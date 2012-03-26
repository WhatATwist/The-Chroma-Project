using UnityEngine;
using System.Collections;

public class LocalLight : MonoBehaviour {
	
	
	public bool Triggered = false, isActive = false;
	public PlatformScript.Colour lightColour;
	private PlatformScript.Colour MainlightColour;
	
	private GameObject[] platforms;
	
	
	private int num = 0;
	
	// Use this for initialization
	void Start () 
	{
		platforms = new GameObject[32];
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// If the light is active turn on the render
		if(isActive)
		{
			renderer.enabled = true;
		}
		else
		{
			renderer.enabled = false;
		}
		
		if(Triggered)
		{
			
			// if the light is activated by the button send the local light colour to colliding platforms
			if(isActive)
			{
				for(int i = 0; i<num; i++)
				{
					platforms[i].SendMessage("UpdateState",lightColour);
				}
			}
			// otherwise we're turning off the local light so send the main light colour back
			else
			{
				for(int i = 0; i<num; i++)
				{
					platforms[i].SendMessage("UpdateState",MainlightColour);
				}
			}
			Triggered = false;
		}
		
		
		
	}
	
	void OnTriggerEnter(Collider colliderInfo) 
	{
		// if the player enters the collider don't add them to the array of objects
		if(colliderInfo.name != "First Person Controller")
		{
			platforms[num] = colliderInfo.gameObject;
			num++;
		}
	}
	
	public void OnLightChange(PlatformScript.Colour mainColour)
	{
		// set the light colour to what colour the main light has been set to
		MainlightColour = mainColour;
		
		// and then retrigger the platform just to make sure if it is active it stays active
		if(isActive)
		{
			Triggered = true;
		}
	}
		
}
