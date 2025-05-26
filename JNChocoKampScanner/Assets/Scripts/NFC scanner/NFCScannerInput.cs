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

    bool locked = false;

    private void Awake()
    {
        cardreader.CardConnected += Cardreader_CardConnected;
        cardreader.CardDisconnected += Cardreader_CardDisconnected;
        cardreader.StartWatch();
    }

    private void Cardreader_CardConnected(object sender, CardreaderEventArgs e)
    {
        if (locked)
            return;

        locked = true;
        
        var cardId = e.Card.Id;
        Channels.ColorChangeChannel.OnCodeScannedRaw?.Invoke(cardId);
        var kid = database.allKids.Find(k => k.Code == e.Card.Id);

        if (kid == null)
            return;

        Channels.ColorChangeChannel.OnCodeScanned?.Invoke(kid);
    }

    private void Cardreader_CardDisconnected(object sender, CardreaderEventArgs e)
    {
        locked = false;
    }

    private void OnDestroy()
    {
        cardreader.StopWatch();
        cardreader.Dispose();
        cardreader.CardConnected -= Cardreader_CardConnected;
        cardreader.CardDisconnected -= Cardreader_CardDisconnected;
    }
}
