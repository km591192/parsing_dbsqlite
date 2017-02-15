using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parsing_wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip.SetToolTip(btnalldb, "All info from database.");
            toolTip.SetToolTip(btnfinddburl, "Find information in database by URL.");
            toolTip.SetToolTip(btnfdbid, "Find information in database by ID.");
            toolTip.SetToolTip(btnparsing, "Parsing ");
            toolTip.SetToolTip(btnclear, " Clear all");
        }


        Pars parsing = new Pars();
        string ans = String.Empty;
        string[] splitans;

        Controller control = new Controller();

        private async void btnparsing_Click(object sender, EventArgs e)
        {
            ans = await parsing.runparsing(tburl.Text.Trim().ToString());
            splitans = ans.Split('~');
            rtbans.Text = splitans[0];
            tbtime.Text = splitans[1];
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tburl.Clear();
            rtbans.Clear();
            tbtime.Clear();
            rtbdb.Clear();
            tbid.Clear();
        }

        private void btnalldb_Click(object sender, EventArgs e)
        {
           rtbdb.Text = control.GetAll();
        }

        private void btnfdbid_Click(object sender, EventArgs e)
        {
            rtbdb.Text = control.GetInfobyId(tbid.Text.Trim().ToString());
        }

        private void btnfinddburl_Click(object sender, EventArgs e)
        {
            rtbdb.Text = control.GetInfobyURL(tburl.Text.Trim().ToString());
        }

    }
}


