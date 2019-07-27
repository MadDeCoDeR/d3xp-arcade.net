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
using d3xp_arcadenet.image;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using TGASharpLib;

namespace d3xp_arcadenet.file
{
    class FileExtractorImpl:FileExtractor
    {
        private ZipArchive zipfile;

        private List<string> excludeResizePaths = new List<string>
        {
            { "guis/assets/bustout"},
            {"guis/assets/bearshoot/sliderthumb" }/*,
            {"guis/assets/bearshoot/sarge" },
            {"guis/assets/bearshoot/turret" },
            {"guis/assets/bearshoot/wind" },
            {"guis/assets/arcade/asteroid" },
            {"guis/assets/arcade/health" },
            {"guis/assets/arcade/powerupbonus" },
            {"guis/assets/arcade/poweruphealth" },
            {"guis/assets/arcade/poweruprescue" },*/

        };

        public FileExtractorImpl(string path)
        {
            zipfile = ZipFile.OpenRead(path);
        }

        public void extractFiles(string archievedFile, string relativePath, string OutputPath)
        {
            foreach( ZipArchiveEntry entry in zipfile.Entries)
            {
                if (entry.FullName.StartsWith(archievedFile)) {
                    string path = OutputPath + entry.FullName.Replace(relativePath, "");
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    entry.ExtractToFile(path, true);
                    if (Path.GetExtension(path).Contains("tga") )
                    {
                        bool skip = false;
                        foreach(string excludePath in excludeResizePaths)
                        {
                            if (path.Contains(excludePath))
                            {
                                skip = true;
                            }
                        }
                        if (!skip)
                        {
                            int multiplier = 8;
                            TGA image = new TGA(path);
                            ImageScaler scaler = new ImageScalerImpl();
                            scaler.ResizeImage(image.ToBitmap(), image.Width * multiplier, image.Height * multiplier, path);
                        }
                    }
                }
            }
        }
    }
}
