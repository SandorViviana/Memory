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
    public class Board:ISerializable
    {
        public Player Player { get; set; }
        public int Level { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<List<Card>> Deck { get; set; }

        public static void Shuffle<T>(IList<T> list)
        {
            var random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        List<Card> cards(int number)
        {
            List<Card> newDeck = new List<Card>();
            int index = 1;
            while(newDeck.Count()<number)
            {
                Card aux=new Card("./Images/" + index.ToString() + ".jpg"); //calea catre imagine
                newDeck.Add(aux);
                if(newDeck.Count() < number)
                {
                    Card pair=new Card("./Images/"+index.ToString()+".jpg");
                    newDeck.Add(pair);
                }
                index++;
            }
            return newDeck; 
        }

        List<List<Card>>makeDeck(int height, int width)
        {
            Deck = new List<List<Card>>();
            List<Card>newDeck=new List<Card>();
            newDeck =cards(height*width);
            Shuffle(newDeck);
            int index = 0;
            for (int i = 0; i < height; i++)
            {
                List<Card> aux = new List<Card>();
                for (int j = 0; j < width; j++)
                {
                    aux.Add(newDeck[index]);                 
                    index++;

                }
                Deck.Add(aux);
            }
            return Deck;
        }
        public Board(Player player, int height=5, int width=5, int level = 1)
        {
            this.Player = player;
            this.Level = level;
            this.Height = height;
            this.Width = width;
            Deck= new List<List<Card>>();
            Deck=makeDeck(height, width);
        }

        public Board()
        {
            //pentru data context
        }
      

        public bool finished()
        {
            int ok = 1;
            for(int i=0;i<Height;i++)
                for(int j=0;j<Width;j++)
                {
                    if (Deck[i][j].Visible && (Height * Width % 2 == 0 || ok == 0))
                        return false;
                    else 
                        if(Deck[i][j].Visible)
                            ok = 0;
                }
            return true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //((ISerializable)Player).GetObjectData(info, context);
            info.AddValue("Player", Player);
            info.AddValue("Level",Level);
            info.AddValue("Height",Height);
            info.AddValue("Width", Width);
            info.AddValue("Deck", Deck);

        }


        public Board(SerializationInfo info, StreamingContext context)
        {
            Player = info.GetValue("Player", typeof(Player)) as Player;
            Level = (int)info.GetValue("Level", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            Width = (int)info.GetValue("Width", typeof(int));
            Deck=info.GetValue("Deck", typeof(List<List<Card>>)) as List<List<Card>>;

        }
    }
}
