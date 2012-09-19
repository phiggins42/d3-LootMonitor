using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace LootAlert
{
    public partial class LootAlert : Form
    {
        private const string version = "1.0.2";
        private Timer timer;
        private bool Running;
        private LegendaryFinder finder;

        public LootAlert()
        {
            InitializeComponent();
            this.Text += " " + version;
            checkBoxLegendary.Checked = Settings.PlayOnLegendary;
            checkBoxRare.Checked = Settings.PlayOnRare;
            checkBoxCrafting.Checked = Settings.PlayOnCrafting;
            checkBoxMagic.Checked = Settings.PlayOnMagic;

            Sounds.InitSounds();
            finder = new LegendaryFinder();

            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 200;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Sounds.PlaySound(finder.FindLegendary());
            }
            catch (Exception ex)
            {
                SetStatus(false);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnTestSound_Click(object sender, EventArgs e)
        {
            Sounds.PlaySound((Sound)new Random().Next(1, 5));
        }

        private bool SetStatus(bool status)
        {
            if (status == true)
            {
                try
                {
                    if (d3.Start(Settings.OverrideProcessID) == false)
                        return false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not find the diablo process!");
                    return false;
                }
                timer.Enabled = true;
            }

            if (status == false)
            {
                try
                {
                    d3.ResetMemory();
                }
                catch (Exception)
                {
                }
                timer.Enabled = false;
            }

            return true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Running == false)
            {
                if (SetStatus(true))
                {
                    btnStart.Text = "Stop";
                    Running = true;
                }
            }
            else
            {
                if (SetStatus(false))
                {
                    btnStart.Text = "Start";
                    Running = false;
                }
            }
        }

        private void checkBoxLegendary_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PlayOnLegendary = checkBoxLegendary.Checked;
        }

        private void checkBoxRare_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PlayOnRare = checkBoxRare.Checked;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            form.ShowDialog(this);
        }

        private void checkBoxCrafting_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PlayOnCrafting = checkBoxCrafting.Checked;
        }

        private void checkBoxMagic_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PlayOnMagic = checkBoxMagic.Checked;
        }
    }
}
