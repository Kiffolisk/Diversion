using System;
using UnityEngine;

[Serializable]
public class SpawnBullet : MonoBehaviour
{
	public Transform bulletPrefab;

	public float secondsBetweenShots;

	public Animation myAnimation;

	public string fireAnimation;

	public SpawnBullet()
	{
		fireAnimation = string.Empty;
	}

	public virtual void Start()
	{
		if (secondsBetweenShots != 0f)
		{
			InvokeRepeating("TurnOn", secondsBetweenShots, secondsBetweenShots);
		}
	}

	public virtual void TurnOn()
	{
		UnityEngine.Object.Instantiate(bulletPrefab, transform.position, transform.rotation);
		if ((bool)myAnimation && fireAnimation != string.Empty)
		{
			myAnimation.Play(fireAnimation);
		}
	}

	public virtual void FireBullet(string whatType)
	{
		TurnOn();
	}

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawSphere(transform.position, 2f);
		Vector3 direction = transform.TransformDirection(Vector3.forward) * 10f;
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, direction);
	}

	public virtual void Main()
	{
	}
}
