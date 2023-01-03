using System;
using UnityEngine;

[Serializable]
public class WarpControl : MonoBehaviour
{
	public GameObject portalObject;

	public string warpScene;

	public string promptText;

	public bool showHintOnce;

	private GameControl gameControl;

	private int showCount;

	public WarpControl()
	{
		warpScene = string.Empty;
		promptText = string.Empty;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
	}

	public virtual void PlayerEnter()
	{
		showCount++;
		if ((bool)portalObject)
		{
			gameControl.WarpPlayer(portalObject.transform);
			gameControl.PlaySound((AudioClip)Resources.Load("Sounds/warped"));
		}
		else if (promptText == string.Empty)
		{
			StartCoroutine(gameControl.ChangeScene(warpScene, true));
		}
		else if (!showHintOnce || showCount <= 1)
		{
			gameControl.ShowWarp(warpScene, promptText);
		}
	}

	public virtual void OnDrawGizmos()
	{
		if ((bool)portalObject)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawSphere(portalObject.transform.position, 2f);
		}
	}

	public virtual void Main()
	{
	}
}
