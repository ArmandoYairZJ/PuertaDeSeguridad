using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using Regla;

using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PuertaDeSeguridad
{
    public partial class Form1 : Form
    {


        SerialPort Port1;
        SerialPort Port2;
        bool IsClosed = false;
        bool operationInProgress = false;
        SQLServerClass Buscar;

        public Form1()
        {
            InitializeComponent();
            Port1 = new SerialPort("COM5", 9600);
            Port1.ReadTimeout = 500;

            Port2 = new SerialPort("COM11", 115200);
            Port2.ReadTimeout = 500;
            Buscar = new SQLServerClass();

            try
            {
                Port1.Open();
                Port2.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar con el puerto serial: " + ex.Message);
                MessageBox.Show("Error al conectar con el puerto serial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void EscucharAlSerial()
        {
            while (!IsClosed)
            {
                try
                {
                    string cadena = Port1.ReadLine();
                    txtbLaser.Invoke(new MethodInvoker(() =>
                    {
                        txtbLaser.Text = cadena;
                        Comparacion();
                     
                        tomarFotos();

                    }));


                }
                catch (TimeoutException) { }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer del puerto serial: " + ex.Message);
                    MessageBox.Show("Error al leer del puerto serial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EscucharAlSerial2()
        {
            while (!IsClosed)
            {

                try
                {
                    string cadena2 = Port2.ReadLine();
                    txtbCamara.Invoke(new MethodInvoker(() =>
                    {
                        txtbCamara.Text = cadena2;
                        Comparacion();
                   
                        tomarFotos();

                    }));



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer del puerto serial: " + ex.Message);

                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            if (Port1.IsOpen && Port2.IsOpen)
            {
                Thread Hilo = new Thread(EscucharAlSerial);
                Hilo.Start();

                Thread Hiloa = new Thread(EscucharAlSerial2);
                Hiloa.Start();


            }
            else
            {
                Console.WriteLine("El puerto serial no está abierto.");
                MessageBox.Show("El puerto serial no está abierto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
            if (Port1.IsOpen && Port2.IsOpen)
            {
                Port1.Close();
                Port2.Close();
                Port1.Dispose();
                Port2.Dispose();
            }

        }


        private void Comparacion()
        {
            string ValorLaser = txtbLaser.Text.Trim();

            if (!string.IsNullOrEmpty(ValorLaser) && !string.IsNullOrEmpty(valorRFID))
            {
                if (valorRFID == "0" && ValorLaser == "0")
                {
                    operationInProgress = true;
                    ApagarLaser(ValorLaser);
                    
                }
            }

        }

       

        private void ApagarLaser(string ap)
        {
            try
            {
                Port1.WriteLine(ap);
                MessageBox.Show("Laser apagado, reiniciando en 5 segundos.");
                valorRFID = null; 
                txbRFID.Invoke(new MethodInvoker(() =>
                {
                    txbRFID.Text = string.Empty;
                }));
                Task.Delay(5000).ContinueWith(_ =>
                {
                    operationInProgress = false;  
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer del puerto serial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void tomarFotos()
        {
            if (!operationInProgress)  
            {
                string ValorLaser = txtbLaser.Text.Trim();

                if (!string.IsNullOrEmpty(ValorLaser) && ValorLaser == "1")
                {
                    Port2.WriteLine(ValorLaser);
                }
            }
        }

        public string valorRFID;

        public void LeerTarjeta(string data)
        {

            if (long.TryParse(data, out long valorLector))
            {
                if (Buscar.BuscarAlumno(valorLector))
                {
                    valorRFID = "0";
                    txbRFID.Text = "0";
                    MessageBox.Show("Acceso permitido");

                    txbRFID.Text = string.Empty;
                }
                else
                {
                    valorRFID = "1";
                    txbRFID.Text = "1";
                    MessageBox.Show("El valor no es correcto");
                }
            }
            else
            {
                valorRFID = "1";
                txbRFID.Text = "1";
                MessageBox.Show("El valor ingresado no es un número válido.");
            }
        }

        private void txbRFID_KeyDown(object sender, KeyEventArgs e)
        {0007662670
                0007662670
                0007662670

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LeerTarjeta(txbRFID.Text.Trim());
                Comparacion(); 
            }
        }
    }
}
