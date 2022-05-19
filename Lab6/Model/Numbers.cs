using Lab6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6.Model
{
    class Numbers : MyViewModel
    {
        
        public void returnResult(String str,ref List <int> X)
        {
            int len = int.Parse(str);
            for(int i = 0; i <= len; ++i)
            {
                 X.Add(i);
            }
           
        }

    }
}
