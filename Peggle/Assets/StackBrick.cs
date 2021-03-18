using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBrick : BrickBehaviour
{
	public SpriteRenderer EnlightenRenderer;

	public override void Effect()
	{
		gameObject.GetComponent<SpriteRenderer>().color = EnlightenRenderer.color;

		Color.RGBToHSV(EnlightenRenderer.color,out float h, out float s, out float v);

		EnlightenRenderer.color = Color.HSVToRGB(h, s, v + .25f);
	}
}
