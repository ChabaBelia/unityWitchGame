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
        Debug.Log("Try Thunder Skill Used On enemy ");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("Thunder Skill Used On enemy ");
            Instantiate(skill, enemy.transform.position, enemy.transform.rotation);
        }
        
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Player>().UseMana(manaConsumption);
    }
}
