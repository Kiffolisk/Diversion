using System.IO;
using UnityEngine;

public class DirectoryLister : MonoBehaviour
{
	public static string getDirectoryList(string path)
	{
		string text = string.Empty;
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		FileInfo[] files = directoryInfo.GetFiles("*.txt");
		foreach (FileInfo fileInfo in files)
		{
			text = text + fileInfo.Name.Replace(".txt", string.Empty) + "\n";
		}
		return text;
	}
}
