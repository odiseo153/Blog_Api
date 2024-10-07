# Blog API

Esta es una API sencilla para gestionar publicaciones y comentarios en un blog. Proporciona funcionalidades CRUD (Crear, Leer, Actualizar y Eliminar) para las publicaciones y permite buscar publicaciones por palabras clave. También incluye la gestión de comentarios asociados a cada publicación.

Los datos se almacenan temporalmente en memoria, lo que la hace adecuada para propósitos de prueba y demostración.

## Requisitos

- .NET Core 3.1 o superior
- Entity Framework Core (para facilitar la gestión de datos)
- AutoMapper (para el mapeo eficiente entre entidades y modelos)

## Configuración

1. Clona este repositorio en tu máquina local con el siguiente comando:

```bash
git clone https://github.com/odiseo153/Blog_Api.git
```

2. Abre el proyecto en tu entorno de desarrollo favorito.

3. Restaura las dependencias del proyecto:

```bash
dotnet restore
```

4. Inicia la aplicación:

```bash
dotnet run
```

## Rutas de la API

### Controlador de Publicaciones

- **GET /Publicaciones**: Obtiene todas las publicaciones disponibles.

- **GET /Busqueda_De_Publicacion?busqueda={palabra_clave}**: Busca publicaciones que coincidan con la palabra clave proporcionada en el parámetro de búsqueda.

- **GET /PublicacionById/{id}**: Obtiene una publicación específica utilizando su ID.

- **POST /Agregar_Publicacion**: Crea una nueva publicación. El cuerpo de la solicitud debe contener los detalles de la publicación en formato JSON.

- **PUT /Actualizar_Publicacion/{id}**: Actualiza una publicación existente con el ID proporcionado. El cuerpo de la solicitud debe contener los detalles actualizados de la publicación.

- **DELETE /Borrar_Publicacion/{id}**: Elimina una publicación específica usando su ID.

### Controlador de Comentarios

- **GET /Obtener_Comentarios**: Obtiene todos los comentarios disponibles.

- **POST /Agregar_Comentarios**: Agrega un nuevo comentario asociado a una publicación. El cuerpo de la solicitud debe contener el contenido del comentario en formato JSON.

---

## Notas adicionales

- Esta API almacena los datos en memoria, por lo que toda la información se perderá al reiniciar el servidor. Para persistencia a largo plazo, se recomienda configurar una base de datos relacional como SQL Server o SQLite utilizando Entity Framework Core.

- Se puede integrar fácilmente con frameworks frontend como React o Angular para crear una interfaz de usuario que interactúe con la API.

