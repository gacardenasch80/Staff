# ADR-002: Modularizar registro de dependencias (DI)

- **Estado:** Proposed
- **Fecha:** 2026-02-23

## Contexto
El registro de DI está altamente concentrado, lo que incrementa complejidad de mantenimiento.

## Decisión
Separar composición DI por módulos:
- `AddCandidatesModule()`
- `AddCompaniesModule()`
- `AddIntegrationsModule()`

## Consecuencias
### Positivas
- Menor complejidad cognitiva.
- Mejor testabilidad de composición.

### Negativas / Trade-offs
- Refactor inicial con impacto transversal.

## Acciones
1. Crear carpeta/proyecto de extensiones DI.
2. Migrar por fases con smoke tests por módulo.
