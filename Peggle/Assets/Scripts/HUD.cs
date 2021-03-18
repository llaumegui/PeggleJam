using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text ScoreText;

    private LevelManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        ScoreText.text = Mathf.Floor(_manager.Score).ToString();
    }

}
