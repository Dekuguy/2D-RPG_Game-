using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// First Code
/*public class DialogeBox : MonoBehaviour
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
				if( i == TextBlocks.Length-1)
					TextBlocks[i] = TextBlocks[i].Substring(0, TextBlocks[i].Length);
				else
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
}*/

//Second Code

/*public class DialogeBox : MonoBehaviour
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

	private string toDisplayText;

	private bool isShowing;

	private bool isComplex;

	public static DialogeBox Instance;
	public static void Show(string text, bool isComplex, bool Freeze)
	{
		Instance.Save(text, isComplex, Freeze);
	}
	public static bool isShowingBox()
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

	private void Save(string code, bool isComplex, bool Freeze)
	{
		Visuals.SetActive(true);
		TextObject.enabled = true;

		isShowing = true;

		if(Freeze)
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
				if (i == TextBlocks.Length - 1)
					TextBlocks[i] = TextBlocks[i].Substring(0, TextBlocks[i].Length);
				else
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
			toDisplayText = TextBlocks[TextBlockCount];
		}
		else
		{
			End();
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
	}

	void Update()
	{
		if (isShowing)
		{
			TextObject.text = toDisplayText;

			if (Input.GetButtonDown("Interact"))
			{
				TextBlockCount++;
				NextIcon.SetActive(false);
				ShowNextTextBlock();
			}
		}
	}
}*/

public class DialogeBox : MonoBehaviour
{

	[SerializeField]
	private GameObject Visuals;
	[SerializeField]
	private GameObject NextIcon;
	[SerializeField]
	private Text TextObject;

	private string rawText;

	private bool isShowing;
	private bool isComplex;

	public static DialogeBox Instance;
	public static void Show(string text, bool isComplex, bool Freeze)
	{
		Instance.Save(text, isComplex, Freeze);
	}
	public static bool isShowingBox()
	{
		return Instance.isShowing;
	}

	private bool firsttime = true;

	private TextBlock[] TextBlocks;
	private int TextBlockCount = 0;

	void Start()
	{
		Instance = this;

		Visuals.SetActive(false);
		TextObject.enabled = false;
		NextIcon.SetActive(false);
	}

	private void Save(string code, bool isComplex, bool Freeze)
	{
		Visuals.SetActive(true);
		TextObject.enabled = true;

		isShowing = true;
		firsttime = true;

		if (Freeze)
			WorldFunktions.FreezeLivingMovement(true);

		this.isComplex = isComplex;
		rawText = code;
		Decode();
	}

	private void Decode()
	{
		if (isComplex)
		{

			string[] temparray = rawText.Split(new string[] { "<new>" }, System.StringSplitOptions.RemoveEmptyEntries);


			for (int i = 1; i < temparray.Length; i++)
			{
				temparray[i] = temparray[i].Substring(2);
			}
			for (int i = 0; i < temparray.Length; i++)
			{
				if (i == temparray.Length - 1)
					temparray[i] = temparray[i].Substring(0, temparray[i].Length);
				else
					temparray[i] = temparray[i].Substring(0, temparray[i].Length - 2);
			}

			TextBlocks = new TextBlock[temparray.Length];
			for (int i = 0; i < temparray.Length; i++)
			{
				TextBlocks[i] = new TextBlock(temparray[i]);
			}
		}
		else
		{
			TextBlocks = new TextBlock[1];
			TextBlocks[0] = new TextBlock(rawText);
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
	}

	void Update()
	{

		if (isShowing)
		{
			TextBlocks[TextBlockCount].Update();
			TextObject.text = TextBlocks[TextBlockCount].getText();


			if (Input.GetButtonDown("Interact"))
			{
				if (!firsttime || TextBlocks[TextBlockCount].hasFinished())
				{
					if (TextBlocks[TextBlockCount].hasFinished())
					{
						TextBlocks[TextBlockCount].Reset();
						TextBlockCount++;
						NextIcon.SetActive(true);

						if (TextBlockCount >= TextBlocks.Length)
						{
							End();
						}
					}
					else
					{
						TextBlocks[TextBlockCount].ShowAll();
						NextIcon.SetActive(true);
					}
				}
				firsttime = false;
			}
		}
	}
}

class TextBlock
{
	// General Variables

	private string words;
	private string returnText;

	private bool m_hasFinished = false;

	//Specific
	private int currentCount = 1;

	private string showedText;

	private bool startedComplex = false;
	//Functions
	public TextBlock(string rawText)
	{
		words = rawText;
		returnText = "";
	}

	public string getText()
	{
		return returnText;
	}
	public bool hasFinished()
	{
		return m_hasFinished;
	}

	public void ShowAll()
	{
		m_hasFinished = true;
		currentCount = words.Length;
	}
	public void Reset()
	{
		returnText = "";
		currentCount = 1;
		m_hasFinished = false;
	}

	public void Update()
	{
		currentCount++;
		if (currentCount < words.Length)
		{
			string startcount ="";
			string inbetween = "";
			string endcount = "";


			startedComplex = true;
			if (words[currentCount] == '<')
			{
				startcount = words.Substring(currentCount, words.Substring(currentCount).IndexOf('>')+1);
				inbetween = words.Substring(currentCount + startcount.Length, words.Substring(currentCount + startcount.Length).IndexOf('<'));
				endcount = words.Substring(currentCount + startcount.Length + inbetween.Length, words.Substring(currentCount + startcount.Length + inbetween.Length).IndexOf('>'));

				currentCount += startcount.Length + inbetween.Length + endcount.Length +1;
			}

			returnText = words.Substring(0, currentCount);
		}
		else
		{
			returnText = words;
			m_hasFinished = true;
		}
	}
}

