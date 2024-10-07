using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fin : MonoBehaviour
{
    [SerializeField] changeScene changementScene;

    [SerializeField] Image debut;
    Color transparence;

    float timer = 3f;

    [SerializeField] AnimationCurve fade;

    bool startGame;

    private void Start()
    {
        startGame = false;
        transparence = debut.color;
        transparence.a = 0f;
        debut.color = transparence;
    }


    public void Play()
    {
        startGame = true;
    }


    private void Update()
    {
        if (startGame)
        {
            timer -= Time.deltaTime;

            float pourcentageTransparence = (3f - timer) / 3f;



            transparence.a = fade.Evaluate(pourcentageTransparence);
            debut.color = transparence;

            if (pourcentageTransparence >= 1)
            {
                changementScene.ChangeSceneJeu();
            }
        }
    }
}
