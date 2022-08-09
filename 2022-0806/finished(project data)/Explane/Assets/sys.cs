using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sys : MonoBehaviour
{
    public GameObject from;
    public int x;
    public int z;
    public int count;
    public Vector3 pos;

    public GameObject newl;

    public GameObject[] newly = new GameObject[625];

    Del del;
    // Start is called before the first frame update
    void Start()
    {
        del = GetComponent<Del>();

        x = 0;
        z = 0;
        pos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        //Instantiate(from, new Vector3(0, 0, 0), Quaternion.identity);
        while (z < 25)
        {
            //del.WillDel = new GameObject[count + 1];
            //del.WillDel[count]
            newl = Instantiate(from, pos, Quaternion.identity);
            Del_myself del_ = newl.gameObject.GetComponent<Del_myself>();
            del_.mynumber = count;
            newly[count] = newl;
            count += 1;
            x += 1;
            if (x > 24)
            {
                x = 0;
                z += 1;
            }
            pos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        }
        del.WillDel = new GameObject[newly.Length];
        del.WillDel = newly;

        del._Update();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
