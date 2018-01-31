using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryManager : MonoBehaviour {

    // Use this for initialization

    public static int battery;

    Text text;


    void Start () {

        text = GetComponent<Text>();
        battery = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "Batteries: " + battery;
		
	}
}
