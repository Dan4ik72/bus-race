using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UITextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public event UnityAction<string> TextChanged;

    public void ChangeText(string text)
    {
        _text.text = text;

        TextChanged?.Invoke(text);
    }
}