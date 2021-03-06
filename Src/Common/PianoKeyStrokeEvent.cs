﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    namespace Events
    {
        public delegate void PianoKeyStrokeEvent (object sender, PianoKeyStrokeEventArgs e);

        public class PianoKeyStrokeEventArgs : EventArgs
        {
            public int midiKeyId { get; set; }
            public KeyStrokeType keyStrokeType { get; set; }
            public int KeyVelocity { get; set; }

            public PianoKeyStrokeEventArgs()
            {
            }

            public PianoKeyStrokeEventArgs(int mideKeyId, KeyStrokeType keyStrokeType, int keyVelocity)
            {
                this.midiKeyId = midiKeyId;
                this.keyStrokeType = keyStrokeType;
                this.KeyVelocity = keyVelocity;
            }
        }

        public enum KeyStrokeType { KeyPress, KeyRelease };
    }
}
