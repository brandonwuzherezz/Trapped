﻿using System.Collections;
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



    public float speed = 6f;



    AudioSource audioSource;


    // Use this for initialization
    void Start()
    {

        myLight = GetComponent<Light>();
        batteryLife = myLight.intensity;

        flashlightbar.value = maxIntensity;
        text = GetComponent<Text>();


        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(flashlightToggleKey))
        {
            isActive = !isActive;

            if (myLight.intensity > 0)
            {
                audioSource.Play();
            }

        }
        if (isActive)
        {

            myLight.enabled = true;
            myLight.intensity -= 0.1f;

            flashlightbar.value = myLight.intensity / maxIntensity;


            // transform.rotation = myCamera.ScreenToWorldPoint(Vector3(Input.mousePosition.x, /*Input.mousePosition.y*/0, Input.mousePosition.y));
            //transform.rotation = 
            /*var pos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
            //transform.Rotate(new Vector3(0, 0, 200) * speed);

            //var pos = Input.mousePosition;
            //var worldpos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, pos.y));
            // Debug.Log(pos);
            //Vector3 target = new Vector3(pos.x, pos.y, pos.y);
            /*Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 targetDir = lookPos - transform.position;
            //float step = speed * Time.deltaTime;
            Vector3 newDir = lookPos - targetDir; //Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            //Debug.Log(newDir);
            Quaternion rotation = Quaternion.LookRotation(newDir);
            transform.rotation = rotation;*/

            Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y); //mouse position
            //Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos); // convert to position in the world

            //lookPos = lookPos - transform.position; // offset by the position of flashlight

            float angle = Mathf.Atan2(mousePos.x - 959.0f, mousePos.z - 573.0f) * Mathf.Rad2Deg; // arctan b/w x and y            
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); //rotate based on angle and axis(forward = z and up = y)      
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
            Debug.Log("lookPos: " + mousePos);


            if (myLight.intensity <= 0)
            {
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
            isActive = !isActive;

        }

    }
}
