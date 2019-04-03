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
        private Controller _controller;
        private int counter;

        public LoginView()
        {
            InitializeComponent();
            txt_userPassword.PasswordChar = '*';
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
                MessageBox.Show("Wrong Password");
            }
            else
            {
                CloseLoginView?.Invoke(this,new CloseLoginViewEventArgs(true));
                
            }

            if (counter >= 3)
            {                
                CloseLoginView?.Invoke(this, new CloseLoginViewEventArgs(false));
                MessageBox.Show("There has been three wrong passwort inputs");
                
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                loginButton.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
