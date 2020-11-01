using System.Collections.Generic;

using UnityEditor;

namespace Frozent.SoundManager
{
    [CustomEditor(typeof(AudioClipData))]
    public class AudioClipDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var audioClipData = (AudioClipData) target;
            var hashSet=new HashSet<string>();
            foreach (var clipInfo in audioClipData.ClipInfo)
            {
                if (!hashSet.Add(clipInfo.id))
                {
                    clipInfo.id = "Invalid clip id";
                }
            }
           
        }
    }
}