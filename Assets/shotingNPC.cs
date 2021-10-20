using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotingNPC : MonoBehaviour
{
    public Transform player;
    //public Transform friend;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private Vector3 direction;
    //private Vector3 frienddir;
    private void Start()
    {
        StartCoroutine(Wave());
    }
    void Update()
    {
        direction = player.position - transform.position;
        //frienddir = GameObject.Find("MeleeEnemy").transform.position - transform.position;
    }
    IEnumerator Wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            //if (frienddir.x / direction.x >= 0 && frienddir.y / direction.y >= 0 && Mathf.Abs(direction.x) > Mathf.Abs(frienddir.x) && Mathf.Abs(direction.y) > Mathf.Abs(frienddir.y))
            //{
            //    // friendly fire off
            //}
            if (direction.x <= 10 && direction.x >= -10 && direction.y <= 10 && direction.y >= -10)
            {
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
