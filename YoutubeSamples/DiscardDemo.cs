using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSamples
{
    class DiscardDemo
    {
        (int, string, int) Sum2() => (100, "anish", 200);


        void sample()
        {
            (_,_,int age)= Sum2();
        }
    }
}
