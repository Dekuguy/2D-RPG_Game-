using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScenePauseMenu : MonoBehaviour {

	[SerializeField]
	private GameObject UI;

	private bool Active;

	private void Start()
	{
		Resume();
	}

	public void Pause()
	{
		Gamestates.isPause = true;
		Active = true;
		UI.SetActive(true);
	}

	public void Resume()
	{
		Gamestates.isPause = false;
		UI.SetActive(false);
		Active = false;
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene(Scene.MainMenu, true);
	}

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (Active)
			{
				Resume();
				GetComponent<DisableObjects>().EnableOBJ(false);
			}
			else
			{
				Pause();
			}
		}
	}
}
