using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerChampi : MonoBehaviour
{
    bool dansTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dansTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dansTrigger = false;
    }

    private void Update()
    {
        if (dansTrigger && Input.GetKey(KeyCode.E))
        {
            //play animation
            Destroy(gameObject);
        }
    }
}
