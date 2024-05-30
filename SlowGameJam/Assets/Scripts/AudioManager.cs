using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //This is the third implementation of my AudioManager script
    //To add a new sound, add a public AudioClip
    //And then add a public Void that can be called from other scripts to one call it
    //The actual audiodesign will be left to somebody else.
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip levelCompleteSound;
    public AudioClip snakeSound;
    public AudioClip branchSound;
    public AudioClip breakSound;
    public AudioClip dieSound;

    //Singleton pattern for easy access
    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        //Donotdestroy + load if there's no instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource component is found, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // This audiomanager script works by calling public voids on other scripts. It's hacky but works. 

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landSound);
    }

    public void PlayLevelCompleteSound()
    {
        audioSource.PlayOneShot(levelCompleteSound);
    }

    public void PlaySnakeSound()
    {
        audioSource.PlayOneShot(snakeSound);
    }

    public void PlayBranchSound()
    {
        audioSource.PlayOneShot(branchSound);
    }
    public void PlayBreakSound()
    {
        audioSource.PlayOneShot(breakSound);
    }

    public void PlayDieSound()
    {
        audioSource.PlayOneShot(dieSound);
    }
}
