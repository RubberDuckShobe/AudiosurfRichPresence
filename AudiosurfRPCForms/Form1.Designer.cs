using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AudiosurfRPCForms {

    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.registeredLabel = new System.Windows.Forms.Label();
            this.howToUseLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Register Window";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // registeredLabel
            // 
            this.registeredLabel.AutoSize = true;
            this.registeredLabel.Location = new System.Drawing.Point(108, 106);
            this.registeredLabel.Name = "registeredLabel";
            this.registeredLabel.Size = new System.Drawing.Size(130, 13);
            this.registeredLabel.TabIndex = 1;
            this.registeredLabel.Text = "Window not registered yet";
            // 
            // howToUseLabel
            // 
            this.howToUseLabel.AutoSize = true;
            this.howToUseLabel.Location = new System.Drawing.Point(2, 5);
            this.howToUseLabel.Name = "howToUseLabel";
            this.howToUseLabel.Size = new System.Drawing.Size(243, 91);
            this.howToUseLabel.TabIndex = 2;
            this.howToUseLabel.Text = resources.GetString("howToUseLabel.Text");
            this.howToUseLabel.Click += new System.EventHandler(this.howToUseLabel_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(2, 127);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(90, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Current status:\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 183);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.howToUseLabel);
            this.Controls.Add(this.registeredLabel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "AudiosurfRPC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label registeredLabel;
        private Label howToUseLabel;
        private Label statusLabel;
    }
}

