using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
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

    #endregion
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
    void Start()
    {
        if(instance != null)
        {
            Debug.LogWarning("There is already one instance of SceneChangeManager. Destroy this");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Changes to battle.
    /// </summary>
    /// <param name="m_Enemies">The Instantiated Enemies. Be sure to use <see cref="Object.Instantiate(Object, Transform)"/> bevore using this Function</param>
    public void ChangeToBattle(params GameObject[] m_Enemies)
    {
        if (m_Enemies.Length % 2 == 0)
        {
            // Gerade
        }
        else
        {
            // NOT FINISHED!
            // Ungerade
            float xPos = (m_Enemies.Length - 1) / 2 * m_XShiftPerEnemy;

            for (int i = 0; i < m_Enemies.Length; i++)
            {
                m_Enemies[i].transform.position = new Vector3(
                    m_Enemies[i].transform.position.x,
                    m_Enemies[i].transform.position.y,
                    m_Enemies[i].transform.position.z);
            }

        }
    }

    public void ChangeToOverWorld()
    {

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
            default:
                Debug.LogWarning("Not existing Type", this.gameObject);
                break;
        }

        return null;
    }
}
