using System;
using System.Collections.Generic;
using VendingMachine.Library;
using VendingMachine.Library.Enums;
using VendingMachine.Library.Moduels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VendingMachine.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagementGUI : Page
    {
        Manager _manager;
        Beverage _selectedBeverage;
        IngredientsEnum _selctedRecipeIngredient;
        IngredientsEnum _selctedStockIngredient;
        public ManagementGUI()
        {
            this.InitializeComponent();
            LoadRecipeComboBox();
        }

        #region Menu controls
        private void MenuGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            _selectedBeverage = e.ClickedItem as Beverage;
            UpdateRecipeViewSource();
            RecipeListViewBtnsSP.Visibility = Visibility.Visible;
        }
        private void DefaultMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            _selectedBeverage = e.ClickedItem as Beverage;
            UpdateRecipeViewSource();
        }

        //add beverage to menu
        private void AddToMenu_Click(object sender, RoutedEventArgs e) => UpdateLogMsg(_manager.AddBeverageToMenu(_selectedBeverage));
        //remove beverage from menu
        private void RemoveFromMenu_Click(object sender, RoutedEventArgs e) => UpdateLogMsg(_manager.RemoveFromMenu(_selectedBeverage));
        #endregion
        #region Stock controls
        private void InContainerListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedKeyValuePair = (KeyValuePair<IngredientsEnum, int>)e.ClickedItem;
            _selctedStockIngredient = selectedKeyValuePair.Key;
        }

        private void AddToIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EditIngredientAmountTextBox.Text, out int amount))
            {
                EditIngredientAmountTextBox.Text = string.Empty;
                return;
            }
            UpdateLogMsg(_manager.RestockIngredient(_selctedStockIngredient, amount));
            UpdateIngredientsViewSource();
        }

        private void RestockIngredient_Click(object sender, RoutedEventArgs e)
        {
            UpdateLogMsg(_manager.RestockIngredient(_selctedStockIngredient));
            UpdateIngredientsViewSource();
            RestockFlyout.Hide();
        }

        private void AddToAll_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(EditAllAmountTextBox.Text,out int amount))
            {
                EditAllAmountTextBox.Text = string.Empty;
                return;
            }
            UpdateLogMsg(_manager.RestockMachineToAmount(amount));
            UpdateIngredientsViewSource();
        }
        private void RestockAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateLogMsg(_manager.RestockMachine());
            UpdateIngredientsViewSource();
        }
        
        private void RestockOptions_Click(object sender, RoutedEventArgs e)
        {
            ToggleStackPanelVisibility(IngredientBtnsSP);
        }

        #endregion
        #region Recipe controls
        private void RecipeListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedKeyValuePair = (KeyValuePair<IngredientsEnum, int>)e.ClickedItem;
            _selctedRecipeIngredient = selectedKeyValuePair.Key;
        }
        private void AddIngredientToRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            //get the enum of the selected ingredient
            IngredientsEnum ingredientToAdd = (IngredientsEnum)Enum.Parse(typeof(IngredientsEnum),
                IngredientsComboBox.SelectedItem.ToString());

            //add ingredient to recipe
            UpdateLogMsg(_manager.AddIngredientToRecipe(_selectedBeverage, ingredientToAdd));
            UpdateRecipeViewSource();
        }
        private void RemoveIngredietnFromRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBlock.Text = _manager.RemoveIngredientFromRecipe(_selectedBeverage, _selctedRecipeIngredient);
            UpdateRecipeViewSource();
        }
        private void AddAmountToRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(AddAmountToRecipe.Text, out int amount) || amount < 0)
            {
                AddAmountToRecipe.Text = string.Empty;
                return;
            }
            UpdateLogMsg(_manager.UpdateIngredientAmountInRecipe(_selectedBeverage, _selctedRecipeIngredient, amount));
            UpdateRecipeViewSource();
        }
        private void RemoveAmountFromRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RemoveAmountFromRecipe.Text, out int amount) || amount < 0)
            {
                RemoveAmountFromRecipe.Text = string.Empty;
                return;
            }
            UpdateLogMsg(_manager.UpdateIngredientAmountInRecipe(_selectedBeverage, _selctedRecipeIngredient, -amount));
            UpdateRecipeViewSource();
        }
        void UpdateRecipeViewSource()
        {
            if (_selectedBeverage != null)
            {
                RecipeListView.ItemsSource = default;
                RecipeListView.ItemsSource = _selectedBeverage.Recipe;
            }

        }


        #endregion
        #region Create Beverage
        private void CreateBeverageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(CreatePriceBox.Text, out decimal price))
            {
                UpdateLogMsg(_manager.CreateBeverage(CreateNameBox.Text, price));
            }
            else
            {
                CreatePriceBox.Text = string.Empty;
            }
        }
        #endregion
        #region Navigation
        //on navigate override (Manager transfer)
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            _manager = e.Parameter as Manager;
        }
        //return to main page
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), _manager);
        }
        #endregion

        //update the log
        void UpdateLogMsg(string msg) => OutputTextBlock.Text = msg;
        //toggle stack panels
        void ToggleStackPanelVisibility(StackPanel stackPanel) =>
            stackPanel.Visibility = stackPanel.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        //load combobox's items
        void LoadRecipeComboBox()
        {
            foreach (string ingredient in Enum.GetNames(typeof(IngredientsEnum)))
            {
                IngredientsComboBox.Items.Add(ingredient);
            }
            IngredientsComboBox.SelectedIndex = 0;
        }
        //refresh stock bindings
        void UpdateIngredientsViewSource()
        {
            InContainerListView.ItemsSource = default;
            InContainerListView.ItemsSource = _manager.VendingMachine.Stock;
        }
    }
}