using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonSetUp : MonoBehaviour
{
    [SerializeField] private ButtonView _buttonView;

    private VolumeButtonModel _volumeButtonModel;
    private ButtonPresenter _buttonPresenter;

    private void Awake()
    {
        _volumeButtonModel = new VolumeButtonModel(MusicAudioSourceHandler.Instance);
        _buttonPresenter = new ButtonPresenter(_volumeButtonModel, _buttonView);
    }
}
