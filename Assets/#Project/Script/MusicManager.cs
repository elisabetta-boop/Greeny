using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager musicManagerInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }


}
