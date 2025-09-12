using UnityEngine;

namespace valsesv._Project.Scripts.Game
{
    public class LevelEnd : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out var player) == false)
            {
                return;
            }

            player.WinGame();
        }
    }
}