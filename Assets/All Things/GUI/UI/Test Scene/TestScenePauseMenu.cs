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
		Active = true;
		WorldFunktions.FreezeLivingMovement(true);
		UI.SetActive(true);
	}

	public void Resume()
	{
		WorldFunktions.FreezeLivingMovement(false);
		UI.SetActive(false);
		Active = false;
	}

	public void BackToMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (Active)
			{
				Resume();
			}else
			{
				Pause();
			}
		}
	}
}
