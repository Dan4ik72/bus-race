using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    [SerializeField] private RectTransform _currentTab;
    [SerializeField] private RectTransform _targetTab;

    public void SwitchTabs()
    {
        _currentTab.gameObject.SetActive(false);
        _targetTab.gameObject.SetActive(true);
    }
}   
