using System;
using UnityEngine;

[Serializable]
public class SampleGUIManager : MonoBehaviour
{
	public virtual void OnGUI()
	{
		if (GUI.Button(new Rect(100f, 100f, 200f, 60f), "Show"))
		{
			gameObject.SendMessage("ShowPromo", SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void PromoShowing()
	{
		MonoBehaviour.print("Now showing the promo!");
	}

	public virtual void PromoDone(int prizeID)
	{
		MonoBehaviour.print("Promo finished, and " + prizeID + " tokens awarded");
	}

	public virtual void Main()
	{
	}
}
