using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour {

    private Dictionary<ItemType, int> m_Items = new Dictionary<ItemType, int>();

    public void AddItem(ItemType itemType)
    {
        AddItem(itemType, 1);
    }

    public void AddItem(ItemType itemType, int amount)
    {
        if (m_Items.ContainsKey(itemType) == true)
        {
            m_Items[itemType] += amount;
        }
        else
        {
            m_Items.Add(itemType, amount);
        }

        if (amount > 0)
        {
            ItemData itemdata = DataBase.Item.FindItem(itemType);
            if (itemdata != null)
            {
				if(itemdata.pickUpAnimation != ItemData.PickUpAnimation.None)
					Character.m_MovementModel.ShowPickuItem(itemdata);

                if (itemdata.EquipType == ItemData.EquipPosition.SwordHand)
                    Character.m_MovementModel.equipWeapon(itemType);
                if (itemdata.EquipType == ItemData.EquipPosition.ShieldHand)
                    Character.m_MovementModel.equipShield(itemType);
            }
        }
    }

	public int getItemAmount(ItemType item)
	{
		if (m_Items.ContainsKey(item))
		{
			return m_Items[item];
		}else
		{
			return 0;
		}
	}
}