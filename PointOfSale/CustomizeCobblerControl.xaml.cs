using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamTwoCodeQuestions.Data;

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
            BlueberryButton.Click += BlueberryButton_Click;
            CherryButton.Click += CherryButton_Click;
            PeachButton.Click += PeachButton_Click;
        }

        private void BlueberryButton_Click(object sender, RoutedEventArgs e)
        {
            ((Cobbler)DataContext).Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Blueberry;
        }
        private void PeachButton_Click(object sender, RoutedEventArgs e)
        {
            ((Cobbler)DataContext).Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Peach;
        }
        private void CherryButton_Click(object sender, RoutedEventArgs e)
        {
            ((Cobbler)DataContext).Fruit = ExamTwoCodeQuestions.Data.FruitFilling.Cherry;
        }
    }
}
