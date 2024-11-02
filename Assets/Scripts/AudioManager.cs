using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    #region 单例模式
    // 静态实例  
    private static AudioManager _instance;

    // 公共属性，用于访问实例  
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 如果实例不存在，查找场景中的AudioManager对象  
                _instance = FindObjectOfType<AudioManager>();

                // 如果没有找到，则创建一个新的AudioManager对象  
                if (_instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    _instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // 在这个类中添加你的音频管理逻辑，例如播放和停止音效  

   

    private void OnDestroy()
    {
        _instance = null;
    }
    #endregion

    [SerializeField]
    public AudioClip[] ClipScenes = new AudioClip[6];
    public AudioClip[] ClipTexts = new AudioClip[6];
    
    [Header("AudioSource")]
    public AudioSource SceneAudioSource;
    public AudioSource TextAudioSource;

    public Scene currentScene;

    private Button playAni;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        // 如果实例已经存在并且不是当前对象，则销毁当前对象  
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Update()
    {
        if (playAni==null)
        {
            playAni = GameObject.Find("Canvas/Bg/PlayAnimButton (1)").GetComponent<Button>();
        }
        playAni.onClick.AddListener(PlaySceneSounds);
    }

    public void PlaySceneSound(AudioClip clip)
    {
        SceneAudioSource.clip = clip;
        SceneAudioSource.loop = true;
        SceneAudioSource.Play();
    }

    public void PlaySceneSounds()
    {
        PlaySceneSound(ClipScenes[GetSceneIndex()]);
    }

    public void PlayTextSound()
    {
        TextAudioSource.clip = GetTextAudioClipByNowScene();
        TextAudioSource.Play();
    }


    public AudioClip GetTextAudioClipByNowScene()
    {
        TextAudioSource.clip = ClipTexts[GetSceneIndex()];
        return TextAudioSource.clip;
    }

    public int GetSceneIndex()
    {
        currentScene = SceneManager.GetActiveScene();
        int index = currentScene.buildIndex;
        return index;
    }

    /* public AudioClip GetSceneAudioClipByNowScene()
     {

         switch (UIManager.Instance.nowPlayScene)
         {
             case 0:
                 return ClipScene0;
                 break;
             case 1:
                 return ClipScene1;
                 break;
             case 2:
                 return ClipScene2;
                 break;
             case 3:
                 return ClipScene3;
                 break;
             case 4:
                 return ClipScene4;
                 break;
             case 5:
                 return ClipScene5;
                 break;
             default:
                 return null;
                 break;
         }

     }*/
    // 其他音频管理相关的方法...  


}