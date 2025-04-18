using KLWM.Auxiliary;
using System;
using System.Windows.Forms;

namespace KLWM.UserFroms
{
    public partial class frmCount : Form
    {
        public frmCount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double setCount = default(Double);
            setCount = Convert.ToDouble(this.numericUpDown1.Value);
            StaticDelegates.SetInOrOutCount(setCount);
            this.Close();
        }
    }
}
