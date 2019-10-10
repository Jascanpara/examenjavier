using Medidores.Observer;

namespace Medidores.Subject
{
    public interface ISubject
    {
        void RegistrarObserver(IObserver o);
        void EliminarObserver(IObserver o);
        void NotificarObservers();
    }
}