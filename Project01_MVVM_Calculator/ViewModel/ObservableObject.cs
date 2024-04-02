using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project01_MVVM_Calculator.ViewModel
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// 该事件专门用来触发属性更改通知
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 使用了CallerMemberName特性后，就不必再传入属性名字符串
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}