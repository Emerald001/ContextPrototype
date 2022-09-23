using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState {

    public bool IsDone;
    public float waitTime;

    public EnemyIdleState(StateMachine<EnemyAI> stateMachine, EnemyAI owner) : base(stateMachine, owner) {

    }

    public override void OnEnter() {
        IsDone = false;
        waitTime = Random.Range(2, 5);
    }

    public override void OnExit() {
        IsDone = false;
    }

    public override void OnUpdate() {
        base.OnUpdate();

        if (WaitTimer(ref waitTime) < 0)
            IsDone = true;
    }

    public float WaitTimer(ref float Timer) {
        return Timer -= Time.deltaTime;
    }
}
