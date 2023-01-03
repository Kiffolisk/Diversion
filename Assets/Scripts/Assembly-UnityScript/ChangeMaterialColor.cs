using System;
using UnityEngine;

[Serializable]
public class ChangeMaterialColor : MonoBehaviour
{
	public Color materialColor;

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent)
		{
			triggerObject.transform.parent.SendMessage("ChangeMaterialColor", materialColor, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent)
		{
			triggerObject.transform.parent.SendMessage("ChangeMaterialColor", Color.white, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Main()
	{
	}
}
