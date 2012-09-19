using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LootAlert
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtBox62s.Text = Settings.Min62s.ToString();
            txtBox63s.Text = Settings.Min63s.ToString();
            txtBoxMagic.Text = Settings.MinMagic.ToString();
            txtBoxPID.Text = Settings.OverrideProcessID.ToString();
        }

        private void txtBox62s_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBox63s_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBoxMagic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void RevertToDefault()
        {
            txtBox62s.Text = (62).ToString();
            txtBox63s.Text = (63).ToString();
            txtBoxMagic.Text = (61).ToString();
            txtBoxPID.Text = (0).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBox62s.Text))
                txtBox62s.Text = (0).ToString();
            if (string.IsNullOrEmpty(txtBox63s.Text))
                txtBox63s.Text = (0).ToString();
            if (string.IsNullOrEmpty(txtBoxMagic.Text))
                txtBoxMagic.Text = (0).ToString();
            if (string.IsNullOrEmpty(txtBoxPID.Text))
                txtBoxPID.Text = (0).ToString();

            int val62 = 0;
            if (int.TryParse(txtBox62s.Text, out val62) == false)
            {
                MessageBox.Show("Invalid textfield input");
                return;
            }

            int val63 = 0;
            if (int.TryParse(txtBox63s.Text, out val63) == false)
            {
                MessageBox.Show("Invalid textfield input");
                return;
            }

            int valMagic = 0;
            if (int.TryParse(txtBoxMagic.Text, out valMagic) == false)
            {
                MessageBox.Show("Invalid textfield input");
                return;
            }

            int valPID = 0;
            if (int.TryParse(txtBoxPID.Text, out valPID) == false)
            {
                MessageBox.Show("Invalid textfield input");
                return;
            }

            Settings.Min62s = val62;
            Settings.Min63s = val63;
            Settings.MinMagic = valMagic;
            Settings.OverrideProcessID = valPID;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            RevertToDefault();
        }

        private void txtBoxPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
