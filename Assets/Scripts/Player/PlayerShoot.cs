using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private PlayerController playerController;
    private PlayerBullet bullet;
    private ObjectPoolling objectPooling;
    private CameraShaker cameraShake;
    private Animator anim;


    [Header("Bullet Prefab")]
    [SerializeField] private PlayerBullet bulletPrefab;

    [Header("Bullet Exit Point")]
    [SerializeField] private Transform bulletExitPoint;

    [Header("Bullet After Attack Time")]
    [SerializeField] private float bulletCooldown;

    private bool isShooting;
    private float direction;

    // Bullet Exit Rotation Change
    private  const float X_VECTOR = 0.15f;
    private const float Y_VECTOR = 0.28f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        // Access
        bullet = FindObjectOfType<PlayerBullet>();
        objectPooling = FindObjectOfType<ObjectPoolling>();
        cameraShake = FindObjectOfType<CameraShaker>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            StartCoroutine(Shoot());
            ChangeBulletExitPosition();

            // Camera  settings 
            cameraShake.CameraShake();

            //player move speed dorp it ... not working fixed
            playerController.moveSpeed = 0.5f;

            // Shoot animation
            anim.SetBool("IsShooting", true);
        }
        else
        {
            playerController.moveSpeed = 5f;
            
            // Shoot animation
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

        // Object Pooling Bullet
        GameObject obj = objectPooling.GetPooledObject();
        obj.transform.position = bulletPosition;
        PlayerBullet bullet = obj.GetComponent<PlayerBullet>();
        bullet.SetDirection(direction);

        yield return new WaitForSeconds(bulletCooldown);

        isShooting = false;
    }

    void ChangeBulletExitPosition()
    {
        if (direction == -1)
            bulletExitPoint.transform.localPosition = new Vector3(-X_VECTOR, -Y_VECTOR, 0f);
        
        else      
            bulletExitPoint.transform.localPosition = new Vector3(X_VECTOR, -Y_VECTOR, 0f);
    
    }
}
