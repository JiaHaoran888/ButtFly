using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniController : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    public Button AnimController;

    private int num;
    // Start is called before the first frame update
    void Start()
    {
        
        AnimController.onClick.AddListener(() =>
        {
            num++;
            transform.GetComponent<Image>().sprite = num % 2 > 0 ? sprites[1] : sprites[0];
            Animation.IsPlay = num % 2 > 0 ? true : false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
