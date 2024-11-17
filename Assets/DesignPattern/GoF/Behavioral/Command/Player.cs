using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Receiver
public class Player : MonoBehaviour
{
    public void Attack(Transform target)
    {
        Debug.Log($"Attack! {target.name}");
    }

    public void Jump()
    {
        Debug.Log("Jump...");
    }
}
