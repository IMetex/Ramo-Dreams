using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;

    [Header("Projectile Values")]
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletDuration = 1f;

    private float direction;
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void SetDirection(float dir)
    {
        hit = false;
        direction = dir;
        boxCollider.enabled = true;
        StartCoroutine(DisableBulletAfterDuration());
    }

    private void Update()
    {
        // Move the bullet in the specified direction
        if (!hit)
            transform.Translate(Vector2.right * bulletSpeed * direction * Time.deltaTime);

    }

    private System.Collections.IEnumerator DisableBulletAfterDuration()
    {
        yield return new WaitForSeconds(bulletDuration);
        gameObject.SetActive(false); // Disable the bullet

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        hit = true;
        // Explosion trigger
        anim.SetTrigger("explode");
        boxCollider.enabled = false;
    }
    private void Deactivate()
    {
        // Expolisin Visibility
        gameObject.SetActive(false);
    }

}


