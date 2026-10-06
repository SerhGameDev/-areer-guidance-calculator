using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace MyCalculator
{
    public partial class MainWindow : Window
    {
        double firstNumber;
        string operation;

        public MainWindow()
        {
            InitializeComponent();
        }


        // Нажатие на цифру
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            string number = button.Content.ToString();

            if (Display.Text == "0")
            {
                Display.Text = number;
            }
            else
            {
                Display.Text += number;
            }
        }


        // Нажатие на математическую операцию
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = double.Parse(
                Display.Text,
                CultureInfo.InvariantCulture);

            Button button = (Button)sender;

            operation = button.Content.ToString();

            Display.Text = "0";
        }


        // Нажатие =
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = double.Parse(
                Display.Text,
                CultureInfo.InvariantCulture);

            double result = 0;


            if (operation == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == "−")
            {
                result = firstNumber - secondNumber;
            }
            else if (operation == "×")
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == "÷")
            {
                if (secondNumber == 0)
                {
                    MessageBox.Show("На ноль делить нельзя!");
                    return;
                }

                result = firstNumber / secondNumber;
            }


            Display.Text = result.ToString(
                CultureInfo.InvariantCulture);
        }


        // Очистить калькулятор
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";

            firstNumber = 0;
            operation = "";
        }


        // Десятичная точка
        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }
        }


        // Показать сообщение
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Здесь школьник сам придумывает своё сообщение!"
            );
        }
    }
}