using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Player;
using Elements.Clothings;

public class EncounterEnter : MonoBehaviour
{
    private GameObject[] m_GOs;
    public MainEntity[] m_Enemies;
    // Start is called before the first frame update
    void Start()
    {

        m_GOs = new GameObject[m_Enemies.Length];


        if(m_Enemies.Length <= 0 || m_Enemies == null)
        {
            Debug.LogError("Enemy Encounter is 0 or null", this.gameObject);
            Debug.Break();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        for (int i = 0; i < m_GOs.Length; i++)
        {
            GameObject go = new GameObject("Enemy", typeof(Slime));
            go.transform.position = new Vector3(0, -10000, 0);

            m_GOs[i] = go;
            m_Enemies[i] = go.GetComponent<MainEntity>();
        }

        MySceneManager.LoadBattleScene(this.gameObject, other.gameObject.transform.position);
    }

    private void OnDestroy()
    {
        foreach (GameObject go in m_GOs)
        {
            Destroy(go);
        }
    }
}
