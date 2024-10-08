using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
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

    [SerializeField] private GameObject player;
    private Animator playerAnimator;

    [SerializeField] Sprite petitPlayer;


    public void Start()
    {
        playerAnimator = player.GetComponent<Animator>();

    }

    public void Manger(string name)
    {
        playerAnimator.Play("eat");
        if (name == "Champi1")
        {
            //playerAnimator.SetBool("isMutating", true);
            player.GetComponent<SpriteRenderer>().sprite = petitPlayer;
            player.GetComponent<PlayerController>().canJump = false;

        }
        //playerAnimator.SetBool("isEating", false);
        Destroy(gameObject);
    }
}
