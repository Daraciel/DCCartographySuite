# Efficiency results

Tabla histórica para comparar cambios de eficiencia del proyecto con el tiempo.

Cómo generar una nueva fila:

- `dotnet run -c Release --project Console/WorldGen.Console.TestConsole/WorldGen.Console.TestConsole.csproj -- efficiency docs/efficiency-results.md`

La consola añadirá una nueva fila (si no existe ya) con la fecha y los tiempos por resolución.

| Date			| CVGA 320x200	| QVGA 320x240	| VGA 640x480	| SVGA 800x600	| HD 1280x720	|
| -------------	| -------------	| -------------	| -------------	| -------------	| ------------- |
| 2026-01-28	| 2,09 s		| 2,18 s		| 10,21 s		| 13,337 s		| 28,552 s		|
| 2026-01-29	| 3,252 s		| 1,984 s		| 7,899 s		| 11,68 s		| 24,897 s		|
