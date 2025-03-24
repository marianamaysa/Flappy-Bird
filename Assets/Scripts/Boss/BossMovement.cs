using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float targetPositionX;
    [SerializeField] private int life = 5;

    [Header("Tiro")]
    [SerializeField] GameObject bulletPref;
    [SerializeField] private Transform pointBullet;
    [SerializeField] private int intervalShoot;
    private float timer;


    private bool checkBossPos = false;

    private void Start()
    {
        timer = intervalShoot;
    }

    void Update()
    {
        if (!checkBossPos)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= targetPositionX)
            {
                checkBossPos = true;
                transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);
            }
        }

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            timer = intervalShoot;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPref, pointBullet.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= 1;
            Debug.Log(life);

            if (life <= 0)
            {
                Morrer();
            }
        }

    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}
