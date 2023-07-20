using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Life Collectibles more for Look Healt Script
            other.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
        
    }
}
