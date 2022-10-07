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

// Week 8 Assignment
// Yakimah Wiley
// October 6th, 2022

// This program will calculate the total cost of a hospital stay.
// The first line requests the number of days that the patient was at the facility,
// that number is then multiplied by 350. Afterwards, the total cost of the stay 
// is added to all of the other costs from the visit. Clicking the 'Calculate' button
// will calculate the total cost of the visit.

// While the number of days in the hospital takes an integer, the rest
// take decimals. 
namespace Hospital_Charge_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fullscreenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the 'Fullscreen' Button");
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the 'Minimize' Button");
        }






        private decimal CalcStayCharges(int numOfDays, decimal costPerDay = 350m)
        {
           return costPerDay * numOfDays;
        }

        private decimal CalcMiscCharges(decimal medCharges, decimal surgCharges, decimal labFees, decimal rehabCharges)
        {
           return medCharges + surgCharges + labFees + rehabCharges;
        }

        private void CalcTotalCharges(decimal totalCostOfDays, decimal totalMiscellaneousCost)
        {
            decimal totalCost;
            totalCost = totalCostOfDays + totalMiscellaneousCost;
            calculatedLabelTextBlock.Text = totalCost.ToString("C");
        }







        private void calculateChargesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                const int LOWEST_NUMBER = 0;
                int days = int.Parse(daysInHospitalTextbox.Text);
                decimal medication = decimal.Parse(medicationChargesTextBox.Text);
                decimal surgery = decimal.Parse(surgicalChargesTextbox.Text);
                decimal labs = decimal.Parse(labFeesTextbox.Text);
                decimal rehab = decimal.Parse(rehabCharesTextbox.Text);

                
                if(days > LOWEST_NUMBER)
                {
                    CalcTotalCharges(totalCostOfDays: CalcStayCharges(days), CalcMiscCharges(medCharges: medication, surgCharges: surgery, labFees: labs, rehabCharges: rehab));
                }

                else
                {
                    MessageBox.Show("The number of days in the hospital must be greater than zero.");
                }
            }

            catch
            {
                MessageBox.Show("Please type a number into each textbox. The 'Number of days in hospital' should be a whole number.");
            }
        }
    }
}
