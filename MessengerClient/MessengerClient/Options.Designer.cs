namespace MessengerClient
{
    partial class Options
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
            button1=new Button();
            label1=new Label();
            label2=new Label();
            textBox1=new TextBox();
            textBox2=new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location=new Point(62, 151);
            button1.Name="button1";
            button1.Size=new Size(135, 38);
            button1.TabIndex=0;
            button1.Text="Сохранить";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(24, 53);
            label1.Name="label1";
            label1.Size=new Size(20, 15);
            label1.TabIndex=1;
            label1.Text="IP:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(12, 95);
            label2.Name="label2";
            label2.Size=new Size(32, 15);
            label2.TabIndex=2;
            label2.Text="Port:";
            label2.Click+=label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location=new Point(50, 50);
            textBox1.Name="textBox1";
            textBox1.Size=new Size(167, 23);
            textBox1.TabIndex=3;
            // 
            // textBox2
            // 
            textBox2.Location=new Point(50, 92);
            textBox2.Name="textBox2";
            textBox2.Size=new Size(167, 23);
            textBox2.TabIndex=4;
            // 
            // Options
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(243, 201);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name="Options";
            Text="Options";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}