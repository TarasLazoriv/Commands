using System.Threading.Tasks;

namespace LazerLabs.Commands
{
    public interface IAsyncCommand
    {
        public Task Execute();
    }
}