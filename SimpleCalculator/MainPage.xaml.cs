using System;
using Microsoft.Maui.Controls;

namespace SimpleCalculator
{
    public partial class MainPage : ContentPage
    {
        private double currentNumber = 0;
        private double lastNumber = 0;
        private string currentOperator = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (resultDisplay.Text == "0" || currentOperator == "=")
                resultDisplay.Text = "";

            resultDisplay.Text += button.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (double.TryParse(resultDisplay.Text, out lastNumber))
            {
                currentOperator = button.Text;
                resultDisplay.Text = "";
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(resultDisplay.Text, out currentNumber))
            {
                double result = 0;

                if (currentOperator == "+")
                    result = lastNumber + currentNumber;
                else if (currentOperator == "-")
                    result = lastNumber - currentNumber;
                else if (currentOperator == "×")
                    result = lastNumber * currentNumber;
                else if (currentOperator == "÷")
                {
                    if (currentNumber != 0)
                        result = lastNumber / currentNumber;
                    else
                        resultDisplay.Text = "Error";
                }

                if (currentOperator != "÷" || currentNumber != 0)
                    resultDisplay.Text = result.ToString();

                currentOperator = "=";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            resultDisplay.Text = "0";
            lastNumber = 0;
            currentNumber = 0;
            currentOperator = "";
        }
    }
}
