using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemDataBaseCreator : MonoBehaviour {
    
    [MenuItem("Custom Manager/Databases/Create ItemDataBase")]
    public static void CreatItemDataBase()
    {
        ItemDatabase newDatabase = ScriptableObject.CreateInstance<ItemDatabase>();
        AssetDatabase.CreateAsset(newDatabase, "Assets/ItemDatabase.asset");
        AssetDatabase.Refresh();
    }

    [MenuItem("Custom Manager/Databases/Create AllVariablesVariablesDatabase")]
    public static void CreatBarVariables()
    {
		AllVariablesDatabase newDatabaseVars = ScriptableObject.CreateInstance<AllVariablesDatabase>();
        AssetDatabase.CreateAsset(newDatabaseVars, "Assets/AllVariablesDatabase.asset");
        AssetDatabase.Refresh();
    }

	[MenuItem("Custom Manager/Databases/Create SettingsDatabase")]
	public static void CreateOptionVariables()
	{
		OptionsDatabase newDatabaseVars = ScriptableObject.CreateInstance<OptionsDatabase>();
		AssetDatabase.CreateAsset(newDatabaseVars, "Assets/OptionsDatabase.asset");
		AssetDatabase.Refresh();
	}
}
