using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz.Model
{
    public class CompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void RemoveCommand(ICommand command)
        {
            _commands.Remove(command);
        }

        public bool CanExecute(object parameter)
        {
            return _commands.All(command => command.CanExecute(parameter));
        }

        public void Execute(object parameter)
        {
            foreach (var command in _commands)
            {
                command.Execute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                foreach (var command in _commands)
                {
                    command.CanExecuteChanged += value;
                }
            }
            remove
            {
                foreach (var command in _commands)
                {
                    command.CanExecuteChanged -= value;
                }
            }
        }
    }

}
