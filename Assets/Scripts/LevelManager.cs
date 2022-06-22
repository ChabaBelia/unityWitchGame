using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	#region Singleton

	public static LevelManager instance;
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

    public List<GameObject> items;
	public Transform startPosition;

    public List<GameObject> enemyListInstantiated;

    public void Start()
    {
		GameObject player = GameManager.instance.getPlayer();
		player.transform.position = startPosition.position;
		player.layer = startPosition.gameObject.layer;
        
		string sortingLayer = LayerMask.LayerToName(player.layer);
       	player.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        SpriteRenderer[] srs = player.GetComponentsInChildren<SpriteRenderer>();
        foreach ( SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }
    }

    public bool LevelCompleted()
    {
        return enemyListInstantiated.Count == 0;
    }

    public void exitLevel()
    {
        GameManager.instance.GoToExitLevelMenu();
    }

	public void RemoveEnemy(GameObject enemy)
	{
		if(enemyListInstantiated.Count == 0) return;

		int i = 0;
		for(; i < enemyListInstantiated.Count; ++i)
		{
			if(enemyListInstantiated[i] == enemy) break;
		}

		enemyListInstantiated.RemoveAt(i);
	}

	public void addEnemy(GameObject enemy)
	{
		enemyListInstantiated.Add(enemy);
	}

	public GameObject popItem()
    {
        int index = Random.Range(0, items.Count);
        GameObject item = items[index];
        items.RemoveAt(index);
        return item;
    }
}