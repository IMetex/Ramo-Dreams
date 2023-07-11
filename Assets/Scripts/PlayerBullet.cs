using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletDuration = 1f;
    private float direction;

    public void SetDirection(float dir)
    {
        direction = dir;
        StartCoroutine(DisableBulletAfterDuration());
    }

    private void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(Vector2.right * bulletSpeed * direction * Time.deltaTime);

    }

    private System.Collections.IEnumerator DisableBulletAfterDuration()
    {
        yield return new WaitForSeconds(bulletDuration);
        gameObject.SetActive(false); // Disable the bullet
        // Or you can use Destroy(gameObject) to destroy the bullet instead
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Explosion trigger


    }

}


