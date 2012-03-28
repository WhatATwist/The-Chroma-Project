using UnityEngine;
using System.Collections;

public class CheckpointRespawn : MonoBehaviour {
	
	private bool hit =false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter(Collider collideInfo)
	{
		if (hit==false){
			print("You have activated checkpoint");
			
			if (collideInfo.tag=="Player"){
				collideInfo.SendMessage("SetSpawnPoint");
				hit = true;
			}
		
		}
	}
}
