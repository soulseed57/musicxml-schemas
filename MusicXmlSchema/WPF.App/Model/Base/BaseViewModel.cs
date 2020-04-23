using System;
using GalaSoft.MvvmLight;

namespace WPF.App.Model.Base
{
    public class BaseViewModel : ViewModelBase
    {
        public bool IsNullable<T>(T type) => Nullable.GetUnderlyingType(type.GetType()) != null;
        protected void Set<T>(ref T field, T newValue, string propertyName, bool isCollect = false)
        {
            if (isCollect)
            {
                if (IsNullable(field))
                {
                    field = default(T);
                }
                GC.Collect();
            }
            field = newValue;
            RaisePropertyChanged(propertyName);
        }
    }
}
