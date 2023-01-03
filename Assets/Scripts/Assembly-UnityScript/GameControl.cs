using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using Prime31;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class GameControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RecordingStop_0024495 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameControl _0024self__0024496;

			public _0024(GameControl self_)
			{
				_0024self__0024496 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__0024496.videoReplay || !_0024self__0024496.videoRecording)
					{
						goto case 1;
					}
					_0024self__0024496.videoRecording = false;
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024497;

		public _0024RecordingStop_0024495(GameControl self_)
		{
			_0024self__0024497 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024497);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RemoteForgotPassword_0024498 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024get_url_0024499;

			internal WWW _0024hs_get_0024500;

			internal string _0024myString_0024501;

			internal GameControl _0024self__0024502;

			public _0024(GameControl self_)
			{
				_0024self__0024502 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024502.redeemMessage = "Contacting the cloud server...";
					_0024get_url_0024499 = "http://ezone.com/cloud/diversion.php?action=forgot" + "&email=" + WWW.EscapeURL(_0024self__0024502.cloudEmail) + "&rnd=" + UnityEngine.Random.Range(0, 100000);
					_0024hs_get_0024500 = new WWW(_0024get_url_0024499);
					result = (Yield(2, _0024hs_get_0024500) ? 1 : 0);
					break;
				case 2:
					if (!string.IsNullOrEmpty(_0024hs_get_0024500.error))
					{
						_0024self__0024502.redeemMessage = "Sorry, could not contact the cloud server.";
						if (_0024self__0024502.cheatsOn)
						{
							_0024self__0024502.redeemMessage = "Error: " + _0024hs_get_0024500.error;
						}
					}
					else
					{
						_0024myString_0024501 = string.Empty + _0024hs_get_0024500.text;
						_0024self__0024502.redeemMessage = _0024myString_0024501;
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

		internal GameControl _0024self__0024503;

		public _0024RemoteForgotPassword_0024498(GameControl self_)
		{
			_0024self__0024503 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__0024503);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RemoteDataSave_0024504 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024get_url_0024505;

			internal WWWForm _0024form_0024506;

			internal WWW _0024hs_get_0024507;

			internal string _0024myString_0024508;

			internal GameControl _0024self__0024509;

			public _0024(GameControl self_)
			{
				_0024self__0024509 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__0024509.remoteSave)
					{
						goto case 1;
					}
					if ((bool)_0024self__0024509.playerData)
					{
						PlayerPrefs.SetString("cloudEmail", _0024self__0024509.cloudEmail);
						_0024self__0024509.menuControl.menu = "cloudcontact";
						_0024self__0024509.redeemMessage = "Contacting the cloud server...";
						_0024get_url_0024505 = "http://ezone.com/cloud/diversion.php";
						_0024form_0024506 = new WWWForm();
						_0024form_0024506.AddField("action", "save");
						_0024form_0024506.AddField("email", _0024self__0024509.cloudEmail);
						_0024form_0024506.AddField("password", _0024self__0024509.cloudPassword);
						_0024form_0024506.AddField("data", _0024self__0024509.playerData.lastSaveData);
						_0024hs_get_0024507 = new WWW(_0024get_url_0024505, _0024form_0024506);
						result = (Yield(2, _0024hs_get_0024507) ? 1 : 0);
						break;
					}
					goto IL_01ab;
				case 2:
					if (!string.IsNullOrEmpty(_0024hs_get_0024507.error))
					{
						_0024self__0024509.redeemMessage = "Sorry, could not contact the cloud server.";
						if (_0024self__0024509.cheatsOn)
						{
							_0024self__0024509.redeemMessage = "Error: " + _0024hs_get_0024507.error;
						}
					}
					else
					{
						_0024myString_0024508 = string.Empty + _0024hs_get_0024507.text;
						_0024self__0024509.redeemMessage = _0024myString_0024508;
					}
					goto IL_01ab;
				case 1:
					{
						result = 0;
						break;
					}
					IL_01ab:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024510;

		public _0024RemoteDataSave_0024504(GameControl self_)
		{
			_0024self__0024510 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__0024510);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024RemoteDataLoad_0024511 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string _0024remoteData_0024512;

			internal string _0024get_url_0024513;

			internal WWW _0024hs_get_0024514;

			internal float _0024remoteVersion_0024515;

			internal string[] _0024tempArray_0024516;

			internal int _0024i_0024517;

			internal string[] _0024tempArray2_0024518;

			internal GameControl _0024self__0024519;

			public _0024(GameControl self_)
			{
				_0024self__0024519 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__0024519.remoteSave)
					{
						goto case 1;
					}
					_0024remoteData_0024512 = null;
					_0024self__0024519.menuControl.menu = "cloudcontact";
					_0024self__0024519.redeemMessage = "Contacting the cloud server...";
					_0024get_url_0024513 = "http://ezone.com/cloud/diversion.php?action=load" + "&password=" + WWW.EscapeURL(_0024self__0024519.cloudPassword) + "&email=" + WWW.EscapeURL(_0024self__0024519.cloudEmail) + "&rnd=" + UnityEngine.Random.Range(0, 100000);
					_0024hs_get_0024514 = new WWW(_0024get_url_0024513);
					result = (Yield(2, _0024hs_get_0024514) ? 1 : 0);
					break;
				case 2:
					if (!string.IsNullOrEmpty(_0024hs_get_0024514.error))
					{
						_0024self__0024519.redeemMessage = "Sorry, could not contact the cloud server.";
						if (_0024self__0024519.cheatsOn)
						{
							_0024self__0024519.redeemMessage = "Error: " + _0024hs_get_0024514.error;
						}
					}
					else
					{
						_0024remoteData_0024512 = string.Empty + _0024hs_get_0024514.text;
						if (string.IsNullOrEmpty(_0024remoteData_0024512))
						{
							_0024self__0024519.loaderror = "\nSorry, there is no new game data to load\n\nPlease try again later";
							_0024self__0024519.menuControl.menu = "gameloaderror";
						}
						else
						{
							_0024remoteVersion_0024515 = 0f;
							_0024tempArray_0024516 = _0024remoteData_0024512.Split(char.Parse("\n"));
							for (_0024i_0024517 = 0; _0024i_0024517 < Extensions.get_length((System.Array)_0024tempArray_0024516) - 1; _0024i_0024517++)
							{
								if (_0024tempArray_0024516[_0024i_0024517].IndexOf("var|version") != -1)
								{
									_0024tempArray2_0024518 = _0024tempArray_0024516[_0024i_0024517].Split(char.Parse("|"));
									if (Extensions.get_length((System.Array)_0024tempArray2_0024518) == 3)
									{
										_0024remoteVersion_0024515 = UnityBuiltins.parseFloat(_0024tempArray2_0024518[2]);
									}
									break;
								}
							}
							if (!(_0024remoteVersion_0024515 <= UnityBuiltins.parseFloat(_0024self__0024519.version)))
							{
								_0024self__0024519.loaderror = "\n\nPlease update to v." + _0024remoteVersion_0024515 + " of this game.";
								_0024self__0024519.menuControl.menu = "gameloaderror";
							}
							else if (_0024remoteVersion_0024515 == 0f)
							{
								_0024self__0024519.redeemMessage = _0024remoteData_0024512;
							}
							else if (_0024remoteData_0024512 == _0024self__0024519.playerData.lastSaveData)
							{
								_0024self__0024519.loaderror = "\nSorry, there is no new game data to load\n\nPlease try again later";
								_0024self__0024519.menuControl.menu = "gameloaderror";
							}
							else
							{
								if ((bool)_0024self__0024519.playerData)
								{
									PlayerPrefs.SetString("cloudEmail", _0024self__0024519.cloudEmail);
									_0024self__0024519.playerData.ReplaceWithRemoteData(_0024remoteData_0024512);
									if (_0024remoteData_0024512.IndexOf("gender|male") != -1)
									{
										_0024self__0024519.gender = "male";
									}
									else
									{
										_0024self__0024519.gender = "female";
									}
									_0024self__0024519.updateOutfit = true;
									_0024self__0024519.StartCoroutine(_0024self__0024519.ChangeScene("Title", true));
									_0024self__0024519.levelHint = "Loading Game Data\n\nThe game is now being reloaded with your remote game data.";
									_0024self__0024519.lastRemoteSaveData = _0024remoteData_0024512;
								}
								YieldDefault(1);
							}
						}
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024520;

		public _0024RemoteDataLoad_0024511(GameControl self_)
		{
			_0024self__0024520 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__0024520);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartAndroidIAB_0024521 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string[] _0024productIdentifiers_0024522;

			internal GameControl _0024self__0024523;

			public _0024(GameControl self_)
			{
				_0024self__0024523 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__0024523.store)
					{
						_0024self__0024523.storeStatus = "disabled";
						goto IL_011f;
					}
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024523.storeStatus = "contacting";
					if (!(_0024self__0024523.platform == "amazon"))
					{
						GoogleIAB.init(_0024self__0024523.key);
						GoogleIABManager.queryInventorySucceededEvent += _0024self__0024523.queryInventorySucceededEvent;
						GoogleIABManager.queryInventoryFailedEvent += _0024self__0024523.queryInventoryFailedEvent;
						GoogleIABManager.purchaseSucceededEvent += _0024self__0024523.purchaseSucceededEvent;
						GoogleIABManager.purchaseFailedEvent += _0024adaptor_0024___0024_MoveNext_0024callable0_00241622_73___0024Action_00240.Adapt(_0024self__0024523.purchaseFailedEvent);
						_0024productIdentifiers_0024522 = _0024self__0024523.storeItems.ToBuiltin(typeof(string)) as string[];
						GoogleIAB.queryInventory(_0024productIdentifiers_0024522);
					}
					goto IL_011f;
				case 1:
					{
						result = 0;
						break;
					}
					IL_011f:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024524;

		public _0024StartAndroidIAB_0024521(GameControl self_)
		{
			_0024self__0024524 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024524);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GetPrize_0024525 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal string[] _0024tempArray_0024526;

			internal string _0024lastHour_0024527;

			internal string _0024currentHour_0024528;

			internal string _0024_0024switch_0024104_0024529;

			internal string _0024hash_0024530;

			internal string _0024get_url_0024531;

			internal WWW _0024hs_get_0024532;

			internal string _0024myString_0024533;

			internal string _0024whichCode_0024534;

			internal GameControl _0024self__0024535;

			public _0024(string whichCode, GameControl self_)
			{
				_0024whichCode_0024534 = whichCode;
				_0024self__0024535 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024535.lastCode = PlayerPrefs.GetString("lastCode", "99");
					_0024tempArray_0024526 = _0024self__0024535.lastCode.Split(char.Parse("|"));
					_0024lastHour_0024527 = _0024tempArray_0024526[0];
					_0024currentHour_0024528 = DateTime.Now.ToString("dd");
					if (_0024lastHour_0024527 != _0024currentHour_0024528)
					{
						_0024self__0024535.lastCode = _0024currentHour_0024528;
						PlayerPrefs.SetString("lastCode", _0024self__0024535.lastCode);
					}
					if (_0024self__0024535.lastCode.IndexOf(_0024whichCode_0024534) != -1)
					{
						_0024self__0024535.redeemMessage = "Sorry, but you've already used that code!";
						_0024self__0024535.menuControl.menu = "redeemerror";
						_0024self__0024535.playerControl.ChangeAnimation("lose", 0.35f);
					}
					else if (_0024whichCode_0024534 == "SANTA")
					{
						_0024self__0024535.santa = true;
						_0024self__0024535.tryingItOn = false;
						_0024self__0024535.StartCoroutine(_0024self__0024535.ActivateItem(_0024self__0024535.activeOutfit));
						_0024self__0024535.redeemMessage = "Santa hats activated!!";
						_0024self__0024535.menuControl.menu = "redeemerror";
						_0024self__0024535.playerControl.ChangeAnimation("win", 0.35f);
					}
					else if (_0024whichCode_0024534 == "FREEGEMS")
					{
						if (PlayerPrefs.GetInt("FREEGEMS", 0) == 0)
						{
							PlayerPrefs.SetInt("FREEGEMS", 1);
							_0024self__0024535.Redeem("gems_500");
						}
						else
						{
							_0024self__0024535.redeemMessage = "Sorry, but you've already used that code!";
							_0024self__0024535.menuControl.menu = "redeemerror";
							_0024self__0024535.playerControl.ChangeAnimation("lose", 0.35f);
						}
					}
                    else if (_0024whichCode_0024534 == "FREEGEMS")
                    {
                        if (PlayerPrefs.GetInt("FREEGEMS", 0) == 0)
                        {
                            PlayerPrefs.SetInt("FREEGEMS", 1);
                            _0024self__0024535.Redeem("gems_500");
                        }
                        else
                        {
                            _0024self__0024535.redeemMessage = "Sorry, but you've already used that code!";
                            _0024self__0024535.menuControl.menu = "redeemerror";
                            _0024self__0024535.playerControl.ChangeAnimation("lose", 0.35f);
                        }
                    }
                    else if (_0024whichCode_0024534 == "TIOB")
                    {
                        _0024self__0024535.Redeem("tokens_1000000");
                        _0024self__0024535.redeemMessage = "tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob tiob";
                        _0024self__0024535.menuControl.menu = "redeemerror";
                        _0024self__0024535.playerControl.ChangeAnimation("win", 0.35f);
                    }
                    else
					{
						if (_0024whichCode_0024534.IndexOf("CLEAR") == -1)
						{
							_0024self__0024535.menuControl.menu = "redeemcheck";
							_0024hash_0024530 = Md5.Md5Sum(_0024whichCode_0024534 + _0024self__0024535.secretKey);
							_0024get_url_0024531 = _0024self__0024535.getPrizeUrl + "&code=" + _0024whichCode_0024534 + "&hash=" + _0024hash_0024530 + "&rnd=" + UnityEngine.Random.Range(0, 100000);
							_0024hs_get_0024532 = new WWW(_0024get_url_0024531);
							result = (Yield(2, _0024hs_get_0024532) ? 1 : 0);
							break;
						}
						_0024_0024switch_0024104_0024529 = _0024whichCode_0024534;
						if (_0024_0024switch_0024104_0024529 == "CLEARONE")
						{
							_0024self__0024535.redeemMessage = "Cleared Scores for World 1";
							_0024self__0024535.playerData.ClearWorld(1);
						}
						else if (_0024_0024switch_0024104_0024529 == "CLEARTWO")
						{
							_0024self__0024535.redeemMessage = "Cleared Scores for World 2";
							_0024self__0024535.playerData.ClearWorld(2);
						}
						else if (_0024_0024switch_0024104_0024529 == "CLEARTHREE")
						{
							_0024self__0024535.redeemMessage = "Cleared Scores for World 3";
							_0024self__0024535.playerData.ClearWorld(3);
						}
						else if (_0024_0024switch_0024104_0024529 == "CLEARFOUR")
						{
							_0024self__0024535.redeemMessage = "Cleared Scores for World 4";
							_0024self__0024535.playerData.ClearWorld(4);
						}
						else if (_0024_0024switch_0024104_0024529 == "CLEARBONUS")
						{
							_0024self__0024535.redeemMessage = "Cleared Scores for Bonus World";
							_0024self__0024535.playerData.ClearWorld(100);
						}
						else
						{
							_0024self__0024535.redeemMessage = "Sorry, but that code didn't work!";
						}
						_0024self__0024535.menuControl.menu = "redeemed";
					}
					goto case 1;
				case 2:
					if (!string.IsNullOrEmpty(_0024hs_get_0024532.error))
					{
						_0024self__0024535.redeemMessage = "Sorry, could not contact the prize server.";
						if (_0024self__0024535.cheatsOn)
						{
							_0024self__0024535.redeemMessage = "Error: " + _0024hs_get_0024532.error;
						}
						_0024self__0024535.menuControl.menu = "redeemerror";
					}
					else
					{
						_0024myString_0024533 = string.Empty + _0024hs_get_0024532.text;
						if (Extensions.get_length(_0024myString_0024533) > 40)
						{
							_0024self__0024535.redeemMessage = "Sorry, but that code didn't work!";
							_0024self__0024535.menuControl.menu = "redeemerror";
							_0024self__0024535.playerControl.ChangeAnimation("lose", 0.35f);
						}
						else
						{
							_0024self__0024535.lastCode += "|" + _0024whichCode_0024534;
							PlayerPrefs.SetString("lastCode", _0024self__0024535.lastCode);
							_0024self__0024535.Redeem(_0024myString_0024533);
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

		internal string _0024whichCode_0024536;

		internal GameControl _0024self__0024537;

		public _0024GetPrize_0024525(string whichCode, GameControl self_)
		{
			_0024whichCode_0024536 = whichCode;
			_0024self__0024537 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024whichCode_0024536, _0024self__0024537);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResumePauseTime_0024538 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameControl _0024self__0024539;

			public _0024(GameControl self_)
			{
				_0024self__0024539 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024539.lastsavetime = Time.realtimeSinceStartup - _0024self__0024539.pauseElapsedTime;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024540;

		public _0024ResumePauseTime_0024538(GameControl self_)
		{
			_0024self__0024540 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024540);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowInterstitial_0024541 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameControl _0024self__0024542;

			public _0024(GameControl self_)
			{
				_0024self__0024542 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024542.showLinks)
					{
						_0024self__0024542.gameObject.SendMessage("ShowPromo", SendMessageOptions.DontRequireReceiver);
					}
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__0024542.promoShowing)
					{
						_0024self__0024542.chartTime = Time.realtimeSinceStartup;
						_0024self__0024542.promoShowing = false;
					}
					else if (_0024self__0024542.adsOn != 0)
					{
						eAds.InterShow();
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

		internal GameControl _0024self__0024543;

		public _0024ShowInterstitial_0024541(GameControl self_)
		{
			_0024self__0024543 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024543);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowSaveMe_0024544 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024delayTime_0024545;

			internal GameControl _0024self__0024546;

			public _0024(float delayTime, GameControl self_)
			{
				_0024delayTime_0024545 = delayTime;
				_0024self__0024546 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(_0024delayTime_0024545 <= 0f))
					{
						result = (Yield(2, new WaitForSeconds(_0024delayTime_0024545)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024self__0024546.menuControl.menu = "saveme";
					_0024self__0024546.playerControl.myAction = "die";
					_0024self__0024546.StartCoroutine(_0024self__0024546.PauseGame(true));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024delayTime_0024547;

		internal GameControl _0024self__0024548;

		public _0024ShowSaveMe_0024544(float delayTime, GameControl self_)
		{
			_0024delayTime_0024547 = delayTime;
			_0024self__0024548 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024delayTime_0024547, _0024self__0024548);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PauseGame_0024549 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal bool _0024pauseNow_0024550;

			internal GameControl _0024self__0024551;

			public _0024(bool pauseNow, GameControl self_)
			{
				_0024pauseNow_0024550 = pauseNow;
				_0024self__0024551 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024551.paused = _0024pauseNow_0024550;
					if (_0024self__0024551.paused)
					{
						Time.timeScale = 0f;
						AudioListener.volume = 0f;
						_0024self__0024551.disableInput = true;
						_0024self__0024551.RecordingPause();
						Screen.sleepTimeout = 60;
						goto IL_00c2;
					}
					Time.timeScale = 1f;
					if (_0024self__0024551.soundOn > 0)
					{
						_0024self__0024551.AdjustSound();
					}
					_0024self__0024551.RecordingResume();
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024551.disableInput = false;
					Screen.sleepTimeout = -1;
					goto IL_00c2;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00c2:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024pauseNow_0024552;

		internal GameControl _0024self__0024553;

		public _0024PauseGame_0024549(bool pauseNow, GameControl self_)
		{
			_0024pauseNow_0024552 = pauseNow;
			_0024self__0024553 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024pauseNow_0024552, _0024self__0024553);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeScene_0024554 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024missionGems_0024555;

			internal string _0024whichScene_0024556;

			internal bool _0024fadeOutFirst_0024557;

			internal GameControl _0024self__0024558;

			public _0024(string whichScene, bool fadeOutFirst, GameControl self_)
			{
				_0024whichScene_0024556 = whichScene;
				_0024fadeOutFirst_0024557 = fadeOutFirst;
				_0024self__0024558 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024558.StartCoroutine(_0024self__0024558.PauseGame(false));
					if (_0024self__0024558.isMiniGame)
					{
						_0024self__0024558.AdjustGems(_0024self__0024558.missionGem);
						_0024self__0024558.Save("gems");
					}
					_0024self__0024558.inputVector = Vector3.zero;
					_0024missionGems_0024555 = 0;
					_0024self__0024558.isMiniGame = false;
					_0024self__0024558.cameraType = "foot";
					_0024self__0024558.UpdateHints();
					if (_0024whichScene_0024556 == "GemFields")
					{
						if (eInput.controlType == "ouya")
						{
							_0024self__0024558.levelHint = "Hover World Preview!\n\n" + "Left joystick to steer,\n'O' to go, 'Y' to swap to on foot.";
						}
						else if (eInput.controlType != "touch")
						{
							_0024self__0024558.levelHint = "Hover World Preview!\n\n" + "Left joystick to steer,\n'A' to go, 'Y' to swap to on foot.";
						}
						else
						{
							_0024self__0024558.levelHint = "Hover World Preview!\n\n" + "Tilt to steer,\ntouch lower screen to go.";
						}
						_0024self__0024558.blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/AtlasDefault"));
						_0024self__0024558.blackoutControl.ChangeColor("204,206,206,255");
					}
					if (_0024whichScene_0024556 == "BonusPool")
					{
						if (eInput.controlType == "ouya")
						{
							_0024self__0024558.levelHint = "Mega Bonus Area!!\n\n" + "Left joystick to steer.\nUse the portal or 'A' to exit.";
						}
						else if (eInput.controlType != "touch")
						{
							_0024self__0024558.levelHint = "Mega Bonus Area!!\n\n" + "Left joystick to steer.\nUse the portal or 'B' to exit.";
						}
						else
						{
							_0024self__0024558.levelHint = "Mega Bonus Area!!\n\n" + "Tilt to steer. Collect everything! Use the portal or pause to exit.";
						}
						_0024self__0024558.blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/AtlasDefault"));
						_0024self__0024558.blackoutControl.ChangeColor("204,206,206,255");
					}
					if (_0024self__0024558.missionMilestone > 0)
					{
						_0024self__0024558.levelHint = "Intermission\n\n" + "Please have a short break while we get the next section ready...";
					}
					_0024self__0024558.gameMenu = "hint";
					if (_0024whichScene_0024556 == "Title")
					{
						_0024self__0024558.missionOver = false;
						_0024self__0024558.gameMenu = "title";
						_0024self__0024558.levelHint = "Loading Main Menu\n\n" + "Are we having fun yet?!!";
						_0024self__0024558.missionMilestone = 0;
						Screen.sleepTimeout = 60;
					}
					else
					{
						Screen.sleepTimeout = -1;
					}
					if (_0024whichScene_0024556 == "Main")
					{
						_0024whichScene_0024556 = _0024self__0024558.gameScene;
					}
					_0024self__0024558.missionName = _0024whichScene_0024556;
					_0024self__0024558.fadeControl.enabled = true;
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024558.cameraTarget = null;
					_0024self__0024558.fadeControl.LoadScene(_0024whichScene_0024556, _0024fadeOutFirst_0024557);
					_0024self__0024558.inGame = false;
					_0024self__0024558.StartCoroutine(_0024self__0024558.ShowInterstitial());
					_0024self__0024558.BannerAdHide();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichScene_0024559;

		internal bool _0024fadeOutFirst_0024560;

		internal GameControl _0024self__0024561;

		public _0024ChangeScene_0024554(string whichScene, bool fadeOutFirst, GameControl self_)
		{
			_0024whichScene_0024559 = whichScene;
			_0024fadeOutFirst_0024560 = fadeOutFirst;
			_0024self__0024561 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichScene_0024559, _0024fadeOutFirst_0024560, _0024self__0024561);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024EndMission_0024562 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024theLevel_0024563;

			internal string _0024whichMenu_0024564;

			internal GameControl _0024self__0024565;

			public _0024(string whichMenu, GameControl self_)
			{
				_0024whichMenu_0024564 = whichMenu;
				_0024self__0024565 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024565.watchCamera = true;
					if (_0024self__0024565.worldID == 100)
					{
						_0024self__0024565.tempString = "Bonus World - " + _0024self__0024565.missionLevel;
					}
					else
					{
						_0024self__0024565.tempString = "World " + _0024self__0024565.worldID + " - " + _0024self__0024565.missionLevel;
					}
					if (_0024self__0024565.missionExited)
					{
						_0024self__0024565.inGame = false;
						_0024self__0024565.shiftCameraLeft = true;
						_0024self__0024565.missionOver = true;
						_0024self__0024565.menuControl.menu = "chooseLevel";
					}
					else
					{
						if (!_0024self__0024565.missionWin || !_0024self__0024565.milestoneReached)
						{
							_0024self__0024565.missionMilestone = 0;
							_0024self__0024565.missionEndless = false;
							_0024self__0024565.shiftCameraLeft = true;
							_0024self__0024565.missionOver = true;
							_0024self__0024565.missionHealth = 3;
							_0024self__0024565.missionMessage = string.Empty;
							_0024self__0024565.menuControl.menu = _0024whichMenu_0024564;
							_0024self__0024565.menuControl.backMenu = _0024whichMenu_0024564;
							_0024self__0024565.inGame = false;
							_0024self__0024565.UpdateBanner(true);
							_0024self__0024565.GetDailyInfo();
							_0024self__0024565.levelAttempts[_0024self__0024565.missionLevel - 1] = _0024self__0024565.levelAttempts[_0024self__0024565.missionLevel - 1] + 1;
							_0024self__0024565.missionGemEnd = _0024self__0024565.missionGem;
							_0024theLevel_0024563 = _0024self__0024565.worldID + "_" + _0024self__0024565.missionLevel;
							_0024self__0024565.missionDouble = string.Empty;
							if (_0024self__0024565.missionWin)
							{
								_0024self__0024565.levelUnlocked[_0024self__0024565.missionLevel - 1] = 1;
								if (Extensions.get_length((System.Array)_0024self__0024565.levelUnlocked) > _0024self__0024565.missionLevel && _0024self__0024565.worldID != 100)
								{
									_0024self__0024565.levelUnlocked[_0024self__0024565.missionLevel] = 1;
									_0024self__0024565.playerData.UnlockMission(_0024self__0024565.worldID, _0024self__0024565.missionLevel + 1);
								}
								if (_0024self__0024565.missionStar > _0024self__0024565.levelStars[_0024self__0024565.missionLevel - 1])
								{
									_0024self__0024565.levelStars[_0024self__0024565.missionLevel - 1] = _0024self__0024565.missionStar;
								}
								if (_0024self__0024565.missionGem >= 50 && _0024self__0024565.worldID != 100)
								{
									_0024self__0024565.missionSummary[0] = true;
									_0024self__0024565.missionGem += 25;
								}
								if (_0024self__0024565.missionStar >= 1)
								{
									_0024self__0024565.missionGem += 5;
								}
								if (_0024self__0024565.missionStar >= 2)
								{
									_0024self__0024565.missionGem += 5;
								}
								if (_0024self__0024565.missionStar >= 3)
								{
									_0024self__0024565.missionSummary[1] = true;
									_0024self__0024565.missionGem += 15;
								}
								if (_0024self__0024565.activeOutfit == _0024self__0024565.doubleOutfit || _0024self__0024565.dailyLevel == _0024theLevel_0024563)
								{
									if (_0024self__0024565.activeOutfit == _0024self__0024565.doubleOutfit)
									{
										_0024self__0024565.missionDouble = "character";
									}
									else
									{
										_0024self__0024565.missionDouble = "level";
									}
									_0024self__0024565.missionGem *= 2;
								}
								if (_0024self__0024565.missionGem > _0024self__0024565.levelGems[_0024self__0024565.missionLevel - 1])
								{
									if (_0024self__0024565.levelGems[_0024self__0024565.missionLevel - 1] != 0)
									{
										_0024self__0024565.missionSummary[2] = true;
									}
									_0024self__0024565.levelGems[_0024self__0024565.missionLevel - 1] = _0024self__0024565.missionGem;
								}
								_0024self__0024565.levelWins[_0024self__0024565.missionLevel - 1] = _0024self__0024565.levelWins[_0024self__0024565.missionLevel - 1] + 1;
								_0024self__0024565.AdjustGems(_0024self__0024565.missionGem);
								_0024self__0024565.Save("level");
								_0024self__0024565.CheckForUnlock();
								_0024self__0024565.menuControl.menu = "missionEnd";
								goto IL_0757;
							}
							if (_0024self__0024565.activeOutfit == _0024self__0024565.doubleOutfit || _0024self__0024565.dailyLevel == _0024theLevel_0024563)
							{
								if (_0024self__0024565.activeOutfit == _0024self__0024565.doubleOutfit)
								{
									_0024self__0024565.missionDouble = "character";
								}
								else
								{
									_0024self__0024565.missionDouble = "level";
								}
								_0024self__0024565.missionGem *= 2;
							}
							if (_0024self__0024565.missionGem > _0024self__0024565.levelGems[_0024self__0024565.missionLevel - 1])
							{
								_0024self__0024565.levelGems[_0024self__0024565.missionLevel - 1] = _0024self__0024565.missionGem;
							}
							_0024self__0024565.AdjustGems(_0024self__0024565.missionGem);
							result = (Yield(2, new WaitForSeconds(0.7f)) ? 1 : 0);
							break;
						}
						_0024self__0024565.ShowToken();
						_0024self__0024565.menuControl.menu = "milestone";
						_0024self__0024565.menuControl.backMenu = "milestone";
						_0024self__0024565.missionMilestone = _0024self__0024565.missionGem;
						_0024self__0024565.missionOver = true;
						_0024self__0024565.saveBoost = _0024self__0024565.playerControl.boost;
					}
					goto case 1;
				case 2:
					_0024self__0024565.playerControl.ChangeAnimation("lose", 0.35f);
					_0024self__0024565.Save("level");
					goto IL_0757;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0757:
					_0024self__0024565.AdjustDailyXP(_0024self__0024565.missionGem);
					_0024self__0024565.SaveScore();
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichMenu_0024566;

		internal GameControl _0024self__0024567;

		public _0024EndMission_0024562(string whichMenu, GameControl self_)
		{
			_0024whichMenu_0024566 = whichMenu;
			_0024self__0024567 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichMenu_0024566, _0024self__0024567);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024WarpCamera_0024568 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameControl _0024self__0024569;

			public _0024(GameControl self_)
			{
				_0024self__0024569 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					Time.timeScale = 0.2f;
					_0024self__0024569.warpCamera = true;
					result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
					break;
				case 2:
					Time.timeScale = 1f;
					_0024self__0024569.warpCamera = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameControl _0024self__0024570;

		public _0024WarpCamera_0024568(GameControl self_)
		{
			_0024self__0024570 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024570);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ActivateItem_0024571 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024tempID_0024572;

			internal string[] _0024tempArray_0024573;

			internal string _0024whichType_0024574;

			internal string _0024whichName_0024575;

			internal int _0024i_0024576;

			internal string _0024whichFilename_0024577;

			internal GameControl _0024self__0024578;

			public _0024(string whichFilename, GameControl self_)
			{
				_0024whichFilename_0024577 = whichFilename;
				_0024self__0024578 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024578.updateOutfit = true;
					_0024tempID_0024572 = default(int);
					_0024tempArray_0024573 = _0024whichFilename_0024577.Split(char.Parse("_"));
					_0024whichType_0024574 = _0024tempArray_0024573[0];
					_0024whichName_0024575 = string.Empty;
					if (_0024whichType_0024574 == "outfit")
					{
						_0024self__0024578.playerData.ActivateOutfit(_0024whichFilename_0024577);
						_0024whichName_0024575 = _0024tempArray_0024573[1];
					}
					else
					{
						_0024tempArray_0024573 = (string[])new UnityScript.Lang.Array().ToBuiltin(typeof(string));
						for (_0024i_0024576 = 0; _0024i_0024576 < _0024self__0024578.playerData.itemID.length; _0024i_0024576++)
						{
							if (RuntimeServices.EqualityOperator(_0024self__0024578.playerData.itemType[_0024i_0024576], _0024whichType_0024574))
							{
								if (RuntimeServices.EqualityOperator(_0024self__0024578.playerData.itemID[_0024i_0024576], _0024whichFilename_0024577))
								{
									_0024self__0024578.playerData.itemActive[_0024i_0024576] = 1;
								}
								else
								{
									_0024self__0024578.playerData.itemActive[_0024i_0024576] = 0;
								}
							}
						}
					}
					_0024self__0024578.playerData.UpdateCharacterOutfit(_0024whichType_0024574);
					_0024self__0024578.playerControl.UpdateMainPlayer();
					_0024self__0024578.playerControl.ChangeAnimation("newitem", 0.35f);
					if (!_0024self__0024578.tryingItOn)
					{
						if (_0024whichType_0024574 == "outfit")
						{
							_0024self__0024578.AddAchievement(_0024whichName_0024575);
							_0024self__0024578.PlaySound((AudioClip)Resources.Load("Sounds/boing", typeof(AudioClip)));
						}
						_0024tempID_0024572 = _0024self__0024578.FindItemSlot(_0024whichFilename_0024577);
						_0024self__0024578.unlockedLevel = _0024self__0024578.itemUnlocksLevel[_0024tempID_0024572];
						if (!(_0024self__0024578.unlockedLevel == "none") && !string.IsNullOrEmpty(_0024self__0024578.unlockedLevel))
						{
							_0024tempArray_0024573 = _0024self__0024578.unlockedLevel.Split(char.Parse("_"));
							_0024self__0024578.newWorldID = UnityBuiltins.parseInt(_0024tempArray_0024573[0]);
							_0024self__0024578.newLevelID = UnityBuiltins.parseInt(_0024tempArray_0024573[1]);
							if (_0024self__0024578.playerData.UnlockMission(UnityBuiltins.parseInt(_0024tempArray_0024573[0]), UnityBuiltins.parseInt(_0024tempArray_0024573[1])))
							{
								_0024self__0024578.PlaySound((AudioClip)Resources.Load("Sounds/unlockitem", typeof(AudioClip)));
								if (_0024self__0024578.menuControl.menu == "characters")
								{
									_0024self__0024578.menuControl.menu = "unlockedLevel";
								}
								else
								{
									_0024self__0024578.menuControl.menu = "unlockedItem";
								}
								result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
								break;
							}
						}
						goto case 2;
					}
					goto IL_03bd;
				case 2:
					_0024self__0024578.Save("items");
					goto IL_03bd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_03bd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichFilename_0024579;

		internal GameControl _0024self__0024580;

		public _0024ActivateItem_0024571(string whichFilename, GameControl self_)
		{
			_0024whichFilename_0024579 = whichFilename;
			_0024self__0024580 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichFilename_0024579, _0024self__0024580);
		}
	}

	public string specialOutfit;

	public bool createItemLists;

	public string appName;

	public string version;

	public string platform;

	public string specialBuild;

	public bool device2;

	public bool videoReplay;

	public bool forKids;

	[Header("Menus")]
	public Color[] menuColors;

	public bool demo;

	public bool cheatsOn;

	public bool store;

	public float tokenPercentage;

	[NonSerialized]
	public bool redeem;

	public bool remoteSave;

	public float farClip;

	public bool forceBigHead;

	public int storeApproved;

	public int maxWorlds;

	public string globalScores;

	public string loginState;

	public GUISkin gameSkin;

	public Transform AudioOneShotPrefab;

	public Material shadowMaterial;

	public Material garbotMaterial;

	public string playerName;

	public string gender;

	public string scene;

	public float ticks;

	public float lastsavetime;

	public int elapsedtime;

	public string lastsave;

	public string cameraMode;

	public string controltype;

	public string cameraType;

	public Transform cameraTarget;

	public bool touchingControls;

	public bool paused;

	public bool jumpButton;

	public bool[] touchButton;

	private string docPath;

	private string filePath;

	public UnityScript.Lang.Array itemType;

	public UnityScript.Lang.Array itemID;

	public UnityScript.Lang.Array itemActive;

	public UnityScript.Lang.Array itemQuantity;

	public string[] shopList;

	public string[] categories;

	public string outfit;

	public string summary;

	public float maxTurningForce;

	public float maxForce;

	public string[] itemName;

	public string[] itemData;

	public Vector3 inputVector;

	public bool newUser;

	public PlayerData playerData;

	public PlayerControl playerControl;

	public bool scrollMenu;

	public bool inair;

	public float targetOffsetAngle;

	private FadeInOut fadeControl;

	private MenuControl menuControl;

	private GameObject playerInput;

	public string gameMenu;

	public string missionName;

	public int missionWins;

	public int missionGem;

	public int missionLevel;

	public int missionBest;

	public string[] missionPrizes;

	public bool[] missionSummary;

	public string missionMessage;

	public string missionDouble;

	public int worldID;

	public bool[] worldLocked;

	public int[] worldScores;

	public int[] worldStars;

	public int[] worldLevels;

	public bool missionStarted;

	public bool missionOver;

	public int missionStar;

	public bool missionWin;

	public int missionHealth;

	public Vector3 missionStartPos;

	private Quaternion missionStartRot;

	public string missionPrize;

	public bool missionAborted;

	public int missionGemEnd;

	public bool missionCharacterBonus;

	public float cameraShake;

	public float boost;

	public bool updateOutfit;

	public bool missionInitMissionControl;

	public int missionCount;

	public bool inverted;

	private int invertCounter;

	private string hintTracker;

	public bool attemptLogin;

	public string[] missionNames;

	public bool firstTime;

	private float pauseElapsedTime;

	private float scoreTime;

	public int[] levelStars;

	public int[] levelGems;

	public int[] levelUnlocked;

	public int[] levelAttempts;

	public int[] levelWins;

	public string levelHint;

	public string lastItemPurchased;

	public string outfitNew;

	private TextAsset tempAsset;

	private string tempString;

	private bool boardsOff;

	public bool disableInput;

	public string[] missionShop;

	public int reviewItemID;

	public string reviewItemFilename;

	public int reviewItemCost;

	public string reviewItemName;

	public string reviewItemCategory;

	public string reviewItemDesc;

	public bool tryingItOn;

	public bool warpCamera;

	public bool showStar;

	public int[] itemCost;

	public int[] itemRarity;

	public bool[] itemOwned;

	public bool[] itemRecent;

	public string[] itemUnlocksLevel;

	public string[] itemAwardedFor;

	public string[] itemAwardedDesc;

	public string unlockedItem;

	public string unlockedLevel;

	public string unlockedReason;

	public int newLevelID;

	public int newWorldID;

	public bool shiftCameraLeft;

	public bool bonusDone;

	private BlackoutControl blackoutControl;

	public Vector3 cameraOffset;

	public string appID;

	public int musicOn;

	public int soundOn;

	public int shadowsOn;

	public bool watchCamera;

	public string activeOutfit;

	public string doubleOutfit;

	public bool hintCollected;

	public int skipsUsed;

	public int adsOn;

	private bool adInverted;

	private bool adShowing;

	public bool lite;

	public float touchScale;

	public bool showTotalGems;

	public string redeemMessage;

	private string secretKey;

	private string getPrizeUrl;

	public UnityScript.Lang.Array storeItems;

	public UnityScript.Lang.Array storePrices;

	public UnityScript.Lang.Array storeTitles;

	private bool houseAd;

	private string lastCode;

	private string iCadeStateLast;

	public bool iCadeActive;

	public string awardMegaPrize;

	public int joyTouchID;

	private string gameCenterID;

	public string loaderror;

	private bool confirmPurchase;

	public Texture2D backdropTexture;

	public string defaultAtlas;

	public string defaultCharacter;

	private bool isDaily;

	public string buildTarget;

	private string lastRemoteSaveData;

	public string defaultAssets;

	public string cloudEmail;

	public string cloudPassword;

	public bool inGame;

	public int dailyXP;

	public int lastXP;

	public bool canEarnDaily;

	private string dailyOutfit;

	private string dailyLevel;

	public float headsize;

	public string gameScene;

	public bool isMiniGame;

	private string admobID;

	private Rect adRect;

	private Rect removeadRect;

	private int preroll;

	public bool iads;

	public string buildVersion;

	public UnityScript.Lang.Array defaultAssetArray;

	private string mopubID;

	public bool garbot;

	public int quality;

	public int maxQuality;

	public string gcPrefix;

	public bool videoReplayAvailable;

	private bool videoRecording;

	public float saveMeY;

	public int tokens;

	public int savePrice;

	public Vector3 goalPosition;

	public UnityScript.Lang.Array unlockedItems;

	public string[] recentOutfits;

	public int forceQuality;

	public bool showLinks;

	public int missionMilestone;

	private int bonusInterval;

	public bool missionEndless;

	public bool milestoneReached;

	private float saveBoost;

	private string CBAppIDAndroid;

	private string CBAppSigAndroid;

	private int nativeXIDAndroid;

	private string nativeXapk;

	private string CBAppIDIOS;

	private string CBAppSigIOS;

	public RenderingPath defaultRenderingPath;

	public string devicemodel;

	public bool hoverLevels;

	public string joystickName;

	private float joystickTimer;

	private string chartboostScene;

	public bool earlyAdopter;

	private bool showLeaderboardAfterLogin;

	private bool missionExited;

	private string adMobIDiOS;

	private string adMobIDAndroid;

	private string vungleios;

	private string vungleandroid;

	public bool santa;

	private int menuColorID;

	private bool showSpecial;

	public bool awardSpecial;

	private string key;

	private System.Collections.Generic.List<GoogleSkuInfo> _products;

	public string[] ezoneValidProducts;

	public string[] ezonePrice;

	public string[] ezoneTitle;

	public string[] ezoneDescription;

	public string storeStatus;

	private int productCheckCount;

	private System.Collections.Generic.List<GPGAchievementMetadata> _achievements;

	private bool toggleBoard;

	private bool promoShowing;

	private float chartTime;

	public GameControl()
	{
		specialOutfit = "yearofmonkey";
		createItemLists = true;
		appName = "HoverWorld";
		version = "1.0";
		platform = "apple";
		tokenPercentage = 2f;
		remoteSave = true;
		farClip = 400f;
		storeApproved = 1;
		maxWorlds = 4;
		globalScores = string.Empty;
		loginState = "none";
		playerName = string.Empty;
		gender = "female";
		scene = "Main";
		lastsave = "None";
		cameraMode = "Normal";
		controltype = "point";
		cameraType = "hover";
		docPath = string.Empty;
		filePath = string.Empty;
		newUser = true;
		gameMenu = "home";
		missionName = string.Empty;
		missionPrizes = new string[3]
		{
			string.Empty,
			string.Empty,
			string.Empty
		};
		missionSummary = new bool[3];
		missionMessage = string.Empty;
		missionDouble = string.Empty;
		worldID = 1;
		missionOver = true;
		missionHealth = 3;
		updateOutfit = true;
		invertCounter = -100;
		hintTracker = string.Empty;
		attemptLogin = true;
		lastItemPurchased = string.Empty;
		outfitNew = string.Empty;
		tempString = string.Empty;
		unlockedItem = "none";
		unlockedLevel = "none";
		unlockedReason = string.Empty;
		newLevelID = -1;
		newWorldID = -1;
		cameraOffset = Vector3.zero;
		appID = "391033290";
		musicOn = 1;
		soundOn = 1;
		shadowsOn = 1;
		watchCamera = true;
		activeOutfit = "none";
		doubleOutfit = "none";
		adsOn = 1;
		touchScale = 1f;
		redeemMessage = string.Empty;
		secretKey = "AK73JDHSY239G48GXN";
		getPrizeUrl = "http://www.ezone.com/iphone/scores/diversion.php?action=get&version=1";
		houseAd = true;
		lastCode = "none";
		iCadeStateLast = string.Empty;
		awardMegaPrize = string.Empty;
		joyTouchID = -1;
		gameCenterID = string.Empty;
		loaderror = string.Empty;
		confirmPurchase = true;
		defaultAtlas = "AtlasDefault";
		defaultCharacter = "default";
		buildTarget = "iPhone";
		lastRemoteSaveData = string.Empty;
		cloudEmail = string.Empty;
		cloudPassword = string.Empty;
		canEarnDaily = true;
		dailyOutfit = string.Empty;
		dailyLevel = string.Empty;
		headsize = 1f;
		gameScene = "Diversion";
		isMiniGame = true;
		admobID = string.Empty;
		adRect = new Rect(0f, 0f, 640f, 100f);
		removeadRect = new Rect(650f, 0f, 100f, 100f);
		buildVersion = string.Empty;
		mopubID = string.Empty;
		garbot = true;
		quality = 1;
		maxQuality = 2;
		gcPrefix = string.Empty;
		tokens = 2;
		savePrice = 1;
		forceQuality = -1;
		showLinks = true;
		bonusInterval = 10;
		CBAppIDAndroid = string.Empty;
		CBAppSigAndroid = string.Empty;
		nativeXapk = string.Empty;
		CBAppIDIOS = string.Empty;
		CBAppSigIOS = string.Empty;
		defaultRenderingPath = RenderingPath.VertexLit;
		devicemodel = string.Empty;
		hoverLevels = true;
		joystickName = string.Empty;
		chartboostScene = string.Empty;
		adMobIDiOS = string.Empty;
		adMobIDAndroid = string.Empty;
		vungleios = string.Empty;
		vungleandroid = string.Empty;
		key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArfb2ZsMqfYiMADbkWT2v+W8e8Z7wMNp7uDBGnoXtoRuPjYvYSGzvJVl6gZH/zobLhAQ9NUdSJnwWEX1YxApW59tYtC0pJKWn7GWLA+lYKNCO+U4NGtK038DRUfUngOmEyS4VUFLOB/tP4q5GICz7iUnxzKZjrFpBUg7w8LnomsB9ZB9xOPh8HIjj1+IqzDEU/hAkiNPdPe/BEEEuGQ1ckN++k8hPwdo4H9Ehb0qLzAnlOcvBzmfT0KUu/KooCSLxYEvKrxqhwXT5remNaasFvWx5rGDAoAOY7TaFZrObC9gPJXXgTxTipXj0TxDbz7qUgDDDqgisoPtNSkFpOvp4LwIDAQAB";
		storeStatus = "none";
	}

	public virtual void MenuColor(int howMuch)
	{
		menuColorID += howMuch;
		if (menuColorID >= menuColors.Length)
		{
			menuColorID = 0;
		}
		PlayerPrefs.SetInt("menuColorID", menuColorID);
		menuControl.menuColor = menuColors[menuColorID];
	}

	public virtual Color GetColor()
	{
		return menuColors[menuColorID];
	}

	public virtual bool SpecialShow()
	{
		bool result = false;
		if (specialOutfit == string.Empty)
		{
			result = showSpecial;
		}
		else if ("outfit_" + specialOutfit != activeOutfit)
		{
			result = true;
		}
		return result;
	}

	public virtual void SpecialActivate()
	{
		if (specialOutfit != string.Empty)
		{
			Redeem("outfit_" + specialOutfit);
		}
		else
		{
			UnlockAppOfTheDay();
		}
	}

	public virtual void CheckAppOfTheDay()
	{
		int num = 0;
		showSpecial = false;
		awardSpecial = false;
		DateTime now = DateTime.Now;
		Debug.Log("Check AppOfTheDay");
		DateTime value = new DateTime(2016, 3, 2, 6, 0, 0);
		DateTime value2 = new DateTime(2016, 3, 11, 18, 0, 0);
		if (now.CompareTo(value) >= 0 && now.CompareTo(value2) < 0)
		{
			if (PlayerPrefs.GetInt("appOfTheDayUnlocked3", 0) == 0)
			{
				showSpecial = true;
			}
			else
			{
				MonoBehaviour.print("App of the Day already unlocked");
			}
		}
	}

	public virtual void UnlockAppOfTheDay()
	{
		MonoBehaviour.print("App of the Day Unlocked");
		PlayerPrefs.SetInt("appOfTheDayUnlocked3", 1);
		playerControl.ChangeAnimation("win", 0.35f);
		PlaySound((AudioClip)Resources.Load("Sounds/unlockitem", typeof(AudioClip)));
		tryingItOn = false;
		BuyItem("outfit_coolshirt", false);
		BuyItem("outfit_clean", false);
		BuyItem("outfit_bluey", false);
		BuyItem("outfit_blue", false);
		BuyItem("outfit_orangemartian", false);
		BuyItem("outfit_cupcake", false);
		BuyItem("outfit_moggie", false);
		BuyItem("outfit_pig", false);
		BuyItem("outfit_dino", false);
		playerData.UnlockMission(2, 1);
		playerData.UnlockMission(3, 1);
		playerData.UnlockMission(4, 1);
		playerData.UnlockMission(5, 1);
		playerData.UnlockMission(6, 1);
		playerData.UnlockMission(7, 1);
		playerData.UnlockMission(100, 1);
		AdjustGems(1000);
		tokens += 10;
		Save("level");
		awardSpecial = true;
		Redeem("outfit_treefrog");
	}

	public virtual void InitializeAppData()
	{
		tempAsset = (TextAsset)Resources.Load(appName + "/AppData", typeof(TextAsset));
		if (!tempAsset)
		{
			return;
		}
		tempString = tempAsset.text;
		string[] array = tempString.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "var")
			{
				if (array3[1] == "defaultAssets" && Extensions.get_length((System.Array)array3) > 6)
				{
					defaultAssets = array3[2] + "|" + array3[3] + "|" + array3[4] + "|" + array3[5] + "|" + array3[6];
				}
				else
				{
					ConvertVar(array3[1], array3[2]);
				}
			}
		}
		devicemodel = SystemInfo.deviceModel.ToLower();
		globalScores = "google";
		if (devicemodel.IndexOf("lg google tv") != -1)
		{
			devicemodel = "lgtv";
			adsOn = 0;
			CBAppIDAndroid = string.Empty;
			nativeXIDAndroid = 0;
			showLinks = true;
			forceQuality = 1;
			remoteSave = true;
			redeem = true;
			hoverLevels = false;
		}
		else if (devicemodel.IndexOf("hkc p774a") != -1)
		{
			adsOn = 1;
			devicemodel = "clicknkids";
			store = false;
			nativeXIDAndroid = 0;
			showLinks = false;
			forceQuality = 1;
			remoteSave = false;
			redeem = true;
			globalScores = string.Empty;
		}
		else if (devicemodel.IndexOf("amazon") != -1)
		{
			devicemodel = "amazon";
			store = false;
			showLinks = true;
			remoteSave = true;
			redeem = true;
			hoverLevels = true;
		}
		else if (devicemodel.IndexOf("nexus 7") != -1)
		{
			devicemodel = "nexus7";
			store = true;
			showLinks = true;
			remoteSave = true;
			redeem = true;
			hoverLevels = true;
		}
		else if (devicemodel.IndexOf("gamestick") != -1)
		{
			devicemodel = "gamestick";
			adsOn = 0;
			CBAppIDAndroid = string.Empty;
			store = false;
			nativeXIDAndroid = 0;
			showLinks = false;
			forceQuality = 1;
			remoteSave = false;
			redeem = false;
			hoverLevels = true;
			globalScores = string.Empty;
		}
		else if (devicemodel.IndexOf("ouya") != -1)
		{
			devicemodel = "ouya";
			adsOn = 0;
			CBAppIDAndroid = string.Empty;
			store = false;
			nativeXIDAndroid = 0;
			showLinks = false;
			forceQuality = 1;
			remoteSave = false;
			redeem = true;
			hoverLevels = true;
			globalScores = string.Empty;
		}
		else if (devicemodel.IndexOf("ios") != -1)
		{
			devicemodel = "ios";
			adsOn = 1;
			showLinks = true;
			remoteSave = true;
			redeem = true;
			hoverLevels = true;
			globalScores = "gameCenter";
			if (forKids)
			{
				adsOn = 0;
				store = false;
				showLinks = false;
			}
		}
		else
		{
			devicemodel = "google";
			globalScores = "google";
			adsOn = 1;
			if (specialBuild == "onhandsoftware")
			{
				devicemodel = "onhandsoftware";
				adsOn = 0;
			}
			if (specialBuild == "playpass")
			{
				devicemodel = "playpass";
				adsOn = 0;
				nativeXIDAndroid = 0;
			}
			if (forKids)
			{
				adsOn = 0;
				store = false;
				showLinks = false;
			}
		}
		joystickName = eInput.controlType;
		if (platform == "amazon")
		{
			adsOn = 0;
			store = true;
			showLinks = true;
			remoteSave = false;
			redeem = true;
			hoverLevels = true;
			globalScores = "gameCircle";
			nativeXIDAndroid = 0;
			CBAppIDAndroid = "53854cf2c26ee44420488dab";
			CBAppSigAndroid = "34583215a5bb20953f3b5cca8cba7666cc4ad93a";
		}
		else
		{
			GameObject gameObject = GameObject.Find("AmazonGameCircleManager");
			if ((bool)gameObject)
			{
				MonoBehaviour.print("Found and destroy the AmazonGameCircleManager");
				UnityEngine.Object.Destroy(gameObject);
			}
			gameObject = GameObject.Find("AmazonIAPManager");
			if ((bool)gameObject)
			{
				MonoBehaviour.print("Found and destroy the AmazonIAPManager");
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		if (platform == "playjam")
		{
			devicemodel = "playjam";
			globalScores = "playjam";
			adsOn = 1;
			store = false;
			showLinks = true;
			remoteSave = true;
			redeem = true;
			hoverLevels = true;
			nativeXIDAndroid = 0;
			CBAppIDAndroid = string.Empty;
			CBAppSigAndroid = string.Empty;
		}
	}

	public virtual void MakeStoreKitArrays(string itemIDs)
	{
		storeItems = new UnityScript.Lang.Array();
		storePrices = new UnityScript.Lang.Array();
		storeTitles = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array = itemIDs.Split(char.Parse(","));
		for (int i = 0; i < array.length; i++)
		{
			storeItems = new UnityScript.Lang.Array("gems_100000", "gems_225000", "gems_500000", "tokens_100", "tokens_225", "tokens_500");
			storePrices = new UnityScript.Lang.Array("$4.99", "$9.99", "$19.99", "$4.99", "$9.99", "$19.99");
			storeTitles = new UnityScript.Lang.Array("100,000 Gem Pack", "225,000 Gem Pack", "500,000 Gem Pack", "100 Token Pack", "225 Token Pack", "500 Token Pack");
		}
	}

	public virtual void ConvertVar(string varName, string varValue)
	{
		switch (varName)
		{
		case "vungleios":
			vungleios = varValue;
			break;
		case "vungleandroid":
			vungleandroid = varValue;
			break;
		case "adsOn":
			adsOn = UnityBuiltins.parseInt(varValue);
			break;
		case "nativeXIDAndroid":
			nativeXIDAndroid = UnityBuiltins.parseInt(varValue);
			break;
		case "nativeXapk":
			nativeXapk = varValue;
			break;
		case "CBAppIDAndroid":
			CBAppIDAndroid = varValue;
			break;
		case "CBAppSigAndroid":
			CBAppSigAndroid = varValue;
			break;
		case "CBAppIDIOS":
			CBAppIDIOS = varValue;
			adsOn = 1;
			break;
		case "CBAppSigIOS":
			CBAppSigIOS = varValue;
			break;
		case "bonusInterval":
			bonusInterval = UnityBuiltins.parseInt(varValue);
			break;
		case "showLinks":
			showLinks = ((varValue == "true") ? true : false);
			break;
		case "forceQuality":
			forceQuality = UnityBuiltins.parseInt(varValue);
			break;
		case "remoteSave":
			remoteSave = ((varValue == "true") ? true : false);
			break;
		case "redeem":
			redeem = ((varValue == "true") ? true : false);
			break;
		case "maxWorlds":
			maxWorlds = UnityBuiltins.parseInt(varValue);
			break;
		case "defaultCharacter":
			defaultCharacter = varValue;
			break;
		case "gcPrefix":
			gcPrefix = varValue;
			break;
		case "appID":
			appID = varValue;
			break;
		case "gameScene":
			gameScene = varValue;
			break;
		case "gender":
			gender = varValue;
			break;
		case "globalScores":
			break;
		case "store":
			store = ((varValue == "true") ? true : false);
			break;
		case "forceBigHead":
			forceBigHead = ((varValue == "true") ? true : false);
			break;
		case "garbot":
			garbot = ((varValue == "true") ? true : false);
			break;
		case "adMobIDiOS":
			adMobIDiOS = varValue;
			break;
		case "adMobIDAndroid":
			adMobIDAndroid = varValue;
			break;
		case "version":
			version = varValue;
			break;
		case "buildVersion":
			buildVersion = varValue;
			break;
		case "lite":
			lite = ((varValue == "true") ? true : false);
			break;
		case "iads":
			iads = ((varValue == "true") ? true : false);
			break;
		case "storeitemlist":
			MakeStoreKitArrays(varValue);
			break;
		}
	}

	public virtual void Awake()
	{
		InitializeAppData();
		AudioListener.volume = 0f;
		if (buildVersion == string.Empty)
		{
			buildVersion = version;
		}
		GameObject gameObject = null;
		cheatsOn = Application.isEditor;
		demo = false;
		if (defaultAssets == string.Empty)
		{
			defaultAssets = "outfit_default|SkyNormal|LightNormal|AtlasDefault|204,206,206,255";
		}
		defaultAssetArray = defaultAssets.Split(char.Parse("|"));
		object obj = defaultAssetArray[0];
		if (!(obj is string))
		{
			obj = RuntimeServices.Coerce(obj, typeof(string));
		}
		defaultCharacter = (string)obj;
		string text = DateTime.Now.ToString("MM");
		if (text == "12")
		{
			defaultAssetArray[3] = "AtlasSnow";
			defaultAssetArray[1] = "SkySpace";
			defaultAssetArray[2] = "LightNewSpace";
		}
		object obj2 = defaultAssetArray[3];
		if (!(obj2 is string))
		{
			obj2 = RuntimeServices.Coerce(obj2, typeof(string));
		}
		defaultAtlas = (string)obj2;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Sky/" + defaultAssetArray[1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
		GameObject obj3 = gameObject;
		object obj4 = defaultAssetArray[1];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		obj3.name = (string)obj4;
		backdropTexture = (Texture2D)gameObject.GetComponent<Renderer>().material.mainTexture;
		gcPrefix = "grp.d.";
		if (appName == "DiversionLite")
		{
			lite = true;
			boardsOff = true;
		}
		else if (appName == "HoverWorld")
		{
			showTotalGems = true;
			boardsOff = false;
		}
		if (garbot)
		{
			garbotMaterial.mainTexture = (Texture)Resources.Load(appName + "/garbot1texture");
		}
		cloudEmail = PlayerPrefs.GetString("cloudEmail", string.Empty);
		ReadMissionLevels();
		inverted = false;
		touchScale = 1.5f;
		storeApproved = 1;
		adsOn = PlayerPrefs.GetInt("adsOn", adsOn);
		dailyXP = PlayerPrefs.GetInt("dailyXP", 0);
		lastXP = dailyXP;
		AdjustDailyXPStatus();
		unlockedItems = new UnityScript.Lang.Array();
		playerName = PlayerPrefs.GetString("playerName", string.Empty);
		gender = PlayerPrefs.GetString("gender", gender);
		musicOn = PlayerPrefs.GetInt("musicOn", 1);
		maxQuality = QualitySettings.names.Length - 1;
		if (!SystemInfo.supportsShadows)
		{
			maxQuality--;
		}
		if (forceQuality != -1)
		{
			maxQuality = forceQuality;
		}
		int defaultValue = maxQuality;
		quality = PlayerPrefs.GetInt("qualitySetting", defaultValue);
		AdjustQuality();
		CreateMasterItemLists();
		CreateMissionLists();
		ResetWorldLists();
		int @int = PlayerPrefs.GetInt("movieCounter", 0);
		if (devicemodel == "ouya")
		{
			if (@int == 0)
			{
				Handheld.PlayFullScreenMovie("Intro.m4v", Color.black, FullScreenMovieControlMode.CancelOnInput);
			}
		}
		else if (@int % 5 == 0)
		{
			Handheld.PlayFullScreenMovie("Intro.m4v", Color.black, FullScreenMovieControlMode.CancelOnInput);
		}
		@int++;
		PlayerPrefs.SetInt("movieCounter", @int);
		if ((bool)shadowMaterial)
		{
			shadowMaterial.color = new Color(0f, 0f, 0f, 0.54f);
		}
		StartCoroutine(StartAndroidIAB());
		soundOn = PlayerPrefs.GetInt("soundOn", 3);
		InitAds();
	}

	public virtual void InitAds()
	{
		eAds.Initialize();
		eAds.onVideoSuccess += onVideoSuccess;
		eAds.onVideoFailed += onVideoFailed;
	}

	public virtual void VideoShow()
	{
		if (eAds.VideoIsReady())
		{
			AudioListener.volume = 0f;
			eAds.VideoShow(true);
		}
	}

	public virtual void onVideoFailed()
	{
		if (soundOn > 0)
		{
			AdjustSound();
		}
	}

	public virtual void onVideoSuccess()
	{
		if (soundOn > 0)
		{
			AdjustSound();
		}
		Redeem("tokens_1");
	}

	public virtual void RecordingStart()
	{
		if (videoReplay)
		{
		}
	}

	public virtual void RecordingPause()
	{
		if (videoReplay)
		{
		}
	}

	public virtual void RecordingResume()
	{
		if (videoReplay)
		{
		}
	}

	public virtual IEnumerator RecordingStop()
	{
		return new _0024RecordingStop_0024495(this).GetEnumerator();
	}

	public virtual void RecordingShowPortal()
	{
		if (videoReplay)
		{
		}
	}

	public virtual void RecordingShowLast()
	{
		if (videoReplay)
		{
		}
	}

	public virtual void ScaleHead()
	{
	}

	public virtual void AdjustBigHead(float newValue)
	{
		if (forceBigHead)
		{
			newValue = 3f;
		}
		headsize = newValue;
		Camera.main.SendMessage("AdjustForHeadSize", headsize, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void PrintOutfits()
	{
		string text = string.Empty;
		tempAsset = (TextAsset)Resources.Load(appName + "/Prizes", typeof(TextAsset));
		if ((bool)tempAsset)
		{
			tempString = tempAsset.text;
			string[] array = tempString.Split(char.Parse("\n"));
			int i = 0;
			string[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				string[] array3 = array2[i].Split(char.Parse("|"));
				if (Extensions.get_length((System.Array)array3) == 5 && array3[2] == "5")
				{
					text += array3[0] + "\n";
				}
			}
		}
		MonoBehaviour.print(text);
	}

	public virtual void RemoteDataClear()
	{
		lastRemoteSaveData = string.Empty;
	}

	public virtual IEnumerator RemoteForgotPassword()
	{
		return new _0024RemoteForgotPassword_0024498(this).GetEnumerator();
	}

	public virtual IEnumerator RemoteDataSave()
	{
		return new _0024RemoteDataSave_0024504(this).GetEnumerator();
	}

	public virtual IEnumerator RemoteDataLoad()
	{
		return new _0024RemoteDataLoad_0024511(this).GetEnumerator();
	}

	public virtual IEnumerator StartAndroidIAB()
	{
		return new _0024StartAndroidIAB_0024521(this).GetEnumerator();
	}

	public virtual void queryInventorySucceededEvent(System.Collections.Generic.List<GooglePurchase> purchases, System.Collections.Generic.List<GoogleSkuInfo> myList)
	{
		_products = myList;
		int count = _products.Count;
		if (count == 0)
		{
			return;
		}
		ezoneValidProducts = new string[count];
		ezonePrice = new string[count];
		ezoneTitle = new string[count];
		ezoneDescription = new string[count];
		for (int i = 0; i < storeItems.Count; i++)
		{
			for (int j = 0; j < count; j++)
			{
				if (RuntimeServices.EqualityOperator(storeItems[i], _products[j].productId.ToString()))
				{
					ezoneValidProducts[i] = _products[j].productId.ToString();
					ezonePrice[i] = _products[j].price.ToString();
					string text = _products[j].title.ToString();
					text = text.Replace("(Diversion - Holiday Special)", string.Empty);
					text = text.Replace("(Diversion)", string.Empty);
					ezoneTitle[i] = text;
					ezoneDescription[i] = _products[j].description.ToString();
					storePrices[i] = _products[j].price.ToString();
					storeTitles[i] = text;
				}
			}
		}
		storeStatus = "ready";
	}

	public virtual void queryInventoryFailedEvent(string error)
	{
		storeStatus = "error";
	}

	public virtual void purchaseSucceededEvent(GooglePurchase purchase)
	{
		storeStatus = "ready";
		RemoveAds();
		string text = purchase.productId.ToString();
		if (confirmPurchase)
		{
			Redeem(text);
		}
		GoogleIAB.consumeProduct(text);
	}

	public virtual void purchaseFailedEvent(string error)
	{
		if (storeStatus == "buying")
		{
			storeStatus = "ready";
		}
		else
		{
			storeStatus = "error";
		}
		redeemMessage = "Sorry, your purchase could not be completed";
		if (menuControl.menu == "storecontact")
		{
			menuControl.menu = "storeFailed";
		}
	}

	public virtual void BuyRemoveAds()
	{
		confirmPurchase = false;
		MonoBehaviour.print("Buy remove ads");
		GoogleIAB.purchaseProduct("com.ezone." + appName + ".removeads");
	}

	public virtual void OnApplicationQuit()
	{
		if (platform == "google")
		{
			GPGManager.authenticationSucceededEvent -= AuthenticationSucceededEvent;
			GPGManager.authenticationFailedEvent -= AuthenticationFailedEvent;
		}
	}

	public virtual void BuyItem(string itemID)
	{
		confirmPurchase = true;
		if (cheatsOn)
		{
			purchaseSuccessful(itemID, "ok", 1);
		}
		else if (storeStatus == "ready")
		{
			if (platform == "google")
			{
				MonoBehaviour.print("GOOGLE: start purchase " + itemID);
				GoogleIAB.purchaseProduct(itemID);
			}
			else if (!(platform == "amazon"))
			{
			}
			storeStatus = "buying";
			menuControl.menu = "storecontact";
		}
	}

	public virtual void RestorePurchases()
	{
	}

	public virtual void purchaseSuccessful(string productIdentifier, string receipt, int quantity)
	{
		storeStatus = "ready";
		RemoveAds();
		if (confirmPurchase)
		{
			Redeem(productIdentifier);
		}
	}

	public virtual void purchaseFailed(string error)
	{
		if (storeStatus == "buying")
		{
			storeStatus = "ready";
		}
		else
		{
			storeStatus = "error";
		}
		Debug.Log("Storekit failed: " + error);
		redeemMessage = "Sorry, your purchase could not be completed";
		if (menuControl.menu == "storecontact")
		{
			menuControl.menu = "storeFailed";
		}
	}

	public virtual void purchaseCancelled(string error)
	{
		if (storeStatus == "buying")
		{
			storeStatus = "ready";
		}
		else
		{
			storeStatus = "error";
		}
		Debug.Log("Storekit cancelled: " + error);
		if (menuControl.menu == "storecontact")
		{
			menuControl.menu = "store";
		}
	}

	public virtual void transactionsRestoredEvent()
	{
	}

	public virtual void transactionRestoreFailedEvent()
	{
		redeemMessage = "Sorry, could not restore purchases";
		if (menuControl.menu == "storecontact")
		{
			menuControl.menu = "storeFailed";
		}
	}

	public virtual void RemoveAds()
	{
		MonoBehaviour.print("RemoveAds called");
		if (adsOn != 0)
		{
			adsOn = 0;
			PlayerPrefs.SetInt("adsOn", adsOn);
		}
	}

	public virtual void ToggleAds()
	{
		if (adsOn == 0)
		{
			adsOn = 1;
		}
		else
		{
			adsOn = 0;
		}
		PlayerPrefs.SetInt("adsOn", adsOn);
	}

	public virtual void UpdateAdsOn(int newValue)
	{
		if (adsOn == 1 && newValue == 0)
		{
			RemoveAds();
		}
	}

	public virtual void GetDailyInfo()
	{
		string text = DateTime.Now.ToString("MM/dd");
		tempAsset = (TextAsset)Resources.Load(appName + "/Daily", typeof(TextAsset));
		dailyOutfit = string.Empty;
		dailyLevel = string.Empty;
		if (!tempAsset)
		{
			return;
		}
		tempString = tempAsset.text;
		string[] array = tempString.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (Extensions.get_length((System.Array)array3) == 3)
			{
				string text2 = array3[0];
				if (text2 == text)
				{
					dailyLevel = array3[1];
					dailyOutfit = array3[2];
					break;
				}
			}
		}
	}

	public virtual void AdjustDailyXP(int howMuch)
	{
		awardMegaPrize = string.Empty;
		lastXP = dailyXP;
		string text = DateTime.Now.ToString("MM/dd");
		string text2 = worldID + "_" + missionLevel;
		if (cheatsOn)
		{
		}
		if (!canEarnDaily)
		{
			dailyXP = 0;
		}
		else
		{
			dailyXP = (int)((float)dailyXP + Mathf.Round(howMuch / 10));
		}
		if (dailyXP >= 100)
		{
			dailyXP = 100;
			string text3 = "dailygems_" + UnityEngine.Random.Range(500, 1000);
			int num = FindItemSlot(dailyOutfit);
			if (num != 0 && !itemOwned[num])
			{
				text3 = dailyOutfit;
			}
			awardMegaPrize = text3;
		}
		PlayerPrefs.SetInt("dailyXP", dailyXP);
	}

	public virtual void AdjustDailyXPStatus()
	{
		string text = DateTime.Now.ToString("MM/dd");
		if (PlayerPrefs.GetString("lastMegaPrize") == text)
		{
			canEarnDaily = false;
		}
		else
		{
			canEarnDaily = true;
		}
	}

	public virtual void ResetDailyXP()
	{
		string value = DateTime.Now.ToString("MM/dd");
		awardMegaPrize = string.Empty;
		dailyXP = 0;
		PlayerPrefs.SetInt("dailyXP", dailyXP);
		lastXP = dailyXP;
		PlayerPrefs.SetString("lastMegaPrize", value);
		AdjustDailyXPStatus();
	}

	public virtual void CheckMegaPrize()
	{
		awardMegaPrize = string.Empty;
	}

	public virtual void CheckDailyPrize()
	{
		string text = DateTime.Now.ToString("MM/dd");
		if (showLinks && PlayerPrefs.GetInt("facebookPrize", 0) == 0)
		{
			PlayerPrefs.SetInt("facebookPrize", 1);
			menuControl.menu = "facebookprize";
		}
	}

	public virtual void CheckDailyPrizeOLD()
	{
		string text = DateTime.Now.ToString("MM/dd");
		if (PlayerPrefs.GetString("lastDayPlayed") != text)
		{
			PlayerPrefs.SetString("lastDayPlayed", text);
			string whichPrize = "dailygems_" + UnityEngine.Random.Range(50, 150);
			tempAsset = (TextAsset)Resources.Load(appName + "/Daily", typeof(TextAsset));
			if ((bool)tempAsset)
			{
				tempString = tempAsset.text;
				string[] array = tempString.Split(char.Parse("\n"));
				int i = 0;
				string[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					string[] array3 = array2[i].Split(char.Parse("|"));
					if (Extensions.get_length((System.Array)array3) != 4)
					{
						continue;
					}
					string text2 = array3[3];
					string text3 = array3[0];
					if (text3 == text)
					{
						MonoBehaviour.print("Found a match: " + array2[i]);
						int num = FindItemSlot(text2);
						if (!itemOwned[num])
						{
							whichPrize = text2;
						}
					}
				}
			}
			else
			{
				MonoBehaviour.print("No Daily Prize list for: " + appName);
			}
			isDaily = true;
			Redeem(whichPrize);
		}
		else if (PlayerPrefs.GetInt("facebookPrize", 0) == 0)
		{
			PlayerPrefs.SetInt("facebookPrize", 1);
			menuControl.menu = "facebookprize";
		}
	}

	public virtual void Redeem(string whichPrize)
	{
		string[] array = whichPrize.Split(char.Parse("."));
		whichPrize = array[Extensions.get_length((System.Array)array) - 1];
		array = whichPrize.Split(char.Parse("_"));
		int num = 0;
		switch (array[0])
		{
		case "dailygems":
			if (Extensions.get_length((System.Array)array) == 2)
			{
				num = UnityBuiltins.parseInt(array[1]);
				AdjustGems(num);
				Save("gems");
				playerControl.ChangeAnimation("win", 0.35f);
				redeemMessage = string.Empty + num + " Gems!";
				menuControl.menu = "redeemed";
			}
			break;
		case "gems":
			if (Extensions.get_length((System.Array)array) == 2)
			{
				num = UnityBuiltins.parseInt(array[1]);
				AdjustGems(num);
				Save("gems");
				if (paused)
				{
					menuControl.menu = "saveme";
					break;
				}
				playerControl.ChangeAnimation("win", 0.35f);
				redeemMessage = num + " Gems!";
				menuControl.menu = "redeemed";
			}
			break;
		case "tokens":
			if (Extensions.get_length((System.Array)array) != 2)
			{
				break;
			}
			num = UnityBuiltins.parseInt(array[1]);
			tokens += num;
			Save("tokens");
			if (paused)
			{
				PlaySound((AudioClip)Resources.Load("Sounds/sparkle", typeof(AudioClip)));
				menuControl.menu = "saveme";
				break;
			}
			playerControl.ChangeAnimation("win", 0.35f);
			if (num == 1)
			{
				redeemMessage = "You earned a Save Token!";
			}
			else
			{
				redeemMessage = num + " Save Tokens!";
			}
			menuControl.menu = "redeemed";
			break;
		case "level":
			newWorldID = UnityBuiltins.parseInt(array[1]);
			newLevelID = UnityBuiltins.parseInt(array[2]);
			playerData.UnlockMission(newWorldID, newLevelID);
			menuControl.menu = "unlockedLevel";
			break;
		case "removeads":
			RemoveAds();
			redeemMessage = "Ads are now removed!";
			menuControl.menu = "redeemed";
			playerControl.ChangeAnimation("win", 0.35f);
			break;
		default:
			if (FindItemSlot(whichPrize) == 0)
			{
				redeemMessage = "Sorry, but that item is not available!";
				menuControl.menu = "redeemerror";
				playerControl.ChangeAnimation("lose", 0.35f);
				break;
			}
			tryingItOn = false;
			BuyItem(whichPrize, false);
			unlockedReason = string.Empty;
			unlockedItem = whichPrize;
			if (!(menuControl.menu == "unlockedLevel") && !(menuControl.menu == "unlockedItem"))
			{
				redeemMessage = string.Empty + array[1] + " unlocked!";
				unlockedLevel = "none";
				menuControl.menu = "redeemed";
			}
			else
			{
				StartCoroutine(ActivateItem(whichPrize));
				MakeList("outfit", true);
			}
			break;
		}
		if (isDaily)
		{
			redeemMessage = "DAILY PRIZE: " + redeemMessage;
			isDaily = false;
		}
		else if (awardMegaPrize != string.Empty)
		{
			redeemMessage = "BONUS: " + redeemMessage;
			menuControl.menu = "bonus";
			ResetDailyXP();
		}
		else if (awardSpecial)
		{
			redeemMessage = "FREE STARTER PACK";
		}
	}

	public virtual IEnumerator GetPrize(string whichCode)
	{
		return new _0024GetPrize_0024525(whichCode, this).GetEnumerator();
	}

	public virtual void ReadMissionLevels()
	{
		missionName = gameScene;
		if (missionName == "DiversionLite")
		{
			missionName = "Diversion";
		}
		int num = HowManyLevelsInWorld(worldID);
		levelStars = new int[num];
		levelGems = new int[num];
		levelUnlocked = new int[num];
		levelAttempts = new int[num];
		levelWins = new int[num];
		if (worldID == 1)
		{
			levelUnlocked[0] = 1;
		}
		if ((bool)playerData)
		{
			playerData.ReadMissionData(missionName, worldID);
		}
	}

	public virtual int HowManyLevelsInWorld(int whichID)
	{
		int num = 0;
		tempAsset = (TextAsset)Resources.Load(appName + "/World" + whichID, typeof(TextAsset));
		tempString = tempAsset.text;
		string[] a = tempString.Split(char.Parse("\n"));
		return Extensions.get_length((System.Array)a);
	}

	public virtual void Start()
	{
		fadeControl = (FadeInOut)UnityEngine.Object.FindObjectOfType(typeof(FadeInOut));
		menuControl = (MenuControl)UnityEngine.Object.FindObjectOfType(typeof(MenuControl));
		blackoutControl = (BlackoutControl)UnityEngine.Object.FindObjectOfType(typeof(BlackoutControl));
		Application.LoadLevel("Title");
		PlayMusic((AudioClip)Resources.Load(appName + "/Music"));
		MakeList("outfit", true);
		menuColorID = PlayerPrefs.GetInt("menuColorID", 0);
		MenuColor(0);
		BannerAdShow();
	}

	public virtual void OnApplicationPause(bool pauseState)
	{
		joystickTimer = Time.realtimeSinceStartup;
		if (pauseState)
		{
			pauseElapsedTime = Time.realtimeSinceStartup - lastsavetime;
			RecordingPause();
			if (device2)
			{
				UpdateHeroWidget();
			}
			return;
		}
		StartCoroutine(ResumePauseTime());
		if (platform == "google")
		{
			CheckGoogleLogin();
		}
		if ((bool)menuControl && menuControl.menu == "game" && !paused)
		{
			menuControl.menu = "missionPause";
			StartCoroutine(PauseGame(true));
		}
		if (!device2)
		{
			return;
		}
		string quickStartLevel = GetQuickStartLevel();
		if (quickStartLevel != string.Empty)
		{
			MonoBehaviour.print("QUICKSTART LEVEL: " + quickStartLevel);
			string[] array = quickStartLevel.Split(char.Parse("-"));
			if (Extensions.get_length((System.Array)array) == 2)
			{
				missionGem = 0;
				missionMilestone = 0;
				missionEndless = false;
				worldID = UnityBuiltins.parseInt(array[0]);
				missionLevel = UnityBuiltins.parseInt(array[1]);
				StartCoroutine(ChangeScene("Main", true));
			}
		}
	}

	public virtual string GetQuickStartLevel()
	{
		return string.Empty;
	}

	public virtual void ClearQuickStart()
	{
	}

	public virtual void UpdateHeroWidget()
	{
		int num = 1;
		int num2 = 0;
		string text = "1-1";
		int num3 = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)worldStars); i++)
		{
			if (i < Extensions.get_length((System.Array)worldStars) - 1)
			{
				MonoBehaviour.print("World " + (i + 1) + " Stars: " + worldStars[i] + ", locked: " + worldLocked[i]);
				num3 += worldStars[i];
				if (!worldLocked[i])
				{
					num2 = i + 1;
				}
			}
		}
		if (num2 < 1)
		{
			num2 = 1;
		}
		int num4 = worldID;
		worldID = num2;
		ReadMissionLevels();
		for (int j = 0; j < Extensions.get_length((System.Array)levelUnlocked); j++)
		{
			if (levelUnlocked[j] == 1)
			{
				num = j + 1;
			}
		}
		if (num < 1)
		{
			num = 1;
		}
		text = string.Empty + num2 + "-" + num;
		worldID = num4;
		ReadMissionLevels();
		int num5 = (int)(DateTime.Today.AddDays(1.0).Subtract(DateTime.Now).TotalSeconds * 1000.0);
		MonoBehaviour.print("SENDING: maxLevel: " + text + ", maxStars: " + num3 + ", mSecsToMidnight: " + num5);
	}

	public virtual IEnumerator ResumePauseTime()
	{
		return new _0024ResumePauseTime_0024538(this).GetEnumerator();
	}

	public virtual void PlayMusic(AudioClip musicClip)
	{
		GetComponent<AudioSource>().clip = musicClip;
		if (musicOn != 0)
		{
			GetComponent<AudioSource>().Play();
		}
		else
		{
			GetComponent<AudioSource>().Stop();
		}
	}

	public virtual void StopMusic()
	{
		GetComponent<AudioSource>().Stop();
	}

	public virtual void PlayAudioClip(AudioClip clip, Vector3 position, float volume)
	{
		GetComponent<AudioSource>().PlayOneShot(clip, volume);
	}

	public virtual void PlaySound(AudioClip whichSound)
	{
		PlayAudioClip(whichSound, transform.position, 1f);
	}

	public virtual void AdjustMusic(int whichWay)
	{
		if (whichWay == 1)
		{
			musicOn = 1;
			GetComponent<AudioSource>().Play();
		}
		else
		{
			musicOn = 0;
			GetComponent<AudioSource>().Stop();
		}
		PlayerPrefs.SetInt("musicOn", musicOn);
	}

	public virtual void AdjustSound()
	{
		GetComponent<AudioSource>().volume = (float)soundOn * 10f / 30f;
		AudioListener.volume = (float)soundOn * 10f / 30f;
		PlayerPrefs.SetInt("soundOn", soundOn);
	}

	public virtual void AdjustQuality()
	{
		QualitySettings.SetQualityLevel(quality, true);
		PlayerPrefs.SetInt("qualitySetting", quality);
		switch (quality)
		{
		case 0:
			defaultRenderingPath = RenderingPath.VertexLit;
			AdjustShadows(0);
			break;
		case 1:
			defaultRenderingPath = RenderingPath.Forward;
			AdjustShadows(1);
			break;
		case 2:
			defaultRenderingPath = RenderingPath.Forward;
			AdjustShadows(0);
			break;
		}
		Camera.main.farClipPlane = farClip;
		float[] array = new float[32];
		if (quality == maxQuality)
		{
			Camera.main.farClipPlane = farClip;
			array[9] = farClip * 0.75f;
			Camera.main.layerCullDistances = array;
		}
		else
		{
			Camera.main.farClipPlane = farClip;
			array[9] = farClip * 0.5f;
			Camera.main.layerCullDistances = array;
		}
	}

	public virtual void AdjustShadows(int whichWay)
	{
		Camera.main.renderingPath = defaultRenderingPath;
		if (whichWay == 1)
		{
			shadowsOn = 1;
			Camera.main.cullingMask = -257;
		}
		else
		{
			shadowsOn = 0;
			Camera.main.cullingMask = -4353;
		}
		PlayerPrefs.SetInt("shadowsOn", shadowsOn);
	}

	public virtual void AdjustVideoReplay(bool whichWay)
	{
		videoReplay = false;
	}

	public virtual void InitScoreManager()
	{
		if (globalScores == "google")
		{
			Debug.Log("GOOGLE: init PLAY");
			GPGManager.authenticationSucceededEvent += AuthenticationSucceededEvent;
			GPGManager.authenticationFailedEvent += AuthenticationFailedEvent;
			PlayGameServices.init("467868940282.apps.googleusercontent.com", true);
			PlayGameServices.authenticate();
		}
		else if (!(globalScores == "gameCircle"))
		{
		}
	}

	public virtual void ProcessAuthentication(bool success)
	{
		if (success)
		{
			loginState = "in";
		}
		else
		{
			loginState = "none";
		}
	}

	public virtual void CheckGoogleLogin()
	{
		if (globalScores == "google")
		{
			if (PlayGameServices.isSignedIn())
			{
				loginState = "in";
			}
			else
			{
				loginState = "none";
			}
		}
	}

	public virtual void AuthenticationSucceededEvent(string param)
	{
		Debug.Log("GOOGLE: authenticationSucceededEvent: " + param);
		loginState = "in";
		InvokeRepeating("GetAchievements", 5f, 5f);
	}

	public virtual void AuthenticationFailedEvent(string error)
	{
		Debug.Log("GOOGLE authenticationFailedEvent: " + error);
		loginState = "none";
	}

	public virtual void GetAchievements()
	{
		_achievements = PlayGameServices.getAllAchievementMetadata();
		if (_achievements.Count != 0)
		{
			CancelInvoke("GetAchievements");
		}
	}

	public virtual string GetAchievementID(string whichName)
	{
		string text = string.Empty;
		string result;
		if (RuntimeServices.EqualityOperator(_achievements, null))
		{
			result = text;
		}
		else
		{
			int count = _achievements.Count;
			MonoBehaviour.print("GOOGLE: checking entry for: " + whichName + " " + count);
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					string text2 = _achievements[i].name.ToString();
					if (whichName == text2.ToLower() && _achievements[i].state.ToString() != "0")
					{
						text = _achievements[i].achievementId.ToString();
					}
				}
			}
			result = text;
		}
		return result;
	}

	public virtual void ProcessScore(bool result)
	{
		MonoBehaviour.print("GAMECENTER result: " + result);
	}

	public virtual void ShowScoreboard()
	{
		if (globalScores == "google" && loginState != "in")
		{
			showLeaderboardAfterLogin = true;
			menuControl.menu = "googlePlay";
		}
		else if (globalScores == "google")
		{
			PlayGameServices.showLeaderboards();
		}
		else if (globalScores == "gameCircle")
		{
			Social.ShowLeaderboardUI();
		}
	}

	public virtual void SaveScore()
	{
		if (loginState != "in" || appName.IndexOf("Diversion") == -1)
		{
			return;
		}
		if (globalScores == "google")
		{
			if (worldID == 100)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQBg", Convert.ToInt64(worldScores[maxWorlds - 1]), string.Empty);
			}
			else if (worldID == 1)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQAQ", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 2)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQAg", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 3)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQAw", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 4)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQBA", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 5)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQBQ", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 6)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQFw", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
			else if (worldID == 7)
			{
				PlayGameServices.submitScore("CgkI-u-l-c4NEAIQGA", Convert.ToInt64(worldScores[worldID - 1]), string.Empty);
			}
		}
		else if (globalScores == "gameCircle")
		{
			if (worldID == 100)
			{
				Social.ReportScore(worldScores[maxWorlds - 1], "bonus", ProcessScore);
			}
			else
			{
				Social.ReportScore(worldScores[worldID - 1], "world" + worldID, ProcessScore);
			}
		}
	}

	public virtual void ShowAchievements()
	{
		if (globalScores == "google")
		{
			PlayGameServices.showAchievements();
		}
	}

	public virtual void AddAchievement(string whichID)
	{
		if (loginState != "in")
		{
			return;
		}
		MonoBehaviour.print("Trying to add achievement: " + whichID);
		if (appName.IndexOf("Diversion") != -1 && globalScores == "google")
		{
			string achievementID = GetAchievementID(whichID);
			if (achievementID != string.Empty)
			{
				PlayGameServices.unlockAchievement(achievementID);
			}
		}
	}

	public virtual void Shake(float howMuch, bool vibratePhone)
	{
		cameraShake = 2f * howMuch;
	}

	public virtual void BannerAdShow()
	{
		if (adsOn == 1)
		{
			eAds.BannerShow(true);
		}
	}

	public virtual void BannerAdHide()
	{
		eAds.BannerShow(false);
	}

	public virtual void PromoShowing()
	{
		promoShowing = true;
		MonoBehaviour.print("Now showing the promo!");
	}

	public virtual void PromoDone(int prizeID)
	{
		promoShowing = false;
		MonoBehaviour.print("Promo finished, and " + prizeID + " tokens awarded");
	}

	public virtual IEnumerator ShowInterstitial()
	{
		return new _0024ShowInterstitial_0024541(this).GetEnumerator();
	}

	public virtual void ShowMoreApps()
	{
		eAds.MoreGames();
	}

	public virtual void Update()
	{
		transform.position = Camera.main.transform.position;
		transform.rotation = Camera.main.transform.rotation;
		cameraShake -= 0.0333f;
		if (!(Time.realtimeSinceStartup - joystickTimer <= 0.5f) && (eInput.Select || eInput.rightPadRight))
		{
			joystickTimer = Time.realtimeSinceStartup;
			menuControl.CheckBack();
		}
		if (cheatsOn)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				playerControl.ResetToSafePosition();
				playerControl.AddShield(100);
				playerControl.AddBoost(100f);
			}
			if (Input.GetKeyDown(KeyCode.T))
			{
				ShowToken();
			}
		}
	}

	public virtual void BuyWorld(int whichWorldID)
	{
		if (tokens < 5)
		{
			if (store)
			{
				menuControl.menu = "store";
			}
			else
			{
				PlaySound((AudioClip)Resources.Load("Sounds/dud"));
			}
			return;
		}
		MonoBehaviour.print("Trying to unlock: " + whichWorldID + "_1");
		int num = -1;
		for (int i = 0; i < Extensions.get_length((System.Array)itemUnlocksLevel); i++)
		{
			if (itemUnlocksLevel[i] == whichWorldID + "_1")
			{
				num = i;
			}
		}
		if (num != -1)
		{
			tokens -= 5;
			tryingItOn = false;
			BuyItem(itemName[num], false);
			StartCoroutine(ActivateItem(itemName[num]));
		}
	}

	public virtual void AddTokens(int howMany)
	{
		if (howMany > 0)
		{
			ShowToken();
		}
		tokens += howMany;
		Save("tokens");
	}

	public virtual void ShowToken()
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("TokenShowPrefab"), Camera.main.transform.position, Camera.main.transform.rotation);
		gameObject.transform.parent = Camera.main.transform;
	}

	public virtual IEnumerator ShowSaveMe(float delayTime)
	{
		return new _0024ShowSaveMe_0024544(delayTime, this).GetEnumerator();
	}

	public virtual void DieNoSaveMe()
	{
		menuControl.menu = "game";
		StartCoroutine(PauseGame(false));
		milestoneReached = false;
		StartCoroutine(playerControl.DieNoSaveMe());
	}

	public virtual void SaveMe()
	{
		if (tokens >= savePrice)
		{
			tokens -= savePrice;
			Save("tokens");
			menuControl.menu = "game";
			StartCoroutine(PauseGame(false));
			playerControl.SaveMe();
			PlaySound((AudioClip)Resources.Load("Sounds/warped"));
			UnityEngine.Object.Instantiate(Resources.Load("warpExplosion"), playerControl.transform.position, Quaternion.identity);
			StartCoroutine(WarpCamera());
			savePrice *= 2;
		}
		else
		{
			menuControl.menu = "moretokens";
		}
	}

	public virtual void SetSaveMeY(Vector3 myPos)
	{
		saveMeY = myPos.y;
		MonoBehaviour.print("SaveMeY: " + saveMeY);
	}

	public virtual IEnumerator PauseGame(bool pauseNow)
	{
		return new _0024PauseGame_0024549(pauseNow, this).GetEnumerator();
	}

	public virtual void UpdateBanner(bool pauseNow)
	{
		if (adsOn == 0)
		{
			BannerAdHide();
		}
		else if (inGame)
		{
			BannerAdHide();
		}
		else
		{
			BannerAdShow();
		}
	}

	public virtual bool UserExists(string whichPlayer)
	{
		bool result = false;
		filePath = whichPlayer + "Data.txt";
		if (PlayerPrefs.GetString(filePath, string.Empty) != string.Empty)
		{
			result = true;
		}
		return result;
	}

	public virtual void ChangeCameraTarget(Transform modelTransform)
	{
		cameraTarget = modelTransform;
		Camera.main.BroadcastMessage("ChangeTarget", cameraTarget);
	}

	public virtual void ChangeControl(string newControls)
	{
		PlayerInput playerInput = (PlayerInput)UnityEngine.Object.FindObjectOfType(typeof(PlayerInput));
		if ((bool)playerInput)
		{
			playerInput.ChangeControl(newControls);
		}
	}

	public virtual void ChangeMode(string newMode)
	{
		if ((bool)playerControl)
		{
			playerControl.ChangeMode(newMode);
		}
	}

	public virtual void OnLevelWasLoaded(int level)
	{
		if ((bool)menuControl)
		{
			menuControl.levelSelected = false;
		}
	}

	public virtual void EndMiniGameScene()
	{
		missionMilestone = 0;
		missionOver = true;
		StartCoroutine(ChangeScene("Title", true));
	}

	public virtual void AdjustGems(int howMuch)
	{
		playerControl.playerData.gems = playerControl.playerData.gems + howMuch;
	}

	public virtual void Save(string whichSave)
	{
		if ((bool)playerData)
		{
			playerData.SaveData(whichSave);
		}
	}

	public virtual IEnumerator ChangeScene(string whichScene, bool fadeOutFirst)
	{
		return new _0024ChangeScene_0024554(whichScene, fadeOutFirst, this).GetEnumerator();
	}

	public virtual void UpdateHints()
	{
		TextAsset textAsset = null;
		string text = null;
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		textAsset = (TextAsset)Resources.Load(appName + "/Hint" + worldID, typeof(TextAsset));
		text = textAsset.text;
		string[] array2 = text.Split(char.Parse("\n"));
		if (missionLevel <= Extensions.get_length((System.Array)array2))
		{
			string empty = string.Empty;
			text = array2[missionLevel - 1];
			string[] array3 = text.Split(char.Parse("|"));
			empty = ((Extensions.get_length((System.Array)array3) != 1) ? array3[0] : text);
			if (eInput.controlType == "ouya")
			{
				empty = empty.Replace("touch", "press 'o'");
			}
			else if (eInput.controlType != "touch")
			{
				empty = empty.Replace("touch", "press 'a'");
			}
			if (worldID == 100)
			{
				levelHint = "Bonus Level " + missionLevel + "\n\n" + empty;
			}
			else
			{
				levelHint = "Level " + worldID + "-" + missionLevel + "\n\n" + empty;
			}
		}
	}

	public virtual void InitScene()
	{
		inputVector = Vector3.zero;
		if (lite && gameMenu == "title")
		{
			menuControl.menu = "upgrade";
			menuControl.backMenu = "title";
		}
		else
		{
			menuControl.menu = gameMenu;
		}
		shiftCameraLeft = false;
		missionOver = false;
		missionAborted = false;
		if (Application.loadedLevelName == "Title")
		{
			watchCamera = true;
			blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/" + defaultAtlas));
		}
		newLevelID = -1;
		newWorldID = -1;
		if (!garbot)
		{
			GameObject gameObject = GameObject.Find("Garbot1");
			if ((bool)gameObject)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
		}
		AdjustSound();
	}

	public virtual void PreviewWorld(int whichID)
	{
		if (whichID > maxWorlds)
		{
			whichID = maxWorlds;
		}
		if (whichID == maxWorlds)
		{
			whichID = 100;
		}
		worldID = whichID;
		if (maxWorlds == 1)
		{
			worldID = 1;
		}
		UnityScript.Lang.Array array;
		if (worldID == 1)
		{
			array = defaultAssetArray;
		}
		else
		{
			tempAsset = (TextAsset)Resources.Load(appName + "/World" + worldID, typeof(TextAsset));
			tempString = tempAsset.text;
			string[] array2 = tempString.Split(char.Parse("\n"));
			array = array2[0].Split(char.Parse("|"));
		}
		bool flag = false;
		GameObject gameObject = GameObject.FindWithTag("Sky");
		if ((bool)gameObject)
		{
			if (!RuntimeServices.EqualityOperator(gameObject.name, array[1]))
			{
				UnityEngine.Object.Destroy(gameObject);
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Sky/" + array[1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
			GameObject obj = gameObject;
			object obj2 = array[1];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			obj.name = (string)obj2;
		}
		flag = false;
		GameObject gameObject2 = GameObject.FindWithTag("Light");
		if ((bool)gameObject2)
		{
			UnityEngine.Object.Destroy(gameObject2);
		}
		UnityEngine.Object.Instantiate(Resources.Load("Lights/" + array[2]), new Vector3(0f, 0f, 0f), Quaternion.identity);
		blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/" + array[3]));
		BlackoutControl obj3 = blackoutControl;
		object obj4 = array[4];
		if (!(obj4 is string))
		{
			obj4 = RuntimeServices.Coerce(obj4, typeof(string));
		}
		obj3.ChangeColor((string)obj4);
	}

	public virtual void ClearMemory()
	{
	}

	public virtual void InitMission()
	{
		if (missionCount == 0)
		{
			missionStartPos = playerControl.transform.position;
			missionStartRot = playerControl.transform.rotation;
		}
		milestoneReached = false;
		missionGem = missionMilestone;
		missionMilestone = missionGem + bonusInterval;
		string loadedLevelName = Application.loadedLevelName;
		int num = 0;
		missionStarted = false;
		missionOver = false;
		string empty = string.Empty;
		missionStar = 0;
		missionWin = false;
		missionSummary = new bool[3];
		missionPrize = string.Empty;
		missionCharacterBonus = false;
		missionAborted = false;
		missionExited = false;
		showStar = false;
		bonusDone = false;
		unlockedItem = "none";
		unlockedLevel = "none";
		string text = "none";
		hintCollected = false;
		playerControl.health = 1;
		playerControl.boost = 0f;
        playerControl.shield = 0;
        if (missionGem > 0)
		{
			playerControl.boost = saveBoost;
		}
		else
		{
			savePrice = 1;
		}
		saveBoost = 0f;
		missionInitMissionControl = true;
		goalPosition = Vector3.zero;
		watchCamera = false;
		missionWins = 0;
		missionBest = 0;
		inGame = true;
		StartCoroutine(PauseGame(true));
		missionCount++;
	}

	public virtual void CheatWin()
	{
		missionStar = 3;
		missionGem = 50;
		missionWin = true;
		missionAborted = true;
	}

	public virtual void AbortMission()
	{
		playerControl.Die();
	}

	public virtual void SkipLevel(int tempCost)
	{
		skipsUsed++;
		levelWins[missionLevel - 1] = levelWins[missionLevel - 1] + 1;
		if (Extensions.get_length((System.Array)levelUnlocked) > missionLevel && worldID != 100)
		{
			levelUnlocked[missionLevel] = 1;
			playerData.UnlockMission(worldID, missionLevel + 1);
		}
		CheckForUnlock();
		AdjustGems(-tempCost);
		Save("level");
	}

	public virtual void HintAbort()
	{
		missionMilestone = 0;
		MissionDistance missionDistance = (MissionDistance)UnityEngine.Object.FindObjectOfType(typeof(MissionDistance));
		if ((bool)missionDistance)
		{
			StartCoroutine(PauseGame(false));
			missionExited = true;
			StartCoroutine(missionDistance.EndMission());
		}
		else
		{
			missionOver = true;
			StartCoroutine(ChangeScene("Title", false));
		}
		BannerAdShow();
	}

	public virtual void LeaveMission()
	{
		MissionDistance missionDistance = (MissionDistance)UnityEngine.Object.FindObjectOfType(typeof(MissionDistance));
		if ((bool)missionDistance)
		{
			StartCoroutine(PauseGame(false));
			StartCoroutine(missionDistance.EndMission());
		}
	}

	public virtual IEnumerator EndMission(string whichMenu)
	{
		return new _0024EndMission_0024562(whichMenu, this).GetEnumerator();
	}

	public virtual string GetAwardDesc(string whichString)
	{
		string result = "none";
		if (whichString != null)
		{
			string[] array = whichString.Split(char.Parse("_"));
			if (Extensions.get_length((System.Array)array) == 3)
			{
				string lhs = "World " + array[1];
				if (array[1] == "100")
				{
					lhs = "Bonus World";
				}
				if (array[0] == "level")
				{
					result = lhs + ": Complete Level " + array[2];
				}
				else if (array[0] == "stars")
				{
					result = lhs + ": " + array[2] + " Stars";
				}
				else if (array[0] == "score")
				{
					result = lhs + ": Score " + array[2];
				}
			}
		}
		return result;
	}

	public virtual void CheckForUnlock()
	{
		unlockedItems = new UnityScript.Lang.Array();
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)levelStars); i++)
		{
			num2 += levelStars[i];
		}
		int num3 = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)levelGems); i++)
		{
			num3 += levelGems[i];
		}
		for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
		{
			num = FindItemSlot(missionShop[i]);
			if (itemOwned[num] || !(itemAwardedFor[num] != null))
			{
				continue;
			}
			string[] array = itemAwardedFor[num].Split(char.Parse("_"));
			if (array[0] == "level")
			{
				if (worldID == UnityBuiltins.parseInt(array[1]) && missionLevel == UnityBuiltins.parseInt(array[2]))
				{
					unlockedItems.Push(num);
				}
			}
			else if (array[0] == "stars")
			{
				if (worldID == UnityBuiltins.parseInt(array[1]) && num2 >= UnityBuiltins.parseInt(array[2]))
				{
					unlockedItems.Push(num);
				}
			}
			else if (array[0] == "score" && worldID == UnityBuiltins.parseInt(array[1]) && num3 >= UnityBuiltins.parseInt(array[2]))
			{
				unlockedItems.Push(num);
			}
		}
	}

	public virtual bool UnlockNext()
	{
		bool result = false;
		unlockedItem = "none";
		unlockedLevel = "none";
		unlockedReason = string.Empty;
		if (unlockedItems.length > 0)
		{
			result = true;
			int num = RuntimeServices.UnboxInt32(unlockedItems.Shift());
			unlockedItem = itemName[num];
			unlockedLevel = itemUnlocksLevel[num];
			unlockedReason = itemAwardedDesc[num] + " - ";
			MonoBehaviour.print("Unlocked " + itemName[num] + " " + unlockedReason + ", unlocks:" + unlockedLevel);
			if (!(unlockedItem == "none") && !(unlockedItem == string.Empty))
			{
				tryingItOn = false;
				BuyItem(unlockedItem, false);
			}
		}
		return result;
	}

	public virtual void CheckBonusMilestone()
	{
		if (missionEndless && playerControl.health > 0 && !milestoneReached && missionGem >= missionMilestone - 10)
		{
			milestoneReached = true;
		}
	}

	public virtual void CheckForUnlockOLD()
	{
		unlockedItem = "none";
		unlockedLevel = "none";
		unlockedReason = string.Empty;
		int num = -1;
		int num2 = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
		{
			num2 = FindItemSlot(missionShop[i]);
			if (!itemOwned[num2] && itemAwardedFor[num2] != null)
			{
				string[] array = itemAwardedFor[num2].Split(char.Parse("_"));
				if (array[0] == "level" && worldID == UnityBuiltins.parseInt(array[1]) && missionLevel == UnityBuiltins.parseInt(array[2]))
				{
					num = num2;
					unlockedReason = itemAwardedDesc[num2] + " - ";
					break;
				}
			}
		}
		if (num == -1)
		{
			int num3 = 0;
			for (int i = 0; i < Extensions.get_length((System.Array)levelStars); i++)
			{
				num3 += levelStars[i];
			}
			for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
			{
				num2 = FindItemSlot(missionShop[i]);
				if (!itemOwned[num2] && itemAwardedFor[num2] != null)
				{
					string[] array = itemAwardedFor[num2].Split(char.Parse("_"));
					if (array[0] == "stars" && worldID == UnityBuiltins.parseInt(array[1]) && num3 >= UnityBuiltins.parseInt(array[2]))
					{
						num = num2;
						unlockedReason = itemAwardedDesc[num2] + " - ";
						break;
					}
				}
			}
		}
		if (num == -1)
		{
			int num4 = 0;
			for (int i = 0; i < Extensions.get_length((System.Array)levelGems); i++)
			{
				num4 += levelGems[i];
			}
			for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
			{
				num2 = FindItemSlot(missionShop[i]);
				if (!itemOwned[num2] && itemAwardedFor[num2] != null)
				{
					string[] array = itemAwardedFor[num2].Split(char.Parse("_"));
					if (array[0] == "score" && worldID == UnityBuiltins.parseInt(array[1]) && num4 >= UnityBuiltins.parseInt(array[2]))
					{
						num = num2;
						unlockedReason = itemAwardedDesc[num2] + " - ";
						break;
					}
				}
			}
		}
		if (num != -1)
		{
			unlockedItem = itemName[num];
			unlockedLevel = itemUnlocksLevel[num];
			if (!(unlockedItem == "none") && !(unlockedItem == string.Empty))
			{
				tryingItOn = false;
				BuyItem(unlockedItem, false);
			}
		}
	}

	public virtual void NextWinMenu()
	{
		menuControl.menu = "missionEnd";
		playerControl.ChangeAnimation("win", 0.35f);
	}

	public virtual void ShowWarp(string warpScene, string promptText)
	{
		menuControl.ShowWarp(warpScene, promptText);
	}

	public virtual void RestartMission()
	{
		missionOver = true;
		gameMenu = "title";
		fadeControl.enabled = true;
		fadeControl.LoadScene(Application.loadedLevelName, true);
	}

	public virtual void ShowHint(string promptText)
	{
		menuControl.ShowHint(promptText, 5f);
	}

	public virtual void ShowTutorialHint(string promptText)
	{
		if (hintTracker.IndexOf(promptText) == -1)
		{
			menuControl.ShowHint(promptText, 5f);
			hintTracker += promptText;
		}
	}

	public virtual void HideHint()
	{
		menuControl.HideHint();
	}

	public virtual void WarpPlayer(Transform warpTransform)
	{
		if ((bool)playerControl)
		{
			playerControl.MovePlayer(warpTransform);
			UnityEngine.Object.Instantiate(Resources.Load("warpExplosion"), warpTransform.position, Quaternion.identity);
			PlayerInput playerInput = (PlayerInput)UnityEngine.Object.FindObjectOfType(typeof(PlayerInput));
			if ((bool)playerInput)
			{
				playerInput.targetPoint = warpTransform.position;
			}
			StartCoroutine(WarpCamera());
		}
	}

	public virtual IEnumerator WarpCamera()
	{
		return new _0024WarpCamera_0024568(this).GetEnumerator();
	}

	public virtual void ResetPlayer()
	{
		ClearFile(playerName);
		updateOutfit = true;
		StartCoroutine(ChangeScene("Title", true));
	}

	public virtual void ClearFile(string whichName)
	{
		worldID = 1;
		missionLevel = 1;
		skipsUsed = 0;
		missionAborted = false;
		filePath = whichName + "Data.txt";
		PlayerPrefs.SetString(filePath, string.Empty);
		ResetWorldLists();
		ReadMissionLevels();
		ResetShopLists();
	}

	public virtual void ResetWorldLists()
	{
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		array.Push(false);
		for (int i = 1; i < maxWorlds; i++)
		{
			array.Push(true);
		}
		worldLocked = (bool[])array.ToBuiltin(typeof(bool));
		worldScores = new int[Extensions.get_length((System.Array)worldLocked)];
		worldStars = new int[Extensions.get_length((System.Array)worldLocked)];
		worldLevels = new int[Extensions.get_length((System.Array)worldLocked)];
		for (int i = 0; i < Extensions.get_length((System.Array)worldLevels); i++)
		{
			int num = i + 1;
			if (num == Extensions.get_length((System.Array)worldLevels) && Extensions.get_length((System.Array)worldLevels) > 1)
			{
				num = 100;
			}
			tempAsset = (TextAsset)Resources.Load(appName + "/World" + num, typeof(TextAsset));
			tempString = tempAsset.text;
			array = tempString.Split(char.Parse("\n"));
			worldLevels[i] = array.length;
		}
	}

	public virtual void CreateMissionLists()
	{
		missionNames = new string[20];
		missionNames[1] = "Diversion";
		missionNames[2] = "CrystalRaceTrack";
		missionNames[3] = "DanceRoom";
	}

	public virtual int GetMissionID(string whichMissionName)
	{
		int result = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)missionNames); i++)
		{
			if (missionNames[i] == whichMissionName)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public virtual void CreateMasterItemLists()
	{
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		tempAsset = (TextAsset)Resources.Load("ItemList", typeof(TextAsset));
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		array2.Push("all");
		string text = string.Empty;
		TextAsset textAsset = (TextAsset)Resources.Load("ItemData", typeof(TextAsset));
		if ((bool)tempAsset)
		{
			string text2 = tempAsset.text;
			array = text2.Split(char.Parse("\n"));
			array.Pop();
			itemName = (string[])array.ToBuiltin(typeof(string));
			string text3 = textAsset.text;
			UnityScript.Lang.Array array3 = new UnityScript.Lang.Array();
			array3 = text3.Split(char.Parse("\t"));
			itemData = (string[])array3.ToBuiltin(typeof(string));
			for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
			{
				array = itemName[i].Split(char.Parse("_"));
				if (!RuntimeServices.EqualityOperator(text, array[0]))
				{
					object obj = array[0];
					if (!(obj is string))
					{
						obj = RuntimeServices.Coerce(obj, typeof(string));
					}
					text = (string)obj;
					if (text != string.Empty)
					{
						array2.Push(text);
					}
				}
			}
			categories = (string[])array2.ToBuiltin(typeof(string));
		}
		else
		{
			Debug.Log("itemList missing. Create a 'Resources/ItemList' containing a list of all the item filenames");
		}
		ResetShopLists();
	}

	public virtual void ResetShopLists()
	{
		itemCost = new int[Extensions.get_length((System.Array)itemData)];
		itemRarity = new int[Extensions.get_length((System.Array)itemData)];
		itemUnlocksLevel = new string[Extensions.get_length((System.Array)itemData)];
		itemAwardedFor = new string[Extensions.get_length((System.Array)itemData)];
		itemAwardedDesc = new string[Extensions.get_length((System.Array)itemData)];
		itemOwned = new bool[Extensions.get_length((System.Array)itemData)];
		itemRecent = new bool[Extensions.get_length((System.Array)itemData)];
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		tempAsset = (TextAsset)Resources.Load(appName + "/Prizes", typeof(TextAsset));
		tempString = tempAsset.text;
		string[] array2 = tempString.Split(char.Parse("\n"));
		int i = 0;
		string[] array3 = array2;
		for (int length = array3.Length; i < length; i++)
		{
			string[] array4 = array3[i].Split(char.Parse("|"));
			if (Extensions.get_length((System.Array)array4) == 5)
			{
				string text = array4[0];
				int num = FindItemSlot(text);
				itemCost[num] = UnityBuiltins.parseInt(array4[1]);
				itemRarity[num] = UnityBuiltins.parseInt(array4[2]);
				itemAwardedFor[num] = array4[3];
				itemAwardedDesc[num] = GetAwardDesc(array4[3]);
				itemUnlocksLevel[num] = array4[4];
				itemOwned[num] = false;
				itemRecent[num] = false;
				array.Push(text);
			}
		}
		missionShop = (string[])array.ToBuiltin(typeof(string));
	}

	public virtual void ChangeLogin(string newName)
	{
		hintTracker = string.Empty;
		playerName = newName;
		PlayerPrefs.SetString("playerName", playerName);
	}

	public virtual bool AlreadyInMissionShop(string outfitName)
	{
		bool result = false;
		for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
		{
			if (outfitName == missionShop[i])
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public virtual bool AlreadyInList(string checkItem, UnityScript.Lang.Array checkList)
	{
		bool result = false;
		for (int i = 0; i < checkList.length; i++)
		{
			if (RuntimeServices.EqualityOperator(checkItem, checkList[i]))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public virtual void MakeList(string whichType, bool isShop)
	{
		bool flag = true;
		string text = "recent";
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		if (isShop)
		{
			if (text == "recent" && recentOutfits.Length > 0)
			{
				array2 = new UnityScript.Lang.Array((IEnumerable)recentOutfits);
			}
			if (cheatsOn || whichType == "all")
			{
				for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
				{
					if (itemName[i].IndexOf("outfit_") != -1)
					{
						array2.Add(itemName[i]);
					}
					else
					{
						array.Add(itemName[i]);
					}
				}
			}
			else if (flag)
			{
				for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
				{
					if (itemName[i].IndexOf("outfit_") != -1)
					{
						int num = FindItemSlot(itemName[i]);
						if (itemOwned[num] && !itemRecent[num])
						{
							array2.Add(itemName[i]);
						}
					}
				}
				for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
				{
					if (missionShop[i].IndexOf("outfit_") != -1)
					{
						int num2 = FindItemSlot(missionShop[i]);
						if (!itemOwned[num2])
						{
							array2.Add(missionShop[i]);
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < Extensions.get_length((System.Array)missionShop); i++)
				{
					if (missionShop[i].IndexOf("outfit_") != -1)
					{
						int num3 = FindItemSlot(missionShop[i]);
						array2.Add(missionShop[i]);
					}
					else
					{
						array.Add(missionShop[i]);
					}
				}
				for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
				{
					if (itemName[i].IndexOf("outfit_") != -1)
					{
						int num4 = FindItemSlot(itemName[i]);
						if (itemOwned[num4] && !AlreadyInList(itemName[i], array2))
						{
							array2.Add(itemName[i]);
						}
					}
				}
			}
		}
		else
		{
			for (int i = 0; i < playerData.itemID.length; i++)
			{
				if (!RuntimeServices.EqualityOperator(playerData.itemType[i], whichType) && !(whichType == "all"))
				{
					continue;
				}
				object obj = playerData.itemID[i];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				tempString = (string)obj;
				if (!boardsOff || (boardsOff && tempString.IndexOf("board_") == -1 && tempString != string.Empty))
				{
					if (tempString.IndexOf("outfit_") != -1)
					{
						array2.Add(tempString);
					}
					else
					{
						array.Add(tempString);
					}
				}
			}
		}
		array = array2.Concat(array);
		shopList = (string[])array.ToBuiltin(typeof(string));
		if (!cheatsOn)
		{
			return;
		}
		string text2 = string.Empty;
		string text3 = string.Empty;
		tempAsset = (TextAsset)Resources.Load(appName + "/Daily", typeof(TextAsset));
		if ((bool)tempAsset)
		{
			text3 = tempAsset.text;
		}
		for (int i = 0; i < Extensions.get_length((System.Array)shopList); i++)
		{
			tempString = shopList[i];
			int num3 = FindItemSlot(tempString);
			if (itemRarity[num3] == 0 && tempString.IndexOf("outfit_") != -1 && text3.IndexOf(tempString) == -1)
			{
				text2 += tempString + "\n";
			}
		}
		MonoBehaviour.print("Outfits not used in the Prize or Daily Lists:\n" + text2);
	}

	public virtual void BuyItem(string newFilename, bool chargeIt)
	{
		if (tryingItOn)
		{
			playerData.BufferActiveItems();
		}
		else
		{
			int num = FindItemSlot(newFilename);
			itemOwned[num] = true;
			PlaySound((AudioClip)Resources.Load("Sounds/chaching", typeof(AudioClip)));
		}
		lastItemPurchased = newFilename;
		bool flag = true;
		for (int i = 0; i < playerData.itemID.length; i++)
		{
			if (RuntimeServices.EqualityOperator(playerData.itemID[i], newFilename))
			{
				int num2 = RuntimeServices.UnboxInt32(playerData.itemQuantity[i]);
				num2++;
				playerData.itemQuantity[i] = num2;
				flag = false;
			}
		}
		if (flag)
		{
			string[] array = newFilename.Split(char.Parse("_"));
			playerData.AddItem(array[0], newFilename, "0", "1");
			if (array[0] == "outfit")
			{
				playerData.BuyOutfit(newFilename);
			}
			else
			{
				CheckOutfits();
			}
		}
		if (chargeIt)
		{
			AdjustGems(-reviewItemCost);
		}
	}

	public virtual void CheckOutfits()
	{
		if (tryingItOn)
		{
			return;
		}
		MakeList("all", false);
		string empty = string.Empty;
		int num = default(int);
		int num2 = default(int);
		bool flag = false;
		for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
		{
			if (itemName[i].IndexOf("outfit") != -1)
			{
				flag = true;
				for (int j = 0; j < playerData.itemID.length; j++)
				{
					if (RuntimeServices.EqualityOperator(itemName[i], playerData.itemID[j]))
					{
						flag = false;
					}
				}
			}
			else
			{
				flag = false;
			}
			if (!flag)
			{
				continue;
			}
			empty = itemData[i];
			MonoBehaviour.print(empty);
			num = 0;
			num2 = 0;
			string[] array = empty.Split(char.Parse("\n"));
			int k = 0;
			string[] array2 = array;
			for (int length = array2.Length; k < length; k++)
			{
				string[] array3 = array2[k].Split(char.Parse("|"));
				if (!(array3[0] == "item") || (boardsOff && array3[1] == "board"))
				{
					continue;
				}
				num++;
				for (int j = 0; j < Extensions.get_length((System.Array)shopList); j++)
				{
					if (shopList[j] == array3[2])
					{
						num2++;
						break;
					}
				}
			}
			if (num != 0 && num == num2)
			{
				MonoBehaviour.print("OUTFIT MATCH: " + itemName[i] + " " + num + " " + num2);
				outfitNew = itemName[i];
				playerData.AddItem("outfit", outfitNew, "0", "1");
			}
		}
	}

	public virtual void AddBoost(float howMuch)
	{
		playerControl.AddBoost(howMuch);
	}

	public virtual void RandomizeOutfit(bool isShop)
	{
		for (int i = 0; i < Extensions.get_length((System.Array)categories); i++)
		{
			MakeList(categories[i], isShop);
			if (Extensions.get_length((System.Array)shopList) > 0 && categories[i] != "outfit")
			{
				string text = shopList[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)shopList))];
				if (isShop)
				{
					BuyItem(text, false);
				}
				StartCoroutine(ActivateItem(text));
			}
		}
	}

	public virtual void PrintOutfit()
	{
		string text = "name|outfit\ndesc|none\ngems|1000\n";
		string empty = string.Empty;
		for (int i = 0; i < playerData.itemID.length; i++)
		{
			if (RuntimeServices.EqualityOperator(playerData.itemActive[i], 1))
			{
				object obj = playerData.itemID[i];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				empty = (string)obj;
				string[] array = empty.Split(char.Parse("_"));
				if (array[0] != "outfit")
				{
					text += "item|" + array[0] + "|" + empty + "|1|1\n";
				}
			}
		}
		MonoBehaviour.print(text);
	}

	public virtual void AddToRecentOutfits(string whichOutfit)
	{
		int num = default(int);
		UnityScript.Lang.Array array = new UnityScript.Lang.Array((IEnumerable)recentOutfits);
		for (int i = 0; i < array.length; i++)
		{
			if (RuntimeServices.EqualityOperator(array[i], whichOutfit))
			{
				array.RemoveAt(i);
				break;
			}
		}
		array.Unshift(whichOutfit);
		num = FindItemSlot(whichOutfit);
		itemRecent[num] = true;
		recentOutfits = array.ToBuiltin(typeof(string)) as string[];
		MakeList("outfit", true);
		activeOutfit = whichOutfit;
		menuControl.ScrollToActiveOutfit();
	}

	public virtual IEnumerator ActivateItem(string whichFilename)
	{
		return new _0024ActivateItem_0024571(whichFilename, this).GetEnumerator();
	}

	public virtual void TryOnItem(string whichFilename)
	{
		RevertItem();
		tryingItOn = true;
		BuyItem(whichFilename, false);
		StartCoroutine(ActivateItem(whichFilename));
	}

	public virtual void RevertItem()
	{
		if (tryingItOn)
		{
			playerData.RevertActiveItems();
			playerData.UpdateCharacterOutfit("outfit");
			playerControl.ChangeOutfit();
			tryingItOn = false;
		}
	}

	public virtual void ReviewItem(string whichFilename)
	{
		RevertItem();
		reviewItemID = FindItemSlot(whichFilename);
		reviewItemCost = itemCost[reviewItemID];
		reviewItemFilename = whichFilename;
		string[] array = whichFilename.Split(char.Parse("_"));
		reviewItemCategory = array[0];
		reviewItemName = array[0];
		array = itemData[reviewItemID].Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "name")
			{
				reviewItemName = array3[1];
			}
			if (array3[0] == "desc")
			{
				reviewItemDesc = array3[1];
			}
		}
		if (cheatsOn)
		{
			reviewItemCost = 10;
		}
	}

	public virtual int FindItemSlot(string whichName)
	{
		int num = -1;
		for (int i = 0; i < Extensions.get_length((System.Array)itemName); i++)
		{
			if (itemName[i] == whichName)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.Log("Item file missing. Create an item file for: \"Resources/Items/" + whichName + "\"");
			num = 0;
		}
		return num;
	}

	public virtual void Blackout(bool whichWay)
	{
		if (whichWay)
		{
			blackoutControl.ChangeLight(Color.black, 1f);
		}
		else
		{
			blackoutControl.Revert(1f);
		}
	}

	public virtual void Main()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
