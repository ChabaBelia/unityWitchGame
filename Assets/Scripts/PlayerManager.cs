using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	#region Singleton

    //public enum MeshBlendShape {Torso, Arms, Legs };
	public static PlayerManager instance;
	//public SkinnedMeshRenderer targetMesh;

    //SkinnedMeshRenderer[] currentMeshes;

	void Awake ()
	{
		instance = this;
	}

	#endregion

    public Player player;

    public void RestoreMana(int points)
    {
        player.addMana(points);
    }
  
    public void RestoreHealth(int points)
    {
        player.addHealth(points);
    }

    void Update()
    {
        //transform.position = player.transform.position + new Vector3(0, 1, -5);
    }
}
