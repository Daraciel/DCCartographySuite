# Efficiency results

Tabla histórica para comparar cambios de eficiencia del proyecto con el tiempo.

Cómo generar una nueva fila:

- `dotnet run -c Release --project Console/WorldGen.Console.TestConsole/WorldGen.Console.TestConsole.csproj -- efficiency --improvement "Mejora X" --output "docs/efficiency-results.md"`

La consola añadirá una nueva fila (si no existe ya) con la fecha y los tiempos por resolución.

-------------------------------------------------------------------------------------------------
| Date			| Improvement	| CVGA 320x200	| QVGA 320x240	| VGA 640x480	| SVGA 800x600	| HD 1280x720	|
| -------------	| -------------	| -------------	| -------------	| -------------	| ------------- | -------------	|
| 2026-01-28	| -				| 2,09 s		| 2,18 s		| 10,21 s		| 13,337 s		| 28,552 s		|
| 2026-01-29	| Mejora 2		| 3,252 s		| 1,984 s		| 7,899 s		| 11,68 s		| 24,897 s		|
| 2026-01-29	| Mejora 1		| 1,379 s		| 2,086 s		| 7,024 s		| 10,695 s		| 24,148 s		|
| 2026-01-29	| Mejora 3		| 474,631 ms	| 733,321 ms	| 1,946 s		| 3,22 s		| 6,687 s		|
| 2026-02-02	| Mejora 3b		| 197,225 ms	| 233,167 ms	| 1,012 s		| 1,501 s		| 3,01 s		|
| 2026-02-03	| Mejora 5		| 233,637 ms	| 208,757 ms	| 1,167 s		| 1,5 s			| 2,901 s		|
| 2026-02-04	| Mejora 6		| 299,412 ms	| 338,715 ms	| 1,24 s		| 2,162 s		| 3,935 s		|
| 2026-02-05	| Mejora 7+8	| 289,42 ms		| 298,793 ms	| 1,283 s		| 2,068 s		| 3,931 s		|
