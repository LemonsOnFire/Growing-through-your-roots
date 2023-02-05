using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

   public AudioMixer _MainMixer;
    public float volumeTime = 6.0f;


    private int currentLayer = -1;

    public string[] ExposedVolumeLayers;


            
    

    public void PlayNewLayer()
    {

        currentLayer++;

        Debug.Log("Starting Aduio # " + currentLayer);

        switch (currentLayer)
        {
            case 0:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[0]));
                break;
            case 1:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[1]));
                break;
            case 2:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[2]));
                break;
            case 3:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[3]));
                break;
            case 4:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[4]));
                break;
            case 5:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[5]));
                break;
            case 6:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[6]));
                break;
            case 7:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[7]));
                break;

        }



    }


    public IEnumerator TurnOnAudioLayer(string myAudioLayer)
    {
        float myVolume = 0.0f;
        while(myVolume <= 1.0f)
        {
            myVolume += volumeTime / 100.0f;
            _MainMixer.SetFloat(myAudioLayer, myVolume);
            yield return new WaitForSecondsRealtime(volumeTime / 100.0f);
        }



    }
    /// <summary>
    /// The coroutine doing a calculation/action over time
    /// </summary>
   



   
}
