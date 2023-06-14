using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelDesigner))]
public class DesignEditor : Editor
{
    
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelDesigner myScript = (LevelDesigner)target;
        if(GUILayout.Button("Create Grids"))
        {
            myScript.BuildObject();
        }
        if(GUILayout.Button("Delete Last Grids"))
        {
            myScript.DeleteLastObject();
        }
    }
}