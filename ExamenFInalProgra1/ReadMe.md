Este proyecto es una aplicación de Windows Forms diseñada
para practicar las operaciones básicas CRUD (Crear, Leer, Actualizar, Eliminar) con una base de datos MySQL.
La aplicación permite gestionar un catálogo de países.


Estructura del Proyecto

El proyecto consta de los siguientes archivos y componentes principales:

forma1.cs: Contiene la lógica de la interfaz gráfica del usuario (GUI) y las operaciones CRUD.
PaisesBD.cs: Contiene las operaciones de acceso a la base de datos.
IngresoPaises.cs: Define el modelo de datos para los países.

forma1.cs
Este archivo maneja la interacción del usuario con la interfaz gráfica
y las llamadas a las funciones de la base de datos.

Componentes Principales
Inicialización

Inicializa los componentes y la conexión a la base de datos cuando se crea la instancia del formulario.
Cargar Datos

Permite cargar los datos de la base de datos y mostrarlos en un componente DataGridView. En caso de error, muestra un mensaje.
Probar Conexión

Prueba la conexión a la base de datos y muestra un mensaje de éxito si la conexión se establece correctamente, o un mensaje de error si falla.
Insertar Datos

Inserta un nuevo registro en la base de datos. Solicita confirmación del usuario antes de proceder y muestra un mensaje de éxito o error dependiendo del resultado de la operación.
Actualizar Datos

Actualiza un registro existente en la base de datos. Solicita confirmación del usuario antes de proceder y muestra un mensaje de éxito o error dependiendo del resultado de la operación.
Eliminar Datos

Elimina un registro de la base de datos. Solicita confirmación del usuario antes de proceder y muestra un mensaje de éxito o error dependiendo del resultado de la operación.
Buscar por ID

Busca y muestra un país por su ID. Si el ID no se encuentra, muestra un mensaje indicando que el ID es inexistente.
Limpiar Campos

Limpia todos los campos del formulario para permitir la entrada de nuevos datos.


PaisesBD.cs
Este archivo maneja las operaciones de la base de datos.

Componentes Principales
Probar Conexión

Intenta abrir una conexión a la base de datos y retorna true si la conexión se establece correctamente, o false si falla.
Insertar

Inserta un nuevo registro en la tabla paises de la base de datos utilizando los datos proporcionados.
Actualizar

Actualiza un registro existente en la tabla paises con los nuevos datos proporcionados.
Leer Catálogo

Lee todos los registros de la tabla paises y los devuelve en un DataTable.
Eliminar

Elimina un registro de la tabla paises utilizando el ID proporcionado.
Buscar País por ID

Busca un país en la tabla paises utilizando el ID proporcionado y devuelve los datos en un DataTable.

Cada operación incluye manejo de errores básico y mensajes de confirmación o error para el usuario.
