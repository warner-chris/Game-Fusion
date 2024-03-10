using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float weight;
    public float gravity;
    public float baseKnockback;
    public float knockbackScaling;
    public float launchAngle;

    // new variables for knockback angle calculation
    public float attackForce;
    public float targetWeight;

    private Rigidbody2D rb;
    private float knockbackTimer;
    private float currentDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockbackTimer = 0f;
        currentDamage = 0f;
    }

    void FixedUpdate()
    {
        if (knockbackTimer > 0)
        {
            float knockbackSpeed = CalculateKnockbackSpeed();
            float resistance = Mathf.Clamp01(knockbackSpeed * Time.fixedDeltaTime);
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, resistance);

            knockbackTimer -= Time.fixedDeltaTime;
        }
    }






    public void Knockedback(Vector2 direction, float damage, Vector2 attackDirection)
    {
        currentDamage = damage;
        float knockbackSpeed = CalculateKnockbackSpeed();

        // Calculate knockback angle
        float knockbackAngle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg + 180f;

        // Apply knockback force and angle to target
        rb.velocity = direction.normalized * knockbackSpeed;
        transform.rotation = Quaternion.Euler(0, 0, knockbackAngle);

        knockbackTimer = 1f;
    }

    private float CalculateKnockbackSpeed()
    {
        float weightFactor = weight / 100f;
        float damageFactor = Mathf.Pow(currentDamage + 2f, 1.4f);
        float scalingFactor = knockbackScaling / 20f;
        float launchAngleFactor = Mathf.Cos(launchAngle * Mathf.Deg2Rad);

        float knockbackSpeed = ((1f + scalingFactor) * baseKnockback * damageFactor * launchAngleFactor) / (weightFactor + 1f);

        knockbackSpeed *= gravity;

        return knockbackSpeed;
    }
}


/*
    public Knockback knockback;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knockbackTimer = 0f;
        currentDamage = 0f;




        if (knockbackTimer > 0)
        {
            float knockbackSpeed = CalculateKnockbackSpeed();
            float resistance = Mathf.Clamp01(knockbackSpeed * Time.fixedDeltaTime);
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, resistance);

            knockbackTimer -= Time.fixedDeltaTime;
        }
    }
*/