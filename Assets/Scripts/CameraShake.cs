using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeAmplitude = 1.2f;
    [SerializeField] private float shakeFrequency = 2.0f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private float elapsedTime = 0f;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    [HideInInspector]public static bool isDamaged = false;

    void Start()
    {
        if(virtualCamera != null) {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged) {
            elapsedTime = shakeDuration;
        }

        if(virtualCamera != null || virtualCameraNoise != null) {
            isDamaged = false;
            if (elapsedTime > 0) {
                virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = shakeFrequency;

                elapsedTime -= Time.deltaTime;
            } else {
                virtualCameraNoise.m_AmplitudeGain = 0f;
                elapsedTime = 0f;
            }
        }
    }
}
