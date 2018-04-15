using UnityEngine;
using System.Collections;

public class red : MonoBehaviour
{

    void OnMouseDown()
    {
        print("Clicked");
        Photoresistor.SendRed();
    }
}
