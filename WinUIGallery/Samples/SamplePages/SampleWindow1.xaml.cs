using System;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using WinRT.Interop;
using WinUIGallery.Helpers;

namespace WinUIGallery.Samples.SamplePages;

public sealed partial class SampleWindow1 : Window
{
    private AppWindow appWindow;

    public SampleWindow1()
    {
        this.InitializeComponent();
    }

    public SampleWindow1(string WindowTitle, Int32 Width, Int32 Height, Int32 X, Int32 Y, TitleBarTheme TitleBarPreferredTheme)
    {
        this.InitializeComponent();

        // Retrieve the AppWindow instance for the current window
        appWindow = GetAppWindowForCurrentWindow();

        // Set the window title
        appWindow.Title = WindowTitle;

        // Set the window size (including borders)
        appWindow.Resize(new Windows.Graphics.SizeInt32(Width, Height));

        // Set the window position on screen
        appWindow.Move(new Windows.Graphics.PointInt32(X, Y));

        // Set the preferred theme for the title bar
        appWindow.TitleBar.PreferredTheme = TitleBarPreferredTheme;

        // Set the taskbar icon (displayed in the taskbar)
        appWindow.SetTaskbarIcon("Assets/Tiles/GalleryIcon.ico");

        // Set the title bar icon (displayed in the window's title bar)
        appWindow.SetTitleBarIcon("Assets/Tiles/GalleryIcon.ico");

        // Set the window icon (affects both taskbar and title bar, can be omitted if the above two are set)
        // appWindow.SetIcon("Assets/Tiles/GalleryIcon.ico"); 
    }

    //Returrns the AppWindow instance associated with the current window.
    private AppWindow GetAppWindowForCurrentWindow()
    {
        // Get the native window handle
        IntPtr hWnd = WindowNative.GetWindowHandle(this);

        // Retrieve the WindowId from the window handle
        WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);

        // Return the AppWindow instance associated with the given WindowId
        return AppWindow.GetFromWindowId(myWndId);
    }

    private void Show_Click(object sender, RoutedEventArgs e)
    {
        appWindow.Hide();
        Task.Delay(3000).ContinueWith(t => appWindow.Show());
    }

    private void Hide_Click(object sender, RoutedEventArgs e)
    {
        appWindow.Hide();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
