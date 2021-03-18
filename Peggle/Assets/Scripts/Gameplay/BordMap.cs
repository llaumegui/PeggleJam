using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordMap : MonoBehaviour
{
    public enum side { left, right, top, bottom}

    public side currentSide;

    private LevelManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            if (currentSide == side.bottom)
            {
                Destroy(collision.gameObject);
                GameManager.Instance.CurrentBall = null;
                _manager.LoseLife(1);
            }
            else if (currentSide == side.top)
            {
                _manager.StopPower();
            }

        }
    }
}
