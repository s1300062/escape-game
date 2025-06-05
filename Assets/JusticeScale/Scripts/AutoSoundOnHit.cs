using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSoundOnHit : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
