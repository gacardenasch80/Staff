# ADR-004: Estándar de observabilidad transversal

- **Estado:** Proposed
- **Fecha:** 2026-02-23

## Contexto
La API depende de Cognito, S3/Textract, APIs remotas y correo, lo que exige trazabilidad operativa.

## Decisión
Establecer estándar mínimo de observabilidad:
- Logs estructurados por request.
- Propagación de `traceId`.
- Métricas por integración (latencia, errores).

## Consecuencias
### Positivas
- Diagnóstico más rápido.
- Mejor control de performance.

### Negativas / Trade-offs
- Sobrecarga inicial de instrumentación.

## Acciones
1. Instrumentar primero flujos críticos.
2. Definir dashboard operativo por dominio.
