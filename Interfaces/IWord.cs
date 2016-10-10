using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazmierczak.Languer.Interfaces
{
    public interface IWord
    {
        [Key]
        int WordID { get; set; }
        string OriginName { get; set; }
        string SecondName { get; set; }
        int Correct { get; set; }
        int Incorrect { get; set; }
    }
}
