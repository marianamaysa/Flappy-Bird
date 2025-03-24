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


    private bool checkBossPos = false;

    void Update()
    {
        if (!checkBossPos)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= targetPositionX)
            {
                checkBossPos = true;
                transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);

                StartCoroutine(ShootRoutine());

            }
        }
    }

    void Shoot()
    {
        Debug.Log("chegou");
        GameObject bullet = Instantiate(bulletPref, pointBullet.position, Quaternion.identity);
        Bullets bulletScript = bullet.GetComponent<Bullets>();

        //bulletScript.SetDirection(Vector3.left);

        if (bulletScript != null)
        {
            bulletScript.origem = OrigemBullet.Enemy;
            bulletScript.SetDirection(Vector3.left);
        }
        else
        {
            Debug.Log("Componente Bullets não encontrado");
        }
    }

    [SerializeField] private float shootInterval;
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    public void Damage(int dano)
    {
        Debug.Log(life);
        life -= dano;

        if (life <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}
