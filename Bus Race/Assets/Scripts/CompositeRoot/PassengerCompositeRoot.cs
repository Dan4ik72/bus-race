using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerCompositeRoot : CompositeRoot
{
    [SerializeField] private BusCompositeRoot _busCompositeRoot;

    public override void Compose()
    {

    }
}
