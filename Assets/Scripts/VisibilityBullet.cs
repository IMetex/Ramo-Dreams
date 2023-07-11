using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityBullet : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x > 10f || transform.position.x < -10f)
        {
            gameObject.SetActive(false);
        }
    }
}
