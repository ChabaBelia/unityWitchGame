using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Thunder Skill", menuName = "Skill Tree/SkillThunder")]
public class ThunderSkill : Skill
{
    public GameObject skill;
    public int manaConsumption = 50; 

    public override void Use() {
        base.Use();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Instantiate(skill, enemy.transform.position, enemy.transform.rotation);
        }
        
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Player>().UseMana(manaConsumption);
    }
}
