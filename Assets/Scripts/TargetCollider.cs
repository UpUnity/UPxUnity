using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Debug.Log("Collided with tag: " + otherObject.tag);
    }
}
