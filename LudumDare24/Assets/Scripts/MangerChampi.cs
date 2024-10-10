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

    [SerializeField] AudioClip sound;


    public void Start()
    {
        playerAnimator = player.GetComponent<Animator>();

    }

    public void Manger(string name)
    {
        player.GetComponent<PlayerController>().enabled = false;
        playerAnimator.Play("eat");

        AudioSource.PlayClipAtPoint(sound, transform.position);


        if (name == "Champi1")
        {
            playerAnimator.SetBool("isMutating", true);
            player.GetComponent<SpriteRenderer>().sprite = petitPlayer;
            player.GetComponent<PlayerController>().canJump = false;

        }
        StartCoroutine(attendreFinAnim());
        //playerAnimator.SetBool("isEating", false);
        
    }

    IEnumerator attendreFinAnim()
    {
        yield return new WaitForSeconds(1.07f);
        player.GetComponent<PlayerController>().enabled = true;
        Destroy(gameObject);
    }
}
