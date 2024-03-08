/*using Statemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Boss/Phase1")]

    public class Phase1: State<KainBase>
    {
        EnemyHealth healthScript;
        KainBase baseScript;
        private int currentPhase;

        
        private bool playerinRange = false;
        private bool attackOnCooldown = false;

        public override void Init(KainBase parent)
        {
            base.Init(parent);
            healthScript = parent.GetComponentInChildren<EnemyHealth>();
            baseScript = parent.GetComponentInChildren<KainBase>();
            ChangeAction();
        }

        public override void Update()
        {
            baseScript.IncrementTimers();
            _runner.GetActiveAction().PlayAction();
            currentPhase = healthScript.GetPhase();

        }

        public override void FixedUpdate()
        {
            
        }

        public override void ChangeState()
        {
            if (currentPhase > 1)
            {
                _runner.SetState(typeof(Phase2));
                Debug.Log("Go to phase 2");
            }
        }

        public override void ChangeAction()
        {
            _runner.SetAction(typeof(Chase));
        }


        public override void Exit()
        {

        }
    }
}*/