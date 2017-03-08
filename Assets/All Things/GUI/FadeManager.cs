using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
	//Has the Image or Color and the bool says which is fading
	[SerializeField]
	private Image CanvasImage;
	[SerializeField]
	private Color color;

	private bool isFading;
	private float fadenumber;
	private float fadingduration;
	private float targetfadenumber;

	private float currenttime;


	private static FadeManager FadeInstance;
	public static void Fade(float target, float duration)
	{
		FadeInstance.FadeLocal(target, duration);
	}

	public void FadeLocal(float target, float duration)
	{
		targetfadenumber = target;
		fadingduration = duration;
		isFading = true;
	}


	private void Start()
	{
		CanvasImage.color = new Color(0, 0, 0, 0);
		currenttime = 0;

		FadeInstance = this;
	}

	private void Update()
	{
		if (isFading)
		{
			if(currenttime > targetfadenumber)
			{
				currenttime -= Time.deltaTime / fadingduration;
				if(currenttime < targetfadenumber)
				{
					isFading = false;
				}
			}
			else if(currenttime < targetfadenumber)
			{
				currenttime += Time.deltaTime / fadingduration;
				if(currenttime > targetfadenumber)
				{
					isFading = false;
				}
			}
		}
		CanvasImage.color = Color.Lerp(new Color(0, 0, 0, 0), color, currenttime);
	}
}
