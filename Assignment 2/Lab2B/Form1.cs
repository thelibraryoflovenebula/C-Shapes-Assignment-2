using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/** STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */

namespace Lab2B
{
    public partial class Form1 : Form
    {
        //ATTRIBUTES

        //CONSTRUCTOR
        /// <summary>
        /// Form1() constructor, initializes everything
        /// also starts program with specific state -> jane button clicked, adult button clicked
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            janeRadioBtn.Checked = true;
            adultRadioBtn.Checked = true;
        }

        //METHODS
        /// <summary>
        /// CALCULATE METHOD (void, no return)
        /// encompasses:
        ///     - validation for at least one button check for each group
        ///     - makes use of TotalCalc class to calculate necessary values on each clicked event 
        ///     - validation for integer input from user (TryParse)
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                testBox.Text = "Must check at least one service.";
                testBox.ForeColor = Color.Red;
            } 
            else
            {
                if (int.TryParse(visitAsk, out visitValidation))
                {
                    if (visitValidation > 0)
                    {
                        //reset text box
                        testBox.Text = "";

                        //HAIRDRESSOR PICK [for TotalCalc Constructor]
                        int dresser = 0;
                        if (janeRadioBtn.Checked)     { dresser = 1; }
                        else if (patRadioBtn.Checked) { dresser = 2; }
                        else if (ronRadioBtn.Checked) { dresser = 3; }
                        else if (sueRadioBtn.Checked) { dresser = 4; }
                        else /*lauraRadioBtn.Checked*/{ dresser = 5; }

                        //SERVICE CHECK [for TotalCalc Constructor]
                        string serviceString = "";
                        if (cutCheckBtn.Checked)        { serviceString += "X"; } else { serviceString += "O"; }
                        if (colourCheckBtn.Checked)     { serviceString += "X"; } else { serviceString += "O"; }
                        if (highlightCheckBtn.Checked)  { serviceString += "X"; } else { serviceString += "O"; }
                        if (extCheckBtn.Checked)        { serviceString += "X"; } else { serviceString += "O"; }

                        //CLIENT PICK  [for TotalCalc Constructor]

                        int client = 0;
                        if (adultRadioBtn.Checked)          { client = 1; }
                        else if (childRadioBtn.Checked)     { client = 2; }
                        else if (studentRadioBtn.Checked)   { client = 3; }
                        else  /*seniorRadioBtn.Checked */   { client = 4; }

                        int visit = visitValidation; //already implemented [for TotalCalc Constructor]


                        
                        TotalCalc calc = new TotalCalc(dresser, serviceString, client, visit);

                        //output to designated textboxes
                        dresserOutput.Text = $"${calc.baseRate:F2}";
                        serviceOutput.Text = $"${calc.serviceRate:F2}";
                        clientOutput.Text = $"${calc.clientDiscount:F2}";
                        visitOutput.Text = $"${calc.visitDiscount:F2}";
                        priceOutput.Text = $"${calc.totalPrice:F2}";
                        
                    }
                    else
                    {
                        testBox.Text = "Must be an integer (positive)";
                        testBox.ForeColor = Color.Red;
                    }
                }
                else
                {
                    testBox.Text = "Must be an integer (non-decimal numbers)";
                    testBox.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// helper method for calcBtn_click() function
        /// assists for local allChecked gate (&& for all three checks)
        /// for hair dresser group box [radio button] 
        /// 
        /// </summary>
        /// <returns>boolean, true if one checked, false if none checked </returns>
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

        /// <summary>
        /// helper method for calcBtn_click() function
        /// assists for local allChecked gate (&& for all three checks)
        /// for services group box [check box]
        /// 
        /// </summary>
        /// <returns>boolean, true if one checked, false if none checked </returns>
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

        /// <summary>
        /// helper method for calcBtn_click() function
        /// assists for local allChecked gate (&& for all three checks)
        /// for client group box [radio button] 
        /// 
        /// </summary>
        /// <returns>boolean, true if one checked, false if none checked </returns>
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

        /// <summary>
        /// Clear button event handler to clear buttons
        /// unchecks everything, resets to start point
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            //reset specific start points, textboxes, radio/check btns 
            janeRadioBtn.Checked = true;
            adultRadioBtn.Checked = true;
            testBox.Text = "";
            visitTextBox.Text = "";

            dresserOutput.Text = "";
            serviceOutput.Text = "";
            clientOutput.Text = "";
            visitOutput.Text = "";
            priceOutput.Text = "";




        }

        /// <summary>
        /// exit button, to close program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    /// <summary>
    /// TOTAL CALCULATION CLASS 
    /// class for making total calculations
    /// 
    /// resorted to object orienteted code for calculating and 
    /// showing values for client calculations
    /// </summary>
    internal class TotalCalc
    {
        //ATTRIBUTES
        public double baseRate;
        public double serviceRate;
        public double clientDiscount;
        public double visitDiscount;
        public double totalPrice;


        //CONSTRUCTOR
        /// <summary>
        /// Constructor for Total Calculation
        /// 
        /// params take validated int choices, and string binary choices.
        /// outputs necessary numbers into instance's variables
        /// 
        /// 
        /// </summary>
        /// <param name="dresser">   choice of dresser, chosen through radio  </param>
        /// <param name="services">  specific set of service checkboxes ("XXXX" -> "OOOO"), length of 4, choice of 2^4 possibilites   </param>
        /// <param name="client">    client type chooser, chosen through radio   </param>
        /// <param name="visits">    visit integer input (already validated   </param>
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
            //calls helper method to calculate service
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
        /// <summary>
        /// Helper method to calculate service instance variable
        /// </summary>
        /// <param name="s"> string input translated from checkbox. MUST BE LENGTH OF 4</param>
        /// <returns></returns>
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
