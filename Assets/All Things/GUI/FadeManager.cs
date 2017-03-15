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
	private Color color = Color.black;

	private Color LerpColor;

	private bool isFading;
	private float fadenumber;
	private float fadingduration;
	private float targetfadenumber;

	private float currenttime;


	private static FadeManager FadeInstance;

	public static void Fade(float targetalpha, float duration)
	{
		FadeInstance.FadeLocal(targetalpha, duration);
	}
	public static void SetColor(Color color)
	{
		FadeInstance.SetColorLocal(color);
	}
	public static Color GetColor()
	{
		return FadeInstance.GetColorLocal();
	}
	public static void SetStandartColor()
	{
		FadeInstance.SetStandartColorLocal();
	}

	public void FadeLocal(float target, float duration)
	{
		targetfadenumber = target;
		fadingduration = duration;
		isFading = true;
	}
	public void SetColorLocal(Color color)
	{
		LerpColor = color;
	}
	public Color GetColorLocal()
	{
		return LerpColor;
	}
	public void SetStandartColorLocal()
	{
		LerpColor = color;
	}


	private void Start()
	{
		CanvasImage.color = new Color(0, 0, 0, 0);
		currenttime = 0;
		LerpColor = color;

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
		CanvasImage.color = Color.Lerp(new Color(0, 0, 0, 0), LerpColor, currenttime);
	}
}
