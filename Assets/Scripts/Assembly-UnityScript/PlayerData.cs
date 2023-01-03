using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PlayerData : MonoBehaviour
{
	public string characterName;

	public string gender;

	public string modelType;

	public string outfit;

	public string controltype;

	public float maxForce;

	public float maxTurningForce;

	public string trail;

	public float version;

	public int elapsedtime;

	public int gems;

	public int level;

	public int xp;

	public string lastsave;

	public string scene;

	public string plusid;

	public string facebookid;

	public string gamecenterid;

	public int skipsUsed;

	public int adsOn;

	public string summary;

	public UnityScript.Lang.Array itemType;

	public UnityScript.Lang.Array itemID;

	public UnityScript.Lang.Array itemActive;

	public UnityScript.Lang.Array itemQuantity;

	private UnityScript.Lang.Array itemTypeSaved;

	private UnityScript.Lang.Array itemIDSaved;

	private UnityScript.Lang.Array itemActiveSaved;

	private UnityScript.Lang.Array itemQuantitySaved;

	private string filePath;

	private string rawData;

	private TextAsset tempAsset;

	private string docPath;

	private string playerName;

	private GameControl gameControl;

	private PlayerControl playerControl;

	private bool firstDataLoad;

	private string tempData;

	public string lastSaveData;

	private float headsize;

	public PlayerData()
	{
		characterName = "default";
		gender = "female";
		modelType = "hover";
		outfit = string.Empty;
		controltype = "tilt";
		trail = "double";
		level = 1;
		plusid = string.Empty;
		facebookid = string.Empty;
		gamecenterid = string.Empty;
		rawData = string.Empty;
		docPath = string.Empty;
		playerName = string.Empty;
		firstDataLoad = true;
		tempData = string.Empty;
		lastSaveData = string.Empty;
		headsize = 1f;
	}

	public virtual void BufferActiveItems()
	{
		itemTypeSaved = new UnityScript.Lang.Array();
		itemIDSaved = new UnityScript.Lang.Array();
		itemActiveSaved = new UnityScript.Lang.Array();
		itemQuantitySaved = new UnityScript.Lang.Array();
		for (int i = 0; i < itemActive.length; i++)
		{
			itemTypeSaved.Push(itemType[i]);
			itemIDSaved.Push(itemID[i]);
			itemActiveSaved.Push(itemActive[i]);
			itemQuantitySaved.Push(itemQuantity[i]);
		}
	}

	public virtual void RevertActiveItems()
	{
		itemType = new UnityScript.Lang.Array();
		itemID = new UnityScript.Lang.Array();
		itemActive = new UnityScript.Lang.Array();
		itemQuantity = new UnityScript.Lang.Array();
		for (int i = 0; i < itemActiveSaved.length; i++)
		{
			itemType.Push(itemTypeSaved[i]);
			itemID.Push(itemIDSaved[i]);
			itemActive.Push(itemActiveSaved[i]);
			itemQuantity.Push(itemQuantitySaved[i]);
		}
	}

	public virtual void ReplaceWithRemoteData(string remoteData)
	{
		PlayerPrefs.SetString(filePath, remoteData);
	}

	public virtual void InitializeCharacter()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if (!Application.isEditor)
		{
			UnityScript.Lang.Array array = new UnityScript.Lang.Array();
			array = Application.dataPath.Split(char.Parse("/"));
			array.Pop();
			array.Pop();
			docPath = string.Empty;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(array);
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				docPath += current + "/";
				UnityRuntimeServices.Update(enumerator, current);
			}
			docPath += "Documents";
		}
		else
		{
			docPath = Application.dataPath + "/Documents";
		}
		string defaultCharacter = gameControl.defaultCharacter;
		if (characterName == "player")
		{
			playerName = gameControl.playerName;
			gameControl.playerData = this;
			filePath = playerName + "Data.txt";
			if (PlayerPrefs.GetString(filePath, string.Empty) != string.Empty)
			{
				rawData = PlayerPrefs.GetString(filePath);
				gameControl.firstTime = false;
			}
			else
			{
				gameControl.firstTime = true;
				MakeRawData(defaultCharacter);
				gameControl.activeOutfit = defaultCharacter;
				gender = gameControl.gender;
			}
			lastSaveData = rawData;
		}
		else
		{
			if (gender == "opposite")
			{
				if ((bool)gameControl)
				{
					if (gameControl.gender == "male")
					{
						gender = "female";
					}
					else
					{
						gender = "male";
					}
				}
				else
				{
					gender = "male";
				}
			}
			MakeRawData(defaultCharacter);
		}
		MakeItemList();
		UpdateCharacterOutfit("outfit");
		if (characterName == "player")
		{
			MakeSummary();
			ReadWorldData();
			ReadMissionData(gameControl.missionName, gameControl.worldID);
			firstDataLoad = false;
			if (gameControl.firstTime)
			{
				AddItem("outfit", defaultCharacter, "1", "1");
			}
		}
	}

	public virtual void ClearWorld(int whichWorld)
	{
		bool flag = false;
		rawData = PlayerPrefs.GetString(filePath);
		string[] array = rawData.Split(char.Parse("\n"));
		string text = string.Empty;
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "mission")
			{
				if (array3[1] == string.Empty + gameControl.missionName + whichWorld)
				{
					flag = true;
				}
				else
				{
					text += array2[i] + "\n";
				}
			}
			else
			{
				text += array2[i] + "\n";
			}
		}
		if (flag)
		{
			text += "mission|" + gameControl.missionName + whichWorld.ToString() + "|" + "0" + "|0|0|1|0|0\n";
		}
		PlayerPrefs.SetString(filePath, text);
		ReadWorldData();
		ReadMissionData(gameControl.missionName, gameControl.worldID);
	}

	public virtual bool UnlockMission(int whichWorld, int whichLevel)
	{
		whichLevel--;
		bool flag = true;
		rawData = PlayerPrefs.GetString(filePath);
		string[] array = rawData.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "mission" && array3[1] == string.Empty + gameControl.missionName + whichWorld && UnityBuiltins.parseInt(array3[2]) == whichLevel)
			{
				flag = false;
			}
		}
		if (flag)
		{
			string empty = string.Empty;
			filePath = playerName + "Data.txt";
			empty = PlayerPrefs.GetString(filePath);
			empty += "mission|" + gameControl.missionName + whichWorld.ToString() + "|" + whichLevel.ToString() + "|0|0|1|0|0\n";
			PlayerPrefs.SetString(filePath, empty);
			if (whichWorld == 100)
			{
				gameControl.worldLocked[Extensions.get_length((System.Array)gameControl.worldLocked) - 1] = false;
			}
			else
			{
				gameControl.worldLocked[whichWorld - 1] = false;
			}
		}
		return flag;
	}

	public virtual void MakeRawData(string whichOutfit)
	{
		int num = gameControl.FindItemSlot(whichOutfit);
		if (num != -1)
		{
			rawData = gameControl.itemData[num];
			if (gameControl.santa)
			{
				rawData += "\nitem|hair|hair_santahat|1|1";
			}
		}
		else
		{
			num = gameControl.FindItemSlot("outfit_default");
			rawData = gameControl.itemData[num];
			Debug.Log("Could not find data file Resources/Items/" + whichOutfit);
		}
	}

	public virtual void MakeItemList()
	{
		itemType = new UnityScript.Lang.Array();
		itemID = new UnityScript.Lang.Array();
		itemActive = new UnityScript.Lang.Array();
		itemQuantity = new UnityScript.Lang.Array();
		string[] array = rawData.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "var")
			{
				ConvertVar(array3[1], array3[2]);
			}
			else if (array3[0] == "item" && Extensions.get_length((System.Array)array3) == 5)
			{
				AddItem(array3[1], array3[2], array3[3], array3[4]);
			}
		}
	}

	public virtual void ReadMissionData(string thisMission, int worldID)
	{
		if (characterName != "player")
		{
			return;
		}
		bool flag = false;
		tempData = PlayerPrefs.GetString(filePath);
		string[] array = tempData.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "mission" && array3[1] == thisMission + worldID.ToString())
			{
				int num = UnityBuiltins.parseInt(array3[2]);
				if (Extensions.get_length((System.Array)array3) > 6 && Extensions.get_length((System.Array)gameControl.levelGems) > num)
				{
					gameControl.levelGems[num] = UnityBuiltins.parseInt(array3[3]);
					gameControl.levelStars[num] = UnityBuiltins.parseInt(array3[4]);
					gameControl.levelUnlocked[num] = UnityBuiltins.parseInt(array3[5]);
					gameControl.levelWins[num] = UnityBuiltins.parseInt(array3[6]);
					gameControl.levelAttempts[num] = UnityBuiltins.parseInt(array3[7]);
				}
				else if (gameControl.version == "1.2.6" && worldID == 4 && num > Extensions.get_length((System.Array)gameControl.levelGems))
				{
					flag = true;
					MonoBehaviour.print("CLEARED WORLD 4 (too many entries)");
				}
			}
		}
		if (worldID != 100)
		{
			if (!gameControl.worldLocked[worldID - 1])
			{
				gameControl.levelUnlocked[0] = 1;
			}
			for (int j = 0; j < Extensions.get_length((System.Array)gameControl.levelGems); j++)
			{
				if (gameControl.levelWins[j] > 0 && j + 1 < Extensions.get_length((System.Array)gameControl.levelGems))
				{
					gameControl.levelUnlocked[j + 1] = 1;
				}
			}
		}
		if (flag)
		{
			MonoBehaviour.print("There was a problem with World 4, so it was cleared");
			ClearWorld(4);
		}
	}

	public virtual void ReadWorldData()
	{
		gameControl.ResetWorldLists();
		tempData = PlayerPrefs.GetString(filePath);
		string[] array = tempData.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (!(array3[0] == "mission"))
			{
				continue;
			}
			for (int j = 1; j <= gameControl.maxWorlds; j++)
			{
				int num = j;
				if (j == gameControl.maxWorlds)
				{
					num = 100;
				}
				if (array3[1] == gameControl.gameScene + num)
				{
					gameControl.worldLocked[j - 1] = false;
					gameControl.worldScores[j - 1] = gameControl.worldScores[j - 1] + UnityBuiltins.parseInt(array3[3]);
					gameControl.worldStars[j - 1] = gameControl.worldStars[j - 1] + UnityBuiltins.parseInt(array3[4]);
					if (UnityBuiltins.parseInt(array3[2]) == gameControl.worldLevels[j - 1] - 1 && UnityBuiltins.parseInt(array3[6]) > 0 && j < gameControl.maxWorlds - 1)
					{
						gameControl.worldLocked[j] = false;
					}
				}
			}
		}
	}

	public virtual void BuyOutfit(string whichOutfit)
	{
		MakeRawData(whichOutfit);
		string[] array = rawData.Split(char.Parse("\n"));
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			string[] array3 = array2[i].Split(char.Parse("|"));
			if (array3[0] == "item" && Extensions.get_length((System.Array)array3) == 5)
			{
				AddItem(array3[1], array3[2], "0", "1");
			}
		}
	}

	public virtual void ActivateOutfit(string whichOutfit)
	{
		MakeRawData(whichOutfit);
		for (int i = 0; i < itemActive.length; i++)
		{
			itemActive[i] = 0;
		}
		string[] array = rawData.Split(char.Parse("\n"));
		int j = 0;
		string[] array2 = array;
		for (int length = array2.Length; j < length; j++)
		{
			string[] array3 = array2[j].Split(char.Parse("|"));
			if (!(array3[0] == "item"))
			{
				continue;
			}
			int i;
			for (i = 0; i < itemActive.length; i++)
			{
				string text = array3[2];
				bool flag = true;
				for (i = 0; i < itemID.length; i++)
				{
					if (RuntimeServices.EqualityOperator(itemID[i], text))
					{
						int num = RuntimeServices.UnboxInt32(itemQuantity[i]);
						num++;
						itemQuantity[i] = num;
						flag = false;
					}
				}
				if (flag)
				{
					string[] array4 = text.Split(char.Parse("_"));
					AddItem(array4[0], text, "0", "1");
				}
			}
		}
		int k = 0;
		string[] array5 = array;
		for (int length2 = array5.Length; k < length2; k++)
		{
			string[] array3 = array5[k].Split(char.Parse("|"));
			if (!(array3[0] == "item"))
			{
				continue;
			}
			for (int i = 0; i < itemActive.length; i++)
			{
				if (RuntimeServices.EqualityOperator(itemID[i], array3[2]))
				{
					itemActive[i] = 1;
				}
			}
		}
		for (int i = 0; i < itemActive.length; i++)
		{
			if (RuntimeServices.EqualityOperator(itemID[i], whichOutfit))
			{
				itemActive[i] = 1;
			}
		}
		gameControl.AddToRecentOutfits(whichOutfit);
	}

	public virtual void AddItem(string newType, string newFilename, string newActive, string newQuantity)
	{
		for (int i = 0; i < itemID.length; i++)
		{
			if (RuntimeServices.EqualityOperator(itemID[i], newFilename))
			{
				return;
			}
		}
		itemType.Add(newType);
		itemID.Add(newFilename);
		itemActive.Add(UnityBuiltins.parseInt(newActive));
		itemQuantity.Add(UnityBuiltins.parseInt(newQuantity));
		if (!gameControl.tryingItOn)
		{
			int num = gameControl.FindItemSlot(newFilename);
			gameControl.itemOwned[num] = true;
		}
	}

	public virtual void UpdateCharacterOutfit(string whichType)
	{
		outfit = string.Empty;
		headsize = 1f;
		for (int i = 0; i < itemID.length; i++)
		{
			if (!RuntimeServices.EqualityOperator(itemActive[i], 1))
			{
				continue;
			}
			if (characterName == "player" && whichType == "outfit")
			{
				object obj = itemID[i];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text = (string)obj;
				if (text.IndexOf("outfit_") != -1)
				{
					GameControl obj2 = gameControl;
					object obj3 = itemID[i];
					if (!(obj3 is string))
					{
						obj3 = RuntimeServices.Coerce(obj3, typeof(string));
					}
					obj2.activeOutfit = (string)obj3;
					object obj4 = itemID[i];
					if (!(obj4 is string))
					{
						obj4 = RuntimeServices.Coerce(obj4, typeof(string));
					}
					ActivateOutfit((string)obj4);
				}
			}
			string[] itemData = gameControl.itemData;
			GameControl obj5 = gameControl;
			object obj6 = itemID[i];
			if (!(obj6 is string))
			{
				obj6 = RuntimeServices.Coerce(obj6, typeof(string));
			}
			string text2 = itemData[obj5.FindItemSlot((string)obj6)];
			string[] array = text2.Split(char.Parse("\n"));
			int j = 0;
			string[] array2 = array;
			for (int length = array2.Length; j < length; j++)
			{
				string[] array3 = array2[j].Split(char.Parse("|"));
				if (array3[0] == gender || array3[0] == "any")
				{
					if (array3[1] == "0" || array3[1] == "1001")
					{
						outfit = array2[j] + "\n" + outfit;
					}
					else
					{
						outfit += array2[j] + "\n";
					}
				}
				else if (array3[0] == "var" && array3[1] != "elapsedtime")
				{
					ConvertVar(array3[1], array3[2]);
				}
			}
		}
		gameControl.AdjustBigHead(headsize);
	}

	public virtual void ConvertVar(string varName, string varValue)
	{
		switch (varName)
		{
		case "trail":
			trail = varValue;
			break;
		case "headsize":
			headsize = UnityBuiltins.parseFloat(varValue);
			gameControl.AdjustBigHead(headsize);
			goto case "controltype";
		case "controltype":
			controltype = varValue;
			if (characterName == "player")
			{
				gameControl.controltype = controltype;
			}
			break;
		case "maxForce":
			maxForce = UnityBuiltins.parseFloat(varValue) * 6000f;
			maxForce = 5400f;
			break;
		case "maxTurningForce":
			maxTurningForce = UnityBuiltins.parseFloat(varValue) * 6000f;
			maxTurningForce = 6000f;
			break;
		case "version":
			version = UnityBuiltins.parseFloat(varValue);
			break;
		case "elapsedtime":
			elapsedtime = UnityBuiltins.parseInt(varValue);
			break;
		case "gems":
			gems = UnityBuiltins.parseInt(varValue);
			break;
		case "level":
			level = UnityBuiltins.parseInt(varValue);
			break;
		case "xp":
			xp = UnityBuiltins.parseInt(varValue);
			break;
		case "lastsave":
			lastsave = varValue;
			break;
		case "gender":
			gender = varValue;
			if (characterName == "player")
			{
				gameControl.gender = gender;
			}
			break;
		case "scene":
			scene = varValue;
			break;
		case "plusid":
			plusid = varValue;
			break;
		case "facebookid":
			facebookid = varValue;
			break;
		case "gamecenterid":
			gamecenterid = varValue;
			break;
		case "skipsUsed":
			skipsUsed = UnityBuiltins.parseInt(varValue);
			if (characterName == "player")
			{
				gameControl.skipsUsed = skipsUsed;
			}
			break;
		case "adson":
		{
			int newValue = UnityBuiltins.parseInt(varValue);
			if (characterName == "player")
			{
				gameControl.UpdateAdsOn(newValue);
			}
			break;
		}
		case "tokens":
			gameControl.tokens = UnityBuiltins.parseInt(varValue);
			break;
		}
	}

	public virtual void MakeSummary()
	{
		summary = string.Empty;
		summary += "Welcome to Hover World (a0.1)\n\n";
		summary += "Name: " + characterName + "\n";
		summary += "Gender: " + gender + "\n";
		summary += "Level: " + level + "   XP: " + xp + "   Gems: " + gems + "\n";
		summary += "Last Save: " + lastsave + "\n";
		for (int i = 0; i < itemID.length; i++)
		{
			if (RuntimeServices.EqualityOperator(itemActive[i], 1))
			{
				summary += itemID[i] + " ";
			}
		}
	}

	public virtual void SaveData(string whichData)
	{
		if (characterName != "player")
		{
			return;
		}
		lastsave = DateTime.Now.ToString();
		elapsedtime = (int)((float)elapsedtime + Mathf.Round(Time.realtimeSinceStartup - gameControl.lastsavetime));
		gameControl.lastsavetime = Time.realtimeSinceStartup;
		PlayerPrefs.SetString("playerName", gameControl.playerName);
		PlayerPrefs.SetString("gender", gameControl.gender);
		gender = gameControl.gender;
		filePath = playerName + "Data.txt";
		string empty = string.Empty;
		empty += "var|controltype|" + controltype.ToString() + "\n";
		empty += "var|lastsave|" + lastsave.ToString() + "\n";
		empty += "var|elapsedtime|" + elapsedtime.ToString() + "\n";
		empty += "var|version|" + gameControl.version.ToString() + "\n";
		empty += "var|gender|" + gender.ToString() + "\n";
		empty += "var|scene|" + scene.ToString() + "\n";
		empty += "var|gems|" + gems.ToString() + "\n";
		empty += "var|level|" + level.ToString() + "\n";
		empty += "var|xp|" + xp.ToString() + "\n";
		empty += "var|plusid|" + plusid.ToString() + "\n";
		empty += "var|facebookid|" + facebookid.ToString() + "\n";
		empty += "var|gamecenterid|" + gamecenterid.ToString() + "\n";
		empty += "var|skipsUsed|" + gameControl.skipsUsed.ToString() + "\n";
		empty += "var|buildtarget|" + gameControl.buildTarget.ToString() + "\n";
		empty += "var|adson|" + gameControl.adsOn.ToString() + "\n";
		empty += "var|tokens|" + gameControl.tokens.ToString() + "\n";
		for (int i = 0; i < itemID.length; i++)
		{
			if (RuntimeServices.EqualityOperator(itemType[i], "outfit"))
			{
				empty += "item|" + itemType[i] + "|" + itemID[i] + "|" + itemActive[i].ToString() + "|" + itemQuantity[i].ToString() + "\n";
			}
		}
		rawData = PlayerPrefs.GetString(filePath);
		string[] array = rawData.Split(char.Parse("\n"));
		if (whichData == "level")
		{
			int num = gameControl.missionLevel - 1;
			int j = 0;
			string[] array2 = array;
			for (int length = array2.Length; j < length; j++)
			{
				string[] array3 = array2[j].Split(char.Parse("|"));
				if (array3[0] == "mission")
				{
					if (array3[1] != string.Empty + gameControl.missionName + gameControl.worldID)
					{
						empty += array2[j] + "\n";
					}
					else if (!(array3[2] == num.ToString()))
					{
						empty += array2[j] + "\n";
					}
				}
			}
			empty += "mission|" + gameControl.missionName + gameControl.worldID + "|" + num.ToString() + "|" + gameControl.levelGems[num].ToString() + "|" + gameControl.levelStars[num].ToString() + "|" + gameControl.levelUnlocked[num].ToString() + "|" + gameControl.levelWins[num].ToString() + "|" + gameControl.levelAttempts[num].ToString() + "\n";
		}
		else
		{
			int k = 0;
			string[] array4 = array;
			for (int length2 = array4.Length; k < length2; k++)
			{
				string[] array3 = array4[k].Split(char.Parse("|"));
				if (array3[0] == "mission")
				{
					empty += array4[k] + "\n";
				}
			}
		}
		PlayerPrefs.SetString(filePath, empty);
		lastSaveData = empty;
		ReadWorldData();
	}

	public virtual void Main()
	{
	}
}
