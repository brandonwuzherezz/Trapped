using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

	public float batteryPower;

	public void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Flashlight>().AddBatteryLife(batteryPower);
			Destroy(gameObject);
		}
	}
}