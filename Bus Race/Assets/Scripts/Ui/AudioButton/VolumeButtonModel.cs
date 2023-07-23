using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class VolumeButtonModel : ButtonModel
{
    private Image _soundImage;

    private Sprite _disabledSound, _enabledSound;

    public VolumeButtonModel(Sprite disabledSound, Sprite enebledSound, Image spriteRenderer)
    {
        _soundImage = spriteRenderer;

        _disabledSound = disabledSound;
        _enabledSound = enebledSound;

        UpdateSprites();
    }

    private void UpdateSprites()
    {
        if (MusicAudioSourceHandler.Instance.IsSoundEnable == false)
            _soundImage.sprite = _disabledSound;
        else
            _soundImage.sprite = _enabledSound;
    }

    public override void OnButtonClick()
    {
        if (MusicAudioSourceHandler.Instance.IsSoundEnable == false)
        {
            EnableSounds();
            _soundImage.sprite = _enabledSound;
            return;
        }
     
        DisableSounds();
        _soundImage.sprite = _disabledSound;
    }

    private void EnableSounds()
    {
        MusicAudioSourceHandler.Instance.PlayMusic();
    }

    private void DisableSounds()
    {
        MusicAudioSourceHandler.Instance.Stop();
    }
}