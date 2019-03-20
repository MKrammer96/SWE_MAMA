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
    public partial class MainView : Form
    {
        private Controller Controller;

        public MainView()
        {
            InitializeComponent();
        }

        public void GetContoller(Controller controller)
        {
            Controller = controller;
        }

        //Check the Name of the ButtonClicked and to reference to the functions
        private void ButtonClicked(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button) sender;

                if (btn == ButtonSaveNewBalance)
                {

                }
                if (btn == ButtonCancelNewBalance)
                {

                }
                if (btn == ButtonSaveEditItems)
                {

                }
                if (btn == ButtonCancelEditItems)
                {

                }
                if(btn == ButtonAddNewAmount)
                {

                }
                if (btn == ButtonSubNewAmount)
                {

                }
                
            }

        }

        private void MenuStripClicked(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(MenuStrip))
            {
                MenuStrip menuStrip = (MenuStrip)sender;
                
            }

        }

        private void TabControlTextBoxChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txBox = (TextBox) sender;

                //Check Input Balance
                if (txBox.Name == TextBoxNewAmount.Name)
                {

                }
                if (txBox.Name == TextBoxNewBalance.Name)
                {

                }
                if (txBox.Name == TextBoxCurrentBalance.Name)
                {

                }
                //Check Input Edit Items 
                if (txBox.Name == TextBoxLastNameEditItems.Name)
                {

                }
                if (txBox.Name == TextBoxEMailEditItems.Name)
                {

                }
            }
        }















































        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
