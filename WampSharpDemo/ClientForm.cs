using System;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace WampSharpDemo
{
    public partial class ClientForm : Form
    {
        public ClientForm(string info)
        {
            InitializeComponent();
            textBox1.Text = info;
            Observable.Timer(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1))
                .Subscribe(
                    l => { consumedTb.BeginInvoke((Action) (() => { consumedTb.Text = "" + Client.EventsConsumed; })); });
        }

        private void terminateButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
//            Application.Exit();
        }
    }
}