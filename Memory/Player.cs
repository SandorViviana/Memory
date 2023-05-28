using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace Memory
{
    [Serializable()]
    public class Player:ISerializable
    {
        [XmlElement]
        public string Username { get; set; }

        [XmlElement]
        public string Avatar { get; set; }

        [XmlElement]
        public int Gamesplayed { get; set; }

        [XmlElement]
        public int Gameswon { get; set; }
        

        public Player(string username, string avatar)
        {
            this.Username = username;
            this.Avatar = avatar;
            this.Gamesplayed = 0;
            this.Gameswon = 0;
           
        }

        public Player()
        {
            this.Gamesplayed = 0;
            this.Gameswon = 0;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Username",Username);
            info.AddValue("Avatar", Avatar);
            info.AddValue("GamesPlayed", Gamesplayed);
            info.AddValue("GamesWon", Gameswon);
        }

        public Player(SerializationInfo info, StreamingContext context)
        {
            Username=info.GetValue("Username", typeof(string)) as string;
            Avatar = info.GetValue("Avatar", typeof(string)) as string;
            Gamesplayed = (int)info.GetValue("GamesPlayed", typeof(int));
            Gameswon = (int)info.GetValue("GamesWon", typeof(int));
        }
    }
}
