    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    namespace VatCalculator
    {
 
        [DesignTimeVisible(false)]
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                amountInput.TextChanged += InputTextChanged;

            }

            private void InputTextChanged(object sender, TextChangedEventArgs e)
            {
                totalAmountLabel.Text = $"{e.NewTextValue} SEK";
                vatPercentageLabel.Text = "0%";
                vatAmountLabel.Text = $"0.00 SEK";
                amountWithoutVatLabel.Text = "0.00 SEK";
            
            }

            private void OnEightPercent(object sender, EventArgs e)
            {
                CalculateAndSetAmountsByVatPercent(8);
            }

            void OnTwelvePercent(object sender, EventArgs e)
            {
                CalculateAndSetAmountsByVatPercent(12); 
            }

            void OnTwentyFivePercent(object sender, EventArgs e)
            {

                CalculateAndSetAmountsByVatPercent(25);
            }


            private void CalculateAndSetAmountsByVatPercent(double VatPercent)
            {
                vatPercentageLabel.Text = $"{VatPercent}%";

                double vat = VatPercent / 100; 

                try
                {
                    var InputTotal = Convert.ToDouble(this.amountInput.Text);
                    var TotalWithoutVat = Math.Round(InputTotal / (1 + vat), 2);
                    var TotalVatAmount = Math.Round(TotalWithoutVat * vat, 2);
                    amountWithoutVatLabel.Text = $"{TotalWithoutVat} SEK";
                    vatAmountLabel.Text = $"{TotalVatAmount} SEK";
                }
                catch (Exception)
                {
                    Console.WriteLine("Unvalid number....");
                }
            }
        }
    }
