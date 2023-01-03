using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class OutfitControl : MonoBehaviour
{
	private string docPath;

	private string filePath;

	private Color[] tempColors;

	private Color[] baseColors;

	private Color tempSkinColor;

	private Color tempColor;

	private float tempR;

	private float tempG;

	private float tempB;

	private float tempA;

	private int tempSlot;

	private int textureSize;

	private int chipSize;

	private Texture2D tempBitmap;

	private string tempName;

	private Color tempHairColor;

	private Color tempBitmapColor;

	private string[] turnOffObjects;

	private UnityScript.Lang.Array addOnPrefab;

	private UnityScript.Lang.Array addOnBone;

	private UnityScript.Lang.Array addOnGO;

	private GameControl gameControl;

	public OutfitControl()
	{
		docPath = string.Empty;
		filePath = string.Empty;
		textureSize = 1024;
		chipSize = 128;
		addOnPrefab = new UnityScript.Lang.Array();
		addOnBone = new UnityScript.Lang.Array();
		addOnGO = new UnityScript.Lang.Array();
	}

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		docPath = Application.dataPath + "/Outfits";
	}

	public virtual void ResetTurnOffObjects(string gender)
	{
		turnOffObjects = new string[75];
		if (gender.IndexOf("female") == -1)
		{
			turnOffObjects[17] = "emohair";
			turnOffObjects[18] = "earrings";
			turnOffObjects[19] = "mask";
			turnOffObjects[21] = "animehair";
			turnOffObjects[22] = "govnercap";
			turnOffObjects[23] = "bandanahair";
			turnOffObjects[24] = "guns";
			turnOffObjects[25] = "collar";
			turnOffObjects[26] = "hood";
			turnOffObjects[27] = "afro";
			turnOffObjects[29] = "baseballcap";
			turnOffObjects[30] = "antennae";
			turnOffObjects[31] = "adventurehat";
			turnOffObjects[32] = "knobblyhair";
			turnOffObjects[35] = "sideburns";
			turnOffObjects[36] = "moustache";
			turnOffObjects[37] = "wings";
			turnOffObjects[38] = "backpack";
			turnOffObjects[39] = "rockabillyhair";
			turnOffObjects[40] = "ponytail";
			turnOffObjects[41] = "helmet";
			turnOffObjects[42] = "bandanahair";
			turnOffObjects[43] = "goatee";
			turnOffObjects[52] = "headhair";
			turnOffObjects[53] = "artichokehair";
			turnOffObjects[54] = "alphahair";
			turnOffObjects[55] = "standardhair";
			turnOffObjects[61] = "neathair";
		}
		else
		{
			turnOffObjects[18] = "earrings";
			turnOffObjects[19] = "mask";
			turnOffObjects[21] = "antennae";
			turnOffObjects[22] = "alphahair";
			turnOffObjects[23] = "necklace";
			turnOffObjects[24] = "guns";
			turnOffObjects[25] = "govnercap";
			turnOffObjects[27] = "afro";
			turnOffObjects[28] = "skirt";
			turnOffObjects[29] = "bob";
			turnOffObjects[30] = "piggytails";
			turnOffObjects[32] = "wings";
			turnOffObjects[38] = "backpack";
			turnOffObjects[39] = "boof";
			turnOffObjects[40] = "ponytail";
			turnOffObjects[53] = "rightponytail";
			turnOffObjects[54] = "fronthairbits";
		}
	}

	public virtual void CheckHalfSlots(Texture2D baseTexture, string gender)
	{
		if (gender.IndexOf("female") != -1)
		{
		}
	}

	public virtual bool PixelNotVisible(Texture2D baseTexture, bool bottomHalf, int slot)
	{
		bool result = true;
		int num = (int)Mathf.Floor((slot - 1) / 8);
		int num2 = (slot - 1) % 8;
		if (bottomHalf)
		{
			tempColors = baseTexture.GetPixels((int)((float)(num2 * chipSize) + (float)chipSize * 0.5f), (int)((float)(num * chipSize) + (float)chipSize * 0.75f), 1, 1, 0);
		}
		else
		{
			tempColors = baseTexture.GetPixels((int)((float)(num2 * chipSize) + (float)chipSize * 0.5f), (int)((float)(num * chipSize) + (float)chipSize * 0.25f), 1, 1, 0);
		}
		if (tempColors[0].a != 0f)
		{
			result = false;
		}
		return result;
	}

	public virtual void DoAddOns()
	{
		gameControl.ScaleHead();
		if (addOnGO.length > 0)
		{
			RemoveAddOns();
		}
		for (int i = 0; i < addOnPrefab.length; i++)
		{
			object obj = addOnBone[i];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			GameObject gameObject = GameObject.Find((string)obj);
			if ((bool)gameObject)
			{
				GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Addons/" + addOnPrefab[i]), Vector3.zero, Quaternion.identity);
				if ((bool)gameObject2)
				{
					addOnGO.Add(gameObject2);
					gameObject2.transform.parent = gameObject.transform;
					gameObject2.transform.localPosition = Vector3.zero;
					gameObject2.transform.localEulerAngles = Vector3.zero;
				}
			}
			else
			{
				Debug.Log("ADDONS: Could not find the bone: " + addOnBone[i]);
			}
		}
	}

	public virtual void RemoveAddOns()
	{
		for (int i = 0; i < addOnGO.length; i++)
		{
			object obj = addOnGO[i];
			if (!(obj is UnityEngine.Object))
			{
				obj = RuntimeServices.Coerce(obj, typeof(UnityEngine.Object));
			}
			UnityEngine.Object.Destroy((UnityEngine.Object)obj);
		}
		addOnGO = new UnityScript.Lang.Array();
	}

	public virtual void TurnOffObjects(GameObject whichGO)
	{
		GameObject gameObject = null;
		whichGO.SetActiveRecursively(true);
		for (int i = 0; i < Extensions.get_length((System.Array)turnOffObjects); i++)
		{
			if (string.IsNullOrEmpty(turnOffObjects[i]))
			{
				continue;
			}
			if (turnOffObjects[i].IndexOf("guns") != -1)
			{
				gameObject = GameObject.Find("BlasterLeft");
				if ((bool)gameObject)
				{
					gameObject.SetActive(true);
				}
				gameObject = GameObject.Find("BlasterRight");
				if ((bool)gameObject)
				{
					gameObject.SetActive(true);
				}
			}
			else
			{
				gameObject = GameObject.Find(turnOffObjects[i]);
				if ((bool)gameObject)
				{
					gameObject.SetActive(true);
				}
			}
		}
	}

	public virtual void ChangeOutfit(Texture2D baseTexture, string outfitText)
	{
		if (addOnGO.length > 0)
		{
			RemoveAddOns();
		}
		addOnPrefab = new UnityScript.Lang.Array();
		addOnBone = new UnityScript.Lang.Array();
		addOnGO = new UnityScript.Lang.Array();
		tempColors = baseTexture.GetPixels(0);
		textureSize = (int)Mathf.Sqrt(Extensions.get_length((System.Array)tempColors));
		chipSize = textureSize / 8;
		tempHairColor = Color.clear;
		tempSkinColor = Color.clear;
		for (int i = 0; i < Extensions.get_length((System.Array)tempColors); i++)
		{
			tempColors[i] = new Color(0f, 1f, 0f, 0f);
		}
		baseTexture.SetPixels(0, 0, textureSize, textureSize, tempColors, 0);
		string text = string.Empty;
		if (Extensions.get_length(outfitText) < 40)
		{
			TextAsset textAsset = (TextAsset)Resources.Load("Outfits/" + outfitText, typeof(TextAsset));
			if ((bool)textAsset)
			{
				text = textAsset.text;
			}
		}
		if (text != string.Empty)
		{
			outfitText = text;
		}
		string gender = "male";
		if (outfitText.IndexOf("female") != -1)
		{
			gender = "female";
		}
		ResetTurnOffObjects(gender);
		string[] array = outfitText.Split(char.Parse("\n"));
		string empty = string.Empty;
		for (int i = 0; i < Extensions.get_length((System.Array)array); i++)
		{
			empty = array[i];
			string[] array2 = empty.Split(char.Parse("|"));
			if (Extensions.get_length((System.Array)array2) < 2)
			{
				break;
			}
			if (!int.TryParse(array2[1], out tempSlot))
			{
				MonoBehaviour.print(empty + ": " + Extensions.get_length(array2[1]));
				tempSlot = -1;
			}
			if (tempSlot == 24)
			{
				MonoBehaviour.print("weapons!");
			}
			if (array2[2] == "color")
			{
				tempR = UnityBuiltins.parseFloat(array2[3]);
				tempG = UnityBuiltins.parseFloat(array2[4]);
				tempB = UnityBuiltins.parseFloat(array2[5]);
				tempA = UnityBuiltins.parseFloat(array2[6]);
				tempColor = new Color(tempR, tempG, tempB, tempA);
				if (tempSlot == 0)
				{
					tempSkinColor = tempColor;
					if (array2[0].IndexOf("female") != -1)
					{
						ChangeColorSlot(baseTexture, tempSkinColor, 33);
						ChangeColorSlot(baseTexture, tempSkinColor, 34);
						ChangeColorSlot(baseTexture, tempSkinColor, 35);
						ChangeColorSlot(baseTexture, tempSkinColor, 36);
						ChangeColorSlot(baseTexture, tempSkinColor, 37);
						ChangeColorSlot(baseTexture, tempSkinColor, 41);
						ChangeColorSlot(baseTexture, tempSkinColor, 42);
						ChangeColorSlot(baseTexture, tempSkinColor, 43);
						ChangeColorSlot(baseTexture, tempSkinColor, 44);
						ChangeColorSlot(baseTexture, tempSkinColor, 45);
						ChangeColorSlot(baseTexture, tempSkinColor, 46);
						ChangeColorSlot(baseTexture, tempSkinColor, 47);
						ChangeColorSlot(baseTexture, tempSkinColor, 48);
						ChangeColorSlot(baseTexture, tempSkinColor, 49);
						ChangeColorSlot(baseTexture, tempSkinColor, 50);
						ChangeColorSlot(baseTexture, tempSkinColor, 51);
						ChangeColorSlot(baseTexture, tempSkinColor, 52);
						ChangeColorSlot(baseTexture, tempSkinColor, 55);
						ChangeColorSlot(baseTexture, tempSkinColor, 57);
						ChangeColorSlot(baseTexture, tempSkinColor, 58);
						ChangeColorSlot(baseTexture, tempSkinColor, 59);
						ChangeColorSlot(baseTexture, tempSkinColor, 60);
						ChangeColorSlot(baseTexture, tempSkinColor, 61);
						ChangeColorSlot(baseTexture, tempSkinColor, 62);
					}
					else
					{
						ChangeColorSlot(baseTexture, tempSkinColor, 33);
						ChangeColorSlot(baseTexture, tempSkinColor, 34);
						ChangeColorSlot(baseTexture, tempSkinColor, 45);
						ChangeColorSlot(baseTexture, tempSkinColor, 46);
						ChangeColorSlot(baseTexture, tempSkinColor, 47);
						ChangeColorSlot(baseTexture, tempSkinColor, 48);
						ChangeColorSlot(baseTexture, tempSkinColor, 49);
						ChangeColorSlot(baseTexture, tempSkinColor, 50);
						ChangeColorSlot(baseTexture, tempSkinColor, 51);
						ChangeColorSlot(baseTexture, tempSkinColor, 52);
						ChangeColorSlot(baseTexture, tempSkinColor, 56);
						ChangeColorSlot(baseTexture, tempSkinColor, 57);
						ChangeColorSlot(baseTexture, tempSkinColor, 58);
						ChangeColorSlot(baseTexture, tempSkinColor, 59);
						ChangeColorSlot(baseTexture, tempSkinColor, 63);
						ChangeColorSlot(baseTexture, tempSkinColor, 64);
					}
				}
				else if (tempSlot == 1001)
				{
					tempHairColor = tempColor;
				}
				else
				{
					ChangeColorSlot(baseTexture, tempColor, tempSlot);
				}
			}
			else if (array2[2] == "hair")
			{
				ChangeColorSlot(baseTexture, tempHairColor, tempSlot);
			}
			else if (array2[2] == "skin")
			{
				ChangeColorSlot(baseTexture, tempSkinColor, tempSlot);
			}
			else if (array2[2] == "addon")
			{
				addOnPrefab.Add(array2[3]);
				addOnBone.Add(array2[4]);
				GameObject gameObject = GameObject.Find(array2[4]);
				if ((bool)gameObject)
				{
					GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Addons/" + array2[3]), Vector3.zero, Quaternion.identity);
					if ((bool)gameObject2)
					{
						addOnGO.Add(gameObject2);
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = Vector3.zero;
						gameObject2.transform.localEulerAngles = Vector3.zero;
					}
				}
				else
				{
					Debug.Log("Could not find the bone: " + array2[4]);
				}
			}
			else if (array2[2] == "bitmap")
			{
				tempName = array2[3];
				tempBitmap = (Texture2D)Resources.Load("Bitmaps/" + tempName, typeof(Texture2D));
				if (!tempBitmap)
				{
					tempBitmap = (Texture2D)Resources.Load("Bitmaps/flameboard03", typeof(Texture2D));
					MonoBehaviour.print("MISSING BITMAP: Resources/Bitmaps/" + tempName);
				}
				tempBitmapColor = Color.clear;
				if (Extensions.get_length((System.Array)array2) > 4)
				{
					if (array2[4] == "skin")
					{
						tempBitmapColor = tempSkinColor;
					}
					else if (array2[4] == "hair")
					{
						tempBitmapColor = tempHairColor;
					}
					else if (Extensions.get_length((System.Array)array2) > 7)
					{
						tempR = UnityBuiltins.parseFloat(array2[4]);
						tempG = UnityBuiltins.parseFloat(array2[5]);
						tempB = UnityBuiltins.parseFloat(array2[6]);
						tempA = UnityBuiltins.parseFloat(array2[7]);
						tempColor = new Color(tempR, tempG, tempB, tempA);
						tempBitmapColor = tempColor;
					}
				}
				ChangeBitmapSlot(baseTexture, tempBitmap, tempSlot, tempBitmapColor);
			}
			if (tempSlot > 0 && tempSlot < Extensions.get_length((System.Array)turnOffObjects))
			{
				turnOffObjects[tempSlot] = null;
			}
		}
		baseTexture.Apply(false);
		CheckHalfSlots(baseTexture, gender);
	}

	public virtual void ChangeBitmapSlot(Texture2D baseTexture, Texture2D newTexture, int slot, Color hairColor)
	{
		int num = (int)Mathf.Floor((slot - 1) / 8);
		int num2 = (slot - 1) % 8;
		tempColors = newTexture.GetPixels(0);
		baseColors = baseTexture.GetPixels(num2 * chipSize, num * chipSize, chipSize, chipSize, 0);
		if (hairColor != Color.clear)
		{
			for (int i = 0; i < Extensions.get_length((System.Array)tempColors); i++)
			{
				tempColors[i].r = hairColor.r;
				tempColors[i].g = hairColor.g;
				tempColors[i].b = hairColor.b;
			}
		}
		for (int i = 0; i < Extensions.get_length((System.Array)tempColors); i++)
		{
			if (baseColors[i].a != 0f && tempColors[i].a != 1f)
			{
				tempColors[i] = tempColors[i] * tempColors[i].a + baseColors[i] * (1f - tempColors[i].a);
				tempColors[i].a = 1f;
			}
		}
		baseTexture.SetPixels(num2 * chipSize, num * chipSize, chipSize, chipSize, tempColors, 0);
	}

	public virtual void ChangeColorSlot(Texture2D baseTexture, Color newColor, int slot)
	{
		int num = (int)Mathf.Floor((slot - 1) / 8);
		int num2 = (slot - 1) % 8;
		for (int i = 0; i < chipSize * chipSize; i++)
		{
			tempColors[i] = newColor;
		}
		baseTexture.SetPixels(num2 * chipSize, num * chipSize, chipSize, chipSize, tempColors, 0);
	}

	public virtual void Main()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
