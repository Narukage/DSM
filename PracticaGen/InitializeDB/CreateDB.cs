
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
                BebidaCEN producto1 = new BebidaCEN ();
                PredefinidaCEN producto2 = new PredefinidaCEN ();
                ComplementoCEN producto3 = new ComplementoCEN ();
                BebidaCEN producto4 = new BebidaCEN ();

                producto1.New_ (float.Parse ("1.0"), "Fanta de limon", "foto de la fanta");
                producto2.New_ (float.Parse ("6.0"), "Pizza de cosas", "foto de pizza", 1, 1, "Es una deliciosa pizza de cosas");
                producto3.New_ (float.Parse ("2.0"), "Alitas de pollos", "foto de pollo");
                producto4.New_ (float.Parse ("1.0"), "Aguita fresca nene", "foto un agua");


                //creamos algun user

                DireccionCEN dirCEN = new DireccionCEN ();
                int id = dirCEN.New_ ("Alicant", "Alicante", "Calle de la amargura", 06732, 3);

                IList<DireccionEN> direcciones = new List<DireccionEN>();
                direcciones.Add (dirCEN.get_IDireccionCAD ().ReadOIDDefault (id));

                AdminCEN admin1 = new AdminCEN ();
                String iadmin = admin1.New_ ("el_admin@alu.ua.es", "Senyor tomate", "1234", DateTime.Today, 647003256);
                UsuarioCEN user1 = new UsuarioCEN ();

                String user = user1.New_ ("tomate@alu.ua.es", "Senyor tommate", "12634", DateTime.Today, 647003256, admin1.get_IAdminCAD ().ReadOIDDefault (iadmin).Email, direcciones);

                IngredienteCEN ing1 = new IngredienteCEN ();
                int idg = ing1.New_ (0.2, "Mozzarella", "foto1");
                IngredienteCEN ing2 = new IngredienteCEN ();
                int idg2 = ing2.New_ (0.4, "Olivas", "foto2");
                IngredienteCEN ing3 = new IngredienteCEN ();
                int idg3 = ing3.New_ (0.15, "Jamon", "foto3");

                PersonalizableCEN hola = new PersonalizableCEN ();
                int a = hola.New_ (3.0, "FFF", "FFF", 0, 0);
                IList<int> cosas = new List<int>();
                cosas.Add (idg);
                hola.AnaydirIngrediente (a, cosas);
                Console.WriteLine(hola.ReadOID(a).Ingrediente[0]);

                /*
                 PedidoCEN h = new PedidoCEN ();
                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum j = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum s = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.contrarreembolso;

                int id_pedido = h.New_ (j, DateTime.Today, 3.4, s, user, iadmin);
                Console.Write("El estado actuale es: ");
                Console.WriteLine(h.ReadOID (id_pedido).Confirmado);
                Console.WriteLine("Lo confirmamos");
                h.ConfirmarPedido(id_pedido);
                Console.WriteLine("Ahora el estado es:" + h.ReadOID(id_pedido).Confirmado);*/



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
