using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Memory
{
    [Serializable()]
    public class Card: INotifyPropertyChanged, ISerializable
    {
        [XmlElement]
        public bool Visible { get; set; }

        private bool _reverse;

        [XmlElement]
        public bool Reverse  {get { return _reverse; }
    set
        {
            if (value != _reverse)
            {
                _reverse = value;
                NotifyPropertyChanged("Reverse");
}
        }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
     
        [XmlElement]
        public string Image
        {
            get; set;
          
            }
                     

        public Card(string image)
        {
            this.Image = image;
            this.Visible = true;
            this.Reverse = false;
        }

        public Card()
        {
            this.Visible = true;
            this.Reverse = false;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Image", Image);
            info.AddValue("Reverse", Reverse);
            info.AddValue("Visibility", Visible);
        }

        public Card(SerializationInfo info, StreamingContext context)
        {
            Image = info.GetValue("Image", typeof(string)) as string;
            Reverse =(bool) info.GetValue("Reverse", typeof(bool));
            Visible = (bool)info.GetValue("Visibility", typeof(bool));
          
        }
    }
}
