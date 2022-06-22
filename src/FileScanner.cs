using System;
using System.IO;
using System.Linq;

/*
 *--------------------------------------------------------------------------
 * CNNFET > FileScanner.cs
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
    class FileScanner
    {
        private string[] supportedExtensions;

        public FileScanner(string[] supportedExtensions)
        {
            int l = supportedExtensions.Length;
            this.supportedExtensions = new string[l];
            Array.Copy(supportedExtensions, this.supportedExtensions, l);
        }

        public string[] scan(string path)
        {
            try
            {
                return Directory
                 .EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                 .Where((file) =>
                 {
                     string ext = Path.GetExtension(file).ToLower();
                     return (Array.IndexOf(supportedExtensions, ext) > -1);
                 }).ToArray();
            }
            catch (Exception)
            {
                return new string[0];
            }
        }
    }
}
