using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Card2 : MonoBehaviour
{

    Rigidbody2D my_rigid;

    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

        Debug.Log("내위치는 " + transform.position);
        Debug.Log("목표의 위치는 " + goal.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
