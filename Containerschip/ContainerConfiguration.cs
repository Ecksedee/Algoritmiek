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
            unsortedContainers = new List<Container>();
        }

        private void BtnAddContainer_Click(object sender, EventArgs e)
        {
            try
            {
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
                UpdateContainerListBox();
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
                Container selectedContainer = lstContainers.SelectedItem as Container;
                if (selectedContainer == null)
                {
                    MessageBox.Show("Please select a container");
                }
                unsortedContainers.Remove(selectedContainer);
                UpdateContainerListBox();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                MessageBox.Show("Something went wrong removing the container.");
            }
        }

        /// <summary>
        /// Shows the visualisation of the sorted containers
        /// </summary>
        private void OpenFreighterVisual()
        {
            rtxLog.ForeColor = Color.Green;
            rtxLog.Text = "Sorting the containers...";

            if (Freighter.CapacityExceedsWeightLimit(freighter.MaximumWeight, freighter.LoadCapacity))
            {
                freighter.LoadCapacity = freighter.MaximumWeight;
            }

            Algorithm algorithm = new Algorithm(freighter);
            algorithm.Sort(unsortedContainers);

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

        private void UpdateContainerListBox()
        {
            lstContainers.Items.Clear();
            lstContainers.Items.AddRange(unsortedContainers.OrderBy(x => x.Type).ThenByDescending(o => o.Weight).ToArray());
            lblTotalWeight.Text = TotalContainersWeight().ToString();
        }
    }
}
    