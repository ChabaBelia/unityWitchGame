using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    Skill skill;
    string keyCode;
    public Text textKey;
    public Image skillImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //set Skill
    }

    public void UseSkill()
    {
        if(!skill) return;
        skill.Use();
    }

    public void setSkill(Skill _skill)
    {
        skill = _skill;
        skillImage.sprite = skill.icon;
    }

    public bool skillEmpty()
    {
        return skill == null;
    }

    public void setKeyCode(string _keyCode)
    {
        keyCode = _keyCode;
        textKey.text = keyCode;
    }
}
