using UnityEngine;
using System.Collections;

public class PlatMoveScript : MonoBehaviour {

	
	public Vector3 DirectionalVelocity;
	public float Distance = 1.0f;
	public float Speed = 0.1f;
	
	private Vector3 StartingPos, EndingPos;
	private bool reverse;
	private float tVal,time;
	
	// Use this for initialization
	void Start () {
		
		// get the start position. We'll use this to determin 
		// how far away the platform has moved so we know when to reverse it 
		StartingPos = transform.position - (DirectionalVelocity*Distance);
		EndingPos =  transform.position + (DirectionalVelocity*Distance);
		
		// use the distance and speed to work out the time per cycle, then divide 1/speed
		// to get a distance for that time slice as later we'll use the delta time function for speed
		time = 1/(Distance/Speed);
		
		
		// reverse determins when the platform goes forwards or backwards
		reverse = false;
		
		// set the tVal to 0.5 so the platform starts where it is positioned in the scene
		tVal = 0.5f;
	
	}
	
	// Update is called once per frame
	// Use FixedUpdate as this should be called for the game cycle being rendered (helps smoothing)
	void FixedUpdate () {
		
		if(!reverse)
		{
			transform.position =  Vector3.Lerp(StartingPos, EndingPos, tVal);
		}
		else
		{
			transform.position =  Vector3.Lerp(StartingPos, EndingPos, tVal);
		}
		
		CheckDistance();
	
	}
	
	// checks if the platform has reached the distance  
	void CheckDistance()
	{
		// if we aren't reversing increment the value of tVal and check it its greater than 1
		if(!reverse)
		{
			// multiply by detlta time to get the speed "per second" rather than "per frame" 
			tVal += Time.deltaTime *time;
			// if we are greater than 1 start reversing
			if(tVal > 1.0f)
			{
				reverse = true;
			}
		}
		// if we are reversing decrement the value of tVal and check it its less than 0
		else
		{
			tVal -= Time.deltaTime *time;
			
			if(tVal < 0.0f)
			{
				reverse = false;
			}
		}
	}
}
