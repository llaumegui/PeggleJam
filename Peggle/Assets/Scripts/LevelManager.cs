using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SetupLevel Setup;
    
    public float Score = 0;
    public float multiplicateur;

    private int life;

    private void Awake()
    {
        life = Setup.Lives;
    }
    public void LoseLife(int value)
    {
        if (value <= life)
        {
            life -= value;
            // if plus de vie fin de la partie
        }
    }
}
