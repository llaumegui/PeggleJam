using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode ShootKey;

    public GameObject BallPrefab;
    public Transform BaseCanon;
    public Transform CanonTip;

    [Space]
    [Header("Values")]
    public float MaxShootValue;
    [Range(0, 2)] public float ChargeSpeed = 1;

    bool _canShoot;

    bool _charging;


    float _chargeLerp;
    float _chargeValue;

    public Vector2 AimPosition = new Vector2();


    // Update is called once per frame
    void Update()
    {
        CheckCanShoot();

        if((Input.GetKey(ShootKey) || Input.GetMouseButton(0) && _canShoot))
		{
            Charge();
		}

        if((Input.GetMouseButtonUp(0) || Input.GetKeyUp(ShootKey)) && _charging)
		{
            ShootBall();
		}

        Aim();
    }

	private void Aim()
	{
        AimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("MousePos :" + Input.mousePosition);
        float angle = Vector2.SignedAngle(Vector2.up, AimPosition);
        BaseCanon.rotation = Quaternion.Euler(0, 0, angle);
	}

	private void ShootBall()
	{
        GameObject ball = Instantiate(BallPrefab, CanonTip.position, Quaternion.identity);
        if(ball.TryGetComponent(out Rigidbody2D ballRb))
		{
            Debug.Log("BallDetected");
            ballRb.AddForce(AimPosition.normalized * MaxShootValue * _chargeValue);
		}
        GameManager.Instance.CurrentBall = ball.GetComponent<Ball>();
	}

	private void Charge()
	{
        _charging = true;
        _chargeLerp += Time.deltaTime * ChargeSpeed;
        _chargeValue = Mathf.Abs(Mathf.Cos(_chargeLerp));
	}

	private void CheckCanShoot()
	{
        if (GameManager.Instance.CurrentBall == null)
            _canShoot = true;
        else
		{
            _canShoot = false;
            _chargeLerp = 0;
            _chargeValue = 0;
            _charging = false;
        }
	}
}
