using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Frozent.SoundManager
{
    [CustomEditor(typeof(ButtonSound))]
    public class ButtonSoundEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var buttonSound = (ButtonSound) target;
            var id = string.IsNullOrEmpty(buttonSound.DataId) ? "none" : buttonSound.DataId;
            GUILayout.Label($"Data ID: {id}");
            id = string.IsNullOrEmpty(buttonSound.SoundId) ? "none" : buttonSound.SoundId;
            GUILayout.Label($"Sound ID: {id}");
            GUILayout.Space(10);
            var dataNames = SoundManager.GetDataNames();
            if(dataNames==null)
                return;
            SetupDataButtons(dataNames, buttonSound);
            GUILayout.Space(10);
            var clipNames = SoundManager.GetClipNames(buttonSound.DataId);
            if(clipNames==null)
                return;
            SetupClickButtons(clipNames, buttonSound);
            GUI.backgroundColor=Color.white;



        }

        private static void SetupDataButtons(IReadOnlyList<string> dataNames,ButtonSound buttonSound)
        {
            var counter = 0;
            while (counter<dataNames.Count)
            {
                GUILayout.BeginHorizontal();
                for (int i = 0; i < 4 & counter< dataNames.Count; i++,counter++)
                {
                    var isNamesMatch = dataNames[counter] == buttonSound.DataId;
                    GUI.backgroundColor = isNamesMatch ? Color.green : Color.white;
                    if (!GUILayout.Button(dataNames[counter], GUILayout.MaxWidth(90)) || isNamesMatch)
                    {
                        continue;
                    }

                    buttonSound.DataId = dataNames[counter];
                    EditorUtility.SetDirty(buttonSound);//пометка что сцена требует сохранения
                    EditorSceneManager.MarkSceneDirty(buttonSound.gameObject.scene); //Отметьте сцену как измененную.

                }
                GUILayout.EndHorizontal();
                GUILayout.Space(5);
                
            }
        }
        private static void SetupClickButtons(IReadOnlyList<string> clipNames,ButtonSound buttonSound)
        {
            var counter = 0;
            while (counter<clipNames.Count)
            {
                GUILayout.BeginHorizontal();
                for (int i = 0; i < 5 & counter< clipNames.Count; i++,counter++)
                {
                    var isNamesMatch = clipNames[counter] == buttonSound.DataId;
                    GUI.backgroundColor = isNamesMatch ? Color.green : Color.white;
                    if (!GUILayout.Button(clipNames[counter], GUILayout.MaxWidth(90)) || isNamesMatch)
                    {
                        continue;
                    }

                    buttonSound.SoundId = clipNames[counter];
                    EditorUtility.SetDirty(buttonSound);
                    EditorSceneManager.MarkSceneDirty(buttonSound.gameObject.scene);
                    
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(5);
                
            }
        }
    }
}