using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;

public class UIManager : MonoBehaviour
{
    #region
    // 静态实例  
    private static UIManager _instance;

    // 公共属性，用于访问实例  
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // 如果实例不存在，查找场景中的UIManager对象  
                _instance = FindObjectOfType<UIManager>();

                // 如果没有找到，则创建一个新的UIManager对象  
                if (_instance == null)
                {
                    GameObject uiManagerObject = new GameObject("UIManager");
                    _instance = uiManagerObject.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // 如果实例已经存在且不是当前对象，则销毁当前对象  
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

      
    }

    private void OnDestroy()
    { 
        _instance= null;
    }
    #endregion

    [Header("播放文本")]
    public Button playBtn;

    public bool Isyong;
    public bool Isbutterfly;
    public float yongNum;
    public Image Yong;


    private int sceneIndex;

    private void Start()
    {
        sceneIndex = AudioManager.Instance.GetSceneIndex();

        playBtn.onClick.AddListener(OnPlayBtnDown);
    }

    private void Update()
    {
        YongChange();
        ButterflyBroth();
    }


    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    // 示例: 隐藏指定的面板  
    public void HidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }


    public void UpdateText(Text textComponent, string newText)
    {
        if (textComponent != null)
        {
            textComponent.text = newText;
        }
    }
    public void OnBtnDown(int num)
    {
        int currentSceneIndex = sceneIndex + num;
        if (currentSceneIndex <= 5 && currentSceneIndex >= 0)
        {
            SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
        }

    }

    public void SceneChanged(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void OnPlayBtnDown()
    {

        AudioManager.Instance.PlayTextSound();
     


    }

    public void OnPlayAllBtnDown()
    {
       // AudioManager.Instance.PlayTextSound();//AudioManager.Instance.GetTextAudioClipByNowScene());
        DirectorPlay();
    }
    /// <summary>
    /// 播放动画
    /// </summary>

    public void DirectorPlay()
    {
        if (GameObject.Find("Director"))
        {
            GameObject director = GameObject.Find("Director");
            director.GetComponent<PlayableDirector>().Play();
        }
    }
    /// <summary>
    /// 当ValueChange的时候 改变场景
    /// </summary>
    public void ChangeScene()
    { 
    
    }
   
    public void YongChange()
    {
        if (Isyong)
        {
            if (yongNum<=1)
            {
            yongNum += Time.deltaTime*0.1f;
            Yong.fillAmount = yongNum;
            }
        }
    }

    public void ButterflyBroth()
    {
        if (Isbutterfly)
        {
            if (yongNum >= 0.8f)
            {
                yongNum -= Time.deltaTime * 0.1f;
                Yong.fillAmount = yongNum;
            }
        }
    }

    public void IsButterflyChange()
    {

        Isbutterfly = !Isbutterfly;
        yongNum = 1;
        Yong.fillAmount = yongNum;
    }

    public void IsYongChange()
    {

        Isyong = !Isyong;
        yongNum = 0;
        Yong.fillAmount = yongNum;
    }


    

    // 其他UI管理相关的方法...  
}