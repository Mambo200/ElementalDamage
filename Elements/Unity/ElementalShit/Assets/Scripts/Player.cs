using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements;
using Elements.Player;
using Elements.Clothings;

public class Player : MonoBehaviour
{
    Elements.Player.Player player;
    public ElementUI m_EUI;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        m_EUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = MyCam.GetCurrent.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            if (info.collider.tag == "StatsObject") m_EUI.gameObject.SetActive(true);
            else m_EUI.gameObject.SetActive(false);
        }
        else m_EUI.gameObject.SetActive(false);

    }
}
