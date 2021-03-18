using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    bool _enlighten;

    [Space]
    [Header("Value")]
    public int ScoreValue;
    public int Resistance = 1;

    public bool InstantEffect;


    private LevelManager _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_enlighten)
		{
            if (GameManager.Instance.CurrentBall==null)
            {
                Resistance--;
                if (Resistance <= 0)
                    EndBrick();

                if (TryGetComponent(out BrickBehaviour behaviour) && !InstantEffect)
                {
                    behaviour.Effect();
                }
            }

            if (TryGetComponent(out BrickBehaviour b) && InstantEffect)
            {
                b.Effect();
            }

            transform.GetChild(0).gameObject.SetActive(true);
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

        if (collision.gameObject.tag == "Explosion")
            EndBrick();
	}

    void EndBrick()
	{
        _manager.AddScore(ScoreValue);
        _manager.multiplicateur += 0.2f;

        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Renderer>().enabled = false;

        transform.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
    }
}
