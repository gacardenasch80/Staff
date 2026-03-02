# ADR-005: Política de secretos y hardening

- **Estado:** Accepted
- **Fecha:** 2026-02-23

## Contexto
Se utiliza Azure Key Vault, pero requiere una política explícita de manejo/rotación.

## Decisión
Formalizar política de secretos:
- Sin secretos reales en repositorio.
- Rotación periódica con owner definido.
- Escaneo automático en CI para filtraciones.

## Consecuencias
### Positivas
- Menor riesgo de seguridad y cumplimiento.

### Negativas / Trade-offs
- Mayor rigor para setup local.

## Acciones
1. Publicar plantillas seguras de configuración local.
2. Agregar validación automática en PR pipeline.
