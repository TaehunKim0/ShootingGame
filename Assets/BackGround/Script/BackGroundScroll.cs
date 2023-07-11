using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundScroll : MonoBehaviour
{
    public float ScrollSpeed;
    public Transform[] Backgrounds;

    private float _leftPosX;
    private float _imageWidth;

    void Start()
    {
        _imageWidth = Backgrounds[0].GetComponent<SpriteRenderer>().size.x; // 1000
        _leftPosX = Backgrounds[0].position.x - _imageWidth;
    }

    void Update()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            if (null == Backgrounds[i])
                continue;

            Backgrounds[i].position += new Vector3(-ScrollSpeed, 0, 0) * Time.deltaTime;

            if (Backgrounds[i].position.x < _leftPosX)
            {
                int index = i - 1;
                if (index < 0)
                {
                    index = Backgrounds.Length - 1;
                }

                Backgrounds[i].position = new Vector3(Backgrounds[index].position.x + _imageWidth, 0, 0);
            }
        }
    }
}
