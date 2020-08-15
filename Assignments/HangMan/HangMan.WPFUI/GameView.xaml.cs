using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HangMan.Library;

namespace HangMan.WPFUI
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        #region HangMan Image Consts
        const string hangManStage0  = @"pack://application:,,,/Assets/HangManStages/0.jpg";
        const string hangManStage1  = @"pack://application:,,,/Assets/HangManStages/1.jpg";
        const string hangManStage2  = @"pack://application:,,,/Assets/HangManStages/2.jpg";
        const string hangManStage3  = @"pack://application:,,,/Assets/HangManStages/3.jpg";
        const string hangManStage4  = @"pack://application:,,,/Assets/HangManStages/4.jpg";
        const string hangManStage5  = @"pack://application:,,,/Assets/HangManStages/5.jpg";
        const string hangManStage6  = @"pack://application:,,,/Assets/HangManStages/6.jpg";
        const string hangManStage7  = @"pack://application:,,,/Assets/HangManStages/7.jpg";
        const string hangManStage8  = @"pack://application:,,,/Assets/HangManStages/8.jpg";
        const string hangManStage9  = @"pack://application:,,,/Assets/HangManStages/9.jpg";
        const string hangManStage10 = @"pack://application:,,,/Assets/HangManStages/10.jpg";
        #endregion
        //a list for all of the buttons that has been disabled
        List<Button> _disabledBtns;

        //the game manager instance
        GameManager _gameManagerInstance;

        public GameView(GameManager gameManager)
        {
            InitializeComponent();
           //assign the game manager instance recived from the main page
            _gameManagerInstance = gameManager;
            //subscribe to the event
            _gameManagerInstance.GameOverEvent += GameOver_Event;
            //initialize list
            _disabledBtns = new List<Button>();
            //wire the game to it's containers
            WireGame();
        }

        //Helping Methods
        void WireGame()
        {
            playerNameBox.Text = _gameManagerInstance.PlayerName;
            WireDifficulties();
            RefreshComponents();
        }
        void WireDifficulties()
        {
            string[] difs = Enum.GetNames(typeof(Difficulty));
            foreach (string dif in difs)
            {
                Button btn = new Button()
                {
                    Content = dif
                };
                btn.Click += ChangeDifficulty_Event;
                difficultySP.Children.Add(btn);
            }
        }
        void RefreshComponents()
        {
            scoreOutput.Text = _gameManagerInstance.GameScore.ToString();
            UpdateHangManPic(_gameManagerInstance.HangedManStatus);
            lettersGuessed.Text = _gameManagerInstance.LettersGuessedAsString;
            wordDisplay.Text = _gameManagerInstance.ToString();
            difficultyOutpot.Text = _gameManagerInstance.GameDifficulty.ToString();

        }
        void UpdateHangManPic(int hangManLvl)
        {
            switch (hangManLvl)
            {
                case 0:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage0));
                    break;
                case 1:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage1));
                    break;
                case 2:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage2));
                    break;
                case 3:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage3));
                    break;
                case 4:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage4));
                    break;
                case 5:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage5));
                    break;
                case 6:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage6));
                    break;
                case 7:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage7));
                    break;
                case 8:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage8));
                    break;
                case 9:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage9));
                    break;
                case 10:
                    hangMan.Source = new BitmapImage(new Uri(hangManStage10));
                    break;
                default:
                    break;
            }
        }
        void SwitchToMainMenu()
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
        void CorrectGuess()
        {
            Random rng = new Random();
            keyBoardSP.Background = new SolidColorBrush(Color.FromRgb((byte)rng.Next(256), (byte)rng.Next(256), (byte)rng.Next(256)));
        }


        /*Events*/
        //what to do when the game is over
        void GameOver_Event(object sender, bool e)
        {
            RefreshComponents();
            MessageBoxResult result;
            //if the game is won
            if (e)
            {
                result = MessageBox.Show($"Congratulations! {_gameManagerInstance.PlayerName} You have succeeded!!\nPlay Another Word?", "Winner", MessageBoxButton.YesNo);
            }
            //if the game is lost
            else
            {
                result = MessageBox.Show($"ohhh! You have Failed!!\nThe Word was: {_gameManagerInstance}\nPlayAgain?", "Looser", MessageBoxButton.YesNo);
            }
            switch (result)
            {
                //play another
                case MessageBoxResult.Yes:
                    _gameManagerInstance.NextWord();
                    //enable all of the buttons
                    foreach (Button button in _disabledBtns)
                    {
                        button.Visibility = Visibility.Visible;
                    }
                    break;
                //leave
                case MessageBoxResult.No:
                    SwitchToMainMenu();
                    break;
            }
        }
        //what to do when the player clicks on a letter
        void LetterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                _disabledBtns.Add(btn);
                btn.Visibility = Visibility.Collapsed;
                if (_gameManagerInstance.Guess(Convert.ToChar(btn.Content)))
                {
                    CorrectGuess();
                }
                RefreshComponents();
            }
        }
        //expand the options
        void ChangeDifficultyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (difficultySP.Visibility == Visibility.Collapsed)
            {
                difficultySP.Visibility = Visibility.Visible;
            }
            else
            {
                difficultySP.Visibility = Visibility.Collapsed;
            }
        }
        //Create a new game
        void NewGame_Click(object sender, RoutedEventArgs e)
        {
            _gameManagerInstance.NewGame();
            RefreshComponents();
        }
        //return to main menu
        void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            SwitchToMainMenu();
        }
        //changing to spesific difficulty
        void ChangeDifficulty_Event(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                _gameManagerInstance.ChangeDifficulty((Difficulty)Enum.Parse(typeof(Difficulty), btn.Content.ToString()),false);
                RefreshComponents();
            }
        }

    }
}