using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    public Transition(System.Predicate<GameObject> condition, System.Type toState)
    {
        this.condition = condition;
        this.toState = toState;
    }
    public System.Predicate<GameObject> condition;
    public System.Type toState;
}