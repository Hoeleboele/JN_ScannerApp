using Assets.KidsDatabase;
using Assets.Scripts.NFC_scanner;
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

    bool locked = false;

    private void Awake()
    {
        CardReader.cardReader.CardConnected += Cardreader_CardConnected;
        CardReader.cardReader.CardDisconnected += Cardreader_CardDisconnected;
        CardReader.cardReader.StartWatch();
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
        CardReader.cardReader.CardConnected -= Cardreader_CardConnected;
        CardReader.cardReader.CardDisconnected -= Cardreader_CardDisconnected;
    }
}
