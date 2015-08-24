using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WampSharpDemo
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class WampSharpForm : Form
    {
        public WampSharpForm()
        {
            InitializeComponent();
            UpdateCase();
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(numClientsTb,
                "Number of different subscribers to all topics");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(label10,
                "Number of different subscribers to all topics");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(eventToTestTb,
                "Test will finish after publishing of this number of events");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(label7,
                "Test will finish after publishing of this number of events");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(rateTb,
                "Publisher will generate new events to a random topic at this rate");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(label6,
                "Publisher will generate new events to a random topic at this rate");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(eventProcessTimeTb,
                "Subscriber will spend this time processing each event");
            new ToolTip {InitialDelay = 100, IsBalloon = true}.SetToolTip(label9,
                "Subscriber will spend this time processing each event");
            ThreadPool.SetMaxThreads(1000, 1000);
            Observable.Timer(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1)).Subscribe(l =>
            {
                producedTxtBx.BeginInvoke((Action) (() =>
                {
                    producedTxtBx.Text = "" + Server.Instance.NumPublished;
                    topicsTb.Text = "" + Server.Instance.CurrentTopics;
                    sessionsTb.Text = "" + Server.CurrentSessions;
                    subscriptionsTb.Text = "" + Server.CurrentSubscribers;
                    consumedTb.Text = "" + Client.EventsConsumed;
                }));
            });
        }

        private void loadTestButton_Click(object sender, EventArgs e)
        {
            Server.Rate = int.Parse(rateTb.Text);
            //
            producedTxtBx.Text = "0";
            consumedTb.Text = "0";
            var eventProcessTimeMillis = int.Parse(eventProcessTimeTb.Text);
            var eventsToTest = int.Parse(eventToTestTb.Text);
            var numClients = int.Parse(numClientsTb.Text);
            var local = ClientsLocation().Equals("in-process");
            var terminateAnyClientInTheMiddle = case4.Checked;
            //
            ThreadPool.QueueUserWorkItem(state =>
            {
                loadTestButton.BeginInvoke((Action) (() =>
                {
                    loadTestButton.Enabled = false;
                    numClientsTb.Enabled = false;
                    comboBox1.Enabled = false;
                    eventToTestTb.Enabled = false;
                    rateTb.Enabled = false;
                    eventProcessTimeTb.Enabled = false;
                }));
                try
                {
                    Server.Instance.NumPublished = 0;
                    Client.EventsConsumed = 0;
                    //
                    var terminate = Client.RunLoadTest(numClients, local, eventProcessTimeMillis);
                    //
                    while (Server.Instance.NumPublished < eventsToTest)
                    {
                        Thread.Sleep(100);
                        if (terminateAnyClientInTheMiddle && Server.Instance.NumPublished >= eventsToTest/2)
                        {
                            terminateAnyClientInTheMiddle = false;
                            terminate(true);
                        }
                    }
                    //
                    terminate(false);
                    //
                    while (Server.CurrentSessions > 0) Thread.Sleep(1000);
                    //
                    if (Server.CurrentSubscribers > 0)
                    {
                        MessageBox.Show("Load test completed. Did not get _topic.SubscriptionRemoving/Removed event. "
                                        + "\r\nStill have " + Server.CurrentSubscribers + " subscriptions alive."
                                        + "\r\nPlease check WampSharpDemo.log for details.",
                            "Error");
                    }
                    else if (Server.Instance.CurrentTopics > 0)
                    {
                        MessageBox.Show("Load test completed. Did not get _realm.TopicContainer.TopicRemoved event. "
                                        + "\r\nStill have " + Server.Instance.CurrentTopics + " topics alive."
                                        + "\r\nPlease check WampSharpDemo.log for details.",
                            "Error");
                    }
                    else
                    {
                        MessageBox.Show("Load test completed", "Info");
                    }
                }
                finally
                {
                    loadTestButton.BeginInvoke((Action) (() =>
                    {
                        loadTestButton.Enabled = true;
                        numClientsTb.Enabled = true;
                        comboBox1.Enabled = true;
                        eventToTestTb.Enabled = true;
                        rateTb.Enabled = true;
                        eventProcessTimeTb.Enabled = true;
                    }));
                }
            });
        }

        private void UpdateDescription()
        {
            descriptionTb.Text =
                "Runs " + numClientsTb.Text + " " + ClientsLocation() + " clients subscribing to 1000 topics. " +
                "Server publishes " + eventToTestTb.Text + " events at " + rateTb.Text + " events/second rate. " +
                "Each event is processed in " + eventProcessTimeTb.Text + " millis.";
        }

        private string ClientsLocation()
        {
            switch (comboBox1.Text)
            {
                case "Subscribers as external processes":
                    return "external";
            }
            return "in-process";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void numClientsTb_TextChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void eventToTestTb_TextChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void rateTb_TextChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void eventProcessTimeTb_TextChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void case1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCase();
        }

        private void UpdateCase()
        {
            // client type, num clients, events, tps, time
            string[][] opts =
            {
                new[] {"In-process subscribers", "1", "250", "10", "5"},
                new[] {"Subscribers as external processes", "1", "250", "10", "5"},
                new[] {"Subscribers as external processes", "2", "5000", "500", "5"},
                new[] {"Subscribers as external processes", "2", "25000", "1000", "85"},
                new[] {"In-process subscribers", "10", "25000", "1000", "85"},
                new[] {"Subscribers as external processes", "10", "50000", "1000", "100"}
            };
            var ix =
                (case2.Checked ? 1 : 0)
                + (case3.Checked ? 2 : 0)
                + (case4.Checked ? 3 : 0)
                + (case5.Checked ? 4 : 0)
                + (case6.Checked ? 5 : 0)
                ;
            var opt = opts[ix];
            comboBox1.Text = opt[0];
            numClientsTb.Text = opt[1];
            eventToTestTb.Text = opt[2];
            rateTb.Text = opt[3];
            eventProcessTimeTb.Text = opt[4];
        }

        private void case2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCase();
        }

        private void case3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCase();
        }

        private void case4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCase();
        }
    }
}