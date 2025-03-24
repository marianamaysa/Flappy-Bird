using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrigemBullet { Player, Enemy }
public class Bullets : MonoBehaviour
{
    public OrigemBullet origem;
    [SerializeField] private float speed;
    [SerializeField] private int damage = 1;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("colidiu");
        if(origem == OrigemBullet.Player && other.CompareTag("Boss"))
        {
            Debug.Log("colidiu boss");

            BossMovement enemy = other.GetComponent<BossMovement>();
            if(enemy != null)
            {
                enemy.Damage(damage);
            }
        }
        else if (origem == OrigemBullet.Enemy && other.CompareTag("Player"))
        {
            Debug.Log("colidiu player");

            Movement player = other.GetComponent<Movement>();

            if(player != null)
            {
                GameManager.instance.GameOver();
            }
        }

        Destroy(gameObject);
    }

}
