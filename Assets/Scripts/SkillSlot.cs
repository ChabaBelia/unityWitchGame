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
    public Image coolDownOverlay;

    // Update is called once per frame
    void Update()
    {
        if(skill && skill.isCoolDown) {
            coolDownOverlay.fillAmount -= 1 / skill.cooldownTime * Time.deltaTime;
            if(coolDownOverlay.fillAmount <= 0) {
                coolDownOverlay.fillAmount = 0;
                skill.isCoolDown = false;
            }
        }
    }

    public void OnClick()
    {
        //set Skill
    }

    public void UseSkill()
    {
        if(!skill || skill.isCoolDown) return;
        skill.isCoolDown = true;
        coolDownOverlay.fillAmount = 1;
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
