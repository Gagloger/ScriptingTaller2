namespace Eventos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EditorInicioApp editorMaestro = new EditorInicioApp();
            Suscriptor1 IniciarSesion = new Suscriptor1("Jacobo", "1234123", editorMaestro);
            Suscriptor2 BaseDeDatos = new Suscriptor2("Estado de la reserva", editorMaestro);

            editorMaestro.IniciarCargaApp();
        }
    }

    public class EditorInicioApp
    {
        public delegate void DelegadoEditor();
        public event DelegadoEditor EventoEditor;
        //private  List<string> historialCalculadora = new List<string>();

        public void IniciarCargaApp()
        {
            try
            {
                Console.WriteLine("Cargando aplicación...");
                Console.WriteLine("Puede tardar unos momentos");
                Console.WriteLine();
                CargaCompletada(true);
            }
            catch (Exception ex)
            {
                CargaCompletada(false);
            }
        }

        public void CargaCompletada(bool cargaExitosa)
        {
            if (cargaExitosa)
            {
                EventoEditor();
            }
            else { Console.WriteLine("Error al cargar la app"); }

        }


    }

    public class Suscriptor1
    {
        private string nombre;
        private string contraseña;


        public void InicioDeSesion()
        {
            Console.WriteLine("Iniciando la sesion del usuario:");
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("contraseña: " + contraseña);
        }
        public Suscriptor1(string nombre, string contraseña, EditorInicioApp editor)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;

            editor.EventoEditor += InicioDeSesion;
        }
    }

    public class Suscriptor2
    {
        private string TipoDeBaseDeDatos;


        public void CargarBaseDatos()
        {
            Console.WriteLine();
            Console.WriteLine("Base de datos cargada correctamente...");
            Console.WriteLine(TipoDeBaseDeDatos + " puede empezar a ser usada");

        }
        public Suscriptor2(string tipoDeBase, EditorInicioApp editor)
        {
            this.TipoDeBaseDeDatos = tipoDeBase;

            editor.EventoEditor += CargarBaseDatos;
        }
    }
}