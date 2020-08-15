using HangMan.Library;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HangMan.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //form importent consts
        const int allowdNameSize = 10;
        const double difficultyBtnOffset = 100;
        const double difficultyBtnHeight = 40;

        Button _lastColoredBtn;
        //difficulty
        Difficulty selectedDifficulty;

        public MainWindow()
        {
            InitializeComponent();
            CreateDifficultiesBtns();
        }
        //Helping Functions
        bool NameValidation(string nameToValidate)
        {
            return nameToValidate != string.Empty && nameToValidate.Length <= allowdNameSize;
        }
        bool FailedToLoadFile(string errorMsg = "Erorr")
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Failed to load Words file, make sure it's formatted correctly.\nLoad default word bank?",
                errorMsg, MessageBoxButton.YesNo);
            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes:
                    return true;

                case MessageBoxResult.No:
                default:
                    return false;
                    
            }
        }
        void SwitchToGamePage(GameManager gm)
        {
            GameView gameView = new GameView(gm);
            gameView.Show();
            Close();
        }
        void CreateDifficultiesBtns()
        {
            //get the names of all difficulties
            string[] difficultiesNames = Enum.GetNames(typeof(Difficulty));
            Button btn;
            foreach (string difficulty in difficultiesNames)
            {
                //create a btn foreach difficulty
                btn = new Button()
                {
                    Content = difficulty,
                    Width = (Window.Width - difficultyBtnOffset) / difficultiesNames.Length,
                    Height = difficultyBtnHeight,
                    FontFamily = new FontFamily("Snap ITC"),
                    FontSize = 18,
                    Background =new SolidColorBrush(Color.FromArgb(0,0,0,0))
                };
                // add margin for all but the last one (most left)
                if (!difficulty.Equals(difficultiesNames[difficultiesNames.Length-1]))
                {
                    btn.Margin = new Thickness(0, 0, 20, 0);
                }
                //position in form
                difficultiesSP.Children.Add(btn);
                //add method to Click event
                btn.Click += DifficultyBtn_Click;
            }
        }

        //Events...
        private void StartGameBtn_Click(object sender, RoutedEventArgs e)
        {
            GameManager gm;
            //load words from txt file?
            bool loadFromFileBool = (bool)loadFromFile.IsChecked;
            //get the entered name
            string playerName = playerNameBox.Text;

            if (!NameValidation(playerName))
            {
                //name isn't valid
                MessageBox.Show($"'{playerName}' is not a valid name!\nA valid name is under {allowdNameSize} characters and isn't empty", "No Name", MessageBoxButton.OK);
                return;
            }

            try
            {
                //if user hasn't selected a difficulty (use default Easy)
                gm = new GameManager(playerName, loadFromFileBool, selectedDifficulty);
                SwitchToGamePage(gm);
            }

            //catch the InvalidDataException, there is a problem with the txt file format or lack of words
            catch (InvalidDataException exception)
            {
                if (FailedToLoadFile(exception.Message))
                {
                    gm = new GameManager(playerName, false, selectedDifficulty);
                    SwitchToGamePage(gm);
                }
            }
        }
        private void DifficultyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button difficultyBtn)
            {
                selectedDifficulty = (Difficulty)Enum.Parse(typeof(Difficulty), difficultyBtn.Content.ToString());
                
                //Color the btn and reset the previous btn
                difficultyBtn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                if (_lastColoredBtn != null)
                {
                    _lastColoredBtn.Background = default;
                }
                _lastColoredBtn = difficultyBtn;
            }
        }
        private void OpenTxtFile_Click(object sender, RoutedEventArgs e)
        {
            GameManager.EditTxtFile();
        }
        private void GenerateNewFile_Click(object sender, RoutedEventArgs e)
        {
            GameManager.RepleaceFile();
        }
    }
}
