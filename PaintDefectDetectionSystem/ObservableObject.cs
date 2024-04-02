using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PaintDefectDetectionSystem
{
    public class ObservableObject : INotifyPropertyChanged
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
                这段代码是一个 C# 方法，通常用于在属性更改时触发 PropertyChanged 事件，以通知绑定到该对象的界面控件更新其显示。
                1.public void OnPropertyChanged([CallerMemberName] String propertyName = "")：这是一个公共方法，用于触发属性更改事件。
                    它接受一个字符串参数 propertyName，该参数默认为空字符串。此方法通常在类中的属性更改时调用。
                2.[CallerMemberName]：这是一个属性，指示编译器在调用方法时自动提供调用者成员的名称。
                    这意味着如果不显式提供 propertyName 参数，编译器将自动使用调用方法的属性或字段的名称。
                3.String propertyName = ""：这是一个可选参数，默认值为空字符串。如果调用者未提供参数，则参数将被设置为默认值。
                4.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));：
                    这一行代码触发了 PropertyChanged 事件。它通过调用 PropertyChanged 委托并传递当前对象以及属性名称来实现。
                    在这里，使用了 C# 6.0 的 null 条件运算符 (?)，以确保在 PropertyChanged 委托不为 null 时才触发事件。
                    总之，这段代码的作用是在属性更改时触发 PropertyChanged 事件，以通知绑定到该对象的界面控件更新其显示
        笔记： ? 这个问号一个要加上，因为初始化该对象的时候，一些对象的属性默认值是null，如果这是该属性赋值，会调用这个方法，导致会发生这个空指针异常，所有，一般情况下，还是都加上？最好

        */
    }
}