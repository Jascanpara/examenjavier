using Medidores.Observer;
using System.Collections;

namespace Medidores.Subject
{
    public class MedidorSensores : ISubject
    {
        #region Estado

        // Atributos que modelan el estado
        private int nivelBateria;
        private int nivelTiempo;
        private bool conectado;

        #endregion

        // Listado de observers
        private readonly IList _suscriptores;

        #region Properties

        public bool Conectado
        {
            get => conectado;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (conectado != value)
                {
                    conectado = value;
                    NotificarObservers();
                }
            }
        }

        public int NivelBateria
        {
            get => nivelBateria;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (nivelBateria != value)
                {
                    nivelBateria = value;
                    NotificarObservers();
                }
            }
        }

        public int NivelTiempo
        {
            get => nivelTiempo;

            // Cada vez que se modifique el estado, se invocara el metodo NotificarObservers()
            set
            {
                if (nivelTiempo != value)
                {
                    nivelTiempo = value;
                    NotificarObservers();
                }
            }
        }

        #endregion

        #region Metodos de la interfaz ISubject

        // Constructor que creara un medidor con los valores iniciales de las presiones
        public MedidorSensores(int nivelBateria, int nivelTiempo, bool conectado)
        {
            _suscriptores = new ArrayList();
            this.nivelBateria = nivelBateria;
            this.nivelTiempo = nivelTiempo;
            this.conectado = conectado;
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
            int[] valores = { nivelBateria, nivelTiempo };

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
