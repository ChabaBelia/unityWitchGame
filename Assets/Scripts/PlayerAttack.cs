using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    public Animator animator;
    public Camera cam;

    Vector2 mousePos;
    float playerPosX;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            playerPosX = gameObject.transform.position.x;
            animator.SetTrigger("Attack");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetFloat("AttackDirection", mousePos.x > playerPosX ? 1 : 0);
            Quaternion ballRotation = (mousePos.x < playerPosX) ? Quaternion.Euler(0,0,180) : firePosition.rotation;
            Instantiate(projectile, firePosition.position, ballRotation); 
        } 
    }
}
