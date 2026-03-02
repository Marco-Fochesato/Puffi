namespace Puffi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlArea = new Panel();
            pnlCasa = new Panel();
            pnlPuffo = new Panel();
            txtPunti = new TextBox();
            pnlArea.SuspendLayout();
            SuspendLayout();
            // 
            // pnlArea
            // 
            pnlArea.BackColor = Color.FromArgb(192, 255, 192);
            pnlArea.BorderStyle = BorderStyle.FixedSingle;
            pnlArea.Controls.Add(pnlCasa);
            pnlArea.Controls.Add(pnlPuffo);
            pnlArea.Location = new Point(0, 0);
            pnlArea.Name = "pnlArea";
            pnlArea.Size = new Size(1938, 1172);
            pnlArea.TabIndex = 0;
            // 
            // pnlCasa
            // 
            pnlCasa.BackColor = Color.Red;
            pnlCasa.Location = new Point(1132, 431);
            pnlCasa.Name = "pnlCasa";
            pnlCasa.Size = new Size(200, 200);
            pnlCasa.TabIndex = 1;
            // 
            // pnlPuffo
            // 
            pnlPuffo.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlPuffo.BackColor = Color.LightBlue;
            pnlPuffo.Location = new Point(0, 0);
            pnlPuffo.Name = "pnlPuffo";
            pnlPuffo.Size = new Size(50, 100);
            pnlPuffo.TabIndex = 0;
            // 
            // txtPunti
            // 
            txtPunti.AcceptsTab = true;
            txtPunti.BackColor = Color.FromArgb(224, 224, 224);
            txtPunti.Location = new Point(1953, 28);
            txtPunti.Name = "txtPunti";
            txtPunti.ReadOnly = true;
            txtPunti.Size = new Size(194, 39);
            txtPunti.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2156, 1216);
            Controls.Add(txtPunti);
            Controls.Add(pnlArea);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += PressTasto;
            pnlArea.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlArea;
        private Panel pnlPuffo;
        private Panel pnlCasa;
        private TextBox txtPunti;
    }
}
