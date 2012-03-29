using UnityEngine;
using System.Collections;

public class DeathRestart : MonoBehaviour {
	public float FadeValue;
	// Use this for initialization
	void Start () 
	{
		renderer.enabled = false;	// collider is invisible in game
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}	
	
	// When the player enters the collision mesh
	void OnTriggerEnter(Collider collideInfo)
	{
		print("You have died lol");
		
		FadeValue -= Mathf.Clamp01(Time.deltaTime / 5);

		GUI.color = new Color(0, 0, 0, FadeValue);
		GUI.DrawTexture( Rect(0, 0, 10, 10 ), null);
		
		print (collideInfo.name);
		collideInfo.SendMessage("Respawn");
	}
}
