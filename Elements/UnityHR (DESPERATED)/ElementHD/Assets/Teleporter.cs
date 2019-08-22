using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter m_Target;
    private bool m_active = true;
    // Start is called before the first frame update
    void Start()
    {
        if (m_Target == null) Debug.LogWarning("Target is null", this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Teleporter");
        if (other.gameObject.tag != "Player") return;
        if (!m_active) return;

        // move Player to location
        m_Target.m_active = false;
        MyCamOverworld.m_Player.transform.position = m_Target.transform.position + new Vector3(0, 2, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        m_active = true;
    }
}
