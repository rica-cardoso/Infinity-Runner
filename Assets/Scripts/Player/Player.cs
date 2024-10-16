using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;

    private Rigidbody2D rig;
    public Animator anim;

    public float speed;
    public float jumpForce;

    private bool isJumping;

    public GameObject buttletPrefab;
    public Transform firePoint;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            OnJump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnShoot();
        }
    }

    public void OnJump()
    {
        rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        anim.SetBool("jumping", true);
        isJumping = true;
    }

    public void OnShoot()
    {
        Instantiate(buttletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnHit(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }
}
