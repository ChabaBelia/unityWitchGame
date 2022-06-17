using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillPannel : MonoBehaviour
{
    #region Singleton

	public static SkillPannel instance;

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

    Dictionary<KeyCode, SkillSlot> skillMap = null;
    string[] keyCodeList = {"Q", "E", "R", "T", "1", "2" };
    SkillTreeUI m_skillTreeUI;
        
    // Start is called before the first frame update
    KeyCode getKeyCode(string keyCode)
    {
        return (KeyCode) System.Enum.Parse(typeof(KeyCode), keyCode);
    }

    void Start()
    {
        skillMap = new Dictionary<KeyCode, SkillSlot>();
        m_skillTreeUI = SkillTreeUI.instance;
        SkillSlot[] skillList = GetComponentsInChildren<SkillSlot>();
        Debug.Log("skillList: " + skillList.Length);
        for (int i = 0 ; i < skillList.Length; ++i)
        {
            if(keyCodeList.Length <= i) break;

            string code = keyCodeList[i];

            Debug.Log("Add code " + code);
            skillList[i].setKeyCode(code);
            SkillSlot skillSlot = skillList[i];
            KeyCode keyCode = getKeyCode(code);
            skillMap.Add(keyCode, skillSlot);
        }

        updateSkillPannel();
    }

    // Update is called once per frame
    void Update()
    {
        if(skillMap != null) {
            foreach (KeyValuePair<KeyCode, SkillSlot> skill in skillMap)
            {
                if (Input.GetKeyDown(skill.Key)) { // && !Skill cool down
                    Debug.Log("Skill Cast: " + skill.Key.ToString());
                    skill.Value.UseSkill();
                }
            }
        }
    }

    public void updateSkillPannel()
    {
        if(!SkillTreeUI.instance)
        {
            Debug.Log("SkillTreeUI.instance !!!!!!!!!!!!!!!! NULL ");
            return;
        }
        List<Skill> skills = SkillTreeUI.instance.getAllSkills();

        if(skills.Count == 0) return;

        foreach (KeyValuePair<KeyCode, SkillSlot> skill in skillMap)
        {
            if(skill.Value.skillEmpty())
            {
                skill.Value.setSkill(skills[skills.Count - 1]);
                break;
            }
        }
    }
}
