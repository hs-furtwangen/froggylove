using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private bool gyroEnabled;
    public Gyroscope gyro;
    public Quaternion rot;
  

    // Use this for initialization
    void Start () {

        gyroEnabled = EnableGyro();
		
	}
	
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            //this.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = Quaternion.Euler(95f, 120f, 0f);
            //rot = new Quaternion(0, 0, 1, 0);
            Debug.Log("Funktioniert");
            return true;
        }
        Debug.Log("Funktioniert nicht");
        return false;
    }

    private void Update()
    {
        if (Input.gyro.enabled)
        {
            // Debug.Log(Input.gyro.attitude);
            transform.localRotation = rot * Quaternion.Inverse(gyro.attitude);
            // transform.rotation = Quaternion.Euler(Input.deviceOrientation.);
            //transform.localRotation = gyro.attitude * rot;
        }
    }
}
