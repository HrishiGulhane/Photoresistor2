using UnityEngine;
using System.Collections;

public class green : MonoBehaviour
{

    void OnMouseDown()
    {
        print("Clicked");
        Photoresistor.SendGreen();
    }
}
