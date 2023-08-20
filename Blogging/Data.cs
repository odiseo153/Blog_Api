using Data.Modelos;

namespace Blogging
{
    public class Data
    {
        private static BloggingContext context;
        public Data() { }
        
        public Data(BloggingContext con)
        {
        context = con;
        }

        public static Usuario AgregarDatos() 
        {
        
            for (int i = 0; i <= 10; i++)
            {
                var user = new Usuario 
                {
                Clave="clave"+i,
                Nombre="Nombre"+i
                };


                return user;
            }

            return null;
        }
    }
}
