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
        
        GameObject enemy = Instantiate(objects[rand], transform.position, Quaternion.identity);
        enemy.layer = gameObject.layer;
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if(player != null) {
            enemy.GetComponent<AIDestinationSetter>().target = player.transform;
        }
      
        
        SkinnedMeshRenderer[] allChildrenMesh = enemy.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer mesh in allChildrenMesh) {
            mesh.sortingLayerName = spawnLayer;
            mesh.sortingOrder = 3;
        }

        Canvas[] allChildrenCanvas = enemy.GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in allChildrenCanvas) {
            canvas.sortingLayerName = spawnLayer;
            canvas.sortingOrder = 3;
        }
    } 
}
