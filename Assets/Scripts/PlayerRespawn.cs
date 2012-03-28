using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	
	private Vector3 RespawnPos;
	private PlatformScript.Colour savedlightcolor;
	// Use this for initialization
	void Start () {
	RespawnPos=transform.position;
		RespawnPos.y+=20;
		GameObject MainLight = GameObject.FindGameObjectWithTag("MainLight");
		savedlightcolor = MainLight.GetComponent<LightScript>().lightColour;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Respawn(){
		
		transform.position = RespawnPos;// collideInfo.transform.TransformPoint(46.0f,41.0f,63.0f);
		GameObject MainLight = GameObject.FindGameObjectWithTag("MainLight");
		MainLight.SendMessage("SetLightColour", savedlightcolor);
		print("died with light colour " + savedlightcolor);
	}
	
	public void SetSpawnPoint(){
		RespawnPos=transform.position;
		RespawnPos.y+=20;
		GameObject MainLight = GameObject.FindGameObjectWithTag("MainLight");
		savedlightcolor = MainLight.GetComponent<LightScript>().lightColour;
		
		print(savedlightcolor);
		
	}
}
