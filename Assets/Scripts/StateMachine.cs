using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : State
{
    State currentstate;

    public void OnUpdate() {
        if (currentstate != null)
            currentstate.OnUpdate();
    }

    public void ChangeState(State stateTo) {
        if (currentstate != null)
            currentstate.OnExit();

        currentstate = stateTo;
        currentstate.OnEnter();
    }
}