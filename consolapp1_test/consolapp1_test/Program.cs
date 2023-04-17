using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolapp1_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int strike = 0;
            int ball = 0;
            int out_count = 0;
            bool isinball = false;
            bool iswin = false;
            Random rand = new Random();
            int rand_num = rand.Next(100, 999);
            String num = rand_num.ToString();

            Console.WriteLine("숫자를 생각 했습니다.");

            for (int k=0; k<10;k++)
            {
                Console.WriteLine("숫자를 입력하세요.--남은횟수--" + (10-k));
                string input = Console.ReadLine();
                //string input = "312";

                for (int i = 0; i < num.Length; i++)
                {
                    for (int j = 0; j < num.Length; j++)
                    {

                        if (num[i] == input[j])
                        {
                            isinball = true;
                            if (i == j)
                            {
                                strike++;
                                //Console.WriteLine("continue가 실행됩니다.");
                                continue;
                            }

                            
                            ball++;

                        }

                    }
                    if (!isinball)
                        out_count++;

                    isinball = false;


                }

                Console.WriteLine("Strike의 갯수는 : " + strike);
                Console.WriteLine("Ball의 갯수는 : " + ball);
                Console.WriteLine("out의 갯수는 : " + out_count);
                Console.WriteLine("\n");

                if (strike == 3)
                {
                    Console.WriteLine("정답입니다~");
                    iswin = true;
                    break;
                }

                strike = 0;
                ball = 0;
                out_count = 0;


            }
            if (!iswin)
            {
                Console.WriteLine("10번 기회줬는데 못맞춰?");
            }
            
 

        }
    }
}
