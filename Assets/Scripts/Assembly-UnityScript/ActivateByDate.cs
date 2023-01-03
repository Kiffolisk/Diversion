using System;
using UnityEngine;

[Serializable]
public class ActivateByDate : MonoBehaviour
{
	public string monthToActivate;

	public ActivateByDate()
	{
		monthToActivate = "12";
	}

	public virtual void Awake()
	{
		string text = DateTime.Now.ToString("MM");
		if (text != monthToActivate)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
