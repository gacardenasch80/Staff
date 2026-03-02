# ADR-003: Estandarizar contrato de respuesta API

- **Estado:** Proposed
- **Fecha:** 2026-02-23

## Contexto
Existen respuestas con estructura similar pero no completamente homogénea.

## Decisión
Adoptar contrato `ApiResponse<T>`:
- `success`
- `message`
- `data`
- `errors`
- `traceId`

## Consecuencias
### Positivas
- Consistencia para consumidores.
- Mejor soporte y observabilidad.

### Negativas / Trade-offs
- Requiere estrategia de transición para backward compatibility.

## Acciones
1. Definir estrategia de versionado (`v1` legacy / `v2` estandarizada).
2. Migrar endpoints por prioridad de consumo.
