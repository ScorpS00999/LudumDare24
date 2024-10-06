using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerChampi : MonoBehaviour
{
    bool dansTrigger = false;

    string nameChampi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dansTrigger = true;
        nameChampi = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dansTrigger = false;
    }

    private void Update()
    {
        if (dansTrigger && Input.GetKey(KeyCode.E))
        {
            if (nameChampi == "ChampiJail")
            {
                SwitchGame.Instance.finJeu();
            }
            //play animation
            Destroy(gameObject);
        }
    }
}
