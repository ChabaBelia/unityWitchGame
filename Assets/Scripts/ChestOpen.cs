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

        string sortingLayer = LayerMask.LayerToName(gameObject.layer);
        if(gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        }

        SpriteRenderer[] srs = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach ( SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !droped) {
            if(enter2d) {
                chestOpen.SetActive(true);
                chestClose.SetActive(false);
                drop();
                droped = true;
            }
        }
    }

    void drop()
    {
        ItemDrop _itemDrop = itemDrop.GetComponent<ItemDrop>();
        _itemDrop.enabled = true;
        _itemDrop.onItemDrop = onItemDrop;

        GameObject item = LevelManager.instance.popItem();
        ItemPickup _item =  item.GetComponent<ItemPickup>();
        
        item.layer = gameObject.layer;

        string sortingLayer = LayerMask.LayerToName(item.layer);
        if(item.GetComponent<SpriteRenderer>() != null)
        {
            item.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        }

        SpriteRenderer[] srs = item.GetComponentsInChildren<SpriteRenderer>();
        foreach ( SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }

        Debug.Log("Drop Item: " + _item.m_item.name);
        _itemDrop.setItem(item);
        itemDrop.SetActive(true);
    }

    void onItemDrop()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            enter2d = true;
            keyCode.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        enter2d = false;
        keyCode.SetActive(false);
        chestOpen.SetActive(false);
        chestClose.SetActive(true);
    }
}
