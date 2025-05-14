using Assets.KidsDatabase;
using Lando;
using Lando.LowLevel;
using System;
using System.Net;
using UnityEngine;
using UnityEngine.Rendering;

public class NFCScannerInput : MonoBehaviour
{
    [SerializeField]
    private ExcelBarcodeDatabase database;

    private Cardreader cardreader = new Cardreader();

    private void Awake()
    {
        cardreader.CardConnected += Cardreader_CardConnected;
        cardreader.CardDisconnected += Cardreader_CardDisconnected;
        cardreader.StartWatch();
    }

    private void Cardreader_CardConnected(object sender, CardreaderEventArgs e)
    {
        Debug.Log($"card connected!");
        var cardId = e.Card.Id;
        var kid = database.allKids.Find(k => k.Code == e.Card.Id);
        Channels.ColorChangeChannel.OnCodeScanned?.Invoke(kid);
        Debug.Log($"card read: {cardId}");
    }

    private void Cardreader_CardDisconnected(object sender, CardreaderEventArgs e)
    {
        Debug.Log($"card disconnected");
    }

    private void OnDestroy()
    {
        cardreader.StopWatch();
        cardreader.Dispose();
        cardreader.CardConnected -= Cardreader_CardConnected;
        cardreader.CardDisconnected -= Cardreader_CardDisconnected;
    }
}
