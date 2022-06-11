using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public InventoryUIManager m_inventoryUIManager;

    Inventory m_inventory;

    InventorySlot[] slots; 
    // Start is called before the first frame update
    void Start()
    {
        m_inventory = Inventory.instance;
        m_inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");

        for (int i = 0 ; i < slots.Length; ++i)
        {
            if(i < m_inventory.items.Count)
            {
                slots[i].addItem(m_inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}
