using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Select_card[] card;

    [SerializeField]
    Sprite[] card_image;

    List<int> randnum_lst = new List<int>();
    List<string> card_lst = new List<string>();
    List<int> card_lst_numOnly = new List<int>();
    List<string> card_lst_shapeOnly = new List<string>();

    [SerializeField]
    Text scoretext;

    

    void Start()
    {
        UnduplicateRandom(randnum_lst);
     
        SpriteRenderer sp_card1 = card[0].GetComponent<SpriteRenderer>();
        sp_card1.sprite = card_image[randnum_lst[0]];
        card_lst.Add(card_image[randnum_lst[0]].name);
        card_lst_numOnly.Add(int.Parse(card_image[randnum_lst[0]].name.Substring(0,2)));
        card_lst_shapeOnly.Add(card_image[randnum_lst[0]].name.Substring(2, 1));
        

        SpriteRenderer sp_card2 = card[1].GetComponent<SpriteRenderer>();
        sp_card2.sprite = card_image[randnum_lst[1]];
        card_lst.Add(card_image[randnum_lst[1]].name);
        card_lst_numOnly.Add(int.Parse(card_image[randnum_lst[1]].name.Substring(0, 2)));
        card_lst_shapeOnly.Add(card_image[randnum_lst[1]].name.Substring(2, 1));

        SpriteRenderer sp_card3 = card[2].GetComponent<SpriteRenderer>();
        sp_card3.sprite = card_image[randnum_lst[2]];
        card_lst.Add(card_image[randnum_lst[2]].name);
        card_lst_numOnly.Add(int.Parse(card_image[randnum_lst[2]].name.Substring(0, 2)));
        card_lst_shapeOnly.Add(card_image[randnum_lst[2]].name.Substring(2, 1));

        SpriteRenderer sp_card4 = card[3].GetComponent<SpriteRenderer>();
        sp_card4.sprite = card_image[randnum_lst[3]];
        card_lst.Add(card_image[randnum_lst[3]].name);
        card_lst_numOnly.Add(int.Parse(card_image[randnum_lst[3]].name.Substring(0, 2)));
        card_lst_shapeOnly.Add(card_image[randnum_lst[3]].name.Substring(2, 1));

        SpriteRenderer sp_card5 = card[4].GetComponent<SpriteRenderer>();
        sp_card5.sprite = card_image[randnum_lst[4]];
        card_lst.Add(card_image[randnum_lst[4]].name);
        card_lst_numOnly.Add(int.Parse(card_image[randnum_lst[4]].name.Substring(0, 2)));
        card_lst_shapeOnly.Add(card_image[randnum_lst[4]].name.Substring(2, 1));


        
        
        //Debug.Log(card_lst_numOnly[0] + " " + card_lst_numOnly[1] + " " + card_lst_numOnly[2] + " " + card_lst_numOnly[3] + " " + card_lst_numOnly[4]);
        //Debug.Log(sp_card1.sprite.name.GetType());
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
    public void Restart()
    {
        SceneManager.LoadScene(0);

    }

    public void Batting()
    {
        
        int paircount = 0;

        for(int i = 0; i<card_lst_numOnly.Count; i++)
        {
            for(int j=i; j< card_lst_numOnly.Count; j++)
            {

                if (i == j)
                    continue;

                if (card_lst_numOnly[i] == card_lst_numOnly[j])
                {
                    paircount++;                  
                }

            }

        }


        card_lst_numOnly.Sort();
        card_lst_shapeOnly.Sort();
        Debug.Log(card_lst_numOnly[0]+" "+ card_lst_numOnly[1] + " " +
            card_lst_numOnly[2] + " " + card_lst_numOnly[3] + " " + card_lst_numOnly[4]);

        bool isStraight = false;
        int strightcount = 0;
        bool isRoyalStraight = false;
        bool isflush = false;
        int a = card_lst_numOnly[card_lst_numOnly.Count - 1] - card_lst_numOnly[0];

        if((card_lst_numOnly[0]==6)&& (card_lst_numOnly[1] == 10)&& (card_lst_numOnly[2] == 11)
            && (card_lst_numOnly[3] == 12)&& (card_lst_numOnly[4] == 13))
        {
            isRoyalStraight = true;
        }

        for(int i = 0; i < card_lst_numOnly.Count - 1; i++)
        {
            isStraight = (card_lst_numOnly[i + 1] - card_lst_numOnly[i]) == 1;
            if (isStraight)
                strightcount++;
        }


        if (card_lst_shapeOnly[0] == card_lst_shapeOnly[card_lst_shapeOnly.Count - 1])
        {
            isflush = true;
        }


        if (isRoyalStraight && isflush)
            scoretext.text = "축하합니다 로얄 스트레이트 플러쉬!";
            
        else if (strightcount==4 && isflush)
            scoretext.text = "축하합니다 스트레이트 플러쉬!";

        else if (isRoyalStraight)
            scoretext.text = "축하합니다 로얄 스트레이트!!";

        else if (paircount == 6)
            scoretext.text = "축하합니다 포카드!";

        else if (paircount == 4)
            scoretext.text = "축하합니다 풀하우스!!"; 

        else if (isflush)
            scoretext.text = "축하합니다 플러쉬!";

        else if (strightcount==4)
            scoretext.text = "축하합니다 스트레이트!!";
 

        else if (paircount == 3)
            scoretext.text = "약간 아쉽네여 트리플!!";

        else if (paircount == 2)
            scoretext.text = "아쉽네여 투페어";

        else if (paircount == 1)
            scoretext.text = "힘내세요 원페어";
        
        else
            scoretext.text = "어이쿠... 아무것도아닌 탑카드에요 ㅠ";
        

    }




}
