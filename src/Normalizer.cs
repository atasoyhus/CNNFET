using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNNFET
{
    class Normalizer
    {
        public int numberOfInstances;
        public int numberOfFeatures;
        public float[] minValues;
        public float[] maxValues;

        public void normalize(float[][] featureSet)
        {
            numberOfInstances = featureSet.Length;
            numberOfFeatures = featureSet[0].Length;

            minValues = new float[numberOfFeatures];
            maxValues = new float[numberOfFeatures];
            for (int j = 0; j < numberOfFeatures; j++)
            {
                minValues[j] = int.MaxValue;
                maxValues[j] = int.MinValue;
            }

            for (int i = 0; i < numberOfInstances; i++)
                for (int j = 0; j < numberOfFeatures; j++)
                {
                    var v = featureSet[i][j];
                    if (minValues[j] > v)
                        minValues[j] = v;
                    if (maxValues[j] < v)
                        maxValues[j] = v;
                }

            normalizeAll(featureSet);
        }

        public void normalize(float[][] featureSet, List<float> minValues, List<float> maxValues)
        {
            numberOfInstances = featureSet.Length;
            numberOfFeatures = featureSet[0].Length;

            this.minValues = minValues.ToArray();
            this.maxValues = maxValues.ToArray();

            normalizeAll(featureSet);
        }

        private void normalizeAll(float[][] featureSet)
        {
            for (int j = 0; j < numberOfFeatures; j++)
            {
                float max_min = maxValues[j] - minValues[j];
                for (int i = 0; i < numberOfInstances; i++)
                    featureSet[i][j] = (featureSet[i][j] - minValues[j]) / max_min;
            }
        }
    }
}
