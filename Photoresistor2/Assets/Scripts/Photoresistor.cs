using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Threading;
using UnityEngine.UI;

public class Photoresistor : MonoBehaviour {

    private float angleMove;
    public Light green;
    public GameObject lightA;
    private int temp;
    public Text heading;
    public Text instructions;
    private int flag;
    public static SerialPort sp = new SerialPort("COM4", 9600);



    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
        heading.text = "waiting for train";
        instructions.text = "";
        flag = 1;
    }


    void Update()
    {
        if (flag == 1)
        {
            temp = (int.Parse((sp.ReadLine()))) / 10;
            print(temp);
            //temp2 = (int.Parse((sp.ReadLine()))) / 100;
            if (temp < 75)
            {
                SwitchLight(true);
                //green.intensity = temp2;
                heading.text = "Train Detected";
                instructions.text = "Start stage 2";
                Invoke("InvokeFlag2", 1f);


            }
        }
        else if(flag==2)
        {
            heading.text = "Press second";
            instructions.text = "Start stage 2";
        }
    }
   

          
    void InvokeFlag2()
    {
        flag = 2;
    }

    void SwitchLight(bool condition)
    {
        lightA.SetActive(condition);
    }


    public static void SendRed()
    {
        sp.Write("r");
        print("on");
    }
        
    public static void SendYellow()
    {
        sp.Write("y");
        print("yellow");
    }

    public static void SendGreen()
    {
        sp.Write("g");
        print("green");
    }

    private void OnApplicationQuit()
    {
        sp.Close();
    }
}




