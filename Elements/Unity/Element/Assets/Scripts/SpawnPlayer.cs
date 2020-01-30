using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject m_Player;
    public Vector3 m_Startposition;
    void Awake()
    {
        GameObject.Instantiate(m_Player, m_Startposition, new Quaternion());
    }
}
