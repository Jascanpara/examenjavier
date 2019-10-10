using Medidores.Observer;
using System.Collections;

namespace Medidores.Subject
{
    public class MedidorSensores : ISubject
    {
        #region Estado

        // Atributos que modelan el estado
        private int nivelAceite;
        private int nivelAgua;
        private int nivelPresionNeumaticos;

        #endregion

        // Listado de observers
        private readonly IList _suscriptores;

        #region Properties

        public int NivelAceite
        {
            get => nivelAceite;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (nivelAceite != value)
                {
                    nivelAceite = value;
                    NotificarObservers();
                }
            }
        }

        public int NivelAgua
        {
            get => nivelAgua;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (nivelAgua != value)
                {
                    nivelAgua = value;
                    NotificarObservers();
                }
            }
        }

        public int NivelPresionNeumaticos
        {
            get => nivelPresionNeumaticos;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (nivelPresionNeumaticos != value)
                {
                    this.nivelPresionNeumaticos = value;
                    NotificarObservers();
                }
            }
        }

        #endregion

        #region Metodos de la interfaz ISubject

        // Constructor que creara un medidor con los valores iniciales de las presiones
        public MedidorSensores(int nivelAceite, int nivelAgua, int nivelPresionNeumaticos)
        {
            _suscriptores = new ArrayList();
            this.nivelAceite = nivelAceite;
            this.nivelAgua = nivelAgua;
            this.nivelPresionNeumaticos = nivelPresionNeumaticos;
        }

        // Comprobamos si el observer se encuentra en la lista. En caso contrario,
        // lo incluye en la lista
        public void RegistrarObserver(IObserver o)
        {
            if (!_suscriptores.Contains(o))
                _suscriptores.Add(o);
        }

        // Comprobamos si el observer se encuentra en la lista. En caso afirmativo,
        // lo elimina de la lista
        public void EliminarObserver(IObserver o)
        {
            if (_suscriptores.Contains(o))
                _suscriptores.Remove(o);
        }

        // Recorre la lista de observers e invoca su metodo Update()
        public void NotificarObservers()
        {
            // Creamos un array con el estado del Subject
            int[] valores = { nivelAceite, nivelAgua, nivelPresionNeumaticos };

            // Recorremos todos los objetos suscritos (observers)
            foreach (var o in _suscriptores)
            {
                // Invocamos el metodo Update de cada observer, pasandole el array con el estado
                // del subject como parametro.
                // Cada observer ya hara lo que estime necesario con esa informacion.
                var observer = (IObserver)o;
                observer.Update(valores);
            }
        }

        #endregion
    }
}
