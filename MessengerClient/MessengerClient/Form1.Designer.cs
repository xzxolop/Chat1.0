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
            send=new Button();
            Connect=new Button();
            NameBox=new TextBox();
            InputName=new Label();
            label2=new Label();
            label3=new Label();
            ChatTextBox=new RichTextBox();
            WriteMessageTextBox=new RichTextBox();
            menuStrip1=new MenuStrip();
            менюToolStripMenuItem=new ToolStripMenuItem();
            настройкиToolStripMenuItem=new ToolStripMenuItem();
            выходToolStripMenuItem=new ToolStripMenuItem();
            авторToolStripMenuItem=new ToolStripMenuItem();
            voroninsToolStripMenuItem=new ToolStripMenuItem();
            info=new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // send
            // 
            send.Location=new Point(464, 315);
            send.Name="send";
            send.Size=new Size(85, 87);
            send.TabIndex=0;
            send.Text="Отправить";
            send.UseVisualStyleBackColor=true;
            send.Click+=send_Click;
            // 
            // Connect
            // 
            Connect.Location=new Point(288, 42);
            Connect.Name="Connect";
            Connect.Size=new Size(127, 46);
            Connect.TabIndex=1;
            Connect.Text="Вход";
            Connect.UseVisualStyleBackColor=true;
            Connect.Click+=Connect_Click;
            // 
            // NameBox
            // 
            NameBox.Location=new Point(12, 55);
            NameBox.Name="NameBox";
            NameBox.Size=new Size(270, 23);
            NameBox.TabIndex=2;
            // 
            // InputName
            // 
            InputName.AutoSize=true;
            InputName.Location=new Point(12, 37);
            InputName.Name="InputName";
            InputName.Size=new Size(78, 15);
            InputName.TabIndex=3;
            InputName.Text="Введите имя:";
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
            // ChatTextBox
            // 
            ChatTextBox.Location=new Point(12, 118);
            ChatTextBox.Name="ChatTextBox";
            ChatTextBox.Size=new Size(537, 166);
            ChatTextBox.TabIndex=6;
            ChatTextBox.Text="";
            // 
            // WriteMessageTextBox
            // 
            WriteMessageTextBox.Location=new Point(12, 315);
            WriteMessageTextBox.Name="WriteMessageTextBox";
            WriteMessageTextBox.Size=new Size(446, 87);
            WriteMessageTextBox.TabIndex=7;
            WriteMessageTextBox.Text="";
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
            настройкиToolStripMenuItem.Click+=настройкиToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name="выходToolStripMenuItem";
            выходToolStripMenuItem.Size=new Size(134, 22);
            выходToolStripMenuItem.Text="Выход";
            выходToolStripMenuItem.Click+=выходToolStripMenuItem_Click;
            // 
            // авторToolStripMenuItem
            // 
            авторToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { voroninsToolStripMenuItem });
            авторToolStripMenuItem.Name="авторToolStripMenuItem";
            авторToolStripMenuItem.Size=new Size(52, 20);
            авторToolStripMenuItem.Text="Автор";
            // 
            // voroninsToolStripMenuItem
            // 
            voroninsToolStripMenuItem.Name="voroninsToolStripMenuItem";
            voroninsToolStripMenuItem.Size=new Size(116, 22);
            voroninsToolStripMenuItem.Text="Vor. inc.";
            // 
            // info
            // 
            info.AutoSize=true;
            info.Location=new Point(452, 42);
            info.Name="info";
            info.Size=new Size(28, 15);
            info.TabIndex=10;
            info.Text="info";
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(info);
            Controls.Add(WriteMessageTextBox);
            Controls.Add(ChatTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(InputName);
            Controls.Add(NameBox);
            Controls.Add(Connect);
            Controls.Add(send);
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

        private Button send;
        private Button Connect;
        private TextBox NameBox;
        private Label InputName;
        private Label label2;
        private Label label3;
        private RichTextBox ChatTextBox;
        private RichTextBox WriteMessageTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem авторToolStripMenuItem;
        private Label info;
        private ToolStripMenuItem voroninsToolStripMenuItem;
    }
}