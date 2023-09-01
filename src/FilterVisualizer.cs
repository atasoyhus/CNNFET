using CeNiN;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

/*
 *--------------------------------------------------------------------------
 * CNNFET > FilterVisualizer.cs
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
    class FilterVisualizer
    {
        private Form frm = null;
        private ComboBox cbFilterIndex;
        private FlowLayoutPanel flp;

        public void visualize(CNN cnn, int layerIndex, int filterIndex)
        {
            Conv layer = (Conv)cnn.layers[layerIndex];

            int[] dims = layer.weights.Dimensions;
            int width = dims[0];
            int height = dims[1];
            int channelCount = dims[2];
            int filterCount = dims[3];

            if (filterIndex >= filterCount)
            {
                MessageBox.Show(null, "Channel index should be a number below " + channelCount + ".", "Invalid Channel Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (width < 2 && height < 2)
            {
                MessageBox.Show(null, "Filters in the selected layer cannot be visualized since their size is 1x1. (These layers are fully connected layers implemented using convolution.)", "Filter Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bitmap[] bitmaps = new Bitmap[channelCount];
            for (int n = 0; n < channelCount; n++)
            {
                float[,] currFilter = new float[width, height];
                float min = float.MaxValue;
                float max = float.MinValue;
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        float val = layer.weights[i, j, n, filterIndex];

                        if (val < min)
                            min = val;
                        if (val > max)
                            max = val;

                        currFilter[i, j] = val;
                    }

                float max_min = max - min;
                if (max_min == 0)
                    max_min = 1;


                Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        float val = currFilter[i, j];
                        val = 255.0f * (val - min) / max_min;
                        int iVal = (int)val;

                        bmp.SetPixel(i, j, Color.FromArgb(iVal, iVal, iVal));
                    }
                bitmaps[n] = bmp;
            }

            if (frm == null || frm.IsDisposed)
            {
                frm = new Form();
                frm.Size = new Size(430, 300);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowIcon = false;
                frm.Text = "Filter Visualizer";

                cbFilterIndex = new ComboBox();
                cbFilterIndex.Dock = DockStyle.Top;
                cbFilterIndex.DropDownStyle = ComboBoxStyle.DropDownList;
                for (int i = 0; i < filterCount; i++)
                    cbFilterIndex.Items.Add("Filter index: " + i);
                cbFilterIndex.SelectedIndex = 0;
                cbFilterIndex.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    visualize(cnn, layerIndex, cbFilterIndex.SelectedIndex);
                };

                flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoScroll = true;

                frm.Controls.Add(flp);
                frm.Controls.Add(cbFilterIndex);

                frm.Show();
            }
            else
                flp.Controls.Clear();

            frm.SuspendLayout();
            for (int n = 0; n < bitmaps.Length; n++)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 50;
                pb.Height = 50;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.BackgroundImage = bitmaps[n];
                pb.BorderStyle = BorderStyle.FixedSingle;
                flp.Controls.Add(pb);
            }
            frm.ResumeLayout();
        }
    }
}
