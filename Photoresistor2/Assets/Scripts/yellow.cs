using UnityEngine;
using System.Collections;

public class yellow : MonoBehaviour
{

    void OnMouseDown()
    {
        print("Clicked");
        Photoresistor.SendYellow();
    }
}
