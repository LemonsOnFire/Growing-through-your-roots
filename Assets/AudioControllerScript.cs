using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioMixer _MainMixer;
    public float volumeTime = 6.0f;
    public float TargetDB = 10.0f;

    private int currentLayer = -1;

    public string[] ExposedVolumeLayers;

    /// <summary>
    /// used to Iterate through volumes
    /// </summary>
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
                StopFirstAudioLayer();
                break;
            case 3:
                StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[3]));
                break;
            case 4:
               // StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[4]));
                break;
            case 5:
              //  StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[5]));
                break;
            case 6:
              //  StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[6]));
                break;
            case 7:
               // StartCoroutine(TurnOnAudioLayer(ExposedVolumeLayers[7]));
                break;
         

        }
    }

    public void StopFirstAudioLayer()
    {
        StartCoroutine(TurnOffAudioLayer(ExposedVolumeLayers[4]));
    }

    /// <summary>
    /// Turn on a specific audio layer to a target DB 
    /// </summary>
    /// <param name="myAudioLayer"></param>
    /// <returns></returns>
    public IEnumerator TurnOnAudioLayer(string myAudioLayer)
    {
        float myVolume = 0.0f;
        _MainMixer.GetFloat(myAudioLayer, out myVolume);
        float tickRate = TargetDB / (volumeTime / 100.0f); 

        while (myVolume <= TargetDB)
        {
            myVolume += tickRate;
            _MainMixer.SetFloat(myAudioLayer, myVolume);
            yield return new WaitForSecondsRealtime(tickRate);
        }
    }
    /// <summary>
    /// The coroutine doing a calculation/action over time
    /// </summary>

    public IEnumerator TurnOffAudioLayer(string myAudioLayer)
    {
        float myVolume = 0.0f;
        _MainMixer.GetFloat(myAudioLayer, out myVolume);
        float tickRate = myVolume / (volumeTime / 100.0f);

        while (myVolume > 0.0f)
        {
            myVolume -= tickRate;
            _MainMixer.SetFloat(myAudioLayer, myVolume);
            yield return new WaitForSecondsRealtime(tickRate);
        }
    }



}
