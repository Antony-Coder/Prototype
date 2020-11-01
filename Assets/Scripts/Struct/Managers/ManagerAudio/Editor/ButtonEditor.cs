using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CastomEditor
{

    [CustomEditor(typeof(DataAudioCreate))]
    public class customButton : Editor
    {
        private int count = 0;
        private bool chooseVisualize = false;
       // private string[] stringArrayAudioNames;


        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DataAudioCreate myScript = (DataAudioCreate)target;

            /*
            AudioClip[] Res = Resources.LoadAll<AudioClip>("Audio");
            int ResLength = Res.Length;
            string[] ResNames = new string[ResLength];

            for (int i = 0; i < ResLength; i++)
            {
                ResNames[i] = Res[i].name;
            }
            */

            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Add All AudioClips"))
            {
                chooseVisualize = true;
            }

            GUI.backgroundColor = Color.white;
            if (chooseVisualize)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Yes"))
                {
                    myScript.AddAll();
                    chooseVisualize = false;
                }
                if (GUILayout.Button("No"))
                {
                    chooseVisualize = false;
                }
                GUILayout.EndHorizontal();
            }

            List<string> AudioInAssetList = myScript.AudioListString; //лист всех имен аудио в листе ассета

            GUILayout.Label("Add One AudioClip");
            count = EditorGUILayout.Popup(count, ArrayAudioNames(AudioInAssetList));


            if (GUILayout.Button("Add"))
            {
                string[] ArrayNames = ArrayAudioNames(AudioInAssetList);

                if (ArrayNames.Length != 0)
                {
                    myScript.Add(ArrayNames[count]);
                    //Debug.Log(ArrayNames[count]);
                    count = 0;
                }               
 

            }

            /*
            GUILayout.Space(10);
            if (GUILayout.Button("Test"))
            {
                myScript.Test();
            }
            */

            GUILayout.Space(20);

            //myScript.AudioList[1].



            for (int i=0; i < AudioInAssetList.Count; i++)
            {
                GUILayout.BeginHorizontal();
                GUI.backgroundColor = Color.red;
                GUILayout.Label("AudioClip:  "+AudioInAssetList[i]);
                if (GUILayout.Button("x",GUILayout.MaxWidth(50)))
                {
                    myScript.Remove(i);
                }
                GUILayout.EndHorizontal();

                GUI.backgroundColor = Color.white;

                try
                {
                    GUILayout.BeginHorizontal();
                    myScript.AudioVolume[i] = GUILayout.HorizontalSlider(myScript.AudioVolume[i], -10, 10, GUILayout.MaxWidth(200));


                    GUILayout.Label("Volume:  "+ string.Format("{0:0.0}", myScript.AudioVolume[i]));
                    if (GUILayout.Button("Reset", GUILayout.MaxWidth(50)))
                    {
                        myScript.AudioVolume[i] = 0;
                    }
                    GUILayout.EndHorizontal();

                }
                catch { }


                GUILayout.BeginHorizontal();
                
                if (GUILayout.Button("Play"))
                {
                    PlayClip(myScript.AudioList[0]);
                }
                if (GUILayout.Button("Copy Name"))
                {
                    GUIUtility.systemCopyBuffer = AudioInAssetList[i];
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(30);


            }

            
            

        }

        public static void PlayClip(AudioClip clip, int startSample = 0, bool loop = false)
        {
            System.Reflection.Assembly unityEditorAssembly = typeof(AudioImporter).Assembly;
            System.Type audioUtilClass = unityEditorAssembly.GetType("UnityEditor.AudioUtil");
            System.Reflection.MethodInfo method = audioUtilClass.GetMethod(
                "PlayClip",
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
                null,
                new System.Type[] { typeof(AudioClip), typeof(int), typeof(bool) },
                null
            );
            method.Invoke(
                null,
                new object[] { clip, startSample, loop }
            );
        }

        /*
        private List<string> ListAudioNamesInFolder()
        {
            AudioClip[] Res = Resources.LoadAll<AudioClip>("Audio");
            List<string> ResNames = new List<string>();

            for (int i = 0; i<Res.Length; i++)
            {
                ResNames.Add(Res[i].name);
            }
            return ResNames;

        }*/

        private string[] ArrayAudioNames(List<string> AudioInAssetList)
        {
            List<string> AllNamesInFolder = new List<string>();

            //if (AudioInAssetList.Count == 0) return AllNamesInFolder.ToArray();

            AudioClip[] Res = Resources.LoadAll<AudioClip>("Audio");
           // List<string> ReturnArray = new List<string>();

            for (int i = 0; i < Res.Length; i++)
            {
                AllNamesInFolder.Add(Res[i].name);
            }
            

            for (int i = 0; i < AudioInAssetList.Count; i++)
            {
                AllNamesInFolder.Remove(AudioInAssetList[i]);
            }




            //Debug.Log($"AllNamesInFolder: {AllNamesInFolder.Count}, AudioInAssetList: {AudioInAssetList.Count});
            // if (count >= AllNamesInFolder.Count) count = 0;

            return AllNamesInFolder.ToArray();


        }

    }
}

