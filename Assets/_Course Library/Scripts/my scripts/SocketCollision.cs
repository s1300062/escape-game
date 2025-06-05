using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SocketCollision : MonoBehaviour
{
    public AudioSource socketSound;
    public AudioClip insertSound;

    void OnTriggerEnter(Collider other)
    {
        if (socketSound == null)
        {
            socketSound = GetComponent<AudioSource>();
            if (socketSound == null)
            {
                socketSound = gameObject.AddComponent<AudioSource>();
            }
        }
        if (socketSound != null)
        {
            socketSound.clip = insertSound;
            socketSound.Play();
        }
    }   
}
