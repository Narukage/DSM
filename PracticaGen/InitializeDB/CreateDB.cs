
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.CAD.Practica;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // Insert the initilizations of entities using the CEN classes

                //creamos unos productos
                /* BebidaCEN producto1 = new BebidaCEN ();
                 * PredefinidaCEN producto2 = new PredefinidaCEN ();
                 * ComplementoCEN producto3 = new ComplementoCEN ();
                 * BebidaCEN producto4 = new BebidaCEN ();
                 * LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
                 *
                 *
                 * AdminCEN admin1 = new AdminCEN ();
                 * // String iadmin = admin1.New_ ("el_admin@alu.ua.es", "Senyor tomate", "1234", DateTime.Today, 647003256);
                 * UsuarioCEN user1 = new UsuarioCEN ();
                 *
                 * producto1.New_ (float.Parse ("1.0"), "Fanta de limon", "foto de la fanta");
                 * producto2.New_ (float.Parse ("6.0"), "Pizza de cosas", "foto de pizza", 1, 1, "Es una deliciosa pizza de cosas");
                 * producto3.New_ (float.Parse ("2.0"), "Alitas de pollos", "foto de pollo");
                 * int p4id = producto4.New_ (float.Parse ("1.0"), "Aguita fresca nene", "foto un agua");
                 *
                 *
                 *
                 *
                 * //creamos algun user
                 *
                 * DireccionCEN dirCEN = new DireccionCEN ();
                 * int id = dirCEN.New_ ("Alicant", "Alicante", "Calle de la amargura", 06732, 3);
                 *
                 * IList<DireccionEN> direcciones = new List<DireccionEN>();
                 * direcciones.Add (dirCEN.get_IDireccionCAD ().ReadOIDDefault (id));
                 *
                 *
                 *
                 * // user1.New_ ("tomate@alu.ua.es", "Senyor tommate", "12634", DateTime.Today, 647003256);
                 *
                 * IngredienteCEN ing1 = new IngredienteCEN ();
                 * int idg = ing1.New_ (0.2, "Mozzarella", "foto1");
                 * IngredienteCEN ing2 = new IngredienteCEN ();
                 * int idg2 = ing2.New_ (0.4, "Olivas", "foto2");
                 * IngredienteCEN ing3 = new IngredienteCEN ();
                 * int idg3 = ing3.New_ (0.15, "Jamon", "foto3");
                 *
                 *
                 *
                 * PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum h = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                 * PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum x = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                 * PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum v = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.contrarreembolso;
                 * PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum w = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.paypal;
                 * PedidoCEN pedidoCEN = new PedidoCEN ();
                 * int id2 = pedidoCEN.New_ (h, DateTime.Today, 1.5, v, "tomate@alu.ua.es");
                 * //admin1.AnyadirPedido(1.5, v, DateTime.Today, h, "tomate@alu.ua.es");
                 * x = pedidoCEN.ConsultarEstado (id2);
                 * Console.WriteLine (x);
                 * pedidoCEN.SeleccionarFormaPago (id2, w);
                 *
                 * Console.WriteLine (pedidoCEN.GetTipoPago (id2));
                 *
                 * PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum val = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.sin_valorar;
                 * PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum val2 = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.excelente;
                 * int idmil = lineaPedidoCEN.New_ (p4id, id2, 5, val);
                 *
                 * lineaPedidoCEN.ValorarLinea (idmil, val2);
                 *
                 *
                 * //Console.WriteLine("El pedido: "+ pedidoCEN);*/


                UsuarioCEN usuario1 = new UsuarioCEN ();
                usuario1.New_ ("alberto@email.com", "Alberto", "123456", DateTime.Today, 647556372, DateTime.Today);
                RegistradoCEN usuario2 = new RegistradoCEN ();
                usuario2.New_ ("fer@email.com", "Fernando", "123456", DateTime.Today, 647556372, DateTime.Today);
                RegistradoCEN usuario3 = new RegistradoCEN ();
                usuario3.New_ ("juanluisio@email.com", "Juanlu", "123456", DateTime.Today, 647552372, DateTime.Today);
                RegistradoCEN usuario4 = new RegistradoCEN ();
                DateTime date1 = new DateTime (2008, 3, 1, 7, 0, 0);
                usuario4.New_ ("felipe@email.com", "Felipe", "123456", DateTime.Today, 647556375, date1);
                DateTime date2 = new DateTime (2017, 10, 11, 7, 0, 0);

                IncidenciaCEN inc1 = new IncidenciaCEN ();
                inc1.New_ ("Mi pizza esta mala", PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum.pendiente, "alberto@email.com", DateTime.Today);
                IncidenciaCEN inc2 = new IncidenciaCEN ();
                inc2.New_ ("Mi pizza esta pocha", PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum.pendiente, "alberto@email.com", DateTime.Today);

                Console.WriteLine ("Numero de incidentes este mes: " + inc1.IncidenciasMes (date2));
                //inc1.IncidenciasMes(date2);
                Console.WriteLine ("Nuevos usuarios este mes :" + usuario1.UsuariosMes (date2));

                Console.WriteLine (usuario1.BuscarUsuario ("ber") [0].Telefono);

                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum h = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum x = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum v = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.contrarreembolso;
                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum w = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.paypal;
                PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.buena;
                PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum tipo = PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum.pizza;
                PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamanyo = PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.familiar;
                PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masa = PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.clasica;
                PedidoCEN pedidoCEN = new PedidoCEN ();
                int id2 = pedidoCEN.New_ (h, date1, 1.5, v, "alberto@email.com");
                PedidoCEN pedido = new PedidoCEN ();
                int id8 = pedido.New_ (h, date1, 2.8, v, "alberto@email.com");

                IList <PedidoEN> listica = pedido.DevolverPedidosUsuario ("alberto@email.com");

                Console.WriteLine ("esto es el precio total" + listica [0].PrecioTotal);

                CodigoCEN codigoCEN = new CodigoCEN ();
                int cod = codigoCEN.New_ (20, tipo, "34005");

                PersonalizableCEN pro1 = new PersonalizableCEN ();
                PersonalizableCEN pro2 = new PersonalizableCEN ();
                PersonalizableCEN pro3 = new PersonalizableCEN ();


                int pr1 = pro1.New_ (1.5, "la ostia", "el culo", 0, tamanyo, masa);
                int pr2 = pro2.New_ (1.9, "la pene", "el culo", 0, tamanyo, masa);
                int pr3 = pro3.New_ (1.5, "la pito", "el culo", 0, tamanyo, masa);

                LineaPedidoCEN li1 = new LineaPedidoCEN ();
                li1.New_ (pr1, id2, 8, valor);

                LineaPedidoCEN li2 = new LineaPedidoCEN ();
                li2.New_ (pr2, id2, 1, valor);
                LineaPedidoCEN li3 = new LineaPedidoCEN ();
                li3.New_ (pr3, id2, 5, valor);








                pedidoCEN.AnyadirCodigo (id2, cod);
                pedido.AnyadirCodigo (id8, cod);
                ;



                long total = pedidoCEN.GetCodigosActivados ();

                Console.WriteLine ("Estos son los codigos que hay activados:" + total);

                Console.WriteLine (pedidoCEN.PedidosMensuales (date2));
                PracticaGenNHibernate.CP.Practica.PedidoCP pedidoCP = new PracticaGenNHibernate.CP.Practica.PedidoCP ();
                pedidoCP.ConfirmarPedido (id2);
                foreach (PersonalizableEN res in pro1.TopVentas ()) {
                        Console.Write (res.Nombre + ": ");
                        Console.WriteLine (res.NumVeces);
                }









                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
