using Zenject;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class ChangeSkinEffect : GameEffect
    {
        private void Awake()
        {
            _effectType = GameEffectType.ChangeSkinEffect;
        }
    }
}