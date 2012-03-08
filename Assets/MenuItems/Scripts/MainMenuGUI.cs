using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// Show mouse cursor and reset its position
		Screen.showCursor = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0))
		{
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        	RaycastHit hit;
			
        	if (Physics.Raycast(ray, out hit,100))
			{
				print("button pressed");
				hit.collider.SendMessageUpwards("Pressed");
				print(hit.collider.name);
				
			}
       		else
            	print("I'm looking at nothing!");
		}
		
	
	}
	
	void OnGUI()
	{
		
	}
}
