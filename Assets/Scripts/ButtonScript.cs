using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	
	
	
	public PlatformScript.Colour ButtonColour;
	public bool isActive;
	
	// set to private as these will only be setup once by the setupColours function
	private Color[] Colours;
	
	// Use this for initialization
	void Start () 
	{
		
		setupColours();
		isActive =false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(isActive)
		{
			TriggerButton();
		}
	
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
	
	public void TriggerButton()
	{
		// and send a call to all platforms to makesure their colour is updated
		// create an array of platforms 
		GameObject[] mainLights = GameObject.FindGameObjectsWithTag("MainLight");//>();
		
		foreach(GameObject mainLight in mainLights)
		{
			mainLight.SendMessage("SetLightColour", ButtonColour);
		}
		
		isActive = false;
		
	}
}
