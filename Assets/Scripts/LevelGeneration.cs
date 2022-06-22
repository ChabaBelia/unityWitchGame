using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;

    void Start() {
        int rand = Random.Range(0, objects.Length);
        string spawnLayer = LayerMask.LayerToName(gameObject.layer);
        
        GameObject objectCopy = Instantiate(objects[rand], transform.position, Quaternion.identity);
        objectCopy.layer = gameObject.layer;

        if(objectCopy.GetComponent<SpriteRenderer>() != null)
        {
            string sortingLayer = LayerMask.LayerToName(objectCopy.layer);
            objectCopy.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
            SpriteRenderer[] srs = objectCopy.GetComponentsInChildren<SpriteRenderer>();
            foreach ( SpriteRenderer sr in srs)
            {
                sr.sortingLayerName = sortingLayer;
            }
        }

        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if(player != null && objectCopy.tag == "Enemy") {
            objectCopy.GetComponent<AIDestinationSetter>().target = player.transform;
            LevelManager.instance.addEnemy(objectCopy);
        }
        
        SkinnedMeshRenderer[] allChildrenMesh = objectCopy.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer mesh in allChildrenMesh) {
            mesh.sortingLayerName = spawnLayer;
            mesh.sortingOrder = 3;
        }

        Canvas[] allChildrenCanvas = objectCopy.GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in allChildrenCanvas) {
            canvas.sortingLayerName = spawnLayer;
            canvas.sortingOrder = 3;
        }
    } 
}
