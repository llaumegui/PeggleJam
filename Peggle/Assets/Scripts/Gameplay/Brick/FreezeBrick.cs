using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBrick : BrickBehaviour
{
	public float TimeFreeze;
	public override void Effect()
	{
		Receptacle.FreezeValue = 0;
		StartCoroutine(Cooldown());
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(TimeFreeze);

		Receptacle.FreezeValue = 1;
	}
}
