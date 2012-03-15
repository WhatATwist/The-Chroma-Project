using UnityEngine;
using System.Collections;

public class LightScript : MonoBehaviour {
	
	//public	enum Colour
	//{
	//	RED,
	//	BLUE,
	//	YELLOW,
	//	ORANGE,
	//	GREEN,
	//	PURPLE
	//} 
	
	
	public PlatformScript.Colour lightColour;
	
	// set to private as these will only be setup once by the setupColours function
	public Color[] Colours;
	
	//private PlatformScript receiver;

	// Use this for initialization
	public void Start () {
		
		
		setupColours();
		light.color = Colours[(int)lightColour];
		
		SetLightColour(lightColour);
	}
	
	// Update is called once per frame
	void Update () {
		//SetLightColour(lightColour);
	}
	
	
	// setups the colour arrays to the correct colours
	void setupColours()
	{
		Colours = new Color[6];
		
		Colours[(int)PlatformScript.Colour.RED] = Color.red;
		Colours[(int)PlatformScript.Colour.BLUE] = Color.blue;
		Colours[(int)PlatformScript.Colour.YELLOW] = Color.yellow;
		Colours[(int)PlatformScript.Colour.ORANGE] = new Color(1.0f,0.55f,0.0f);
		Colours[(int)PlatformScript.Colour.GREEN] = Color.green;
		Colours[(int)PlatformScript.Colour.PURPLE] = new Color(1.0f,0.0f,1.0f);
		
	}
	
	public void SetLightColour(PlatformScript.Colour colour)
	{
		// set the light colour
		light.color = Colours[(int)colour];
		
		// and send a call to all platforms to makesure their colour is updated
		// create an array of platforms 
		GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");//>();
		
		foreach(GameObject platform in platforms)
		{
			platform.SendMessage("UpdateState",colour);
		}
		
		
	}
}
