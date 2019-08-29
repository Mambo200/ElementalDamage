using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [HideInInspector]
    public Light m_Light;
    private static LightManager m_Instance;
    public static LightManager Get
    {
        get
        {
            if (m_Instance == null)
                m_Instance = GameObject.FindObjectOfType<LightManager>();
            return m_Instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(m_Instance != null)
        {
            Debug.LogWarning("There is already an Lightmanager in scene. Destroy this.");
            Destroy(this.gameObject);
            return;
        }

        m_Instance = GetComponent<LightManager>();
        if (m_Instance == null) Debug.LogWarning("There is no LightManager Component on this Gameobject", this.gameObject);
        m_Light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
