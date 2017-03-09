using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSign : InteractableBase
{
	[SerializeField]
	private bool Freeze = true;
    [SerializeField]
    [Header("Max. X characters!")]
    private string TextToShow;
    [SerializeField]
    private TextAsset alternateText;

    public override void OnInteract()
    {
        if (TextToShow != "")
            DialogeBox.Show(TextToShow, false, Freeze);
        else if (alternateText.text != "")
        {
            DialogeBox.Show(alternateText.text, true, Freeze);
        }
    }
}
