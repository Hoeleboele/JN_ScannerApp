using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.KidsDatabase
{
    public class ExcelBarcodeDatabase : MonoBehaviour
    {
        private const string filepath = "./KidsDatabase.csv";

        public List<Kid> allKids = new List<Kid>();

        private void Start()
        {
            if (File.Exists(filepath) == false)
            {
                File.Create(filepath);
            }

            var isheaderLine = true;
            foreach (var item in File.ReadAllLines(filepath))
            {
                if (isheaderLine)
                {
                    isheaderLine = false;
                    continue;
                }

                Kid kid = new Kid();
                kid = kid.StringToKid(item);
                allKids.Add(kid);
            }

            foreach (var item in allKids)
            {
                Debug.Log($"{item.Code}, {item.FirstName}, {item.LastName}, {item.Group},{item.IsCorrectCode}");
            }
        }
    }
}
