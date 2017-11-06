
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
                IngredienteCEN ing1 = new IngredienteCEN ();
                int idg = ing1.New_ (0.2, "Mozzarella", "foto1");
                IngredienteCEN ing2 = new IngredienteCEN ();
                int idg2 = ing2.New_ (0.4, "Olivas", "foto2");
                IngredienteCEN ing3 = new IngredienteCEN ();
                int idg3 = ing3.New_ (0.15, "Jamon", "foto3");

                PersonalizableCEN pizza = new PersonalizableCEN ();

                PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum d = PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.familiar;

                PracticaGenNHibernate.Enumerated.Practica.TipomasaEnum e = PracticaGenNHibernate.Enumerated.Practica.TipomasaEnum.Clasica;
                int id = pizza.New_ (3.0, "pizza personalizada", "suuuh foto", d, e);

                System.Collections.Generic.IList<int> lista = new System.Collections.Generic.List<int>();
                IngredienteEN uno = new IngredienteCAD ().ReadOID (idg);
                lista.Add (idg);
                pizza.AnaydirIngrediente (id, lista);
                pizza.AnaydirIngrediente (id, lista);

                Console.WriteLine ("El precio de su pizza es " + Math.Round (pizza.get_IPersonalizableCAD ().ReadOIDDefault (id).Precio, 2));





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
