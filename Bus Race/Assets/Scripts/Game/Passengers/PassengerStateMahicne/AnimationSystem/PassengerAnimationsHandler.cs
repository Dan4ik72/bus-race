using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerAnimationsHandler
{
    private readonly int _wavingAnimationHash = Animator.StringToHash("Waving");
    private readonly int _isRunningParameterHash = Animator.StringToHash("IsRunning");
    
    private Animator _animator;

    public PassengerAnimationsHandler(Animator animator) => _animator = animator;

    public void PlayRunningAnimation()
    {
        _animator.SetBool(_isRunningParameterHash, true);
    }

    public void PlayWavingAnimation()
    {
        _animator.Play(_wavingAnimationHash);
    }

    public void PlayDancingAnimation()
    {
        //_animator.SetBool(_isRunningParameterHash, true);
    }
    
    public void PlayIdleAnimation()
    {
        _animator.SetBool(_isRunningParameterHash, false);
    }
}
