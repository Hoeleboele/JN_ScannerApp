public class ColorChangeChannel
{
    public delegate void ColorChange();
    public delegate void KidScanned(Kid scannedKid);
    public delegate void CodeScanned(string scannedCode);

    public ColorChange OnColorChange;

    public KidScanned OnCodeScanned;

    public CodeScanned OnCodeScannedRaw;
}