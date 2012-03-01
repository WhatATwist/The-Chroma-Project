// ColourObjectEditor.cs
// What A Twist
//
// Editor script for modifying the colour of in-game geometry
// and visual representation within the editor

using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PlatformScript))]
public class ColourObjectEditor : Editor 	
{
	public PlatformScript _target;					// The Platform that to be edited
	
	void OnEnable()
	{
		_target = (PlatformScript) target;			
		_target.Start();
	}
	
	public void OnSceneGUI () 
	{
		// Change the colour of the platform
        _target.renderer.material.color = _target.ActiveColour[(int)_target.PlatColour];
		
        if (GUI.changed)
            EditorUtility.SetDirty (target);		// Notify editor of asset change
	}
}
