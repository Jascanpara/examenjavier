using Medidores.Observer;
using Medidores.Subject;
using System;
using System.Windows.Forms;

namespace Medidores
{
    public partial class Form1 : Form
    {
        private readonly ISubject _sensores;
        private IObserver _display;
        public Form1()
        {
            InitializeComponent();
            _sensores = new MedidorSensores((int)numericUpDown1.Value, (int)numericUpDown3.Value, (int)numericUpDown2.Value);
            _display = new ObserverAlerta(_sensores);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ((MedidorSensores) _sensores).NivelAceite = (int) numericUpDown1.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ((MedidorSensores)_sensores).NivelAgua = (int)numericUpDown3.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ((MedidorSensores)_sensores).NivelPresionNeumaticos = (int)numericUpDown2.Value;
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
    }
}
