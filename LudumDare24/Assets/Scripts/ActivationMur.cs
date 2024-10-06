using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationMur : MonoBehaviour
{
    [SerializeField] GameObject murAvant;
    [SerializeField] GameObject murApres;

    CharacterDisplay sonCharacterDisplay;

    private void Start()
    {
        murAvant.SetActive(false);
        murApres.SetActive(false);

        Transform characDisplayTransform = this.transform.parent;
        sonCharacterDisplay = characDisplayTransform.GetComponent<CharacterDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sonCharacterDisplay.changerIndex(0);


        murAvant.SetActive(true);
        murApres.SetActive(true);
    }

    public void ActivationZone()
    {
        murApres.SetActive(false);
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
