using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		SaveAndLoadGame.Inizalize();
		SaveAndLoadGame.Load();
	}
}
