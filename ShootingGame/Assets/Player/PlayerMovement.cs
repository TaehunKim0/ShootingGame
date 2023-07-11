using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;
    private Transform _transform;

    public float MoveSpeed;

    void Start()
    {
        _transform = GetComponent<Transform>(); //���� ������ �ִ� ������Ʈ �� �߿� Transform ������Ʈ �������ڴ�.
    }
    void Update()
    {
        _moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow)) _moveInput.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) _moveInput.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) _moveInput.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) _moveInput.x = 1f;

        _transform.Translate(new Vector3(_moveInput.x, _moveInput.y, 0f) * MoveSpeed * Time.deltaTime);

        // �̰� �ƴ�
        // ī�޶��� ���� �ϴ���(0, 0, 0.0)�̸�, ���� �����(1.0 , 1.0)�̴�.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}