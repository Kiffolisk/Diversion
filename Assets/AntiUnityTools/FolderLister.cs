using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class FolderLister : EditorWindow
{
    [MenuItem("Anti-Unity Retardation tools/Folder lister")]
    public static void ShowWindow()
    {
        currentFolder = Application.dataPath;
        GetWindow(typeof(FolderLister));
        ReloadFolder();
    }

    public static string currentFolder = Application.dataPath;

    public static List<string> allShit = new List<string>();

    Vector2 scrollPos;

    public static void ReloadFolder()
    {
        allShit.Clear();
        foreach (string f in Directory.GetDirectories(currentFolder))
        {
            allShit.Add("[DIR] " + f);
        }
        foreach (string f in Directory.GetFiles(currentFolder))
        {
            allShit.Add("[FILE] " + f);
        }
    }

    void OnGUI()
    {
        GUILayout.Label(currentFolder, EditorStyles.boldLabel);
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        if (GUILayout.Button("Back"))
        {
            currentFolder += "/../";
            currentFolder = Path.GetFullPath(currentFolder);
            ReloadFolder();
        }
        foreach (string p in allShit)
        {
            if (GUILayout.Button(p))
            {
                if (p.StartsWith("[DIR"))
                {
                    currentFolder = p.Replace("[DIR] ", "");
                    ReloadFolder();
                }
            }
        }
        GUILayout.EndScrollView();
    }
}
#endif