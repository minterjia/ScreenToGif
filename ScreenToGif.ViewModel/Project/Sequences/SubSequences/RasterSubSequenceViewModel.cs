namespace ScreenToGif.ViewModel.Project.Sequences.SubSequences;

public abstract class RasterSubSequenceViewModel : RectSubSequenceViewModel
{
    private ushort _originalWidth;
    private ushort _originalHeight;
    private double _horizontalDpi;
    private double _verticalDpi;
    private byte _channelCount = 4;
    private byte _bitsPerChannel = 8;
    private ulong _dataLength;

    /// <summary>
    /// The original width (pre-resize) of the raster image.
    /// </summary>
    public ushort OriginalWidth
    {
        get => _originalWidth;
        set => SetProperty(ref _originalWidth, value);
    }

    /// <summary>
    /// The original height (pre-resize) of the raster image.
    /// </summary>
    public ushort OriginalHeight
    {
        get => _originalHeight;
        set => SetProperty(ref _originalHeight, value);
    }

    public double HorizontalDpi
    {
        get => _horizontalDpi;
        set => SetProperty(ref _horizontalDpi, value);
    }

    public double VerticalDpi
    {
        get => _verticalDpi;
        set => SetProperty(ref _verticalDpi, value);
    }

    /// <summary>
    /// The number of channels of the images.
    /// 4 is RGBA
    /// 3 is RGB
    /// </summary>
    public byte ChannelCount
    {
        get => _channelCount;
        set => SetProperty(ref _channelCount, value);
    }

    /// <summary>
    /// The bits per channel in the images.
    /// </summary>
    public byte BitsPerChannel
    {
        get => _bitsPerChannel;
        set => SetProperty(ref _bitsPerChannel, value);
    }

    /// <summary>
    /// The number of bytes of the capture content.
    /// </summary>
    public ulong DataLength
    {
        get => _dataLength;
        set => SetProperty(ref _dataLength, value);
    }

    /// <summary>
    /// The position of the stream of pixels (StreamPosition + the size of the headers).
    /// </summary>
    public abstract ulong DataStreamPosition { get; }
}