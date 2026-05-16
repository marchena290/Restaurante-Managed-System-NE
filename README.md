# 🍽️ Restaurante Fénix - Sistema de Gestión Administrativo

Sistema administrativo para la gestión operativa de restaurantes, desarrollado como proyecto universitario en C# con arquitectura en capas.

## 🚀 Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework 4.8 / ASP.NET MVC
- **Base de Datos:** Microsoft SQL Server
- **ORM:** Entity Framework / ADO.NET
- **Frontend:** Razor Pages, HTML5, CSS3, Bootstrap

## 🏗️ Arquitectura

El sistema fue desarrollado siguiendo una arquitectura en capas:

- **Acceso a Datos:** Conexión a SQL Server mediante Entity Framework y procedimientos almacenados.
- **Entidades:** Modelos del dominio con Data Annotations para validación.
- **Lógica de Negocio:** Reglas y operaciones centralizadas por módulo.
- **Presentación:** Interfaz web con ASP.NET MVC y Razor Pages.

## 📋 Módulos

- **Clientes:** Registro y gestión de clientes (nombre, apellidos, teléfono, correo).
- **Menú:** Administración de platos (descripción, precio).
- **Mesas:** Gestión de mesas del restaurante.
- **Reservaciones:** Creación y consulta de reservaciones vinculando cliente, mesa y menú.

## 🛠️ Instalación y Configuración

1. Clonar el repositorio: `git clone https://github.com/marchena290/Restaurante-Managed-System-NE.git`
2. Abrir la solución (`.sln`) en **Visual Studio 2022**.
3. Crear la base de datos en SQL Server y ejecutar los procedimientos almacenados incluidos en el proyecto.
4. Actualizar el `Web.config` con tus credenciales locales de SQL Server.
5. Ejecutar (F5).

## 📄 Licencia

Proyecto desarrollado como parte del curso Programación III — Ingeniería en Sistemas, Universidad Internacional San Isidro Labrador.
