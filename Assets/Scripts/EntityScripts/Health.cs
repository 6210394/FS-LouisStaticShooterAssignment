using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float maxHealth;

    public float health;

    private void Start()
    {
        health = maxHealth;
    }
    public float GetHealth()
    {
        return health;
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
        }

        if (health <= 0)
        {
            SendMessageUpwards("OnDeath", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
