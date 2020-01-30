using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public bool m_deactivateOnStart;

    private bool m_startExecuted;
    // Start is called before the first frame update
    void Start()
    {
        if (m_startExecuted) return;

        DontDestroyOnLoad(this.gameObject);
        gameObject.SetActive(!m_deactivateOnStart);

        m_startExecuted = true;

    }
}
