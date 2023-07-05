using UnityEngine.Events;
 
public class GameEndingInput : IBusInput
{
    public event UnityAction GasPressed;
    public event UnityAction IdlePressed;
    
    public void Enter()
    {
        IdlePressed?.Invoke();
    }

    public void Update() { }

}
