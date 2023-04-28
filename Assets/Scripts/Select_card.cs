using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_card : MonoBehaviour
{

    GameObject card;

    [SerializeField]
    GameObject cardpos;
    Rigidbody2D my_rigid;

    Vector3 next_pos;

    float speed = 3f;


    Sprite[] my_sprite;
    SpriteRenderer my_spriteRendere;



    private void Awake()
    {
        my_rigid = transform.GetComponent<Rigidbody2D>();
        my_spriteRendere = transform.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        


    }


    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {



        next_pos = cardpos.transform.position - transform.position;
        next_pos = next_pos.normalized;

        my_rigid.MovePosition(transform.position + next_pos * 5 * Time.fixedDeltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, cardpos.transform.position, 5 * Time.fixedDeltaTime);
        //transform.position = Vector3.Lerp(transform.position, cardpos.transform.position, speed * Time.fixedDeltaTime);
        //transform.position = Vector3.Slerp(transform.position, cardpos[0].transform.position, 3 * Time.fixedDeltaTime);


    }





}
