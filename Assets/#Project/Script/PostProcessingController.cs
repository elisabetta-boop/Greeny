using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    private Bloom bloom;
    
    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bloomOnOff(bool value)
    {
        bloom.active = value;
    }
}
