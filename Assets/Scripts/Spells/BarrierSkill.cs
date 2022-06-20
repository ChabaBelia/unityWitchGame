using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Barrier Skill", menuName = "Skill Tree/SkillBarrier")]
public class BarrierSkill : Skill
{
    public int manaConsumption = 50; 
    public int duration = 10;
    GameObject player;

    public override void Use() {
        base.Use();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Player>().EnableBarrier(duration);
    }
}