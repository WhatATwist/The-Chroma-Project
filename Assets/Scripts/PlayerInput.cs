using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	
	
	private bool UsePressed;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		UsePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		// if the player has pressed the use key and only just pressed it
		if(Input.GetAxis("Use") != 0.0f && !UsePressed)
		{
			// set UsePressed to true to stop multiple Use key presses at a time
			UsePressed = true;
			
			// check if they are near a button by casting a ray from the camera to the point we're looking at
			Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        	RaycastHit hit;
			
        	if (Physics.Raycast(ray, out hit,1.75f))
			{
				hit.collider.SendMessage("Trigger");
				
			}
       		else if (Debug.isDebugBuild)
			{
            	Debug.Log("I'm looking at nothing!");	// only print if in Debug Mode
			}
			
		}
		// otherwise if the player isn't pressing use
		else if(Input.GetAxis("Use") == 0.0f)
		{
			// set the button to not being pressed
			UsePressed = false;
		}
		
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
	}
}
