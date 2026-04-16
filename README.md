# 🍽️ RestaurantePro - Sistema de Gestión Transaccional

Sistema integral para la gestión operativa de negocios gastronómicos, desarrollado con un enfoque en la integridad de los datos y el alto rendimiento en procesos backend.

## 🚀 Tecnologías Utilizadas
* **Lenguaje:** C# 
* **Framework:** .NET Framework 4.8 / ASP.NET MVC
* **Base de Datos:** Microsoft SQL Server
* **ORM:** Entity Framework / ADO.NET
* **Frontend:** Razor Pages, HTML5, CSS3, Bootstrap

## 🧠 Características Técnicas Destacadas

### 🗄️ Arquitectura de Base de Datos (SQL Server)
El núcleo del sistema reside en una lógica de base de datos robusta para garantizar la consistencia en entornos multiusuario:
* **Stored Procedures:** Implementación de procedimientos almacenados para la gestión de pedidos y facturación, reduciendo la latencia y aumentando la seguridad.
* **Triggers & Constraints:** Uso de disparadores para auditoría de inventarios y restricciones de integridad referencial avanzadas.
* **Optimización:** Índices diseñados para agilizar las consultas en tablas de alto tráfico (transacciones de ventas).

### 🏗️ Arquitectura de Software
* **Patrón MVC:** Separación clara de responsabilidades para facilitar el mantenimiento y la escalabilidad.
* **Lógica de Negocio:** Centralizada en servicios para asegurar que las reglas del restaurante (descuentos, impuestos, estados de mesa) se apliquen de forma uniforme.
* **Seguridad:** Validaciones de lado del servidor y manejo seguro de cadenas de conexión.

## 🛠️ Instalación y Configuración
1. Clonar el repositorio: `git clone https://github.com/marchena290/nombre-de-tu-repo.git`
2. Abrir la solución (`.sln`) en **Visual Studio 2022**.
3. Ejecutar el script SQL incluido en la carpeta `/Database` para generar las tablas y procedimientos.
4. Actualizar el `Web.config` con tus credenciales locales de SQL Server.
5. Ejecutar (F5).

## 📄 Licencia
Este proyecto fue desarrollado como parte de mi portafolio profesional de Ingeniería en Sistemas.
