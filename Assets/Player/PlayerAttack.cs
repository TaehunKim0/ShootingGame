using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttack : MonoBehaviour
{
    public float AttackCoolDown; // ���� ��Ÿ�� 
    public float ProjectileMoveSpeed; // ����ü �߻� �ӵ�
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

            if (_time > AttackCoolDown) // �̰� �� �̷��� �Ѱ���
            {
                _time = 0f;
                _isCoolDown = false;
            }
        }
        
        if (Input.GetKey(KeyCode.Space) && false == _isCoolDown)
        {
            GameObject projectile = Instantiate(Projectile, ProjectileSpawnTransform.position, Quaternion.identity);
            // ����(����ü, ����ü ��ġ, ���ʹϾ�)
            projectile.GetComponent<ProjectileMovement>().Movespeed = ProjectileMoveSpeed; 
            // 

            _isCoolDown = true;
        }
    }
}
