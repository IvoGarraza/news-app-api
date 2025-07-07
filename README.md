# News API - Backend (.NET 8 + PostgreSQL)

Este proyecto es el backend del desafío técnico **Fullstack - MindFactory**, desarrollado con **.NET 8** y **PostgreSQL**. Expone una API RESTful para gestionar noticias.

## Funcionalidades implementadas

-  Listado de noticias
-  Detalle de una noticia
-  Crear noticia
-  Editar noticia
-  Eliminar noticia
-  Búsqueda por título o autor

## Modelo de datos

Cada noticia contiene los siguientes campos:

- `id` (int)
- `title` (string)}
- `subtitle` (string)
- `description` (string)
- `img` (string)
- `author` (string)
- `date` (DateTime)
- `category` (string)

## Tecnologías usadas

- ASP.NET Core 8
- Dapper
- PostgreSQL
- Arquitectura en capas
- Swagger para documentación

## Endpoints principales

```http
GET    /api/News
GET    /api/News/{id}
POST   /api/News
PUT    /api/News/{id}
DELETE /api/News/{id}
GET    /api/News/search?query=...
