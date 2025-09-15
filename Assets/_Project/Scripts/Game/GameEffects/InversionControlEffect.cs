using Zenject;

namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class InversionControlEffect : GameEffect
    {
        private void Awake()
        {
            _effectType = GameEffectType.InversionControl;
        }
    }
}