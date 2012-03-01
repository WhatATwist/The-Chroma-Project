using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		// if the player has pressed the use key
		if(Input.GetAxis("Use") != 0.0f)
		{
			// check if they are near a button by casting a ray from the camera to the point we're looking at
			Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        	RaycastHit hit;
			
        	if (Physics.Raycast(ray, out hit,1.75f))
			{
				hit.collider.SendMessage("TriggerButton");
				
			}
       		else
            	print("I'm looking at nothing!");
			
		}
	}
}
