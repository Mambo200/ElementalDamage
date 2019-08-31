using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Elements;
using Elements.Player;
using Elements.Clothings;

public class Player : MonoBehaviour
{
    public bool attacked = false;

    public Elements.Player.Player player;
    public ElementUI m_EUI;
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        player = new Elements.Player.Player("Haans", 200, 200, new Gear(new Top(), new Shirt(), new Pants()), PlayerWeapon.Icicle(1));

        yield return new WaitForEndOfFrame();
        m_EUI.gameObject.SetActive(false);

        // look for Enemys
    }

    // Update is called once per frame
    void Update()
    {
        ShootRayForStats();

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCamBattle.GetCurrent.m_BattleCam.ScreenPointToRay(Input.mousePosition);

            // something was hit
            if(Physics.Raycast(r, out RaycastHit info))
            {
                // Enemy was hit
                if(info.collider.gameObject.tag == "Enemy")
                {
                    FightManager.GetFight.ChangeIndex(info.collider.gameObject);
                }
            }
        }

        Attack();
    }

    private void ShootRayForStats()
    {
        Ray ray = MyCamBattle.GetCurrent.m_BattleCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            if (info.collider.tag == "StatsObject") m_EUI.gameObject.SetActive(true);
            else m_EUI.gameObject.SetActive(false);
        }
        else m_EUI.gameObject.SetActive(false);
    }

    private void Attack()
    {
        // do nothing if its enemys turn
        if (FightManager.GetFight.EnemyTurn) return;

        if (Input.GetMouseButtonDown(1))
        {
            FightManager.GetFight.Attack(player);
            attacked = true;
        }
    }


}
