using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FeestdagButton : MonoBehaviour
{
    private FeestDagType feestDagType;

    public void Init(FeestDagType feestDagType)
    {
        this.feestDagType = feestDagType;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        var text = button.GetComponentInChildren<TMP_Text>();
        
        if (text != null)
        {
            text.SetText(feestDagType.ToString());
        }
    }

    public void OnButtonClick()
    {
        FeestDagenManager.Instance.ShowFeestdagFromType(feestDagType);
    }
}
