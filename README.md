# Scripting: taller 2
#### *Integrantes:* 
- Jacobo Prada
- Nombre 2
- 
### 1. Explicar por medio de un ejemplo de min 5 funciones, el concepto de *DELEGADO*
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

### 3. Consultar que es un *singletone*, sus pros y contras. ¿Cómo se implementa en C#? ¿Cómo se implementa en Unity?

### 4. Investigar y explicar un patron de POO y un principio

### 5. Consultar y explicar el cilclo de vida de un script en Unity
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
