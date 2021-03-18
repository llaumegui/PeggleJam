using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuObj : MonoBehaviour
{
	[HideInInspector]
	public MenuManager Root;


	public MenuManager.Item Type;

	[Space]
	public UnityEvent Click;
	public UnityEvent FeedBackSelect;

	private void OnMouseDown()
	{
		Select();
	}

	private void OnMouseOver()
	{
		Root.Hover(this);
	}

	public void FeedBackHover()
	{
		FeedBackSelect.Invoke();
	}

	public void Select()
	{
		Click.Invoke();
	}
}
