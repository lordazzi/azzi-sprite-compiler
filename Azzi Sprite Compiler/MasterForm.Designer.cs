namespace Azzi_Sprite_Compiler
{
    partial class MasterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.Extract = new System.Windows.Forms.Button();
            this.Compile = new System.Windows.Forms.Button();
            this.Donate = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Registred = new System.Windows.Forms.TextBox();
            this.Read = new System.Windows.Forms.TextBox();
            this.Exported = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Compiled = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.Label();
            MasterForm.ShowMsg = new System.Windows.Forms.Timer(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.labelTempo = new System.Windows.Forms.Label();
            this.Configs = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selectversion = new System.Windows.Forms.ComboBox();
            MasterForm.criptografia = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(MasterForm.criptografia)).BeginInit();
            this.SuspendLayout();
            // 
            // Extract
            // 
            this.Extract.Location = new System.Drawing.Point(3, 3);
            this.Extract.Name = "Extract";
            this.Extract.Size = new System.Drawing.Size(59, 21);
            this.Extract.TabIndex = 0;
            this.Extract.Text = "Extract";
            this.Extract.UseVisualStyleBackColor = true;
            this.Extract.Click += new System.EventHandler(this.Extract_Click);
            // 
            // Compile
            // 
            this.Compile.Location = new System.Drawing.Point(68, 3);
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(59, 21);
            this.Compile.TabIndex = 1;
            this.Compile.Text = "Compile";
            this.Compile.UseVisualStyleBackColor = true;
            this.Compile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // Donate
            // 
            this.Donate.Location = new System.Drawing.Point(133, 3);
            this.Donate.Name = "Donate";
            this.Donate.Size = new System.Drawing.Size(59, 21);
            this.Donate.TabIndex = 2;
            this.Donate.Text = "Donate";
            this.Donate.UseVisualStyleBackColor = true;
            this.Donate.Click += new System.EventHandler(this.Donate_Click);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(260, 3);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(59, 21);
            this.About.TabIndex = 4;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sprites registred number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sprites read:";
            // 
            // Registred
            // 
            this.Registred.BackColor = System.Drawing.Color.White;
            this.Registred.Enabled = false;
            this.Registred.ForeColor = System.Drawing.Color.Black;
            this.Registred.Location = new System.Drawing.Point(244, 59);
            this.Registred.Name = "Registred";
            this.Registred.Size = new System.Drawing.Size(78, 20);
            this.Registred.TabIndex = 6;
            this.Registred.Text = "0";
            // 
            // Read
            // 
            this.Read.BackColor = System.Drawing.Color.White;
            this.Read.Enabled = false;
            this.Read.ForeColor = System.Drawing.Color.Black;
            this.Read.Location = new System.Drawing.Point(244, 83);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(78, 20);
            this.Read.TabIndex = 7;
            this.Read.Text = "0";
            // 
            // Exported
            // 
            this.Exported.BackColor = System.Drawing.Color.White;
            this.Exported.Enabled = false;
            this.Exported.ForeColor = System.Drawing.Color.Black;
            this.Exported.Location = new System.Drawing.Point(244, 109);
            this.Exported.Name = "Exported";
            this.Exported.Size = new System.Drawing.Size(78, 20);
            this.Exported.TabIndex = 8;
            this.Exported.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sprites exported:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sprites compiled:";
            // 
            // Compiled
            // 
            this.Compiled.BackColor = System.Drawing.Color.White;
            this.Compiled.Enabled = false;
            this.Compiled.ForeColor = System.Drawing.Color.Black;
            this.Compiled.Location = new System.Drawing.Point(244, 135);
            this.Compiled.Name = "Compiled";
            this.Compiled.Size = new System.Drawing.Size(78, 20);
            this.Compiled.TabIndex = 10;
            this.Compiled.Text = "0";
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg.ForeColor = System.Drawing.Color.Green;
            this.Msg.Location = new System.Drawing.Point(6, 163);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(115, 16);
            this.Msg.TabIndex = 12;
            this.Msg.Text = "Welcome, foreign! (:";
            // 
            // ShowMsg
            // 
            MasterForm.ShowMsg.Enabled = true;
            MasterForm.ShowMsg.Interval = 1;
            MasterForm.ShowMsg.Tick += new System.EventHandler(this.ShowMsg_Tick);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.Location = new System.Drawing.Point(294, 166);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(34, 13);
            this.labelTempo.TabIndex = 13;
            this.labelTempo.Text = "00:00";
            // 
            // Configs
            // 
            this.Configs.Location = new System.Drawing.Point(198, 3);
            this.Configs.Name = "Configs";
            this.Configs.Size = new System.Drawing.Size(59, 21);
            this.Configs.TabIndex = 3;
            this.Configs.Text = "Config";
            this.Configs.UseVisualStyleBackColor = true;
            this.Configs.Click += new System.EventHandler(this.Configs_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Version";
            // 
            // selectversion
            // 
            this.selectversion.BackColor = System.Drawing.SystemColors.Window;
            this.selectversion.DisplayMember = "1";
            this.selectversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectversion.FormattingEnabled = true;
            this.selectversion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectversion.Items.AddRange(new object[] {
            "7.2 to 9.5",
            "9.6 to ...",
            "3.1 to 7.0"});
            this.selectversion.Location = new System.Drawing.Point(244, 35);
            this.selectversion.Name = "selectversion";
            this.selectversion.Size = new System.Drawing.Size(78, 21);
            this.selectversion.TabIndex = 17;
            this.selectversion.SelectedIndexChanged += new System.EventHandler(this.selectversion_SelectedIndexChanged);
            // 
            // criptografia
            // 
            MasterForm.criptografia.Image = ((System.Drawing.Image)(resources.GetObject("criptografia.Image")));
            MasterForm.criptografia.Location = new System.Drawing.Point(172, 135);
            MasterForm.criptografia.Name = "criptografia";
            MasterForm.criptografia.Size = new System.Drawing.Size(37, 36);
            MasterForm.criptografia.TabIndex = 18;
            MasterForm.criptografia.TabStop = false;
            MasterForm.criptografia.Visible = false;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 192);
            this.Controls.Add(MasterForm.criptografia);
            this.Controls.Add(this.selectversion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Configs);
            this.Controls.Add(this.labelTempo);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Compiled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Exported);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.Registred);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Donate);
            this.Controls.Add(this.Compile);
            this.Controls.Add(this.Extract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterForm";
            this.Text = "Azzi Sprite Compiler 1.0";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(MasterForm.criptografia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Extract;
        private System.Windows.Forms.Button Compile;
        private System.Windows.Forms.Button Donate;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Registred;
        private System.Windows.Forms.TextBox Read;
        private System.Windows.Forms.TextBox Exported;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Compiled;
        private System.Windows.Forms.Label Msg;
        public static System.Windows.Forms.Timer ShowMsg;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.Button Configs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selectversion;
        public static System.Windows.Forms.PictureBox criptografia;
    }
}

