using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private LevelManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();
    }

    private void OnDestroy()
    {
        _manager.multiplicateur = 1;
    }


}
