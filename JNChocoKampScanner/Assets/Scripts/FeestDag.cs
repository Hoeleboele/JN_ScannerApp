using System;
using UnityEngine;

public class FeestDag : MonoBehaviour
{
    [SerializeField]
    private FeestDagType feestDagType;

    public FeestDagType FeestDagType { get => feestDagType; internal set => feestDagType = value; }

    public void Show()
    {
        gameObject.gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.gameObject.SetActive(false);
    }
}

public enum FeestDagType
{
    Kerst,
    Pasen,
    Halloween,
    Valentijn,
    OudEnNieuw,
    Moederdag,
    Vaderdag,
    Koningsdag,
    Bevrijdingsdag,
    Hemelvaart,
    Pinksteren,
    Sinterklaas
}