using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Vector3 offset;

    // Update is called once per frame
    void Update() {
        transform.position = Vector3.Lerp(transform.position, ObjectToFollow.position + offset, 20 * Time.deltaTime);
    }
}