using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Del : MonoBehaviour
{
    public GameObject[] WillDel = new GameObject[0];
    public GameObject[] sub = new GameObject[0];
    int count = 0;
    public int count1;
    public int se;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(WillDel.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && WillDel.Length != 0)
        {
            se += 1;

            if (se == 1)
            {
                int b = 0;
                int c_ = 0;
                GameObject a = null;
                while(a == null && WillDel.Length > 0 && c_ < 50)
                {
                    if (WillDel.Length != 1 && WillDel.Length != 0) b = Random.Range(0, WillDel.Length - 1);
                    else if (WillDel.Length != 0) b = 0;
                    else break;
                    a = WillDel[b];
                    c_ += 1;
                }
                if (a == null) Debug.Log("no" + WillDel.Length +"+"+ b);
                if (WillDel.Length != 0) Destroy(a);

                count = 0;
                ArrayUtility.Clear(ref sub);
                sub = new GameObject[WillDel.Length];
                for (int c = WillDel.Length; c > 0; --c)
                {
                    if (WillDel[c - 1] != null)
                    {
                        sub[count] = WillDel[c - 1];
                        count += 1;
                    }
                    else
                    {
                        //Debug.Log(WillDel[c - 1]);
                        //Debug.Log(c - 1);
                    }
                }
                WillDel = new GameObject[count];

                count1 = 0;
                for (int c = WillDel.Length; c > 0; --c)
                {
                    if (sub[c - 1] != null)
                    {
                        WillDel[count1] = sub[c - 1];
                        count1 += 1;
                    }
                }

                //WillDel = sub;
                sub = new GameObject[count];

                //WillDel = sub;
                //count1 += 1;
            }
            
        }
        if (!Input.GetKey(KeyCode.Space) || se > 0)se = 0;
    }

    //void cake()
    //{//‚à‚µÀs’†‚É‘‚¦‚é‚È‚ç«‚ğ‘‚â‚·‚Æ‚±‚ë‚É‘‚«‘«‚·
    //    WillDel = new GameObject[WillDel.Length + 1];
    //    WillDel[WillDel.Length - 1] = V‚µ‚­‘‚¦‚½‚â‚Â;
    //}
}
