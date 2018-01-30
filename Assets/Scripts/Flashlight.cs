using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public KeyCode flashlightToggleKey = KeyCode.F;
    public float batteryLifeInSeconds = 5f;

    public float totalBatteries;

    private float batteryLife;
    public bool isActive;

    public Light myLight;



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
            myLight.intensity -= 0.1f;
            if (myLight.intensity <= 0)
            {
                isActive = !isActive;
                AddBatteryLife();
            }

        }
        else
        {
            myLight.enabled = false;
        }


    }

    public void Collected(int _collected)
    {
        totalBatteries += _collected;
    }

    public void AddBatteryLife()
    {
        if (totalBatteries > 0)
        {
            totalBatteries -= 1;
            myLight.intensity += 12;
        }
    }
}
