using UnityEngine;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class ObstacleDestroyer : MonoBehaviour
    {
        [SerializeField] private AudioClip _obstacleSound;
        [Inject] private SoundManager _soundManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Obstacle>(out var obstacle))
            {
                DestroyObstacle(obstacle);
            }

            if (other.gameObject.TryGetComponent<GameEffect>(out var gameEffect))
            {
                DestroyGameEffect(gameEffect);
            }
        }
        
        private void DestroyObstacle(Obstacle obstacle)
        {
            _soundManager.PlaySound(_obstacleSound);
            Destroy(obstacle.gameObject);
        }

        private void DestroyGameEffect(GameEffect gameEffect)
        {
            Destroy(gameEffect.gameObject);
        }
    }
}