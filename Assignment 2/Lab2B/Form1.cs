using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2B
{
    public partial class Form1 : Form
    {
        //ATTRIBUTES

        //CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
        }

        //METHODS
        private void calcBtn_Click(object sender, EventArgs e)
        {

            //all button validation
            bool allChecked = false;
            if (hairDresserCheck() && servicesCheck() && clientCheck())
            {
                 allChecked = true;
            }

            //integer validation
            string visitAsk = visitTextBox.Text;
            int visitValidation = 0;


            if (!allChecked)
            {
                testBox.Text = "Must check one hairdresser, service, and client type.";
            } 
            else
            {
                if (int.TryParse(visitAsk, out visitValidation))
                {
                    if (visitValidation > 0)
                    {
                        testBox.Text = "";

                        int dresser = 0;
                        string service = "OOOO";
                        int client = 0;
                        int visit = visitValidation;

                        TotalCalc calc = new TotalCalc(dresser, service, client, visit);

                        dresserOutput.Text = $"${calc.baseRate}";
                        serviceOutput.Text = $"${calc.serviceRate}";
                        clientOutput.Text = $"${calc.clientDiscount}";
                        visitOutput.Text = $"${calc.visitDiscount}";
                        priceOutput.Text = $"${calc.totalPrice}";
                        
                    }
                    else
                    {
                        testBox.Text = "Must be an integer (positive)";
                    }
                }
                else
                {
                    testBox.Text = "Must be an integer (non-decimal numbers)";
                }
            }
        }

        private bool hairDresserCheck()
        {
            if (!janeRadioBtn.Checked &&
                !patRadioBtn.Checked &&
                !ronRadioBtn.Checked &&
                !sueRadioBtn.Checked &&
                !lauraRadioBtn.Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool servicesCheck()
        {
            if (!cutCheckBtn.Checked &&
                !colourCheckBtn.Checked &&
                !highlightCheckBtn.Checked &&
                !extCheckBtn.Checked)
            {
                return false;

            } else
            {
                return true;
            }
        }

        private bool clientCheck()
        {
            if(!adultRadioBtn.Checked &&
                !childRadioBtn.Checked &&
                !studentRadioBtn.Checked &&
                !seniorRadioBtn.Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //HAIRDRESSER UNCHECKER
            foreach (Control c in hairDresserBox.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }

            //SERVICES UNCHECKER
            foreach (Control c in servicesBox.Controls)
            {
                if (c is CheckBox cb)
                {
                    cb.Checked = false;
                }
            }

            //CLIENT UNCHECKER
            foreach (Control c in clientTypeBox.Controls)
            {
                if (c is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }


            testBox.Text = "";
            visitTextBox.Text = "";

            dresserOutput.Text = "";
            serviceOutput.Text = "";
            clientOutput.Text = "";
            visitOutput.Text = "";
            priceOutput.Text = "";




        }
    }


    internal class TotalCalc
    {
        //ATTRIBUTES
        public double baseRate;
        public double serviceRate;
        public double clientDiscount;
        public double visitDiscount;
        public double totalPrice;


        //CONSTRUCTOR
        public TotalCalc(int dresser, string services, int client, int visits)
        {
            //DRESSER
            switch (dresser)
            {
                case 1: this.baseRate = 30;  break; //jane
                case 2: this.baseRate = 45; break; //pat
                case 3: this.baseRate = 40; break; //ron
                case 4: this.baseRate = 50; break; //sue
                case 5: this.baseRate = 55; break; //laurie
            }

            //SERVICES
            this.serviceRate = serviceCalc(services);

            //local variable totalBase
            double totalBase = baseRate + serviceRate;



            //CLIENT
            switch (client)
            {
                case 1: this.clientDiscount = totalBase * 0; break; //adult 
                case 2: this.clientDiscount = totalBase * 0.1; break; //child 
                case 3: this.clientDiscount = totalBase * 0.05; break; //student
                case 4: this.clientDiscount = totalBase * 0.15; break; //senior
            }

            //VISITS
            if (visits >= 1 && visits <= 3) // 1–3 visits
            {
                this.visitDiscount = totalBase * 0;
            }
            else if (visits <= 8) // 4–8 visits
            {
                this.visitDiscount = totalBase * 0.05;
            }
            else if (visits <= 13) // 9–13 visits
            {
                this.visitDiscount = totalBase * 0.1;
            }
            else // 14+ visits
            {
                this.visitDiscount = totalBase * 0.15;
            }



            //TOTAL PRICE
            this.totalPrice = totalBase - this.visitDiscount - this.clientDiscount;

        }

        //METHODS
        private double serviceCalc(string s) //XOXO ONLY 4 CHARACTERS
        {
            double totalService = 0;
            if (s[0] == 'X') { totalService += 30; } //CUT SERVICE 
            if (s[1] == 'X') { totalService += 40; } //COLOR SERVICE 
            if (s[2] == 'X') { totalService += 50; } //HIGHLIGHTS SERVICE
            if (s[3] == 'X') { totalService += 200; } //EXTENSIONS SERVICE 

            return totalService;
        }



    }
}
