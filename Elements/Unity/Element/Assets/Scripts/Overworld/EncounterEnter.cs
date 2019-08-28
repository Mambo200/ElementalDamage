using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Player;
using Elements.Clothings;

public class EncounterEnter : MonoBehaviour
{
    public EnemySpecificType[] m_Enemies;
    // Start is called before the first frame update
    void Start()
    {

        if(m_Enemies.Length <= 0 || m_Enemies == null)
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
#pragma warning HIER
        SceneChangeManager.Get.ChangeToBattle(GOs);
    }

    private void OnDestroy()
    {
    }

}
