using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSkill : MonoBehaviour
{
    public Skill skill;
   
    // Start is called before the first frame update
    public void UseSkill()
    {
        skill.Use();
    }
}
