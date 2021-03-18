using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBrick : BrickBehaviour
{
    LevelManager _level;
    void Start()
    {
        _level = (LevelManager)FindObjectOfType(typeof(LevelManager));
        _level.Targets++;
    }

	public override void Effect()
	{
        _level.Targets--;
	}

}
