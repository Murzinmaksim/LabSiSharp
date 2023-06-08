using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLib
{
    public interface ITelephone
    {
        string Model { get; set; }
        string Status(bool vkl);
        string Call(int number);
    }

}
