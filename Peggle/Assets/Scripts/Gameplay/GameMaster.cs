using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public static GameMaster Instance;

	public Ball CurrentBall;
	public List<Brick> TargetBricks;

	public float Score;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
			Destroy(this);
	}

}
