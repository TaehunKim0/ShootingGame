using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemName Name;
    public GameObject Prefab;
}

public enum ItemName
{
    HealthUp
}

public class ItemManager : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public static ItemManager instance;

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(gameObject);  // �� �ٲ� �� �ڱ� �ڽ� �ı� ����
        }
        else
            Destroy(this.gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SpawnItem(ItemName name, Vector3 position)
    {
        Item foundItem = Items.Find(item => item.Name == name);

        if (foundItem != null)
        {
            GameObject itemPrefab = foundItem.Prefab;
            Instantiate(itemPrefab, position, Quaternion.identity);
        }
    }
}