using UnityEngine;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class ObjectTeleporter : MonoBehaviour
    {
        [SerializeField] private float _tpPositionZ;
        [SerializeField] private Vector3 _tpDistance;

        private void Update()
        {
            if (transform.position.z < _tpPositionZ)
            {
                transform.position += _tpDistance;
            }
        }
    }
}