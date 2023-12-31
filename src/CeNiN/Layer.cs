﻿
/*
 *--------------------------------------------------------------------------
 * CeNiN > Layer.cs
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

using System.Threading;

namespace CeNiN
{
    public abstract class Layer
    {
        private Mutex mutex;

        public string type;

        private int[] inputTensorDims;
        public int[] InputTensorDims
        {
            get
            {
                return inputTensorDims;
            }
        }

        public bool paddedWriting;
        public int[] pad;

        public Tensor inputTensor = null;
        public Layer nextLayer;
        public Layer()
        {
            mutex = new Mutex();
        }

        public void mutexLock()
        {
            mutex.WaitOne();
            //System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " > " + type + " - Lock - " + ((nextLayer is null) ? "" : nextLayer.type));
        }
        public void mutexUnlock()
        {
            //System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " > " + type + " - Unlock - " + ((nextLayer is null) ? "" : nextLayer.type));
            mutex.ReleaseMutex();
        }

        public void writeNextLayerInput(int[] indexes, float value)
        {
            if (nextLayer.paddedWriting)
            {
                int[] nInd = (int[])indexes.Clone();
                nInd[0] += nextLayer.pad[0];
                nInd[1] += nextLayer.pad[2];
                nextLayer.inputTensor[nInd] = value;
            }
            else
                nextLayer.inputTensor[indexes] = value;
        }

        public Layer(int[] inputTensorDims) : this()
        {
            paddedWriting = false;
            this.inputTensorDims = (int[])inputTensorDims.Clone();
        }

        public Layer(int[] inputTensorDims, int[] pad) : this()
        {
            this.pad = (int[])pad.Clone();
            if (pad[0] > 0 || pad[2] > 0)
                paddedWriting = true;
            else
                paddedWriting = false;

            this.inputTensorDims = (int[])inputTensorDims.Clone();
            this.inputTensorDims[0] += pad[0] + pad[1];
            this.inputTensorDims[1] += pad[2] + pad[3];
        }

        public int[] outputDims;

        public void setOutputDims()
        {
            outputDims = (int[])inputTensorDims.Clone();
        }

        public abstract void feedNext();

        public void inputTensorMemAlloc()
        {
            mutexLock();
            inputTensor = new Tensor(inputTensorDims);
        }

        public void outputTensorMemAlloc()
        {
            nextLayer.inputTensorMemAlloc();
        }

        public void disposeInputTensor()
        {
            inputTensor.Dispose();
            inputTensor = null;
            mutexUnlock();
        }

        public void appendNext(Layer nextLayer)
        {
            this.nextLayer = nextLayer;
        }
    }
}
