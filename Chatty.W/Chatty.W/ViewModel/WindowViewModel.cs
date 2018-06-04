using System.Windows;

namespace Chatty.W
{
    class WindowViewModel : BaseViewModel
    {
        #region priv fields
        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
        #endregion

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
        }
    }
}
