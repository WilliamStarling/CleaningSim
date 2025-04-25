using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    //accessible elements
    [SerializeField] private Slider volumeSlider;
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component not found on this GameObject.");
            return;
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject.");
            return;
        }
    }
    public void PauseVideo()
    {
        if(videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    public void UpdateVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
