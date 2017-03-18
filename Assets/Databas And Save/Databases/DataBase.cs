using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase
{

	private static ItemDatabase m_ItemDataBase;
	public static ItemDatabase Item
	{
		get
		{
			if (m_ItemDataBase == null)
			{
				m_ItemDataBase = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
			}
			return m_ItemDataBase;
		}
	}

	private static AllVariablesDatabase m_AllVariablesDatabase;
	public static AllVariablesDatabase AllVariables
	{
		get
		{
			if (m_AllVariablesDatabase == null)
			{
				m_AllVariablesDatabase = Resources.Load<AllVariablesDatabase>("Databases/AllVariablesDatabase");
			}
			return m_AllVariablesDatabase;
		}
	}
}
