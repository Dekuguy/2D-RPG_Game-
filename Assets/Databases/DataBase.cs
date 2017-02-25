using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase {

    private static ItemDatabase m_ItemDataBase;
    public static ItemDatabase Item
    {
        get
        {
            if(m_ItemDataBase == null)
            {
                m_ItemDataBase = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
            }
            return m_ItemDataBase;
        }
    }

    private static AllVariables m_BaseVariables;
    public static AllVariables AllVariables
    {
        get
        {
            if (m_BaseVariables == null)
            {
                m_BaseVariables = Resources.Load<AllVariables>("Databases/AllThingsVariables");
            }
            return m_BaseVariables;
        }
    }
}
