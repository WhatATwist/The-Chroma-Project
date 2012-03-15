using UnityEngine;
using System.Collections;

public class ColourObjBase : MonoBehaviour {
	
	
	
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
	
	public Colour ObjColour;
	
	// set to private as these will only be setup once by the setupColours function
	public Color[] ActiveColour;
	
	
	// Use this for initialization
	public void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// setups the colour arrays to the correct colours
	protected Color[] setupColours(float alpha)
	{
		Color[] colours = new Color[7];
		
		colours[(int)Colour.RED] = Color.red;
		colours[(int)Colour.BLUE] = Color.blue;
		colours[(int)Colour.YELLOW] = Color.yellow;
		colours[(int)Colour.ORANGE] = new Color(1.0f,0.55f,0.0f);
		colours[(int)Colour.GREEN] = Color.green;
		colours[(int)Colour.PURPLE] = new Color(1.0f,0.0f,1.0f);
		colours[(int)Colour.WHITE] = Color.white;
		
		if(alpha != 1.0f)
		{
			for(int i =0; i < 7; i++)
			{
				colours[i].a = alpha;
			}
		}
		
		return colours;
		
	}
}
