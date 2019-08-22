using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerOverworld : MonoBehaviour
{
    public Image m_HintBackground;
    public Text m_HintText;
    [SerializeField]
    private GameObject m_Hint;

    // Static Variables
    private static UIManagerOverworld instance;
    public static UIManagerOverworld Get
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<UIManagerOverworld>();
                if (instance == null)
                {
                    Debug.LogWarning("No UIManagerOverworld could be found.");
                    Debug.Break();
                }
            }

            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (m_HintBackground == null) Debug.LogWarning("Hint Background is null", this.gameObject);
        if (m_HintText == null) Debug.LogWarning("Hint Text is null", this.gameObject);
        if (m_Hint == null) Debug.LogWarning("Hint Gameobject is null", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets the active state of the main Hint Gameobject
    /// </summary>
    /// <param name="_active">if set to <c>true</c> [active].</param>
    public void SetHintActive(bool _active) => m_Hint.SetActive(_active);

    /// <summary>
    /// Sets the hint text.
    /// </summary>
    /// <param name="_text">The text.</param>
    public void SetHintText(string _text) => Get.m_HintText.text = _text;

    /// <summary>
    /// Sets the hint text and the Color.
    /// </summary>
    /// <param name="_text">The text.</param>
    /// <param name="_color">The color.</param>
    public void SetHintText(string _text, Color _color)
    {
        Get.m_HintText.text = _text;
        Get.m_HintText.color = _color;
    }

    /// <summary>
    /// Sets the color of the background of the Hint box.
    /// </summary>
    /// <param name="_color">The color.</param>
    public void SetHintBackgroundColor(Color _color) => Get.m_HintBackground.color = _color;
}
