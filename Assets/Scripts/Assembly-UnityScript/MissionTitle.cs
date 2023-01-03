using System;
using UnityEngine;

[Serializable]
public class MissionTitle : MonoBehaviour
{
	private GameControl gameControl;

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		gameControl.PreviewWorld(1);
		gameControl.isMiniGame = false;
	}

	public virtual void Update()
	{
	}

	public virtual void Main()
	{
	}
}
