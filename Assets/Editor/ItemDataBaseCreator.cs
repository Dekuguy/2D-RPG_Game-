using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemDataBaseCreator : MonoBehaviour {
    
    [MenuItem("Custom Manager/Databases/CreateItemDataBase")]
    public static void CreatItemDataBase()
    {
        ItemDatabase newDatabase = ScriptableObject.CreateInstance<ItemDatabase>();
        AssetDatabase.CreateAsset(newDatabase, "Assets/ItemDatabase.asset");
        AssetDatabase.Refresh();
    }

    [MenuItem("Custom Manager/All Living Things/CreatVariables")]
    public static void CreatBarVariables()
    {
        AllVariables newDatabaseVars = ScriptableObject.CreateInstance<AllVariables>();
        AssetDatabase.CreateAsset(newDatabaseVars, "Assets/AllThingsVariables.asset");
        AssetDatabase.Refresh();
    }
}
