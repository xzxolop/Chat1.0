namespace MessengerClient
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
            button1=new Button();
            button2=new Button();
            textBox1=new TextBox();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            richTextBox1=new RichTextBox();
            richTextBox2=new RichTextBox();
            menuStrip1=new MenuStrip();
            менюToolStripMenuItem=new ToolStripMenuItem();
            настройкиToolStripMenuItem=new ToolStripMenuItem();
            выходToolStripMenuItem=new ToolStripMenuItem();
            авторToolStripMenuItem=new ToolStripMenuItem();
            label4=new Label();
            label5=new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location=new Point(464, 315);
            button1.Name="button1";
            button1.Size=new Size(85, 87);
            button1.TabIndex=0;
            button1.Text="Отправить";
            button1.UseVisualStyleBackColor=true;
            // 
            // button2
            // 
            button2.Location=new Point(288, 42);
            button2.Name="button2";
            button2.Size=new Size(127, 46);
            button2.TabIndex=1;
            button2.Text="Вход";
            button2.UseVisualStyleBackColor=true;
            // 
            // textBox1
            // 
            textBox1.Location=new Point(12, 55);
            textBox1.Name="textBox1";
            textBox1.Size=new Size(270, 23);
            textBox1.TabIndex=2;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(12, 37);
            label1.Name="label1";
            label1.Size=new Size(78, 15);
            label1.TabIndex=3;
            label1.Text="Введите имя:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(12, 100);
            label2.Name="label2";
            label2.Size=new Size(29, 15);
            label2.TabIndex=4;
            label2.Text="Чат:";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(12, 297);
            label3.Name="label3";
            label3.Size=new Size(135, 15);
            label3.TabIndex=5;
            label3.Text="Написать сообщение...";
            // 
            // richTextBox1
            // 
            richTextBox1.Location=new Point(12, 118);
            richTextBox1.Name="richTextBox1";
            richTextBox1.Size=new Size(537, 166);
            richTextBox1.TabIndex=6;
            richTextBox1.Text="";
            // 
            // richTextBox2
            // 
            richTextBox2.Location=new Point(12, 315);
            richTextBox2.Name="richTextBox2";
            richTextBox2.Size=new Size(446, 87);
            richTextBox2.TabIndex=7;
            richTextBox2.Text="";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, авторToolStripMenuItem });
            menuStrip1.Location=new Point(0, 0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Size=new Size(800, 24);
            menuStrip1.TabIndex=8;
            menuStrip1.Text="menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem, выходToolStripMenuItem });
            менюToolStripMenuItem.Name="менюToolStripMenuItem";
            менюToolStripMenuItem.Size=new Size(53, 20);
            менюToolStripMenuItem.Text="Меню";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name="настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size=new Size(134, 22);
            настройкиToolStripMenuItem.Text="Настройки";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name="выходToolStripMenuItem";
            выходToolStripMenuItem.Size=new Size(134, 22);
            выходToolStripMenuItem.Text="Выход";
            // 
            // авторToolStripMenuItem
            // 
            авторToolStripMenuItem.Name="авторToolStripMenuItem";
            авторToolStripMenuItem.Size=new Size(52, 20);
            авторToolStripMenuItem.Text="Автор";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(0, 0);
            label4.Name="label4";
            label4.Size=new Size(38, 15);
            label4.TabIndex=9;
            label4.Text="label4";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(672, 42);
            label5.Name="label5";
            label5.Size=new Size(28, 15);
            label5.TabIndex=10;
            label5.Text="info";
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip=menuStrip1;
            Name="Form1";
            Text="Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem авторToolStripMenuItem;
        private Label label4;
        private Label label5;
    }
}