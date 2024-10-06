using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class png : MonoBehaviour
{
    [SerializeField] GameObject bulleDialogue;

    private void Start()
    {
        bulleDialogue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulleDialogue.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bulleDialogue.SetActive(false);
    }
}
