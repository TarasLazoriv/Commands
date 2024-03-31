namespace LazerLabs.Commands
{
    public interface ICommand
    {
        public void Execute();
    }

    public interface ICommand<out TReturn>
    {
        public TReturn Execute();
    }

    public interface ICommand<in TVariable1, out TReturn>
    {
        public TReturn Execute(TVariable1 v1);
    }

    public interface ICommand<in TVariable1, in TVariable2, out TReturn>
    {
        public TReturn Execute(TVariable1 v1, TVariable2 v2);
    }

    public interface ICommand<in TVariable1, in TVariable2, in TVariable3, out TReturn>
    {
        public TReturn Execute(TVariable1 v1, TVariable2 v2, TVariable3 v3);
    }


    public interface ICommandVoid<in TVariable1>
    {
        public void Execute(TVariable1 v1);
    }

    public interface ICommandVoid<in TVariable1, in TVariable2>
    {
        public void Execute(TVariable1 v1, TVariable2 v2);
    }

    public interface ICommandVoid<in TVariable1, in TVariable2, in TVariable3>
    {
        public void Execute(TVariable1 v1, TVariable2 v2, TVariable3 v3);
    }

}