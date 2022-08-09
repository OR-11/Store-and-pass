using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del_myself : MonoBehaviour
{
    public GameObject parent;
    public GameObject leave;
    Del del;
    public int mynumber;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("sys");
        del = parent.gameObject.GetComponent<Del>();
        //Debug.Log(del.now);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space)) Debug.Log(del.now);
        if (Mathf.Approximately(del.transform.position.x, transform.position.x) && Mathf.Approximately(del.transform.position.z, transform.position.z) && del.now)
        {
            del.now = false;
            GameObject clone = Instantiate(leave, transform.position, Quaternion.identity);
            dig dig = clone.gameObject.GetComponent<dig>();
            dig.mynumber = mynumber;
            Destroy(gameObject);
        }
    }
}
