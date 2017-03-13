using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInizial : MonoBehaviour {

	[SerializeField]
	private float Speed;
	[SerializeField]
	private int Lives;
	[SerializeField]
	private int Rubins;

	[Space]

	[SerializeField]
	[Tooltip("The First is the - if possible - equipped one and the second on the other hand")]
	private List<StartUpItems> startupItems;

	private void Start()
	{
		if(Speed != 0)
			DataBase.AllVariables.baseVariables.character_Speed = Speed;
		if (Lives != 0)
			GetComponent<AttackableCharacter>().SetHearts(Lives);
		if (Rubins != 0)
			GetComponent<CharacterInventoryModel>().AddItemWithoutAnimation(ItemType.Ruby, Rubins);

		for(int i = 0; i < startupItems.Count; i++)
		{
			GetComponent<CharacterInventoryModel>().AddItemWithoutAnimation(startupItems[i].type, startupItems[i].amount);
		}
	}

	[System.Serializable]
	public class StartUpItems
	{
		public ItemType type;
		public int amount = 1;
	}
}
