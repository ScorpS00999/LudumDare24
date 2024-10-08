using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundsGlands : MonoBehaviour
{
    [SerializeField] AudioClip soundCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(soundCollect, transform.position);
            print("uwu");
        }
    }
}
