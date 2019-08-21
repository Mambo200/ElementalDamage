using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCam : MonoBehaviour
{
    public static Camera instance;
    public static Camera GetCurrent
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            return instance;
        }
    }
}
