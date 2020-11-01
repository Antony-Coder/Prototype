using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Frozent.SoundManager
{
    public static class SoundManager 
    {
        private  static readonly List<AudioClipInfo> AudioCliInfos=new List<AudioClipInfo>();

#if UNITY_EDITOR
        private static AudioClipData[] allClipData;
        
#endif

        private static GameObject mainAudioSourceObject;
        private static readonly List<AudioSource> AudioSources=new List<AudioSource>();
        //перегрузка метода с проверками (включены или выключены звуки и музыка) 
        public static void PlayAudioClip(string id,string audio)
        {
            if (audio == "music")
            {
      
                var clipInfo = AudioCliInfos.FirstOrDefault(c => c.id == id);
                if (clipInfo == null)
                {
                    Debug.LogError($"clip info with id {id} not found");
                    return;
                }

                PlayClip(clipInfo);
            }

            if (audio == "sound")
            {
     
                var clipInfo = AudioCliInfos.FirstOrDefault(c => c.id == id);
                if (clipInfo == null)
                {
                    Debug.LogError($"clip info with id {id} not found");
                    return;
                }

                PlayClip(clipInfo);
            }
        }
        public static void PlayAudioClip(string id)
        {
            var clipInfo = AudioCliInfos.FirstOrDefault(c => c.id == id);
            if (clipInfo == null)
            {
                Debug.LogError($"clip info with id {id} not found");
                return;
            }
            PlayClip(clipInfo);
        }

#if UNITY_EDITOR
        public static string[] GetDataNames()
        {
            allClipData = Resources.LoadAll<AudioClipData>("Audio");
            var dataNames = allClipData?.Select(c => c.name);
            return dataNames?.ToArray();
        }

        public static string[] GetClipNames(string dataId)
        {
            allClipData = Resources.LoadAll<AudioClipData>("Audio");
            var clipData=allClipData.FirstOrDefault(c => c.name == dataId);
            return clipData != null ? clipData.ClipInfo?.Select(c => c.id).ToArray() : null;
            
        }
#endif
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            mainAudioSourceObject=new GameObject("Main AudioSource");
            Object.DontDestroyOnLoad(mainAudioSourceObject);
            var newSource = mainAudioSourceObject.AddComponent<AudioSource>();
            AudioSources.Add(newSource);
            var clipsData = Resources.LoadAll<AudioClipData>("Audio");
            foreach (var clipData in clipsData)
            {
                AudioCliInfos.AddRange(clipData.ClipInfo.ToList());
            }
        }

        private static void PlayClip(AudioClipInfo clipInfo)
        {
            if (clipInfo.clipVariants == null || clipInfo.clipVariants.Length == 0)
            {
                return;
            }

            var clips = clipInfo.clipVariants;
            var clip = clips.Length == 1 ? clips[0] : clips[Random.Range(0, clips.Length)];
            var audioSource = AudioSources.FirstOrDefault(a => !a.isPlaying);
            if (audioSource == null)
            {
                audioSource = mainAudioSourceObject.AddComponent<AudioSource>();
            }

            audioSource.clip = clip;
            audioSource.volume = 0.1f;
            audioSource.Play();
        }
        
    }
}