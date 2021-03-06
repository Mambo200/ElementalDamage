﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField] private ElementUI m_ElementUI;
    public ElementUI ElementUI { get { return m_ElementUI; } }

    [Header("Main Gameobjects of Overworld and Battle")]
    [SerializeField] public Player m_PlayerBattle;
    [SerializeField] public PlayerOverworld m_PlayerOW;

    [Header("Main Gameobjects of Overworld and Battle")]
    [SerializeField] private GameObject m_OverWorldGO;
    [SerializeField] private GameObject m_BattleGO;

    [Header("Enemy Spawn")]
    [SerializeField] private Vector3 m_StartPos;
    [SerializeField] private float m_XShiftPerEnemy;

    #region Enemies
    [Header("Enemies")]
    [SerializeField] private GameObject m_Slime;
    [SerializeField] private GameObject m_Golem;
    [SerializeField] private GameObject m_Bush;
    [SerializeField] private GameObject m_Icegolem;
    #endregion

    [Header("Light")]
    [SerializeField] private Color m_OverWorldColor;
    [SerializeField] private Color m_BattleColor;


    /// <summary>Trigger object is set to this so when Fight is over SceneChangeManager can destroy it</summary>
    private GameObject m_EncounterTrigger;

    private static SceneChangeManager instance;
    public static SceneChangeManager Get
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneChangeManager>();
                if (instance == null)
                {
                    Debug.LogWarning("no SceneChangeMaanager could be found.");
                    Debug.Break();
                }
            }
                return instance;
        }
    }
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        if (m_ElementUI == null) Debug.LogWarning("Element UI is not set", this.gameObject);
        if(instance != null)
        {
            Debug.LogWarning("There is already one instance of SceneChangeManager. Destroy this");
            Destroy(this.gameObject);
            yield break;
        }
        instance = this;

        m_BattleGO.SetActive(true);
        MyCamBattle.GetCurrent.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        m_PlayerBattle.Start();
        MyCamBattle.GetCurrent.gameObject.SetActive(true);
        m_BattleGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Changes to battle.
    /// </summary>
    /// <param name="m_Enemies">The Instantiated Enemies. Be sure to use <see cref="Object.Instantiate(Object, Transform)"/> bevore using this Function</param>
    public void ChangeToBattle(GameObject _trigger, params GameObject[] m_Enemies)
    {
        // set trigger GO
        m_EncounterTrigger = _trigger;

        float xPos = 0;
        // calculate position of enemies
        if (m_Enemies.Length % 2 == 0)
            // Gerade
            // get most left x pos
            xPos = -(m_Enemies.Length - 1) * (m_XShiftPerEnemy / 2);
        else
            // Ungerade
            // get most left x pos
            xPos = -(m_Enemies.Length - 1) / 2 * m_XShiftPerEnemy;

        for (int i = 0; i < m_Enemies.Length; i++)
        {
            m_Enemies[i].transform.position = new Vector3(
                0 + xPos + i * m_XShiftPerEnemy,
                10000 - 6,
                //m_Enemies[i].transform.position.z
                10);
        }


        // activate Fight Scene
        m_BattleGO.SetActive(true);

        // Set Light Color
        LightManager.Get.m_Light.color = m_BattleColor;

        // deactivate OW Camera. activate Battle Camera
        MyCamOverworld.GetCurrent.gameObject.SetActive(false);
        MyCamBattle.GetCurrent.gameObject.SetActive(true);

        // deactivate Menu Button
        MenuManager.Get.m_MenuButton.gameObject.SetActive(false);

        FightManager.GetFight.NewRound();
    }

    public void ChangeToOverWorld()
    {
        // destory trigger GO
        Destroy(m_EncounterTrigger);
        m_EncounterTrigger = null;

        // Set Light Color
        LightManager.Get.m_Light.color = m_OverWorldColor;

        // disable battleground Gameobject
        m_BattleGO.SetActive(false);

        // activate OW Camera
        MyCamOverworld.GetCurrent.gameObject.SetActive(true);

        // activate Menu Button
        MenuManager.Get.m_MenuButton.gameObject.SetActive(true);

    }

    /// <summary>
    /// returns Gameobect. Does not Instantiate!
    /// </summary>
    /// <param name="_type">The type.</param>
    /// <returns></returns>
    public GameObject InvokeEnemy(EnemySpecificType _type)
    {
        switch (_type)
        {
            case EnemySpecificType.SLIME:
                return m_Slime;
            case EnemySpecificType.GOLEM:
                return m_Golem;
            case EnemySpecificType.BUSH:
                return m_Bush;
            case EnemySpecificType.ICEGOLEM:
                return m_Icegolem;
            default:
                Debug.LogWarning("Not existing Type", this.gameObject);
                break;
        }

        return null;
    }
}
