# Roadmap de arquitectura (90 días) — `CandidatesMS`

## Objetivo
Convertir la arquitectura documentada en ejecución controlada durante 90 días, con entregables verificables por sprint.

## Horizonte y fases
- **Fase A (Semanas 1-4):** Fundaciones (gobernanza + baseline técnico).
- **Fase B (Semanas 5-8):** Estandarización (contratos + observabilidad).
- **Fase C (Semanas 9-12):** Endurecimiento (riesgos + optimización + auditoría).

## Fase A — Fundaciones
### Entregables
1. Adoptar `docs/adr/TEMPLATE.md` como formato oficial.
2. Publicar ADR-006 (módulos de DI) usando template.
3. Inventario oficial de endpoints críticos por dominio.
4. Definir owners por módulo (alineado con RACI).

### Criterios de salida
- 100% ADR nuevos usando template.
- Lista de endpoints críticos aprobada por backend + PO.

## Fase B — Estandarización
### Entregables
1. Piloto `ApiResponse<T>` en 5 endpoints críticos.
2. `traceId` presente en respuestas de error de esos endpoints.
3. Métricas de latencia/error rate para integraciones externas clave.

### Criterios de salida
- p95 medido en endpoints piloto.
- Dashboard mínimo disponible para equipo técnico.

## Fase C — Endurecimiento
### Entregables
1. Revisión de deuda de acoplamiento en clases core.
2. Plan de refactor para constructores sobredimensionados.
3. Auditoría de secretos y rotación validada.
4. Revisión de ADRs: Proposed -> Accepted/Superseded.

### Criterios de salida
- Riesgos críticos con mitigación activa.
- Reporte de cierre de ciclo con KPIs.

## KPIs del programa (90 días)
1. % PRs con referencia ADR (objetivo >= 80%).
2. % endpoints críticos con contrato estandarizado (objetivo >= 30% piloto).
3. Cobertura de trazabilidad `traceId` en endpoints críticos (objetivo >= 70% piloto).
4. Error rate de integraciones externas en tendencia descendente.

## Riesgos de ejecución
- Falta de capacidad del equipo para refactors estructurales.
- Priorización de features sobre hardening técnico.
- Ambigüedad en ownership técnico por dominio.

## Mitigaciones
- Timebox semanal para arquitectura (mínimo 2h).
- Gate de PR para cambios con impacto arquitectónico.
- Comité técnico quincenal con decisiones registradas (ADR).