using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System.Runtime.CompilerServices;

namespace StateMachine
{
    public class PlayerBase : StateRunner<PlayerBase>
    {
        [SerializeField] LayerMask groundLayer;
        [SerializeField] private BoxCollider2D boxCollider;
        private int playerDirection;
        private bool isJumping = false;
        private char wallDirection;

        protected override void Awake()
        {
            base.Awake();
        }

        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);

            return hit.collider != null;
        }

        public void SetPlayerDirection(int _playerDirection)
        {
            playerDirection = _playerDirection;
        }

        public int GetPlayerDirection()
        {
            return playerDirection;
        }

        public void SetJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                isJumping= false;
            }
        }

        public bool GetJump()
        {
            return isJumping;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Boss")
            {

            }

            else if (collision.gameObject.tag == "Enemy")
            {
                
            }
        }
    }
}

/*
 *  public bool IsWalled()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.52f, groundLayer);

            if (hit)
            {
                wallDirection = 'R';
            }
            else
            {
                hit = Physics2D.Raycast(transform.position, -transform.right, 0.55f, groundLayer);

                if (hit)
                {
                    wallDirection = 'L';
                }
                else
                {
                    wallDirection = 'n';
                }
            }

            return hit.collider != null;
*/