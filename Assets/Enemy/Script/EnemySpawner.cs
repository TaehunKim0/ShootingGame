using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemys;
    public Transform[] EnemySpawnTransform;
    public float CoolDownTime;
    public int MaxSpawnEnemyCount;

    private float _time = 0;
    private bool _isCoolDown = false;

    void Start()
    {
    }

    void Update()
    {
        UpdateCoolDownTime();
        if (false == _isCoolDown) SpawnEnemy();
    }

    void UpdateCoolDownTime()
    {
        if (true == _isCoolDown)
        {
            _time += Time.deltaTime;
            if (_time > CoolDownTime)
            {
                _time = 0f;
                _isCoolDown = false;
            }
        }
    }

    void SpawnEnemy()
    {
        int spawnCount = Random.Range(1, MaxSpawnEnemyCount);
        List<int> availablePositions = new List<int>(EnemySpawnTransform.Length);

        for (int i = 0; i < EnemySpawnTransform.Length; i++)
        {
            availablePositions.Add(i);
        }

        for (int i = 0; i < spawnCount; i++)
        {
            int randomEnemy = Random.Range(0, Enemys.Length);
            int randomPositionIndex = Random.Range(0, availablePositions.Count - 1);
            int randomPosition = availablePositions[randomPositionIndex];

            availablePositions.RemoveAt(randomPositionIndex);

            Instantiate(Enemys[randomEnemy], EnemySpawnTransform[randomPosition].position, Quaternion.identity);
        }

        _isCoolDown = true;
    }
}