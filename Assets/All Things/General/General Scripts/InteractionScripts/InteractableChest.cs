using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : InteractableBase
{
    [SerializeField]
    private Sprite OpenChestSprite;
    [SerializeField]
    private ItemType ItemChest;
    [SerializeField]
    private int Amount = 1;

    private bool m_isOpen = false;

    public override void OnInteract()
    {
        if (!m_isOpen)
        {
            transform.GetComponentInChildren<SpriteRenderer>().sprite = OpenChestSprite;
            Character.m_InventoryModel.AddItem(ItemChest, Amount);
            m_isOpen = true;
        }
    }
}
