using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2f;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerController != null)
        {
            if (playerController.horizontalInput > 0)
            {
                transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
            }
        }
    }

}
