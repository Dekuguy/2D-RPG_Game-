using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSign : InteractableBase
{
    [SerializeField]
    [Header("Max. X characters!")]
    private string TextToShow;
    [SerializeField]
    private TextAsset alternateText;

    public override void OnInteract()
    {
        if (TextToShow != "")
            DialogeBox.Show(TextToShow, false);
        else if (alternateText.text != "")
        {
            DialogeBox.Show(alternateText.text, true);
        }
    }
}
