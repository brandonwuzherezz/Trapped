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

    //public Camera camera;
    //private mousePosition;
     public float speed;
    //private Camera myCamera;

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
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          /*  if (Input.GetMouseButtonDown(0))
            {
                Vector3 target = new Vector3(0, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
                Vector3 targetDir = target - transform.position;
                float step = speed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                transform.rotation = Quaternion.LookRotation(newDir);
            }*/
        }
        if (isActive)
        {
            myLight.enabled = true;
            myLight.intensity -= 0.1f;

            // transform.rotation = myCamera.ScreenToWorldPoint(Vector3(Input.mousePosition.x, /*Input.mousePosition.y*/0, Input.mousePosition.y));
            //transform.rotation = 
            /*var pos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0); //Quaternion.AngleAxis(angle, Vector3.forward);*/
            //transform.Rotate(new Vector3(0, 0, 20) * speed);
            
            //mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));
            //rigidbody.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90);
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
