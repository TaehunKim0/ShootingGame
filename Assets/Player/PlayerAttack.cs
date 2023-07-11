using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttack : MonoBehaviour
{
    public float AttackCoolDown; // 공격 쿨타임 
    public float ProjectileMoveSpeed; // 투사체 발사 속도
    public GameObject Projectile;
    public Transform ProjectileSpawnTransform;

    private bool _isCoolDown = false;
    private float _time = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (null == Projectile)
        {
            Console.WriteLine("Projectile is null");
            return;
        }

        if (_isCoolDown)
        {
            _time += Time.deltaTime;

            if (_time > AttackCoolDown) // 이걸 왜 이렇게 한건지
            {
                _time = 0f;
                _isCoolDown = false;
            }
        }
        
        if (Input.GetKey(KeyCode.Space) && false == _isCoolDown)
        {
            GameObject projectile = Instantiate(Projectile, ProjectileSpawnTransform.position, Quaternion.identity);
            // 생성(투사체, 투사체 위치, 쿼터니언)
            projectile.GetComponent<ProjectileMovement>().Movespeed = ProjectileMoveSpeed; 
            // 

            _isCoolDown = true;
        }
    }
}
