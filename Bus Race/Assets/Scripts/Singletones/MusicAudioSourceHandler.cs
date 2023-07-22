using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicAudioSourceHandler : MonoBehaviour
{
    private AudioSource _audioSource;

    public static MusicAudioSourceHandler Instance { get; private set; }

    private bool _isSoundEnable = true;

    public bool IsSoundEnable => _isSoundEnable;

    private void Awake()
    {
        CheckInstance();

        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        _audioSource.Play();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }

    private void CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}