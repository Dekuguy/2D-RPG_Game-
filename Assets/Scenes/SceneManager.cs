using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	public static void LoadScene( Scene scene, bool save)
	{
		SaveAndLoadGame.Save();
		switch (scene)
		{
			case Scene.MainMenu:
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
				break;
			case Scene.TestLevel:
				UnityEngine.SceneManagement.SceneManager.LoadScene(1);
				break;
		}
	}

	public static void EndGame()
	{
		SaveAndLoadGame.Save();
		Application.Quit();
	}
}

public enum Scene
{
	MainMenu = 0,
	TestLevel = 1,
}
