using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptacle : MonoBehaviour
{
    public float startingPos = .5f;
    public BezierSpline path;
    public float step = 0.01f;

    private LevelManager _manager;
    private Rigidbody2D _rb;

    public static int FreezeValue=1;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _manager = FindObjectOfType<LevelManager>();
        FreezeValue = 1;
    }

    private void Update()
    {
        if (startingPos >= 1)
        {
            startingPos = 1;
            step *= -1;
        }
        if (startingPos <= 0)
        {
            startingPos = 0;
            step *= -1;
        }
    }

    private void FixedUpdate()
    {
        transform.position = path.GetPoint(startingPos);
        startingPos += step * FreezeValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.currentBall = null;
        }
    }


    // remettre la freeze value a 1 si le level est terminé
}
