using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [HideInInspector]
    public float Movespeed = 2f;

    public GameObject ExplodeFX;

    [SerializeField]
    private float LifeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Movespeed * Time.deltaTime, 0, 0));
    }

    private void OnDestroy()
    {
       Instantiate(ExplodeFX, transform.position, Quaternion.identity);
    }
}
