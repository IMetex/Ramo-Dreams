using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealt;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    public float currentHealt { get; private set; }

    private Animator animator;
    public bool isDead; // GameOver

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
            if (!isDead)
            {
                animator.SetTrigger("IsDead");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;

                isDead = true;
            }
        }

    }

    public void AddHealth(float _value)
    {
        // Collect Heart 
        currentHealt = Mathf.Clamp(currentHealt + _value, 0, startingHealt);
    }
}
