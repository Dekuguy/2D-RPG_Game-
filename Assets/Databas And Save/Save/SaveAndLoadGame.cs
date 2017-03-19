using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveAndLoadGame : MonoBehaviour {

	public static SaveOptions m_saveOptions;

	public static void Inizalize()
	{
		m_saveOptions = new SaveOptions();
	}

	public static void Save()
	{
		Debug.Log("Saving game...");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "\\playerinfo.dat", FileMode.Open);
		bf.Serialize(file, m_saveOptions);
		file.Close();
	}

	public static void Load()
	{
		Debug.Log("Loading game...");
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "\\playerinfo.dat", FileMode.Open);
		SaveOptions t = (SaveOptions)bf.Deserialize(file);
		file.Close();

		m_saveOptions = t;
	}
}
