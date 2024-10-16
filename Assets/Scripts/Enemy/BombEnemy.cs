using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public GameObject bombPreFab;
    public Transform firePoint;

    public float throwTime;
    private float throwCount;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            Instantiate(bombPreFab, firePoint.position, firePoint.rotation);
            throwCount = 0f; // Reset throw count after each throw
        }
    }
}
