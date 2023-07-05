using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ObjectPoolling objectPool = null;
    private bool isShooting;
    [SerializeField] private float attackCooldown;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
    private IEnumerator Shoot()
    {
        isShooting = true;
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(attackCooldown);
        isShooting = false;

    }

}
