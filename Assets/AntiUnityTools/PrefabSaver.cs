using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class PrefabSaver : EditorWindow
{
    [MenuItem("Anti-Unity Retardation tools/Prefab saver")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PrefabSaver));
    }

    public string prefabName = "";
    public GameObject obj;

    void OnGUI()
    {
        GUILayout.Label("Prefab saver", EditorStyles.boldLabel);
        prefabName = EditorGUILayout.TextField(prefabName);
        obj = (GameObject)EditorGUILayout.ObjectField("Object name", obj, typeof(GameObject), true);
        if (GUILayout.Button("Save"))
        {
            // prefabutility.createprefab obsolete since unity 2018.3
#if UNITY_2017
            string thePath = "Assets/Resources/" + prefabName + (prefabName.EndsWith(".prefab") ? "" : ".prefab");
            if (AssetDatabase.LoadAssetAtPath(thePath, typeof(GameObject)))
            {
                if (EditorUtility.DisplayDialog("Are you sure?",
                        "The prefab already exists. Do you want to overwrite it?",
                        "Yes",
                        "No"))
                {
                    // ok
                }
                else
                {
                    Close();
                    return;
                }
            }
            PrefabUtility.CreatePrefab(thePath, obj, ReplacePrefabOptions.ReplaceNameBased);
            Close();
#endif
        }
    }
}
#endif