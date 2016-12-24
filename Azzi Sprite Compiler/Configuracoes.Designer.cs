namespace Azzi_Sprite_Compiler
{
    partial class configuracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configuracoes));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loginsprite = new System.Windows.Forms.TextBox();
            this.loginsenha1 = new System.Windows.Forms.TextBox();
            this.loginsenha2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.remeberme = new System.Windows.Forms.CheckBox();
            this.salvar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.security = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "To set a password on your Tibia Sprites\r\nyou will need to sacrifice a sprite (the" +
                " sprite\r\nwhere the password will be registered).";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sprite Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Repeat";
            // 
            // loginsprite
            // 
            this.loginsprite.Location = new System.Drawing.Point(117, 64);
            this.loginsprite.Name = "loginsprite";
            this.loginsprite.Size = new System.Drawing.Size(100, 20);
            this.loginsprite.TabIndex = 4;
            this.loginsprite.TextChanged += new System.EventHandler(this.loginsprite_TextChanged);
            // 
            // loginsenha1
            // 
            this.loginsenha1.Location = new System.Drawing.Point(117, 87);
            this.loginsenha1.Name = "loginsenha1";
            this.loginsenha1.PasswordChar = '•';
            this.loginsenha1.Size = new System.Drawing.Size(100, 20);
            this.loginsenha1.TabIndex = 5;
            // 
            // loginsenha2
            // 
            this.loginsenha2.Location = new System.Drawing.Point(117, 109);
            this.loginsenha2.Name = "loginsenha2";
            this.loginsenha2.PasswordChar = '•';
            this.loginsenha2.Size = new System.Drawing.Size(100, 20);
            this.loginsenha2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 39);
            this.label5.TabIndex = 7;
            this.label5.Text = "You can add another sprite in sprites folder,\r\nso that it is compiled as the last" +
                ", and then\r\nsacrifice it to use as password container.";
            // 
            // remeberme
            // 
            this.remeberme.AutoSize = true;
            this.remeberme.Location = new System.Drawing.Point(15, 288);
            this.remeberme.Name = "remeberme";
            this.remeberme.Size = new System.Drawing.Size(176, 17);
            this.remeberme.TabIndex = 9;
            this.remeberme.Text = "Always remember these settings";
            this.remeberme.UseVisualStyleBackColor = true;
            // 
            // salvar
            // 
            this.salvar.Location = new System.Drawing.Point(146, 315);
            this.salvar.Name = "salvar";
            this.salvar.Size = new System.Drawing.Size(74, 23);
            this.salvar.TabIndex = 11;
            this.salvar.Text = "Save";
            this.salvar.UseVisualStyleBackColor = true;
            this.salvar.Click += new System.EventHandler(this.salvar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(66, 315);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(74, 23);
            this.cancelar.TabIndex = 10;
            this.cancelar.Text = "Cancel";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // security
            // 
            this.security.AutoSize = true;
            this.security.Location = new System.Drawing.Point(15, 189);
            this.security.Name = "security";
            this.security.Size = new System.Drawing.Size(113, 17);
            this.security.TabIndex = 8;
            this.security.Text = "Add More Security";
            this.security.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 65);
            this.label6.TabIndex = 13;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 348);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.security);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.salvar);
            this.Controls.Add(this.remeberme);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loginsenha2);
            this.Controls.Add(this.loginsenha1);
            this.Controls.Add(this.loginsprite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(235, 372);
            this.MinimumSize = new System.Drawing.Size(235, 372);
            this.Name = "configuracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Config";
            this.Load += new System.EventHandler(this.configuracoes_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.configuracoes_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loginsprite;
        private System.Windows.Forms.TextBox loginsenha1;
        private System.Windows.Forms.TextBox loginsenha2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox remeberme;
        private System.Windows.Forms.Button salvar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.CheckBox security;
        private System.Windows.Forms.Label label6;
    }
}