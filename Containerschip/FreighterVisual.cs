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
    public partial class FreighterVisual : Form
    {
        Freighter freighter;
        public FreighterVisual(Freighter freighter)
        {
            InitializeComponent();
            this.freighter = freighter;
        }
    }
}
