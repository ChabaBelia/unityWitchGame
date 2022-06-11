using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Singleton

	public static GameManager instance;

    public int chestNumber = 5;

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
    public List<GameObject> chests;

    private void Start() {
        Debug.Log("GameManager: create " + chests.Count);
        for (int i = 0 ; i < chests.Count; ++i)
        {
            Vector3 dest = transform.position;
            dest.x += i * 2;
            dest.z = 0;
            Instantiate(chests[i], dest, Quaternion.identity);
        }
    }

    public GameObject popItem()
    {
        int index = Random.Range(0, items.Count);
        GameObject item = items[index];
        items.RemoveAt(index);
        return item;
    }

}