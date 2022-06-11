using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Mana Potion", menuName = "Inventory/Consumple/Mana Potion")]
public class ManaPotion : Item {

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnPotionUse();
	public OnPotionUse onPotionUse;

	public int manaPointsRestore = 0;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
		PlayerManager.instance.RestoreMana(manaPointsRestore);	// Equip it
		RemoveFromInventory();					// Remove it from inventory
	}

}
