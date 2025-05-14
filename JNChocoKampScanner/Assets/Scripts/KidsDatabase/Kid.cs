public class Kid
{
    public string Code { get; set; }
    public KidGroup Group { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsCorrectCode { get; set; }

    public string KidToString()
    {
        string toreturn = $"{Code},{KidGroupString()},{FirstName},{LastName},{IsCorrectCode}";
        return toreturn;
    }

    public Kid StringToKid(string kidString)
    {
        string[] splitKid = kidString.Split(';');
        Kid kid = new Kid();
        kid.Code = splitKid[0];
        kid.FirstName = splitKid[1];
        kid.LastName = splitKid[2];

        if (splitKid[3] == "1") { kid.IsCorrectCode = true; }
        else { kid.IsCorrectCode = false; }

        kid.Group = kidGroupFromBarcode(kid.Code);
        return kid;
    }

    private KidGroup kidGroupFromBarcode(string barcode)
    {
        switch (barcode.ToCharArray()[0])
        {
            case '1':
                return KidGroup.Senior;
            case '2':
                return KidGroup.Maxioor;
            case '3':
                return KidGroup.Junior;
            case '4':
                return KidGroup.Minioor;
            default:
                return KidGroup.Senior;
        }

    }

    private KidGroup StringToGroup(string v)
    {
        switch (v)
        {
            case "Senior":
                return KidGroup.Senior;
            case "Maxioor":
                return KidGroup.Maxioor;
            case "Junior":
                return KidGroup.Junior;
            case "Minioor":
                return KidGroup.Minioor;
            default:
                return KidGroup.Senior;
        }
    }

    public string KidGroupString()
    {
        switch (Group)
        {
            case KidGroup.Senior:
                return "Senior";
            case KidGroup.Maxioor:
                return "Maxioor";
            case KidGroup.Junior:
                return "Junior";
            case KidGroup.Minioor:
                return "Minioor";
            default:
                return "";
        }
    }
}

public enum KidGroup
{
    Senior,
    Maxioor,
    Junior,
    Minioor
}