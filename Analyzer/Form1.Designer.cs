
namespace Analyzer
{
    partial class Form1
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
            this.tableLayoutPanelDown = new System.Windows.Forms.TableLayoutPanel();
            this.Input = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelUp = new System.Windows.Forms.TableLayoutPanel();
            this.Outputlabel = new System.Windows.Forms.Label();
            this.Inputlabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelMid = new System.Windows.Forms.TableLayoutPanel();
            this.Symbols = new System.Windows.Forms.Button();
            this.Analysis = new System.Windows.Forms.Button();
            this.tableLayoutPanelDown.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelUp.SuspendLayout();
            this.tableLayoutPanelMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDown
            // 
            this.tableLayoutPanelDown.ColumnCount = 2;
            this.tableLayoutPanelDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDown.Controls.Add(this.Input, 0, 0);
            this.tableLayoutPanelDown.Controls.Add(this.Output, 1, 0);
            this.tableLayoutPanelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDown.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanelDown.Name = "tableLayoutPanelDown";
            this.tableLayoutPanelDown.RowCount = 1;
            this.tableLayoutPanelDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 363F));
            this.tableLayoutPanelDown.Size = new System.Drawing.Size(794, 363);
            this.tableLayoutPanelDown.TabIndex = 0;
            // 
            // Input
            // 
            this.Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input.Location = new System.Drawing.Point(3, 3);
            this.Input.Multiline = true;
            this.Input.Name = "Input";
            this.Input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Input.Size = new System.Drawing.Size(391, 357);
            this.Input.TabIndex = 0;
            // 
            // Output
            // 
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.Location = new System.Drawing.Point(400, 3);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Output.Size = new System.Drawing.Size(391, 357);
            this.Output.TabIndex = 1;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelDown, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelUp, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelUp
            // 
            this.tableLayoutPanelUp.ColumnCount = 3;
            this.tableLayoutPanelUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelUp.Controls.Add(this.Outputlabel, 2, 0);
            this.tableLayoutPanelUp.Controls.Add(this.Inputlabel, 0, 0);
            this.tableLayoutPanelUp.Controls.Add(this.tableLayoutPanelMid, 1, 0);
            this.tableLayoutPanelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUp.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelUp.Name = "tableLayoutPanelUp";
            this.tableLayoutPanelUp.RowCount = 1;
            this.tableLayoutPanelUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelUp.Size = new System.Drawing.Size(794, 75);
            this.tableLayoutPanelUp.TabIndex = 1;
            // 
            // Outputlabel
            // 
            this.Outputlabel.AutoSize = true;
            this.Outputlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Outputlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Outputlabel.Location = new System.Drawing.Point(558, 0);
            this.Outputlabel.Name = "Outputlabel";
            this.Outputlabel.Size = new System.Drawing.Size(233, 75);
            this.Outputlabel.TabIndex = 2;
            this.Outputlabel.Text = "Result";
            this.Outputlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Inputlabel
            // 
            this.Inputlabel.AutoSize = true;
            this.Inputlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inputlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputlabel.Location = new System.Drawing.Point(3, 0);
            this.Inputlabel.Name = "Inputlabel";
            this.Inputlabel.Size = new System.Drawing.Size(232, 75);
            this.Inputlabel.TabIndex = 0;
            this.Inputlabel.Text = "Input Section";
            this.Inputlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelMid
            // 
            this.tableLayoutPanelMid.ColumnCount = 2;
            this.tableLayoutPanelMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMid.Controls.Add(this.Symbols, 1, 0);
            this.tableLayoutPanelMid.Controls.Add(this.Analysis, 0, 0);
            this.tableLayoutPanelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMid.Location = new System.Drawing.Point(241, 3);
            this.tableLayoutPanelMid.Name = "tableLayoutPanelMid";
            this.tableLayoutPanelMid.RowCount = 1;
            this.tableLayoutPanelMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMid.Size = new System.Drawing.Size(311, 69);
            this.tableLayoutPanelMid.TabIndex = 3;
            // 
            // Symbols
            // 
            this.Symbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Symbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Symbols.Location = new System.Drawing.Point(158, 3);
            this.Symbols.Name = "Symbols";
            this.Symbols.Size = new System.Drawing.Size(150, 63);
            this.Symbols.TabIndex = 1;
            this.Symbols.Text = "Symbols";
            this.Symbols.UseVisualStyleBackColor = true;
            this.Symbols.Click += new System.EventHandler(this.Symbols_Click);
            // 
            // Analysis
            // 
            this.Analysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Analysis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analysis.Location = new System.Drawing.Point(3, 3);
            this.Analysis.Name = "Analysis";
            this.Analysis.Size = new System.Drawing.Size(149, 63);
            this.Analysis.TabIndex = 0;
            this.Analysis.Text = "Analysis";
            this.Analysis.UseVisualStyleBackColor = true;
            this.Analysis.Click += new System.EventHandler(this.Analysis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanelDown.ResumeLayout(false);
            this.tableLayoutPanelDown.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelUp.ResumeLayout(false);
            this.tableLayoutPanelUp.PerformLayout();
            this.tableLayoutPanelMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDown;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUp;
        private System.Windows.Forms.Label Inputlabel;
        private System.Windows.Forms.Label Outputlabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMid;
        private System.Windows.Forms.Button Symbols;
        private System.Windows.Forms.Button Analysis;
    }
}

