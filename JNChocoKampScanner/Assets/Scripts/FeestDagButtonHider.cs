using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeestDagButtonHider : MonoBehaviour
{
    [SerializeField]
    private GameObject feestDagButtonParent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            feestDagButtonParent.SetActive(!feestDagButtonParent.activeSelf);
        }
    }
}
