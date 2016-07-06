using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyP1
{
    public class Program
    {
        private string _matricula;
        public string matricula
        {
            get
            {
                return _matricula;
            }
            set
            {
                _matricula = value;
            }
        }

        private DateTime _fecha;
        public DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        private DateTime _hora;
        public DateTime hora
        {
            get
            {
                return _hora;
            }
            set
            {
                _hora = value;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.Clear();

            Console.Write("Validación Pico y Placa");
            Console.Write(Environment.NewLine);
            program.matricula = program.ValidarMatricula();
            program.fecha = program.ValidarFecha();
            program.hora = program.ValidarHora();
            program.ValidarPicoPlaca();
            Console.Write(Environment.NewLine);
            Console.Write("Presione una tecla para salir...");
            Console.ReadKey();
        }

        public string ValidarMatricula()
        {
            string entrada;
            bool resultado;
            string pattern = @"^[a-zA-Z]{3}-\d{3,4}$";
            while (true)
            {
                Console.Write("Ingrese la matricula del vehiculo (ejemplo: AAB-0000)");
                Console.Write(Environment.NewLine);
                entrada = Console.ReadLine();                
                resultado = System.Text.RegularExpressions.Regex.IsMatch(entrada, pattern);
                if (resultado == true)
                {
                    break;
                }
                else
                {
                    Console.Write("Ingreso incorrecto");
                    Console.Write(Environment.NewLine);
                }
            }
            return entrada;
        }

        public DateTime ValidarFecha()
        {
            DateTime fecha;
            bool resultado;
            string[] format = new string[] { "dd-MM-yyyy" };
            while (true)
            {
                Console.Write("Ingrese la fecha (ejemplo: 31-12-1999)");
                Console.Write(Environment.NewLine);
                resultado = DateTime.TryParseExact(Console.ReadLine(), format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.NoCurrentDateDefault, out fecha);
                if (resultado == true)
                {
                    break;
                }
                else
                {
                    Console.Write("Fecha no valida");
                    Console.Write(Environment.NewLine);
                }
            }
            return fecha;
        }

        public DateTime ValidarHora()
        {
            DateTime hora;
            bool resultado;
            string[] format = new string[] { "HH:mm" };
            while (true)
            {
                Console.Write("Ingrese la hora (ejemplo: 23:59)");
                Console.Write(Environment.NewLine);
                resultado = DateTime.TryParseExact(Console.ReadLine(), format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.NoCurrentDateDefault, out hora);
                if (resultado == true)
                {
                    break;
                }
                else
                {
                    Console.Write("Hora no valida");
                    Console.Write(Environment.NewLine);
                }
            }
            return hora;
        }

        public void ValidarPicoPlaca()
        {
            //ultimo digito de la placa
            string ultDig = matricula.Substring(matricula.Length - 1, 1);
            int UtimoDigito = Convert.ToInt16(ultDig);

            //Horarios del Pico y Placa - Quito
            //obtenido de la pagina
            //http://sinmiedosec.com/horarios-pico-y-placa-quito-ecuador/

            string time;
            time = "07:00";
            DateTime HoraIni1 = DateTime.Parse(time);
            time = "09:30";
            DateTime HoraFin1 = DateTime.Parse(time);
            time = "16:00";
            DateTime HoraIni2 = DateTime.Parse(time);
            time = "19:30";
            DateTime HoraFin2 = DateTime.Parse(time);
            //Formato de hora ingresado por el usuario
            DateTime Horausuario = DateTime.Parse(hora.ToString("HH:mm"));

            //Verificando si la hora ingresada por el usuario esta dentro del rango de pico y placa
            if ((Horausuario > HoraIni1 && Horausuario < HoraFin1) 
                || (Horausuario > HoraIni2 && Horausuario < HoraFin2))
            {
                //Verificando el dia de la semana
                switch (fecha.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        Console.WriteLine("Lunes");
                        if (UtimoDigito == 1 || UtimoDigito == 2)
                        {
                            MsgNOCircula();
                        }
                        else
                        {
                            MsgSICircula();
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        Console.WriteLine("Martes");
                        if (UtimoDigito == 3 || UtimoDigito == 4)
                        {
                            MsgNOCircula();
                        }
                        else
                        {
                            MsgSICircula();
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        Console.WriteLine("Miercoles");
                        if (UtimoDigito == 5 || UtimoDigito == 6)
                        {
                            MsgNOCircula();
                        }
                        else
                        {
                            MsgSICircula();
                        }
                        break;
                    case DayOfWeek.Thursday:
                        Console.WriteLine("Jueves");
                        if (UtimoDigito == 7 || UtimoDigito == 8)
                        {
                            MsgNOCircula();
                        }
                        else
                        {
                            MsgSICircula();
                        }
                        break;
                    case DayOfWeek.Friday:
                        Console.WriteLine("Viernes");
                        if (UtimoDigito == 9 || UtimoDigito == 0)
                        {
                            MsgNOCircula();
                        }
                        else
                        {
                            MsgSICircula();
                        }
                        break;
                    default:
                        MsgSICircula();
                        break;
                }
            }
            else //No esta dentro del rango de la hora
            {
                MsgSICircula();
            }

        }

        private void MsgNOCircula()
        {
            Console.Write(Environment.NewLine);
            Console.Write("NO Puede circular");
            Console.Write(Environment.NewLine);
        }

        private void MsgSICircula()
        {
            Console.Write(Environment.NewLine);
            Console.Write("SI Puede circular");
            Console.Write(Environment.NewLine);
        }
    }
}
