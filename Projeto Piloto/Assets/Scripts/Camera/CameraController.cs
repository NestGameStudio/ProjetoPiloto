using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Se tocou em um trigger de puzzle a camera fica com o foco no puzzle

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera Camera;

    // Se tocou em um trigger de puzzle a camera fica com o foco no puzzle
    private void OnTriggerEnter(Collider other) {
        
    }
}
