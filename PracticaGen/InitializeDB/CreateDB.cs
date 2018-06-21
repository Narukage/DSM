
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

                

                Console.WriteLine ("---- Declaramos nuestra base de datos ----");

                Console.WriteLine ("--- Establecemos nuestros tamanyos de pizzas, estados de pedidos y los tipos de masas... ---");
                Console.WriteLine ();


                PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamFamiliar = PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.familiar;
                PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamNormal = PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.normal;
                PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamPequenya = PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.pequenya;

                PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masaExtraFina = PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.extra_fina;
                PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masaClasica = PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.clasica;
                PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masaGruesa = PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.gruesa;
                PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masaQueso = PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.rellena_de_queso;

                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estadoPedPendiente = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente;
                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estadoPedRechazado = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.rechazado;
                PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estadoPedRecibido = PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.recibido;

                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum pagoContrarrembolso = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.contrarreembolso;
                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum pagoPaypal = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.paypal;
                PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum pagoTarjeta = PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.tarjeta;


                Console.WriteLine ("-- Los tamanyos de pizza y los tipos de masa se han cargado correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("--- Declaramos nuestros productos y usuarios ---");
                Console.WriteLine ();


                BebidaCEN bebida1 = new BebidaCEN ();
                BebidaCEN bebida2 = new BebidaCEN ();
                BebidaCEN bebida3 = new BebidaCEN ();
                BebidaCEN bebida4 = new BebidaCEN ();
                BebidaCEN bebida5 = new BebidaCEN ();

                int[] idBebidas = new int [5];

                Console.WriteLine ("-- Bebidas declaradas correctamente! --");


                ComplementoCEN complem1 = new ComplementoCEN ();
                ComplementoCEN complem2 = new ComplementoCEN ();
                ComplementoCEN complem3 = new ComplementoCEN ();
                ComplementoCEN complem4 = new ComplementoCEN ();
                ComplementoCEN complem5 = new ComplementoCEN ();

                int[] idComplementos = new int [5];

                Console.WriteLine ("-- Complementos declarados correctamente! --");


                PredefinidaCEN pizzaPred1 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred2 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred3 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred4 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred5 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred6 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred7 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred8 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred9 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred10 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred11 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred12 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred13 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred14 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred15 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred16 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred17 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred18 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred19 = new PredefinidaCEN ();
                PredefinidaCEN pizzaPred20 = new PredefinidaCEN ();

                int[] idPizzasPred = new int [20];


                Console.WriteLine ("-- Pizzas predefinidas declaradas correctamente! --");



                UsuarioCEN usuRegist1 = new UsuarioCEN ();
                UsuarioCEN usuRegist2 = new UsuarioCEN ();
                UsuarioCEN usuRegist3 = new UsuarioCEN ();
                UsuarioCEN usuRegist4 = new UsuarioCEN ();
                UsuarioCEN usuRegist5 = new UsuarioCEN ();




                int[] idUsuRegist = new int [5];

                Console.WriteLine ("-- Usuarios registrados declarados correctamente! --");



                PedidoCEN ped1 = new PedidoCEN ();
                PedidoCEN ped2 = new PedidoCEN ();
                PedidoCEN ped3 = new PedidoCEN ();
                PedidoCEN ped4 = new PedidoCEN ();
                PedidoCEN ped5 = new PedidoCEN ();

                int[] idPedidos = new int [5];

                Console.WriteLine ("-- Pedidos declarados correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();




                Console.WriteLine ("---- Inicializamos nuestras bebidas ----");
                Console.WriteLine ();


                idBebidas [0] = bebida1.New_ (0.75, "Coca Cola 0.5 L", "../Images/productos/pizzas_predefinidas/cocacola.png", 0);
                idBebidas [1] = bebida2.New_ (1.00, "Agua 0.5 L", "../Images/productos/pizzas_predefinidas/agua.jpg", 0);
                idBebidas [2] = bebida3.New_ (0.80, "Fanta Naranja 0.5 L", "../Images/productos/pizzas_predefinidas/fanta_naranja.png", 0);
                idBebidas [3] = bebida4.New_ (0.80, "Fanta Limon 0.5 L", "../Images/productos/pizzas_predefinidas/fanta_limon.png", 0);
                idBebidas [4] = bebida5.New_ (0.90, "Sprite 0.5 L", "../Images/productos/pizzas_predefinidas/sprite.jpg", 0);


                Console.WriteLine ("-- Bebidas inicializadas correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();


                Console.WriteLine ("---- Inicializamos nuestros complementos ----");
                Console.WriteLine ();


                idComplementos [0] = complem1.New_ (4.00, "Patatas Fritas", "../Images/productos/pizzas_predefinidas/patatas_fritas.jpg", 0);
                idComplementos [1] = complem2.New_ (5.00, "Nuggets", "../Images/productos/pizzas_predefinidas/nuggets.png", 0);
                idComplementos [2] = complem3.New_ (4.50, "Aros de Cebolla", "../Images/productos/pizzas_predefinidas/aros_cebolla.png", 0);
                idComplementos [3] = complem4.New_ (4.50, "Patatas Bravas", "../Images/productos/pizzas_predefinidas/patatas_bravas.jpg", 0);
                idComplementos [4] = complem5.New_ (6.00, "Patatas Fritas Deluxe", "../Images/productos/pizzas_predefinidas/patatas_deluxe.jpg", 0);


                Console.WriteLine ("-- Complementos inicializados correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("---- Inicializamos nuestras pizzas predefinidas ----");
                Console.WriteLine ();


                idPizzasPred [0] = pizzaPred1.New_ (5.00, "Pizza 4 Quesos Pequenya Clasica", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamPequenya, masaClasica, "Deliciosa pizza para aquellos a los que les encante el queso.");
                idPizzasPred [1] = pizzaPred2.New_ (7.00, "Pizza 4 Quesos Normal Clasica", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamNormal, masaClasica, "Deliciosa pizza para aquellos a los que les encante el queso.");
                idPizzasPred [2] = pizzaPred3.New_ (8.00, "Pizza 4 Quesos Familiar Clasica", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamFamiliar, masaClasica, "Deliciosa pizza para aquellos a los que les encante el queso.");

                idPizzasPred [3] = pizzaPred4.New_ (5.30, "Pizza 4 Quesos Pequenya Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamPequenya, masaExtraFina, "Deliciosa pizza para aquellos a los que les encante el queso.");
                idPizzasPred [4] = pizzaPred5.New_ (7.30, "Pizza 4 Quesos Normal Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamNormal, masaExtraFina, "Deliciosa pizza para aquellos a los que les encante el queso.");
                idPizzasPred [5] = pizzaPred6.New_ (8.30, "Pizza 4 Quesos Familiar Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_4_quesos.png", 0, tamFamiliar, masaExtraFina, "Deliciosa pizza para aquellos a los que les encante el queso.");

                idPizzasPred [6] = pizzaPred7.New_ (5.00, "Pizza Barbacoa Pequenya Clasica", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamPequenya, masaClasica, "La mejor salsa barbacoa que puedes probar");
                idPizzasPred [7] = pizzaPred8.New_ (7.00, "Pizza Barbacoa Normal Clasica", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamNormal, masaClasica, "La mejor salsa barbacoa que puedes probar");
                idPizzasPred [8] = pizzaPred9.New_ (8.00, "Pizza Barbacoa Familiar Clasica", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamFamiliar, masaClasica, "La mejor salsa barbacoa que puedes probar");

                idPizzasPred [9] = pizzaPred10.New_ (5.30, "Pizza Barbacoa Pequenya Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamPequenya, masaExtraFina, "La mejor salsa barbacoa que puedes probar");
                idPizzasPred [10] = pizzaPred11.New_ (7.30, "Pizza Barbacoa Normal Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamNormal, masaExtraFina, "La mejor salsa barbacoa que puedes probar");
                idPizzasPred [11] = pizzaPred12.New_ (8.30, "Pizza Barbacoa Familiar Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_barbacoa.png", 0, tamFamiliar, masaExtraFina, "La mejor salsa barbacoa que puedes probar");

                idPizzasPred [12] = pizzaPred13.New_ (5.00, "Pizza York Pequenya Clasica", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamPequenya, masaClasica, "Una pizza jamon york para chuparse los dedos");
                idPizzasPred [13] = pizzaPred14.New_ (7.00, "Pizza York Normal Clasica", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamNormal, masaClasica, "Una pizza jamon york para chuparse los dedos");
                idPizzasPred [14] = pizzaPred15.New_ (8.00, "Pizza York Familiar Clasica", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamFamiliar, masaClasica, "Una pizza jamon york para chuparse los dedos");

                idPizzasPred [15] = pizzaPred16.New_ (5.30, "Pizza York Pequenya Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamPequenya, masaClasica, "Una pizza jamon york para chuparse los dedos");
                idPizzasPred [16] = pizzaPred17.New_ (7.30, "Pizza York Normal Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamNormal, masaClasica, "Una pizza jamon york para chuparse los dedos");
                idPizzasPred [17] = pizzaPred18.New_ (8.30, "Pizza York Familiar Extra Fina", "../Images/productos/pizzas_predefinidas/pizza_york.png", 0, tamFamiliar, masaClasica, "Una pizza jamon york para chuparse los dedos");


                Console.WriteLine ("-- Pizzas predefinidas inicializadas correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("---- Inicializamos nuestros usuarios ----");
                Console.WriteLine ();

                idUsuRegist [0] = usuRegist1.New_ ("usuario1@gmail.com", "Alejandro", "asd123", new DateTime (2008, 5, 1, 8, 30, 52), 95687412, DateTime.Now);


                Console.WriteLine ("-- Usuarios registrados inicializados correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();

                Console.WriteLine ("---- Inicializamos nuestros pedidos ----");
                Console.WriteLine ();


                Console.WriteLine ("-- Usuarios registrados inicializados correctamente! --");
                Console.WriteLine ();
                Console.WriteLine ();




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
