using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using YG;

[RequireComponent(typeof(TMP_Text))]
public class LocalizationHandler : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;
    [SerializeField] private string _tr;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        Localizate();
    }

    private void Localizate()
    {
        if (YandexGame.SDKEnabled == false)
        {
            Debug.LogError($"Can't localizate the {gameObject.name} text, Yandex SDK isn't ready");
            return;
        }

        string languague = YandexGame.EnvironmentData.language;

        switch (languague)
        {
            case "ru":
                _text.text = _ru;
                break;

            case "tr":
                _text.text = _tr;
                break;

            case "en":
                _text.text = _en;
                break;

            default:
                _text.text = _en;
                break;
        }
    }
}
