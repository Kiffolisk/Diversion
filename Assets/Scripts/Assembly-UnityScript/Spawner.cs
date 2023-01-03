using System;
using UnityEngine;

[Serializable]
public class Spawner : MonoBehaviour
{
	public Transform spawnPrefab;

	public int rows;

	public int columns;

	public float distanceBetween;

	public float heightAboveGround;

	public float maxScale;

	private RaycastHit hit;

	private Vector3 collidePos;

	private int layerMask;

	public Spawner()
	{
		rows = 10;
		columns = 10;
		distanceBetween = 100f;
		heightAboveGround = 10f;
		maxScale = 1f;
	}

	public virtual void Start()
	{
		if (!spawnPrefab)
		{
			return;
		}
		layerMask = 4;
		layerMask = ~layerMask;
		int num = 0;
		Transform transform = null;
		for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				collidePos = this.transform.position + new Vector3(((float)columns * 0.5f - (float)i) * distanceBetween, 0f, ((float)rows * 0.5f - (float)j) * distanceBetween);
				if (heightAboveGround == 0f)
				{
					transform = (Transform)UnityEngine.Object.Instantiate(spawnPrefab, new Vector3(collidePos.x, hit.point.y + heightAboveGround, collidePos.z), Quaternion.identity);
					transform.parent = this.transform;
					num++;
					continue;
				}
				collidePos += Vector3.up * 50f;
				if (Physics.Raycast(collidePos, -Vector3.up, out hit, 200f, layerMask))
				{
					transform = (Transform)UnityEngine.Object.Instantiate(spawnPrefab, new Vector3(collidePos.x, hit.point.y + heightAboveGround, collidePos.z), Quaternion.identity);
					if (maxScale != 1f)
					{
						transform.localScale = new Vector3(UnityEngine.Random.Range(1f, maxScale), UnityEngine.Random.Range(1f, maxScale), UnityEngine.Random.Range(1f, maxScale));
					}
					transform.parent = this.transform;
					num++;
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
