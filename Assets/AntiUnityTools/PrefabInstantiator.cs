using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class PrefabInstantiator : EditorWindow
{
    [MenuItem("Anti-Unity Retardation tools/Prefab instantiator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PrefabInstantiator));
    }

    public string prefabName = "";

    void OnGUI()
    {
        GUILayout.Label("Prefab instantiator", EditorStyles.boldLabel);
        prefabName = EditorGUILayout.TextField(prefabName);
        if (GUILayout.Button("Instantiate"))
        {
            GameObject x = Instantiate(Resources.Load<GameObject>(prefabName));
            Close();
        }
    }
}
#endif