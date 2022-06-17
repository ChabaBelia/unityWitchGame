using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fireball Skill", menuName = "Skill Tree/SkillFireball")]
public class FireballSkill : Skill
{
    public GameObject skill;
    public int manaConsumption = 30; 

    Vector2 mousePos;
    float playerPosX;


    public override void Use() {
        base.Use();
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        Animator animator = player.GetComponent<Animator>();
        Transform firePosition = player.GetComponent<PlayerAttack>().firePosition;
        Camera cam =  player.GetComponent<PlayerAttack>().cam;

        Debug.Log("Try Fireball Skill Used On enemy");
        playerPosX = player.transform.position.x;
        animator.SetTrigger("Attack");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("AttackDirection", mousePos.x > playerPosX ? 1 : 0);
        Quaternion ballRotation = (mousePos.x < playerPosX) ? Quaternion.Euler(0,0,180) : firePosition.rotation;
        Instantiate(skill, firePosition.position, ballRotation); 
        player.GetComponent<Player>().UseMana(manaConsumption);
    }
}