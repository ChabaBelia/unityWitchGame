using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        visible(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void visible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public bool isVisible()
    {
        return gameObject.activeSelf;
    }
}
