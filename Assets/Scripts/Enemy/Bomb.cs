using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D rig;
    private Player player;

    public int damage; // The amount of damage the bomb does. Adjust this value as needed. 10 is a standard damage value. 0 would mean the bomb does no damage. 100 would mean it does infinite damage. 10000 would be a super-powerful bomb that can destroy entire levels. 1000000000 would be a bomb that can destroy the entire universe.

    public float xAxis;
    public float yAxis;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(xAxis, yAxis), ForceMode2D.Impulse);

        Destroy(gameObject, 5f); // Destroys the bomb after 3 seconds.
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.OnHit(damage);
        }
    }
}
