using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VendingMachine.Library;
using VendingMachine.Library.Moduels;
using VendingMachine.Library.Enums;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VendingMachine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Manager _manager;
        Beverage _selected;
        int _sugar;
        public MainPage()
        {
            this.InitializeComponent();
            _sugar = 0;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Manager m)
            {
                _manager = m;
            }
            else
            {
                _manager = new Manager();
            }
            RefreshMoneyComponent();
            RefreshSugarComponent();
        }
        #region Sugar controls
        private void RemoveSugar_Click(object sender, RoutedEventArgs e)
        {
            _sugar = Math.Max(0, _sugar - 1);
            RefreshSugarComponent();
        }
        private void AddSugar_Click(object sender, RoutedEventArgs e)
        {
            _sugar++;
            RefreshSugarComponent();
        }
        void RefreshSugarComponent() => SugarAmountTxt.Text = _sugar.ToString();
        #endregion
        #region Money controls
        //Coins
        private void Coin_Click(object sender, RoutedEventArgs e)
        {
            //add the coin
            OutputView.Items.Add(_manager.AddMoney((Coins)Enum.Parse(typeof(Coins), (sender as Button).Name)));
            RefreshMoneyComponent();
        }
        //return money
        private void AbortCoinBtn_Click(object sender, RoutedEventArgs e)
        {
            OutputView.Items.Add(_manager.ReturnMoney());
            RefreshMoneyComponent();
        }
        void RefreshMoneyComponent() => MoneyTxtBlock.Text = _manager.GetMoney();
        #endregion
        //select a drink from grid view
        private void GridView_ItemClick(object sender, ItemClickEventArgs e) => _selected = e.ClickedItem as Beverage;
        //make the beverage
        private void PrepareBeverageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                return;
            }
            OutputView.Items.Add(_manager.Prepare(_selected, _sugar));
            RefreshMoneyComponent();
        }
        //clear the log
        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            OutputView.Items.Clear();
        }
        //Navigate to ManagementPage
        private void MoveToManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManagementGUI), _manager);
        }
    }
}