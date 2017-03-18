using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : ScriptableObject {

    public List<ItemData> Data;

    public ItemData FindItem(ItemType itemType)
    {
        for(int i = 0; i< Data.Count; i++)
        {
            if(Data[i].Type == itemType)
            {
                return Data[i];
            }
        }
        return null;
    }
}

[System.Serializable]
public class ItemData
{
    public enum PickUpAnimation
    {
        OneHand,
        TwoHands,
		None,
    }

    public enum EquipPosition
    {
        NotEquippable,
        SwordHand,
        ShieldHand,
    }

    public ItemType Type;
    public GameObject Prefab;
    public EquipPosition EquipType;
    public PickUpAnimation pickUpAnimation;
    public float timetoShowAnimation = 1f;
}
