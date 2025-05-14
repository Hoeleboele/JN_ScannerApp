using System.Collections.Generic;

namespace Assets.KidsDatabase
{
    public static class BarcodeDatabase
    {
        public static List<string> Barcodes = new();

        private static int seniorPrefix = 1;
        private static int maxioorPrefix = 2;
        private static int minioorPrefix = 3;
        private static int juniorPrefix = 4;

        private static int seniorCurrentIndex = 0;
        private static int maxioorCurrentIndex = 0;
        private static int minioorCurrentIndex = 0;
        private static int juniorCurrentIndex = 0;

        public static string GetNextBarcodeFromGroup(KidGroup kidGroup)
        {
            string toReturn = "";

            int index = GetNextIndexFromKidsGroup(kidGroup);

            switch (kidGroup)
            {
                case KidGroup.Senior:
                    toReturn = GetAllBarcodesFromKidsGroup(kidGroup)[index];
                    break;
                case KidGroup.Maxioor:
                    toReturn = GetAllBarcodesFromKidsGroup(kidGroup)[index];
                    break;
                case KidGroup.Junior:
                    toReturn = GetAllBarcodesFromKidsGroup(kidGroup)[index];
                    break;
                case KidGroup.Minioor:
                    toReturn = GetAllBarcodesFromKidsGroup(kidGroup)[index];
                    break;
            }

            return toReturn;
        }

        private static List<string> GetAllBarcodesFromKidsGroup(KidGroup kidGroup)
        {
            char prefix = GetPrefixFromKidsGroup(kidGroup).ToCharArray()[0];

            return Barcodes.FindAll(c => c.ToCharArray()[0] == prefix);
        }

        private static int GetNextIndexFromKidsGroup(KidGroup kidGroup)
        {
            int toReturn = -1;

            switch (kidGroup)
            {
                case KidGroup.Senior:
                    toReturn = seniorCurrentIndex;
                    seniorCurrentIndex++;
                    break;
                case KidGroup.Maxioor:
                    toReturn = maxioorCurrentIndex;
                    maxioorCurrentIndex++;
                    break;
                case KidGroup.Junior:
                    toReturn = juniorCurrentIndex;
                    juniorCurrentIndex++;
                    break;
                case KidGroup.Minioor:
                    toReturn = minioorCurrentIndex;
                    minioorCurrentIndex++;
                    break;
            }

            return toReturn;
        }

        private static string GetPrefixFromKidsGroup(KidGroup group)
        {
            switch (group)
            {
                case KidGroup.Senior:
                    return seniorPrefix.ToString();
                case KidGroup.Maxioor:
                    return maxioorPrefix.ToString();
                case KidGroup.Junior:
                    return juniorPrefix.ToString();
                case KidGroup.Minioor:
                    return minioorPrefix.ToString();
            }

            return "0";
        }

        public static void InitDatabase()
        {
            Barcodes.Add("10001");
            Barcodes.Add("10002");
            Barcodes.Add("10003");
            Barcodes.Add("10004");
            Barcodes.Add("10005");
            Barcodes.Add("10006");
            Barcodes.Add("10007");
            Barcodes.Add("10008");
            Barcodes.Add("10009");
            Barcodes.Add("10010");
            Barcodes.Add("10011");
            Barcodes.Add("10012");
            Barcodes.Add("10013");
            Barcodes.Add("10014");
            Barcodes.Add("10015");
            Barcodes.Add("10016");
            Barcodes.Add("10017");
            Barcodes.Add("10018");
            Barcodes.Add("10019");
            Barcodes.Add("10020");
            Barcodes.Add("10021");
            Barcodes.Add("10022");
            Barcodes.Add("10023");
            Barcodes.Add("10024");
            Barcodes.Add("10025");
            Barcodes.Add("10026");
            Barcodes.Add("10027");
            Barcodes.Add("10028");
            Barcodes.Add("10029");
            Barcodes.Add("10030");
            Barcodes.Add("20001");
            Barcodes.Add("20002");
            Barcodes.Add("20003");
            Barcodes.Add("20004");
            Barcodes.Add("20005");
            Barcodes.Add("20006");
            Barcodes.Add("20007");
            Barcodes.Add("20008");
            Barcodes.Add("20009");
            Barcodes.Add("20010");
            Barcodes.Add("20011");
            Barcodes.Add("20012");
            Barcodes.Add("20013");
            Barcodes.Add("20014");
            Barcodes.Add("20015");
            Barcodes.Add("20016");
            Barcodes.Add("20017");
            Barcodes.Add("20018");
            Barcodes.Add("20019");
            Barcodes.Add("20020");
            Barcodes.Add("20021");
            Barcodes.Add("20022");
            Barcodes.Add("20023");
            Barcodes.Add("20024");
            Barcodes.Add("20025");
            Barcodes.Add("20026");
            Barcodes.Add("20027");
            Barcodes.Add("20028");
            Barcodes.Add("20029");
            Barcodes.Add("20030");
            Barcodes.Add("30001");
            Barcodes.Add("30002");
            Barcodes.Add("30003");
            Barcodes.Add("30004");
            Barcodes.Add("30005");
            Barcodes.Add("30006");
            Barcodes.Add("30007");
            Barcodes.Add("30008");
            Barcodes.Add("30009");
            Barcodes.Add("30010");
            Barcodes.Add("30011");
            Barcodes.Add("30012");
            Barcodes.Add("30013");
            Barcodes.Add("30014");
            Barcodes.Add("30015");
            Barcodes.Add("30016");
            Barcodes.Add("30017");
            Barcodes.Add("30018");
            Barcodes.Add("30019");
            Barcodes.Add("30020");
            Barcodes.Add("30021");
            Barcodes.Add("30022");
            Barcodes.Add("30023");
            Barcodes.Add("30024");
            Barcodes.Add("30025");
            Barcodes.Add("30026");
            Barcodes.Add("30027");
            Barcodes.Add("30028");
            Barcodes.Add("30029");
            Barcodes.Add("30030");
            Barcodes.Add("40001");
            Barcodes.Add("40002");
            Barcodes.Add("40003");
            Barcodes.Add("40004");
            Barcodes.Add("40005");
            Barcodes.Add("40006");
            Barcodes.Add("40007");
            Barcodes.Add("40008");
            Barcodes.Add("40009");
            Barcodes.Add("40010");
            Barcodes.Add("40011");
            Barcodes.Add("40012");
            Barcodes.Add("40013");
            Barcodes.Add("40014");
            Barcodes.Add("40015");
            Barcodes.Add("40016");
            Barcodes.Add("40017");
            Barcodes.Add("40018");
            Barcodes.Add("40019");
            Barcodes.Add("40020");
            Barcodes.Add("40021");
            Barcodes.Add("40022");
            Barcodes.Add("40023");
            Barcodes.Add("40024");
            Barcodes.Add("40025");
            Barcodes.Add("40026");
            Barcodes.Add("40027");
            Barcodes.Add("40028");
            Barcodes.Add("40029");
            Barcodes.Add("40030");
        }
    }
}
