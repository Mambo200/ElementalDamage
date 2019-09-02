using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Player;
using Elements.Clothings;
using UnityEngine.Events;

public class EncounterEnter : MonoBehaviour
{
    public EnemySpecificType[] m_Enemies;
    [SerializeField]
    UnityEvent m_AfterDefeated;
    PlayerOverworld m_Player;
    // Start is called before the first frame update
    void Start()
    {

        if (m_Enemies.Length <= 0 || m_Enemies == null)
        {
            Debug.LogError("Enemy Encounter is 0 or null", this.gameObject);
            Debug.Break();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        GameObject[] GOs = new GameObject[m_Enemies.Length];
        for (int i = 0; i < m_Enemies.Length; i++)
        {
            GOs[i] = Instantiate(SceneChangeManager.Get.InvokeEnemy(m_Enemies[i]), this.gameObject.transform);
        }

        // set player in fight bool to true
        m_Player = other.gameObject.GetComponent<PlayerOverworld>();
        m_Player.m_InFight = true;

        SceneChangeManager.Get.ChangeToBattle(this.gameObject, GOs);
    }

    private void OnDestroy()
    {
        // Do Functions if Enemy is dead
        m_AfterDefeated.Invoke();

        // Player is not in fight anymore, set in fight bool to false
        if (m_Player != null)
            m_Player.m_InFight = false;
    }

}
