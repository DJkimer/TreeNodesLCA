Tree Nodes Lowest Common Ancestor
Proyecto por Diego Javier Ortiz

Este proyecto es una api rest realizada con NetCore 2.2.0 y sqlite.
Utilizando el patron de repositorio, para ejecutarla basta con tener instalado el NetCoreCLI y ejecutar el comando 
"dotnet run" desde la consola de windows ubicados en la carpeta raiz del proyecto.
Luego se recomienda utilizar Postman para realizar las pruebas de los servicios:

1. Creación de Nodo: http://localhost:5000/api/nodes/insert/{value} donde value es el valor del nodo.
2. Lista de todos los nodos : http://localhost:5000/api/nodes/
3. Obtención del Ancentro común más cercano : http://localhost:5000/api/nodes/LCA/{valueFirstNode}/{valueSecondNode}
    dando los valores del primer y segundo nodo a buscar su ancestro.

Notas:
* la aplicación esta hecha con metodos asincronicos e implementando patrones de diseño que se utilizan comunmente 
en el diseño de estas api para producción, tambien se recimienda chequear la data del archivo .db con SqliteBrowser.

Saludos.
