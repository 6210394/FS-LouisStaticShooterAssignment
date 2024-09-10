using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamager : MonoBehaviour
{
    [SerializeField]
    float damageAmount = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.SendMessageUpwards("TakeDamage", damageAmount, SendMessageOptions.DontRequireReceiver);
    }

}
