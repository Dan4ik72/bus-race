using UnityEngine.Events;

public class ButtonModel
{
    public event UnityAction OnClick;

    public virtual void OnButtonClick() => OnClick?.Invoke();
}
