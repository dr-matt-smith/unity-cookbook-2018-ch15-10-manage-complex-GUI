using UnityEngine;
using UnityEditor;

public class GUITextField : IMyGUI
{
    public string text = "";
    public GUIContent label = new GUIContent();
    
    public void OnGUI() {
        text = EditorGUILayout.TextField (label, text);
    }
}