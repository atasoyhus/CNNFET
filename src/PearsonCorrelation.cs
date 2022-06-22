using System;

/*
 *--------------------------------------------------------------------------
 * CNNFET > PearsonCorrelation.cs
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

namespace CNNFET
{
    static class PearsonCorrelation
    { 
        private static float correlationBetween(float[] X, float[] Y)
        {
            int n = X.Length;

            float avgX = 0, avgY = 0;
            for (int i = 0; i < n; i++)
            {
                avgX += X[i];
                avgY += Y[i];
            }
            avgX /= n;
            avgY /= n;

            float sum_X_avgX_2 = 0, sum_Y_avgY_2 = 0, sum_X_avgXY_avgY = 0;
            for (int i = 0; i < n; i++)
            {
                float X_avgX = X[i] - avgX;
                float Y_avgY = Y[i] - avgY;

                sum_X_avgX_2 += X_avgX * X_avgX;
                sum_Y_avgY_2 += Y_avgY * Y_avgY;
                sum_X_avgXY_avgY += X_avgX * Y_avgY;
            }

            float mul = sum_X_avgX_2 * sum_Y_avgY_2;
            if (mul == 0)
                return 1;
            else
                return (float)(sum_X_avgXY_avgY / Math.Sqrt(Math.Abs(mul)));
        }

        public static float weightedAvgAbsCorrelation(float[] X, int[] Y, int distinctClassCount)
        {
            int m = distinctClassCount;
            int n = X.Length;
            float[] binarizedClasses = new float[n];
            if (m == 2)
            {
                for (int j = 0; j < n; j++)
                    binarizedClasses[j] = Y[j];
                return Math.Abs(correlationBetween(X, binarizedClasses));
            }

            float avgCorr = 0f;
            for (int i = 0; i < m; i++)
            {
                int instanceCount = 0;
                for (int j = 0; j < n; j++)
                {
                    if (Y[j] == i)
                    {
                        binarizedClasses[j] = 1f;
                        instanceCount++;
                    }
                    else
                        binarizedClasses[j] = 0f;
                }
                float corr = Math.Abs(correlationBetween(X, binarizedClasses));
                corr *= (float)instanceCount / n;
                avgCorr += corr;
            }
            return avgCorr;
        }
    }
}
