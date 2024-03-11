using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float bossPositionX;
    private float targetPositionX;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int pointValue;
    [SerializeField] private float limitLeft;
    [SerializeField] private float limitRight;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetTargetPositionX();
    }

    public void Update()
    {
        rb.transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetPositionX, 0), movementSpeed * Time.deltaTime);
    }

    private void SetTargetPositionX()
    {
        float rand = Random.Range(limitLeft, limitRight);
        targetPositionX = rand;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBase>().UpdateScore(pointValue);
            Destroy(this.gameObject);
        }

        else if (collision.tag != "Food")
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyAfterPoints()
    {
        Destroy(this.gameObject);
    }
}
