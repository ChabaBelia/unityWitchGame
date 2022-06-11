using UnityEngine;
using UnityEngine.UI;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill Tree/Skill")]
public class Skill : ScriptableObject {

	new public string name = "Skill";	// Name of the item
    new public string skillInfo;
    SkillInfo info;
	public Sprite icon = null;				// Item icon

    public void setSkillInfo(SkillInfo setInfo)
    {
        info = setInfo;
    }

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
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
