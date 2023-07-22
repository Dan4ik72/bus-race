public class VolumeButtonModel : ButtonModel
{
    private MusicAudioSourceHandler _musicAudioHandler;

    public VolumeButtonModel(MusicAudioSourceHandler musicAudioHandler)
    {
        _musicAudioHandler = musicAudioHandler;
    }
}