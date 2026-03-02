# ADR-001: Mantener monolito modular en corto/mediano plazo

- **Estado:** Accepted
- **Fecha:** 2026-02-23

## Contexto
La solución `CandidatesMS` concentra subdominios de candidato y compañía, con integración a múltiples servicios externos.

## Decisión
Mantener arquitectura monolítica, reforzando modularización interna por dominios y límites de acoplamiento.

## Consecuencias
### Positivas
- Menor costo operativo inicial.
- Menor complejidad de despliegue.

### Negativas / Trade-offs
- Mayor riesgo de acoplamiento si no existe gobernanza.
- Mayor radio de impacto por cambios transversales.

## Acciones
1. Definir límites de módulo explícitos.
2. Revisiones periódicas de dependencia entre módulos.
