using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private PlayerController playerController;
    private PlayerBullet bullet;
    private ObjectPoolling objectPooling;
    private Animator anim;

    [SerializeField] private ObjectPoolling objectPool = null;
    [SerializeField] private PlayerBullet bulletPrefab;
    [SerializeField] private Transform bulletExitPoint;
    [SerializeField] private float bulletCooldown;
    private bool isShooting;
    private float direction;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        bullet = FindObjectOfType<PlayerBullet>();
        objectPooling = FindObjectOfType<ObjectPoolling>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(Shoot());
            //player move speed dorp it
            playerController.moveSpeed = 2f;
            anim.SetBool("IsShooting", true);
        }
        else
        {
            playerController.moveSpeed = 5f;
            anim.SetBool("IsShooting", false);
        }

        BulletExitPosition();
    }

    public IEnumerator Shoot()
    {
        isShooting = true;


        // Determine the direction based on player's sprite flipX
        direction = playerController.sprite.flipX ? -1f : 1f;

        // Calculate the position to instantiate the bullet
        Vector3 bulletPosition = bulletExitPoint.position + new Vector3(direction, 0f, 0f);

        // Object Pooling 
        GameObject obj = objectPooling.GetPooledObject();
        obj.transform.position = bulletPosition;
        PlayerBullet bullet = obj.GetComponent<PlayerBullet>();
        bullet.SetDirection(direction);

        yield return new WaitForSeconds(bulletCooldown);

        isShooting = false;

        // player move old speed
        playerController.moveSpeed = 5f;
    }

    void BulletExitPosition()
    {
        if (direction == -1)
        {
            bulletExitPoint.transform.localPosition = new Vector3(-0.13f,-0.28f,0f);
        }
        else
        {
             bulletExitPoint.transform.localPosition = new Vector3(0.13f,-0.28f,0f);
        }
    }
}
