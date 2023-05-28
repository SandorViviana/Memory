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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        internal Player player { get; set; }
        internal Menu(Player player)
        {
            this.player = player;
            InitializeComponent();
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
        private void new_Click(object sender, RoutedEventArgs e)
        {          
            Options.Visibility = Visibility.Visible;
            standard.Visibility = Visibility.Visible;
            custom.Visibility = Visibility.Visible;
        }
        private void open_Click(object sender, RoutedEventArgs e)
        {
            //se cauta jocurile salvate ale utilizatorului
            string path = "../../SavedGames/" + player.Username + ".xml";
            if (File.Exists(path))
            {
                Board board = new Board();
                XmlSerializer serializer = new XmlSerializer(typeof(Board));
                using (FileStream fs = File.OpenRead(path))
                {
                    if (fs.Length > 0)
                        board = (Board)serializer.Deserialize(fs);
                }
                if (board!=null)

                {
                    Board aux = null;
                    using (Stream fs = new FileStream(path,
                     FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        XmlSerializer serializer2 = new XmlSerializer(typeof(Board));
                        serializer2.Serialize(fs, aux);
                    }

                    Game newgame = new Game(board);
                    newgame.Show();
                    this.Close();
                }
                else MessageBox.Show("You have no saved games!!!");

            }
            else MessageBox.Show("You have no saved games!!!");
        }
        private void stats_Click(object sender, RoutedEventArgs e)
        {
            
            Statisctics stats = new Statisctics(player);
            stats.Show();
        }

        private void custom_Click(object sender, RoutedEventArgs e)
        {
            CustomHeight.Visibility = Visibility.Visible;
            CustomWidth.Visibility = Visibility.Visible;
            textHeight.Visibility = Visibility.Visible;
            textWidth.Visibility = Visibility.Visible;           
            Play.Visibility = Visibility.Visible;
            custom.IsEnabled = false;
            
        }

        private void standard_Click(object sender, RoutedEventArgs e)
        {
            
            Board board=new Board(player);
            Game newgame = new Game(board);
            newgame.Show();
            this.Close();           
            List<Player> users = deserialize();
            Player aux=users.Find(x => x.Username == player.Username);
            aux.Gamesplayed += 1;
            serializer(users);
            player.Gamesplayed += 1;

        }
        private void play_click(object sender, RoutedEventArgs e)
        {

            Board board = new Board(player,(int)CustomHeight.Value,(int)CustomWidth.Value);
            Game newgame = new Game(board);
            newgame.Show();
            this.Close();            
            List<Player> users = deserialize();
            Player aux = users.Find(x => x.Username == player.Username);
            aux.Gamesplayed += 1;
            serializer(users);
            player.Gamesplayed += 1;

        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About info=new About();
            info.Show();
        }
    }
}
