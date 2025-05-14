public class ColorChangeChannel
{
    public delegate void ColorChange();
    public delegate void CodeScanned(Kid scannedKid);

    public ColorChange OnColorChange;

    public CodeScanned OnCodeScanned;
}