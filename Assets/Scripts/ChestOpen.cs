using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject chestClose;
    public GameObject chestOpen;
    public GameObject keyCode;
    public GameObject itemDrop;

    bool droped = false;
    bool enter2d = false;
    // Start is called before the first frame update
    void Start()
    {
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
        keyCode.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !droped) {
            if(enter2d) {
                chestOpen.SetActive(true);
                drop();
                droped = true;
            }
        }
    }

    void drop()
    {
        ItemDrop _itemDrop = itemDrop.GetComponent<ItemDrop>();
        _itemDrop.onItemDrop = onItemDrop;

        GameObject item = GameManager.instance.popItem();
        ItemPickup _item =  item.GetComponent<ItemPickup>();
        Debug.Log("Drop Item: " + _item.m_item.name);
        _itemDrop.setItem(item);
        itemDrop.SetActive(true);
    }

    void onItemDrop()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        enter2d = true;
        keyCode.SetActive(true);
        chestClose.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other) {
        enter2d = false;
        keyCode.SetActive(false);
        chestOpen.SetActive(false);
        chestClose.SetActive(true);
    }
}
