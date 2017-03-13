using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

	public void StartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
	public void EndGame()
	{
		Application.Quit();
	}
}
