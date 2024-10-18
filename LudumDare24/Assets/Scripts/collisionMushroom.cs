using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionMushroom : MonoBehaviour
{
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("bounce");
        }
    }
}
