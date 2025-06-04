using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SocketCollision : MonoBehaviour
{
    public AudioSource socketSound;
    public AudioClip insertSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
