using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    AudioSource audioSource;
    public int collected = 1;
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("B_SoundFX").GetComponent<AudioSource>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().Collected(collected);
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}