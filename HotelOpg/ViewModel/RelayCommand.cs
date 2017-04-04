using System;
using System.Windows.Input;

namespace HotelOpg.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action createGuest;
        private Action deleteSelected;
        private Func<bool> isListEmptyCheck;

        public RelayCommand(Action createGuest)
        {
            this.createGuest = createGuest;
        }

        public RelayCommand(Action deleteSelected, Func<bool> isListEmptyCheck)
        {
            this.deleteSelected = deleteSelected;
            this.isListEmptyCheck = isListEmptyCheck;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}