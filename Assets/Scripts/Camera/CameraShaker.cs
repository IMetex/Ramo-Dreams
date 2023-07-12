using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [Header("Camera")]
    public Transform cameraTransform;

    [Header("Camera Shake Values")]
    public float shakeDuration = 0.2f;
    public float shakeStrength = 0.5f;
    public int shakeVibrato = 10;
    public float shakeRandomness = 90f;


    public void CameraShake()
    {
        // Shoot Camera Shake 
        cameraTransform.DOShakeRotation(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness);
    }
}
