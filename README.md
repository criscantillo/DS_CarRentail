# Car Rentail Api
La api utiliza Entity Framework, por simplicidad se usa una base de datos sqlite.

## Correr el proyecto
Está listo para ser ejecutado, si usa visual studio code, utilice el siguiente comando
```
donet run
```

## Ejecutar Pruebas
Se aplicaron test para ilustrar el funcionamiento, sobre el servicio de reserva
```
donet test
```

## Métodos
La API cuenta un Crud completo para la definición de los vehículos:

GET, POST, PUT, DELETE
```
https://localhost:7068/car
```

Para aplicar la búsqueda, se tienen 2 endpoints

Obtener el listado de lugares donde se puede recoger o dejar el veehículo
```
https://localhost:7068/search/locations
```

Obtener el listado de vehiculos disponibles según la búsqueda
```
https://localhost:7068/search?locationOrigin=1&locationDestination=1&from=2024-03-09%2000%3A00%3A00&to=2024-03-11%2000%3A00%3A00
```

Reservar un vehículo (Post)
```
https://localhost:7068/reserve
```

## Notas finales
El proyecto es un MVP de la funcionalidad, faltan componentes, como toda la gestión de las otras entidades (Empresas, Usuarios, Localidades), 
validaciones, diseño orientado al dominio, entre otros.
