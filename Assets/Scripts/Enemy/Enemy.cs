using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public Player player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void ApplyDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            collision.GetComponent<Projectile>().OnHit();
            ApplyDamage(collision.GetComponent<Projectile>().damage);
        }
    }
}
