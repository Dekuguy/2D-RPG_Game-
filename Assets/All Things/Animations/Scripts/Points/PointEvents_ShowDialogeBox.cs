using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_ShowDialogeBox : PointEvents_Base {
	[SerializeField]
	private string text;
	[SerializeField]
	private TextAsset asset;

	public override void Triggered()
	{
		if (text != "")
			DialogeBox.Show(text, false);
		else
			DialogeBox.Show(asset.text, true);
		base.Triggered();	
	}

	void Start()
	{
		finished = false;
	}

	void Update()
	{
		if (gotTriggered)
		{
			if (!DialogeBox.ShowBox())
			{
				finished = true;
			}
		}
	}
}
