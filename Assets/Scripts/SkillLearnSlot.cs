using UnityEngine;
using UnityEngine.UI;

public class SkillLearnSlot : MonoBehaviour
{
    public Image iconDisable;
    public Image imageUnknownSkill;
    Image iconSkill;
    Button useButton;
    public Skill skill;
    public SkillTreeUI skillTree;
    bool learned = false;
    bool opened = false;
    bool enableToLearn = false;
    public SkillLearnSlot[] slots;
    public SkillLearnSlot parent;


    public void Start()
    {
        Debug.Log("\n\nStart SkillLearnSlot - " + skill.name);
        useButton = GetComponent<Button>();
        iconSkill = GetComponent<Image>();
        iconDisable.enabled = false;
        imageUnknownSkill.enabled = true;
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
        Debug.Log("Open skill to learn: " + skill.name);
        imageUnknownSkill.enabled = false;
        opened = true;

        if(!enableToLearn){
            iconSkill.enabled = true;
            iconDisable.enabled = true;
            Debug.Log("Learned skill locked make grace scale: " + skill.name);
            return;
        }

        enableSkillToLearn();
    }

    public void enableSkillToLearn()
    {
        useButton = GetComponent<Button>();
        Debug.Log("Try Skill To Learn: " + skill.name);
        enableToLearn = true;
        if(learned || !opened)
        {
            Debug.Log("Skill closed need book: " + skill.name);
            return;
        }

        Debug.Log("Skill Learned: " + skill.name);
        useButton.enabled = true;
        useButton.interactable = true;
        iconSkill.enabled = true;
        iconDisable.enabled = false;
    }

    public void unableSkillToLearn()
    {
        Debug.Log("unable Skill To Learn: " + skill.name);
        enableToLearn = false;
        iconDisable.enabled = true;
        useButton.enabled = false;
    }

    public void onChildLearnSkill()
    {
        for (int i = 0 ; i < slots.Length; ++i)
        {
            if(!slots[i].Learned())
            {
                slots[i].unableSkillToLearn();
            }
        }
    }

    public void learnSkill()
    {
        Debug.Log("Try to learn skill " + skill.name);
        if(!enableToLearn || learned || !opened)
        { 
            Debug.Log("Unable to Learn " + skill.name);
            return;
        }

        learned = true;
        for (int i = 0 ; i < slots.Length; ++i)
        {
            slots[i].enableSkillToLearn();
        }
        skillTree.updateSkillTree();

        if(parent)
            parent.onChildLearnSkill();
        useButton.enabled = false;
        Debug.Log("learned Skill: " + skill.name);
    }

    public void forgetSkill()
    {

    }

    public bool Learned()
    {
        return learned;
    }

    public void pointerEnter()
    {
        if(!opened) return;

        skill.ShowInfo();
    }

    public void pointerLeave()
    {
        skill.HideInfo();
    }
}
