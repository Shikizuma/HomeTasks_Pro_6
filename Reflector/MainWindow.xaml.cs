using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Reflector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selectedFilePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Оберіть файл";
            openFileDialog.Filter = "Всі файли (*.*)|*.*|Текстові файли (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {               
                selectedFilePath = openFileDialog.FileName;
            }

            ShowAssemblyInfo();
        }

        private void ShowAssemblyInfo()
        {
            Assembly assembly = Assembly.LoadFrom(selectedFilePath);

            InfoTextBox.Text += "Ім'я складання:" + assembly.FullName + Environment.NewLine + Environment.NewLine;
            InfoTextBox.Text += $"Версія складання: {assembly.GetName().Version}" + Environment.NewLine;
            InfoTextBox.Text += $"Культура складання: {assembly.GetName().CultureInfo.DisplayName}" + Environment.NewLine;

            Type[] types = assembly.GetTypes();
            InfoTextBox.Text += $"Кількість типів у складанні: {types.Length}" + Environment.NewLine;
            InfoTextBox.Text += "Список типів:" + Environment.NewLine;

            foreach (Type item in types)
            {
                InfoTextBox.Text += $"- {item.FullName}" + Environment.NewLine;

                MethodInfo[] methods = item.GetMethods();
                InfoTextBox.Text += $"  Кількість методів у типі {item.FullName}: {methods.Length}" + Environment.NewLine;
                InfoTextBox.Text += "  Список методів:" + Environment.NewLine;
                foreach (MethodInfo method in methods)
                {
                    InfoTextBox.Text += $"    - {method.Name}" + Environment.NewLine;
                }
            }
        }


    }
}
