using System.IO;
using UnityEngine;

public class AssetLister : MonoBehaviour
{
	public static string getDirectoryList(string path)
	{
		string text = string.Empty;
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		FileInfo[] files = directoryInfo.GetFiles("*.*");
		foreach (FileInfo fileInfo in files)
		{
			text = text + fileInfo.Name + "\n";
		}
		return text;
	}
}
