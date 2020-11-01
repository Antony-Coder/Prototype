using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoneMusic : MonoBehaviour
{
    private AudioSource foneMusic;
    // Start is called before the first frame update
    void Start()
    {
        foneMusic = gameObject.GetComponent<AudioSource>();

    }


}
