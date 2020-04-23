using WPF.App.Model.Base;

namespace WPF.App.ViewModel
{
    public class MainVM : Singleton<MainVM>
    {
        #region 构造函数
        public MainVM()
        {
            instance = this;
        }
        #endregion

        #region 绑定属性

        double _width = 800;
        public double Width
        {
            get => _width;
            set => Set(ref _width, value, "Width");
        }

        double _height = 800;
        public double Height
        {
            get => _height;
            set => Set(ref _height, value, "Height");
        }

        #endregion

    }
}