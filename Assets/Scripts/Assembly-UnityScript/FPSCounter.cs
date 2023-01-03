using System;
using UnityEngine;

[Serializable]
public class FPSCounter : MonoBehaviour
{
	public float updateInterval;

	private double lastInterval;

	private int frames;

	private float fps;

	public FPSCounter()
	{
		updateInterval = 0.5f;
	}

	public virtual void Awake()
	{
		useGUILayout = false;
	}

	public virtual void Start()
	{
		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
	}

	public virtual void OnGUI()
	{
		GetComponent<GUIText>().text = "FPS: " + fps.ToString("f0");
	}

	public virtual void Update()
	{
		frames++;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (!((double)realtimeSinceStartup <= lastInterval + (double)updateInterval))
		{
			fps = (float)((double)frames / ((double)realtimeSinceStartup - lastInterval));
			frames = 0;
			lastInterval = realtimeSinceStartup;
		}
	}

	public virtual void Main()
	{
	}
}
