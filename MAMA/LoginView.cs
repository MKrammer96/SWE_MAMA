using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMA
{
    public partial class LoginView : Form
    {
        public event EventHandler CloseLoginView;

        public LoginView()
        {
            InitializeComponent();
        }


        private void CloseView(object sender, EventArgs e)
        {
            //check the password
            
            CloseLoginView?.Invoke(this, new CloseLoginViewEventArgs(true));
        }
    }
}
