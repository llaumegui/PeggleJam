using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SetupLevel Setup;

    public float Score = 0;
    public float multiplicateur;
    public int ReversePower;

    [HideInInspector] public Coroutine coroutine;

    private int _life;
    public int Life { get { return _life; } }

    private HUD _hud;


    private void Awake()
    {
        _life = Setup.Lives;

        _hud = FindObjectOfType<HUD>();
    }
    public void LoseLife(int value)
    {
        if (value <= _life)
        {
            _life -= value;
            _hud.LooseALife();
            // if plus de vie fin de la partie
        }
    }

    public void GainALIfe(int value)
    {
        _life += value;
        _hud.Spawn();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Reverse"))
        {
            StartPower();
        }
    }

    IEnumerator Reversed()
    {
        yield return new WaitForSeconds(Setup.ReverseGravityTime);
        Physics2D.gravity *= -1;
    }

    public void StartPower()
    {
        if (ReversePower > 0)
        {
            Physics2D.gravity *= -1;
            coroutine = StartCoroutine(Reversed());
            ReversePower--;
        }
    }

    public void StopPower()
    {
        StopCoroutine(coroutine);
        Physics2D.gravity *= -1;

    }
}
