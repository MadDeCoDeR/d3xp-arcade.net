/*
ROE BFG arcade installer

Copyright(C) 2019 George Kalmpokis

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files(the "Software"), to deal in the Software without
restriction, including without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following conditions :

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using d3xp_arcadenet.Properties;
using System.IO;

namespace d3xp_arcadenet.file
{
    class FileTransferImpl : FileTransfer
    {
        private FileExtractor exporter;

        public void transferFiles(string d3path, string bfgpath)
        {
            exporter = new FileExtractorImpl(d3path + "/pak000.pk4");
            foreach(string key in Paths.paths.Keys)
            {
                string currentPath = bfgpath + "/" + key;
                Directory.CreateDirectory(currentPath);
                Directory.SetCurrentDirectory(currentPath);
                if (key.Equals("maps/game")) {
                    File.WriteAllText(currentPath + "/erebus3.map", Resources.erebus3);
                    File.WriteAllText(currentPath + "/erebus4.map", Resources.erebus4);
                    File.WriteAllText(currentPath + "/phobos2.map", Resources.phobos2);
                    continue;
                }
                if (Paths.paths[key][0].EndsWith(".gui"))
                {
                    exporter.extractFiles(Paths.paths[key][0], "guis", currentPath);
                    continue;
                }
                foreach (string path in Paths.paths[key])
                {
                    exporter.extractFiles(path, key, currentPath);
                }
            }
        }
    }
}
