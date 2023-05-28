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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int avatarIndex=1;
        private Player selectedPlayer;
        private Auxiliary.ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            
           selectedPlayer = new Player("not-a-player", "./Avatars/image" + avatarIndex.ToString() + ".jpg");           
           viewModel = new Auxiliary.ViewModel();
           DataContext = viewModel;

        }

        private Player validUsername(string username)
        {
            for (int i = 0; i < viewModel.Players.Count; i++)
                if (viewModel.Players[i].Username == username)
                    return viewModel.Players[i];
            return new Player("not-a-player", "./Avatars/image" + avatarIndex.ToString() + ".jpg");
        }

        private void serializer()
        {
            using (Stream fs = new FileStream(@"../../players.xml",
                   FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Player>));
                serializer.Serialize(fs, viewModel.Players);
            }
        }



        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            username.Visibility=Visibility.Visible;
            submit.Visibility=Visibility.Visible;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayer.Username != "not-a-player")
            {
                viewModel.Players.Remove(selectedPlayer);
                string path = "../../SavedGames/" + selectedPlayer.Username + ".xml";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                    serializer();
                selectedPlayer = new Player("not-a-player", "./Avatars/image" + avatarIndex.ToString() + ".jpg");
                
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayer.Username != "not-a-player")
            {
                Menu menu = new Menu(selectedPlayer);
                this.Close();
                menu.Show();
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
           
            if (avatarIndex < 6)
                avatarIndex++;
            else avatarIndex = 1;
           Avatar.Source = new BitmapImage(new Uri(@"./Avatars/image" + avatarIndex.ToString() + ".jpg", UriKind.Relative));
           if(selectedPlayer.Username !="not-a-player")
            {
                Player aux= viewModel.Players.FirstOrDefault(x => x.Username == selectedPlayer.Username);
                aux.Avatar = "./Avatars/image" + avatarIndex.ToString() + ".jpg";
                serializer();
            }
           
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            //imaginea precedenta - vezi next
            if (avatarIndex >1)
                avatarIndex--;
            else avatarIndex = 6;
            Avatar.Source = new BitmapImage(new Uri(@"./Avatars/image" + avatarIndex.ToString() + ".jpg", UriKind.Relative));
            if (selectedPlayer.Username != "not-a-player")
            {
                Player aux = viewModel.Players.FirstOrDefault(x => x.Username == selectedPlayer.Username);
                aux.Avatar = "./Avatars/image" + avatarIndex.ToString() + ".jpg";
                serializer();
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string playerName = username.Text;
            if (playerName == "")
            {
                MessageBox.Show("Your username cannot be empty!!!");
            }
            else
            { 
                if (validUsername(playerName).Username!="not-a-player")
                    MessageBox.Show("Username already taken!!!");
                else
                {
                    Player current = new Player(playerName, "./Avatars/image" + avatarIndex.ToString() + ".jpg");

                              
                    viewModel.Players.Add(current);                    
                    serializer();

                    selectedPlayer = current;
                    username.Visibility = Visibility.Collapsed;
                    username.Text = "";
                    submit.Visibility = Visibility.Collapsed;

                    players.SelectedItem = current;
                }
            }

            
            
        }

        private void players_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(players.SelectedItem != null && players.SelectedItem as Player!=null)
            {
                selectedPlayer = (Player)players.SelectedItem;
                Avatar.Source = new BitmapImage(new Uri(selectedPlayer.Avatar, UriKind.Relative));
                avatarIndex = Convert.ToInt32(selectedPlayer.Avatar[15])-48;
            }

        }
    }
}
