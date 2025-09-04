using UnityEngine;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class ObjectRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 270f;

        private void Update()
        {
            var rotationAmount = new Vector3(0, 0, _rotationSpeed) * Time.deltaTime;
            transform.Rotate(rotationAmount);
        }
    }
}
