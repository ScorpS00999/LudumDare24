using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finJeu : MonoBehaviour
{
    [SerializeField] GameObject jeuAller;
    [SerializeField] GameObject jeuRetour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (jeuAller.activeInHierarchy)
        {
            collision.gameObject.transform.position = new Vector2(45.54f, -0.65f);
        }
        if (jeuRetour.activeInHierarchy)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
