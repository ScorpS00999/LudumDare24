using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementSon : MonoBehaviour
{
    

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void changementSon(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
