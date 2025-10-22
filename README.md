# 🧩 API de Sistema de Reservas

API **RESTful** para la gestión de reservas, construida con **.NET** y **C#**.  
El proyecto implementa **Clean Architecture** para garantizar un código modular, escalable y de fácil mantenimiento.  
Utiliza **PostgreSQL** como base de datos y **ASP.NET Core Identity** con **JWT** para una seguridad robusta.

---

## 🚀 Características Principales

### 🔐 Sistema de Autenticación y Autorización
- Gestión completa de usuarios y roles usando **ASP.NET Core Identity**.  
- Registro de nuevos usuarios con hasheo de contraseñas seguro (**BCrypt**).  
- Login de usuarios y generación de **Tokens JWT** para autenticar peticiones.  
- Protección de endpoints basada en roles (por ejemplo: `[Authorize(Roles = "Administrador")]`).

### 📦 Gestión de Datos (ABM/CRUD)
- Gestión completa de **Clientes** (Crear, Leer, Actualizar, Borrar).
- Gestión de **Usuarios** (los comandos usan UserManager para interactuar de forma segura con Identity).
- Lógica de negocio para **Reservas** (Crear y Consultar).

### 🧠 Calidad de API y Código
- Documentación de API automática con **Swagger (OpenAPI)**.  
- Validación avanzada de modelos de entrada usando **FluentValidation**.  
- Manejo de excepciones **global y centralizado**.

---

## 🏗️ Arquitectura y Patrones de Diseño

### 🧱 Clean Architecture
La solución está dividida en **cuatro proyectos** (`Domain`, `Application`, `Infrastructure`, `Api`) para una clara separación de responsabilidades.

### ⚙️ CQRS (Command Query Responsibility Segregation)
La lógica de la aplicación se divide en:
- **Comandos:** Acciones que escriben o modifican datos (ej: `CreateClienteCommand`).  
- **Consultas:** Acciones que leen datos (ej: `GetAllClientesQuery`).

### 💉 Inyección de Dependencias (DI)
Usada en toda la aplicación para desacoplar componentes y facilitar las pruebas.

### 🗃️ Patrón Repositorio y Unidad de Trabajo
Abstraído a través de `IDataBaseService`, permitiendo que la capa de aplicación acceda a los datos sin acoplarse directamente a **Entity Framework Core**.

---

## 🧰 Stack de Tecnologías

| Categoría | Tecnología |
|------------|-------------|
| **Framework** | .NET 9 |
| **Base de Datos** | PostgreSQL |
| **ORM** | Entity Framework Core |
| **Autenticación** | ASP.NET Core Identity |
| **Autorización API** | JWT |
| **Mapeo de Objetos** | AutoMapper |
| **Validación** | FluentValidation |
| **Documentación API** | Swagger (Swashbuckle) |

---

## 🧪 Pruebas Unitarias (Unit Tests)

**Proyecto:** `Sosa.Reservas.Application.Tests`  
**Tecnologías:** `xUnit` (framework de pruebas) y `Moq` (librería de simulación).  

**Objetivo:**  
Probar la lógica de negocio de la capa de **Application** (Comandos y Consultas) de forma totalmente aislada.  
Se simulan las dependencias externas (como `UserManager` y `IDataBaseService`) para verificar que la lógica interna funciona como se espera.

---
