using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();

    public List<Transition> transitions = new List<Transition>();

    public virtual void AddTransition(Transition transition) {
        transitions.Add(transition);
    }
}