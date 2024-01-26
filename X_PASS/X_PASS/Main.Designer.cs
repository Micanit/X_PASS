namespace X_PASS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.addRowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLastRow = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectRows = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LockButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLogin,
            this.ColumnPassword,
            this.ColumnName});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(776, 417);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnLogin
            // 
            this.ColumnLogin.HeaderText = "Login";
            this.ColumnLogin.MinimumWidth = 30;
            this.ColumnLogin.Name = "ColumnLogin";
            this.ColumnLogin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnLogin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnLogin.Width = 280;
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.HeaderText = "Password";
            this.ColumnPassword.MinimumWidth = 30;
            this.ColumnPassword.Name = "ColumnPassword";
            this.ColumnPassword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPassword.Width = 280;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.MinimumWidth = 30;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Width = 210;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStripDropDown,
            this.toolStripDropDownButton2,
            this.LockButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addStripDropDown
            // 
            this.addStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addStripDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowMenu,
            this.addColumnMenu});
            this.addStripDropDown.Image = ((System.Drawing.Image)(resources.GetObject("addStripDropDown.Image")));
            this.addStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addStripDropDown.Name = "addStripDropDown";
            this.addStripDropDown.Size = new System.Drawing.Size(51, 27);
            this.addStripDropDown.Text = "Add";
            // 
            // addRowMenu
            // 
            this.addRowMenu.Name = "addRowMenu";
            this.addRowMenu.Size = new System.Drawing.Size(175, 26);
            this.addRowMenu.Text = "Add Row";
            this.addRowMenu.Click += new System.EventHandler(this.addRowMenu_Click);
            // 
            // addColumnMenu
            // 
            this.addColumnMenu.Name = "addColumnMenu";
            this.addColumnMenu.Size = new System.Drawing.Size(175, 26);
            this.addColumnMenu.Text = "Add Column";
            this.addColumnMenu.Click += new System.EventHandler(this.addColumnMenu_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem,
            this.deleteColumnToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(67, 27);
            this.toolStripDropDownButton2.Text = "Delete";
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLastRow,
            this.deleteSelectRows,
            this.deleteAllRowsToolStripMenuItem});
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.deleteRowToolStripMenuItem.Text = "Delete row";
            // 
            // deleteLastRow
            // 
            this.deleteLastRow.Name = "deleteLastRow";
            this.deleteLastRow.Size = new System.Drawing.Size(213, 26);
            this.deleteLastRow.Text = "Delete last row";
            this.deleteLastRow.Click += new System.EventHandler(this.deleteLastRow_Click);
            // 
            // deleteSelectRows
            // 
            this.deleteSelectRows.Name = "deleteSelectRows";
            this.deleteSelectRows.Size = new System.Drawing.Size(213, 26);
            this.deleteSelectRows.Text = "Delete select rows";
            this.deleteSelectRows.Click += new System.EventHandler(this.deleteSelectRows_Click);
            // 
            // deleteAllRowsToolStripMenuItem
            // 
            this.deleteAllRowsToolStripMenuItem.Name = "deleteAllRowsToolStripMenuItem";
            this.deleteAllRowsToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.deleteAllRowsToolStripMenuItem.Text = "Delete all rows";
            this.deleteAllRowsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllRowsToolStripMenuItem_Click);
            // 
            // deleteColumnToolStripMenuItem
            // 
            this.deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            this.deleteColumnToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.deleteColumnToolStripMenuItem.Text = "Delete column";
            this.deleteColumnToolStripMenuItem.Click += new System.EventHandler(this.deleteColumnToolStripMenuItem_Click);
            // 
            // LockButton
            // 
            this.LockButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LockButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LockButton.Image = ((System.Drawing.Image)(resources.GetObject("LockButton.Image")));
            this.LockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(30, 27);
            this.LockButton.Text = "🔒";
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "X PASS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton addStripDropDown;
        private System.Windows.Forms.ToolStripMenuItem addRowMenu;
        private System.Windows.Forms.ToolStripMenuItem addColumnMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLastRow;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectRows;
        private System.Windows.Forms.ToolStripMenuItem deleteAllRowsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.ToolStripButton LockButton;
    }
}