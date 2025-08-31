using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace valsesv
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private List<KeyCode> leftMoveKeys;
        [SerializeField] private List<KeyCode> rightMoveKeys;
        [SerializeField] private float _currentSpeed;
        private float _targetSpeed;

        private Tween _speedTween;

        private void OnEnable()
        {
            _speedTween?.Kill();
        }

        private void Update()
        {
            GetInput();
            Move();
        }

        private void GetInput()
        {
            if (GetClickButton())
            {
                return;
            }
            if (GetKeyButton())
            {
                return;
            }

            SetSpeedWithAcceleration(0);
        }

        private bool GetClickButton()
        {
            if (IsClickOnUi())
            {
                return false;
            }
            if (Input.GetMouseButton(0) == false)
            {
                return false;
            }

            if (Input.mousePosition.x > Screen.width / 2)
            {
                SetSpeedWithAcceleration(_maxSpeed);
            }
            else
            {
                SetSpeedWithAcceleration(-_maxSpeed);
            }

            return true;
        }

        private bool IsClickOnUi()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private bool GetKeyButton()
        {
            foreach (var key in leftMoveKeys)
            {
                if (Input.GetKey(key))
                {
                    SetSpeedWithAcceleration(-_maxSpeed);
                    return true;
                }
            }
            foreach (var key in rightMoveKeys)
            {
                if (Input.GetKey(key))
                {
                    SetSpeedWithAcceleration(_maxSpeed);
                    return true;
                }
            }

            return false;
        }

        private void Move()
        {
            transform.Rotate(0, 0, _currentSpeed * Time.deltaTime);
        }

        private void SetSpeedWithAcceleration(float targetSpeed)
        {
            if (_targetSpeed == targetSpeed)
            {
                return;
            }
            _targetSpeed = targetSpeed;
            _speedTween?.Kill();
            _speedTween = DOTween.To(() => _currentSpeed, x => _currentSpeed = x, targetSpeed, _acceleration).SetSpeedBased(true);
        }
    }
}
