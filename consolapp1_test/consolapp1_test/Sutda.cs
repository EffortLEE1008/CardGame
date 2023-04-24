using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolapp1_test
{
    class Sutda
    {
        // a b c d e f g h i j 
        // 1 2 3 4 5 6 7 8 9 10
        static void Main(string[] args)
        {
            Dictionary<string, int> jokbo = new Dictionary<string, int>()
            {

                {"aA",200 }, {"bB", 220 }, {"cC", 240 }, {"dD", 260 }, {"eE", 280 }, {"fF", 300 },
                {"gG", 320 }, {"hH", 340 }, {"iI", 360 }, {"jJ", 380 },

                {"df", 40 }, {"dF", 40 }, {"Df", 40 }, {"DF", 40 }, //세륙
                {"ai", 50 }, {"aI", 50 }, {"Ai", 50 }, {"AI", 50 }, //구삥
                {"dj", 60 }, {"dJ", 60 }, {"Dj", 60 }, {"DJ", 60 }, //장사
                {"ad", 70 }, {"aD", 70 }, {"Ad", 70 }, {"AD", 70 }, //독사
                {"aj", 80 }, {"aJ", 80 }, {"Aj", 80 }, {"AJ", 80 }, //장삥
                {"ab", 90 }, {"aB", 90 }, {"Ab", 90 }, {"AB", 90 }, //알리

                {"AC", 1300 }, {"AH", 1300 }, {"CH", 3800 } //광땡

            };

            Dictionary<string, int> not_in_jokbo = new Dictionary<string, int>()
            {
                {"a", 1 }, {"b", 2 }, {"c", 3 }, {"d", 4 }, {"e", 5 }, {"f", 6 }
                , {"g", 7 }, {"h", 8 }, {"i", 9 }, {"j", 10 },
                {"A", 1 }, {"B", 2 }, {"C", 3 }, {"D", 4 }, {"E", 5 }, {"F", 6 }
                , {"G", 7 }, {"H", 8 }, {"I", 9 }, {"J", 10 }
            };

            List<string> ddang_list = new List<string>()
            {
                "aA", "bB", "cC", "dD", "eE", "fF", "gG", "hH", "iI", "jJ"
            };

            List<string> ddangkiller_list = new List<string>()
            {
                "cg", "Cg", "cG", "CG"
            };

            List<string> gyangddang_list = new List<string>()
            {
                "AC", "AH"
            };


            /////////////////0    1    2    3    4    5    6    7    8    9
            String[] dec = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};


            List<string> player0 = new List<string>() { dec[6], dec[3] }; //현재 암행어사
            List<string> computer1 = new List<string>() { dec[16], dec[2] }; // 현재 땡잡이
            List<string> computer2 = new List<string>() { dec[11], dec[1] }; // 2땡
            List<string> computer3 = new List<string>() { dec[10], dec[12] }; // 18광땡

            List<string> players_card_list = new List<string>();
            List<int> players_value_list = new List<int>();

            player0.Sort();
            computer1.Sort();
            computer2.Sort();
            computer3.Sort();

            string player0_concat = player0[0] + player0[1];
            string computer1_concat = computer1[0] + computer1[1];
            string computer2_concat = computer2[0] + computer2[1];
            string computer3_concat = computer3[0] + computer3[1];

            players_card_list.Add(player0_concat);
            players_card_list.Add(computer1_concat);
            players_card_list.Add(computer2_concat);
            players_card_list.Add(computer3_concat);

            Console.WriteLine(players_card_list[0]);
            Console.WriteLine(players_card_list[1]);
            Console.WriteLine(players_card_list[2]);
            Console.WriteLine(players_card_list[3]);

            //Console.WriteLine(not_in_jokbo[players_card_list[0][0].ToString()]);

            //카드 값 부여
            for (int i = 0; i < players_card_list.Count; i++)
            {
                
                if (jokbo.ContainsKey(players_card_list[i]))
                {
                    players_value_list.Add(jokbo[players_card_list[i]]);

                }
                else
                {
                    players_value_list.Add((not_in_jokbo[players_card_list[i][0].ToString()] + not_in_jokbo[players_card_list[i][1].ToString()]) % 10);
                }

            }

            Console.WriteLine("ㅡㅡㅡ카드값 부여ㅡㅡㅡ");
            Console.WriteLine(players_value_list[0]);
            Console.WriteLine(players_value_list[1]);
            Console.WriteLine(players_value_list[2]);
            Console.WriteLine(players_value_list[3]);


            bool isDDang = false;

            for (int i = 0; i < ddang_list.Count; i++)
            {

                if (players_card_list.Contains(ddang_list[i]))
                {
                    //Console.WriteLine("땡이 존재합니다.");
                    isDDang = true;
                    break;
                }
                else
                {
                    //Console.WriteLine("땡이 존재하지 않습니다.");
                }
            }

            if (isDDang)
            {
                for (int i = 0; i < players_card_list.Count; i++)
                {
                    if (ddangkiller_list.Contains(players_card_list[i]))
                    {
                        //Console.WriteLine("DDang잡이의 값을 변경합니다.");
                        players_value_list[i] = 500;
                    }
                    else
                    {
                        //Console.WriteLine("변경값이 없습ㄴ디ㅏ..");
                    }

                }

            }

            // indexOf로 바꿔보기
            //for (int i = 0; i < ddang_list.Count; i++)
            //{
            //    int temp = players_card_list.IndexOf(ddang_list[i]);
            //    if (temp!=-1)
            //    {
            //        //Console.WriteLine("땡이 존재합니다.");
            //    }
            //    else
            //    {
            //        //Console.WriteLine("땡이 존재하지 않습니다.");
            //    }
            //}


            bool isGyangDDang = false;

            for (int i = 0; i < gyangddang_list.Count; i++)
            {
                if (players_card_list.Contains(gyangddang_list[i]))
                {

                    isGyangDDang = true;
                    //Console.WriteLine("광땡이 존재합니다.");
                    break;

                }
                else
                {
                    //Console.WriteLine("광땡이 존재하지 않습니다..");
                }

            }

            if (isGyangDDang)
            {
                for(int i =0; i<players_card_list.Count; i++)
                {
                    if (players_card_list[i]=="dg")
                    {
                        players_value_list[i] = 1800;
                    }

                }

            }
            Console.WriteLine("player들의 값을 변경했습니다.");
            Console.WriteLine("player0의 값은 : " + players_value_list[0]);
            Console.WriteLine("computer1의 값은 : " + players_value_list[1]);
            Console.WriteLine("computer2의 값은 : " + players_value_list[2]);
            Console.WriteLine("computer3의 값은 : " + players_value_list[3]);

            int max_index = 0;
            int max = 0;
            for(int i=0; i < players_value_list.Count; i++)
            {
                if (players_value_list[i] > max)
                {
                    max = players_value_list[i];
                    max_index = i;
                }

            }

            Console.WriteLine("가장 높은 값을 가진 플레이어는 : " + max_index);
            Console.WriteLine("가장 높은 값을 가진 플레이어의 값은 : " + players_value_list[max_index]);





        }
    }
}


