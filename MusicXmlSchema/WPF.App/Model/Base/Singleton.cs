namespace WPF.App.Model.Base
{
    public abstract class Singleton<T> : BaseViewModel where T : BaseViewModel, new()
    {
        protected static T instance;
        public static T Instance => instance ?? (instance = new T());
    }
}