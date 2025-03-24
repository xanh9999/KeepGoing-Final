using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager instance;
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip shoot;
    public AudioClip jump;
    public AudioClip playerHurt;
    public AudioClip groundMonsterHurt;
    public AudioClip flyMonsterHurt;
    public AudioClip pickups;

    private void Awake()
    {   
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else   
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
