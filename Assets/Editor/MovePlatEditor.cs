using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PlatMoveScriptNode))]
public class MovePlatEditor : Editor {

	public PlatMoveScriptNode _target;
	
	// Use this for initialization
	void OnEnable () {
		
		_target = (PlatMoveScriptNode) target;
	
	}
	
	// Update is called once per frame
	void OnSceneGUI () {
		
		int i;
		
		for(i = 0; i < _target.Nodes.Length -1; i++)
		{
			
			Handles.DrawLine(_target.Nodes[i].transform.position, _target.Nodes[i+1].transform.position); 
			Handles.DrawLine(_target.Nodes[i].transform.position, _target.Nodes[0].transform.position); 
		}
		
		if (GUI.changed)
            EditorUtility.SetDirty (target);
	
	}
}

[CustomEditor(typeof(PlatNodeScript))]
public class NodeEditor : Editor {

	public PlatMoveScriptNode _target;
	
	// Use this for initialization
	void OnEnable () {
		
		_target = (PlatMoveScriptNode) target;
	
	}
	
	// Update is called once per frame
	void OnSceneGUI () {
		
		int i;
		
		for(i = 0; i < _target.Nodes.Length -1; i++)
		{
			
			Handles.DrawLine(_target.Nodes[i].transform.position, _target.Nodes[i+1].transform.position); 
		}
		Handles.DrawLine(_target.Nodes[i].transform.position, _target.Nodes[0].transform.position); 
		
		if (GUI.changed)
            EditorUtility.SetDirty (target);
	
	}
}
