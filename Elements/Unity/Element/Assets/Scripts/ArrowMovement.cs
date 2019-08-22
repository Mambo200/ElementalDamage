using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float m_Zero;
    public float m_DistanceToZero;
    public float m_Speed;
    private bool up = true;

    // Update is called once per frame
    void Update()
    {
        // Move Arrow up
        if (up)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y + Time.deltaTime * m_Speed,
                transform.localPosition.x);
            if (transform.localPosition.y >= m_Zero + m_DistanceToZero) up = !up;
        }

        // Move Arrow down
        else
        {
            transform.localPosition = new Vector3
                (transform.localPosition.x,
                transform.localPosition.y + (Time.deltaTime * m_Speed * -1),
                transform.localPosition.x);
            if (transform.localPosition.y <= m_Zero - m_DistanceToZero) up = !up;
        }

    }
}
