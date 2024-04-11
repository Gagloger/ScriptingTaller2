# Scripting: taller 2
#### *Integrantes:* 
- Jacobo Prada
- Nombre 2
  
[Link a la presentación](https://www.canva.com/design/DAGCHeLq8FU/7FpgvEjPQNDTFVpjkVECcQ/edit?utm_content=DAGCHeLq8FU&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)
### 1. Explicar por medio de un ejemplo de min 5 funciones, el concepto de *DELEGADO*
---
Delegados lo encontramos en C# como un tipo de dato distinto a los que estamos acostumbrados, pues en este caso, es un tipo de dato que no almacena un valor, sino una función. Es importante aclarar que para que un delegado reciba como "valor" una función, la misma debe cumplir con la firma que determina el delegado

	"tipo de retorno" nombreDelegado("parametros")
						=
	"tipo de retorno" nombreFunción("parametros")
Además, a un mismo delegado se le pueden ir adicionando "valores" (funciones) similar a como un contador se le puede aumentar su valor 

	nombreDelegado = Funcion1;
	nombreDelegado += funcion2;
	...
Por último, es importante aclarar que cuando llamemos a un *delegado*, este ejecutará todas las funciones que tenga asignadas en el orden que se fueron agregando.

#### Ahora veamos en un ejemplo:
 Para este caso usaremos un delegado para calcular variable estadísticas de un conjunto de datos, declaremos primero el delegado:
	 
	 public delegate void Estadisticas(int[] numeros);
	 Estadisticas delegaStats; //declarar dentro del main usando
								 al delegado como tipo de dato
Como vemos C# tiene su palabra reservada para ellos, y luego de esta irá la firma que necesitaremos replicar en las funciones.

	static void Media(int[] numeros){ ... }
	static void Organizar(int[] numeros) { ... }
	static void Escribir(int[] numeros) { ... }
	static void Max(int[] numeros) { ... }
	static void Min(int[] numeros) { ... }
	static void Rango(int[] numeros) { ... } 
Observamos que todas tienen el mismo tipo de retorno que el delegado y reciben los mismos parámetros, por lo que podemos asignarlas como "valores" al este
	
	delegaStats = Escribir;
	delegaStats +=Organizar;
	delegaStats +=Media;
	delegaStats +=Max;
	delegaStats +=Min;
	delegaStats += Rango;
Ahora podemos utilizar un *array* que queramos y medirla sus datos estadísticos:
	
	int[] numeroOperar = {10, 100, 20, 30, 40};
	delegaStats(numeroOperar); //invocamos al delegado con el parametro estipulado
***La consola imprimirá:*** 

	Los números dados son:
	10, 100, 20, 30, 40,
	Organizados en orden ascendente:
	10, 20, 30, 40, 100,
	La media de los numeros es: 40
	El máximo es: 100
	El mínimo es: 10
	El rango es: 90
	

> Nota: como vemos no importa el orden en el que declaremos las funciones sino el orden en que agregamos estas dentro del delegado...

### 2. Consultar y crear un ejemplo donde se evidencie el uso de *"event"* en c# (comparar al modelo de Corgi)
---
Para los eventos, en términos simples, tenemos un *delegado encapsulado en una clase*, a esta clase la llamaremos **editor,** y a este editor, se le **suscribirán** otras clases. Este "Editor", ***notificará*** por medio del evento a todas los suscriptores cuando un proceso en particular ocurra, ejecutando las funciones suscritas de todos al estilo de un delegado.
**Veamos un ejemplo:**
Supongamos que queremos iniciar un aplicación, y que cuando esta cargue de forma correcta, comiencen distintos procesos de clases externas a la carga de la App como lo puede ser ***iniciar sesión*** o ***cargar base de datos***
Pues esto lo podemos simular e implementar por medio de eventos, donde la aplicación sea nuestro editor, y los procesos alrededor de esta sean sus suscriptores. comencemos creando la clase editor

	 public class EditorInicioApp
	 {
		public delegate void DelegadoEditor(); //usamos un delegado como vimos antes
		public event DelegadoEditor EventoEditor; //con la palabra reservada event declaramos el evento a partir del delegado
Luego, dentro de la clase, en algún punto, llamaremos al evento para que todas las clases suscritas ejecuten sus acciones, en este caso, cuando la App haya cargado

	public void IniciarCargaApp()
	{
	    try
	    {
        Console.WriteLine("Cargando aplicación...");
        Console.WriteLine("Puede tardar unos momentos");
        Console.WriteLine();
        CargaCompletada(true); //Carga completada correctamente
	    }
	    catch (Exception ex)
	    {
        CargaCompletada(false); //caso de fallo en la carga
	    }
    }
    public void CargaCompletada(bool cargaExitosa)
	{
	    if (cargaExitosa)
	    {
	        EventoEditor(); //aqui notificamos que el evento ha ocurrido, y como un delegado le avisará a todos los suscriptores
	    }
	    else { Console.WriteLine("Error al cargar la app"); }
	}
Ahora veamos al suscriptor 

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
	
Como vemos, al momento de instanciarlo lo que hacemos es suscribir la función específica que necesitamos que haga cuando se complete la carga.
Ahora cuando llamemos al inicio de App, mediante el evento también se cargará el inicio de sesión

	EditorInicioApp editorMaestro = new EditorInicioApp();
	Suscriptor1 IniciarSesion = new Suscriptor1("Jacobo", "1234123", editorMaestro);
	
	editorMaestro.IniciarCargaApp();
La consola nos mostrará lo siguiente:
	
	Cargando aplicación...		//función del editor ejecutada
	Puede tardar unos momentos

	Iniciando la sesion del usuario: //función del suscriptor ejecutada
	Nombre: Jacobo
	contraseña: 1234123
Como vemos el ***editor*** notifico al ***suscriptor***  correctamente mediante el evento que la App cargo correctamente, y este actuó en consecuencia... Podemos agregar otra clase suscriptor distinta que actúe con el mismo evento

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
y del mismo modo 

	EditorInicioApp editorMaestro = new EditorInicioApp();
	Suscriptor1 IniciarSesion = new Suscriptor1("Jacobo", "1234123", editorMaestro);
	Suscriptor2 BaseDeDatos = new Suscriptor2("Estado de la reserva", editorMaestro);

	editorMaestro.IniciarCargaApp();
La consola nos mostrará

	Cargando aplicación...			//funcion del editor
	Puede tardar unos momentos
						//llamado del evento
	Iniciando la sesion del usuario: //funcion suscriptor 1
	Nombre: Jacobo
	contraseña: 1234123

	Base de datos cargada correctamente... //funcion suscriptor 2
	Estado de la reserva puede empezar a ser usada
 #### En el caso de CorgiEngine:
Corgi cuenta con una clase estatica **MMEventManager**, que se encarga de notificar todos los eventos existentes. Cualquier clase puede hacer uso de estos mediante `MMEventManager.TriggerEvent(YOUR_EVENT)`, no sin antes definir que es una receptora, y en que punto comienza a "escuchar" eventos y cuando para de hacerlo, 

	public class MMAchievementDisplayer : MonoBehaviour, MMEventListener<MMAchievementUnlockedEvent> //heredar definiendose como receptora
	void OnEnable()
	{
	this.MMEventStartListening<MMAchievementUnlockedEvent>(); //comienzo
	}
	void OnDisable()
	{
	this.MMEventStopListening<MMAchievementUnlockedEvent>(); // fin
	}

### 3. *singletone*
En este ejemplo, la clase GameManager implementa el patrón Singleton. Solo puede haber una instancia de GameManager en todo el juego. Esto es útil porque permite que cualquier parte del programa acceda al mismo GameManager desde cualquier lugar del código.
 ```
public class GameManager
{
    private static GameManager instance;
    private int score;

    private GameManager() { }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public void IncrementScore(int points)
    {
        score += points;
    }
}
public class Player
{
    public void AddPoints(int points)
    {
        GameManager.Instance.IncrementScore(points);
    }
}

 ```
En este caso, la clase Player puede acceder al GameManager desde cualquier parte del código simplemente llamando a GameManager.Instance. Esto facilita el acceso y la gestión de instancias únicas de clases en todo el programa.
---

### 4. Investigar y explicar un patron de POO y un principio
---

### 5. Consultar y explicar el cilclo de vida de un script en Unity
---
El **ciclo de vida** de un script en Unity viene dado en el siguiente orden:

 1. Primero tenemos las **funciones del editor** (lo que se actualiza cada vez que hacemos cambios en un script).
 2. De segundo tenemos la **inicialización** de los elementos, variables, objetos, etc.
 3. Luego se resuelven las **físicas** (colisiones, fixed y triggers).
 4. Posteriormente se leen los **inputs** del sistema.
 5. De quinto se aplica la **lógica del sistema** (coroutines, update).
 6. Con todo lo anterior se **renderiza la escena** que vemos.
 7. Luego los **gizmos.**
 8. Y encima de todo las **interfaces.**
 9. De noveno paso se procesa el **fin de cada frame.**
 10. Y se detectan **pausas**. (en este punto se vuelve al tercer paso)
 11. Casi al finalizar se detecta si un objeto a sido **deshabilitado o habilitado.**
 12. Por último se procesa lo que ocurre al **final del programa** o si se destruye algún objeto.

[más información detallada sobre la vida de un script](https://docs.unity3d.com/es/530/Manual/ExecutionOrder.html)
