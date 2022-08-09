using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dig : MonoBehaviour
{
    GameObject bring;
    public GameObject pp;
    Del del;
    public int myphase;
    public int mynumber;
    public check alive = new check(false, false, false, false);
    public int aliveCount;
    int random;
    
    public class check
    {
        public check(bool up,bool down, bool right, bool left)
        {
            this.up = up;
            this.down = down;
            this.right = right;
            this.left = left;
        }
        public bool up = false;
        public bool down = false;
        public bool right = false;
        public bool left = false;
    }

    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        bring = GameObject.Find("sys");
        del = bring.gameObject.GetComponent<Del>();
    }

    //private void Update()
    //{
        
    //    if (Input.GetKey(KeyCode.Space) && a == 0)
    //    {
    //        _Update();
    //        a += 1;
    //    }
    //    if (Input.GetKey(KeyCode.None)) a = 0;

    //    if (Input.GetKey(KeyCode.Return)) Debug.Log(mynumber + "" + alive.up + "" + alive.down + "" + alive.right + "" + alive.left + "AA" + (0 <= mynumber - 2 && del.WillDel[mynumber - 2] != null && !(mynumber - 1 == 0) && !((mynumber - 1) % 25 == 0)));
    //}

    // Update is called once per frame
    void Update()
    {

        alive.up = false;
        alive.down = false;
        alive.right = false;
        alive.left = false;
        //Debug.Log(del.WillDel);
        //Debug.Log(alive.up);
        //Debug.Log(mynumber);

        //すべて2ブロック先の存在を確認している
        aliveCount = 0;
        //上(+z方向)
        if (del.WillDel.Length - 1 >= mynumber + 50 && del.WillDel[mynumber + 50] != null)
        {
            alive.up = true;
            aliveCount += 1;
        }
        else if (!(del.WillDel.Length - 1 >= mynumber + 50) || del.WillDel[mynumber + 50] == null) alive.up = false;

        //下(-z方向)
        if (0 <= mynumber - 50 && del.WillDel[mynumber - 50] != null)
        {
            alive.down = true;
            aliveCount += 1;
        }
        else if (!(0 <= mynumber - 50) || del.WillDel[mynumber - 50] == null) alive.down = false;
        
        //右(+x方向)
        if (del.WillDel.Length - 1 >= mynumber + 2 && del.WillDel[mynumber + 2] != null && !(mynumber + 1 == 24) && !((mynumber + 1 - 24) % 25 == 0))
        {
            alive.right = true;
            aliveCount += 1;
        }
        else if (!(del.WillDel.Length - 1 >= mynumber + 2) || del.WillDel[mynumber + 2] == null || (mynumber + 1 == 24 || (mynumber + 1 - 24) % 25 == 0)) alive.right = false;

        //左(-x方向)
        if (0 <= mynumber - 2 && del.WillDel[mynumber - 2] != null && !Mathf.Approximately((mynumber - 1) % 25, 0))
        {
            alive.left = true;
            aliveCount += 1;
        }        else
        {
            if (!(0 <= mynumber - 2) || del.WillDel[mynumber - 2] == null || (mynumber - 1 == 0 || (mynumber - 1) % 25 == 0)) alive.left = false;
        }

        //Debug.Log(alive.right);
        if (aliveCount == 0 && myphase != del.phase)
        {
            del.phase = 2;
            Destroy(gameObject);
        }
        else if (myphase == 0 && del.phase == 1)
        {            
            random = 0;
            while ((random == 0 || (random == 1 && !alive.up) || (random == 2 && !alive.down) || (random == 3 && !alive.right) || (random == 4 && !alive.left) || random == 5) && !(aliveCount == 0))
            {
                random = Random.Range(1, 5);                
            }

            if (random == 1)
            {
                bring.transform.position = del.WillDel[mynumber + 50].transform.position;
                Destroy(del.WillDel[mynumber + 25]);
            }
            else if (random == 2)
            {
                bring.transform.position = del.WillDel[mynumber - 50].transform.position;
                Destroy(del.WillDel[mynumber - 25]);
            }
            else if (random == 3)
            {
                bring.transform.position = del.WillDel[mynumber + 2].transform.position;
                Destroy(del.WillDel[mynumber + 1]);
            }
            else if (random == 4)
            {                
                bring.transform.position = del.WillDel[mynumber - 2].transform.position;
                Destroy(del.WillDel[mynumber - 1]);
            }

            del.now = true;
            myphase += 1;
        }
        else if (myphase < 2 && del.phase == 2 && del.thinking == false)
        {
            if (del.yourturn == mynumber)
            {                
                random = 0;
                while ((random == 0 || (random == 1 && !alive.up) || (random == 2 && !alive.down) || (random == 3 && !alive.right) || (random == 4 && !alive.left) || random == 5) && !(aliveCount == 0))
                {
                    random = Random.Range(1, 5);                    
                }

                if (random == 1)
                {
                    bring.transform.position = del.WillDel[mynumber + 50].transform.position;
                    Destroy(del.WillDel[mynumber + 25]);
                }
                else if (random == 2)
                {
                    bring.transform.position = del.WillDel[mynumber - 50].transform.position;
                    Destroy(del.WillDel[mynumber - 25]);
                }
                else if (random == 3)
                {
                    bring.transform.position = del.WillDel[mynumber + 2].transform.position;
                    Destroy(del.WillDel[mynumber + 1]);
                }
                else if (random == 4)
                {                    
                    bring.transform.position = del.WillDel[mynumber - 2].transform.position;
                    Destroy(del.WillDel[mynumber - 1]);
                }

                del.now = true;
            }
        }
    }
}
