namespace Basic_Synth
{
    partial class BasicSynth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oscillatorController2 = new Basic_Synth.OscillatorController();
            this.oscillatorController1 = new Basic_Synth.OscillatorController();
            this.oscillatorController3 = new Basic_Synth.OscillatorController();
            this.SuspendLayout();
            // 
            // oscillatorController2
            // 
            this.oscillatorController2.Location = new System.Drawing.Point(13, 138);
            this.oscillatorController2.Name = "oscillatorController2";
            this.oscillatorController2.Size = new System.Drawing.Size(280, 100);
            this.oscillatorController2.TabIndex = 1;
            this.oscillatorController2.TabStop = false;
            this.oscillatorController2.Text = "oscillatorController2";
            // 
            // oscillatorController1
            // 
            this.oscillatorController1.Location = new System.Drawing.Point(12, 12);
            this.oscillatorController1.Name = "oscillatorController1";
            this.oscillatorController1.Size = new System.Drawing.Size(290, 100);
            this.oscillatorController1.TabIndex = 0;
            this.oscillatorController1.TabStop = false;
            this.oscillatorController1.Text = "oscillatorController1";
            // 
            // oscillatorController3
            // 
            this.oscillatorController3.Location = new System.Drawing.Point(13, 262);
            this.oscillatorController3.Name = "oscillatorController3";
            this.oscillatorController3.Size = new System.Drawing.Size(280, 100);
            this.oscillatorController3.TabIndex = 6;
            this.oscillatorController3.TabStop = false;
            this.oscillatorController3.Text = "oscillatorController3";
            // 
            // BasicSynth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oscillatorController3);
            this.Controls.Add(this.oscillatorController2);
            this.Controls.Add(this.oscillatorController1);
            this.KeyPreview = true;
            this.Name = "BasicSynth";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasicSynth_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private OscillatorController oscillatorController1;
        private OscillatorController oscillatorController2;
        private OscillatorController oscillatorController3;
    }
}

