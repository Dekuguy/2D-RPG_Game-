using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

	public void StartGame()
	{
		SceneManager.LoadScene(Scene.TestLevel, true);
	}
	public void EndGame()
	{
		SceneManager.EndGame();
	}
}
