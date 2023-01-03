using System;
using UnityEngine;

[Serializable]
public class BaddiePuncher : MonoBehaviour
{
	private bool charged;

	public BaddiePuncher()
	{
		charged = true;
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (triggerObject.tag == "BulletEffected")
		{
			if ((bool)triggerObject.transform.parent)
			{
				triggerObject.transform.parent.SendMessage("ShotByBullet", 1, SendMessageOptions.DontRequireReceiver);
				triggerObject.transform.SendMessage("ShotByBullet", 1, SendMessageOptions.DontRequireReceiver);
			}
		}
		else if (triggerObject.tag == "Button")
		{
			triggerObject.transform.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Main()
	{
	}
}
