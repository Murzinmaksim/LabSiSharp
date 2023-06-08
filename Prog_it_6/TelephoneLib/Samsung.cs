using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneLib
{
    public class Samsung : MobilePhone
    {
        public int Memory { get; set; }
        public int BatteryVolume { get; set; }

        public Samsung() : base()
        {
            Memory = 32;
            BatteryVolume = 4200;
        }

        public string TakePhoto()
        {
            return "Сделано фото";
        }

        public string DeletePhoto()
        {
            return "Фото удалено";
        }

    }
}
