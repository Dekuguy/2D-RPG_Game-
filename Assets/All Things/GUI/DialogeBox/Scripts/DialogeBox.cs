using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogeBox : MonoBehaviour
{
    [SerializeField]
    private GameObject Visuals;
    [SerializeField]
    private GameObject NextIcon;
    [SerializeField]
    private Text TextObject;

    private string rawText;

    [SerializeField]
    private string[] TextBlocks;
    private int TextBlockCount = 0;
    [SerializeField]
    private string[] CurrentTextBlockWords;
    private int CurrentTextBlockWordsCount = 0;

    private string toDisplayText;

    private bool isShowing;
    private bool isTriggering;

    private bool isComplex;

    public static DialogeBox Instance;
    public static void Show(string text, bool isComplex)
    {
        Instance.Save(text, isComplex);
    }
	public static bool ShowBox()
	{
		return Instance.isShowing;
	}

    void Start()
    {
        Instance = this;

        Visuals.SetActive(false);
        TextObject.enabled = false;
        NextIcon.SetActive(false);
    }

    private void Save(string code, bool isComplex)
    {
        Visuals.SetActive(true);
        TextObject.enabled = true;

        isShowing = true;

        WorldFunktions.FreezeLivingMovement(true);

        this.isComplex = isComplex;
        rawText = code;
        Decode();
        ShowNextTextBlock();
    }

    private void Decode()
    {
        if (isComplex)
        {
            TextBlocks = rawText.Split(new string[] { "<new>" }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < TextBlocks.Length; i++)
            {
                TextBlocks[i] = TextBlocks[i].Substring(2);
            }
            for (int i = 0; i < TextBlocks.Length; i++)
            {
                TextBlocks[i] = TextBlocks[i].Substring(0, TextBlocks[i].Length - 2);
            }
        }
        else
        {
            TextBlocks = new string[1] { rawText };
        }
    }
    private void ShowNextTextBlock()
    {
        toDisplayText = "";

        if (TextBlockCount < TextBlocks.Length)
        {
            CurrentTextBlockWords = TextBlocks[TextBlockCount].Split(' ');
            TextBlockCount++;
            CurrentTextBlockWordsCount = 0;
            isTriggering = true;
        }
        else
        {
            isTriggering = false;
            End();
        }
    }

    private void GetTriggeredText()
    {
        if (CurrentTextBlockWordsCount < CurrentTextBlockWords.Length)
        {
            if (CurrentTextBlockWordsCount == 0)
                toDisplayText += CurrentTextBlockWords[CurrentTextBlockWordsCount];
            else
                toDisplayText += " " + CurrentTextBlockWords[CurrentTextBlockWordsCount];
            CurrentTextBlockWordsCount++;
        }
        else
        {
            isTriggering = false;
            NextIcon.SetActive(true);
        }
    }

    private void End()
    {
        WorldFunktions.FreezeLivingMovement(false);

        isShowing = false;

        Visuals.SetActive(false);
        TextObject.enabled = false;
        NextIcon.SetActive(false);

        TextBlockCount = 0;
        toDisplayText = "";
        CurrentTextBlockWordsCount = 0;
    }

    void Update()
    {
        if (isShowing)
        {
            if (isTriggering)
            {
                GetTriggeredText();
                TextObject.text = toDisplayText;
            }

            if (Input.GetButtonDown("Interact"))
            {
                if (isTriggering)
                {
                    isTriggering = false;
                    TextObject.text = string.Join(" ", CurrentTextBlockWords);
                }
                else
                {
                    NextIcon.SetActive(false);
                    ShowNextTextBlock();
                }
            }
        }
    }
}