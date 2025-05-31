using UnityEngine;
using valsesv._Project.Scripts.Managers.GameConfiguration;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public class SoundManager : AudioSourceManager
    {
        [SerializeField] private AudioClip turningOnSound;

        public override void Init()
        {
            SwitchConfigKey = ConfigKey.GameSoundSwitcher;
            ValueConfigKey = ConfigKey.GameSound;
            base.Init();
        }

        public override void Switch()
        {
            base.Switch();
            if (IsOn)
            {
                PlaySound(turningOnSound);
            }
        }

        public void PlaySound(AudioClip audioClip)
        {
            if (IsOn == false)
            {
                return;
            }

            soundSource.PlayOneShot(audioClip);
        }
    }
}