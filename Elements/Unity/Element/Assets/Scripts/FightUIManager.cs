using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    private static FightUIManager instance;
    public static FightUIManager Get { get => instance; }

    [SerializeField] private GraphicRaycaster raycaster;

    public bool InMenu { get => !m_MenuButton.gameObject.activeSelf; }
    [Header("Gameobjects")]
    public Button m_MenuButton;
    public GameObject m_FightMenu;

    [Header("Fight Menu Items")]
    public Image m_BackgroundImage;
    public GameObject m_FoodItems;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) Debug.LogWarning("Too many FightUIManagers in scene!");
        instance = GetComponent<FightUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenMenu()
    {
        m_MenuButton.gameObject.SetActive(false);
        m_FightMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        m_FightMenu.SetActive(false);
        m_MenuButton.gameObject.SetActive(true);
    }

}
