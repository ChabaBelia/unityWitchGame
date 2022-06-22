using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Button useButton;

    Item item;

    public void addItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        useButton.interactable = true;
    }

    public void clearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        useButton.interactable = false;
    }

    public void useItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void onUseButton()
    {
        Debug.Log("onUseButton !!!!!!!!!!!!!!!!!!! ");
        useItem();
    }

    public void onRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
}
