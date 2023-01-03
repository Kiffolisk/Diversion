using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TriggerObject : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024699 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_0024700;

			internal Transform _0024child_0024701;

			internal IEnumerator _0024_0024iterator_0024133_0024702;

			internal GameObject _0024tempTransform_0024703;

			internal TriggerObject _0024self__0024704;

			public _0024(TriggerObject self_)
			{
				_0024self__0024704 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024704.gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
					if (_0024self__0024704.dieTime != 0)
					{
						result = (Yield(2, new WaitForSeconds(_0024self__0024704.dieTime)) ? 1 : 0);
						break;
					}
					goto IL_0106;
				case 2:
					_0024i_0024700 = 0;
					goto IL_00ea;
				case 3:
					_0024self__0024704.transform.localScale = Vector3.one;
					result = (Yield(4, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 4:
					_0024i_0024700++;
					goto IL_00ea;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00ea:
					if (_0024i_0024700 < 6)
					{
						_0024self__0024704.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
						result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					UnityEngine.Object.Destroy(_0024self__0024704.gameObject);
					goto IL_0106;
					IL_0106:
					if (_0024self__0024704.hideForSecondsAfterHit != 0f)
					{
						_0024self__0024704.origPosition = _0024self__0024704.transform.position;
						_0024self__0024704.regenerateAfterSeconds = (int)_0024self__0024704.hideForSecondsAfterHit;
					}
					if (_0024self__0024704.transform.name.IndexOf("Star") != -1)
					{
						_0024_0024iterator_0024133_0024702 = UnityRuntimeServices.GetEnumerator(_0024self__0024704.transform);
						while (_0024_0024iterator_0024133_0024702.MoveNext())
						{
							object obj = _0024_0024iterator_0024133_0024702.Current;
							if (!(obj is Transform))
							{
								obj = RuntimeServices.Coerce(obj, typeof(Transform));
							}
							_0024child_0024701 = (Transform)obj;
							UnityEngine.Object.Destroy(_0024child_0024701.gameObject);
							UnityRuntimeServices.Update(_0024_0024iterator_0024133_0024702, _0024child_0024701);
						}
						_0024tempTransform_0024703 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(_0024self__0024704.gameControl.appName + "/StarPrefab"), _0024self__0024704.transform.position, Quaternion.identity);
						_0024tempTransform_0024703.transform.parent = _0024self__0024704.transform;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal TriggerObject _0024self__0024705;

		public _0024Start_0024699(TriggerObject self_)
		{
			_0024self__0024705 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024705);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PauseTriggers_0024706 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TriggerObject _0024self__0024707;

			public _0024(TriggerObject self_)
			{
				_0024self__0024707 = self_;
			}

			public override bool MoveNext()
			{
				//Discarded unreachable code: IL_005e
				int result;
				switch (_state)
				{
				default:
					_0024self__0024707.state = "waiting";
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024707.state = "on";
					_0024self__0024707.triggered = false;
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TriggerObject _0024self__0024708;

		public _0024PauseTriggers_0024706(TriggerObject self_)
		{
			_0024self__0024708 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024708);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnTriggerStay_0024709 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024tempTransform_0024710;

			internal Collider _0024triggerObject_0024711;

			internal TriggerObject _0024self__0024712;

			public _0024(Collider triggerObject, TriggerObject self_)
			{
				_0024triggerObject_0024711 = triggerObject;
				_0024self__0024712 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024712.triggered && !(_0024self__0024712.state != "on") && (bool)_0024triggerObject_0024711.transform.parent && !(_0024triggerObject_0024711.transform.parent.tag != "Player"))
					{
						_0024self__0024712.hitTransform = _0024triggerObject_0024711.transform.parent;
						if ((bool)_0024self__0024712.gameControl && _0024self__0024712.underwater == (_0024self__0024712.gameControl.playerControl.myAction.IndexOf("water") != -1))
						{
							_0024self__0024712.state = "collected";
							if (_0024self__0024712.bounceToDestroy && _0024self__0024712.gameControl.playerControl.myAction.IndexOf("jump") != -1)
							{
								_0024self__0024712.bouncesRequiredToDestroy--;
								_0024triggerObject_0024711.transform.parent.SendMessage("BouncedBaddie", 60, SendMessageOptions.DontRequireReceiver);
								if (_0024self__0024712.bouncesRequiredToDestroy > 0)
								{
									if ((bool)_0024self__0024712.prefabWhenBouncedButStillAlive)
									{
										UnityEngine.Object.Instantiate(_0024self__0024712.prefabWhenBouncedButStillAlive, _0024self__0024712.transform.position, Quaternion.identity);
									}
									_0024self__0024712.StartCoroutine(_0024self__0024712.PauseTriggers());
									goto case 1;
								}
								if ((bool)_0024self__0024712.prefabWhenBounced)
								{
									UnityEngine.Object.Instantiate(_0024self__0024712.prefabWhenBounced, _0024self__0024712.transform.position, Quaternion.identity);
								}
								_0024self__0024712.damage = 0;
								_0024self__0024712.vibrateWhenHit = false;
								_0024self__0024712.prefabWhenHit = null;
							}
							if ((bool)_0024self__0024712.prefabWhenHit)
							{
								_0024tempTransform_0024710 = null;
								if (_0024self__0024712.showAtImpact)
								{
									_0024tempTransform_0024710 = (Transform)UnityEngine.Object.Instantiate(_0024self__0024712.prefabWhenHit, _0024self__0024712.hitTransform.position, Quaternion.identity);
								}
								else
								{
									_0024tempTransform_0024710 = (Transform)UnityEngine.Object.Instantiate(_0024self__0024712.prefabWhenHit, _0024self__0024712.transform.position, Quaternion.identity);
								}
								_0024tempTransform_0024710.parent = _0024self__0024712.transform.parent;
							}
							if (_0024self__0024712.hitTransform == _0024self__0024712.gameControl.playerControl.transform && _0024self__0024712.gameControl.playerControl.shield == 0)
							{
								if (_0024self__0024712.vibrateWhenHit)
								{
									_0024self__0024712.gameControl.Shake(1f, true);
								}
								if ((bool)_0024self__0024712.soundWhenHit)
								{
									_0024self__0024712.gameControl.PlaySound(_0024self__0024712.soundWhenHit);
								}
							}
							_0024self__0024712.hitTime = Time.realtimeSinceStartup;
							if (_0024self__0024712.forceToAdd != 0f)
							{
								_0024self__0024712.StartCoroutine(_0024self__0024712.AddForceDelayed(_0024self__0024712.hitTransform, _0024self__0024712.forceToAdd));
							}
							if (_0024self__0024712.damage > 0)
							{
								_0024self__0024712.hitTransform.SendMessage("AddDamage", _0024self__0024712.damage, SendMessageOptions.DontRequireReceiver);
							}
							if (!(_0024self__0024712.boost <= 0f))
							{
								if (_0024self__0024712.moveToCornerOnCollect)
								{
									_0024self__0024712.collectOffset = new Vector3(-8f, -6f, 13f);
									result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
									break;
								}
								_0024self__0024712.hitTransform.SendMessage("AddBoost", _0024self__0024712.boost, SendMessageOptions.DontRequireReceiver);
							}
							goto IL_04cb;
						}
					}
					goto case 1;
				case 2:
					_0024self__0024712.hitTransform.SendMessage("AddBoost", _0024self__0024712.boost, SendMessageOptions.DontRequireReceiver);
					goto IL_04cb;
				case 3:
					_0024self__0024712.hitTransform.SendMessage("AddGems", _0024self__0024712.gems, SendMessageOptions.DontRequireReceiver);
					goto IL_056d;
				case 4:
					_0024self__0024712.hitTransform.SendMessage("AddStar", _0024self__0024712.star, SendMessageOptions.DontRequireReceiver);
					goto IL_05d3;
				case 5:
					_0024self__0024712.hitTransform.SendMessage("AddHealth", _0024self__0024712.health, SendMessageOptions.DontRequireReceiver);
					goto IL_06a9;
				case 6:
					_0024self__0024712.hitTransform.SendMessage("AddX2", _0024self__0024712.x2, SendMessageOptions.DontRequireReceiver);
					goto IL_0780;
				case 1:
					{
						result = 0;
						break;
					}
					IL_06a9:
					if (_0024self__0024712.shield > 0)
					{
						_0024self__0024712.hitTransform.SendMessage("AddShield", _0024self__0024712.shield, SendMessageOptions.DontRequireReceiver);
					}
					if (_0024self__0024712.x2 > 0)
					{
						if (_0024self__0024712.moveToCornerOnCollect)
						{
							_0024self__0024712.collectOffset = new Vector3(11f, 6f, 13f);
							result = (Yield(6, new WaitForSeconds(0.5f)) ? 1 : 0);
							break;
						}
						_0024self__0024712.hitTransform.SendMessage("AddX2", _0024self__0024712.x2, SendMessageOptions.DontRequireReceiver);
					}
					goto IL_0780;
					IL_0780:
					if (_0024self__0024712.hole)
					{
						_0024self__0024712.hitTransform.SendMessage("FallDownHole", _0024self__0024712.holeSoundOff, SendMessageOptions.DontRequireReceiver);
					}
					if (_0024self__0024712.winMissionWhenHit)
					{
						_0024self__0024712.gameControl.missionWin = true;
						_0024self__0024712.StartCoroutine(_0024self__0024712.gameControl.EndMission("missionEnd"));
					}
					_0024self__0024712.Kill();
					YieldDefault(1);
					goto case 1;
					IL_05d3:
					if (_0024self__0024712.tokens > 0)
					{
						_0024self__0024712.gameControl.AddTokens(_0024self__0024712.tokens);
					}
					if (_0024self__0024712.hint > 0)
					{
						_0024self__0024712.gameControl.hintCollected = true;
					}
					if (_0024self__0024712.health > 0)
					{
						if (_0024self__0024712.moveToCornerOnCollect)
						{
							result = (Yield(5, new WaitForSeconds(0.5f)) ? 1 : 0);
							break;
						}
						_0024self__0024712.hitTransform.SendMessage("AddHealth", _0024self__0024712.health, SendMessageOptions.DontRequireReceiver);
					}
					goto IL_06a9;
					IL_04cb:
					if (_0024self__0024712.gems > 0)
					{
						if (_0024self__0024712.moveToCornerOnCollect)
						{
							_0024self__0024712.collectOffset = new Vector3(9.5f, 6f, 13f);
							result = (Yield(3, new WaitForSeconds(0.5f)) ? 1 : 0);
							break;
						}
						_0024self__0024712.hitTransform.SendMessage("AddGems", _0024self__0024712.gems, SendMessageOptions.DontRequireReceiver);
					}
					goto IL_056d;
					IL_056d:
					if (_0024self__0024712.star > 0)
					{
						_0024self__0024712.collectOffset = new Vector3(9f, -6f, 13f);
						result = (Yield(4, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_05d3;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024triggerObject_0024713;

		internal TriggerObject _0024self__0024714;

		public _0024OnTriggerStay_0024709(Collider triggerObject, TriggerObject self_)
		{
			_0024triggerObject_0024713 = triggerObject;
			_0024self__0024714 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024triggerObject_0024713, _0024self__0024714);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024AddForceDelayed_0024715 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Transform _0024hitTransform_0024716;

			internal float _0024force_0024717;

			public _0024(Transform hitTransform, float force)
			{
				_0024hitTransform_0024716 = hitTransform;
				_0024force_0024717 = force;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.05f)) ? 1 : 0);
					break;
				case 2:
					_0024hitTransform_0024716.SendMessage("AddVerticalForce", _0024force_0024717, SendMessageOptions.DontRequireReceiver);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Transform _0024hitTransform_0024718;

		internal float _0024force_0024719;

		public _0024AddForceDelayed_0024715(Transform hitTransform, float force)
		{
			_0024hitTransform_0024718 = hitTransform;
			_0024force_0024719 = force;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024hitTransform_0024718, _0024force_0024719);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Regenerate_0024720 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TriggerObject _0024self__0024721;

			public _0024(TriggerObject self_)
			{
				_0024self__0024721 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024721.hideForSecondsAfterHit != 0f)
					{
						_0024self__0024721.transform.Translate(Vector3.up * 2000f);
					}
					result = (Yield(2, new WaitForSeconds(_0024self__0024721.regenerateAfterSeconds)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__0024721.hideForSecondsAfterHit != 0f)
					{
						_0024self__0024721.transform.position = _0024self__0024721.origPosition;
						_0024self__0024721.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					_0024self__0024721.triggered = false;
					_0024self__0024721.state = "on";
					_0024self__0024721.collectCount = 0;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TriggerObject _0024self__0024722;

		public _0024Regenerate_0024720(TriggerObject self_)
		{
			_0024self__0024722 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024722);
		}
	}

	public float forceToAdd;

	public bool underwater;

	public int damage;

	public int health;

	public int gems;

	public float boost;

	public int shield;

	public int x2;

	public int star;

	public int tokens;

	public int hint;

	public bool hole;

	public bool holeSoundOff;

	public int dieTime;

	public bool winMissionWhenHit;

	public bool bounceToDestroy;

	public int bouncesRequiredToDestroy;

	public Transform prefabWhenBouncedButStillAlive;

	public Transform prefabWhenBounced;

	public bool destroyWhenHit;

	public float hideForSecondsAfterHit;

	public bool vibrateWhenHit;

	public Transform prefabWhenHit;

	public bool showAtImpact;

	public AudioClip soundWhenHit;

	public AudioClip soundWhenCollected;

	public string messageWhenHit;

	public bool moveToCornerOnCollect;

	private int regenerateAfterSeconds;

	private string state;

	private GameObject targetGO;

	private int collectCount;

	private float hitTime;

	private GameControl gameControl;

	private bool triggered;

	private Transform hitTransform;

	private Vector3 collectOffset;

	private float newScale;

	private Vector3 origPosition;

	public TriggerObject()
	{
		damage = 1;
		bouncesRequiredToDestroy = 1;
		messageWhenHit = string.Empty;
		regenerateAfterSeconds = 2;
		state = "on";
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_0024699(this).GetEnumerator();
	}

	public virtual void OnCollisionStay(Collision collision)
	{
		StartCoroutine(OnTriggerStay(collision.collider));
	}

	public virtual void OnCollisionEnter()
	{
		triggered = true;
	}

	public virtual void OnTriggerEnter()
	{
		triggered = true;
	}

	public virtual IEnumerator PauseTriggers()
	{
		return new _0024PauseTriggers_0024706(this).GetEnumerator();
	}

	public virtual IEnumerator OnTriggerStay(Collider triggerObject)
	{
		return new _0024OnTriggerStay_0024709(triggerObject, this).GetEnumerator();
	}

	public virtual IEnumerator AddForceDelayed(Transform hitTransform, float force)
	{
		return new _0024AddForceDelayed_0024715(hitTransform, force).GetEnumerator();
	}

	public virtual void Update()
	{
		if (state == "collected")
		{
			collectCount++;
			transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position + Camera.main.transform.TransformDirection(collectOffset), (Time.realtimeSinceStartup - hitTime) * 2f);
			if (collectCount < 15)
			{
				newScale = Mathf.Clamp(1f * (1f - (Time.realtimeSinceStartup - hitTime) * 2f), 0f, 1f);
				transform.localScale = new Vector3(newScale, newScale, newScale);
			}
			else
			{
				transform.localScale = new Vector3(0f, 0f, 0f);
			}
		}
	}

	public virtual void Kill()
	{
		state = "dead";
		if ((bool)soundWhenCollected)
		{
			gameControl.PlaySound(soundWhenCollected);
		}
		if (destroyWhenHit)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
		else
		{
			StartCoroutine(Regenerate());
		}
	}

	public virtual IEnumerator Regenerate()
	{
		return new _0024Regenerate_0024720(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
