using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int maxHeatlh = 2;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHeatlh;
        healthBar.SetMaxHealth(maxHeatlh);
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if (currentHealth <= 0)
        {
            Score.scoreValue++;
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet1")
        {
            TakeDamage(1);
        }
    }
}
