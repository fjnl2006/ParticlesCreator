Un sistema de partículas ligero y personalizado para **Unity** que calcula trayectorias parabólicas mediante código, sin depender del motor de físicas


 Características Clave
* Cálculo Matemático Real: Utiliza fórmulas de movimiento uniformemente acelerado para determinar la posición en cada frame.
* Control de Dispersión: Soporta tanto ángulos fijos como disparos aleatorios en 360 grados.
* Gestión de Memoria: Sistema de limpieza automático que destruye las partículas una vez cumplido su tiempo de vida.


 Funcionamiento Matemático

El script `Particle.cs` calcula la posición basándose en el tiempo transcurrido utilizando las siguientes ecuaciones cinemáticas:

- Eje Horizontal (X, Z):
  pX = V_0 \cdot \cos(\theta) \cdot t
  pZ = V_0 \cdot \cos(\phi) \cdot t
- Eje Vertical (Y):
  pY = V_0 \cdot \sin(\theta) \cdot t - \frac{1}{2}gt^2

Donde V_0 es la velocidad inicial y g es la gravedad aplicada.

Instalación y Uso

1.  Importar Scripts: Añade `Particle.cs` y `ParticlesController.cs` a tu carpeta `Assets/Scripts`.
2.  Configurar el Prefab:
    * Crea un objeto 3D (ej. una Esfera pequeña).
    * Añádele el componente `Particle.cs`.
    * Guárdalo como un Prefab y bórralo de la escena.
3.  Configurar el Controlador:
    * Crea un objeto vacío en la escena llamado `ParticlesController`.
    * Añade el componente `ParticlesController.cs`.
    * Arrastra tu Prefab al campo `Particle Prefab` en el Inspector.
4.  Ajustes del Inspector:
    * `Particle Count`: Número de partículas a generar.
    * `Initial Speed`: Velocidad base de salida.
    * `Lifetime`: Tiempo promedio de vida de cada partícula.
    * `Random Angle`: Activa/Desactiva la dispersión aleatoria.

Estructura de Scripts

* `ParticlesController.cs`: Gestiona el ciclo de vida, la instanciación inicial y la actualización de todas las partículas activas en la lista.
* `Particle.cs`: Contiene los datos individuales (velocidad, ángulos, tiempo de vida) y la lógica de cálculo de posición.
