using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillTreeUI : MonoBehaviour
{
	#region Singleton

	public static SkillTreeUI instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

    public SkillLearnSlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0 ; i < slots.Length; ++i)
        {
            slots[i].enableSkillToLearn();
        }
    }

    // Update is called once per frame
    public void visible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public bool isVisible()
    {
        return gameObject.activeSelf;
    }

    public void LearnSkill(Skill skill)
    {
        SkillLearnSlot[] skillsSlots = GetComponentsInChildren<SkillLearnSlot>();

        for (int i = 0 ; i < skillsSlots.Length; ++i)
        {
            if(skillsSlots[i].skill == skill) {
                skillsSlots[i].openSkill();
            }
        }
    }

    public void updateSkillTree()
    {
        Debug.Log("Updating Update Skill Tree UI");
        SkillPannel.instance.updateSkillPannel();
    }

    public List<Skill> getAllSkills()
    {
        List<Skill> skills = new List<Skill>();
        
        SkillLearnSlot[] skillsSlots = GetComponentsInChildren<SkillLearnSlot>();

        for (int i = 0 ; i < skillsSlots.Length; ++i)
        {
            if(skillsSlots[i].Learned())
            {
                skills.Add(skillsSlots[i].skill);
            }
        }

        return skills;
    }
}
