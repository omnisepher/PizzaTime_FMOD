using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager AudioManagerInstance;

    [SerializeField] private FMODUnity.EventReference _themeSong;
    private FMOD.Studio.EventInstance themeSong;
    [SerializeField] private FMODUnity.EventReference _clockTick;
    private FMOD.Studio.EventInstance clockTick;

    private bool isPlaying = false;

    private void Awake()
    {
        AudioManagerInstance = this;
    }

    private void Start()
    {
        FMODUnity.RuntimeManager.GetBus("bus:/").stopAllEvents(STOP_MODE.IMMEDIATE);

        themeSong = FMODUnity.RuntimeManager.CreateInstance(_themeSong);
        // themeSong = FMODUnity.RuntimeManager.CreateInstance(FMOD.GUID.Parse("{609170fc-98f4-4d9d-b61d-b7680674cc68}")); //{609170fc-98f4-4d9d-b61d-b7680674cc68}
        // themeSong = FMODUnity.RuntimeManager.CreateInstance("event:/Menu/Menu 1");
        clockTick = FMODUnity.RuntimeManager.CreateInstance(_clockTick);

        if (themeSong.isValid())
        {
            themeSong.start();
            themeSong.setVolume(1.0f);
            isPlaying = true;
        }

        if (clockTick.isValid())
        {
            clockTick.start();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseResume();
        }

        if (GameManager.timer < 5.0f)
        {
            clockTick.setParameterByName("Volume", 1);
        }
        else
        {
            clockTick.setParameterByName("Volume", 0);
        }
    }

    public void SetVolume(float value)
    {
        themeSong.setVolume(value);
    }

    public void PauseResume()
    {
        if (isPlaying)
        {
            themeSong.setPaused(true);

        }
        else
        {
            themeSong.setPaused(false);
        }

        isPlaying = !isPlaying;
    }
}
