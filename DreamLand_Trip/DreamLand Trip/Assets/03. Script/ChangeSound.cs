using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    public Image DefaultImage; //기존 이미지
    public Sprite OnSprite, OffSprite; // 온 이미지


    GameObject BackgroundMusic;
    AudioSource backmusic;
    bool off=false;

    public void OnOffSoundImage()
    {
        if(off == true)
        {
            DefaultImage.sprite = OnSprite; //소리를 킬 때
            off = false;
        }
        else
        {
            DefaultImage.sprite = OffSprite; // 소리를 끌 때
            off = true;
        }
            
    }

    public void BackGroundMusicOffButton() //배경음악 키고 끄는 버튼
    {
        BackgroundMusic = GameObject.Find("SoundManger");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) backmusic.Pause();
        else backmusic.Play();
    }
}
