/*using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Statemachine
{
    public class KainBase : StateRunner<KainBase>
    {
        Rigidbody2D _rb;
        [SerializeField] private int basicAttackMaxCooldown;
        private int basicAttackCurrentCooldown = 0;
        [SerializeField] private int jumpAttackMaxCooldown;
        private int jumpAttackCurrentCooldown = 0;
        [SerializeField] private int stompAttackMaxCooldown;
        private int stompAttackCurrentCooldown = 0;
        [SerializeField] private Transform firePointRight;
        [SerializeField] private Transform firePointLeft;
        [SerializeField] private GameObject[] shockWaves;
        private int shockWaveCounter = 0;

        private int currentPhase = 0;

        private bool canBasicAttack = false;
        private bool canJumpAttack = false;
        private bool canStompAttack = false;
        [SerializeField] float sightSize;
        [SerializeField] float sightSizeYDivision;
        [SerializeField] float sightOrigin;
        [SerializeField] float sightOffsetX;
        [SerializeField] private BoxCollider2D _boxCollider;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private GameObject playerObj;
        private float playerObjPosX;
        private float xDirection;
        [SerializeField] private int damage;

        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody2D>();
        }


        //----------------------------Check Triggers------------------------------------------
        public bool IsInDashRange(float _xDirection)
        {
            xDirection = _xDirection;
            RaycastHit2D hit = Physics2D.BoxCast(new Vector2(_boxCollider.bounds.center.x + (sightOrigin * _xDirection), _boxCollider.bounds.center.y), new Vector2(_boxCollider.bounds.size.x * sightSize, _boxCollider.bounds.size.y * (sightSize / sightSizeYDivision)),
                0, Vector2.left, 0, playerLayer);

            if (hit.collider)
            {
                playerObjPosX = playerObj.transform.position.x;
            }
           
            return hit.collider != null;
        }

        public bool GroundCheck()
        {
            RaycastHit2D hit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.down, (_boxCollider.bounds.extents.y + 0.1f), groundLayer);
            
            return hit.collider != null;
        }

//----------------------------Get Vars-------------------------------------------------------
        public float GetPlayerPos()
        {
            return playerObjPosX;
        }

        public float GetxDirection()
        {
            return xDirection;
        }

//----------------------------Trigger Projectile---------------------------------------------
        public void FireShockWave()
        {
            shockWaves[shockWaveCounter].transform.position = firePointRight.position;
            shockWaves[shockWaveCounter].GetComponent<KainProjectile>().SetDirection(xDirection);
            shockWaveCounter ++;
            shockWaves[shockWaveCounter].transform.position = firePointLeft.position;
            shockWaves[shockWaveCounter].GetComponent<KainProjectile>().SetDirection(-xDirection);
            shockWaveCounter++;
            if (shockWaveCounter >= shockWaves.Length)
            {
                shockWaveCounter = 0;
            }
        }

        //----------------------------Set Timers---------------------------------------------
        public void IncrementTimers()
        {
            BasicAttackTimer();
            JumpAttackTimer();
            StompAttackTimer();
        }

        private void BasicAttackTimer()
        {
            if (basicAttackCurrentCooldown <= basicAttackMaxCooldown)
            {
                basicAttackCurrentCooldown++;
            }
            else 
            {
                canBasicAttack = true;
            }
        }

        private void JumpAttackTimer()
        {
            if (jumpAttackCurrentCooldown >= jumpAttackMaxCooldown)
            {
                jumpAttackCurrentCooldown++;
            }
            else
            {
                canJumpAttack = true;
            }

        }

        private void StompAttackTimer()
        {
            if (stompAttackCurrentCooldown >= stompAttackMaxCooldown)
            {
                stompAttackCurrentCooldown++;
            }
            else
            {
                canStompAttack = true;
            }

        }

        //----------------Reset Timers--------------------------------------------------------
        public void BasicAttackBool()
        {
            basicAttackCurrentCooldown = 0;
            canBasicAttack = false;
        }

        public void JumpAttackBool()
        {
            jumpAttackCurrentCooldown = 0;
            canJumpAttack = false;
        }

        public void StompAttackBool()
        {
            stompAttackCurrentCooldown = 0;
            canStompAttack= false;
        }

        public bool GetBasicAttackTimer()
        {
            return canBasicAttack;
        }

        public bool GetJumpAttackTimer()
        {
            return canJumpAttack;
        }

        public bool GetStompAttackTimer()
        {
            return canStompAttack;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(new Vector2(_boxCollider.bounds.center.x + (sightOrigin * sightOffsetX), _boxCollider.bounds.center.y), new Vector2(_boxCollider.bounds.size.x * sightSize, _boxCollider.bounds.size.y * (sightSize / sightSizeYDivision)));
        }
    }
}*/

/*
 * private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector2(_boxCollider.bounds.center.x + (sightOrigin * sightOffsetX), _boxCollider.bounds.center.y), new Vector2(_boxCollider.bounds.size.x * sightSize, _boxCollider.bounds.size.y * (sightSize / sightSizeYDivision)));
        }
*/