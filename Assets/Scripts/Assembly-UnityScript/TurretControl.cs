using System;
using UnityEngine;

[Serializable]
public class TurretControl : MonoBehaviour
{
	public Transform bulletPrefab;

	public Vector3 bulletPositionOffset;

	public float secondsBetweenShots;

	public string fireAnimation;

	private Animation myAnimation;

	public TurretControl()
	{
		fireAnimation = string.Empty;
	}

	public virtual void Start()
	{
		myAnimation = (Animation)gameObject.GetComponent(typeof(Animation));
		if (secondsBetweenShots != 0f)
		{
			InvokeRepeating("TurnOn", secondsBetweenShots, secondsBetweenShots);
		}
	}

	public virtual void TurnOn()
	{
		if ((bool)myAnimation && fireAnimation != string.Empty)
		{
			myAnimation.Play(fireAnimation);
		}
	}

	public virtual void FireBullet(string whatType)
	{
		Quaternion rotation = transform.rotation;
		UnityEngine.Object.Instantiate(bulletPrefab, transform.position + bulletPositionOffset, rotation);
	}

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.gray;
		Gizmos.DrawSphere(transform.position + bulletPositionOffset, 2f);
		Vector3 direction = transform.TransformDirection(Vector3.forward) * 10f;
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position + bulletPositionOffset, direction);
	}

	public virtual void Main()
	{
	}
}
