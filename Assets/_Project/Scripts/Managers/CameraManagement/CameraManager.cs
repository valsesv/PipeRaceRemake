using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace valsesv._Project.Scripts.Managers.CameraManagement
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera[] cameras;
        [SerializeField] private CameraType currentCameraType;

        private float _timer;

        private CinemachineVirtualCamera _currentCamera;
        private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

        private CinemachineVirtualCamera CurrentCamera
        {
            get => _currentCamera;
            set
            {
                _currentCamera = value;
                _cinemachineBasicMultiChannelPerlin =
                    _currentCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            }
        }

        public void ChangeCamera(CameraType cameraType)
        {
            currentCameraType = cameraType;

            foreach (var virtualCamera in cameras)
            {
                virtualCamera.m_Priority = 0;
            }
            CurrentCamera = cameras[(int)currentCameraType];
            CurrentCamera.m_Priority = 100;
        }

        public void SetCamera(CameraType cameraType, CinemachineVirtualCamera targetCamera)
        {
            targetCamera.m_Priority = cameras[(int) cameraType].m_Priority;
            cameras[(int) cameraType].m_Priority = 0;
            cameras[(int) cameraType] = targetCamera;

            if (currentCameraType == cameraType)
            {
                CurrentCamera = targetCamera;
            }
        }

        public async void ShakeCamera(float intensity, float shakeDuration)
        {
            SetAmplitudeIntensity(intensity);
            UniTask.WaitForSeconds(shakeDuration);
            SetAmplitudeIntensity(0f);
        }

        private void SetAmplitudeIntensity(float targetIntensity) =>
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = targetIntensity;
    }
}