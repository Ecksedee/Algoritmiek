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
                rtxLog.Text = "Container added!";
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
                Freighter.WeightExceedsMaxWeight(freighter.MaximumWeight, TotalContainersWeight());
                Freighter.WeightExceedsCapacity(freighter.MaximumWeight, TotalContainersWeight());

                OpenFreighterVisual();
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
                rtxLog.ForeColor = Color.Red;
                rtxLog.Text = exc.Message;
            }
        }

        private void OpenFreighterVisual()
        {
            this.Hide();
            FreighterVisual freighter1 = new FreighterVisual(freighter);
            freighter1.ShowDialog();
            this.Close();
        }

        private int TotalContainersWeight()
        {
            int totalContainersWeight = 0;

            foreach (var container in unsortedContainers)
            {
                totalContainersWeight += container.Weight;
            }
            return totalContainersWeight;
        }
    }
}
