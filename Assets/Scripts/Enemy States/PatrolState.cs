using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState {

    public List<Transform> positions;

    public PatrolState(EnemyAI owner, List<Transform> positions) : base(owner) {
        this.positions = positions;
    }

    public override void OnEnter() {

    }

    public override void OnExit() {

    }

    public override void OnUpdate() {

    }
}