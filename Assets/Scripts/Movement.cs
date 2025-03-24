using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] float rotationSpeed;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform pointBullet;
    [SerializeField] private float intervalShoot;

    private Rigidbody2D rb;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = intervalShoot;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            timer = intervalShoot;
        }

        Jump();

    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo") || collision.gameObject.CompareTag("BulletEnemy"))
        {
            GameManager.instance.GameOver();
            ScoreManager.instance.GameOverScore();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, pointBullet.position, Quaternion.identity);
    }
}