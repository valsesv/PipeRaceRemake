using UnityEngine;
using valsesv._Project.Scripts.Managers.GameConfiguration;

namespace valsesv._Project.Scripts.Managers.SoundManagement
{
    public class MusicManager : AudioSourceManager
    {
        public override void Init()
        {
            SwitchConfigKey = ConfigKey.GameMusicSwitcher;
            ValueConfigKey = ConfigKey.GameMusic;
            base.Init();
        }

        public void PlayMusic(AudioClip audioClip)
        {
            soundSource.clip = audioClip;
            if (soundSource.isPlaying == false && IsOn)
            {
                soundSource.Play();
            }
        }

        public void PauseMusic()
        {
            soundSource.Pause();
        }
    }
}