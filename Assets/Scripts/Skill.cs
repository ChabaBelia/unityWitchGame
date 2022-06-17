using UnityEngine;
using UnityEngine.UI;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill Tree/Skill")]
public class Skill : ScriptableObject {
	new public string name = "Skill";	// Name of the item
    new public string skillInfo;
    SkillInfo info;
	public Sprite icon = null;	
    public bool isCoolDown { get; set; }
    public float cooldownTime = 5; 
    
    //public SkillUse skillUse;

    public void setSkillInfo(SkillInfo setInfo)
    {
        info = setInfo;
    }

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
        Debug.Log("Base Skill Used");
	}

    public virtual void ShowInfo()
    {
        info.ShowInfo(skillInfo);
    }

    public virtual void HideInfo()
    {
        info.HideInfo();
    }
}
