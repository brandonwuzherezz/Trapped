using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{

    public int collected = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().Collected(collected);
            Destroy(gameObject);
        }
    }
}