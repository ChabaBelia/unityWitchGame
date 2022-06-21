using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    GameObject item;
    public SpriteRenderer m_SpriteRenderer;
	public delegate void OnItemDrop();
	public OnItemDrop onItemDrop;


    public Vector3 Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
 
    public Transform Projectile;      
    private Transform myTransform;

    public void setItem(GameObject _item)
    {
        item = _item;
        ItemPickup _itemPickup = item.GetComponent<ItemPickup>();
        m_SpriteRenderer.sprite = _itemPickup.m_item.icon;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 _startPosition = transform.position;
        _startPosition.x += 1;

        Target = _startPosition;
        StartCoroutine(SimulateProjectile());
    }

    void Awake()
    {
        myTransform = transform;      
    }
 
    IEnumerator SimulateProjectile()
    {     
        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);
       
        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target);
 
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
 
        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
 
        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        float elapse_time = 0;
 
        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
           
            elapse_time += Time.deltaTime;
 
            yield return null;
        }
        Arrived();
    }

    public void Arrived()
    {
        Debug.Log("Drop arive .....");
        if(onItemDrop != null) {
            onItemDrop();
        }

        if(item) {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
