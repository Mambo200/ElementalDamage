using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : Item
{
    protected override void Effect()
    {
        SceneChangeManager.Get.m_PlayerBattle.player.Heal(20f);
    }


}
