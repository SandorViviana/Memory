using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Memory.Auxiliary
{
    internal class ViewModel
    {
      public  ObservableCollection<Player> Players { get; set; }

        public ViewModel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Player>));
            using (FileStream fs = File.OpenRead("../../players.xml"))
            {
                Players = (ObservableCollection<Player>)serializer.Deserialize(fs);
            }
        }
    }
}
