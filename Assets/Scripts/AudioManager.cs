using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    #region ����ģʽ
    // ��̬ʵ��  
    private static AudioManager _instance;

    // �������ԣ����ڷ���ʵ��  
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // ���ʵ�������ڣ����ҳ����е�AudioManager����  
                _instance = FindObjectOfType<AudioManager>();

                // ���û���ҵ����򴴽�һ���µ�AudioManager����  
                if (_instance == null)
                {
                    GameObject audioManagerObject = new GameObject("AudioManager");
                    _instance = audioManagerObject.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }

    // �����������������Ƶ�����߼������粥�ź�ֹͣ��Ч  

   

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
        // ���ʵ���Ѿ����ڲ��Ҳ��ǵ�ǰ���������ٵ�ǰ����  
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
    // ������Ƶ������صķ���...  


}