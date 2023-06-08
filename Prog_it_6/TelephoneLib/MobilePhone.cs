using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLib
{
    public abstract class MobilePhone : ITelephone
    {
        public string Model { get; set; }
        public string ScreenMatrix { get; set; }
        public int YourPhoneNumber { get; set; }

        public MobilePhone()
        {
           
        }

        public string Status(bool vkl)
        {
            if (vkl)
            {
                return "Телефон включен";
            }
            else
            {
                return "Телефон выключен";
            }
        }

        public string Call(int number)
        {
          return "Вы позвонили на номер: " + (number).ToString();  
        }


    }
}
