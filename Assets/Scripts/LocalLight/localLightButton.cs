using UnityEngine;
using System.Collections;

public class localLightButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Trigger()
	{
		LocalLight light = GetComponentInChildren<LocalLight>();
		light.Triggered = true;
		if(light.isActive)
		{
			light.isActive = false;
		}
		else
		{
			light.isActive = true;
		}
	}
}
