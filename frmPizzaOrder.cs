using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeYourPizza
{
    public partial class frmPizzaOrder : Form
    {
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        private void frmPizzaOrder_Load(object sender, EventArgs e)
        {
            lblToppingsValue.Tag = new List<string>();
        }

        void ChangeLabel(Label label, RadioButton radioButton)
        {
            if (radioButton.Checked)
                label.Text = radioButton.Text;
        }

        void ChangeTotalPriceBy(object ControlTag, bool IsControlChecked)
        {
            int TagNumber = Convert.ToInt32(ControlTag);
            int TotalPriceNumber = Convert.ToInt32(lblTotalPriceValue.Tag);

            TotalPriceNumber += (IsControlChecked) ? TagNumber : -TagNumber;
            lblTotalPriceValue.Tag = TotalPriceNumber;

            lblTotalPriceValue.Text = "$" + TotalPriceNumber.ToString();
        }

        void ChangeToppingsValue(CheckBox checkBox)
        {
            List<string> toppingsList = lblToppingsValue.Tag as List<string>;

            if (lblToppingsValue.Text == "No Toppings" || checkBox.Checked)
                toppingsList.Add(checkBox.Text);
            else
                toppingsList.Remove(checkBox.Text);

            lblToppingsValue.Tag = toppingsList;
            lblToppingsValue.Text = (toppingsList.Count() == 0) ? 
                "No Toppings" : 
                string.Join(", ", toppingsList);
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            rbMedium.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            foreach (CheckBox checkBox in gbToppings.Controls)
                checkBox.Checked = false;
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblSizeValue, rbSmall);
            ChangeTotalPriceBy(rbSmall.Tag, rbSmall.Checked);
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblSizeValue, rbMedium);
            ChangeTotalPriceBy(rbMedium.Tag, rbMedium.Checked);
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblSizeValue, rbLarge);
            ChangeTotalPriceBy(rbLarge.Tag, rbLarge.Checked);
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblCrustTypeValue, rbThickCrust);
            ChangeTotalPriceBy(rbThickCrust.Tag, rbThickCrust.Checked);
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblCrustTypeValue, rbThinCrust);
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblWhereToEatValue, rbEatIn);
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            ChangeLabel(lblWhereToEatValue, rbTakeOut);
        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkExtraCheese);
            ChangeTotalPriceBy(chkExtraCheese.Tag, chkExtraCheese.Checked);
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkMushrooms);
            ChangeTotalPriceBy(chkMushrooms.Tag, chkMushrooms.Checked);
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkTomatoes);
            ChangeTotalPriceBy(chkTomatoes.Tag, chkTomatoes.Checked);
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkOnion);
            ChangeTotalPriceBy(chkOnion.Tag, chkOnion.Checked);
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkOlives);
            ChangeTotalPriceBy(chkOlives.Tag, chkOlives.Checked);
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            ChangeToppingsValue(chkGreenPeppers);
            ChangeTotalPriceBy(chkGreenPeppers.Tag, chkGreenPeppers.Checked);
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (MessageBox.Show("Order Placed Succesfully", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    gbSize.Enabled = false;
                    gbCrustType.Enabled = false;
                    gbToppings.Enabled = false;
                    gbWhereToEat.Enabled = false;
                    btnOrderPizza.Enabled = false;
                }
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
