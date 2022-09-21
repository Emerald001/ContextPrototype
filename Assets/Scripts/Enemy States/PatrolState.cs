using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState {

    public List<Transform> positions;

    public PatrolState(StateMachine<EnemyAI> stateMachine, EnemyAI owner, List<Transform> positions) : base(stateMachine, owner) {
        this.positions = positions;
    }

    public override void OnEnter() {

    }

    public override void OnExit() {

    }

    public override void OnUpdate() {

    }
}