using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Skill Book", menuName = "Inventory/Consumple/Skill Book")]
public class SkillBook : Item {

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnBookRead();
	public OnBookRead onBookRead;

    public Skill skill;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
        SkillTreeUI.instance.LearnSkill(skill);
		RemoveFromInventory();					// Remove it from inventory
	}

}
