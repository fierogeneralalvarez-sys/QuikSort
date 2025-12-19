using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSortApp
{
    public partial class MainForm : Form
    {
        // UI Controls
        private NumericUpDown nudSize;
        private Button btnSort;
        private ComboBox cmbAlgorithm; 
        private Label lblAlgoTitle;    
        private ListBox lbOriginal;
        private ListBox lbSorted;
        private Label lblStats;
        private Label lblOriginalTitle;
        private Label lblSortedTitle;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.topPanel = new Panel();
            this.lblSize = new Label();
            this.lblAlgoTitle = new Label(); 
            nudSize = new NumericUpDown();
            cmbAlgorithm = new ComboBox();   
            btnSort = new Button();
            this.bottomPanel = new Panel();
            lblStats = new Label();
            this.splitContainer = new SplitContainer();
            this.leftPanel = new Panel();
            lbOriginal = new ListBox();
            lblOriginalTitle = new Label();
            this.rightPanel = new Panel();
            lbSorted = new ListBox();
            lblSortedTitle = new Label();

            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSize).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            SuspendLayout();

            // 
            // topPanel
            // 
            this.topPanel.BackColor = Color.WhiteSmoke;
            this.topPanel.Controls.Add(this.lblSize);
            this.topPanel.Controls.Add(nudSize);
            this.topPanel.Controls.Add(this.lblAlgoTitle); 
            this.topPanel.Controls.Add(cmbAlgorithm);      
            this.topPanel.Controls.Add(btnSort);
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Location = new Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new Padding(20);
            this.topPanel.Size = new Size(900, 80); 
            this.topPanel.TabIndex = 2;

            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new Point(20, 30);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new Size(89, 23);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Array Size:";

            // 
            // nudSize
            // 
            nudSize.Location = new Point(115, 25);
            nudSize.Maximum = new decimal(new int[] { 50000, 0, 0, 0 }); 
            nudSize.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudSize.Name = "nudSize";
            nudSize.Size = new Size(80, 30);
            nudSize.TabIndex = 1;
            nudSize.Value = new decimal(new int[] { 100, 0, 0, 0 });

            // 
            // lblAlgoTitle
            // 
            this.lblAlgoTitle.AutoSize = true;
            this.lblAlgoTitle.Location = new Point(210, 30);
            this.lblAlgoTitle.Text = "Algorithm:";

            // 
            // cmbAlgorithm 
            // 
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Items.AddRange(new object[] {
            "Bubble Sort",
            "Cocktail Sort"
      });
            cmbAlgorithm.Location = new Point(300, 25);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(140, 31);
            cmbAlgorithm.TabIndex = 3;
            cmbAlgorithm.SelectedIndex = 0; 

            // 
            // btnSort
            // 
            btnSort.BackColor = Color.DodgerBlue;
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(460, 23);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(150, 35);
            btnSort.TabIndex = 2;
            btnSort.Text = "Generate & Sort";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += BtnSort_Click;



            // bottomPanel
            this.bottomPanel.BackColor = Color.LightYellow;
            this.bottomPanel.Controls.Add(lblStats);
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Location = new Point(0, 417);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new Padding(10);
            this.bottomPanel.Size = new Size(782, 257);
            this.bottomPanel.TabIndex = 1;

            // lblStats
            lblStats.Dock = DockStyle.Fill;
            lblStats.Font = new Font("Consolas", 11F, FontStyle.Bold);
            lblStats.Location = new Point(10, 10);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(762, 237);
            lblStats.TabIndex = 0;
            lblStats.Text = "Statistics will appear here...";
            lblStats.TextAlign = ContentAlignment.MiddleCenter;

            // splitContainer
            this.splitContainer.Dock = DockStyle.Fill;
            this.splitContainer.Location = new Point(0, 80);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Panel1.Controls.Add(this.leftPanel);
            this.splitContainer.Panel2.Controls.Add(this.rightPanel);
            this.splitContainer.Size = new Size(782, 337);
            this.splitContainer.SplitterDistance = 484;
            this.splitContainer.TabIndex = 0;

            // Paneles y ListBoxes
            this.leftPanel.Controls.Add(lbOriginal);
            this.leftPanel.Controls.Add(lblOriginalTitle);
            this.leftPanel.Dock = DockStyle.Fill;
            this.leftPanel.Padding = new Padding(10);

            lbOriginal.Dock = DockStyle.Fill;
            lbOriginal.ItemHeight = 23;
            lbOriginal.Location = new Point(10, 40);

            lblOriginalTitle.Dock = DockStyle.Top;
            lblOriginalTitle.Text = "Original Array (Random)";
            lblOriginalTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblOriginalTitle.Size = new Size(464, 30);

            this.rightPanel.Controls.Add(lbSorted);
            this.rightPanel.Controls.Add(lblSortedTitle);
            this.rightPanel.Dock = DockStyle.Fill;
            this.rightPanel.Padding = new Padding(10);

            lbSorted.Dock = DockStyle.Fill;
            lbSorted.ItemHeight = 23;
            lbSorted.Location = new Point(10, 40);

            lblSortedTitle.Dock = DockStyle.Top;
            lblSortedTitle.Text = "Sorted Array";
            lblSortedTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSortedTitle.Size = new Size(274, 30);

            // MainForm properties
            ClientSize = new Size(900, 674);
            Controls.Add(this.splitContainer);
            Controls.Add(this.bottomPanel);
            Controls.Add(this.topPanel);
            Font = new Font("Segoe UI", 10F);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sorting Algorithms Tester";

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSize).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            // 1. Preparation
            int size = (int)nudSize.Value;
            int[] numbers = GenerateRandomArray(size);

            // Clear UI
            lbOriginal.Items.Clear();
            lbSorted.Items.Clear();
            lblStats.Text = "Processing...";
            lblSortedTitle.Text = $"Sorted Array ({cmbAlgorithm.SelectedItem})";

            int displayLimit = 1000;

            // Display Original
            lbOriginal.BeginUpdate();
            for (int i = 0; i < Math.Min(size, displayLimit); i++)
            {
                lbOriginal.Items.Add($"[{i}]: {numbers[i]}");
            }
            if (size > displayLimit) lbOriginal.Items.Add($"... {size - displayLimit} more items hidden ...");
            lbOriginal.EndUpdate();

            // 2. Reset Statistics
            Order.SwapCount = 0;
            Order.ComparisonCount = 0;

            // 3. Execution & Measurement
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // SWITCH PARA ELEGIR EL ALGORITMO
            string selectedAlgo = cmbAlgorithm.SelectedItem.ToString();

            switch (selectedAlgo)
            {
                case "Bubble Sort":
                    Order.BubbleSort(numbers);
                    break;
                case "Cocktail Sort":
                    Order.CocktailSort(numbers);
                    break;
            }

            stopwatch.Stop();

            // 4. Display Sorted Results
            lbSorted.BeginUpdate();
            for (int i = 0; i < Math.Min(size, displayLimit); i++)
            {
                lbSorted.Items.Add($"[{i}]: {numbers[i]}");
            }
            if (size > displayLimit) lbSorted.Items.Add($"... {size - displayLimit} more items hidden ...");
            lbSorted.EndUpdate();

            // 5. Show Statistics
            string statsText = $"Algorithm: {selectedAlgo}\n" +
                               $"Time Elapsed: {stopwatch.Elapsed.TotalMilliseconds:F4} ms\n" +
                               $"Total Swaps: {Order.SwapCount:N0}\n" +
                               $"Comparisons: {Order.ComparisonCount:N0}\n" +
                               $"Array Size: {size}";

            lblStats.Text = statsText;
        }

        private int[] GenerateRandomArray(int size)
        {
            Random rnd = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(0, 101);
            }
            return arr;
        }
    }
}
