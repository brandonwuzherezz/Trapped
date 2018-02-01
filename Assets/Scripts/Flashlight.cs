using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{

    public KeyCode flashlightToggleKey = KeyCode.F;
    public float batteryLifeInSeconds = 5f;

    public float maxIntensity = 12f;

    public int totalBatteries;

    private float batteryLife;
    public bool isActive;

    public Light myLight;

    public Slider flashlightbar;

    public Text text;




    // Use this for initialization
    void Start()
    {

        myLight = GetComponent<Light>();
        batteryLife = myLight.intensity;
        flashlightbar.value = maxIntensity;
        text = GetComponent<Text>();

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
            flashlightbar.value = myLight.intensity / maxIntensity;
            if (myLight.intensity <= 0)
            {
                isActive = !isActive;
                myLight.enabled = false;
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
        BatteryManager.battery += _collected;
    }

    public void AddBatteryLife()
    {
        if (totalBatteries > 0)
        {
            totalBatteries -= 1;
            BatteryManager.battery -= 1;
            myLight.intensity += maxIntensity;
            flashlightbar.value = maxIntensity;
            
        }
    }
}
