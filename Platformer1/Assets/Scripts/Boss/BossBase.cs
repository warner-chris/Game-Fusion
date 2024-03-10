using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System.Runtime.CompilerServices;

namespace StateMachine
{
    public class BossBase : StateRunner<BossBase>
    {
        [SerializeField] LayerMask playerLayer;
        private DamageTestScript dmgScript;
        private int currentDirection;
        private BoxCollider2D boxCollider;
        private bool sendKnockback;

        protected override void Awake()
        {
            base.Awake();
            boxCollider = GetComponent<BoxCollider2D>();
            dmgScript = GetComponent<DamageTestScript>();
        }

        public float GetPlayerPositionX()
        {
            float _playerPositionx = GameObject.FindWithTag("Player").transform.position.x;

            return _playerPositionx;
        }

        public void SetMovementDirection(int _setDirection)
        {
            currentDirection = _setDirection;
        }

        public int GetDirection()
        {
            return currentDirection;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector3 center = boxCollider.bounds.center;

            if (collision.gameObject.tag == "Player")
            {
                if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
                {
                    // Collision is mostly horizontal
                    if (normal.x > center.x)
                    {
                        dmgScript.CallKnockback(collision);
                    }
                    else
                    {
                        dmgScript.CallKnockback(collision);
                    }
                }
                else
                {
                    // Collision is mostly vertical
                    if (normal.y > center.y)
                    {
                        dmgScript.CallKnockback(collision);
                    }
                    else
                    {
                        dmgScript.CallKnockback(collision);
                    }
                }
            }


        }
    }

}
