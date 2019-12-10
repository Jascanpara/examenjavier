using Medidores.Subject;
using System.Windows.Forms;

namespace Medidores.Observer
{
    public class ObserverAlerta : IObserver
    {
        // Atributos que modelan el estado
        public int nivelBateria;
        public int nivelTiempo;
        public bool cargando;
        public bool conectado;
        public static int aux = 10;

        // Subject al que se encuentra suscrito el observer
        private ISubject subject;

        // El constructor suscribira el observer al subject
        public ObserverAlerta(ISubject subject)
        {
            this.subject = subject;
            subject.RegistrarObserver(this);
        }

        public void Concecion(bool coneccion)
        {
            if (coneccion==true)
            {
                Cargar(nivelBateria);
                cargando = true;
            }
            else
            {
                Descargar(nivelBateria);
                cargando = false;
            }
        }

        public int Cargar(int nivelBateria)
        {
            if (nivelBateria>=100)
            {
                return nivelBateria;
            }
            else
            {
                return nivelBateria += aux;
            }
        }

        public int Descargar(int nivelBateria)
        {
            if (nivelBateria <= 0)
            {
                return nivelBateria;
            }
            else
            {
                return nivelBateria -= aux;
            }
        }

        public void Update(object o)
        {
            // Comprobamos el tipo del objeto recibido como parametro
            int[] arrayInt = null;
            if (o.GetType() == typeof(int[]))
                arrayInt = (int[])o;

            // Si es del tipo esperado (int[]) y del tamano esperado (2), actualizamos los
            // atributos
            if ((arrayInt != null) && (arrayInt.Length == 2))
            {
                nivelBateria = arrayInt[0];
                nivelTiempo = arrayInt[1];

                // Comprobamos que los valores no exceden los limites
                ComprobarBateria();
                ComprobarTiempo();
            }
        }

        // Metodo que comprueba los niveles de bateria
        private void ComprobarBateria()
        {
            if (nivelBateria==100)
            {
                MessageBox.Show($"Bateria complatamente cargada 100%");
            }
            if (nivelBateria == 0)
            {
                MessageBox.Show($"Bateria complatamente descargada 0%");
            }
        }

        // Metodo que comprueba los niveles de tiempo
        private void ComprobarTiempo()
        {
            if (nivelTiempo==100)
            {
                MessageBox.Show($"Tiempo de carga finalizado 100s");
            }
            if(nivelTiempo == 0)
            {
                MessageBox.Show($"Teimpo de carga 0s");
            }
        }
    }
}
