using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float multiplier;


    void Update()
    {

        if (Time.timeScale != 0)
        {

            float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
            float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
            transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * multiplier), mouseX * multiplier, transform.localRotation.z));
        }
    }
}
