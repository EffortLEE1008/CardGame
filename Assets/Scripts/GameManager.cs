using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Select_card[] card;

    [SerializeField]
    Sprite[] card_image;

    List<int> randnum_lst = new List<int>(); 
          
    
    void Start()
    {
        UnduplicateRandom(randnum_lst);

        SpriteRenderer sp_card1 = card[0].GetComponent<SpriteRenderer>();
        sp_card1.sprite = card_image[randnum_lst[0]];

        SpriteRenderer sp_card2 = card[1].GetComponent<SpriteRenderer>();
        sp_card2.sprite = card_image[randnum_lst[1]];

        SpriteRenderer sp_card3 = card[2].GetComponent<SpriteRenderer>();
        sp_card3.sprite = card_image[randnum_lst[2]];

        SpriteRenderer sp_card4 = card[3].GetComponent<SpriteRenderer>();
        sp_card4.sprite = card_image[randnum_lst[3]];

        SpriteRenderer sp_card5 = card[4].GetComponent<SpriteRenderer>();
        sp_card5.sprite = card_image[randnum_lst[4]];

        Debug.Log(sp_card1.sprite.name.GetType());
        //card[0].my_spriteRendere.sprite = card[0].my_sprite[3];

    }

    // Update is called once per frame
    void Update()
    {


    }

    void UnduplicateRandom(List<int> tmp_lst)
    {
        int tmp_random = Random.Range(0, 32);

        for(int i=0; i < 7;)
        {
            if (tmp_lst.Contains(tmp_random))
            {
                tmp_random = Random.Range(0, 32);
            }
            else
            {
                tmp_lst.Add(tmp_random);
                i++;
            }
        }


    }




}
