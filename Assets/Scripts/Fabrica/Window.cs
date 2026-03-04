using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BorderlessWindow : MonoBehaviour
{

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    const int GWL_STYLE = -16;
    const uint WS_BORDER = 0x00800000;
    const uint WS_DLGFRAME = 0x00400000;
    const uint WS_CAPTION = 0x00C00000;

    void Start()
    {
        SetAlwaysOnTop();

        IntPtr window = GetActiveWindow();
        uint style = GetWindowLong(window, GWL_STYLE);
        style &= ~(WS_BORDER | WS_DLGFRAME | WS_CAPTION);
        SetWindowLong(window, GWL_STYLE, style);
    }

    [DllImport("user32.dll")] //Activar Always On Top
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    const UInt32 SWP_NOSIZE = 0x0001;
    const UInt32 SWP_NOMOVE = 0x0002;

    void SetAlwaysOnTop()
    {
        IntPtr window = GetActiveWindow();
        SetWindowPos(window, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
    }

}
