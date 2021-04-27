using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LabMVC.Models.Domain;
using Microsoft.Extensions.Configuration;

namespace LabMVC15_04_2021.Models.Data
{
    public class NationalityDAO
    {

        //CRUD = CREATE, READ (SELECT), UPDATE, DELETE

        private readonly IConfiguration _configuration;
        string connectionString;

        public NationalityDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public NationalityDAO()
        {

        }

        public List<Nationality> Get() //ya no es void, sino int
        {

            List<Nationality> nationality = new List<Nationality>();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("SelectNationality", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    nationality.Add(new Nationality
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        Name = sqlDataReader["Name"].ToString()
                    });
                }

                //command.ExecuteNonQuery(); //esta es la sentencia que ejecuta la inserción en BD y saca un 1 o un 0 dependiendo de si se modificó la tupla o no. Es decir, si se insertó en BD o no. 
                connection.Close(); //cerramos conexión. 
            }


            return nationality; //retornamos resultado al Controller.  

        }

    }
}