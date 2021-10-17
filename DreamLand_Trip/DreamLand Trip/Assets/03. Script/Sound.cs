using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;


    private void Awake()
    {
        BackgroundMusic = GameObject.Find("SoundManger");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠

        backmusic.Play();
        DontDestroyOnLoad(gameObject); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)

    }
}
