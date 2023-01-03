using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Meteor : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Launch_0024608 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Meteor _0024self__0024609;

			public _0024(Meteor self_)
			{
				_0024self__0024609 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024609.state = "inair";
					if ((bool)_0024self__0024609.meteorGO)
					{
						_0024self__0024609.meteorGO.SetActive(true);
					}
					if ((bool)_0024self__0024609.craterGO)
					{
						_0024self__0024609.craterGO.SetActive(false);
					}
					_0024self__0024609.particleTransform = (Transform)UnityEngine.Object.Instantiate(_0024self__0024609.particlePrefab, _0024self__0024609.transform.position, Quaternion.identity);
					_0024self__0024609.particleTransform.parent = _0024self__0024609.transform;
					if ((bool)_0024self__0024609.inAirSound)
					{
						_0024self__0024609.GetComponent<AudioSource>().PlayOneShot(_0024self__0024609.inAirSound);
					}
					result = (Yield(2, new WaitForSeconds(_0024self__0024609.airTime)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024609.state = "active";
					if (_0024self__0024609.disappearWhenDone)
					{
						if ((bool)_0024self__0024609.meteorGO)
						{
							_0024self__0024609.meteorGO.SetActive(false);
						}
						if ((bool)_0024self__0024609.craterGO)
						{
							_0024self__0024609.craterGO.SetActive(false);
						}
						if ((bool)_0024self__0024609.particleTransform)
						{
							_0024self__0024609.particleTransform.GetComponent<ParticleEmitter>().emit = false;
						}
					}
					else
					{
						_0024self__0024609.gameControl.Shake(0.4f, false);
						if ((bool)_0024self__0024609.hitGroundSound)
						{
							_0024self__0024609.GetComponent<AudioSource>().PlayOneShot(_0024self__0024609.hitGroundSound);
						}
						_0024self__0024609.transform.position = _0024self__0024609.landingPosition;
						if ((bool)_0024self__0024609.craterGO)
						{
							_0024self__0024609.craterGO.SetActive(true);
						}
						if ((bool)_0024self__0024609.particleTransform)
						{
							_0024self__0024609.particleTransform.GetComponent<ParticleEmitter>().emit = false;
						}
						if ((bool)_0024self__0024609.meteorGO && (bool)_0024self__0024609.meteorGO.GetComponent<Animation>())
						{
							_0024self__0024609.meteorGO.GetComponent<Animation>().Play("groundHit");
						}
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Meteor _0024self__0024610;

		public _0024Launch_0024608(Meteor self_)
		{
			_0024self__0024610 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024610);
		}
	}

	public float showDistance;

	public bool disappearWhenDone;

	public GameObject meteorGO;

	public GameObject craterGO;

	public Transform particlePrefab;

	private Transform particleTransform;

	public AudioClip inAirSound;

	public AudioClip hitGroundSound;

	private float airTime;

	private string state;

	private Vector3 speedVector;

	private Vector3 landingPosition;

	private GameControl gameControl;

	public Meteor()
	{
		showDistance = 300f;
		airTime = 5f;
		state = "waiting";
	}

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		Initialize();
	}

	public virtual void Initialize()
	{
		speedVector = new Vector3(100f, UnityEngine.Random.Range(-50, -100), UnityEngine.Random.Range(50, 100)) * 2f;
		landingPosition = transform.position;
		if ((bool)meteorGO)
		{
			meteorGO.SetActive(false);
		}
		if ((bool)craterGO)
		{
			craterGO.SetActive(false);
		}
		state = "ready";
		transform.position -= speedVector * airTime;
	}

	public virtual IEnumerator Launch()
	{
		return new _0024Launch_0024608(this).GetEnumerator();
	}

	public virtual void Update()
	{
		string text = state;
		if (text == "ready")
		{
			if (!(Vector3.Distance(landingPosition, gameControl.playerControl.transform.position) >= showDistance))
			{
				StartCoroutine(Launch());
			}
		}
		else if (text == "inair")
		{
			transform.position += speedVector * Time.deltaTime;
		}
	}

	public virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(transform.position, 4f);
	}

	public virtual void Main()
	{
	}
}
