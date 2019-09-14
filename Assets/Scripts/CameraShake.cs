using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.2f;
    [SerializeField] private float shakeAmplitude = 1.2f;
    [SerializeField] private float shakeFrequency = 2.0f;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    private WaitForSeconds waitForSeconds;

    private void Start()
    {
        virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        waitForSeconds = new WaitForSeconds(shakeDuration);
    }

    public void ShakeCamera()
    {
        StartCoroutine(startCameraShake());
    }

    private IEnumerator startCameraShake()
    {
        virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = shakeFrequency;
        yield return waitForSeconds;
        virtualCameraNoise.m_AmplitudeGain = 0f;
        virtualCameraNoise.m_FrequencyGain = 0f;
    }
}
