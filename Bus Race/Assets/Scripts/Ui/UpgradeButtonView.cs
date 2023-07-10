using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeButtonView : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeValue;

    public event UnityAction UpgradeButtonClicked;

    private void Awake()
    {
        _upgradeButton = GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnButtonClick);
    }

    public void ChangeUpgradeValue(int value)
    {
        _upgradeValue.text = value.ToString();
    }

    private void OnButtonClick()
    {
        UpgradeButtonClicked?.Invoke();
    }
}
