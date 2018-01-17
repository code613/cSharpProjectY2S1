﻿using System;
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
using BE;
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for personDeitailsWindow.xaml
    /// </summary>
    public partial class personDeitailsWindow : Window
    {
        public Person temp;//maid public so can copy to main window
        public personDeitailsWindow()
        {
            InitializeComponent();
//temp = new Person(IDtextBox.Text, FNtextBox.Text, LNtextBox.Text, BirthdaytextBox.SelectedDate.Value.Date);

        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            temp = new Person(IDtextBox.Text, FNtextBox.Text, LNtextBox.Text, BirthdaytextBox.SelectedDate.Value.Date);
            this.Close();
            //need to only alow to click butten if all information is inside securly(with progress bar)
        }
    }
}
