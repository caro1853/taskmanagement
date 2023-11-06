# Qué es Docker

Docker es una plataforma de software que le permite crear, probar e implementar aplicaciones rápidamente. Docker empaqueta software en unidades estandarizadas llamadas contenedores que incluyen todo lo necesario para que el software se ejecute, incluidas bibliotecas, herramientas de sistema, código y tiempo de ejecución. [Ver mas información](https://docs.docker.com/)

---
## [Regresar](../README.md)
---

# Qué es docker compose

Es una herramienta para definir y ejecutar aplicaciones de Docker de varios contenedores. En Compose, se usa un archivo YAML para configurar los servicios de la aplicación. Después, con un solo comando, se crean y se inician todos los servicios de la configuración.

---
## [Regresar](../README.md)
---

# Crear y ejecutar la imagen de sql server

Una vez se tenga instalados Docker y Docker compose ejecutar el siguiente comando para generar la imagen y correr el contenedor.

```sh
# Ir al folder src
cd src
# Crear la imagen y ejecutar el contenedor usando el archivo docker-compose-managementdb que se encuentra dendtro del folder src
docker-compose -f docker-compose-managementdb.yaml up -d
```

---
## [Regresar](../README.md)
---

# Algunos comandos útiles para este ejercicio

```sh
# Entrar al contenedor
docker exec -it managementdb sh
# Output
# $
# Usar el cliente de sql server dentro del contenedor 
/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U SA -P "Caro123456"
# Output
# 1>
SELECT Name from sys.databases;
GO
# Output
# Name
# ------
# master
# tempdb
# model
# msdb
# TaskDb
use TaskDb
GO
# Output
# Changed database context to 'TaskDb'.
# Tablas creadas dentro de la base de datos TaskDb
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG = 'TaskDb'
# Output
TABLE_NAME
# ------------------------
# __EFMigrationsHistory
# Categories
# Users
# Tasks
```

---
## [Regresar](../README.md)
---