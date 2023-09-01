using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 *--------------------------------------------------------------------------
 * CNNFET > MFileWriter.cs
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
    class MFileWriter
    {
        string filePath;
        string variableName;
        FileStream fileStream;
        public MFileWriter(string filePath, string variableName)
        {
            this.filePath = filePath;
            this.variableName = variableName;
            fileStream = null;
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public bool writeDefinitions(string[] distinctClassNames)
        {
            try
            {
                fileStream = File.OpenWrite(filePath);
                byte[] byteArray = Encoding.ASCII.GetBytes(
                    variableName + "_classes = { '" + string.Join("', '", distinctClassNames.ToArray()) + "' };\r\n" +
                    variableName + " = [\r\n"
                );
                fileStream.Write(byteArray, 0, byteArray.Length);

                return true;
            }
            catch (Exception)
            {
                closeFile();
                return false;
            }
        }

        public void writeInstance(float[] data, int instanceClassIndex, List<int> selectedFeatureIndexes)
        {
            StringBuilder sb = new StringBuilder();
            if (selectedFeatureIndexes != null)
                foreach (int i in selectedFeatureIndexes)
                    sb.Append(data[i].ToString().Replace(",", ".") + " ");
            else
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString().Replace(",", ".") + " ");

            sb.Append(instanceClassIndex.ToString() + "\r\n");
            byte[] byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            fileStream.Write(byteArray, 0, byteArray.Length);
        }

        public void closeFile()
        {
            byte[] byteArray = Encoding.ASCII.GetBytes("];\r\n%Each row represents one instance and ends with class index (starting from zero)\r\n\r\n");
            fileStream.Write(byteArray, 0, byteArray.Length);

            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }

        ~MFileWriter()
        {
            closeFile();
        }
    }
}
