using UnityEngine;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public abstract class GameEffect : MonoBehaviour
    {
        [SerializeField] private float _duration;

        public GameEffectType _effectType{ get; protected set; }
    }
}