using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangerChampi : MonoBehaviour
{
    //bool dansTrigger = false;
    //
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    dansTrigger = true;
    //}
    //
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    dansTrigger = false;
    //}
    //
    //private void Update()
    //{
    //    if (dansTrigger && Input.GetKey(KeyCode.E))
    //    {
    //        //play animation
    //        Destroy(gameObject);
    //    }
    //}

    public void Manger(string name)
    {
        //play anim
        Destroy(gameObject);
        if (name == "Champi1")
        {
            //play animation
            SceneManager.LoadScene("Menu");
        }
    }
}
