using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolapp1_test
{
    class cardgame
    {
        //카드 숫자는 A(6) 7 8 9 10 J(11) Q(12) K(13) 
        //카드 모양은 클로버(c), 다이야(d), 하트(h) 스페이드(s)
        static void Main(string[] args)
        {

            //0      1      2      3      4      5     6       7
            string[] deck = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                             "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                             "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                             "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

            List<string> mycard = new List<string>();
            List<int> mycard_numOnly = new List<int>();
            List<string> mycard_shapeOnly = new List<string>();

            mycard.Add("09c"); 
            mycard.Add("11c");
            mycard.Add("10c");
            mycard.Add("13c");
            mycard.Add("12c");

            //
            for (int i = 0; i < mycard.Count; i++)
            {
                mycard_numOnly.Add(Convert.ToInt32(mycard[i].Substring(0, 2)));
            }


            //for (int i = 0; i < mycard.Count; i++)
            //{
            //    Console.WriteLine(i + "번째 인덱스에는 "+ mycard_numOnly[i] + 
            //                       "가 들어가 있습니다.");
            //}
            int paircount = 0;
            for (int i = 0; i < mycard.Count; i++)
            {
                mycard_shapeOnly.Add(mycard[i].Substring(2, 1));
            }

            for(int i = 0; i < mycard_numOnly.Count; i++)
            {
                for(int j=i; j<mycard_numOnly.Count; j++)
                {

                    if (i == j)
                        continue;

                    if (mycard_numOnly[i] == mycard_numOnly[j])
                    {
                        paircount++;
                    }                   
                }
                
            }

            switch (paircount)
            {
                case 1:
                    Console.WriteLine("원페어입니다.");

                    break;

                case 2:
                    Console.WriteLine("투페어입니다.");
                    break;

                case 3:
                    Console.WriteLine("트리플입니다.");
                    break;
                
                case 4:
                    Console.WriteLine("풀하우스입니다.");
                    break;

                case 6:
                    Console.WriteLine("포카드입니다.");
                    break;
            }

            for (int i = 0; i < mycard_numOnly.Count; i++)
            {
                Console.WriteLine(mycard_numOnly[i]);
            }
            Console.WriteLine("");

            mycard_numOnly.Sort();

            for (int i = 0; i < mycard_numOnly.Count; i++)
            {
                Console.WriteLine(mycard_numOnly[i]);
            }


            //stright인지 체크

            int a = mycard_numOnly[mycard_numOnly.Count - 1] - mycard_numOnly[0];
            Console.WriteLine(a);

            if (a== 4)
            {
                Console.WriteLine("straingt입니다");
            }
            else if ((mycard_numOnly[0] == 6)&& (mycard_numOnly[1]==10))
            {
                Console.WriteLine("로얄 스트레이트 입니다");
            }

            
            if (mycard_shapeOnly[0] == mycard_shapeOnly[mycard_shapeOnly.Count - 1])
            {
                Console.WriteLine("플러쉬입니다.");
            }




        }
        
    }
}
