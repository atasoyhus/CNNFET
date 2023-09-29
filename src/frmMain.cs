using CeNiN;
using CNNFET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *--------------------------------------------------------------------------
 * CNNFET > frmMain.cs
 *--------------------------------------------------------------------------
 * CNNFET; Convolutional Neural Network Feature Extraction Tools
 * Huseyin Atasoy
 * huseyin [at] atasoyweb.net
 * May 2022
 *--------------------------------------------------------------------------
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *--------------------------------------------------------------------------
 */

namespace CCNFET
{
    public partial class frmMain : Form
    {
        const int FORM_PADDING = 11;

        DateTime dateTime;
        CNN cnn;
        int lastConvLayerInd = -1;
        ConvOutputExtractor convOutputExtractor;
        Dataset dataset;
        float[][] featureSet;
        Random random;

        private string[] classNamePatterns = new string[]
        {
            @".*\\(.*?)\\.*?\..*?$",
            @".*\\(.*?)_[0-9]{1,}\..*?"
        };

        public unsafe frmMain()
        {
            random = new Random(DateTime.Now.Millisecond);
            InitializeComponent();
            foreach (Control c in tabControl.TabPages)
            {
                if (c != tpMain && c != tpHelp)
                    c.Enabled = false;
            }

            cbKVal.SelectedIndex = 0;
            cbClassifier.SelectedIndex = 0;

            pnlProgress.Top = tabControl.Top;
            pnlProgress.Left = tabControl.Left;
            pnlProgress.Width = tabControl.Width;
            pnlProgress.Height = tabControl.Height;

            lvCorrelations.Left = ClientSize.Width - lvCorrelations.Width - FORM_PADDING;
            lvCorrelations.Top = FORM_PADDING;
            lvCorrelations.Height = ClientSize.Height - FORM_PADDING * 2;

            makeDoubleBuffered(pnlProgress);

            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            Text += " v" + v.Major + "." + v.Minor;
        }

        public void makeDoubleBuffered(Control ctrl)
        {
            ctrl.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(ctrl, true, null);
        }

        public string round(float f, int decimals)
        {
            return Math.Round(f, decimals).ToString("0.######").Replace(',', '.');
        }

        void enableTabControl()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => enableTabControl()));
                return;
            }
            tabControl.Enabled = true;
        }

        private string leftPad(string str, int len)
        {
            var i = str.Length;
            if (i >= len)
                return str;
            else
                return new string(' ', len - i) + str;
        }

        private DateTime tic()
        {
            dateTime = DateTime.Now;
            return dateTime;
        }
        private double toc()
        {
            return Math.Round((DateTime.Now - dateTime).TotalSeconds, 3);
        }

        private void appendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => appendText(text)));
                return;
            }

            txtLog.AppendText(text);
        }

        private void appendLine(string text, string prefix = "-->  ")
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => appendLine(text, prefix)));
                return;
            }

            txtLog.AppendText("\r\n" + prefix + text);
        }

        bool breakLoops = false;
        void showProgressPanel(bool noProgress = false)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => showProgressPanel()));
                return;
            }
            tabControl.Enabled = false;

            lblTerminate.Text = "Stop";
            breakLoops = false;
            pbProgress.Value = 0;
            pbProgress.Style = noProgress ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
            lblProgress.Text = noProgress ? "Please wait..." : "... 0%";
            pnlProgress.Visible = true;
        }

        float prevPercent, prevPercent2;
        private void progress(int i, int n)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progress(i, n)));
                return;
            }

            if (i == 0)
            {
                prevPercent = -1;
                prevPercent2 = -1;
            }

            int j = i + 1;
            float percent = j * 100f / n;
            float diff = percent - prevPercent;
            float diff2 = percent - prevPercent2;

            if (diff > 0.1)
            {
                string str = round(percent, 3) + "%" + "\r\n\r\n" + j + " / " + n;
                pbProgress.Value = (int)percent;
                lblProgress.Text = str;
                prevPercent = percent;
                Application.DoEvents();
            }
        }

        private void finishedIn()
        {
            if (breakLoops)
                appendLine("Interrupted by the user after " + round((float)toc(), 3) + " seconds");
            else
                appendLine("Finished in " + round((float)toc(), 3) + " seconds");
            Invoke(new Action(() => pnlProgress.Visible = false));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CBLAS.detectCBLAS();
            txtLog.Text = "-->  Checking BLAS support...";
            Application.DoEvents();
            appendLine("OpenBLAS: " + (CBLAS.openbAvailable ? "" : "not ") + "available", "");
            appendLine("Intel MKL: " + (CBLAS.imklAvailable ? "" : "not ") + "available", "");
            if (!CBLAS.openbAvailable && !CBLAS.imklAvailable)
                appendLine("The application is written to be able to run standalone. But you can improve the performance drastically, using a BLAS library. Please visit GIT repository of this application for more info.", "");
            appendLine("Ready");
            cbRegex.SelectedIndex = 0;
        }

        private void txtLog_DoubleClick(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
                txtLog.Clear();
        }

        private void btnBrowseCeNiNFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "CeNiN file|*.cenin";
            if (opf.ShowDialog() != DialogResult.OK) return;

            txtCeNiNFile.Text = opf.FileName;

            appendLine("Loading CNN file...");

            tic();
            tabControl.Enabled = false;

            new Thread(() =>
            {
                cnn = new CNN(opf.FileName);
                appendLine("Total number of weights: " + cnn.totalWeightCount, "");
                appendLine("Total number of biases: " + cnn.totalBiasCount, "");
                appendLine(cnn.layerCount + "+2 layers were loaded in " + toc() + " seconds");

                Invoke(new Action(() => cbLayerList.Items.Clear()));
                int i = 1;
                lastConvLayerInd = -1;
                foreach (Layer layer in cnn.layers)
                {
                    string str = layer.type;
                    if (!(layer is Input || layer is Output))
                    {
                        str = "#" + i + "   " + str;
                        int[] dims = (int[])layer.InputTensorDims.Clone();
                        if (layer.pad != null)
                        {
                            dims[0] -= layer.pad[0] + layer.pad[1];
                            dims[1] -= layer.pad[2] + layer.pad[3];
                        }
                        str += "   ( input:[" + string.Join(", ", dims) + "]";
                        i++;
                    }
                    if (layer is Conv)
                    {
                        int[] dims = ((Conv)layer).weights.Dimensions;
                        str += " filters:[" + string.Join(", ", dims) + "]";
                        lastConvLayerInd = i - 1;
                    }
                    str += " )";
                    Invoke(new Action(() => cbLayerList.Items.Add(str)));
                }
                if (lastConvLayerInd != -1)
                    Invoke(new Action(() => cbLayerList.SelectedIndex = lastConvLayerInd));

                convOutputExtractor = new ConvOutputExtractor(cnn);

                finishedIn();
                enableTabControl();

            }).Start();
        }

        private void scanFiles()
        {
            string regexPattern = cbRegex.Text;
            if (cbRegex.SelectedIndex >= 0)
                regexPattern = classNamePatterns[cbRegex.SelectedIndex];
            else
                regexPattern = cbRegex.Text;
            try
            {
                Regex r = new Regex(regexPattern, RegexOptions.Singleline);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "The regex value written for the class name pattern is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedPath = txtImagesPath.Text;

            appendLine("Scanning image files...");

            tic();
            tabControl.Enabled = false;
            int maxNumOfInsPerClass = cbNofInstanceLimit.Checked ? (int)nudNofInstanceLimit.Value : 0;
            int minNumOfInsPerClass = cbMinSamplePerClass.Checked ? (int)nudMinSamplePerClass.Value : 0;

            new Thread(() =>
            {
                dataset = new Dataset(selectedPath, regexPattern, minNumOfInsPerClass, maxNumOfInsPerClass);

                if (minNumOfInsPerClass > 0)
                    appendLine("Minimum number of instances per class: " + minNumOfInsPerClass, "");
                if (maxNumOfInsPerClass > 0)
                    appendLine("Maximum number of instances per class: " + maxNumOfInsPerClass, "");
                appendLine("Number of classes: " + dataset.distinctClasses.Length, "");
                appendLine("Number of images: " + dataset.count, "");

                int maxStrLen = 0;
                for (int i = 0; i < dataset.distinctClassCount; i++)
                {
                    int len = dataset.distinctClasses[i].Length;
                    if (maxStrLen < len)
                        maxStrLen = len;
                }

                for (int i = 0; i < dataset.distinctClassCount; i++)
                    appendLine("  " + leftPad(dataset.distinctClasses[i], maxStrLen) + ": " + dataset.numOfInsPerClass[i], "");

                if (dataset.count < 2 || dataset.distinctClassCount < 2)
                {
                    appendLine("Both the number of images and the number of classes found in the directory should be greater than 1.");
                    dataset = null;
                }

                finishedIn();
                enableTabControl();

            }).Start();
        }

        private void btnBrowseDatasetDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK) return;

            txtImagesPath.Text = fbd.SelectedPath;

            scanFiles();
        }

        bool isConvSelected()
        {
            string type = cbLayerList.Text;
            if (type.Contains("#"))
                type = type.Substring(type.IndexOf(' ') + 1).Trim();
            bool b = type.StartsWith("Conv");
            if(!b)
                MessageBox.Show(this, "Please select a convolution layer", "Invalid Layer Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return b;
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            if (isConvSelected())
                (new FilterVisualizer()).visualize(cnn, cbLayerList.SelectedIndex, 0);
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (!isConvSelected())
                return;
            if (dataset is null)
            {
                MessageBox.Show(this, "Please select a dataset directory.", "Empty Dataset", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int layerIndex = cbLayerList.SelectedIndex;

            selectedFeatureIndexes = null;
            lvCorrelations.Items.Clear();

            appendLine("Extracting...");
            showProgressPanel();

            tic();

            int n = dataset.files.Length;
            featureSet = new float[n][];

            new Thread(() =>
            {
                ParallelOptions po = new ParallelOptions();
                po.MaxDegreeOfParallelism = Environment.ProcessorCount;
                Mutex m = new Mutex();
                int j = 0;
                Parallel.For(0, dataset.count, po, (int i, ParallelLoopState state) =>
                {
                    featureSet[i] = convOutputExtractor.extract(dataset.files[i], layerIndex);
                    m.WaitOne();
                    progress(j, n);
                    j++;
                    m.ReleaseMutex();
                    if (breakLoops)
                    {
                        featureSet = null;
                        state.Break();
                    }
                });
                if (!breakLoops && featureSet != null && featureSet.Length > 0)
                    appendLine("Number of features extracted per each instance: " + featureSet[0].Length, "");
                finishedIn();
                enableTabControl();
            }).Start();
        }

        private bool checkFeatureSet()
        {
            if (featureSet is null)
            {
                MessageBox.Show(this, "There is no extracted feature set yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void export(bool arff)
        {
            if (!checkFeatureSet())
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = arff ? "ARFF file|*.arff" : "Matlab script|*.m";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            appendLine("Exporting feature vectors...");
            showProgressPanel();

            tic();
            if (arff)
            {
                ARFFFileWriter arffCreator = new ARFFFileWriter(sfd.FileName, "CNNFET" + random.Next(10000, 99999));
                arffCreator.writeAttributeDefinitions(featureSet[0].Length, dataset.distinctClasses, selectedFeatureIndexes);

                int n = featureSet.Length;
                for (int i = 0; i < n; i++)
                {
                    arffCreator.writeInstance(featureSet[i], dataset.classes[i], selectedFeatureIndexes);
                    progress(i, n);
                    if (breakLoops)
                        break;
                }
                arffCreator.closeFile();
            }
            else
            {
                MFileWriter mFileCreator = new MFileWriter(sfd.FileName, "cnnfet" + random.Next(10000, 99999));
                mFileCreator.writeDefinitions(dataset.distinctClasses);

                int n = featureSet.Length;
                for (int i = 0; i < n; i++)
                {
                    mFileCreator.writeInstance(featureSet[i], dataset.classIndexes[i], selectedFeatureIndexes);
                    progress(i, n);
                    if (breakLoops)
                        break;
                }
                mFileCreator.closeFile();
            }

            finishedIn();
            enableTabControl();
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            if (cnn is null)
            {
                MessageBox.Show(this, "Please load a CNN file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files|*.bmp;*.jpeg;*.jpg;*.png";
            if (opf.ShowDialog() != DialogResult.OK) return;
            Bitmap b = new Bitmap(opf.FileName);
            cnn.inputLayer.setInput(b, Input.ResizingMethod.ZeroPad);
            tic();
            Layer currentLayer = cnn.inputLayer;
            int i = 0;
            while (currentLayer.nextLayer != null)
            {
                if (i == 0)
                    appendLine("Passing the image through the layers...");
                else
                    appendLine("Layer " + i + " (" + currentLayer.type + ") input:[" + string.Join(",", currentLayer.InputTensorDims) + "]" + (currentLayer is Conv ? " width,height,channels,filters:[" + string.Join(",", ((Conv)currentLayer).weights.Dimensions) + "]" + " biases:[" + string.Join(",", ((Conv)currentLayer).biases.Dimensions) + "]" : ""));

                Application.DoEvents();

                currentLayer.feedNext();
                currentLayer = currentLayer.nextLayer;
                i += 1;
            }

            Output outputLayer = (Output)currentLayer;
            finishedIn();

            string decision = outputLayer.getDecision();
            string hLine = new string('-', 50);
            appendLine(hLine, "");
            appendLine("THE HIGHEST 3 PROBABILITIES: ", "");
            appendLine(hLine, "");
            for (i = 0; i < 3; i++)
                appendLine(" #" + (i + 1) + "   " + outputLayer.sortedClasses[i] + " (" + round(outputLayer.probabilities[i], 3) + ")", "");
            appendLine(hLine, "");
            appendLine("DECISION: " + decision);
            appendLine(hLine, "");
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            int foldCount = (int)nudFolds.Value;
            int kNNk = int.Parse(cbKVal.SelectedItem.ToString());
            appendLine("Performing classification (" + foldCount + "-fold cross-validation) using " 
                + (selectedFeatureIndexes != null ? selectedFeatureIndexes.Count : featureSet[0].Length) + " features on " 
                + featureSet.Length + " instances...\r\n");
            showProgressPanel();
            tic();
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;
            new Thread(() =>
            {
                int[][] outputs = new int[dataset.count][];
                for (int i = 0; i < dataset.count; i++)
                    outputs[i] = new int[1] { dataset.classIndexes[i] };

                KFoldProvider<float, int> kfp;
                if (selectedFeatureIndexes != null)
                {
                    appendLine("Preparing feature subset. This may take a while...", "");
                    int numberOfInstances = featureSet.Length;
                    int numberOfFeatures = featureSet[0].Length;
                    float[][] featureSubset = new float[numberOfInstances][];
                    for (int i = 0; i < numberOfInstances; i++)
                        featureSubset[i] = new float[selectedFeatureIndexes.Count];
                    int k = 0;
                    for (int j = 0; j < numberOfFeatures; j++)
                    {
                        if (!selectedFeatureIndexes.Contains(j))
                            continue;
                        for (int i = 0; i < numberOfInstances; i++)
                            featureSubset[i][k] = featureSet[i][j];
                        k++;
                    }
                    appendLine("The subset is ready", "");

                    kfp = new KFoldProvider<float, int>(featureSubset, outputs, foldCount, cbRandRandSeed.Checked ? int.MinValue : 1);
                }
                else
                    kfp = new KFoldProvider<float, int>(featureSet, outputs, foldCount, cbRandRandSeed.Checked ? int.MinValue : 1);

                int[,] confusionMatrix = new int[dataset.distinctClassCount, dataset.distinctClassCount];
                Array.Clear(confusionMatrix, 0, dataset.distinctClassCount * dataset.distinctClassCount);

                int total = 0;
                int tp_tn = 0;
                for (int j = 0; j < kfp.k; j++)
                {
                    float[][] trainData = kfp.trainData[j];
                    int[][] trainOutputs = kfp.trainOutputs[j];

                    float[][] testData = kfp.testData[j];
                    int[][] testOutputs = kfp.testOutputs[j];

                    appendLine("Fold " + (j + 1) + ": " + trainData.Length + " training, " + testData.Length + " test instances", "");

                    //int[] labels = new int[testOutputs.Length];
                    int[] labels = trainOutputs.Select<int[], int>(innerArr => innerArr[0]).ToArray<int>();

                    KNNClassifier knnc = new KNNClassifier(trainData, labels);

                    Mutex m = new Mutex();
                    Parallel.For(0, testData.Length, po, (int i, ParallelLoopState state) =>
                    {
                        int predictedClassInd = knnc.classify(testData[i], kNNk);
                        int realClassInd = testOutputs[i][0];

                        confusionMatrix[realClassInd, predictedClassInd]++;

                        m.WaitOne();
                        if (predictedClassInd == realClassInd)
                            tp_tn++;
                        progress(total, dataset.count);
                        total++;
                        m.ReleaseMutex();

                        if (breakLoops)
                            state.Break();
                    });
                    if (breakLoops)
                        break;
                }

                if (!breakLoops)
                {
                    if (dataset.distinctClassCount < 27)
                    {
                        string chars = "";
                        for (char c = 'a'; c <= 'z'; c++)
                            chars += c;

                        int maxNumberStrLen = dataset.count.ToString().Length;

                        string line = "\r\nCONFUSION MATRIX\r\n";
                        for (int i = 0; i < dataset.distinctClassCount; i++)
                            line += leftPad(chars.Substring(i, 1), maxNumberStrLen) + " ";
                        line += "<-- classified as\r\n";
                        for (int i = 0; i < dataset.distinctClassCount; i++)
                        {
                            for (int j = 0; j < dataset.distinctClassCount; j++)
                            {
                                line += leftPad(confusionMatrix[i, j].ToString(), maxNumberStrLen) + " ";
                            }
                            line += "| " + chars.Substring(i, 1) + " = " + dataset.distinctClasses[i] + "\r\n";
                        }
                        appendLine(line, "");
                    }

                    appendLine("Accuracy: " + round(100f * (float)tp_tn / total, 6) + "%" + " [" + tp_tn + " / " + total + "]\r\n", "");
                }
                finishedIn();
                enableTabControl();
            }).Start();

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control selectedTab = tabControl.SelectedTab;
            if (selectedTab == tpFeatureSelection)
            {
                lvCorrelations.Visible = true;
                tabControl.Width = ClientSize.Width - lvCorrelations.Width - 3 * FORM_PADDING;
                txtLog.Width = ClientSize.Width - lvCorrelations.Width - 3 * FORM_PADDING;
                pnlProgress.Width = tabControl.Width;
                pnlProgress.Height = tabControl.Height;

                if (!checkFeatureSet())
                {
                    selectedTab.Enabled = false;
                    return;
                }
                else
                    selectedTab.Enabled = true;

                if (lvCorrelations.Items.Count < 1)
                {
                    tic();
                    appendLine("Calculating correlations...");
                    showProgressPanel();

                    int instanceCount = featureSet.Length;
                    int attributeCount = featureSet[0].Length;

                    float[] correlations = new float[attributeCount];

                    float[] column = new float[instanceCount];
                    for (int j = 0; j < attributeCount; j++)
                    {
                        for (int i = 0; i < instanceCount; i++)
                            column[i] = featureSet[i][j];
                        correlations[j] = PearsonCorrelation.weightedAvgAbsCorrelation(column, dataset.classIndexes, dataset.distinctClassCount);
                        progress(j, attributeCount);
                        if (breakLoops)
                            break;
                    }
                    if (breakLoops)
                    {
                        selectedFeatureIndexes = null;
                        lvCorrelations.Items.Clear();
                        tpFeatureSelection.Enabled = false;
                    }
                    else
                    {
                        prepareInterface(correlations);
                        if (attributeCount > 500)
                            appendLine("Since there are so many features, only the first 500 features are shown.", "");
                    }
                    finishedIn();
                    enableTabControl();
                }
            }
            else
            {
                lvCorrelations.Visible = false;
                tabControl.Width = ClientSize.Width - FORM_PADDING * 2;
                txtLog.Width = ClientSize.Width - FORM_PADDING * 2;
                pnlProgress.Width = tabControl.Width;
                pnlProgress.Height = tabControl.Height;

                if (selectedTab == tpExport || selectedTab == tpClassification || selectedTab == tpNormalization)
                {
                    if (!checkFeatureSet())
                    {
                        selectedTab.Enabled = false;
                        return;
                    }
                    else
                        selectedTab.Enabled = true;

                    if (selectedTab == tpClassification)
                    {
                        int max = dataset.count;
                        nudFolds.Maximum = max;
                        nudFolds.Value = (dataset.count >= 10 ? 10 : max);
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            export(rbWeka.Checked);
        }

        private void lblTerminate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (breakLoops)
                return;
            if (MessageBox.Show(this, "The operations will be terminated before being completed. Do you want to interrupt?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            breakLoops = true;
            lblTerminate.Text = "Interrupting...";
        }

        private void cbNofInstanceLimit_CheckedChanged(object sender, EventArgs e)
        {
            nudNofInstanceLimit.Enabled = cbNofInstanceLimit.Checked;
        }

        private void cbMinSamplePerClass_CheckedChanged(object sender, EventArgs e)
        {
            nudMinSamplePerClass.Enabled = cbMinSamplePerClass.Checked;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void rtbHelp_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        #region FeatureSelection

        private int[] sortedIndexes;
        private int[] sortedIndexes_invMapping;
        private float[] sortedAvgAbsCorrelations;
        private List<int> selectedFeatureIndexes;
        private int featureCount;

        void prepareInterface(float[] avgAbsCorrelations)
        {
            featureCount = avgAbsCorrelations.Length;

            sortedAvgAbsCorrelations = new float[featureCount];
            sortedIndexes = new int[featureCount];
            for (int i = 0; i < featureCount; i++)
            {
                sortedAvgAbsCorrelations[i] = avgAbsCorrelations[i];
                sortedIndexes[i] = i;
            }
            Array.Sort(sortedAvgAbsCorrelations, sortedIndexes);
            Array.Reverse(sortedIndexes);
            Array.Reverse(sortedAvgAbsCorrelations);

            sortedIndexes_invMapping = new int[featureCount];

            int featuresToShow = featureCount;
            if (featuresToShow > 500)
                featuresToShow = 500;
            lvCorrelations.BeginUpdate();
            for (int i = 0; i < featureCount; i++)
            {
                if (i < featuresToShow)
                {
                    int j = sortedIndexes[i];
                    ListViewItem lvi = lvCorrelations.Items.Add("Feature" + j);
                    lvi.SubItems.Add(round(avgAbsCorrelations[j], 6));
                }

                sortedIndexes_invMapping[sortedIndexes[i]] = i;
            }
            lvCorrelations.Columns[0].Width = -2;
            lvCorrelations.Columns[1].Width = -2;
            lvCorrelations.EndUpdate();

            nudFeatureCount.Maximum = featureCount;
            nudFeatureCount.Value = featureCount;
            nudThreshold.Value = 0.35m;
            rbThreshold.Checked = true;
        }

        private bool disableCheckBoxChanges = true;
        private void btnApplyFS_Click(object sender, EventArgs e)
        {
            selectedFeatureIndexes = new List<int>();

            int fc = (int)nudFeatureCount.Value;
            float threshold = (float)nudThreshold.Value;
            List<string> featureList = new List<string>();
            if (rbFeatures.Checked)
            {
                string[] featuresToSearch = rtbFeatures.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string f in featuresToSearch)
                {
                    string trimmed = f.Trim();
                    if (!featureList.Contains(trimmed))
                        featureList.Add(trimmed);
                }
            }
            disableCheckBoxChanges = false;
            lvCorrelations.BeginUpdate();
            for (int i = 0; i < featureCount; i++)
            {
                bool check;
                if (rbFeatures.Checked)
                {
                    check = featureList.Contains(i.ToString());
                    if (check)
                        selectedFeatureIndexes.Add(i);
                    int j = sortedIndexes_invMapping[i];
                    if (j < 500)
                        lvCorrelations.Items[j].Checked = check;
                }
                else
                {
                    if (rbFeatureCount.Checked)
                        check = i < fc;
                    else// if (rbThreshold.Checked)
                        check = sortedAvgAbsCorrelations[i] >= threshold;
                    if (check)
                        selectedFeatureIndexes.Add(sortedIndexes[i]);
                    if (i < 500)
                        lvCorrelations.Items[i].Checked = check;
                }
            }
            lvCorrelations.EndUpdate();
            disableCheckBoxChanges = true;
            selectedFeatureIndexes.Sort();
            rtbFeatures.Text = string.Join(", ", selectedFeatureIndexes);

            if (selectedFeatureIndexes.Count < 1)
            {
                appendLine("No feature is selected. All the features (" + featureCount + ") will be included.");
                selectedFeatureIndexes = null;
            }
            else if (selectedFeatureIndexes.Count == featureCount)
            {
                appendLine("The number of selected features is equal to the total number of features. All the features (" + featureCount + ") will be included.");
                selectedFeatureIndexes = null;
            }
            else
                appendLine(selectedFeatureIndexes.Count + " features are selected. The others will be excluded.");
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (disableCheckBoxChanges)
                e.NewValue = e.CurrentValue;
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            if (txtImagesPath.TextLength > 0)
                scanFiles();
            else
                MessageBox.Show(this, "Please select a dataset directory first.", "Dataset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnApplyNorm_Click(object sender, EventArgs e)
        {
            tic();
            appendLine("Applying min-max normalization...");
            showProgressPanel(true);

            string rtbNormMinValsText = rtbNormMinVals.Text;
            string rtbNormMaxValsText = rtbNormMaxVals.Text;
            new Thread(() =>
            {
                char decimalSeperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                Normalizer normalizer = new Normalizer();
                if (rbNormRecalc.Checked)
                {
                    normalizer.normalize(featureSet);
                    Invoke(new Action(() =>
                    {
                        rtbNormMinVals.Text = string.Join("| ", normalizer.minValues).Replace(decimalSeperator, '.').Replace('|', ',');
                        rtbNormMaxVals.Text = string.Join("| ", normalizer.maxValues).Replace(decimalSeperator, '.').Replace('|', ',');
                    }));
                }
                else //if (rbNormCalc.Checked)
                {
                    List<float> minValues = new List<float>();
                    string[] strArr = rtbNormMinValsText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (string str in strArr)
                    {
                        string trimmed = str.Replace('.', decimalSeperator).Trim();
                        float f;
                        if (float.TryParse(trimmed, out f))
                            minValues.Add(f);
                    }
                    List<float> maxValues = new List<float>();
                    strArr = rtbNormMaxValsText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (string str in strArr)
                    {
                        string trimmed = str.Replace('.', decimalSeperator).Trim();
                        float f;
                        if (float.TryParse(trimmed, out f))
                            maxValues.Add(f);
                    }
                    if (minValues.Count != maxValues.Count || minValues.Count != featureSet[0].Length)
                        appendLine("The length of the normalization vectors (min and max) is not equal to the number of features!");
                    else
                        normalizer.normalize(featureSet, minValues, maxValues);
                }
                finishedIn();
                enableTabControl();
            }).Start();
        }

        private void rtbFeatures_DoubleClick(object sender, EventArgs e)
        {
            int len = rtbFeatures.Text.Length;
            if (len < 1)
                return;
            rtbFeatures.Select(0, len);
            Clipboard.SetText(rtbFeatures.Text);
            MessageBox.Show(this, "Copied to the clipboard", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}
