using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coll : MonoBehaviour
{
    public int maxHeatlh = 5;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHeatlh;
        healthBar.SetMaxHealth(maxHeatlh);
    }
    public float moveSpeed = 5f;
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;

    private void Update()
    {
        //prototip
        /*Vector2 lookdir = mousePos - rb.position;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position += new Vector3(movement.x * 5f, movement.y * 5f, 0);
        }*/
        if (currentHealth <= 0)
        {
            Score.scoreValue = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookdir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;
        //HareketveBakma();// alternatif
    }
    public void HareketveBakma()
    {
        var yön = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var açı = Mathf.Atan2(yön.y, yön.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(açı, Vector3.forward);
        float hız = 5f * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            hız /= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            hız = 2f * Time.fixedDeltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(hız, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(hız, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, hız, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, hız, 0);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MeleeEnemy")
        {
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(1);
        }
    }
}
