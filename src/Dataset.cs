using System.Collections.Generic;
using System.Text.RegularExpressions;

/*
 *--------------------------------------------------------------------------
 * CNNFET > Dataset.cs
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
    class Dataset
    {
        public string[] files;
        public string[] classes;
        public int[] classIndexes;
        public string[] distinctClasses;
        public int[] numOfInsPerClass;
        public int distinctClassCount;
        public int count;

        public Dataset(string path, string regexPattern, int minNumOfInsPerClass = 0, int maxNumOfInsPerClass = 0)
        {
            FileScanner fs = new FileScanner(new string[] { ".jpg", ".jpeg", ".png", ".bmp" });
            string[] unfilteredFiles = fs.scan(path);

            List<string> files = new List<string>();
            List<int> classIndexes = new List<int>();
            List<string> classes = new List<string>();
            List<int> numOfInsPerClass = new List<int>();

            List<string> classNames = new List<string>();
            foreach (string file in unfilteredFiles)
            {
                Regex r = new Regex(regexPattern, RegexOptions.Singleline);
                Match m = r.Match(file);

                string c = m.Groups[1].Value.Replace("\'", "");

                int ind = classNames.IndexOf(c);
                if (ind < 0)
                {
                    numOfInsPerClass.Add(0);
                    classNames.Add(c);
                    ind = classNames.Count - 1;
                }
                else if (maxNumOfInsPerClass > 0 && numOfInsPerClass[ind] >= maxNumOfInsPerClass)
                    continue;

                numOfInsPerClass[ind]++;

                files.Add(file);
                classIndexes.Add(ind);
                classes.Add(c);
            }

            if (minNumOfInsPerClass > 1)
                for (int i = numOfInsPerClass.Count - 1; i >= 0; i--)
                {
                    if (numOfInsPerClass[i] < minNumOfInsPerClass)
                    {
                        numOfInsPerClass.RemoveAt(i);
                        classNames.RemoveAt(i);
                        for (int j = files.Count - 1; j >= 0; j--)
                            if (classIndexes[j] == i)
                            {
                                files.RemoveAt(j);
                                classes.RemoveAt(j);
                                classIndexes.RemoveAt(j);
                            }
                    }
                }

            this.files = files.ToArray();
            this.classIndexes = classIndexes.ToArray();
            this.classes = classes.ToArray();
            this.numOfInsPerClass = numOfInsPerClass.ToArray();
            count = files.Count;
            distinctClasses = classNames.ToArray();
            distinctClassCount = distinctClasses.Length;

            Dictionary<int, int> newClassIndexes = new Dictionary<int, int>();
            if(minNumOfInsPerClass>0 && classIndexes.Count > 0)
            {
                int k = 0;
                for (int i=0;i< classIndexes.Count; i++)
                {
                    int classInd = classIndexes[i];
                    int newClassInd;
                    if (newClassIndexes.ContainsKey(classInd))
                        newClassInd = newClassIndexes[classInd];
                    else
                    {
                        newClassIndexes.Add(classInd, k);
                        newClassInd = k;
                        k++;
                    }
                    this.classIndexes[i] = newClassInd; 
                }
            }
        }
    }
}
