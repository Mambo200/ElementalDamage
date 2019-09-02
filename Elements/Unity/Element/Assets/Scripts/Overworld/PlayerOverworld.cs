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
        // do nothing in here if Player is in fight
        if (m_InFight == true) return;
        // do nothing in here if Player is in menu
        if (MenuManager.Get.inMenu) return;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(SceneChangeManager.Get.InvokeEnemy(EnemySpecificType.GOLEM));
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z);
        }
    }

}
