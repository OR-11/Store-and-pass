using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Del : MonoBehaviour
{
    public GameObject[] WillDel = new GameObject[0];//こんな名前してるけどただの保存用配列
    public GameObject[] sub = new GameObject[0];
    //int count = 0;
    public int count1;
    public int se;
    public bool now;

    public int phase;

    public int yourturn = -1;

    public int time = 0;

    public bool thinking;

    //public Vector3 my;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(WillDel.Length);
        phase = 1;
    }

    private void Update()
    {        
        if (phase == 2)
        {            
            if (GameObject.Find("point(Clone)") != null)
            {
                thinking = true;
                if (time == 0)
                {
                    yourturn += 1;
                    while (Random.Range(0, 10) != 1) 
                    {
                        while (WillDel[yourturn] != null)// && Random.Range(0, 5) != 1)
                        {
                            yourturn += 1;
                            if (yourturn > 624) yourturn = -1;
                        }
                    }
                    thinking = false;
                }
                time += 1;
                if (time > 2) time = 0;

                if (yourturn > 624) yourturn = -1;
            }
        }

        GameObject clone = GameObject.Find("point(Clone)");
        if (clone == null && phase == 2)
        {
            phase = 3;
            Debug.Log("End");
        }
    }

    // Update is called once per frame
    public void _Update()
    {

        transform.position += new Vector3((Random.Range(1, 12) * 2) - 1, 0, (Random.Range(1, 12) * 2) - 1);
        //my = transform.position;
        now = true;

        //if (WillDel.Length != 0)
        //{
        //    se += 1;

        //    if (se == 1)
        //    {
        //        int b = 0;
        //        int c_ = 0;
        //        GameObject a = null;
        //        while(a == null && WillDel.Length > 0 && c_ < 50)
        //        {
        //            if (WillDel.Length != 1 && WillDel.Length != 0) b = Random.Range(0, WillDel.Length - 1);
        //            else if (WillDel.Length != 0) b = 0;
        //            else break;
        //            a = WillDel[b];
        //            c_ += 1;
        //        }
        //        if (a == null) Debug.Log("no" + WillDel.Length +"+"+ b);
        //        if (WillDel.Length != 0) Destroy(a);

        //        count = 0;
        //        ArrayUtility.Clear(ref sub);
        //        sub = new GameObject[WillDel.Length];
        //        for (int c = WillDel.Length; c > 0; --c)
        //        {
        //            if (WillDel[c - 1] != null)
        //            {
        //                sub[count] = WillDel[c - 1];
        //                count += 1;
        //            }
        //            else
        //            {
        //                //Debug.Log(WillDel[c - 1]);
        //                //Debug.Log(c - 1);
        //            }
        //        }
        //        WillDel = new GameObject[count];

        //        count1 = 0;
        //        for (int c = WillDel.Length; c > 0; --c)
        //        {
        //            if (sub[c - 1] != null)
        //            {
        //                WillDel[count1] = sub[c - 1];
        //                count1 += 1;
        //            }
        //        }

        //        //WillDel = sub;
        //        sub = new GameObject[count];

        //        //WillDel = sub;
        //        //count1 += 1;
        //    }
            
        //}
        //if (!Input.GetKey(KeyCode.Space) || se > 0)se = 0;
    }

    //void cake()
    //{//もし実行中に増えるなら↓を増やすところに書き足す
    //    WillDel = new GameObject[WillDel.Length + 1];
    //    WillDel[WillDel.Length - 1] = 新しく増えたやつ;
    //}
}
