# Sistema de Gestión de Cartelera de Películas

##Descripción del Proyecto
Este proyecto es una aplicación web desarrollada bajo el patrón arquitectónico 
**MVC (Modelo-Vista-Controlador)**
Su objetivo principal es gestionar un catálogo de películas permitiendo realizar operaciones CRUD 
(Crear, Leer, Actualizar y Eliminar) conectadas a una base de datos relacional.

## Tecnologías Utilizadas
* **Backend:** C# con ASP.NET Core MVC (versión 8.0)
* **ORM:** Entity Framework Core
* **Base de Datos:** SQL Server
* **Frontend:** HTML5, Razor Views y Bootstrap 5 (Diseño Responsivo)

---

## Documentación de la Implementación (Arquitectura)

Para cumplir con los requerimientos del proyecto, la aplicación se estructuró de la siguiente manera:

1. **Modelo de Datos (Mejorado):**
   Partiendo de la entidad básica solicitada, se expandió la tabla `Pelicula` incorporando los campos `Director` y `Sinopsis` 
   para darle mayor valor al dominio, se implementaron *Data Annotations* en C# (como `[Key]` y `[DataType(DataType.Date)]`) 
   para asegurar la integridad de los datos desde el backend.

2. **Controlador y Entity Framework (CRUD):**
   Se configuró el DbContext mediante Inyección de Dependencias en `Program.cs`. 
   El controlador `PeliculasController` gestiona las peticiones HTTP de forma asíncrona (`async/Task`), 
   interactuando con la base de datos para listar, guardar, editar y eliminar registros mediante sentencias LINQ.

3. **Vistas y Diseño UI (Bootstrap):**
   Las vistas Razor (`.cshtml`) fueron reestructuradas utilizando el sistema de grillas y clases de Bootstrap 5.
   Se implementó la clase `table-responsive` para garantizar la adaptabilidad en dispositivos móviles. 
   Los botones, insignias (*badges*) y espaciados fueron estilizados para ofrecer una experiencia de usuario moderna.

4. **Gestión de Archivos Estáticos (Imágenes):**
   Se habilitó el middleware `app.UseStaticFiles()` para la carga de recursos públicos. 
   Las carátulas de las películas se renderizan dinámicamente llamando al ID autoincremental de la base de datos (`ID.jpg`) 
   desde la carpeta `wwwroot/imagenes`.

5. **Buscador y Paginación:** *(En desarrollo / Próxima implementación)*
   Lógica integrada en el controlador para filtrar registros mediante el título y dividir las consultas 
   para optimizar la carga de datos en la vista.

---

## Instrucciones para Ejecutar el Proyecto (Para el Equipo)

Sigan estos pasos cuidadosamente para correr el sistema:

### 1. Preparar la Base de Datos
Abre SQL Server Management Studio (SSMS), crea una "Nueva Consulta", pega este código y presiona Ejecutar (F5):

```sql

CREATE DATABASE PeliculasDB;
GO
USE PeliculasDB;
GO
CREATE TABLE Pelicula (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL,
    Anio DATE NOT NULL,
    Genero VARCHAR(50) NOT NULL,
    Recaudacion DECIMAL(18,2) NOT NULL,
    Director VARCHAR(100) NULL,
    Sinopsis VARCHAR(500) NULL
);
GO

2. Configurar la Cadena de Conexión
Clona este repositorio y abre la solución .sln en Visual Studio 2022.

Abre el archivo appsettings.json.

Modifica la propiedad Server= colocando el nombre de tu propio servidor de SQL Server. 
(Ejemplo: Server=localhost\\SQLEXPRESS). Nota: Recuerda mantener el doble backslash \\ si tu servidor lo requiere.

3. Ejecutar y Restaurar Paquetes
Al abrir el proyecto, Visual Studio restaurará automáticamente los paquetes NuGet (Entity Framework Core y Tools).

Presiona el botón verde de "Iniciar" (o F5) en Visual Studio.

En la URL de tu navegador, agrega /Peliculas al final para ver la cartelera.