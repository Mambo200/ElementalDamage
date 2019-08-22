using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter m_Target;
    public bool m_TeleporterActive = true;
    private bool TeleportActiveBackup = true;

    private bool m_active = true;
    private bool m_Teleport = false;
    private Renderer m_Renderer;

    // Shader    
    /// <summary>ID of first Circle</summary>
    private int m_FirstProperty;
    /// <summary>ID of second Circle</summary>
    private int m_SecondProperty;

    /// <summary>Color of first Circle if Teleporter is active</summary>
    private static Vector3 m_InnerCircleActive = new Vector3();
    /// <summary>Color of second Circle if Teleporter is active</summary>
    private static Vector3 m_OuterCircleActive = new Vector3();
                         
    /// <summary>Color of first Circle if Teleporter is inactive</summary>
    private static Vector3 m_InnerCircleInactive = new Vector3();
    /// <summary>Color of second Circle if Teleporter is inactive</summary>
    private static Vector3 m_OuterCircleInactive = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        if (m_Target == null)
        {
            Debug.LogWarning("Target is null", this.gameObject);
            Debug.Break();
        }
        m_Renderer = GetComponent<Renderer>();

        // Get Shader ID
        m_FirstProperty = Shader.PropertyToID("_ColorOne");
        m_SecondProperty = Shader.PropertyToID("_ColorTwo");

        // Get Vector Colors from Shader
        if(m_InnerCircleActive == new Vector3())
        {
            m_InnerCircleActive = m_Renderer.material.GetVector(m_FirstProperty);
            m_OuterCircleActive = m_Renderer.material.GetVector(m_SecondProperty);

            Debug.Log("Go Here if you want to change inactive Teleporter Colors", this.gameObject);
            m_InnerCircleInactive = new Vector3(0, 0, 0);
            m_OuterCircleInactive = new Vector3(0.2f, 0.2f, 2);
        }
    }

    private void Update()
    {
        if(m_TeleporterActive != TeleportActiveBackup)
        {
            if(m_TeleporterActive)
            {
                // wurde Aktiviert
                m_Renderer.material.SetVector(m_FirstProperty, m_InnerCircleActive);
                m_Renderer.material.SetVector(m_SecondProperty, m_OuterCircleActive);
            }
            else
            {
                // wurde deaktiviert
                m_Renderer.material.SetVector(m_FirstProperty, m_InnerCircleInactive);
                m_Renderer.material.SetVector(m_SecondProperty, m_OuterCircleInactive);
            }
            TeleportActiveBackup = m_TeleporterActive;
        }

    }

    private void LateUpdate()
    {
        if (!m_Teleport) return;

        m_Target.m_active = false;
        MyCamOverworld.m_Player.transform.position = m_Target.transform.position + new Vector3(0, 1.1f, 0);
        m_Teleport = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        // check if Teleporter is active
        if (!m_TeleporterActive) return;
        // check wwho triggered this event
        if (other.gameObject.tag != "Player") return;
        // check if Teleporter was used from the other side
        if (!m_active) return;

        // move Player to location
        m_Target.m_active = false;
        m_Teleport = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        m_active = true;
    }
}
