using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    GameObject item;
    public Image image;
    public SpriteRenderer m_SpriteRenderer;
	public delegate void OnItemDrop();
	public OnItemDrop onItemDrop;

    public float speed = 0.005f;
    public Vector3 target;
    public float arcHeight;

    Vector3 _startPosition;
    float _stepScale;
    float _progress = 0.0f;

    public void setItem(GameObject _item)
    {
        item = _item;
        ItemPickup _itemPickup = item.GetComponent<ItemPickup>();
        image.sprite = _itemPickup.m_item.icon;
        m_SpriteRenderer.sprite = _itemPickup.m_item.icon;
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;

        float distance = 1;
        target = _startPosition;
        target.x += distance;

        // This is one divided by the total flight duration, to help convert it to 0-1 progress.
        _stepScale = 0.5f;
    }

    void Update() {
        // Increment our progress from 0 at the start, to 1 when we arrive.
        _progress = Mathf.Min(_progress + Time.deltaTime * _stepScale, 1.0f);

        // Turn this 0-1 value into a parabola that goes from 0 to 1, then back to 0.
        float parabola = 1.0f - 4.0f * (_progress - 0.5f) * (_progress - 0.5f);

        // Travel in a straight line from our start position to the target.        
        Vector3 nextPos = Vector3.Lerp(_startPosition, target, _progress);

        // Then add a vertical arc in excess of this.
        nextPos.y += parabola * arcHeight;

        // Continue as before.
        transform.LookAt(nextPos, transform.forward);
        transform.position = nextPos;

        // I presume you disable/destroy the arrow in Arrived so it doesn't keep arriving.
        if(_progress == 1.0f) {
            Arrived();
        }
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
