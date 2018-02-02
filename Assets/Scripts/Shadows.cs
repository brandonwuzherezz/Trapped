using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {
    AudioSource audioSource;
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("S_SoundFX").GetComponent<AudioSource>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            if (GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().isActive)
            {
                audioSource.Play();
                Destroy(gameObject);
            }
        }
    }
}
