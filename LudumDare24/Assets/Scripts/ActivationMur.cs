using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationMur : MonoBehaviour
{
    [SerializeField] GameObject murAvant;
    [SerializeField] GameObject murApres;

    private void Start()
    {
        murAvant.SetActive(false);
        murApres.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        murAvant.SetActive(true);
        murApres.SetActive(true);
    }

    public void ActivationZone()
    {
        murApres.SetActive(false);
    }
}
