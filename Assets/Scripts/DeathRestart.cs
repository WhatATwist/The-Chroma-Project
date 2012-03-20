using UnityEngine;
using System.Collections;

public class DeathRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		print("You have died lol");
		
		
		Application.LoadLevel(Application.loadedLevel);
				
		
	}
}
