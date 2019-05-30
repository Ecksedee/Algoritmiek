using Containerschip.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                int loadCapacity = Convert.ToInt32(nudLoadCapacity.Value);

                freighter = new Freighter(lengthInContainers, widthInContainers, heightInContainers, loadCapacity);

                if (Freighter.CapacityExceedsMaxWeight(freighter.MaximumWeight, loadCapacity))
                {
                    throw new ArgumentException("The load capacity exceeds the maximum amount of weight.");
                }
            }
            catch (ArgumentException exc)
            {
                rtxLog.Text = exc.Message;
            }
        }
    }
}
