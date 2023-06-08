using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLib
{
    class Apple : MobilePhone
    {
        public int Memory { get; set; }
        public int BatteryVolume { get; set; }

        public Apple() : base()
        {
            Memory = 128;
            BatteryVolume = 10000;
        }

        public string Reboot()
        {
            return "Вы перезагрузили телефон";
        }
        public string SwipeScreen(bool direction)
        {
            if (direction)
            {
                return "Провести экран вправо";
            }
            else
            {
                return "Провести экран влево";
            }
        }

    }
}
