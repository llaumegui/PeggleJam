using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBrick : BrickBehaviour
{
    public float Range = 1;
    public CircleCollider2D Explosion;

	public override void Effect()
	{
		Explosion.gameObject.SetActive(true);
		Explosion.radius = Range;

		StartCoroutine(Cooldown());
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(.5f);
		Explosion.gameObject.SetActive(false);
	}
}
