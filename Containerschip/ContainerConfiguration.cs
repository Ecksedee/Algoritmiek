using Containerschip.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using Container = Containerschip.Models.Container;
using System.Drawing;

namespace Containerschip
{
    public partial class ContainerConfiguration : Form
    {
        Freighter freighter;
        List<Container> unsortedContainers;
        public ContainerConfiguration(Freighter freighter)
        {
            InitializeComponent();
            this.freighter = freighter;
        }

        private void BtnAddContainer_Click(object sender, EventArgs e)
        {
            try
            {
                unsortedContainers = new List<Container>();

                int containerWeight = Convert.ToInt32(nudContainerWeight.Value);
                var type = Models.Type.Standard;

                if (rdoCooled.Checked)
                {
                    type = Models.Type.Cooled;
                }
                else if (rdoValuable.Checked)
                {
                    type = Models.Type.Valuable;
                }

                unsortedContainers.Add(new Container(containerWeight, type));
                unsortedContainers = unsortedContainers.OrderBy(x => x.Type).ThenByDescending(o => o.Weight).ToList();
                lstContainers.Items.AddRange(unsortedContainers.ToArray());
                rtxLog.ForeColor = Color.Green;
                rtxLog.Text = "Container added.";
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                rtxLog.ForeColor = Color.Red;
                rtxLog.Text = "Something went wrong adding the container.";
            }
        }

        private void BtnStartSorting_Click(object sender, EventArgs e)
        {
            try
            {
                Freighter.WeightFailsLimits(freighter.MaximumWeight, freighter.MinimumWeight, freighter.LoadCapacity, TotalContainersWeight());

                OpenFreighterVisual();
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
                rtxLog.ForeColor = Color.Red;
                rtxLog.Text = exc.Message;
            }
        }

        private void BtnRemoveContainer_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO:
                // Container uit listbox en unsortedContainers verwijderen en listbox updaten
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Something went wrong removing the container.");
            }
        }

        private void OpenFreighterVisual()
        {
            rtxLog.ForeColor = Color.Green;
            rtxLog.Text = "Sorting the containers...";

            //TODO:
            // Algoritme aanroepen en freighter meesturen

            //this.Hide();
            //FreighterVisual freighter1 = new FreighterVisual(freighter);
            //freighter1.ShowDialog();
            //this.Close();
        }

        /// <summary>
        /// Calculates the total weight of all the containers combined
        /// </summary>
        /// <returns></returns>
        private int TotalContainersWeight()
        {
            return unsortedContainers.Sum(x => x.Weight);
        }
    }
}
