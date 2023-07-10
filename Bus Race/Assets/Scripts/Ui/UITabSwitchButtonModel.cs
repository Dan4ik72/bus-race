using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabSwitchButtonModel : ButtonModel
{
    private TabSwitcher _tabSwitcher;

    public UITabSwitchButtonModel(TabSwitcher tabSwitcher)
    {
        _tabSwitcher = tabSwitcher;
    }

    public override void OnButtonClick()
    {
        _tabSwitcher.SwitchTabs();

        base.OnButtonClick();
    }
}
