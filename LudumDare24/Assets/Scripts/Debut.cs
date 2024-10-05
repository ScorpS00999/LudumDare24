using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debut : MonoBehaviour
{
    [SerializeField] Image debut;
    Color transparence;

    float timer = 3f;

    [SerializeField] AnimationCurve fade;

    private void Start()
    {
        transparence = debut.color;
        transparence.a = 1f;
        debut.color = transparence;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        float pourcentageTransparence = timer / 3f;
        transparence.a = fade.Evaluate(pourcentageTransparence);
        debut.color = transparence;
    }
}
