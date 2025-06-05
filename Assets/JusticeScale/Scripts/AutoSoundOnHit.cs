using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSoundOnHit : MonoBehaviour
{

    public AudioSource audioSource;
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    // Update is called once per frame
   
}
