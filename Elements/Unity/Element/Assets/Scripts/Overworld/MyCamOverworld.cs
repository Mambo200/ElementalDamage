using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamOverworld : MonoBehaviour
{
    public float m_MinYDistanceFromPlayer;
    public float m_MaxYDistanceFromPlayer;
    public float m_ScrollSpeed;
    [HideInInspector]
    public static PlayerOverworld m_Player;
    public static Camera m_MainCamera;
    private static MyCamOverworld instance;
    public static MyCamOverworld GetCurrent
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MyCamOverworld>();
                if (instance == null) Debug.LogWarning("MyCamOverworld could not be found");
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        m_Player = transform.parent.GetComponent<PlayerOverworld>();
        if (m_Player == null) Debug.LogWarning("Player is Empty");

        m_MainCamera = GetComponent<Camera>();
        if (m_MainCamera == null) Debug.LogWarning("No Camera on this object", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Camera Scroll
        // 0.1 up | -0.1 down
        float scroll = (Input.GetAxis("Mouse ScrollWheel"));
        
        Vector3 newCamPos = new Vector3()
        {
            x = GetCurrent.transform.position.x,
            y = GetCurrent.transform.position.y - ((scroll * m_ScrollSpeed)),
            z = GetCurrent.transform.position.z
        };
        
        if (newCamPos.y <= m_MinYDistanceFromPlayer)
            newCamPos.y = m_MinYDistanceFromPlayer;
        else if (newCamPos.y >= m_MaxYDistanceFromPlayer)
            newCamPos.y = m_MaxYDistanceFromPlayer;
        
        //Debug.Log(GetCurrent.transform.position);
        //Debug.LogWarning(newCamPos);
        // Set new Camera Position
        GetCurrent.transform.position = newCamPos;
    }

    private void ChangedToOW()
    {

    }
}
