using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Hint Attributes")]
    public string m_HintText = "No Replace";
    public Color m_HintColor = Color.black;

    [Header("Backgound Attributes")]
    public Color m_BackgroundColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // If other isnt player return
        if (other.gameObject.tag != "Player") return;

        UIManagerOverworld.Get.SetHintActive(true);
        UIManagerOverworld.Get.SetHintText(m_HintText, m_HintColor);
        UIManagerOverworld.Get.SetHintBackgroundColor(m_BackgroundColor);
    }

    private void OnTriggerExit(Collider other)
    {
        // If other isnt player return
        if (other.gameObject.tag != "Player") return;

        UIManagerOverworld.Get.SetHintActive(false);

    }
}
