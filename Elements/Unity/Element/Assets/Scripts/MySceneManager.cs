using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static bool m_Executed = false;
    public static bool m_ChangedToOW { get; private set; }
    SceneManager m = new SceneManager();
    public static GameObject m_LastFight;
    public static Vector3 m_PlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        MySceneManager[] scenes = FindObjectsOfType<MySceneManager>();
        if (scenes.Length > 1)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (m_Executed)
        {
            MySceneManager.m_ChangedToOW = false;
            m_Executed = false;
        }
    }

    public static void LoadBattleScene(GameObject _trigger, Vector3 _playerPosition)
    {
        m_LastFight = _trigger;
        m_PlayerPosition = _playerPosition;
        MyCamOverworld.m_MainCamera.gameObject.SetActive(false);
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
    }

    public static void LoadOverWorldScene()
    {
        SceneManager.UnloadSceneAsync("Battle");

        
        if (m_LastFight != null)
            Destroy(m_LastFight);
        m_LastFight = null;

        m_ChangedToOW = true;
        m_Executed = false;

        DestroyImmediate(m_LastFight);
        MyCamOverworld.m_MainCamera.gameObject.SetActive(true);
        MyCamOverworld.m_Player.GetComponent<PlayerOverworld>().m_InFight = false;


    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            BattleLoaded();
        }
    }


    static void BattleLoaded()
    {
        MyCamBattle.GetCurrent.m_BattleCam.gameObject.SetActive(true);
        MyCamOverworld.m_Player.GetComponent<PlayerOverworld>().m_InFight = true;
    }
}
