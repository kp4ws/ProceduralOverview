﻿using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(SurfaceCreator))]
public class SurfaceCreatorInspector : Editor
{
	private SurfaceCreator creator;

	private void OnEnable()
	{
		creator = target as SurfaceCreator;
		Undo.undoRedoPerformed += RefreshCreator;
	}

	private void OnDisable()
	{
		Undo.undoRedoPerformed -= RefreshCreator;
	}

	private void RefreshCreator()
	{
		if(Application.isPlaying)
		{
			creator.Refresh();
		}
	}

	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();
		DrawDefaultInspector();
		
		if(EditorGUI.EndChangeCheck())
		{
			RefreshCreator();
		}
	}
}
