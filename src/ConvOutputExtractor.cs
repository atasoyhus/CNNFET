using CeNiN;
using System.Drawing;

/*
 *--------------------------------------------------------------------------
 * CNNFET > ConvOutputExtractor.cs
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
    unsafe class ConvOutputExtractor
    {
        private CNN cnn;

        public ConvOutputExtractor(CNN cnn)
        {
            this.cnn = cnn;
        }

        public float[] extract(string imageFile, int layerIndex)
        {
            float[] convOutput = null;
            Bitmap b = new Bitmap(imageFile);
            cnn.inputLayer.setInput(b, Input.ResizingMethod.ZeroPad);
            Layer currentLayer = cnn.inputLayer;
            int i = 0;
            while (currentLayer.nextLayer != null)
            {
                if (i == layerIndex + 1)
                {
                    convOutput = new float[currentLayer.inputTensor.TotalLength];
                    for (int j = 0; j < convOutput.Length; j++)
                        convOutput[j] = currentLayer.inputTensor.memPtr[j];
                    currentLayer.disposeInputTensor();
                    break;
                }

                currentLayer.feedNext();
                currentLayer = currentLayer.nextLayer;
                i += 1;
            }

            return convOutput;
        }
    }
}
