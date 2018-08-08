using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppAgendaContactos
{
    public delegate void MiDelegado(string s);
    class Program
    {

        public static Contacto c = new Contacto();
        public static List<Contacto> Contactos = new List<Contacto>();
        static MiDelegado Delega = Seleccion;
        public static int n = 0;
        public static bool activo = true;

        static void Main()
        {
            try
            {

                Console.Clear();
                //pre-Cargando usuarios
                while (activo)
                {
                    Contactos.Add(new Contacto() { Id = (n += 1), Nombre = "Yonatan Avila", Telefono = "829-923-7131", Email = "avila012@gmail.com" });
                    Contactos.Add(new Contacto() { Id = (n += 1), Nombre = "Ramon Dotel", Telefono = "829-923-7132", Email = "avila013@gmail.com" });
                    Contactos.Add(new Contacto() { Id = (n += 1), Nombre = "Javier Mateo", Telefono = "829-923-7133", Email = "avila014@gmail.com" });
                    Contactos.Add(new Contacto() { Id = (n += 1), Nombre = "Iliana Santana", Telefono = "829-923-7134", Email = "avila015@gmail.com" });
                    activo = false;
                }


                MPrincipal();

                Console.Write("Ingrese una opcion: ");
                Seleccion(Console.ReadLine());
                Console.ReadKey();

            }
            catch (Exception)
            {
                Console.WriteLine("El Programa ha presentado problemas, contacte al Administrador de la aplicacion.");
                Console.WriteLine("La aplicación finalizará de manera automatica al presionar una tecla.");
                Console.ReadKey();
            }
        }

        public static void MPrincipal()
        {
            Console.Clear();
            Console.WriteLine("<<<AGENDA CONTACTOS>>>");
            Console.WriteLine();
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Mostrar todos los contactos");
            Console.WriteLine("3. Buscar Contacto por ID");
            Console.WriteLine("4. Buscar Contacto por Nombre");
            Console.WriteLine();            
            Console.WriteLine("5. Salir");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void Seleccion(string opcion)
        {
            Console.Clear();
            //string opcion = "1";
            switch (opcion)
            {
                case "1":
                    {
                        string _nombre, _telefono, _email;

                        Console.WriteLine("<<<Agregar Contacto>>>");
                        Console.WriteLine();
                        Console.Write("Nombre: ");
                        _nombre = Console.ReadLine();
                        Console.Write("Telefono: ");
                        _telefono = Console.ReadLine();
                        Console.Write("Correo: ");
                        _email = Console.ReadLine();

                        Contactos.Add(new Contacto() { Id = (n += 1), Nombre = _nombre, Telefono = _telefono, Email = _email });
                        Console.WriteLine();
                        Console.WriteLine("Contacto ha sido Agregado. Ahora Regresará a la pantalla Inicial.");
                        Console.ReadKey();
                        Main();
                    }
                    break;

                case "2":
                    Mostrar();
                    break;

                case "3":
                    { //Busqueda por ID
                        try
                        {
                            Console.Clear();
                            Console.Write("Introduzca el ID a buscar: ");
                            var resContacto = BuscarPorId(int.Parse(Console.ReadLine()));

                            Console.WriteLine($"{resContacto.Id} | {resContacto.Nombre} | {resContacto.Telefono} | {resContacto.Email}");

                            Console.WriteLine();
                            Console.Write("Que accion desea realizar: 1. Editar(F1), 2. Eliminar(F2), 3. Salir(F3)");
                            string seleccion = Console.ReadLine();

                            //Editar o Eliminar
                            switch (seleccion)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("<<<Editar Contacto>>>");
                                        Console.WriteLine();
                                        Console.Write("Nombre: ");
                                        resContacto.Nombre = Console.ReadLine();
                                        Console.Write("Telefono: ");
                                        resContacto.Telefono = Console.ReadLine();
                                        Console.Write("Correo: ");
                                        resContacto.Email = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Contacto ha sido editado");
                                        Console.ReadKey();

                                        Delega.Invoke("3");

                                    }
                                    break;

                                case "2":
                                    {
                                        try
                                        {
                                            Contactos.Remove(resContacto);
                                            Console.WriteLine("<<<Contacto ha sido Eliminado>>>");
                                            Console.WriteLine();
                                            Console.ReadKey();

                                            Delega.Invoke("2");
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("El registro no existe en la Lista.");
                                            Console.ReadKey();
                                            Main();
                                        }
                                       
                                    }
                                    break;

                                case "3":
                                    Main();
                                    break;

                                default:
                                    break;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("El registro no existe en la Lista o ya fué eliminado.");
                            Console.ReadKey();
                            Delega.Invoke("3");
                        }
                    }
                    break;

                case "4":
                    {
                        try
                        {

                            Console.Clear();
                            Console.Write("Introduzca el Nombre a buscar: ");
                            var resContacto = BuscarPorNombre(Console.ReadLine());

                            Console.WriteLine($"{resContacto.Id} | {resContacto.Nombre} | {resContacto.Telefono} | {resContacto.Email}");

                            Console.WriteLine();
                            Console.Write("Que accion desea realizar: 1. Editar(F1), 2. Eliminar(F2), 3. Salir(F3)");
                            string seleccion = Console.ReadLine();

                            //Editar o Eliminar
                            switch (seleccion)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("<<<Editar Contacto>>>");
                                        Console.WriteLine();
                                        Console.Write("Nombre: ");
                                        resContacto.Nombre = Console.ReadLine();
                                        Console.Write("Telefono: ");
                                        resContacto.Telefono = Console.ReadLine();
                                        Console.Write("Correo: ");
                                        resContacto.Email = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.WriteLine("Contacto ha sido editado");
                                        Console.ReadKey();

                                        Delega.Invoke("3");

                                    }
                                    break;

                                case "2":
                                    {
                                        try
                                        {
                                            Contactos.Remove(resContacto);
                                            Console.WriteLine("<<<Contacto ha sido Eliminado>>>");
                                            Console.WriteLine();
                                            Console.ReadKey();

                                            Delega.Invoke("2");
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("El registro no existe en la Lista.");
                                            Console.ReadKey();
                                            Main();
                                        }

                                    }
                                    break;

                                case "3":
                                    Main();
                                    break;

                                default:
                                    break;
                            }

                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("El registro no existe en la Lista o ya fué eliminado.");
                            Console.ReadKey();
                            Delega.Invoke("3");
                        }
                    }
                    break;

                case "5":
                    Environment.Exit(0);
                    break;


                default:
                    break;
            }
        }


        //MUESTRA LA LISTA DE CONTACTOS
        public static void Mostrar()
        {
            try
            {
                Console.WriteLine();
                foreach (var cont in Contactos)
                {
                    Console.WriteLine(cont.Id.ToString() + " | " + cont.Nombre.ToString() + " | " + cont.Telefono.ToString() + " | " +  cont.Email.ToString());
                }
                Console.ReadKey();
                Main();
            }
            catch (Exception e) 
            {
                Console.WriteLine("El error presentado es:" + e.Message);
                throw ;
            }
        }


        //PERMITE REALIZAR LA BUSQUEDA POR ID CONTACTO
        public static Contacto BuscarPorId(int id)
        {
            return Contactos.SingleOrDefault(x => x.Id == id);
        }


        //PERMITE REALIZAR BUSQUEDA POR NOMBRE CONTACTO
        public static Contacto BuscarPorNombre(string nombre)
        {
            return Contactos.SingleOrDefault(x => x.Nombre == nombre);
            
        }
    }
}