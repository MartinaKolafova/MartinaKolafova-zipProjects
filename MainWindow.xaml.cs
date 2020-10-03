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

namespace MorseCodeWPF
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            MorseCodeConverterClass morseCodeConverterClass = new MorseCodeConverterClass(Dot.Text.ToCharArray(0,1).First(), Dash.Text.ToCharArray(0, 1).First(), LetterSeparatorChar.Text.ToCharArray(0, 1).First(), WordSeparatorString.Text);          
                      
            ConvertedText.Text = morseCodeConverterClass.MorseToText(TextToConvert.Text);             
            Dash.Text = morseCodeConverterClass.Dash.ToString(); //Dash can be only 1 char - extra chars in TextBox will be deleted
            Dot.Text = morseCodeConverterClass.Dot.ToString(); //Dot can be only 1 char - extra chars in TextBox will be deleted
            LetterSeparatorChar.Text = morseCodeConverterClass.LetterSeparator.ToString();
        }

        private void OnClick2(object sender, RoutedEventArgs e)
        {
            MorseCodeConverterClass morseCodeConverterClass = new MorseCodeConverterClass(DotCreator(Dot.Text), DashCreator(Dash.Text), LetterSeparatorCreator(LetterSeparatorChar.Text), WordSeparatorString.Text);
            ConvertedText.Text = morseCodeConverterClass.TextToMorse(TextToConvert.Text);
            Dash.Text = morseCodeConverterClass.Dash.ToString(); //Dash can be only 1 char - extra chars in TextBox will be deleted
            Dot.Text = morseCodeConverterClass.Dot.ToString(); //Dot can be only 1 char - extra chars in TextBox will be deleted
            LetterSeparatorChar.Text = morseCodeConverterClass.LetterSeparator.ToString();
        }

        private void LetterSeparatorChar_TextChanged(object sender, TextChangedEventArgs e)
        {          
            
            if (LetterSeparatorChar.Text == Dash.Text)
            {
                if (Dash.Text != "/")
                {
                    LetterSeparatorChar.Text = "/";
                }
                else 
                {
                    LetterSeparatorChar.Text = " ";
                }

            }
        }

        private char DotCreator(string dot)
        {
            char chardot;

            if (String.IsNullOrEmpty(dot))
            {
                chardot = '.';
            }
            else
            {
                chardot = dot.First();
            }

            return chardot;
        }

        private char DashCreator(string dash)
        {
            char chardash;

            if (String.IsNullOrEmpty(dash))
            {
                chardash = '-';
            }
            else
            {
                chardash = dash.First();
            }

            return chardash;
        }

        private char LetterSeparatorCreator(string letterSeparator)
        {           
            if(String.IsNullOrEmpty(letterSeparator))
            {
                return '/';
            }

            else
            {
                return letterSeparator.First();
            }
        }
                
    }
}
