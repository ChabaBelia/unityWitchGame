using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Inventory/Consumple/Health Potion")]
public class HealthPotion : Item {

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnPotionUse();
	public OnPotionUse onPotionUse;

	public int healthPointsRestore = 0;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
		PlayerManager.instance.RestoreHealth(healthPointsRestore);	// Equip it
		RemoveFromInventory();					// Remove it from inventory
	}

}
