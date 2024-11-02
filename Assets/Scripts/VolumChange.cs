using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumChange : MonoBehaviour
{

    private float TextVolum;
    private float SceneVolum;
    // Start is called before the first frame update
    void Start()
    {
        TextVolum = transform.Find("Text/TextSound").GetComponent<Slider>().value;
        SceneVolum = transform.Find("Bg/BGSound").GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextVolumChange()
    {
        TextVolum = transform.Find("Text/TextSound").GetComponent<Slider>().value;
        Debug.Log(GameObject.Find("AudioManager/TextSound").GetComponent<AudioSource>().volume);
        GameObject.Find("AudioManager/TextSound").GetComponent<AudioSource>().volume= TextVolum;
    }
    public void SceneVolumChange()
    {
        SceneVolum = transform.Find("Bg/BGSound").GetComponent<Slider>().value;
        Debug.Log(GameObject.Find("AudioManager/BgSound").GetComponent<AudioSource>().volume);
        GameObject.Find("AudioManager/BgSound").GetComponent<AudioSource>().volume = SceneVolum;
    }
}
