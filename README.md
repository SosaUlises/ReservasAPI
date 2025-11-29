# 🏨 API de Sistema de Reservas

API RESTful para la **gestión integral de reservas hoteleras**, construida con **.NET 8** y **C#**.  
El proyecto implementa **Clean Architecture** para garantizar un código modular, escalable y mantenible.  
Utiliza **PostgreSQL**, **ASP.NET Core Identity** y **JWT** para una seguridad robusta.

---

## 🚀 Live Demo — *Prueba la API en vivo*

La API está desplegada en **Render**.  
Accede a la documentación interactiva (Swagger UI):

👉 **[Ver Documentación y API en Vivo](https://reservasapi-mz8h.onrender.com/index.html)**  

> ⚠️ **Nota:** El entorno de demo es de prueba. Los datos pueden resetearse periódicamente.

---

## 🔐 Credenciales de Acceso (Testing)

Para probar los endpoints protegidos por rol **Administrador**, usa el usuario preconfigurado:

| Rol   | Email           | Password   |
|-------|----------------|------------|
| Admin | admin@sosa.com | Admin123!  |

### Pasos para autenticarse

1. Ve al endpoint `POST /api/v1/auth/login`.
2. Ingresa las credenciales y ejecuta ("Execute").
3. Copia el `token` que recibirás en la respuesta.
4. Haz clic en el botón verde **Authorize** en Swagger.
5. Escribe: `Bearer TU_TOKEN_AQUI` (respetando el espacio después de Bearer) y presiona **Authorize**.

> ⚠️ Recuerda: los endpoints de administración (CRUD de Hoteles/Habitaciones/Clientes) requieren rol **Admin**.  

---

## ✨ Características Principales

### 🔐 Seguridad y Accesos
- **Identity + JWT:** gestión completa de usuarios y roles.
- **RBAC:** Protección por roles (Administrador / Cliente).
- **Passwords Hasheadas** con algoritmos robustos (BCrypt).

### 🏨 Gestión del Negocio
- **CRUD Completo:** Hoteles, Habitaciones, Clientes.
- **📅 Validación Inteligente de Reservas:** evita traslapes de fechas automáticamente.
- **📧 Notificaciones automáticas:** email de confirmación al generar una reserva.

### 🧠 Calidad y Buenas Prácticas
- **FluentValidation:** validación sólida de entradas.
- **AutoMapper:** mapeo entre DTOs y entidades.
- **Swagger/OpenAPI:** documentación automática.
- **Middleware global de errores:** manejo centralizado de excepciones.

---

## 🏗️ Arquitectura y Patrones

El sistema sigue **Clean Architecture**, organizado en capas:

### 📂 Capas Principales
- **Domain:** entidades y reglas puras.
- **Application:** casos de uso, CQRS, interfaces.
- **Infrastructure/Persistence:** EF Core + repositorios.
- **API:** controladores y endpoints REST.

### 🧩 Patrones Utilizados
- **CQRS** (separación de comandos y consultas)
- **Repository Pattern**
- **Unit of Work**
- **Dependency Injection (DI)**

---

## 📦 Gestión de Datos (CRUD)

### 🔐 Auth
- **POST** `/api/v1/auth/login` — Iniciar sesión y obtener token JWT.

---

### 👥 Clientes
- **POST** `/api/v1/cliente/create` — Crear cliente.
- **PUT** `/api/v1/cliente/update` — Actualizar cliente.
- **DELETE** `/api/v1/cliente/delete/{id}` — Eliminar cliente por ID.
- **GET** `/api/v1/cliente/get-all` — Listar todos los clientes.
- **GET** `/api/v1/cliente/getById/{id}` — Obtener cliente por ID.
- **GET** `/api/v1/cliente/getByDni/{dni}` — Obtener cliente por DNI.

---

### 🏨 Habitaciones
- **POST** `/api/v1/habitacion/create` — Crear habitación.
- **PUT** `/api/v1/habitacion/update` — Actualizar habitación.
- **DELETE** `/api/v1/habitacion/delete/{id}` — Eliminar habitación.
- **GET** `/api/v1/habitacion/get-all` — Listar todas las habitaciones.
- **GET** `/api/v1/habitacion/getByHotel/{hotelId}` — Listar habitaciones por hotel.

---

### 🏩 Hoteles
- **POST** `/api/v1/hotel/create` — Crear hotel.
- **PUT** `/api/v1/hotel/update` — Actualizar hotel.
- **DELETE** `/api/v1/hotel/delete/{id}` — Eliminar hotel.
- **GET** `/api/v1/hotel/get-all` — Listar todos los hoteles.
- **GET** `/api/v1/hotel/getByPais/{pais}` — Listar hoteles por país.

---

### 📅 Reservas
- **POST** `/api/v1/reserva/create` — Crear una reserva.
- **GET** `/api/v1/reserva/get-all` — Listar todas las reservas.
- **GET** `/api/v1/reserva/getAllByCliente/{clienteId}` — Reservas por cliente.

---

### 🧑‍💻 Usuarios
- **GET** `/api/v1/usuario/get-all` — Listar todos los usuarios.
- **GET** `/api/v1/usuario/getById/{id}` — Obtener usuario por ID.

---

## 🧰 Stack Tecnológico

| Categoría      | Tecnología                     |
|----------------|--------------------------------|
| Framework      | .NET 8                         |
| Base de Datos  | PostgreSQL (Neon Tech)         |
| ORM            | Entity Framework Core          |
| Seguridad      | ASP.NET Core Identity + JWT    |
| Email Service  | SendGrid / SMTP Service        |
| Mapeo          | AutoMapper                     |
| Validación     | FluentValidation               |
| Documentación  | Swagger / Swashbuckle          |
| Despliegue     | Render + Docker                |

---

## 🙌 Autor
Proyecto desarrollado por **Sosa Ulises**

