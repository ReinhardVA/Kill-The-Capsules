using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public MusicManager musicManager;

    public AudioSource audioSource;

    private float _musicVolume = 0.5f;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(musicManager);
        audioSource.volume = _musicVolume;
        slider.value = _musicVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMusicVolume(){
        audioSource.volume = slider.value;
    }
}
