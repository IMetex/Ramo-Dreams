using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    private float direction;

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    private void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(Vector2.right * bulletSpeed * direction * Time.deltaTime);
    }

}


