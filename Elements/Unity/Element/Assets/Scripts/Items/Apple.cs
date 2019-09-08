using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Item
{
    protected override void Effect()
    {
        SceneChangeManager.Get.m_PlayerBattle.player.Heal(50f);
    }
}
