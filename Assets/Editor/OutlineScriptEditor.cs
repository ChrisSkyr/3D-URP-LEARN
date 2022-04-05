using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OutlineScript))]
public class OutlineScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        OutlineScript outlineScript = (OutlineScript)target;

        if(GUILayout.Button("Update Shader"))
        {
            outlineScript.SetMaterial();
        }         
    }
}
