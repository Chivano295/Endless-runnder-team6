using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource, musicSource;
    
    [SerializeField] AudioClip musicMenu;
    [SerializeField] AudioClip musicGame;


    public static AudioManager Instance;

    #region Singleton and audio sources
    //Gets all the relevant audio sources and assigns them to a variable
    private void Awake()
    {
        if (Instance != null && Instance != this) //singleton
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        musicSource.clip = musicGame;
        musicSource.Play();
    }
    #endregion

    #region Audio Function can be called from other classes
    public void PlayClip(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }
    #endregion
}
