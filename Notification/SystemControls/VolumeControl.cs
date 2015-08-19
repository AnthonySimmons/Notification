using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Notification.SystemControls
{
    /// <summary>
    /// http://stackoverflow.com/questions/13139181/how-to-programmatically-set-the-system-volume
    /// </summary>
    public class VolumeControl
    {
        private static object VolumeLockObject = new object();

        private IntPtr _handle;

        public VolumeControl(IntPtr handle)
        {
            _handle = handle;
        }
              
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public void Mute()
        {
            SendMessageW(_handle, WM_APPCOMMAND, _handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public void VolumeDown()
        {
            SendMessageW(_handle, WM_APPCOMMAND, _handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public void VolumeUp()
        {
            SendMessageW(_handle, WM_APPCOMMAND, _handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}