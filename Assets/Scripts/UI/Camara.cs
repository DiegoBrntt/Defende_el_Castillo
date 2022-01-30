using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float Vel = 5f;



    void Update()
    {
        Vector3 MoverCam = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            MoverCam.z += Vel * Time.deltaTime;
            MoverCam.z = Mathf.Clamp(MoverCam.z, -44.63f, -29.31f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoverCam.z -= Vel * Time.deltaTime;
            MoverCam.z = Mathf.Clamp(MoverCam.z, -44.63f, -29.31f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoverCam.x -= Vel * Time.deltaTime;
            MoverCam.x = Mathf.Clamp(MoverCam.x, -71.15f, -30.94f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoverCam.x += Vel * Time.deltaTime;
            MoverCam.x = Mathf.Clamp(MoverCam.x, -71.15f, -30.94f);
        }

        transform.position = MoverCam;
    }
}
