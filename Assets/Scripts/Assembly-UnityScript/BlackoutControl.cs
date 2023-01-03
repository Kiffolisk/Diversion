using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class BlackoutControl : MonoBehaviour
{
	public Material[] backMat;

	private Color lightColor;

	private float fadeTime;

	private GameObject skyGO;

	private Color[] origBackColor;

	private Color origSkyColor;

	private Color[] currentBackColor;

	private Color currentSkyColor;

	private float startTime;

	private string state;

	private GameObject garbot;

	private Vector3 garbotHome;

	private Vector3 garbotTarget;

	public BlackoutControl()
	{
		state = "ready";
	}

	public virtual void Initialize()
	{
		origBackColor = (Color[])new UnityScript.Lang.Array(Extensions.get_length((System.Array)backMat)).ToBuiltin(typeof(Color));
		currentBackColor = (Color[])new UnityScript.Lang.Array(Extensions.get_length((System.Array)backMat)).ToBuiltin(typeof(Color));
		skyGO = GameObject.FindWithTag("Sky");
		for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
		{
			origBackColor[i] = backMat[i].color;
		}
		origSkyColor = skyGO.GetComponent<Renderer>().material.color;
		garbot = GameObject.Find("Garbot1");
		if ((bool)garbot)
		{
			garbotHome = garbot.transform.position;
			garbotTarget = garbotHome + new Vector3(0f, 50f, 0f);
		}
	}

	public virtual void ChangeTexture(Texture2D whichTexture)
	{
		for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
		{
			backMat[i].SetTexture("_MainTex", whichTexture);
		}
	}

	public virtual void ChangeColor(string whichColorString)
	{
		Color white = Color.white;
		string[] array = whichColorString.Split(char.Parse(","));
		if (Extensions.get_length((System.Array)array) == 4)
		{
			white.r = (float)UnityBuiltins.parseInt(array[0]) / 255f;
			white.g = (float)UnityBuiltins.parseInt(array[1]) / 255f;
			white.b = (float)UnityBuiltins.parseInt(array[2]) / 255f;
			white.a = (float)UnityBuiltins.parseInt(array[3]) / 255f;
		}
		else
		{
			MonoBehaviour.print("EZONE ALERT: Problem with color definition for this level: " + whichColorString);
		}
		for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
		{
			backMat[i].SetColor("_Color", white);
		}
	}

	public virtual void Update()
	{
		switch (state)
		{
		case "changing":
		{
			if ((bool)skyGO)
			{
				skyGO.GetComponent<Renderer>().material.color = Color.Lerp(currentSkyColor, lightColor, (Time.time - startTime) / fadeTime);
			}
			for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
			{
				backMat[i].SetColor("_Color", Color.Lerp(currentBackColor[i], lightColor, (Time.time - startTime) / fadeTime));
			}
			if ((bool)garbot)
			{
				garbot.transform.position = Vector3.Lerp(garbot.transform.position, garbotTarget, (Time.time - startTime) / fadeTime);
			}
			if (!(Time.time - startTime < fadeTime))
			{
				state = "changed";
			}
			break;
		}
		case "changed":
			break;
		case "reverting":
		{
			if ((bool)skyGO)
			{
				skyGO.GetComponent<Renderer>().material.color = Color.Lerp(currentSkyColor, origSkyColor, (Time.time - startTime) / fadeTime);
			}
			for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
			{
				backMat[i].SetColor("_Color", Color.Lerp(currentBackColor[i], origBackColor[i], (Time.time - startTime) / fadeTime));
			}
			if ((bool)garbot)
			{
				garbot.transform.position = Vector3.Lerp(garbot.transform.position, garbotHome, (Time.time - startTime) / fadeTime);
			}
			if (!(Time.time - startTime < fadeTime))
			{
				state = "ready";
			}
			break;
		}
		}
	}

	public virtual void ChangeLight(Color newLightColor, float newFadeTime)
	{
		if (state != "ready")
		{
			return;
		}
		Initialize();
		fadeTime = newFadeTime;
		lightColor = newLightColor;
		if (fadeTime == 0f)
		{
			if ((bool)skyGO)
			{
				skyGO.GetComponent<Renderer>().material.color = lightColor;
			}
			for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
			{
				backMat[i].color = lightColor;
			}
			state = "changed";
			return;
		}
		if ((bool)skyGO)
		{
			currentSkyColor = skyGO.GetComponent<Renderer>().material.color;
		}
		for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
		{
			currentBackColor[i] = backMat[i].GetColor("_Color");
		}
		state = "changing";
		startTime = Time.time;
	}

	public virtual void Revert(float newFadeTime)
	{
		fadeTime = newFadeTime;
		if (fadeTime == 0f)
		{
			if ((bool)skyGO)
			{
				skyGO.GetComponent<Renderer>().material.color = origSkyColor;
			}
			for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
			{
				backMat[i].SetColor("_Color", origBackColor[i]);
			}
			if ((bool)garbot)
			{
				garbot.transform.position = garbotHome;
			}
			state = "ready";
		}
		else
		{
			if ((bool)skyGO)
			{
				currentSkyColor = skyGO.GetComponent<Renderer>().material.color;
			}
			for (int i = 0; i < Extensions.get_length((System.Array)backMat); i++)
			{
				currentBackColor[i] = backMat[i].GetColor("_Color");
			}
			state = "reverting";
			startTime = Time.time;
		}
	}

	public virtual void Main()
	{
	}
}
