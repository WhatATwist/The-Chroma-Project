using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {
	
public	enum Colour
	{
		RED,
		BLUE,
		YELLOW,
		ORANGE,
		GREEN,
		PURPLE,
		WHITE
	} 
	
	public Colour PlatColour;
	public bool isActive;
	
	// private colour arrays that just hold the colours the platform could be
	// 2 arrays as the deactive one has a lower alpha value
	public Color[] ActiveColour, DeActiveColour;

	// Use this for initialization
	public void Start () 
	{
		setupColours();
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
		if(isActive)
		{
			collider.enabled = true;
			renderer.material.color = ActiveColour[(int)PlatColour];
		}
		else
		{
			collider.enabled = false;
			renderer.material.color = DeActiveColour[(int)PlatColour];
		}
		
	}
	
	
	
	// setups the colour arrays to the correct colours
	void setupColours()
	{
		ActiveColour = new Color[7];
		DeActiveColour = new Color[7];
		
		ActiveColour[(int)Colour.RED] = DeActiveColour[(int)Colour.RED] = Color.red;
		ActiveColour[(int)Colour.BLUE] = DeActiveColour[(int)Colour.BLUE] = Color.blue;
		ActiveColour[(int)Colour.YELLOW] = DeActiveColour[(int)Colour.YELLOW] = Color.yellow;
		ActiveColour[(int)Colour.ORANGE] = DeActiveColour[(int)Colour.ORANGE] = new Color(1.0f,0.55f,0.0f);
		ActiveColour[(int)Colour.GREEN] = DeActiveColour[(int)Colour.GREEN] = Color.green;
		ActiveColour[(int)Colour.PURPLE] = DeActiveColour[(int)Colour.PURPLE] = new Color(1.0f,0.0f,1.0f);
		ActiveColour[(int)Colour.WHITE] = DeActiveColour[(int)Colour.WHITE] = Color.white;
		
		for(int i = 0; i < 7; i++)
		{
			DeActiveColour[i].a = 0.2f;
		}
		
	}


// checks to see if the colour 
public void UpdateState(Colour colour)
	{
		// if the colour sent is the same as the colour of the platform make it active
		if(PlatColour == colour || PlatColour == Colour.WHITE)
		{
			isActive = true;
		}
		// otherwise do a switch to see if the platform contains any colour that should be active
		else
		{
			switch(colour)
			{
			case Colour.RED:
				if(PlatColour == Colour.ORANGE || PlatColour == Colour.PURPLE)
				{
					isActive = true;
				}
				else
				{
					isActive = false;
				}
				break;
				
			case Colour.BLUE:
				if(PlatColour == Colour.GREEN || PlatColour == Colour.PURPLE)
				{
					isActive = true;
				}
				else
				{
					isActive = false;
				}
				break;
				
			case Colour.YELLOW:
				if(PlatColour == Colour.ORANGE || PlatColour == Colour.GREEN)
				{
					isActive = true;
				}
				else
				{
					isActive = false;
				}
				break;
			default:
				isActive = false;
				break;
			}// end switch
			
		}// end else
	}
}

