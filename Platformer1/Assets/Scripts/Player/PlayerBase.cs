using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace StateMachine
{
    public class PlayerBase : StateRunner<PlayerBase>
    {
        [SerializeField] private GameObject scoreBoard;
        private Score scoreScript;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] LayerMask enemyLayer;
        [SerializeField] private BoxCollider2D boxCollider;
        private int playerDirection;
        private bool isJumping = false;
        private char wallDirection;
        [SerializeField] GameObject gameManager;
        private SoundEffects soundEffectsScript;

        protected override void Awake()
        {
            soundEffectsScript = gameManager.GetComponent<SoundEffects>();
            scoreScript = scoreBoard.GetComponent<Score>();
            base.Awake();
        }

        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);

            return hit.collider != null;
        }

        public bool HitEnemy()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, enemyLayer);

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

        public void UpdateScore(int _score)
        {
            if (_score == 15)
            {
                soundEffectsScript.PlayPotato();
            }
            else if (_score == 15)
            {
                soundEffectsScript.PlayCarrot();
            }
            else
            {
                soundEffectsScript.PlayChicken();
            }

            scoreScript.UpdateScore(_score);
        }

        /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector3 center = boxCollider.bounds.center;

            if (collision.gameObject.tag == "Boss")
            {
                if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
                {
                    // Collision is mostly horizontal
                    if (normal.x > center.x)
                    {
                        Debug.Log("Collision on right side");
                        //call damage Script
                    }
                    else
                    {
                        Debug.Log("Collision on left side");
                        //call damage script
                    }
                }
                else
                {
                    // Collision is mostly vertical
                    if (normal.y > center.y)
                    {
                        Debug.Log("Collision on top side");
                        //call damage script
                    }
                    else
                    {
                        Debug.Log("Collision on bottom side");
                        //call jump script
                        //enemy health script
                    }
                }
            }

            if (collision.gameObject.tag == "Enemy")
            {
                if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
                {
                    // Collision is mostly horizontal
                    if (normal.x > center.x)
                    {
                        Debug.Log("Collision on right side");
                        //call damage Script
                    }
                    else
                    {
                        Debug.Log("Collision on left side");
                        //call damage script
                    }
                }
                else
                {
                    // Collision is mostly vertical
                    if (normal.y > center.y)
                    {
                        Debug.Log("Collision on top side");
                        //call damage script
                    }
                    else
                    {
                        Debug.Log("Collision on bottom side");
                        //call jump script
                        //enemy health script
                    }
                }
            }
        }
        */
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