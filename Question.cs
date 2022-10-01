using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWS_Cloud_Practitioner_Exam
{
   public class Question
    {
       public string _Question { get; set; }
       public string Response { get; set; }
       public List<string> Responses { get; set; }
       
       //constructor
       public Question()
       {
           Responses = new List<string>();
       }
    }
}
