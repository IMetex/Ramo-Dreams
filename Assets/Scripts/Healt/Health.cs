using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealt;
    public float currentHealt { get; private set; }
    private Animator animator;

    private void Awake()
    {
        currentHealt = startingHealt;
        animator = GetComponent<Animator>();
    }


    public void TakeDamage(float _damage)
    {
        currentHealt = Mathf.Clamp(currentHealt - _damage, 0, startingHealt);

        if (currentHealt > 0)
        {
            // player hit
            animator.SetTrigger("IsHurt");
        }
        else
        {
            // player dead
            animator.SetTrigger("IsDead");
        }

    }
}
