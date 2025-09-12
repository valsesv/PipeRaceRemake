using System.Runtime.InteropServices;
using UnityEngine;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using Zenject;

namespace valsesv._Project.Scripts.Game
{
    public class Player : MonoBehaviour
    {
        [Inject] private GameSceneManager _gameSceneManager;

        private int _playerHp = 1;

        public void GetDamage(int damageValue = 1)
        {
            _playerHp -= damageValue;
            if (_playerHp <= 0)
            {
                LoseGame();
            }
        }

        private void LoseGame()
        {
            _gameSceneManager.LoseGame();
        }

        public void WinGame()
        {
            _gameSceneManager.WinGame();
        }
    }
}
