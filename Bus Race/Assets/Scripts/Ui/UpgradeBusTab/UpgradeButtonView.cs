using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeButtonView : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeValue;
    [SerializeField] private TMP_Text _price;

    public event UnityAction UpgradeButtonClicked;

    private void Awake()
    {
        _upgradeButton = GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnButtonClick);
    }

    public void DisableButton()
    {
        _upgradeButton.interactable = false;
    }

    public void EnableButton()
    {
        _upgradeButton.interactable = true;
    }

    public void ChangeUpgradeValue(int value, int price)
    {
        _upgradeValue.text = value.ToString();
        _price.text = price.ToString();
    }

    private void OnButtonClick()
    {   
        UpgradeButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _upgradeButton.onClick.RemoveListener(OnButtonClick);
    }
}
