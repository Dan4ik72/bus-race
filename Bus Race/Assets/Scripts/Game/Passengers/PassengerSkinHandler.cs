using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PassengerSkinHandler : MonoBehaviour
{
    [SerializeField] private List<Animator> _skins = new List<Animator>();

    public Animator Animator { get; private set; }

    public void Init()
    {
        EnableRandomSkin();
    }

    public void EnableRandomSkin()
    {
        DisableAllSkins();

        int randomSkinIndex = Random.Range(0, _skins.Count);

        _skins[randomSkinIndex].gameObject.SetActive(true);

        Animator = _skins[randomSkinIndex];
    }

    private void DisableAllSkins()
    {
        foreach (var avatar in _skins)
            avatar.gameObject.SetActive(false);
    }
}
