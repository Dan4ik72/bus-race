using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonView : MonoBehaviour
{
    private Button _button;

    public event UnityAction OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick?.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnClick?.Invoke();
    }
}
