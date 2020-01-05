using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Synth
{
    class OscillatorController : GroupBox
    {
        public OscillatorController()
        {

            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                BackColor = Color.Yellow
            });
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(65, 15),
                Text = "Square"
            });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(120, 15),
                Text = "Saw"
            });
            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(10, 50),
                Text = "Triangle"
            });
            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise"
            });
            foreach(Control c in this.Controls)
            {
                c.Size = new Size(50, 30);
                c.Font = new Font("Microsoft Consolas", 6.75f);
                c.Click += Wavebtn_Click;
            }
            this.Controls.Add(new CheckBox()
            {
                Name = "OscolatorOn",
                Location = new Point(210, 10),
                Text = "On"
            });

        }
        
        public WaveForm WaveForm { get; private set; }
        public bool On => ((CheckBox)this.Controls["OscolatorOn"]).Checked;

        private void Wavebtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);          
            foreach (Button otherbtn in this.Controls.OfType<Button>())
            {
                // resets color, somehow...
                otherbtn.UseVisualStyleBackColor = true;

            }
            // new active button
            button.BackColor = Color.Yellow;

        }
    }
}
