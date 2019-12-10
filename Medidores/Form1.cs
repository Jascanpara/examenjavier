using Medidores.Observer;
using Medidores.Subject;
using System;
using System.Windows.Forms;
using System.Timers;

namespace Medidores
{
    public partial class Form1 : Form
    {
        private readonly ISubject _sensores;
        private IObserver _display;
        public Form1()
        {
            InitializeComponent();
            _sensores = new MedidorSensores(100, 50, false);
            _display = new ObserverAlerta(_sensores);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            ActualizarLabel();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (((MedidorSensores)_sensores).Conectado == true)
            {
                Cargando();
            }
            else
            {
                Descargando();
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _display = new ObserverAlerta(_sensores);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _sensores.EliminarObserver(_display);
            button1.Enabled = true;
            button2.Enabled = false;
        }

        //btnDEsconectar
        private void Button4_Click(object sender, EventArgs e)
        {
            ((MedidorSensores)_sensores).Conectado = false;
            _display = new ObserverAlerta(_sensores);
            ActualizarLabel();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            ((MedidorSensores)_sensores).Conectado = true;
            _display = new ObserverAlerta(_sensores);
            ActualizarLabel();
        }

        private void LblBateria_Click(object sender, EventArgs e)
        {
            if (((MedidorSensores)_sensores).Conectado == true)
            {
                lblBateria.Text = "Conectado";
            }
            else
            {
                lblBateria.Text = "Desconectada";
            }
        }

        private void LblActividadBateria_Click(object sender, EventArgs e)
        {
            if (((MedidorSensores)_sensores).Conectado == true)
            {
                lblActividadBateria.Text = "Cargando";
            }
            else
            {
                lblActividadBateria.Text = "Descargando";
            }
        }

        private void LblProcentajeCarga_Click(object sender, EventArgs e)
        {
            lblProcentajeCarga.Text = ((MedidorSensores)_sensores).NivelBateria.ToString();
        }

        private void LblCarga_Click(object sender, EventArgs e)
        {
            lblCarga.Text = ((MedidorSensores)_sensores).NivelBateria.ToString();
        }

        public void ActualizarLabel()
        {
            lblCarga.Text = ((MedidorSensores)_sensores).NivelBateria.ToString();
            lblProcentajeCarga.Text = ((MedidorSensores)_sensores).NivelTiempo.ToString();
            if (((MedidorSensores)_sensores).Conectado == true)
            {
                lblActividadBateria.Text = "Cargando";
            }
            else
            {
                lblActividadBateria.Text = "Descargando";
            }
            if (((MedidorSensores)_sensores).Conectado == true)
            {
                lblBateria.Text = "Conectado";
            }
            else
            {
                lblBateria.Text = "Desconectada";
            }
        }

        public void Cargando()
        {
            ((MedidorSensores)_sensores).NivelBateria += 10;
            ((MedidorSensores)_sensores).NivelTiempo -= 10;
            ActualizarLabel();
        }

        public void Descargando()
        {
            ((MedidorSensores)_sensores).NivelBateria -= 10;
            ((MedidorSensores)_sensores).NivelTiempo += 10;
            ActualizarLabel();
        }
    }
}
