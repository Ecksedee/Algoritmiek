﻿using Containerschip.Models;
using System;
using System.Windows.Forms;

namespace Containerschip
{
    public partial class FreighterConfiguration : Form
    {
        Freighter freighter;

        public FreighterConfiguration()
        {
            InitializeComponent();
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            try
            {
                int lengthInContainers = Convert.ToInt32(nudLengthInContainers.Value);
                int widthInContainers = Convert.ToInt32(nudWidthInContainers.Value);
                int heightInContainers = Convert.ToInt32(nudHeightInContainers.Value);

                freighter = new Freighter(widthInContainers, lengthInContainers, heightInContainers);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Something went wrong creating the freighter.");
            }

            OpenContainerConfiguration();
        }

        private void OpenContainerConfiguration()
        {
            this.Hide();
            ContainerConfiguration containerConfig = new ContainerConfiguration(freighter);
            containerConfig.ShowDialog();
            this.Close();
        }
    }
}
