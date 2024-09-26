namespace Working
{
    partial class NewsWindow
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
            components = new System.ComponentModel.Container();
            newsLbl = new Label();
            exitBtn = new Button();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            addBtn = new Button();
            newsBoxTxt = new RichTextBox();
            commitBtn = new Button();
            backgroundFormsBtn = new Button();
            listFormsBox = new ComboBox();
            setBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            funnBtn = new Button();
            questBtn = new Button();
            importantBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // newsLbl
            // 
            newsLbl.AutoSize = true;
            newsLbl.Font = new Font("Segoe UI", 29F);
            newsLbl.Location = new Point(263, 18);
            newsLbl.Name = "newsLbl";
            newsLbl.Size = new Size(174, 52);
            newsLbl.TabIndex = 0;
            newsLbl.Text = "Новости";
            // 
            // exitBtn
            // 
            exitBtn.Font = new Font("Segoe UI", 19F);
            exitBtn.Location = new Point(1020, 519);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(221, 67);
            exitBtn.TabIndex = 4;
            exitBtn.Text = "Выйти";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // listView1
            // 
            listView1.Alignment = ListViewAlignment.Left;
            listView1.Font = new Font("Segoe UI", 10F);
            listView1.Location = new Point(32, 106);
            listView1.Margin = new Padding(30, 3, 3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(663, 307);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // addBtn
            // 
            addBtn.Font = new Font("Segoe UI", 19F);
            addBtn.Location = new Point(701, 176);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(221, 49);
            addBtn.TabIndex = 6;
            addBtn.Text = "Добавить новость";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // newsBoxTxt
            // 
            newsBoxTxt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            newsBoxTxt.Location = new Point(32, 106);
            newsBoxTxt.Name = "newsBoxTxt";
            newsBoxTxt.Size = new Size(494, 307);
            newsBoxTxt.TabIndex = 7;
            newsBoxTxt.Text = "Напишите свою новость";
            newsBoxTxt.Visible = false;
            // 
            // commitBtn
            // 
            commitBtn.Font = new Font("Segoe UI", 19F);
            commitBtn.Location = new Point(701, 106);
            commitBtn.Name = "commitBtn";
            commitBtn.Size = new Size(221, 49);
            commitBtn.TabIndex = 8;
            commitBtn.Text = "Сохранить";
            commitBtn.UseVisualStyleBackColor = true;
            commitBtn.Visible = false;
            commitBtn.Click += commitBtn_Click;
            // 
            // backgroundFormsBtn
            // 
            backgroundFormsBtn.Font = new Font("Segoe UI", 19F);
            backgroundFormsBtn.Location = new Point(32, 519);
            backgroundFormsBtn.Name = "backgroundFormsBtn";
            backgroundFormsBtn.Size = new Size(221, 49);
            backgroundFormsBtn.TabIndex = 9;
            backgroundFormsBtn.Text = "Задать фон";
            backgroundFormsBtn.UseVisualStyleBackColor = true;
            backgroundFormsBtn.Click += backgroundFormsBtn_Click;
            // 
            // listFormsBox
            // 
            listFormsBox.Font = new Font("Segoe UI", 13F);
            listFormsBox.FormattingEnabled = true;
            listFormsBox.Items.AddRange(new object[] { "MainWindow", "LoginWindow", "NewsWindow" });
            listFormsBox.Location = new Point(32, 459);
            listFormsBox.Name = "listFormsBox";
            listFormsBox.Size = new Size(221, 31);
            listFormsBox.TabIndex = 10;
            listFormsBox.Visible = false;
            // 
            // setBtn
            // 
            setBtn.Font = new Font("Segoe UI", 19F);
            setBtn.Location = new Point(32, 519);
            setBtn.Name = "setBtn";
            setBtn.Size = new Size(221, 49);
            setBtn.TabIndex = 11;
            setBtn.Text = "Применить";
            setBtn.UseVisualStyleBackColor = true;
            setBtn.Click += setBtn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // funnBtn
            // 
            funnBtn.Font = new Font("Segoe UI", 19F);
            funnBtn.Location = new Point(1020, 464);
            funnBtn.Name = "funnBtn";
            funnBtn.Size = new Size(221, 49);
            funnBtn.TabIndex = 12;
            funnBtn.Text = "Не жмать";
            funnBtn.UseVisualStyleBackColor = true;
            funnBtn.Click += funnBtn_Click;
            // 
            // questBtn
            // 
            questBtn.Font = new Font("Segoe UI", 19F);
            questBtn.Location = new Point(1020, 409);
            questBtn.Name = "questBtn";
            questBtn.Size = new Size(221, 49);
            questBtn.TabIndex = 13;
            questBtn.Text = "Не жмать";
            questBtn.UseVisualStyleBackColor = true;
            questBtn.Click += questBtn_Click;
            // 
            // importantBtn
            // 
            importantBtn.Font = new Font("Segoe UI", 19F);
            importantBtn.Location = new Point(1020, 340);
            importantBtn.Name = "importantBtn";
            importantBtn.Size = new Size(221, 49);
            importantBtn.TabIndex = 14;
            importantBtn.Text = "Не жмать";
            importantBtn.UseVisualStyleBackColor = true;
            importantBtn.Click += importantBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(774, 432);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 15;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // NewsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 598);
            Controls.Add(label1);
            Controls.Add(importantBtn);
            Controls.Add(questBtn);
            Controls.Add(funnBtn);
            Controls.Add(listFormsBox);
            Controls.Add(backgroundFormsBtn);
            Controls.Add(commitBtn);
            Controls.Add(addBtn);
            Controls.Add(listView1);
            Controls.Add(exitBtn);
            Controls.Add(newsLbl);
            Controls.Add(newsBoxTxt);
            Controls.Add(setBtn);
            Name = "NewsWindow";
            Text = "MyApp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label newsLbl;
        private Button exitBtn;
        private ListView listView1;
        private ImageList imageList1;
        private Button addBtn;
        private RichTextBox newsBoxTxt;
        private Button commitBtn;
        private Button backgroundFormsBtn;
        private ComboBox listFormsBox;
        private Button setBtn;
        private OpenFileDialog openFileDialog1;
        private Button funnBtn;
        private Button questBtn;
        private Button importantBtn;
        private Label label1;
    }
}