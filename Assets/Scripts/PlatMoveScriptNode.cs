using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatMoveScriptNode : MonoBehaviour 
{
	public GameObject[] Nodes = new GameObject[1];   // Errornous - .Length not valid
	// The speed.
	public float Speed = 0.1f;
	
	private int CurrentNode = 0;
	// Use this for initialization
	void Start () 
	{
		print("nodes array length : ");
		print(Nodes.Length);
	}
	
	// Update is called once per frame
	// Use FixedUpdate as this should be called for the game cycle being rendered (helps smoothing)
	void FixedUpdate () {
		
		MoveDirect();
	
	}
	
	// Moves Directly towards the node
	void MoveDirect()
	{
		
		// move Directly towards the node
		transform.position = Vector3.MoveTowards(transform.position, Nodes[CurrentNode].transform.position, Time.deltaTime * Speed);
		
		// if we've reached the node then move to the next one
		if(transform.position == Nodes[CurrentNode].transform.position)
		{
			CurrentNode++;
			print(CurrentNode);
			
			// if we're already at the last node change to the first otherwise increment
			if(CurrentNode >= Nodes.Length)
			{
				CurrentNode = 0;
			}
		}
	}
}
