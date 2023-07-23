using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtonSetUp : MonoBehaviour
{
    [SerializeField] private ButtonView _buttonView;

    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _disabledSound, _enabledSound;

    private VolumeButtonModel _volumeButtonModel;
    private ButtonPresenter _buttonPresenter;

    private void Start()
    {
        _volumeButtonModel = new VolumeButtonModel(_disabledSound, _enabledSound, _soundImage);
        _buttonPresenter = new ButtonPresenter(_volumeButtonModel, _buttonView);
    }

    private void OnDisable()
    {
        _buttonPresenter.Disable();
    }
}
