using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BossControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PauseTriggers_0024469 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BossControl _0024self__0024470;

			public _0024(BossControl self_)
			{
				_0024self__0024470 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_005e
				int result;
				switch (_state)
				{
				default:
					_0024self__0024470.state = "waiting";
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024470.state = "on";
					_0024self__0024470.triggered = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal BossControl _0024self__0024471;

		public _0024PauseTriggers_0024469(BossControl self_)
		{
			_0024self__0024471 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024471);
		}
	}

	public bool lookAtPlayer;

	public bool reversePlayerOnBounce;

	public bool playerNeedsShield;

	public float playerBounceHeight;

	public int[] bouncesPerStage;

	public Transform[] prefabStages;

	public Transform[] prefabInjured;

	public Transform prefabKilled;

	public GameObject[] turnOnWhenKilled;

	public GameObject[] turnOffWhenKilled;

	public Transform bulletPrefab;

	private int stage;

	private int bounceCount;

	private string state;

	private GameObject targetGO;

	private int collectCount;

	private float hitTime;

	private GameControl gameControl;

	private bool triggered;

	private Transform hitTransform;

	private Transform visibleTransform;

	private Vector3 origEulerAngles;

	public BossControl()
	{
		lookAtPlayer = true;
		playerBounceHeight = 30f;
		stage = -1;
		state = "on";
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		for (int i = 0; i < Extensions.get_length((System.Array)turnOnWhenKilled); i++)
		{
			turnOnWhenKilled[i].SetActive(false);
		}
		NextStage();
		if (lookAtPlayer)
		{
			InvokeRepeating("LookAtPlayer", 1f, 0.1f);
		}
	}

	public virtual void FireBullet(string whatType)
	{
		if ((bool)bulletPrefab)
		{
			UnityEngine.Object.Instantiate(bulletPrefab, transform.position + transform.forward * 10f, transform.rotation);
		}
	}

	public virtual void ShotByBullet()
	{
		if (!(state != "on"))
		{
			bounceCount++;
			if (stage < Extensions.get_length((System.Array)prefabInjured))
			{
				UnityEngine.Object.Instantiate(prefabInjured[stage], transform.position, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate(prefabInjured[Extensions.get_length((System.Array)prefabInjured) - 1], transform.position, Quaternion.identity);
			}
			StartCoroutine(PauseTriggers());
			if (bounceCount >= bouncesPerStage[stage])
			{
				NextStage();
			}
		}
	}

	public virtual void OnCollisionStay(Collision collision)
	{
		OnTriggerStay(collision.collider);
	}

	public virtual void OnCollisionEnter()
	{
		triggered = true;
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		triggered = true;
	}

	public virtual IEnumerator PauseTriggers()
	{
		return new _0024PauseTriggers_0024469(this).GetEnumerator();
	}

	public virtual void ToggleObjects()
	{
		if (Extensions.get_length((System.Array)turnOnWhenKilled) > 0)
		{
			for (int i = 0; i < Extensions.get_length((System.Array)turnOnWhenKilled); i++)
			{
				if ((bool)turnOnWhenKilled[i])
				{
					turnOnWhenKilled[i].SetActive(true);
				}
			}
		}
		if (Extensions.get_length((System.Array)turnOffWhenKilled) <= 0)
		{
			return;
		}
		for (int i = 0; i < Extensions.get_length((System.Array)turnOffWhenKilled); i++)
		{
			if ((bool)turnOffWhenKilled[i])
			{
				turnOffWhenKilled[i].SetActive(false);
			}
		}
	}

	public virtual void NextStage()
	{
		stage++;
		bounceCount = 0;
		Quaternion rotation = transform.rotation;
		if ((bool)visibleTransform)
		{
			rotation = visibleTransform.rotation;
			UnityEngine.Object.Destroy(visibleTransform.gameObject);
		}
		if (stage + 1 <= Extensions.get_length((System.Array)prefabStages))
		{
			visibleTransform = (Transform)UnityEngine.Object.Instantiate(prefabStages[stage], transform.position, rotation);
			visibleTransform.parent = transform;
		}
		else
		{
			UnityEngine.Object.Instantiate(prefabKilled, transform.position, rotation);
			ToggleObjects();
			Kill();
		}
	}

	public virtual void LookAtPlayer()
	{
		if ((bool)visibleTransform)
		{
			origEulerAngles = visibleTransform.eulerAngles;
			visibleTransform.LookAt(gameControl.playerControl.transform);
			visibleTransform.eulerAngles = new Vector3(origEulerAngles.x, visibleTransform.eulerAngles.y, origEulerAngles.z);
		}
	}

	public virtual void ChildTrigger(Collider triggerObject)
	{
		triggered = true;
		OnTriggerStay(triggerObject);
	}

	public virtual void UpdateHits()
	{
		bounceCount++;
		if (stage + 1 > Extensions.get_length((System.Array)prefabInjured))
		{
			UnityEngine.Object.Instantiate(prefabInjured[Extensions.get_length((System.Array)prefabInjured) - 1], hitTransform.position, Quaternion.identity);
		}
		else
		{
			UnityEngine.Object.Instantiate(prefabInjured[stage], hitTransform.position, Quaternion.identity);
		}
		StartCoroutine(PauseTriggers());
		if (bounceCount >= bouncesPerStage[stage])
		{
			NextStage();
		}
		if (reversePlayerOnBounce)
		{
			hitTransform.SendMessage("ChangeRotation", new Vector3(0f, 180f, 0f), SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void OnTriggerStay(Collider triggerObject)
	{
		if (!triggered || state != "on" || !triggerObject.transform.parent || triggerObject.transform.parent.tag != "Player")
		{
			return;
		}
		hitTransform = triggerObject.transform.parent;
		if (!gameControl)
		{
			return;
		}
		if (gameControl.playerControl.shield != 0)
		{
			hitTransform.SendMessage("BouncedBaddie", playerBounceHeight, SendMessageOptions.DontRequireReceiver);
			UpdateHits();
		}
		else if (playerNeedsShield)
		{
			if (gameControl.playerControl.shield == 0)
			{
				hitTransform.SendMessage("AddDamage", 1, SendMessageOptions.DontRequireReceiver);
				return;
			}
			hitTransform.SendMessage("BouncedBaddie", playerBounceHeight, SendMessageOptions.DontRequireReceiver);
			UpdateHits();
		}
		else if (gameControl.playerControl.myAction.IndexOf("jump") != -1)
		{
			hitTransform.SendMessage("BouncedBaddie", playerBounceHeight, SendMessageOptions.DontRequireReceiver);
			UpdateHits();
		}
		else
		{
			hitTransform.SendMessage("AddDamage", 1, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Kill()
	{
		state = "dead";
		CancelInvoke();
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, 4f);
	}

	public virtual void Main()
	{
	}
}
