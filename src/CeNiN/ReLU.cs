﻿/*
 *--------------------------------------------------------------------------
 * CeNiN > ReLU.cs
 *--------------------------------------------------------------------------
 * CeNiN; a convolutional neural network implementation in pure C#
 * Huseyin Atasoy
 * huseyin [at] atasoyweb.net
 * March 2019
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

namespace CeNiN
{
    public unsafe class ReLU : Layer
    {
        public ReLU(int[] inputTensorDims) : base(inputTensorDims)
        {
            type = "ReLU";
        }

        public override void feedNext()
        {
            outputTensorMemAlloc();

            int inputHeight = InputTensorDims[0];
            int inputWidth = InputTensorDims[1];
            int channelCount = InputTensorDims[2];

            float f;
            int[] inputInd = new int[] { 0, 0, 0 };
            for (inputInd[0] = 0; inputInd[0] < inputHeight; inputInd[0]++)
                for (inputInd[1] = 0; inputInd[1] < inputWidth; inputInd[1]++)
                    for (inputInd[2] = 0; inputInd[2] < channelCount; inputInd[2]++)
                    {
                        f = inputTensor[inputInd];
                        if (f < 0)
                            f = 0;
                        writeNextLayerInput(inputInd, f);
                    }

            disposeInputTensor();
        }
    }
}
