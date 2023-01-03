using System;
using UnityEngine;

[Serializable]
public class TriggerReward : MonoBehaviour
{
	public Transform rewardPrefab;

	public string activatedTag;

	public AudioClip soundWhenActivated;

	private bool used;

	private GameControl gameControl;

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
	}

	public virtual void OnTriggerEnter(Collider triggerCollider)
	{
		if (!used && triggerCollider.gameObject.tag == activatedTag)
		{
			ShowReward(transform.position);
			used = true;
		}
	}

	public virtual void ShowReward(Vector3 splashPos)
	{
		if ((bool)soundWhenActivated)
		{
			gameControl.PlaySound(soundWhenActivated);
		}
		if ((bool)rewardPrefab)
		{
			Transform transform = null;
			transform = (Transform)UnityEngine.Object.Instantiate(rewardPrefab, splashPos, Quaternion.identity);
		}
	}

	public virtual void Main()
	{
	}
}
