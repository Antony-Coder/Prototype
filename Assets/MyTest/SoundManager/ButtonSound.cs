using System;
using UnityEngine;
using UnityEngine.UI;

namespace Frozent.SoundManager
{
    [RequireComponent(typeof(Button))]
    public class ButtonSound : MonoBehaviour
    {
        [SerializeField] private Button button;

        [SerializeField] private string soundId;
#if UNITY_EDITOR
        [SerializeField] private string dataId;
        public string DataId
        {
            get => dataId;
            set => dataId = value;
        }

        public string SoundId
        {
            get => soundId;
            set => soundId = value;
        }
#endif
        private void Reset()
        {
            button=GetComponent<Button>();
            
        }

        public void Start()
        {
            button = GetComponent<Button>();
            if(button.interactable)
                button.onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            SoundManager.PlayAudioClip(soundId,"sound");
        }

        // public void PlayMusic()
        // {
        //     SoundManager.PlayAudioClip(soundId,"music");
        // }
    }
}