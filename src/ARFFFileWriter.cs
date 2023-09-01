using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 *--------------------------------------------------------------------------
 * CNNFET > ARFFFileWriter.cs
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
    class ARFFFileWriter
    {
        string filePath;
        string relationName;
        FileStream fileStream;
        public ARFFFileWriter(string filePath, string relationName)
        {
            this.filePath = filePath;
            this.relationName = relationName;
            fileStream = null;
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public bool writeAttributeDefinitions(int attributeCount, string[] distinctClassNames, List<int> selectedFeatureIndexes)
        {
            try
            {
                fileStream = File.OpenWrite(filePath);
                byte[] byteArray = Encoding.ASCII.GetBytes("@relation " + relationName + "\r\n\r\n");
                fileStream.Write(byteArray, 0, byteArray.Length);

                if (selectedFeatureIndexes != null)
                    foreach (int i in selectedFeatureIndexes)
                    {
                        byteArray = Encoding.ASCII.GetBytes("@attribute attr" + i + " numeric\r\n");
                        fileStream.Write(byteArray, 0, byteArray.Length);
                    }
                else
                    for (int i = 0; i < attributeCount; i++)
                    {
                        byteArray = Encoding.ASCII.GetBytes("@attribute attr" + i + " numeric\r\n");
                        fileStream.Write(byteArray, 0, byteArray.Length);
                    }
                byteArray = Encoding.ASCII.GetBytes("@attribute class {'" + string.Join("','", distinctClassNames.ToArray()) + "'}\r\n\r\n@data\r\n");
                fileStream.Write(byteArray, 0, byteArray.Length);

                return true;
            }
            catch (Exception)
            {
                closeFile();
                return false;
            }
        }

        public void writeInstance(float[] data, string instanceClass, List<int> selectedFeatureIndexes)
        {
            StringBuilder sb = new StringBuilder();
            if (selectedFeatureIndexes != null)
                foreach (int i in selectedFeatureIndexes)
                    sb.Append(data[i].ToString().Replace(",", ".") + " ");
            else
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString().Replace(",", ".") + " ");
            sb.Append("'" + instanceClass + "'\r\n");
            byte[] byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            fileStream.Write(byteArray, 0, byteArray.Length);
        }

        public void closeFile()
        {
            if (fileStream != null)
            {
                fileStream.Close();
                fileStream = null;
            }
        }

        ~ARFFFileWriter()
        {
            closeFile();
        }
    }
}
