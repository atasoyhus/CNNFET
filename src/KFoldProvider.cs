using System;

/*
 *--------------------------------------------------------------------------
 * CNNFET > KFoldProvider.cs
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
    class KFoldProvider<T1, T2>
    {
        public readonly T1[][] data;
        public readonly T2[][] outputs;

        public readonly int k;

        public readonly T1[][][] trainData;
        public readonly T2[][][] trainOutputs;
        public readonly T1[][][] testData;
        public readonly T2[][][] testOutputs;

        public readonly int instanceCount;
        public readonly int attributeCount;
        public readonly int outputCount;

        public readonly int[] shuffledIndexes;

        public KFoldProvider(T1[][] data, T2[][] outputs, int k = 10, int randomSeed = int.MinValue)
        {
            instanceCount = data.Length;
            attributeCount = data[0].Length;
            outputCount = outputs[0].Length;

            this.data = new T1[instanceCount][];
            this.outputs = new T2[instanceCount][];

            shuffledIndexes = new int[instanceCount];
            for (int i = 0; i < instanceCount; i++)
            {
                this.data[i] = new T1[attributeCount];
                this.outputs[i] = new T2[outputCount];

                Array.Copy(data[i], this.data[i], attributeCount);
                Array.Copy(outputs[i], this.outputs[i], outputCount);

                shuffledIndexes[i] = i;
            }

            trainData = new T1[k][][];
            trainOutputs = new T2[k][][];
            testData = new T1[k][][];
            testOutputs = new T2[k][][];

            this.k = k;

            shuffle(randomSeed);

            prepareKFolds();
        }

        private void shuffle(int randomSeed = int.MinValue)
        {
            Random randomGenerator;
            if (randomSeed == int.MinValue)
                randomGenerator = new Random(Guid.NewGuid().GetHashCode());
            else
                randomGenerator = new Random(randomSeed);

            float[] randArr = new float[instanceCount];
            for (int i = 0; i < instanceCount; i++)
                randArr[i] = (float)randomGenerator.NextDouble();

            Array.Sort(randArr, shuffledIndexes);
        }

        private void prepareKFolds()
        {
            int vectorCountInEachFold = (int)Math.Floor((double)instanceCount / k);

            int vectorCountInKMinus1Fold = (k - 1) * vectorCountInEachFold;
            int vectorCountInTheLastFold = instanceCount - vectorCountInKMinus1Fold;

            for (int i = 0; i < k; i++)
            {
                int testInstanceCount;
                if (i == k - 1)
                    testInstanceCount = vectorCountInTheLastFold;
                else
                    testInstanceCount = vectorCountInEachFold;

                testData[i] = new T1[testInstanceCount][];
                testOutputs[i] = new T2[testInstanceCount][];

                int trainInstanceCount = instanceCount - testInstanceCount;
                trainData[i] = new T1[trainInstanceCount][];
                trainOutputs[i] = new T2[trainInstanceCount][];

                int m = 0;
                for (int j = 0; j < k; j++)
                {
                    int lBound = j * vectorCountInEachFold;
                    int uBound = lBound;
                    if (j == k - 1)
                        uBound += vectorCountInTheLastFold;
                    else
                        uBound += vectorCountInEachFold;

                    if (i == j)
                    {
                        int n = 0;
                        for (int p = lBound; p < uBound; p++)
                        {
                            int shuffledInd = shuffledIndexes[p];
                            testData[i][n] = data[shuffledInd];
                            testOutputs[i][n] = outputs[shuffledInd];
                            n++;
                        }
                    }
                    else
                    {
                        for (int p = lBound; p < uBound; p++)
                        {
                            int shuffledInd = shuffledIndexes[p];
                            trainData[i][m] = data[shuffledInd];
                            trainOutputs[i][m] = outputs[shuffledInd];
                            m++;
                        }
                    }
                }
            }
        }
    }
}
