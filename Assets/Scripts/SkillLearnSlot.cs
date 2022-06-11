using UnityEngine;
using UnityEngine.UI;

public class SkillLearnSlot : MonoBehaviour
{
    public Image iconDisable;
    public Image iconClose;
    Image iconSkill;
    Button useButton;
    public Skill skill;
    public SkillTreeUI skillTree;
    bool learned = false;
    bool locked = false;
    bool opened = false;
    bool enableToLearn = false;
    public SkillLearnSlot[] slots;

    public void Start()
    {
        Debug.Log("\n\nStart SkillLearnSlot - " + skill.name);
        useButton = GetComponent<Button>();
        iconSkill = GetComponent<Image>();
        if(iconDisable) 
            iconDisable.enabled = true;
        iconClose.enabled = true;
        iconSkill.sprite = skill.icon;
        iconSkill.enabled = false;
        enableToLearn = false;
        skill.setSkillInfo(GetComponentsInChildren<SkillInfo>()[0]);
        Debug.Log("slots.Length: " + slots.Length);
        for (int i = 0 ; i < slots.Length; ++i)
        {
            Debug.Log("GetComponentsInChildren: " + slots[i].skill.name);
        }
        Debug.Log("End Start SkillLearnSlot - " + skill.name + "\n\n");
    }

    public void openSkill()
    {
        iconClose.enabled = false;
        opened = true;

        if(locked) return;

        if(enableToLearn)
            enableSkillToLearn();
    }

    public void enableSkillToLearn()
    {
        useButton = GetComponent<Button>();
        Debug.Log("enableSkillToLearn " + skill.name);
        enableToLearn = true;
        if(locked || learned || !opened) return;

        useButton.enabled = true;
        useButton.interactable = true;
        iconSkill.enabled = true;
    }

    public void learnSkill()
    {
        Debug.Log("learnSkill " + skill.name);
        if(locked || learned || !opened) return;

        learned = true;
        for (int i = 0 ; i < slots.Length; ++i)
        {
            slots[i].enableSkillToLearn();
        }
        skillTree.updateSkillTree();

        useButton.enabled = false;
        if(iconDisable)
            iconDisable.enabled = false;
    }

    public void forgetSkill()
    {

    }

    public bool Learned()
    {
        return learned;
    }

    public void Lock()
    {
        Debug.Log("Lock " + skill.name);
        locked = true;
        useButton.enabled = false;
        for (int i = 0 ; i < slots.Length; ++i)
        {
            slots[i].Lock();
        }
    }

    public void Unlock()
    {
        locked = true;
        for (int i = 0 ; i < slots.Length; ++i)
        {
            slots[i].Unlock();
        }
    }

    public bool Locked()
    {
        return locked;
    }

    public void pointerEnter()
    {
        skill.ShowInfo();
    }

    public void pointerLeave()
    {
        skill.HideInfo();
    }
}
