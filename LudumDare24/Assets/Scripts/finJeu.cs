using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finJeu : MonoBehaviour
{
    [SerializeField] GameObject jeuAller;
    [SerializeField] GameObject jeuRetour;

    [SerializeField] Image fonduFin;
    Color transparence;

    float timer = 1.5f;

    [SerializeField] AnimationCurve fade;

    bool transiMenu;

    private void Start()
    {
        transiMenu = false;
        transparence = fonduFin.color;
        transparence.a = 0f;
        fonduFin.color = transparence;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (jeuAller.activeInHierarchy)
        {
            collision.gameObject.transform.position = new Vector2(45.54f, -0.65f);
        }
        if (jeuRetour.activeInHierarchy)
        {
            transiMenu = true;
        }
    }

    private void Update()
    {
        if (transiMenu)
        {
            timer -= Time.deltaTime;

            float pourcentageTransparence = (1.5f - timer) / 1.5f;
            transparence.a = fade.Evaluate(pourcentageTransparence);
            fonduFin.color = transparence;

            if (pourcentageTransparence >= 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
