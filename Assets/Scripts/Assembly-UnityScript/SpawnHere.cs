using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class SpawnHere : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Spawn_0024681 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024myDist_0024682;

			internal Transform _0024tempTransform_0024683;

			internal int _0024tempRandom_0024684;

			internal bool _0024showToken_0024685;

			internal GameObject _0024tempGO_0024686;

			internal GameObject _0024tempGO2_0024687;

			internal SpawnHere _0024self__0024688;

			public _0024(SpawnHere self_)
			{
				_0024self__0024688 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.01f)) ? 1 : 0);
					break;
				case 2:
					if (!_0024self__0024688.hasSpawned)
					{
						_0024self__0024688.hasSpawned = true;
						if ((bool)_0024self__0024688.gameControl.playerControl)
						{
							_0024myDist_0024682 = _0024self__0024688.gameControl.playerControl.transform.position.x - _0024self__0024688.transform.position.x;
							if (!(_0024myDist_0024682 >= 100f) && _0024self__0024688.dontShowIfPlayerTooClose)
							{
								_0024self__0024688.enabled = false;
								goto case 1;
							}
						}
						if (Extensions.get_length((System.Array)_0024self__0024688.spawnPrefab) > 0)
						{
							_0024tempTransform_0024683 = null;
							_0024tempRandom_0024684 = 0;
							_0024showToken_0024685 = false;
							if ((bool)_0024self__0024688.transform.parent && _0024self__0024688.transform.parent.name.IndexOf("CrateCollect") != -1 && !((float)UnityEngine.Random.Range(0, 100) >= _0024self__0024688.gameControl.tokenPercentage))
							{
								_0024showToken_0024685 = true;
							}
							if (_0024showToken_0024685)
							{
								_0024tempGO_0024686 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("PowerupToken"), _0024self__0024688.transform.position, _0024self__0024688.transform.rotation);
								_0024tempGO_0024686.transform.parent = _0024self__0024688.transform;
								_0024tempGO_0024686.transform.name = "RespawnPoint";
							}
							else if (_0024self__0024688.spawnPrefab[_0024tempRandom_0024684].name.IndexOf("Star") != -1)
							{
								if (_0024self__0024688.showStar)
								{
									_0024tempRandom_0024684 = 0;
									_0024tempTransform_0024683 = (Transform)UnityEngine.Object.Instantiate(_0024self__0024688.spawnPrefab[_0024tempRandom_0024684], _0024self__0024688.transform.position, _0024self__0024688.transform.rotation);
									_0024tempTransform_0024683.parent = _0024self__0024688.transform;
									if (_0024tempTransform_0024683.name.IndexOf("Star") != -1 || _0024tempTransform_0024683.name.IndexOf("Token") != -1)
									{
										_0024tempTransform_0024683.name = "RespawnPoint";
									}
								}
								else if (!((float)UnityEngine.Random.Range(0, 100) >= _0024self__0024688.gameControl.tokenPercentage))
								{
									_0024tempGO2_0024687 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("PowerupToken"), _0024self__0024688.transform.position, _0024self__0024688.transform.rotation);
									_0024tempGO2_0024687.transform.parent = _0024self__0024688.transform;
									if (_0024tempGO2_0024687.transform.name.IndexOf("Star") != -1 || _0024tempGO2_0024687.transform.name.IndexOf("Token") != -1)
									{
										_0024tempGO2_0024687.transform.name = "RespawnPoint";
									}
								}
								else if (Extensions.get_length((System.Array)_0024self__0024688.spawnPrefab) > 1)
								{
									_0024tempRandom_0024684 = UnityEngine.Random.Range(1, Extensions.get_length((System.Array)_0024self__0024688.spawnPrefab));
									_0024tempTransform_0024683 = (Transform)UnityEngine.Object.Instantiate(_0024self__0024688.spawnPrefab[_0024tempRandom_0024684], _0024self__0024688.transform.position, _0024self__0024688.transform.rotation);
									_0024tempTransform_0024683.parent = _0024self__0024688.transform;
									if (_0024tempTransform_0024683.name.IndexOf("Star") != -1 || _0024tempTransform_0024683.name.IndexOf("Token") != -1)
									{
										_0024tempTransform_0024683.name = "RespawnPoint";
									}
								}
							}
							else if (!(UnityEngine.Random.Range(0f, 1f) > _0024self__0024688.chanceOfShowing))
							{
								if (Extensions.get_length((System.Array)_0024self__0024688.spawnPrefab) > 1)
								{
									_0024tempRandom_0024684 = UnityEngine.Random.Range(1, Extensions.get_length((System.Array)_0024self__0024688.spawnPrefab));
								}
								if (_0024self__0024688.spawnPrefab[_0024tempRandom_0024684].name.IndexOf("Health") != -1)
								{
									_0024tempRandom_0024684 = 0;
								}
								_0024tempTransform_0024683 = (Transform)UnityEngine.Object.Instantiate(_0024self__0024688.spawnPrefab[_0024tempRandom_0024684], _0024self__0024688.transform.position, _0024self__0024688.transform.rotation);
								_0024tempTransform_0024683.parent = _0024self__0024688.transform;
								if (_0024tempTransform_0024683.name.IndexOf("Star") != -1 || _0024tempTransform_0024683.name.IndexOf("Token") != -1)
								{
									_0024tempTransform_0024683.name = "RespawnPoint";
								}
							}
						}
						_0024self__0024688.enabled = false;
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal SpawnHere _0024self__0024689;

		public _0024Spawn_0024681(SpawnHere self_)
		{
			_0024self__0024689 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024689);
		}
	}

	public Transform[] spawnPrefab;

	public int showIfScoreIsOver;

	public float chanceOfShowing;

	public bool alwaysShow;

	public bool dontShowIfPlayerTooClose;

	private GameControl gameControl;

	private bool hasSpawned;

	private bool showStar;

	public SpawnHere()
	{
		chanceOfShowing = 1f;
	}

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if ((bool)gameControl)
		{
			showStar = gameControl.showStar;
		}
	}

	public virtual void OnEnable()
	{
		StartCoroutine(Spawn());
	}

	public virtual IEnumerator Spawn()
	{
		return new _0024Spawn_0024681(this).GetEnumerator();
	}

	public virtual void OnDrawGizmos()
	{
		if (spawnPrefab[0].name.IndexOf("Baddie") != -1)
		{
			Gizmos.color = Color.magenta;
		}
		else if (spawnPrefab[0].name.IndexOf("Star") != -1)
		{
			Gizmos.color = Color.yellow;
		}
		else if (spawnPrefab[0].name.IndexOf("Token") != -1)
		{
			Gizmos.color = Color.yellow;
		}
		else
		{
			Gizmos.color = Color.green;
		}
		if (spawnPrefab[0].name.IndexOf("water") != -1)
		{
			Gizmos.color += Color.blue;
		}
		Gizmos.DrawSphere(transform.position, 4f);
	}

	public virtual void Main()
	{
	}
}
