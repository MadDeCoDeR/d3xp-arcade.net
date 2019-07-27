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
using System.Collections.Generic;

namespace d3xp_arcadenet.file
{
    class Paths
    {
        public static Dictionary<string, List<string>> paths = new Dictionary<string, List<string>> {
            { "maps/game", null },
            {"guis/assets", new List<string>
            {
                {"guis/assets/arcade"},
                {"guis/assets/bearshoot" },
                {"guis/assets/bustout" }
            } },
            { "guis/BearShoot", new List<string>{
                {"guis/GameBearShoot.gui" }
            } },
            { "guis/BustOut", new List<string>{
                {"guis/GameBustOut.gui" }
            } },
            { "guis/SSD", new List<string>{
                {"guis/GameSSD.gui" }
            } },
            { "materials", new List<string>{
                { "materials/GameBearShoot.mtr"},
                { "materials/GameSSD.mtr"}
            } },
            {"models/mapobjects", new List<string>{
                {"models/mapobjects/arcade_machine" }
            } },
            {"newpdas", new List<string>{
                {"newpdas/arcade.pda" }
            } },
            {"sound", new List<string>{
                {"sound/arcade_machines" },
                {"sound/arcade.sndshd" }
            } },
            { "textures/particles", new List<string>{
                { "textures/particles/fball2_strip.tga"},
                { "textures/particles/flame2_strip.tga"}
            } },
            {"ui/assets", new List<string>{
                {"ui/assets/crosshair.tga" }
            } }
        };

    }
}
