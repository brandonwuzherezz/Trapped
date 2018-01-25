using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public KeyCode flashlightToggleKey = KeyCode.F;
    public float batteryLifeInSeconds = 5f;


    private float batteryLife;
    private bool isActive;

    private Light myLight;



    // Use this for initialization
    void Start()
    {

        myLight = GetComponent<Light>();
        batteryLife = myLight.intensity;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(flashlightToggleKey))
        {
            isActive = !isActive;
        }
        if (isActive)
        {
            myLight.enabled = true;
            myLight.intensity -= 0.01f;
        }
        else
        {
            myLight.enabled = false;
        }
    }

    public void AddBatteryLife(float _batteryPower)
    {
        print(_batteryPower);
        myLight.intensity += _batteryPower;
        print(myLight.intensity);
        if (myLight.intensity > 12)
            myLight.intensity = 12;
    }
}