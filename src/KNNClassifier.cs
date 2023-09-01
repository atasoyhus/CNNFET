using System;
using System.Collections.Generic;

/*
 *--------------------------------------------------------------------------
 * CNNFET > KNNClassifier.cs
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
    class KNNClassifier
    {
        private float[][] instances;
        private int[] labelIndexes;
        private int numberOfInstances, numberOfFeatures;
        private int[] orderedIndexes;

        public int[] uniqueLabelIndexes;

        public KNNClassifier(float[][] instances, int[] labelIndexes)
        {
            numberOfInstances = instances.Length;
            numberOfFeatures = instances[0].Length;

            orderedIndexes = new int[numberOfInstances];
            this.labelIndexes = new int[numberOfInstances];
            this.instances = new float[numberOfInstances][];

            List<int> uniqueLabelList = new List<int>();
            for (int i = 0; i < numberOfInstances; i++)
            {
                orderedIndexes[i] = i;
                this.labelIndexes[i] = labelIndexes[i];
                this.instances[i] = new float[numberOfFeatures];
                for (int j = 0; j < numberOfFeatures; j++)
                    this.instances[i][j] = instances[i][j];
                if (!uniqueLabelList.Contains(labelIndexes[i]))
                    uniqueLabelList.Add(labelIndexes[i]);
            }
            uniqueLabelIndexes = uniqueLabelList.ToArray();
        }

        public int classify(float[] newInstance, int k)
        {
            float[] distances = new float[numberOfInstances];
            Dictionary<int, float> minDistancesPerClass = new Dictionary<int, float>();
            int n = uniqueLabelIndexes.Length;
            for (int i = 0; i < n; i++)
                minDistancesPerClass[uniqueLabelIndexes[i]] = float.MaxValue;
            for (int i = 0; i < numberOfInstances; i++)
            {
                float d = calcDistance(instances[i], newInstance);
                distances[i] = d;
                int labelInd = labelIndexes[i];
                if (d < minDistancesPerClass[labelInd])
                    minDistancesPerClass[labelInd] = d;
            }

            int[] indexes = (int[])orderedIndexes.Clone();
            Array.Sort(distances, indexes);

            int[] nearestKClasses = new int[k];
            if (k > numberOfInstances) k = numberOfInstances;
            for (int i = 0; i < k; i++)
                nearestKClasses[i] = labelIndexes[indexes[i]];

            Dictionary<int, int> histogram = calcHistogram(nearestKClasses);
            int max = -1;
            int maxInd = 0;
            foreach (KeyValuePair<int, int> kvp in histogram)
            {
                if (kvp.Value == max && minDistancesPerClass[kvp.Key] < minDistancesPerClass[maxInd])
                {
                    max = kvp.Value;
                    maxInd = kvp.Key;
                }
                else if (kvp.Value > max)
                {
                    max = kvp.Value;
                    maxInd = kvp.Key;
                }
            }
            return maxInd;
        }

        private float calcDistance(float[] instance1, float[] instance2)
        {
            float sumOfSquares = 0f;
            for (int i = 0; i < numberOfFeatures; i++)
                sumOfSquares += (float)Math.Pow(instance1[i] - instance2[i], 2);

            return (float)Math.Sqrt(sumOfSquares);
        }

        private Dictionary<int, int> calcHistogram(int[] array)
        {
            int k = array.Length;
            Dictionary<int, int> hist = new Dictionary<int, int>();
            for (int i = 0; i < k; i++)
            {
                int val = array[i];
                if (hist.ContainsKey(val))
                    hist[val]++;
                else
                    hist.Add(val, 1);
            }

            return hist;
        }
    }
}
