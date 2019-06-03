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
                Random r = new Random();

                if (rdoCooled.Checked)
                {
                    type = Models.Type.Cooled;
                }
                else if (rdoValuable.Checked)
                {
                    type = Models.Type.Valuable;
                }

                for (int i = 0; i < nudAmount.Value; i++)
                {
                    if (chkRandomize.Checked)
                    {
                        unsortedContainers.Add(new Container(r.Next(4000, 30000), type));
                    }
                    else
                    {
                        unsortedContainers.Add(new Container(containerWeight, type));
                    }
                }

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
                freighter.WeightFailsLimits(unsortedContainers);
                freighter.CooledContainersExceedsMaximum(unsortedContainers);
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

            Algorithm algorithm = new Algorithm(freighter);
            freighter.Containers = algorithm.Sort(unsortedContainers);
            rtxLog.Text = String.Format("The containers have been sorted with a left/right weight difference of {0} %",freighter.Balance);

            string visualText = "";

            for (int width = 0; width < freighter.Width; width++)
            {
                for (int length = 0; length < freighter.Length; length++)
                {
                    for (int height = 0; height < freighter.Height; height++)
                    {
                        visualText += String.Format("[{0},{1},{2}] = {3}", width, length, height, freighter.Containers[width, length, height]) + "\n";
                    }
                }
            }

            rtxVisual.Text = visualText;
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

        private void BtnClear_Click(object sender, EventArgs e)
        {
            unsortedContainers.Clear();
            UpdateContainerListBox();
        }

        private void ChkRandomize_CheckedChanged(object sender, EventArgs e)
        {
            nudContainerWeight.Enabled = !nudContainerWeight.Enabled;
        }
    }
}
    