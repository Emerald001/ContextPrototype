using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEvaluator
{
    public bool IsGrounded(GameObject objectToCheck)
    {
        Vector3 bottom = objectToCheck.transform.position - new Vector3(0, .5f, 0);

        if (Physics.Raycast(bottom, new Vector3(0, -1, 0), out var hit, 1f))
        {
            Debug.Log(hit.collider);

            if (hit.collider != null)
            {
                return true;
            }
        }
        return false;
    }
    public bool InTheAir(GameObject objectToCheck)
    {
        Vector3 bottom = objectToCheck.transform.position - new Vector3(0, .5f, 0);

        if (Physics.Raycast(bottom, new Vector3(0, -1, 0), out var hit, 1f))
        {
            if (hit.collider != null)
            {
                return false;
            }
        }
        return true;
    }
}