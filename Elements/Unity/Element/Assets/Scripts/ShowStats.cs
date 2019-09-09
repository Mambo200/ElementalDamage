using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements.Player;
public class ShowStats : MonoBehaviour
{
    [HideInInspector]
    public MainEntity main;
    [HideInInspector]
    public Enemy enemy;
    [HideInInspector]
    public GameObject parent;
    private static Color m_MouseOver;
    // save total resistance
    Dictionary<Elements.EElementalTypes, float> m_TotalDefence;
    private static ElementUI m_EUI;
    private SpriteRenderer m_Renderer;

    private bool m_wasHitLastFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        if (m_Renderer == null)
        {
            Debug.LogWarning("There is no SpriteRenderer attached to this object", this.gameObject);
            return;
        }
        m_MouseOver = new Color(0.5613208f, 0.6637937f, 1);
        if (transform.parent == null)
        {
            Debug.LogWarning("This GameObject has no Parent", this.gameObject);
            return;
        }
        parent = transform.parent.gameObject;
        main = GetComponentInParent<MainEntity>();
        if (main == null)
        {
            Debug.LogWarning("There is no Main Entity Class on this object", parent);
            return;
        }
        if (main.Enemy == null)
        {
            Debug.LogWarning("Enemy Class is null. Put Enemy Init in Awake Method", parent);
            return;
        }
        enemy = main.Enemy;

        m_TotalDefence = enemy.TotalResistance;
        if (m_EUI == null)
        {
            //m_EUI = GameObject.FindObjectOfType<ElementUI>();
            //if (m_EUI == null) Debug.LogWarning("No Object with Element UI could be found");
            m_EUI = SceneChangeManager.Get.ElementUI;
            if (m_EUI == null) Debug.LogWarning("No Object with Element UI could be found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Raycast 3D

        Ray ray = MyCamBattle.GetCurrent.m_BattleCam.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(ray, out RaycastHit info))
        {
            // hit nothing
            if (m_wasHitLastFrame)
            {
                // Mouse Left
                m_Renderer.color = Color.white;
                m_wasHitLastFrame = false;
                m_EUI.ResetAllText();
            }
            return;
        }
        
        // hit something
        if (info.collider.gameObject.tag != "StatsObject")
        {
            // Mouse Left
            m_Renderer.color = Color.white;
            m_wasHitLastFrame = false;
            m_EUI.ResetAllText();
        }
        
        if (info.collider.gameObject != this.gameObject) return;
        
        
        if (!m_wasHitLastFrame)
        {
            // Mouse Enter
            m_Renderer.color = m_MouseOver;
            m_wasHitLastFrame = true;
            m_EUI.SetAllText(main, m_TotalDefence);
        
        }
        #endregion
        
    }

    public void RefreshTotalDefence() => m_TotalDefence = enemy.TotalResistance;
}
