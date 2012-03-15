using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PlatformScript))]
public class ColourObjectEditor : Editor {
	
	
	public PlatformScript _target;
	
	void OnEnable()
	{
		_target = (PlatformScript) target;
		_target.Start();
	}
	
	public void OnSceneGUI () 
	{
        _target.renderer.sharedMaterial.color = _target.ActiveColour[(int)_target.PlatColour];
		
        if (GUI.changed)
            EditorUtility.SetDirty (target);
	}
}

