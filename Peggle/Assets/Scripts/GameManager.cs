using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion

    public List<Object> Levels = new List<Object>();

    [HideInInspector] public Ball CurrentBall;
    public List<Brick> TargetBricks;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }



}
