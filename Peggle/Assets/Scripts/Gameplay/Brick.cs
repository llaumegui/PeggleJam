using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    bool _enlighten;

    [Space]
    [Header("Value")]
    public float ScoreValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_enlighten && GameMaster.Instance.CurrentBall.IsDestroyed)
		{
            EndBrick();
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
            _enlighten = true;

            if(collision.gameObject.TryGetComponent(out Rigidbody2D ballRb))
			{
                Vector2 normalSum = new Vector2();
                for(int i =0;i<collision.contactCount;i++)
				{
                    normalSum += collision.contacts[i].normal;
				}

                normalSum /= collision.contactCount;

                //changeImpulse;
			}
		}
	}

    void EndBrick()
	{
        GameMaster.Instance.Score += ScoreValue;

        if(GameMaster.Instance.TargetBricks.Contains(this))
		{
            GameMaster.Instance.TargetBricks.Remove(this);
		}

        Destroy(gameObject);
	}
}
