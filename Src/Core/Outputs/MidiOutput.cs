﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanford.Multimedia.Midi;
using Common;
using Common.Devices;
using Common.Events;
using Common.Infrastructure;

namespace Common.Outputs
{
    public class MidiOutput : ObservableObject, IOutput, IDisposable
    {
        OutputDevice _outputDevice;

        public void Close()
        {
            _outputDevice.Close();
        }

        public void Initialise()
        {
            try
            {
                _outputDevice = new OutputDevice(0);
                IsInitialised = true;
            }
            catch (Exception e)
            {
                Exceptions.ErrHandler("Failed to initialise output device: ", e);
            }
        }

        public void Send(PianoKeyStrokeEventArgs args)
        {
            _outputDevice.Send(SanfordUtils.ConvertKeyStrokeEventArgsToChannelMessage(args));
        }

        #region IOutput implementation
        private string _deviceName;

        public bool IsInitialised
        {
            get;
            private set;
        }

        public string Name
        {
            get { return "Output (make dyn pls)"; }
            set
            {
                _deviceName = value;
                RaisePropertyChanged("Name");
            }
        }

        public DeviceType DeviceType
        {
            get { return DeviceType.Output; }
        }
        #endregion

        #region IDisposable implementation
        public void Dispose()
        {
            Close();
        }
        #endregion
    }
}
