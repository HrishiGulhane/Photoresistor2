using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class please : MonoBehaviour
{




    SerialPort sp = new SerialPort("COM4", 9600);


    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {

            print((sp.ReadLine()));
        }


    }
}
