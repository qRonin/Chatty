using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Chatty.W
{
    class WindowViewModel : BaseViewModel
    {
        #region Fields Private
        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
        #endregion
        #region Fields Public
        public int ResizeBorder {get; set; } = 6;

        public Thickness ResizeBorderThickness {get {return new Thickness(ResizeBorder); } }

        public int OuterMarginSize 
        {
            get
            { 
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set 
            {
             mOuterMarginSize = value;   
            }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize + OuterMarginSize); } }


        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight {get; set; }

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        #endregion
        #region Commans
        public ICommand MinimizeCommand {get; set; }
        public ICommand MaximizeCommand {get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Ctor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            { 
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Maximized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

        }
        #endregion

        #region Helpers

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
        #endregion
    }
}
