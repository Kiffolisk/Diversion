using System;
using UnityEngine;

[Serializable]
public class HUDControl : MonoBehaviour
{
	private GameControl gameControl;

	public virtual void Start()
	{
		useGUILayout = false;
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
	}

	public virtual void Update()
	{
		GetComponent<GUIText>().text = gameControl.playerName + "  LEVEL:" + gameControl.playerData.level + "     XP:" + gameControl.playerData.xp + "      GEMS:" + gameControl.playerData.gems;
	}

	public virtual void Main()
	{
	}
}
