using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public LevelManager levelManager;
    public PlayerManager playerManager;
    private void Awake()
    {
        levelManager =  FindObjectOfType<LevelManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Start()
    {
        audioSource.Play();
    }
    private void Update()
    {
        if(levelManager.isWinning || playerManager.isGameOver)
        {
            audioSource.Stop();
        }
    }


}
