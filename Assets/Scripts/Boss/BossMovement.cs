using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float targetPositionX;

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
            }
        }
    }
}
