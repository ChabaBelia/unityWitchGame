using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    void Start () {
      GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
      string layer = LayerMask.LayerToName(player.layer);
      GetComponent<SpriteRenderer>().sortingLayerName = layer;
    }

    public void onLastFrame()
    {
		  Destroy(gameObject);
    }
}
