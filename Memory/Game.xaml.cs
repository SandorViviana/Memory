using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace Memory
{
    
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        internal Board Board { get; set; }
        public int ClickCount { get; set; }
        List<Card> selectedCards;
        internal Game(Board b)
        {
            
            Board = b;          
            InitializeComponent();
            DataContext = Board;
            selectedCards = new List<Card>();
            ClickCount = determineClickCount();            
            currentLevel.Text = "Level: "+Board.Level.ToString(); //a se modifica la fiecare nivel terminat
        }

        private int determineClickCount()
        {
           
            int count = 0;
            List<Card> reversedCards=new List<Card>();
            for(int i=0;i<Board.Deck.Count;i++)
                for(int j=0;j<Board.Deck[i].Count;j++)
                {
                    if(Board.Deck[i][j].Reverse)
                    {
                        count++;
                        reversedCards.Add(Board.Deck[i][j]);
                    }
                }
            if (count % 2 == 0)
                return count % 2;
            else
            {
                
                    foreach (Card card in reversedCards)
                    {
                       List<Card> pair=reversedCards.FindAll(x => x.Image==card.Image);
                        if (pair.Count == 1)
                        {
                            selectedCards.Add(card);
                            return count % 2;
                        
                        }
                    }
                
                return count % 2;
            }
        }

        private void serializer(List<Player> users)
        {
            using (Stream fs = new FileStream(@"../../players.xml",
                   FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
                serializer.Serialize(fs, users);
            }
        }


        private void saveBoard()
        {
            using (Stream fs = new FileStream(@"../../SavedGames/" + Board.Player.Username+".xml",
                   FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Board));
                serializer.Serialize(fs, Board);
            }
        }

        private List<Player> deserialize()
        {
            List<Player> users = new List<Player>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Player>));
            using (FileStream fs = File.OpenRead("../../players.xml"))
            {
                if (fs.Length > 0)
                    users = (List<Player>)serializer.Deserialize(fs);
            }
            return users;
        }

        private void finishControl()
        {
            if (Board.finished())
            {
                MessageBox.Show("Congratulations!");
                if (Board.Level == 3)
                {
                    MessageBox.Show("Congratulations! You completed all stages.");
                    Board.Player.Gameswon += 1; //plus actualizare in fisier
                    List<Player> users = deserialize();
                    Player aux = users.Find(x => x.Username == Board.Player.Username);
                    aux.Gameswon += 1;
                    serializer(users);

                    MainWindow start=new MainWindow();
                    start.Show();
                    this.Close();                   
                    
                }
                else
                {
                    Board aux = new Board(Board.Player, Board.Height, Board.Width, Board.Level + 1);
                    Game nextLevel = new Game(aux);
                    nextLevel.Show();
                    this.Close();
                }
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button =sender as Button;
            Card card = (Card)button.DataContext;
            if (card.Reverse == false)
            {
                card.Reverse = !card.Reverse;
                ClickCount++;
                selectedCards.Add(card);
                if (Board.Height * Board.Width % 2 != 0)
                    finishControl();

               
                    if (ClickCount == 2)
                    {
                        if (selectedCards[0].Image == selectedCards[1].Image)
                        {
                            selectedCards[0].Visible = false;
                            selectedCards[1].Visible = false;
                            finishControl();

                        }
                        else
                        {

                        await Task.Delay(500);
                        selectedCards[0].Reverse = false;
                        selectedCards[1].Reverse = false;
                        
                    }
                        ClickCount = 0;
                        selectedCards.Clear();
                    }
                
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveBoard();
            MainWindow start = new MainWindow();
            start.Show();
            this.Close();

        }
    }
}
