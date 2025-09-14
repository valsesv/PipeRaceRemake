using UnityEngine;
using valsesv._Project.Scripts.Managers.GameScene;
using valsesv._Project.Scripts.Managers.GameStatesManagement;
using valsesv._Project.Scripts.Managers.SoundManagement;
using Zenject;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _levelMusic;
    [SerializeField] private AudioClip _menuMusic;

    [Inject] private ProjectStateController _projectStateController;
    [Inject] private LevelManager _levelManager;
    [Inject] private MusicManager _musicManager;

    private void OnEnable()
    {
        _projectStateController.OnStateChangedEvent += SetMusic;
        SetMusic(_projectStateController.State);
    }

    private void OnDisable()
    {
        _projectStateController.OnStateChangedEvent -= SetMusic;
    }

    private void SetMusic(ProjectState projectState)
    {
        switch (projectState)
        {
            case ProjectState.Game:
                _musicManager.PlayMusic(_levelMusic);
                break;
            case ProjectState.Menu:
                _musicManager.PlayMusic(_menuMusic);
                break;
        }
    }
}