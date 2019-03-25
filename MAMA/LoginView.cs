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
        private Controller _controller;
        private int counter;

        public LoginView()
        {
            InitializeComponent();
            counter = 0;
        }

        public void SetContoller(Controller controller)
        {
            _controller = controller;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!Password.CheckPassword(txt_userPassword.Text))
            {
                counter++;
            }
            else
            {
                // Start Main View
            }

            if (counter >= 3)
            {
                // Quit
                
            }
            
        }

        private void LoginView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Quit
            
        }
    }
}
