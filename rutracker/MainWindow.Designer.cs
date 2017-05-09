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
            this.buttonNewSearch = new System.Windows.Forms.Button();
            this.LableCountTorrents = new System.Windows.Forms.Label();
            this.textFieldSearch = new System.Windows.Forms.TextBox();
            this.LableCountFoundTor = new System.Windows.Forms.Label();
            this.FoundItemsView = new System.Windows.Forms.DataGridView();
            this.forumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registred_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelState = new System.Windows.Forms.Label();
            this.buttonStopSearch = new System.Windows.Forms.Button();
            this.buttonContinueSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FoundItemsView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewSearch
            // 
            this.buttonNewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewSearch.Location = new System.Drawing.Point(486, 12);
            this.buttonNewSearch.Name = "buttonNewSearch";
            this.buttonNewSearch.Size = new System.Drawing.Size(100, 20);
            this.buttonNewSearch.TabIndex = 0;
            this.buttonNewSearch.Text = "Новый поиск";
            this.buttonNewSearch.UseVisualStyleBackColor = true;
            this.buttonNewSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonNewSearch_Click);
            // 
            // LableCountTorrents
            // 
            this.LableCountTorrents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LableCountTorrents.AutoSize = true;
            this.LableCountTorrents.Location = new System.Drawing.Point(302, 444);
            this.LableCountTorrents.Name = "LableCountTorrents";
            this.LableCountTorrents.Size = new System.Drawing.Size(127, 13);
            this.LableCountTorrents.TabIndex = 1;
            this.LableCountTorrents.Text = "Количество торрентов: ";
            // 
            // textFieldSearch
            // 
            this.textFieldSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFieldSearch.Location = new System.Drawing.Point(12, 12);
            this.textFieldSearch.Name = "textFieldSearch";
            this.textFieldSearch.Size = new System.Drawing.Size(468, 20);
            this.textFieldSearch.TabIndex = 2;
            // 
            // LableCountFoundTor
            // 
            this.LableCountFoundTor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LableCountFoundTor.AutoSize = true;
            this.LableCountFoundTor.Location = new System.Drawing.Point(521, 444);
            this.LableCountFoundTor.Name = "LableCountFoundTor";
            this.LableCountFoundTor.Size = new System.Drawing.Size(179, 13);
            this.LableCountFoundTor.TabIndex = 4;
            this.LableCountFoundTor.Text = "Количество найденых торрентов: ";
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
            this.FoundItemsView.Location = new System.Drawing.Point(15, 39);
            this.FoundItemsView.Name = "FoundItemsView";
            this.FoundItemsView.ReadOnly = true;
            this.FoundItemsView.RowHeadersVisible = false;
            this.FoundItemsView.ShowCellToolTips = false;
            this.FoundItemsView.ShowEditingIcon = false;
            this.FoundItemsView.ShowRowErrors = false;
            this.FoundItemsView.Size = new System.Drawing.Size(737, 399);
            this.FoundItemsView.TabIndex = 5;
            // 
            // forumName
            // 
            this.forumName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.forumName.HeaderText = "Форум";
            this.forumName.Name = "forumName";
            this.forumName.ReadOnly = true;
            this.forumName.Width = 68;
            // 
            // titel
            // 
            this.titel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titel.HeaderText = "Тема";
            this.titel.Name = "titel";
            this.titel.ReadOnly = true;
            // 
            // size
            // 
            this.size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.size.HeaderText = "Размер";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 71;
            // 
            // registred_at
            // 
            this.registred_at.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.registred_at.HeaderText = "Дата регистрации";
            this.registred_at.Name = "registred_at";
            this.registred_at.ReadOnly = true;
            this.registred_at.Width = 114;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(15, 443);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(67, 13);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "Состояние: ";
            // 
            // buttonStopSearch
            // 
            this.buttonStopSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopSearch.Location = new System.Drawing.Point(592, 12);
            this.buttonStopSearch.Name = "buttonStopSearch";
            this.buttonStopSearch.Size = new System.Drawing.Size(66, 20);
            this.buttonStopSearch.TabIndex = 7;
            this.buttonStopSearch.Text = "Стоп";
            this.buttonStopSearch.UseVisualStyleBackColor = true;
            this.buttonStopSearch.Click += new System.EventHandler(this.buttonStopSearch_Click);
            // 
            // buttonContinueSearch
            // 
            this.buttonContinueSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinueSearch.Location = new System.Drawing.Point(664, 12);
            this.buttonContinueSearch.Name = "buttonContinueSearch";
            this.buttonContinueSearch.Size = new System.Drawing.Size(84, 20);
            this.buttonContinueSearch.TabIndex = 8;
            this.buttonContinueSearch.Text = "Продолжить";
            this.buttonContinueSearch.UseVisualStyleBackColor = true;
            this.buttonContinueSearch.Click += new System.EventHandler(this.buttonContinueSearch_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 466);
            this.Controls.Add(this.buttonContinueSearch);
            this.Controls.Add(this.buttonStopSearch);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.FoundItemsView);
            this.Controls.Add(this.LableCountFoundTor);
            this.Controls.Add(this.buttonNewSearch);
            this.Controls.Add(this.LableCountTorrents);
            this.Controls.Add(this.textFieldSearch);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.FoundItemsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewSearch;
        private System.Windows.Forms.Label LableCountTorrents;
        private System.Windows.Forms.TextBox textFieldSearch;
        private System.Windows.Forms.Label LableCountFoundTor;
        private System.Windows.Forms.DataGridView FoundItemsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn forumName;
        private System.Windows.Forms.DataGridViewTextBoxColumn titel;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn registred_at;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Button buttonStopSearch;
        private System.Windows.Forms.Button buttonContinueSearch;
    }
}

