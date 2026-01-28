# Efficiency results

Tabla histórica para comparar cambios de eficiencia del proyecto con el tiempo.

Cómo generar una nueva fila:

- `dotnet run -c Release --project Console/WorldGen.Console.TestConsole/WorldGen.Console.TestConsole.csproj -- efficiency docs/efficiency-results.md`

La consola añadirá una nueva fila (si no existe ya) con la fecha y los tiempos por resolución.

| Date			| CVGA 320x200	| QVGA 320x240	| VGA 640x480	| SVGA 800x600	| HD 1280x720	|
| -------------	| -------------	| -------------	| -------------	| -------------	| ------------- |
| 2026-01-27	| 2,09 s		| 1,68 s		| 6,936 s		| 10,887 s		| 19,968 s		|
