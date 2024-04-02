using System;
using System.Windows.Input;

namespace PaintDefectDetectionSystem
{
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// 定义了一个返回值类型为空，可以接收object类型的委托
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// 定义一个接受1个object类型的参数并返回一个bool类型结果的委托
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// 声明了一个构造方法，为DelegateCommand的两个属性赋值，
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"> 可以为null </param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// 接口方法的实现
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 接口方法的实现
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            // 上面构造方法中canExecute = null ，可以为null,等于null是 返回true
            // return _canExecute == null || _canExecute(parameter);
            // 使用 || 运算法等同于下面的写法
            if (_canExecute == null)
            {
                return true;
            }
            // 上面定义了一个这样的委托，接收一个object类型的参数，返回一个bool的值
            return _canExecute(parameter);
        }

        /// Lambda表达式的写法，作用同上
        /// public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// 接口方法的实现
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Lambda表达式的写法，作用同上
        //public void Execute(object parameter) => _execute(parameter);
    }
}