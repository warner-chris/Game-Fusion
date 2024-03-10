using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float weight = 160f;
    public float startingHealth = 0f;
    public float currentHealth { get; private set; }
    private Rigidbody2D rb;
    public float knockbackTimer;
    private bool knockedBack = false;
    private float knockbackSpeed;
    private float currentDamageValue;
    public float gravity;
    Vector2 knockbackAngle;
    Vector2 inverseKnockbackAngle;

    void Start()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        knockbackTimer = 0f;
    }

    void FixedUpdate()
    {
        KnockingBack();
        Knockedback(inverseKnockbackAngle, currentDamageValue, knockbackAngle);  
    }

    public void CurrentHealth()
    {
        //Debug.Log(currentHealth);
    }

    public void TakeDamage(float damageAmount, float newKnockbackSpeed, Vector2 knockBackAngle2)
    {
        currentDamageValue = damageAmount;
        currentHealth += damageAmount;
        knockedBack = true;
        knockbackTimer = 0.2f;
        knockbackSpeed = newKnockbackSpeed;
        knockbackAngle = knockBackAngle2;
        inverseKnockbackAngle = knockBackAngle2;
    }

    private void KnockingBack()
    {
        if (knockbackTimer > 0)
        {
            float resistance = Mathf.Clamp01(knockbackSpeed * Time.fixedDeltaTime);
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, resistance);

            knockbackTimer -= Time.fixedDeltaTime;
        }

        else
        {
            knockedBack = false;
            knockbackTimer = 0;
        }
    }

    public void Knockedback(Vector2 attackDirection, float damage, Vector2 direction)
    {
        if (knockedBack == true)
        {
            // Calculate knockback angle
            float knockbackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg + 180f;

            // Apply knockback force and angle to target
            rb.velocity = direction.normalized * knockbackSpeed;
            transform.rotation = Quaternion.Euler(0, 0, knockbackAngle);
        }
    }

    public bool AskKnockBack()
    {
        return knockedBack;
    }

}