Sistema Web con Arquitectura en Capas
Este proyecto implementa una arquitectura de software en capas utilizando ASP.NET Web MVC, WCF y SQL Server.

Descripción
El sistema consta de:

Capa de presentación: Aplicación web ASP.NET Web Forms con páginas para gestionar usuarios
Capa de negocio: Servicios WCF que exponen la lógica de negocio y operaciones CRUD
Capa de datos: Base de datos SQL Server con tabla Usuarios y procedimiento almacenado para CRUD
La capa web referencia los servicios WCF para delegar las operaciones de negocio. Los servicios WCF se conectan a la base de datos para persistir la información.

Requisitos
Visual Studio 2019
SQL Server
.NET Framework 4.7
Configuración
Restaurar base de datos que esta en Solution Items/DB.sql
Configurar cadenas de conexión en UserPresentacion/Web.config/<connectionStrings>
		<add name="cn" connectionString="Data Source = localhost; Initial Catalog = digital_bank; Integrated Security = True;"/>
	</connectionStrings>
Compilar solución
Uso
Ejecutar aplicación web
Ir a página Usuarios
Agregar nuevos usuarios con nombre, fecha nacimiento y sexo
Ver lista de usuarios en página UsuariosConsulta
Modificar o eliminar usuarios
Licencia
MIT
