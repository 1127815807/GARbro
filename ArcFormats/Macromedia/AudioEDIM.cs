//! \file       AudioEDIM.cs
//! \date       Fri Jun 26 06:52:33 2015
//! \brief      Selen wrapper around MP3 stream.
//
// Copyright (C) 2015 by morkt
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//

using System.ComponentModel.Composition;
using System.IO;
using GameRes.Utility;

namespace GameRes.Formats.Selen
{
    [Export(typeof(AudioFormat))]
    public class EdimAudio : Mp3Audio
    {
        public override string         Tag { get { return "EDIM"; } }
        public override string Description { get { return "Selen audio format (MP3)"; } }
        public override uint     Signature { get { return 0x40010000; } }
        
        public override SoundInput TryOpen (Stream file)
        {
            uint offset = 4 + Binary.BigEndian (FormatCatalog.ReadSignature (file));
            return base.TryOpen (new StreamRegion (file, offset));
        }

        public override void Write (SoundInput source, Stream output)
        {
            throw new System.NotImplementedException ("EdimFormat.Write not implemenented");
        }
    }
}