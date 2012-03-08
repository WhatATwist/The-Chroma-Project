using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(LightScript))]
public class ColourLightEditor : Editor {
	
	
	public LightScript _target;
	
	void OnEnable()
	{
		_target = (LightScript) target;
		_target.Start();
	}
	
	public void OnSceneGUI () 
	{
        _target.light.color = _target.Colours[(int)_target.lightColour];
		
        if (GUI.changed)
            EditorUtility.SetDirty (target);
	}
}

