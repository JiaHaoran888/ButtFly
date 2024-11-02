using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator ani;
    private Vector3 pos;
    public static bool IsPlay;

    private bool Ismove;
    private bool IsFly;
    // Start is called before the first frame update
    void Start()
    {
        IsPlay = false;
        ani = GetComponent<Animator>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        ani.SetBool("Play", IsPlay);

        if (IsPlay&& Ismove)
        {
            Invoke(nameof(Move), 2f);
        }
       /* else if (IsPlay && IsFly)
        {
            Invoke(nameof(Fly), 2f);
        }*/
        else if (!IsPlay)//||!IsFly)
        {
            transform.position = pos;
        }
    }


    public void Move()
    {
        if (transform.position.x<pos.x+5)
        {
            Ismove = true;
            transform.position += new Vector3(0.01f, 0, 0);
        }
        else if (transform.position.x > pos.x + 4.5f)
        {
            IsPlay = false;
        }
        
    }

    public void Fly()
    {
        if (transform.position.y < pos.y + 3)
        {
            IsFly = true;
            transform.position += new Vector3(0, 0.01f, 0);
        }
        else if (transform.position.y > pos.y + 2.5f)
        {
            IsFly = false;
        }

    }

}
