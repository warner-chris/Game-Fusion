using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private DamageTestScript dmgScript;
    private float direction;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    [SerializeField] private float maxActiveTime;
    private float currActiveTime;
    private Rigidbody2D rb;

    private void Awake()
    {
        dmgScript = GetComponent<DamageTestScript>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (direction == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x + (speed * Time.fixedDeltaTime), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x - (speed * Time.fixedDeltaTime), rb.velocity.y);
        }

        //transform.Translate((), rb.transform.position.y, rb.transform.position.y);
        currActiveTime -= Time.deltaTime;

        if (currActiveTime <= 0)
        {
            Deactivate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        hit = true;
        dmgScript.CallKnockback(collision);
        boxCollider.enabled = false;
        Deactivate();
    }

    public void SetDirection(float _direction)
    {
        currActiveTime = maxActiveTime;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
