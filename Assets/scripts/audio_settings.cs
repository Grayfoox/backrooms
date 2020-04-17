using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_settings : MonoBehaviour
{
    void Start()
    {
        AudioConfiguration configuration = AudioSettings.GetConfiguration();
        configuration.dspBufferSize = 4096;
    }
}
