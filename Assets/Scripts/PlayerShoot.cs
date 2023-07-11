using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private PlayerController playerController;
    private PlayerBullet bullet;
    private Animator anim;

    //[SerializeField] private ObjectPoolling objectPool = null;
    [SerializeField] private PlayerBullet bulletPrefab;
    [SerializeField] private Transform bulletExitPoint;
    [SerializeField] private float fireCooldown;
    private bool isShooting;
    private float direction;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        bullet = FindObjectOfType<PlayerBullet>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {

            StartCoroutine(Shoot());
            anim.SetBool("IsShooting", true);
        }
        else
        {
            anim.SetBool("IsShooting", false);
        }
    }

    public IEnumerator Shoot()
    {
        isShooting = true;

        // Determine the direction based on player's sprite flipX
        direction = playerController.sprite.flipX ? -1f : 1f;

        // Calculate the position to instantiate the bullet
        Vector3 bulletPosition = bulletExitPoint.position + new Vector3(direction, 0f, 0f);
;

        // Instantiate the bullet
        PlayerBullet bullet = Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
        //GameObject obj = objectPool.GetPooledObject();
        //obj.transform.position = gameObject.transform.position;
        bullet.SetDirection(direction);
        yield return new WaitForSeconds(fireCooldown);
        isShooting = false;
    }
}
