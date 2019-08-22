using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamOverworld : MonoBehaviour
{
    public float m_MinYDistanceFromPlayer;
    public float m_MaxYDistanceFromPlayer;
    public float m_ScrollSpeed;
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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
