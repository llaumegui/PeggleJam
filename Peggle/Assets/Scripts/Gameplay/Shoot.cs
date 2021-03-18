using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode ShootKey;

    [Space]
    [Header("Values")]
    public float MaxShootValue;
    [Range(0, 2)] public float ChargeSpeed = 1;

    bool _canShoot;

    bool _charging;


    float _chargeLerp;
    float _chargeValue;


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
		throw new NotImplementedException();
	}

	private void ShootBall()
	{
		throw new NotImplementedException();
	}

	private void Charge()
	{
        _charging = true;
        _chargeLerp += Time.deltaTime * ChargeSpeed;
        _chargeValue = Mathf.Abs(Mathf.Cos(_chargeLerp));
	}

	private void CheckCanShoot()
	{
        if (GameMaster.Instance.CurrentBall == null)
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
