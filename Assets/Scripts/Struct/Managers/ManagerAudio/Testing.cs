using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private void Start()
    {
        Audio.Ins.SettingsAudioSorce().loop = true;
    }
}
