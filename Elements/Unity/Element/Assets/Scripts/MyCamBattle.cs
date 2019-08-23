using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamBattle : MonoBehaviour
{
    public Camera m_BattleCam;
    public static MyCamBattle instance;
    public static MyCamBattle GetCurrent
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("BattleCam").GetComponent<MyCamBattle>();
            }
            return instance;
        }
    }

    private void Start()
    {
    }
}
