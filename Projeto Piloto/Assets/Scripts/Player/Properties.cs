using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    public bool Spirit = false;

    public GameObject Camera;

    [Header("Movement Configuration")]
    public float WalkVelocity = 3.0f;
    public float RotationVelocity = 150.0f;
}
