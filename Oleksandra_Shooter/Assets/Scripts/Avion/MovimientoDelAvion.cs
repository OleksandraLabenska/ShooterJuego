using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelAvion : MonoBehaviour
{
    public float vel;
    public float velRot;

    void Update()
    {
        this.transform.Translate(0, 0, vel * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(-velRot * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(velRot * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0,   velRot * Time.deltaTime, 0 );
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0,  -velRot * Time.deltaTime, 0);
        }
    }
}
