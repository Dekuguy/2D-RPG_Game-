using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_ShowDialogeBox : PointEvents_Base {
	[SerializeField]
	private bool Freeze;
	[SerializeField]
	private string text;
	[SerializeField]
	private TextAsset asset;

	public override void Triggered()
	{
		if (text != "")
			DialogeBox.Show(text, false, Freeze);
		else
			DialogeBox.Show(asset.text, true, Freeze);
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
			if (!DialogeBox.isShowingBox())
			{
				finished = true;
			}
		}
	}
}
