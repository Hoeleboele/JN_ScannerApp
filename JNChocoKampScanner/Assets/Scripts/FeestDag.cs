using System;
using System.Collections;
using UnityEngine;

public class FeestDag : MonoBehaviour
{
    private const float timeInBetweenHide = 2f;

    [SerializeField]
    private FeestDagType feestDagType;

    [SerializeField]
    private GameObject correctView;

    [SerializeField]
    private GameObject inCorrectView;

    public FeestDagType FeestDagType { get => feestDagType; internal set => feestDagType = value; }

    private void OnEnable()
    {
        Channels.ColorChangeChannel.OnCodeScanned += OnCodeScanned;
    }

    private void OnCodeScanned(Kid scannedKid)
    {
        if (scannedKid.IsCorrectCode)
        {
            correctView.SetActive(true);
            inCorrectView.SetActive(false);
        }
        else
        {
            correctView.SetActive(false);
            inCorrectView.SetActive(true);
        }

        StartCoroutine(HideAfterTime());
    }

    private IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(timeInBetweenHide);

        correctView.SetActive(false);
        inCorrectView.SetActive(false);
    }

    private void OnDisable()
    {
        Channels.ColorChangeChannel.OnCodeScanned -= OnCodeScanned;
    }

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