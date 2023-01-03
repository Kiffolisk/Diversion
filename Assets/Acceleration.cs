using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
	public static Vector2 acceleration
	{
		get
		{
			if (Application.isMobilePlatform)
			{
				return Input.acceleration;
			}
			float multiplier = (Application.loadedLevelName == "GemFields" || Application.loadedLevelName == "BonusPool") ? 3f : 0.1f;
			return new Vector2(Input.GetAxis("Mouse X") * multiplier, Input.GetAxis("Mouse Y") * multiplier);
		}
	}
}
