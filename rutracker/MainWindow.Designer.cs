namespace rutracker
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.главноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lableCountFoundTor = new System.Windows.Forms.ToolStripStatusLabel();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.источникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqLiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Поиск = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonStopSearch = new System.Windows.Forms.Button();
            this.buttonNewSearch = new System.Windows.Forms.Button();
            this.buttonContinueSearch = new System.Windows.Forms.Button();
            this.textFieldSearch = new System.Windows.Forms.TextBox();
            this.registred_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoundItemsView = new System.Windows.Forms.DataGridView();
            this.xmlВSqLiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Поиск.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoundItemsView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главноеToolStripMenuItem,
            this.параметрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // главноеToolStripMenuItem
            // 
            this.главноеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.главноеToolStripMenuItem.Name = "главноеToolStripMenuItem";
            this.главноеToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.главноеToolStripMenuItem.Text = "Главное";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelState,
            this.lableCountFoundTor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelState
            // 
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(58, 17);
            this.labelState.Text = "labelState";
            // 
            // lableCountFoundTor
            // 
            this.lableCountFoundTor.Name = "lableCountFoundTor";
            this.lableCountFoundTor.Size = new System.Drawing.Size(120, 17);
            this.lableCountFoundTor.Text = "LableCountFoundTor";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкаToolStripMenuItem,
            this.источникToolStripMenuItem,
            this.xmlВSqLiteToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // источникToolStripMenuItem
            // 
            this.источникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xmlToolStripMenuItem,
            this.sqLiteToolStripMenuItem});
            this.источникToolStripMenuItem.Name = "источникToolStripMenuItem";
            this.источникToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.источникToolStripMenuItem.Text = "Источник";
            // 
            // xmlToolStripMenuItem
            // 
            this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
            this.xmlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xmlToolStripMenuItem.Text = "xml";
            // 
            // sqLiteToolStripMenuItem
            // 
            this.sqLiteToolStripMenuItem.Name = "sqLiteToolStripMenuItem";
            this.sqLiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sqLiteToolStripMenuItem.Text = "sqLite";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Поиск);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 437);
            this.tabControl1.TabIndex = 11;
            // 
            // Поиск
            // 
            this.Поиск.Controls.Add(this.FoundItemsView);
            this.Поиск.Controls.Add(this.textFieldSearch);
            this.Поиск.Controls.Add(this.buttonContinueSearch);
            this.Поиск.Controls.Add(this.buttonNewSearch);
            this.Поиск.Controls.Add(this.buttonStopSearch);
            this.Поиск.Location = new System.Drawing.Point(4, 22);
            this.Поиск.Name = "Поиск";
            this.Поиск.Padding = new System.Windows.Forms.Padding(3);
            this.Поиск.Size = new System.Drawing.Size(868, 411);
            this.Поиск.TabIndex = 0;
            this.Поиск.Text = "Поиск";
            this.Поиск.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonStopSearch
            // 
            this.buttonStopSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopSearch.Location = new System.Drawing.Point(708, 6);
            this.buttonStopSearch.Name = "buttonStopSearch";
            this.buttonStopSearch.Size = new System.Drawing.Size(66, 20);
            this.buttonStopSearch.TabIndex = 7;
            this.buttonStopSearch.Text = "Стоп";
            this.buttonStopSearch.UseVisualStyleBackColor = true;
            this.buttonStopSearch.Click += new System.EventHandler(this.buttonStopSearch_Click);
            // 
            // buttonNewSearch
            // 
            this.buttonNewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewSearch.Location = new System.Drawing.Point(602, 6);
            this.buttonNewSearch.Name = "buttonNewSearch";
            this.buttonNewSearch.Size = new System.Drawing.Size(100, 20);
            this.buttonNewSearch.TabIndex = 0;
            this.buttonNewSearch.Text = "Новый поиск";
            this.buttonNewSearch.UseVisualStyleBackColor = true;
            this.buttonNewSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNewSearch_Click);
            // 
            // buttonContinueSearch
            // 
            this.buttonContinueSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinueSearch.Location = new System.Drawing.Point(780, 6);
            this.buttonContinueSearch.Name = "buttonContinueSearch";
            this.buttonContinueSearch.Size = new System.Drawing.Size(84, 20);
            this.buttonContinueSearch.TabIndex = 8;
            this.buttonContinueSearch.Text = "Продолжить";
            this.buttonContinueSearch.UseVisualStyleBackColor = true;
            this.buttonContinueSearch.Click += new System.EventHandler(this.buttonContinueSearch_Click);
            // 
            // textFieldSearch
            // 
            this.textFieldSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFieldSearch.Location = new System.Drawing.Point(0, 7);
            this.textFieldSearch.Name = "textFieldSearch";
            this.textFieldSearch.Size = new System.Drawing.Size(596, 20);
            this.textFieldSearch.TabIndex = 2;
            // 
            // registred_at
            // 
            this.registred_at.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.registred_at.HeaderText = "Дата регистрации";
            this.registred_at.Name = "registred_at";
            this.registred_at.ReadOnly = true;
            this.registred_at.Width = 114;
            // 
            // size
            // 
            this.size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.size.HeaderText = "Размер";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 71;
            // 
            // titel
            // 
            this.titel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titel.HeaderText = "Тема";
            this.titel.Name = "titel";
            this.titel.ReadOnly = true;
            // 
            // forumName
            // 
            this.forumName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.forumName.HeaderText = "Форум";
            this.forumName.Name = "forumName";
            this.forumName.ReadOnly = true;
            this.forumName.Width = 68;
            // 
            // FoundItemsView
            // 
            this.FoundItemsView.AllowUserToAddRows = false;
            this.FoundItemsView.AllowUserToDeleteRows = false;
            this.FoundItemsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FoundItemsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoundItemsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.forumName,
            this.titel,
            this.size,
            this.registred_at});
            this.FoundItemsView.Location = new System.Drawing.Point(0, 33);
            this.FoundItemsView.Name = "FoundItemsView";
            this.FoundItemsView.ReadOnly = true;
            this.FoundItemsView.RowHeadersVisible = false;
            this.FoundItemsView.ShowCellToolTips = false;
            this.FoundItemsView.ShowEditingIcon = false;
            this.FoundItemsView.ShowRowErrors = false;
            this.FoundItemsView.Size = new System.Drawing.Size(868, 378);
            this.FoundItemsView.TabIndex = 5;
            // 
            // xmlВSqLiteToolStripMenuItem
            // 
            this.xmlВSqLiteToolStripMenuItem.Name = "xmlВSqLiteToolStripMenuItem";
            this.xmlВSqLiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xmlВSqLiteToolStripMenuItem.Text = "xml в sqLite";
            this.xmlВSqLiteToolStripMenuItem.Click += new System.EventHandler(this.xmlВSqLiteToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 489);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Поиск.ResumeLayout(false);
            this.Поиск.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoundItemsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem главноеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelState;
        private System.Windows.Forms.ToolStripStatusLabel lableCountFoundTor;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem источникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqLiteToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Поиск;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView FoundItemsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn forumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn titel;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn registred_at;
        private System.Windows.Forms.TextBox textFieldSearch;
        private System.Windows.Forms.Button buttonContinueSearch;
        private System.Windows.Forms.Button buttonNewSearch;
        private System.Windows.Forms.Button buttonStopSearch;
        private System.Windows.Forms.ToolStripMenuItem xmlВSqLiteToolStripMenuItem;
    }
}

