/*using Statemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Boss/Actions/Attack")]

    public class Attack:SubState<KainBase>
    {
        //SET BOX COLLIDER INSTEAD OF CALLING TO FUNCTIONS--------PATROL SCRIPT
        private bool _changeAction = false;
        private Rigidbody2D _rb;
        [SerializeField] private float dashSpeed;
        private float dashPosX;
        private float offsetPlayerPosX;
        private float playerPosX;

        [SerializeField] private float jumpForce;
        [SerializeField] private float airSpeed;

        EnemyHealth healthScript;
        KainBase baseScript;
        KainAnimator anim;
        private int currentPhase;

        private int maxAttackReroll = 3;
        private int currAttackReroll = 0;

        private bool unRolled = true;
        private bool isFeinting = false;
        private bool isDashing = false;
        private bool isJumping = false;
        private bool isStomping = false;

        public override void Init(KainBase parent)
        {
            base.Init(parent);
            healthScript = parent.GetComponentInChildren<EnemyHealth>();
            baseScript = parent.GetComponentInChildren<KainBase>();
            anim = parent.GetComponentInChildren<KainAnimator>();
            _rb = parent.GetComponentInChildren<Rigidbody2D>();
            playerPosX = baseScript.GetPlayerPos();
            offsetPlayerPosX = (playerPosX - baseScript.GetxDirection());
            dashPosX = (playerPosX - (baseScript.GetxDirection() * 1.6f));
            SetVanilla();
        }

        public override void PlayAction()
        {
            ChooseAttack();
            UpdateFeint();
            UpdateDash();
            UpdateJumpAttack();
            UpdateStompAttack();
            ChangeAction();
        }

        public override void ChangeAction()
        {
            //get bool in animate script to check on status of animation
            if (anim.CheckAnimationCompleted())
            {
                _runner.SetAction(typeof(Wait));
            }

        }

        public override void Exit()
        {
            _changeAction = false;
        }

        private void SetVanilla()
        {
            isDashing = false;
            isFeinting = false;
            isJumping = false;
            isStomping = false;
            unRolled = true;
            currAttackReroll = 0;
            anim.ResetAnimBool();
        }

        private void ChooseAttack()
        {
            currentPhase = healthScript.GetPhase();
            
            int randAttack = Random.Range(1, (currentPhase + 1));
            if (unRolled)
            {
                if (currAttackReroll <= maxAttackReroll)
                {
                    currAttackReroll++;
                    if (randAttack == 1)
                    {
                        BasicAttack();
                    }

                    else if (randAttack == 2)
                    {
                        JumpAttack();
                    }

                    else if (randAttack == 3)
                    {
                        StompAttack();
                    }
                }

                else
                {
                    Feint();
                }
            }

        }

        private void Feint()
        {
            unRolled = false;
            isFeinting = true;
        }

        private void BasicAttack()
        {
            if (baseScript.GetBasicAttackTimer())
            {
                baseScript.BasicAttackBool();
                unRolled = false;
                isDashing = true;
            }

            else
            {
                ChooseAttack();
            }
        }

        private void JumpAttack()
        {
            if (baseScript.GetJumpAttackTimer())
            {
                unRolled = false;
                isJumping = true;
                baseScript.JumpAttackBool();
                anim.JumpAttackAnim();
                _rb.velocity = Vector2.up * jumpForce;
            }
            
            else
            {
                ChooseAttack();
            }
        }

        private void StompAttack()
        {
            if (baseScript.GetStompAttackTimer())
            {
                unRolled = false;
                isStomping = true;
                baseScript.StompAttackBool();
                anim.JumpAttackAnim();
                _rb.velocity = Vector2.up * jumpForce;
                Debug.Log("Stomp");
            }

            else
            {
                ChooseAttack();
            }
        }

        private void UpdateFeint()
        {
            if (isFeinting)
            {
                if (_rb.position.x != (-offsetPlayerPosX))
                {
                    _rb.position = Vector2.MoveTowards(_rb.position, new Vector2((-offsetPlayerPosX), _rb.transform.position.y), (dashSpeed * Time.deltaTime));
                }

                else
                {
                    isFeinting = false;
                    anim.KainFeintStop();
                }
            }
        }

        private void UpdateDash()
        {
            if (isDashing)
            {
                if (_rb.position.x != dashPosX)
                {
                    _rb.position = Vector2.MoveTowards(_rb.position, new Vector2(dashPosX, _rb.transform.position.y), (dashSpeed * Time.deltaTime));
                }
                else
                {
                    anim.BasicAttackAnim();
                    isDashing = false;
                }
            }
        }

        private void UpdateJumpAttack()
        {
            if (isJumping)
            {
                if (_rb.position.x != playerPosX)
                {
                    _rb.position = Vector2.MoveTowards(_rb.position, new Vector2((playerPosX), _rb.transform.position.y), (airSpeed * Time.deltaTime));

                }
                else
                {
                    if (baseScript.GroundCheck())
                    {
                        anim.JumpingFinished();
                        isJumping = false;
                    }
                }
            }
        }

        private void UpdateStompAttack()
        {

            if (isStomping)
            {
                if (_rb.position.x != offsetPlayerPosX)
                {
                    _rb.position = Vector2.MoveTowards(_rb.position, new Vector2((offsetPlayerPosX), _rb.transform.position.y), (airSpeed * Time.deltaTime));

                }
                else
                {
                    if (baseScript.GroundCheck())
                    {
                        anim.JumpingFinished();
                        SendProjectiles();
                    }
                }
            }
        }

        private void SendProjectiles()
        {
            baseScript.FireShockWave();
            isStomping = false;
        }

    }
}*/