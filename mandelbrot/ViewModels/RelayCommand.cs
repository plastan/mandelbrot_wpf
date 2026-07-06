using System.Windows;
using System.Windows.Input;

namespace mandelbrot.ViewModels
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _execute;


        public RelayCommand(Action  execute)
        {
            _execute = execute;

        }

        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public  void Execute(object? parameter)
        {
            _execute();
            
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
