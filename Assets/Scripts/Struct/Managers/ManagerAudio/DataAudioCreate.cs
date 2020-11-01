using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[CreateAssetMenu(fileName = "ManagerAudio", menuName = "Managers/ManagerAudio")]
public class DataAudioCreate : ManagerBase
{
    // [SerializeField] [Range(-10.0f, 10.0f)] float k = 0;
    public List<AudioClip> AudioList {  get; private set; } = new List<AudioClip>();
    public List<float> AudioVolume { get; private set; } = new List<float>();
    /*
public myEnum DropDown = myEnum.Item1;
public enum myEnum
{
    Item1,
    Item2,
    Item3
}
*/
    public List <string> AudioListString
    {
        get
        {
            List<string> ResNames = new List<string>();
            
            for (int i = 0; i < AudioList.Count; i++)
            {
                ResNames.Add(AudioList[i].name);
            }
            return ResNames;
        }
    }

   


#if UNITY_EDITOR
    public void AddAll()
    {
        AudioClip[] Res = Resources.LoadAll<AudioClip>("Audio");
        AudioList.Clear();
        AudioList.AddRange(Res);

        AudioVolume.Clear();
        AudioVolume.AddRange(new float[Res.Length]);

    }

    public void Add(string element)
    {

        AudioClip[] Res = Resources.LoadAll<AudioClip>("Audio");

        List<string> AudioListString = new List<string>();


        for (int i = 0; i < Res.Length; i++)
        {
            AudioListString.Add(Res[i].name);
        }

        int index = 0;

        for (int i = 0; i < AudioListString.Count; i++)
        {
            if(AudioListString[i]==element)
            {
                index = i;
                break;
            }
        }
        
        AudioList.Add(Res[index]);

        AudioVolume.Insert(index, 0);


    }



    public void Remove(int num)
    {
        AudioList.RemoveAt(num);
        AudioVolume.RemoveAt(num);
    }


    public void Test()
    {
        Debug.Log("count: "+ AudioVolume.Count);
        for (int i = 0; i < AudioVolume.Count; i++)
        {
           Debug.Log(AudioVolume[i]);
        }

    }
#endif






}
