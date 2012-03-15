using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public enum Type
	{
		Play,
		Quit
	};
	
	public Type ButtonType;
	// Use this for initialization
	void Start () 
	{
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Pressed()
	{
		switch( ButtonType)
		{
		case Type.Play:
			Application.LoadLevel(1);
			break;
			
		case Type.Quit:
			Application.Quit();
			break;
			
		default:
			break;
		}
	}
	
}
