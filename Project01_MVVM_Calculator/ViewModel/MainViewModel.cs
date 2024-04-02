namespace Project01_MVVM_Calculator.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private double input1;

        public double Input1
        {
            get { return input1; }
            set { input1 = value; OnPropertyChanged(); }
        }

        private double input2;

        public double Input2
        {
            get { return input2; }
            set { input2 = value; OnPropertyChanged(); }
        }

        private double result;

        public double Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        private string expression;

        public string Expression
        {
            get { return expression; }
            set { expression = value; OnPropertyChanged(); }
        }

        // 属性一定要有对应的 get set,不然会导致绑定失败

        public DelegateCommand ButtonAddCommand { get; set; }
        public DelegateCommand ButtonSubCommand { get; set; }
        public DelegateCommand ButtonMulCommand { get; set; }
        public DelegateCommand ButtonDivCommand { get; set; }

        public MainViewModel()
        {
            // 在构造器中为委托调用具体的方法
            ButtonAddCommand = new DelegateCommand(Add);
            ButtonSubCommand = new DelegateCommand(Sub);
            ButtonMulCommand = new DelegateCommand(Mul);
            ButtonDivCommand = new DelegateCommand(Div);
        }

        public void Add(object parametar)
        {
            Result = Input1 + Input2;
            Expression += $"{Input1} + {Input2} = {Result}" + "\n";
        }

        public void Sub(object parametar)
        {
            Result = Input1 - Input2;
            Expression += $"{Input1} - {Input2} = {Result}" + "\n";
        }

        public void Mul(object parametar)
        {
            Result = Input1 * Input2;
            Expression += $"{Input1} * {Input2} = {Result}" + "\n";
        }

        public void Div(object parametar)
        {
            Result = Input1 / Input2;
            Expression += $"{Input1} / {Input2} = {Result}" + "\n";
        }
    }
}