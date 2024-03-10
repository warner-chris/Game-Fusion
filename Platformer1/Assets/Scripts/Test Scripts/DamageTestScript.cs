using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTestScript : MonoBehaviour
{
    [SerializeField] private float damage;
    public float gravity;
    public float baseKnockback = 5;
    public float launchAngle;
    public float knockbackScaling;

    // new variables for knockback angle calculation
    public float attackForce;
    public float targetWeight;
    private float currentDamage;
    float knockbackSpeed;
    private float knockbackTimer;
    public PlayerHealth targetObject;
    public Vector2 knockBackAngle2;




    public void CallKnockback(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            targetObject = collision.gameObject.GetComponent<PlayerHealth>();
            //Do knockback stuff
            gravity = targetObject.gravity;
            currentDamage = damage + targetObject.currentHealth;
            knockbackSpeed = CalculateKnockbackSpeed(targetObject.weight);
            launchAngle = Mathf.Atan2(DetermineKnockbackAngle().y, DetermineKnockbackAngle().x) * Mathf.Rad2Deg + 180f;
            knockBackAngle2 = DetermineKnockbackAngle();
            targetObject.TakeDamage(damage, knockbackSpeed, knockBackAngle2);
        }

        else if (collision.gameObject.tag == "Boss")
        {
            targetObject = collision.gameObject.GetComponent<PlayerHealth>();
            //Do knockback stuff
            gravity = targetObject.gravity;
            currentDamage = damage + targetObject.currentHealth;
            knockbackSpeed = CalculateKnockbackSpeed(targetObject.weight);
            launchAngle = Mathf.Atan2(DetermineKnockbackAngle().y, DetermineKnockbackAngle().x) * Mathf.Rad2Deg + 180f;
            knockBackAngle2 = DetermineKnockbackAngle();
            targetObject.TakeDamage(damage, knockbackSpeed, knockBackAngle2);
        }
    }

        private float CalculateKnockbackSpeed(float weight)
    {
        float weightFactor = weight / 100f;
        float damageFactor = Mathf.Pow(currentDamage + 2f, 1.4f);
        float scalingFactor = knockbackScaling / 20f;
        float launchAngleFactor = Mathf.Cos(launchAngle * Mathf.Deg2Rad);

        float knockbackSpeed = ((1f + scalingFactor) * baseKnockback * damageFactor * launchAngleFactor) / (weightFactor + 1f);
        //-------------------------------------------------------------------------------------------SET TO GRAVITY SCALE OF TARGET----------------------------------------------------------------------------
        knockbackSpeed *= gravity;

        return knockbackSpeed;
    }

    private Vector2 DetermineKnockbackAngle()
    {
        Vector2 direction = targetObject.transform.position - this.transform.position;
        return direction;
    }

    public float SetKnockbackSpeed()
    {
        return knockbackSpeed;
    }
}





