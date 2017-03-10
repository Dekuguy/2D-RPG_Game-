using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHearts : MonoBehaviour
{

	[SerializeField]
	private GameObject sampleImage;
	[SerializeField]
	private int maxX = 8;
	[SerializeField]
	private float size = 1;

	[SerializeField]
	private Vector2 startposition;
	[SerializeField]
	private Vector2 Spacing;

	private List<Heart> Hearts;

	private void Start()
	{

		Hearts = new List<Heart>();

		int row;
		int rowindex;
		for (int i = 0; i < DataBase.AllVariables.baseVariables.character_MaxLives; i++)
		{
			row = i / maxX;
			rowindex = i - (maxX * row);
			Hearts.Add(new Heart(sampleImage, transform, startposition.x + Spacing.x * rowindex, startposition.y - row * Spacing.y, size));
		}
	}

	// Update is called once per frame
	void Update()
	{
		int row;
		int rowindex;
		for (int i = 0; i < Hearts.Count; i++)
		{
			row = i / maxX;
			rowindex = i - (maxX * row);
			Hearts[i].UpdatePosition(startposition.x + Spacing.x * rowindex, startposition.y - row * Spacing.y, size);

			if (i < Character.m_AttackableCharacter.Lives)
			{
				Hearts[i].Enable();
			}
			else {
				Hearts[i].Disable();
			}
		}
	}
}

class Heart
{
	private float x;
	private float y;

	private GameObject image;

	public Heart(GameObject image, Transform transform, float x, float y, float size)
	{
		this.image = MonoBehaviour.Instantiate(image, transform, false);
		this.image.transform.localPosition = new Vector3(x, y);
		this.x = x;
		this.y = y;
		this.image.transform.localScale = Vector2.one * size;
	}

	public void Enable()
	{
		image.SetActive(true);
	}
	public void Disable()
	{
		image.SetActive(false);
	}

	//Debug
	public void UpdatePosition(float x, float y)
	{
		this.x = x;
		this.y = y;
		this.image.transform.localPosition = new Vector3(x, y);
	}
	public void UpdatePosition(float x, float y, float size)
	{
		this.x = x;
		this.y = y;
		this.image.transform.localPosition = new Vector3(x, y);
		this.image.transform.localScale = Vector2.one * size;
	}
}
