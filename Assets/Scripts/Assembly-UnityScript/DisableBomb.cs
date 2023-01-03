using System;
using UnityEngine;

[Serializable]
public class DisableBomb : MonoBehaviour
{
	public Transform explosionPrefab;

	public Transform throwPrefab;

	public float destroyAfterSeconds;

	public DisableBomb()
	{
		destroyAfterSeconds = 5f;
	}

	public virtual void Awake()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().AddForceAtPosition(transform.up * 10f, transform.position + new Vector3(0f, 0f, UnityEngine.Random.Range(-5, 5)), ForceMode.Impulse);
		}
		if ((bool)explosionPrefab)
		{
			UnityEngine.Object.Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}
		if ((bool)throwPrefab)
		{
			UnityEngine.Object.Instantiate(throwPrefab, transform.position, Quaternion.identity);
		}
		UnityEngine.Object.Destroy(gameObject, destroyAfterSeconds);
	}

	public virtual void Main()
	{
	}
}
