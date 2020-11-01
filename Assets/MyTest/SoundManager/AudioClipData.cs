
using UnityEngine;

namespace Frozent.SoundManager
{
    [System.Serializable]
    public class AudioClipInfo 
    {
        public string id;
        public AudioClip[] clipVariants;
       
       
    }
    [CreateAssetMenu(fileName = "AudioClip Data",menuName = "Sound Manager/Create AudioClip Data ",order=1)]
    public class AudioClipData : ScriptableObject
    {
        [SerializeField] private AudioClipInfo[] clipInfo;
        
        public AudioClipInfo[] ClipInfo => clipInfo;
    }
}