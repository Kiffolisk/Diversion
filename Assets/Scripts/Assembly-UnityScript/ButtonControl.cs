using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class ButtonControl : MonoBehaviour
{
	public bool activateOnce;

	public bool activateWhenStandingOn;

	public GameObject onObject;

	public GameObject offObject;

	public GameObject[] targetObjects;

	public string promptText;

	public string state;

	public Color hitObjectColorOn;

	public Color hitObjectColorOff;

	public AudioClip turnOffAudio;

	public AudioClip turnOnAudio;

	public bool dontTurnOffTarget;

	private GameControl gameControl;

	private string statePrompt;

	private bool activated;

	public ButtonControl()
	{
		activateOnce = true;
		promptText = string.Empty;
		state = "on";
		hitObjectColorOn = Color.white;
		hitObjectColorOff = Color.white;
		statePrompt = string.Empty;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		int i = 0;
		GameObject[] array = targetObjects;
		for (int length = array.Length; i < length; i++)
		{
			if (!(ButtonActivated)array[i].GetComponent(typeof(ButtonActivated)))
			{
			}
		}
		ToggleObjects();
		if (Extensions.get_length((System.Array)targetObjects) == 0)
		{
			promptText = string.Empty;
		}
		if (promptText == string.Empty)
		{
			if (Extensions.get_length((System.Array)targetObjects) > 0)
			{
				statePrompt = "The " + targetObjects[0].name + " is now: ";
			}
		}
		else if (promptText == "none")
		{
			promptText = string.Empty;
		}
		promptText = string.Empty;
		statePrompt = string.Empty;
	}

	public virtual void ToggleObjects()
	{
		if (state == "on")
		{
			if ((bool)onObject)
			{
				onObject.SetActive(true);
			}
			if ((bool)offObject)
			{
				offObject.SetActive(false);
			}
			int i = 0;
			GameObject[] array = targetObjects;
			for (int length = array.Length; i < length; i++)
			{
				array[i].SetActive(true);
				array[i].SendMessage("TurnOn", SendMessageOptions.DontRequireReceiver);
			}
			return;
		}
		if ((bool)onObject)
		{
			onObject.SetActive(false);
		}
		if ((bool)offObject)
		{
			offObject.SetActive(true);
		}
		int j = 0;
		GameObject[] array2 = targetObjects;
		for (int length2 = array2.Length; j < length2; j++)
		{
			if (!dontTurnOffTarget && array2[j] != null)
			{
				array2[j].SendMessage("TurnOff", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual void OnEnable()
	{
		ToggleObjects();
	}

	public virtual void Activate()
	{
		if (activateOnce && activated)
		{
			MonoBehaviour.print("Button can only be activated once!");
			return;
		}
		activated = true;
		if (activateWhenStandingOn)
		{
			state = "off";
		}
		if (state == "on")
		{
			state = "off";
			if ((bool)turnOffAudio)
			{
				gameControl.PlaySound(turnOffAudio);
			}
		}
		else
		{
			state = "on";
			if ((bool)turnOnAudio)
			{
				gameControl.PlaySound(turnOnAudio);
			}
		}
		ToggleObjects();
		if (promptText != string.Empty)
		{
			gameControl.ShowHint(promptText);
		}
		else if (statePrompt != string.Empty)
		{
			gameControl.ShowHint(statePrompt + state);
		}
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent)
		{
			if (state == "off")
			{
				triggerObject.transform.parent.SendMessage("ChangeMaterialColor", hitObjectColorOn, SendMessageOptions.DontRequireReceiver);
			}
			else if (activateOnce && activated)
			{
				triggerObject.transform.parent.SendMessage("ChangeMaterialColor", hitObjectColorOn, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				triggerObject.transform.parent.SendMessage("ChangeMaterialColor", hitObjectColorOff, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent)
		{
			if (activateWhenStandingOn)
			{
				state = "off";
				ToggleObjects();
			}
			triggerObject.transform.parent.SendMessage("ChangeMaterialColor", Color.white, SendMessageOptions.DontRequireReceiver);
		}
	}

	public virtual void Main()
	{
	}
}
