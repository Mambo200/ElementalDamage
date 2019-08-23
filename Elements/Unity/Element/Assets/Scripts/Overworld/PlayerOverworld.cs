using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworld : MonoBehaviour
{
    public CharacterController Controller { get; private set; }
    
    public float m_MoveSpeed;
    public bool m_InFight = false;

    // gravity
    public float m_FallSpeed;
    public float m_MaxFallSpeed = float.PositiveInfinity;
    private float m_CurrentFallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_InFight == true) return;

        if (MySceneManager.m_ChangedToOW)
            ChangedToOW();

        Vector3 toMove = new Vector3();
        // Gravity
        if(!Controller.isGrounded)
        {
            m_CurrentFallSpeed += (m_FallSpeed * m_FallSpeed) * Time.deltaTime;
            if (m_CurrentFallSpeed > m_MaxFallSpeed) m_CurrentFallSpeed = m_MaxFallSpeed;
            toMove.y -= m_CurrentFallSpeed;

        }
        else
        {
            m_CurrentFallSpeed = 0;
            toMove.y = 0;
        }

        //Input

        float UpDown = (Input.GetAxisRaw("Horizontal"));
        float LeftRight = (Input.GetAxisRaw("Vertical"));

        toMove.x += UpDown;
        toMove.z += LeftRight;

        

        // Set Position
        Controller.Move((toMove.normalized * Time.deltaTime * m_MoveSpeed) + new Vector3(0, toMove.y, 0));
    }

    private void ChangedToOW()
    {
        CharacterController c = GetComponent<CharacterController>();
        c.enabled = false;
        transform.position = MySceneManager.m_PlayerPosition;
        c.enabled = true;

        MySceneManager.m_Executed = true;
    }

}
