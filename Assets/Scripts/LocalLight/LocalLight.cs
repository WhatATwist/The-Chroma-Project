using UnityEngine;
using System.Collections;

public class LocalLight : MonoBehaviour {
	
	
	public bool Triggered = false, isActive = false;
	public PlatformScript.Colour lightColour;
	private PlatformScript.Colour MainlightColour;
	
	private Collider[] platforms;
	private SphereCollider SphCollider;
	
	
	
	private int totalPlatforms = 0; // this number stores the total platforms picked up last check.
									// maybe used later to check if the number of platforms found has
									// changed so then we know if we should trigger again (ie for when a moving platform enters and leaves the radius)
	
	// Use this for initialization
	void Start () 
	{
		// get all platforms within the colission sphere
		GetClosePlatforms();
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
				for(int i = 0; i<platforms.Length; i++)
				{
					platforms[i].SendMessage("UpdateState",lightColour);
				}
			}
			// otherwise we're turning off the local light so send the main light colour back
			else
			{
				for(int i = 0; i<platforms.Length; i++)
				{
					platforms[i].SendMessage("UpdateState",MainlightColour);
				}
			}
			Triggered = false;
		}
		
		
		
	}
	
	/// <summary>
	/// Called when the main light is changed
	/// </summary>
	/// <param name='mainColour'>
	/// The colour of the main light.
	/// </param>
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
	
	/// <summary>
	/// Gets the nearby platforms. can be called more than once later on to get a list of platforms
	/// </summary>
	void GetClosePlatforms()
	{
		// stores all platforms within sphere's radius, raduis = half the sphere's scale 
		platforms = Physics.OverlapSphere(transform.position, transform.localScale.x/2);
		
		totalPlatforms = platforms.Length;
		
	}
		
}
