using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item m_item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Pickup");
            Inventory.instance.Add(m_item);
            Destroy(gameObject);
        }
    }
}
