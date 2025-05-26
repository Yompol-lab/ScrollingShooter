using UnityEngine;

public class AltitudeWarning : MonoBehaviour
{
    public AudioSource warningAudio;    
    public float triggerHeight = 5f;
    private bool isPlaying = false;

    void Update()
    {
        if (transform.position.y <= triggerHeight)
        {
            if (!isPlaying)
            {
                warningAudio.Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                warningAudio.Stop(); 
                isPlaying = false;
            }
        }
    }
}
