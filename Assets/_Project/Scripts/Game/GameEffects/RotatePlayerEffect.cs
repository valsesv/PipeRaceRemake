namespace valsesv._Project.Scripts.Game.Obstacles
{
    public class RotatePlayerEffect : GameEffect
    {
        private void Awake()
        {
            _effectType = GameEffectType.Rotate180;
        }
    }
}