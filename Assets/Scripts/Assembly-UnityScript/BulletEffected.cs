using System;
using UnityEngine;

[Serializable]
public class BulletEffected : MonoBehaviour
{
	public Transform prefabWhenHit;

	public virtual void Awake()
	{
		transform.tag = "BulletEffected";
	}

	public virtual void ShotByBullet()
	{
		if ((bool)prefabWhenHit)
		{
			Transform transform = null;
			transform = (Transform)UnityEngine.Object.Instantiate(prefabWhenHit, this.transform.position, Quaternion.identity);
			transform.parent = this.transform.parent;
		}
		UnityEngine.Object.Destroy(gameObject, 0.05f);
	}

	public virtual void Main()
	{
	}
}
