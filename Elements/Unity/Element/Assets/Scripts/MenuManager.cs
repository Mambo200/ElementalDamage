using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI Elements
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [System.Obsolete("Only use this to instanciate! Only use in MenuManager.Get and MenuManager.Load()")]
    /// <summary>Instance. DO NOT USE!</summary>
    private static MenuManager instance;
    /// <summary>Returns the instance of Menu Manager</summary>
    public static MenuManager Get
    {
        get
        {
#pragma warning disable CS0618
            if (instance == null)
            {
                instance = FindObjectOfType<MenuManager>();
                if (instance == null) Debug.LogWarning("No Instance of MenuManager found.");
            }
            return instance;
#pragma warning restore CS0618
        }
    }

    #region Player Info
    /// <summary>The Overworld Player</summary>
    [Header("Player")]
    [Tooltip("The Player which you can control in the overworld")]
    public PlayerOverworld m_PlayerOverworld;

    /// <summary>The Battle Player</summary>
    [Tooltip("The Player which is used in Battle. There the actual Player info, like HP, is saved.")]
    public Player m_PlayerBattle;
    #endregion

    #region Button things
    /// <summary>The Menu Button</summary>
    [Header("Menu Button Things")]
    [Tooltip("This is the Button where the Player can Click to open the Menu.")]
    public Button m_MenuButton;

    /// <summary>The Text of the Menu Button</summary>
    [Tooltip("This is the Text of the Button.")]
    public TMPro.TMP_Text m_ButtonText;
    #endregion

    #region Menu Itself
    /// <summary>The Main GameObject for the Menu</summary>
    [Header("Menu Itself")]
    [Tooltip("This is the main GameObject where the Menu objects are connected with.")]
    public GameObject m_MenuItself;

    /// <summary>The Menu Background.</summary>
    [Tooltip("The Image Object for dimming so the player can differentiate between the Game and the Menu")]
    public Image m_MenuBackgroundDimm;

    /// <summary>The Player Background.</summary>
    [Tooltip("The Image Object for dimming so the player can differentiate between the Menu and the Player Info")]
    public Image m_PlayerInfoDimm;

    /// <summary>Name of Player</summary>
    [Tooltip("The Text Mesh Pro Object. To change the Text to the players Name")]
    public TMPro.TMP_Text m_PlayerName;

    /// <summary>Textobject Current HP Left Side.</summary>
    [Tooltip("The Current HP Text Object on the left side")]
    public TMPro.TMP_Text m_PlayerHPText;

    /// <summary>Player HP Right Side.</summary>
    [Tooltip("The Current HP Text Object on the right side")]
    public TMPro.TMP_Text m_PlayerHP;
    #endregion

    /// <summary>Changes Color of Current HP Text depending on <see cref="Elements.Player.PlayerEntity.HealthPercentage"/></summary>
    [Header("Color of Current HP Text")]
    [Tooltip("Color Gradient which changed the Color of the Current HP text")]
    public Gradient m_CurrentHPColor;

    /// <summary>Returns true if Player in in Menu -> if Menu Button is not active return true</summary>
    public bool inMenu { get => !m_MenuButton.gameObject.activeSelf; }

    /// <summary>
    /// Set <see cref="instance"/>
    /// </summary>
    private void Load()
    {
        #region Create Instance of MenuManager
#pragma warning disable CS0618
        if (instance != null)
        {
            Debug.LogWarning("Instance with MenuManager already exists. take care!");
            Destroy(this.gameObject);
            return;
        }
        instance = this.GetComponent<MenuManager>();
#pragma warning restore CS0618
        #endregion

    }

    // Start is called before the first frame update
    void Start()
    {
        // Set Instance
        Load();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateMenu()
    {
        m_MenuButton.gameObject.SetActive(false);
        m_MenuItself.gameObject.SetActive(true);

        SetPlayer1Info();
    }

    public void CloseMenu()
    {
        m_MenuButton.gameObject.SetActive(true);
        m_MenuItself.gameObject.SetActive(false);
    }

    private void SetPlayer1Info()
    {
        // Set Name Info
        m_PlayerName.SetText(m_PlayerBattle.player.Name);

        // Set HP Info
        m_PlayerHP.SetText(((int)m_PlayerBattle.player.CurrentHealth).ToString() + " / " + ((int)m_PlayerBattle.player.MaxHealth).ToString());

        // Set HP Color
        m_PlayerHP.color = m_CurrentHPColor.Evaluate(m_PlayerBattle.player.HealthPercentageZeroOne);
    }
}
