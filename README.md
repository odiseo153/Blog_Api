# Blog_Api

Esta es una API simple para gestionar publicaciones y comentarios de un blog. Permite realizar operaciones básicas como crear, leer, actualizar y eliminar publicaciones, así como buscar publicaciones por palabras clave.

Los datos se guardan en memoria 
## Requisitos

- .NET Core 3.1 o superior
- Entity Framework Core
- AutoMapper

## Configuración 
1. Clona este repositorio en tu máquina local:

bash
git clone https://github.com/odiseo153/Blog_Api.git


## Rutas de la Api

# controlador de Publicaciones

GET /Publicaciones: Obtiene todas las publicaciones.
GET /Busqueda_De_Publicacion?busqueda={palabra_clave}: Busca publicaciones por palabra clave.
GET /PublicacionById/{id}: Obtiene una publicación por su ID.
POST /Agregar_Publicacion: Crea una nueva publicación.
PUT /Actualizar_Publicacion/{id}: Actualiza una publicación existente por su ID.
DELETE /Borrar_Publicacion/{id}: Elimina una publicación por su ID.

# controlador de Comentarios
GET /Obtener_Commentarios: Obtiene todos los comentarios.
POST /Agregar_Commentarios: Agrega un nuevo comentario.

