using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCsSample.CodeSampleControls.Present
{
    /// <summary>
    /// Interaction logic for HorizontalWindow.xaml
    /// </summary>
    public partial class HorizontalWindow : Window
    {
        private TextBlock _mtb;
        private int _midiResult = -1;

        //Setup for the WinMM library
        private IntPtr hMidiOut = IntPtr.Zero;
        private MidiOutCallback callback;
        public delegate void MidiOutCallback(IntPtr midiInHandle, int message, IntPtr userData, IntPtr messageParameter1, IntPtr messageParameter2);
        [DllImport("winmm.dll")]
        public static extern int midiOutOpen(out IntPtr lphMidiOut, IntPtr uDeviceID, MidiOutCallback dwCallback, IntPtr dwInstance, int dwFlags);
        [DllImport("winmm.dll")]
        public static extern int midiOutShortMsg(IntPtr hMidiOut, int dwMsg);
        [DllImport("winmm.dll")]
        public static extern int midiOutClose(IntPtr hMidiOut);

        Hashtable ht;

        public HorizontalWindow()
        {
            InitializeComponent();
            //Build the Tag -> Note hashtable
            BuildNoteHashTable();
            //Open the MidiOut and always use the device 0 as an example
            this.callback = new MidiOutCallback(Callback);
            _midiResult = midiOutOpen(out hMidiOut, (IntPtr)0, callback, IntPtr.Zero, 0x30000);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_midiResult == 0)
            { //successful midi handle
                int r = midiOutClose(hMidiOut);
            }
            _midiResult = -1;
        }

        private void KeyButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                keyText.Text = btn.Tag as string;
            }
        }

        private void KeyTouch_Enter(object sender, TouchEventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                keyText.Text = btn.Tag as string;

                // Midi command code 0x90 = NoteOn
                int commandCode = 0x90;
                int vol = 0x60;
                int note = (int)ht[keyText.Text];
                //Midi message 1 byte unused, 2 byte Vol, 3 byte Data, and last byte commeand code
                int message = (vol << 16) + (note << 8) + commandCode;
                if (_midiResult == 0)
                { //successful midi handle
                    int r = midiOutShortMsg(hMidiOut, message);
                }
                
            }
        }

        private void Button_TouchDown(object sender, TouchEventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                keyText.Text = btn.Tag as string;
            }
        }

        private void KeyTouch_Leave(object sender, TouchEventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                keyText.Text = btn.Tag as string;
                // Midi command code 0x90 = NoteOn
                int commandCode = 0x80;
                int vol = 0x00;
                int note = (int)ht[keyText.Text];
                int message = (vol << 16) + (note << 8) + commandCode;
                if (_midiResult == 0)
                {//successful midi handle
                    int r = midiOutShortMsg(hMidiOut, message);
                }
            }
        }

        public void SetMusicTextBlock(TextBlock mtb) 
        {
            //setting the vertical screen text reference
            if (mtb != null)
            {
                _mtb = mtb;
            }
        }

        private void Callback(IntPtr midiInHandle, int message, IntPtr userData, IntPtr messageParameter1, IntPtr messageParameter2)
        {
        }

        private void BuildNoteHashTable()
        {
            ht = new Hashtable();
            ht.Add("C1", 36);
            ht.Add("D1", 38);
            ht.Add("E1", 40);
            ht.Add("F1", 41);
            ht.Add("G1", 43);
            ht.Add("A1", 45);
            ht.Add("B1", 47);
            ht.Add("C2", 48);
            ht.Add("D2", 50);
            ht.Add("E2", 52);
            ht.Add("F2", 53);
            ht.Add("G2", 55);
            ht.Add("A2", 57);
            ht.Add("B2", 59);
            ht.Add("C3", 60);
            ht.Add("D3", 62);
            ht.Add("E3", 64);
            ht.Add("F3", 65);
            ht.Add("G3", 66);
            ht.Add("A3", 69);
            ht.Add("B3", 71);
            ht.Add("C1#", 37);
            ht.Add("D1#", 39);
            ht.Add("F1#", 42);
            ht.Add("G1#", 44);
            ht.Add("A1#", 46);
            ht.Add("C2#", 49);
            ht.Add("D2#", 51);
            ht.Add("F2#", 54);
            ht.Add("G2#", 56);
            ht.Add("A2#", 58);
            ht.Add("C3#", 61);
            ht.Add("D3#", 63);
            ht.Add("F3#", 66);
            ht.Add("G3#", 68);
            ht.Add("A3#", 70);
        }
    }

}
