using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern1 : MonoBehaviour
{
    public float MoveSpeed;
    public float Amplitude; // ������ ����(���Ʒ� �̵� �Ÿ�)

    private bool movingUp = true;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float verticalMovement = MoveSpeed * Time.deltaTime;

        // ���� �̵� ���̸鼭 ���� ��ġ�� ���� ��ġ���� �������� ���� ���
        if (movingUp && transform.position.y < startPosition.y + Amplitude)
        {
            transform.position += new Vector3(0f, verticalMovement, 0f);
        }
        // �Ʒ��� �̵� ���̸鼭 ���� ��ġ�� ���� ��ġ���� �������� ū ���
        else if (!movingUp && transform.position.y > startPosition.y - Amplitude)
        {
            transform.position -= new Vector3(0f, verticalMovement, 0f);
        }
        // ���� ������ ��� ��� �̵� ������ �ݴ�� ����
        else
        {
            movingUp = !movingUp;
        }

        transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0f, 0f);
    }
}