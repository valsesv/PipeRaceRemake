using UnityEngine;

namespace valsesv._Project.Scripts.Game
{
    public class Obstacle : MonoBehaviour
    {
        public int damageValue { get; private set; } = 1;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Player>(out var player) == false)
            {
                return;
            }

            player.GetDamage();
        }
    }
}
