using System;
using UnityEngine;

[Serializable]
public class BossTrigger : MonoBehaviour
{
	public virtual void OnTriggerStay(Collider triggerObject)
	{
		if ((bool)transform.parent)
		{
			transform.parent.SendMessage("ChildTrigger", triggerObject);
		}
	}

	public virtual void ShotByBullet()
	{
		if ((bool)transform.parent)
		{
			transform.parent.SendMessage("ShotByBullet");
		}
	}

	public virtual void Main()
	{
	}
}
