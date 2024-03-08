/*using Statemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Boss/Actions/Chase")]

    public class Chase:SubState<KainBase>
    {
        private KainAnimator anim;
        private bool _changeAction = false;
        private Rigidbody2D _rb;
        private BoxCollider2D _boxCollider;
        private GameObject player;
        [SerializeField] private float chaseSpeed;
        private float movementDirection;
        KainBase parentScript;

        public override void Init(KainBase parent)
        {
            base.Init(parent);

            parentScript = parent.GetComponentInChildren<KainBase>();
            _rb = parent.GetComponentInChildren<Rigidbody2D>();
            _boxCollider = parent.GetComponentInChildren<BoxCollider2D>();
            anim = parent.GetComponentInChildren<KainAnimator>();
            player = GameObject.FindGameObjectWithTag("Player");
            
        }

        public override void PlayAction()
        {
            Movement();
            ChangeAction();
        }

        public override void ChangeAction()
        {
            _changeAction = parentScript.IsInDashRange(movementDirection);

            if (_changeAction)
            {

                _runner.SetAction(typeof(Attack));
            }
        }

        private void Movement()
        {
            if ((player.transform.position.x + 3f) <= _rb.position.x)
            {
                anim.KainWalk();
                movementDirection = (player.transform.position.x - _rb.position.x);
                movementDirection = anim.SetDirection(movementDirection);
                _rb.position = Vector2.MoveTowards(_rb.position, new Vector2(player.transform.position.x, _rb.position.y), (chaseSpeed * Time.deltaTime));
            }
            else if ((player.transform.position.x - 3f) >= _rb.position.x)
            {
                anim.KainWalk();
                movementDirection = (player.transform.position.x - _rb.position.x);
                movementDirection = anim.SetDirection(movementDirection);
                _rb.position = Vector2.MoveTowards(_rb.position, new Vector2(player.transform.position.x, _rb.position.y), (chaseSpeed * Time.deltaTime));
            }

            else 
            {
                anim.KainIdle();
            }
        }

        public override void Exit()
        {
            anim.KainIdle();
            _changeAction = false;
        }
    }
}*/