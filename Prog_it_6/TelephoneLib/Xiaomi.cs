using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLib
{
    class Xiaomi : MobilePhone
    {
        public int Memory { get; set; }
        public int BatteryVolume { get; set; }

        public Xiaomi() : base()
        {
            Memory = 64;
            BatteryVolume = 8000;
        }

        public string LearnChinese()
        { 
            return "Вы выучили китайский";
        }

        public string VklFlash(bool vkl)
        {
            if (vkl)
            {
                return "Вспышка включена";
            }
            else
            {
                return "Вспышка выключена";
            }
        }


    }
}
