namespace CCNFET
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblTerminate = new System.Windows.Forms.LinkLabel();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.tpHelp = new System.Windows.Forms.TabPage();
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.tpClassification = new System.Windows.Forms.TabPage();
            this.cbRandRandSeed = new System.Windows.Forms.CheckBox();
            this.cbClassifier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbKVal = new System.Windows.Forms.ComboBox();
            this.btnClassify = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudFolds = new System.Windows.Forms.NumericUpDown();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.rbMatlab = new System.Windows.Forms.RadioButton();
            this.rbWeka = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.tpFeatureSelection = new System.Windows.Forms.TabPage();
            this.rtbFeatures = new System.Windows.Forms.RichTextBox();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.rbThreshold = new System.Windows.Forms.RadioButton();
            this.rbFeatures = new System.Windows.Forms.RadioButton();
            this.rbFeatureCount = new System.Windows.Forms.RadioButton();
            this.nudFeatureCount = new System.Windows.Forms.NumericUpDown();
            this.btnApplyFS = new System.Windows.Forms.Button();
            this.lvCorrelations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpMain = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.nudMinSamplePerClass = new System.Windows.Forms.NumericUpDown();
            this.cbMinSamplePerClass = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRescan = new System.Windows.Forms.Button();
            this.nudNofInstanceLimit = new System.Windows.Forms.NumericUpDown();
            this.cbRegex = new System.Windows.Forms.ComboBox();
            this.cbNofInstanceLimit = new System.Windows.Forms.CheckBox();
            this.txtCeNiNFile = new System.Windows.Forms.TextBox();
            this.txtImagesPath = new System.Windows.Forms.TextBox();
            this.btnBrowse3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnVisualize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseDatasetDirectory = new System.Windows.Forms.Button();
            this.cbLayerList = new System.Windows.Forms.ComboBox();
            this.btnBrowseCeNiNFile = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpNormalization = new System.Windows.Forms.TabPage();
            this.rbNormRecalc = new System.Windows.Forms.RadioButton();
            this.rbNormPrecalc = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbNormMinVals = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rtbNormMaxVals = new System.Windows.Forms.RichTextBox();
            this.btnApplyNorm = new System.Windows.Forms.Button();
            this.pnlProgress.SuspendLayout();
            this.tpHelp.SuspendLayout();
            this.tpClassification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolds)).BeginInit();
            this.tpExport.SuspendLayout();
            this.tpFeatureSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatureCount)).BeginInit();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSamplePerClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNofInstanceLimit)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpNormalization.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.Location = new System.Drawing.Point(11, 183);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(811, 211);
            this.txtLog.TabIndex = 2;
            this.txtLog.DoubleClick += new System.EventHandler(this.txtLog_DoubleClick);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProgress.Controls.Add(this.lblProgress);
            this.pnlProgress.Controls.Add(this.lblTerminate);
            this.pnlProgress.Controls.Add(this.pbProgress);
            this.pnlProgress.Location = new System.Drawing.Point(95, 279);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(632, 100);
            this.pnlProgress.TabIndex = 19;
            this.pnlProgress.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProgress.ForeColor = System.Drawing.Color.Green;
            this.lblProgress.Location = new System.Drawing.Point(0, 0);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(632, 52);
            this.lblProgress.TabIndex = 21;
            this.lblProgress.Text = "progress 0%";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTerminate
            // 
            this.lblTerminate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTerminate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblTerminate.Location = new System.Drawing.Point(0, 52);
            this.lblTerminate.Name = "lblTerminate";
            this.lblTerminate.Size = new System.Drawing.Size(632, 25);
            this.lblTerminate.TabIndex = 22;
            this.lblTerminate.TabStop = true;
            this.lblTerminate.Text = "Stop";
            this.lblTerminate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTerminate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTerminate_LinkClicked);
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(0, 77);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(632, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 20;
            this.pbProgress.Value = 5;
            // 
            // tpHelp
            // 
            this.tpHelp.BackColor = System.Drawing.Color.White;
            this.tpHelp.Controls.Add(this.rtbHelp);
            this.tpHelp.Location = new System.Drawing.Point(4, 22);
            this.tpHelp.Name = "tpHelp";
            this.tpHelp.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.tpHelp.Size = new System.Drawing.Size(803, 135);
            this.tpHelp.TabIndex = 4;
            this.tpHelp.Text = "Help";
            // 
            // rtbHelp
            // 
            this.rtbHelp.BackColor = System.Drawing.Color.White;
            this.rtbHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHelp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rtbHelp.Location = new System.Drawing.Point(10, 10);
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.Size = new System.Drawing.Size(783, 115);
            this.rtbHelp.TabIndex = 1;
            this.rtbHelp.Text = resources.GetString("rtbHelp.Text");
            this.rtbHelp.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbHelp_LinkClicked);
            // 
            // tpClassification
            // 
            this.tpClassification.Controls.Add(this.cbRandRandSeed);
            this.tpClassification.Controls.Add(this.cbClassifier);
            this.tpClassification.Controls.Add(this.label4);
            this.tpClassification.Controls.Add(this.cbKVal);
            this.tpClassification.Controls.Add(this.btnClassify);
            this.tpClassification.Controls.Add(this.label6);
            this.tpClassification.Controls.Add(this.label5);
            this.tpClassification.Controls.Add(this.nudFolds);
            this.tpClassification.Location = new System.Drawing.Point(4, 22);
            this.tpClassification.Name = "tpClassification";
            this.tpClassification.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpClassification.Size = new System.Drawing.Size(803, 135);
            this.tpClassification.TabIndex = 3;
            this.tpClassification.Text = "Classify";
            this.tpClassification.UseVisualStyleBackColor = true;
            // 
            // cbRandRandSeed
            // 
            this.cbRandRandSeed.AutoSize = true;
            this.cbRandRandSeed.Checked = true;
            this.cbRandRandSeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRandRandSeed.Location = new System.Drawing.Point(194, 18);
            this.cbRandRandSeed.Name = "cbRandRandSeed";
            this.cbRandRandSeed.Size = new System.Drawing.Size(204, 17);
            this.cbRandRandSeed.TabIndex = 37;
            this.cbRandRandSeed.Text = "Use different random seeds each time";
            this.cbRandRandSeed.UseVisualStyleBackColor = true;
            // 
            // cbClassifier
            // 
            this.cbClassifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClassifier.FormattingEnabled = true;
            this.cbClassifier.Items.AddRange(new object[] {
            "kNN"});
            this.cbClassifier.Location = new System.Drawing.Point(93, 44);
            this.cbClassifier.Name = "cbClassifier";
            this.cbClassifier.Size = new System.Drawing.Size(90, 21);
            this.cbClassifier.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Classifier:";
            // 
            // cbKVal
            // 
            this.cbKVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKVal.FormattingEnabled = true;
            this.cbKVal.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15"});
            this.cbKVal.Location = new System.Drawing.Point(93, 73);
            this.cbKVal.Name = "cbKVal";
            this.cbKVal.Size = new System.Drawing.Size(90, 21);
            this.cbKVal.TabIndex = 34;
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(194, 44);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(66, 50);
            this.btnClassify.TabIndex = 33;
            this.btnClassify.Text = "Classify";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "k value (kNN):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Folds:";
            // 
            // nudFolds
            // 
            this.nudFolds.Location = new System.Drawing.Point(93, 15);
            this.nudFolds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudFolds.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFolds.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFolds.Name = "nudFolds";
            this.nudFolds.Size = new System.Drawing.Size(90, 20);
            this.nudFolds.TabIndex = 27;
            this.nudFolds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tpExport
            // 
            this.tpExport.Controls.Add(this.rbMatlab);
            this.tpExport.Controls.Add(this.rbWeka);
            this.tpExport.Controls.Add(this.btnExport);
            this.tpExport.Location = new System.Drawing.Point(4, 22);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpExport.Size = new System.Drawing.Size(803, 135);
            this.tpExport.TabIndex = 2;
            this.tpExport.Text = "Export";
            this.tpExport.UseVisualStyleBackColor = true;
            // 
            // rbMatlab
            // 
            this.rbMatlab.AutoSize = true;
            this.rbMatlab.Location = new System.Drawing.Point(13, 44);
            this.rbMatlab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMatlab.Name = "rbMatlab";
            this.rbMatlab.Size = new System.Drawing.Size(141, 17);
            this.rbMatlab.TabIndex = 27;
            this.rbMatlab.Text = "Matlab (.M Matlab script)";
            this.rbMatlab.UseVisualStyleBackColor = true;
            // 
            // rbWeka
            // 
            this.rbWeka.AutoSize = true;
            this.rbWeka.Checked = true;
            this.rbWeka.Location = new System.Drawing.Point(13, 15);
            this.rbWeka.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbWeka.Name = "rbWeka";
            this.rbWeka.Size = new System.Drawing.Size(237, 17);
            this.rbWeka.TabIndex = 26;
            this.rbWeka.TabStop = true;
            this.rbWeka.Text = "Weka (.ARFF - Attribute-Relation File Format)";
            this.rbWeka.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(255, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 46);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tpFeatureSelection
            // 
            this.tpFeatureSelection.Controls.Add(this.rtbFeatures);
            this.tpFeatureSelection.Controls.Add(this.nudThreshold);
            this.tpFeatureSelection.Controls.Add(this.rbThreshold);
            this.tpFeatureSelection.Controls.Add(this.rbFeatures);
            this.tpFeatureSelection.Controls.Add(this.rbFeatureCount);
            this.tpFeatureSelection.Controls.Add(this.nudFeatureCount);
            this.tpFeatureSelection.Controls.Add(this.btnApplyFS);
            this.tpFeatureSelection.Location = new System.Drawing.Point(4, 22);
            this.tpFeatureSelection.Name = "tpFeatureSelection";
            this.tpFeatureSelection.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpFeatureSelection.Size = new System.Drawing.Size(803, 135);
            this.tpFeatureSelection.TabIndex = 1;
            this.tpFeatureSelection.Text = "Feature Selection";
            this.tpFeatureSelection.UseVisualStyleBackColor = true;
            // 
            // rtbFeatures
            // 
            this.rtbFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFeatures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbFeatures.DetectUrls = false;
            this.rtbFeatures.Location = new System.Drawing.Point(178, 73);
            this.rtbFeatures.Multiline = false;
            this.rtbFeatures.Name = "rtbFeatures";
            this.rtbFeatures.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbFeatures.Size = new System.Drawing.Size(613, 21);
            this.rtbFeatures.TabIndex = 27;
            this.rtbFeatures.Text = "";
            this.rtbFeatures.WordWrap = false;
            this.rtbFeatures.DoubleClick += new System.EventHandler(this.rtbFeatures_DoubleClick);
            // 
            // nudThreshold
            // 
            this.nudThreshold.DecimalPlaces = 3;
            this.nudThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudThreshold.Location = new System.Drawing.Point(178, 44);
            this.nudThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(90, 20);
            this.nudThreshold.TabIndex = 26;
            // 
            // rbThreshold
            // 
            this.rbThreshold.AutoSize = true;
            this.rbThreshold.Location = new System.Drawing.Point(13, 45);
            this.rbThreshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbThreshold.Name = "rbThreshold";
            this.rbThreshold.Size = new System.Drawing.Size(161, 17);
            this.rbThreshold.TabIndex = 25;
            this.rbThreshold.Text = "Min. absolute corr. threshold:";
            this.rbThreshold.UseVisualStyleBackColor = true;
            // 
            // rbFeatures
            // 
            this.rbFeatures.AutoSize = true;
            this.rbFeatures.Location = new System.Drawing.Point(13, 73);
            this.rbFeatures.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbFeatures.Name = "rbFeatures";
            this.rbFeatures.Size = new System.Drawing.Size(102, 17);
            this.rbFeatures.TabIndex = 23;
            this.rbFeatures.Text = "Certain features:";
            this.rbFeatures.UseVisualStyleBackColor = true;
            // 
            // rbFeatureCount
            // 
            this.rbFeatureCount.AutoSize = true;
            this.rbFeatureCount.Location = new System.Drawing.Point(13, 15);
            this.rbFeatureCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbFeatureCount.Name = "rbFeatureCount";
            this.rbFeatureCount.Size = new System.Drawing.Size(152, 17);
            this.rbFeatureCount.TabIndex = 22;
            this.rbFeatureCount.Text = "Certain number of features:";
            this.rbFeatureCount.UseVisualStyleBackColor = true;
            // 
            // nudFeatureCount
            // 
            this.nudFeatureCount.Location = new System.Drawing.Point(178, 15);
            this.nudFeatureCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudFeatureCount.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudFeatureCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFeatureCount.Name = "nudFeatureCount";
            this.nudFeatureCount.Size = new System.Drawing.Size(90, 20);
            this.nudFeatureCount.TabIndex = 21;
            this.nudFeatureCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnApplyFS
            // 
            this.btnApplyFS.Location = new System.Drawing.Point(278, 15);
            this.btnApplyFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApplyFS.Name = "btnApplyFS";
            this.btnApplyFS.Size = new System.Drawing.Size(66, 49);
            this.btnApplyFS.TabIndex = 19;
            this.btnApplyFS.Text = "Apply";
            this.btnApplyFS.UseVisualStyleBackColor = true;
            this.btnApplyFS.Click += new System.EventHandler(this.btnApplyFS_Click);
            // 
            // lvCorrelations
            // 
            this.lvCorrelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCorrelations.CheckBoxes = true;
            this.lvCorrelations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCorrelations.FullRowSelect = true;
            this.lvCorrelations.HideSelection = false;
            this.lvCorrelations.Location = new System.Drawing.Point(374, 201);
            this.lvCorrelations.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.lvCorrelations.Name = "lvCorrelations";
            this.lvCorrelations.Size = new System.Drawing.Size(200, 79);
            this.lvCorrelations.TabIndex = 20;
            this.lvCorrelations.UseCompatibleStateImageBehavior = false;
            this.lvCorrelations.View = System.Windows.Forms.View.Details;
            this.lvCorrelations.Visible = false;
            this.lvCorrelations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Feature";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Avg. Abs. Corr.";
            this.columnHeader2.Width = 91;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.label10);
            this.tpMain.Controls.Add(this.nudMinSamplePerClass);
            this.tpMain.Controls.Add(this.cbMinSamplePerClass);
            this.tpMain.Controls.Add(this.label7);
            this.tpMain.Controls.Add(this.btnRescan);
            this.tpMain.Controls.Add(this.nudNofInstanceLimit);
            this.tpMain.Controls.Add(this.cbRegex);
            this.tpMain.Controls.Add(this.cbNofInstanceLimit);
            this.tpMain.Controls.Add(this.txtCeNiNFile);
            this.tpMain.Controls.Add(this.txtImagesPath);
            this.tpMain.Controls.Add(this.btnBrowse3);
            this.tpMain.Controls.Add(this.label2);
            this.tpMain.Controls.Add(this.label1);
            this.tpMain.Controls.Add(this.btnExtract);
            this.tpMain.Controls.Add(this.btnVisualize);
            this.tpMain.Controls.Add(this.label3);
            this.tpMain.Controls.Add(this.btnBrowseDatasetDirectory);
            this.tpMain.Controls.Add(this.cbLayerList);
            this.tpMain.Controls.Add(this.btnBrowseCeNiNFile);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpMain.Size = new System.Drawing.Size(802, 135);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Feature Extraction";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(338, 106);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Instances:";
            // 
            // nudMinSamplePerClass
            // 
            this.nudMinSamplePerClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinSamplePerClass.Enabled = false;
            this.nudMinSamplePerClass.Location = new System.Drawing.Point(443, 104);
            this.nudMinSamplePerClass.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMinSamplePerClass.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMinSamplePerClass.Name = "nudMinSamplePerClass";
            this.nudMinSamplePerClass.Size = new System.Drawing.Size(52, 20);
            this.nudMinSamplePerClass.TabIndex = 24;
            this.nudMinSamplePerClass.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbMinSamplePerClass
            // 
            this.cbMinSamplePerClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMinSamplePerClass.AutoSize = true;
            this.cbMinSamplePerClass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbMinSamplePerClass.Location = new System.Drawing.Point(394, 106);
            this.cbMinSamplePerClass.Name = "cbMinSamplePerClass";
            this.cbMinSamplePerClass.Size = new System.Drawing.Size(46, 17);
            this.cbMinSamplePerClass.TabIndex = 25;
            this.cbMinSamplePerClass.Text = "Min:";
            this.cbMinSamplePerClass.UseVisualStyleBackColor = true;
            this.cbMinSamplePerClass.CheckedChanged += new System.EventHandler(this.cbMinSamplePerClass_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Class name pattern:";
            // 
            // btnRescan
            // 
            this.btnRescan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRescan.Location = new System.Drawing.Point(613, 102);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(66, 23);
            this.btnRescan.TabIndex = 21;
            this.btnRescan.Text = "Rescan";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // nudNofInstanceLimit
            // 
            this.nudNofInstanceLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNofInstanceLimit.Enabled = false;
            this.nudNofInstanceLimit.Location = new System.Drawing.Point(555, 104);
            this.nudNofInstanceLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNofInstanceLimit.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNofInstanceLimit.Name = "nudNofInstanceLimit";
            this.nudNofInstanceLimit.Size = new System.Drawing.Size(52, 20);
            this.nudNofInstanceLimit.TabIndex = 19;
            this.nudNofInstanceLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cbRegex
            // 
            this.cbRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRegex.BackColor = System.Drawing.Color.White;
            this.cbRegex.FormattingEnabled = true;
            this.cbRegex.Items.AddRange(new object[] {
            "...\\{CLASSNAME}\\randomfilename.ext",
            "...\\{CLASSNAME}_001.ext"});
            this.cbRegex.Location = new System.Drawing.Point(117, 103);
            this.cbRegex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRegex.Name = "cbRegex";
            this.cbRegex.Size = new System.Drawing.Size(214, 21);
            this.cbRegex.TabIndex = 22;
            // 
            // cbNofInstanceLimit
            // 
            this.cbNofInstanceLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNofInstanceLimit.AutoSize = true;
            this.cbNofInstanceLimit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbNofInstanceLimit.Location = new System.Drawing.Point(502, 106);
            this.cbNofInstanceLimit.Name = "cbNofInstanceLimit";
            this.cbNofInstanceLimit.Size = new System.Drawing.Size(49, 17);
            this.cbNofInstanceLimit.TabIndex = 20;
            this.cbNofInstanceLimit.Text = "Max:";
            this.cbNofInstanceLimit.UseVisualStyleBackColor = true;
            this.cbNofInstanceLimit.CheckedChanged += new System.EventHandler(this.cbNofInstanceLimit_CheckedChanged);
            // 
            // txtCeNiNFile
            // 
            this.txtCeNiNFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCeNiNFile.BackColor = System.Drawing.Color.White;
            this.txtCeNiNFile.Location = new System.Drawing.Point(117, 15);
            this.txtCeNiNFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCeNiNFile.Name = "txtCeNiNFile";
            this.txtCeNiNFile.ReadOnly = true;
            this.txtCeNiNFile.Size = new System.Drawing.Size(491, 20);
            this.txtCeNiNFile.TabIndex = 13;
            // 
            // txtImagesPath
            // 
            this.txtImagesPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagesPath.BackColor = System.Drawing.Color.White;
            this.txtImagesPath.Location = new System.Drawing.Point(117, 74);
            this.txtImagesPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtImagesPath.Name = "txtImagesPath";
            this.txtImagesPath.ReadOnly = true;
            this.txtImagesPath.Size = new System.Drawing.Size(491, 20);
            this.txtImagesPath.TabIndex = 14;
            // 
            // btnBrowse3
            // 
            this.btnBrowse3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse3.Location = new System.Drawing.Point(684, 13);
            this.btnBrowse3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowse3.Name = "btnBrowse3";
            this.btnBrowse3.Size = new System.Drawing.Size(105, 23);
            this.btnBrowse3.TabIndex = 12;
            this.btnBrowse3.Text = "Single Image Test";
            this.btnBrowse3.UseVisualStyleBackColor = true;
            this.btnBrowse3.Click += new System.EventHandler(this.btnBrowse3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Pretrained CNN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Dataset (Images):";
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtract.Location = new System.Drawing.Point(684, 42);
            this.btnExtract.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(105, 81);
            this.btnExtract.TabIndex = 9;
            this.btnExtract.Text = "Extract\r\nFeaures";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnVisualize
            // 
            this.btnVisualize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualize.Location = new System.Drawing.Point(613, 43);
            this.btnVisualize.Name = "btnVisualize";
            this.btnVisualize.Size = new System.Drawing.Size(66, 23);
            this.btnVisualize.TabIndex = 11;
            this.btnVisualize.Text = "Visualize";
            this.btnVisualize.UseVisualStyleBackColor = true;
            this.btnVisualize.Click += new System.EventHandler(this.btnVisualize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Extraction layer:";
            // 
            // btnBrowseDatasetDirectory
            // 
            this.btnBrowseDatasetDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDatasetDirectory.Location = new System.Drawing.Point(613, 72);
            this.btnBrowseDatasetDirectory.Name = "btnBrowseDatasetDirectory";
            this.btnBrowseDatasetDirectory.Size = new System.Drawing.Size(66, 23);
            this.btnBrowseDatasetDirectory.TabIndex = 5;
            this.btnBrowseDatasetDirectory.Text = "Browse...";
            this.btnBrowseDatasetDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDatasetDirectory.Click += new System.EventHandler(this.btnBrowseDatasetDirectory_Click);
            // 
            // cbLayerList
            // 
            this.cbLayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLayerList.BackColor = System.Drawing.Color.White;
            this.cbLayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerList.FormattingEnabled = true;
            this.cbLayerList.Location = new System.Drawing.Point(117, 44);
            this.cbLayerList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbLayerList.Name = "cbLayerList";
            this.cbLayerList.Size = new System.Drawing.Size(491, 21);
            this.cbLayerList.TabIndex = 17;
            // 
            // btnBrowseCeNiNFile
            // 
            this.btnBrowseCeNiNFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseCeNiNFile.Location = new System.Drawing.Point(613, 13);
            this.btnBrowseCeNiNFile.Name = "btnBrowseCeNiNFile";
            this.btnBrowseCeNiNFile.Size = new System.Drawing.Size(66, 23);
            this.btnBrowseCeNiNFile.TabIndex = 0;
            this.btnBrowseCeNiNFile.Text = "Browse...";
            this.btnBrowseCeNiNFile.UseVisualStyleBackColor = true;
            this.btnBrowseCeNiNFile.Click += new System.EventHandler(this.btnBrowseCeNiNFile_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpNormalization);
            this.tabControl.Controls.Add(this.tpFeatureSelection);
            this.tabControl.Controls.Add(this.tpExport);
            this.tabControl.Controls.Add(this.tpClassification);
            this.tabControl.Controls.Add(this.tpHelp);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(810, 161);
            this.tabControl.TabIndex = 11;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tpNormalization
            // 
            this.tpNormalization.Controls.Add(this.rbNormRecalc);
            this.tpNormalization.Controls.Add(this.rbNormPrecalc);
            this.tpNormalization.Controls.Add(this.label9);
            this.tpNormalization.Controls.Add(this.rtbNormMinVals);
            this.tpNormalization.Controls.Add(this.label8);
            this.tpNormalization.Controls.Add(this.rtbNormMaxVals);
            this.tpNormalization.Controls.Add(this.btnApplyNorm);
            this.tpNormalization.Location = new System.Drawing.Point(4, 22);
            this.tpNormalization.Name = "tpNormalization";
            this.tpNormalization.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tpNormalization.Size = new System.Drawing.Size(803, 135);
            this.tpNormalization.TabIndex = 5;
            this.tpNormalization.Text = "Feature Normalization";
            this.tpNormalization.UseVisualStyleBackColor = true;
            // 
            // rbNormRecalc
            // 
            this.rbNormRecalc.AutoSize = true;
            this.rbNormRecalc.Checked = true;
            this.rbNormRecalc.Location = new System.Drawing.Point(15, 14);
            this.rbNormRecalc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbNormRecalc.Name = "rbNormRecalc";
            this.rbNormRecalc.Size = new System.Drawing.Size(178, 17);
            this.rbNormRecalc.TabIndex = 34;
            this.rbNormRecalc.TabStop = true;
            this.rbNormRecalc.Text = "Recalculate min and max values";
            this.rbNormRecalc.UseVisualStyleBackColor = true;
            // 
            // rbNormPrecalc
            // 
            this.rbNormPrecalc.AutoSize = true;
            this.rbNormPrecalc.Location = new System.Drawing.Point(15, 40);
            this.rbNormPrecalc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbNormPrecalc.Name = "rbNormPrecalc";
            this.rbNormPrecalc.Size = new System.Drawing.Size(207, 17);
            this.rbNormPrecalc.TabIndex = 33;
            this.rbNormPrecalc.Text = "Use precalculated min and max values";
            this.rbNormPrecalc.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Min values:";
            // 
            // rtbNormMinVals
            // 
            this.rtbNormMinVals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNormMinVals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbNormMinVals.DetectUrls = false;
            this.rtbNormMinVals.Location = new System.Drawing.Point(82, 67);
            this.rtbNormMinVals.Multiline = false;
            this.rtbNormMinVals.Name = "rtbNormMinVals";
            this.rtbNormMinVals.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbNormMinVals.Size = new System.Drawing.Size(708, 21);
            this.rtbNormMinVals.TabIndex = 31;
            this.rtbNormMinVals.Text = "";
            this.rtbNormMinVals.WordWrap = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Max values:";
            // 
            // rtbNormMaxVals
            // 
            this.rtbNormMaxVals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNormMaxVals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbNormMaxVals.DetectUrls = false;
            this.rtbNormMaxVals.Location = new System.Drawing.Point(82, 94);
            this.rtbNormMaxVals.Multiline = false;
            this.rtbNormMaxVals.Name = "rtbNormMaxVals";
            this.rtbNormMaxVals.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbNormMaxVals.Size = new System.Drawing.Size(708, 21);
            this.rtbNormMaxVals.TabIndex = 29;
            this.rtbNormMaxVals.Text = "";
            this.rtbNormMaxVals.WordWrap = false;
            // 
            // btnApplyNorm
            // 
            this.btnApplyNorm.Location = new System.Drawing.Point(230, 14);
            this.btnApplyNorm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApplyNorm.Name = "btnApplyNorm";
            this.btnApplyNorm.Size = new System.Drawing.Size(66, 43);
            this.btnApplyNorm.TabIndex = 28;
            this.btnApplyNorm.Text = "Apply";
            this.btnApplyNorm.UseVisualStyleBackColor = true;
            this.btnApplyNorm.Click += new System.EventHandler(this.btnApplyNorm_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 406);
            this.Controls.Add(this.lvCorrelations);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 445);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CNN Feature Extraction Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlProgress.ResumeLayout(false);
            this.tpHelp.ResumeLayout(false);
            this.tpClassification.ResumeLayout(false);
            this.tpClassification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolds)).EndInit();
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.tpFeatureSelection.ResumeLayout(false);
            this.tpFeatureSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatureCount)).EndInit();
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSamplePerClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNofInstanceLimit)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tpNormalization.ResumeLayout(false);
            this.tpNormalization.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TabPage tpHelp;
        private System.Windows.Forms.TabPage tpClassification;
        private System.Windows.Forms.ComboBox cbClassifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKVal;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudFolds;
        private System.Windows.Forms.TabPage tpExport;
        private System.Windows.Forms.RadioButton rbMatlab;
        private System.Windows.Forms.RadioButton rbWeka;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tpFeatureSelection;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.RadioButton rbThreshold;
        private System.Windows.Forms.RadioButton rbFeatures;
        private System.Windows.Forms.RadioButton rbFeatureCount;
        private System.Windows.Forms.NumericUpDown nudFeatureCount;
        private System.Windows.Forms.ListView lvCorrelations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnApplyFS;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TextBox txtCeNiNFile;
        private System.Windows.Forms.TextBox txtImagesPath;
        private System.Windows.Forms.Button btnBrowse3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnVisualize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseDatasetDirectory;
        private System.Windows.Forms.ComboBox cbLayerList;
        private System.Windows.Forms.Button btnBrowseCeNiNFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.CheckBox cbRandRandSeed;
        private System.Windows.Forms.LinkLabel lblTerminate;
        private System.Windows.Forms.RichTextBox rtbFeatures;
        private System.Windows.Forms.RichTextBox rtbHelp;
        private System.Windows.Forms.NumericUpDown nudNofInstanceLimit;
        private System.Windows.Forms.CheckBox cbNofInstanceLimit;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRegex;
        private System.Windows.Forms.TabPage tpNormalization;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbNormMinVals;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rtbNormMaxVals;
        private System.Windows.Forms.Button btnApplyNorm;
        private System.Windows.Forms.RadioButton rbNormRecalc;
        private System.Windows.Forms.RadioButton rbNormPrecalc;
        private System.Windows.Forms.NumericUpDown nudMinSamplePerClass;
        private System.Windows.Forms.CheckBox cbMinSamplePerClass;
        private System.Windows.Forms.Label label10;
    }
}

