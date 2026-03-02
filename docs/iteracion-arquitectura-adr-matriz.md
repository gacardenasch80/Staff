# Iteración de arquitectura: ADR inicial + matriz de responsabilidades (`CandidatesMS`)

## Objetivo
Definir artefactos de gobernanza técnica para la arquitectura de la solución, de forma que el equipo pueda tomar decisiones de manera consistente y mantener trazabilidad entre diseño, implementación y operación.

Este documento contiene:
1. Un **pack inicial de 5 ADRs** (Architecture Decision Records).
2. Una **matriz de responsabilidades por módulo** (RACI simplificada).
3. Un **plan de adopción** por etapas.

---

## 1) ADR pack inicial (v1)

## ADR-001 — Mantener arquitectura monolítica modular en corto/mediano plazo
- **Estado:** Aceptado.
- **Contexto:** La solución concentra múltiples subdominios (candidate/company), alto volumen de repositorios y dependencias externas.
- **Decisión:** Mantener el monolito actual, pero con modularización explícita por dominios y límites de acoplamiento.
- **Consecuencias positivas:**
  - Menor costo de operación comparado con microservicios inmediatos.
  - Menor fricción de despliegue y coordinación.
- **Trade-offs / riesgos:**
  - Riesgo de crecimiento desordenado sin gobernanza de módulos.
  - Incremento de tiempo de build y superficie de impacto de cambios.
- **Acciones derivadas:**
  - Definir módulos explícitos por dominio.
  - Crear checklist de revisión de acoplamiento entre módulos.

## ADR-002 — Separación de composición DI por módulos
- **Estado:** Propuesto.
- **Contexto:** `Startup.ConfigureServices` centraliza demasiado registro y configuración.
- **Decisión:** Extraer registro de dependencias a extensiones por módulo:
  - `AddCandidatesModule()`
  - `AddCompaniesModule()`
  - `AddIntegrationsModule()`
- **Consecuencias positivas:**
  - Menor complejidad cognitiva.
  - Mayor mantenibilidad y testabilidad de composición.
- **Trade-offs / riesgos:**
  - Refactor inicial con posible impacto transversal.
- **Acciones derivadas:**
  - Crear proyecto/folder de `DependencyInjection`.
  - Aplicar migración por fases y validar por smoke tests.

## ADR-003 — Estandarizar contrato de respuesta API
- **Estado:** Propuesto.
- **Contexto:** Existe envelope frecuente `{ message, obj }`, pero puede variar entre endpoints.
- **Decisión:** Formalizar un contrato de respuesta versionado:
  - `ApiResponse<T> { success, message, data, errors, traceId }`
- **Consecuencias positivas:**
  - Consistencia para frontend y consumidores internos.
  - Mejor observabilidad y soporte operativo.
- **Trade-offs / riesgos:**
  - Necesidad de transición gradual para no romper consumidores.
- **Acciones derivadas:**
  - Definir estrategia de compatibilidad (`v1` legacy, `v2` estandarizada).

## ADR-004 — Estrategia de observabilidad transversal
- **Estado:** Propuesto.
- **Contexto:** Procesos críticos dependen de servicios externos (Cognito, S3, APIs remotas, mail).
- **Decisión:** Incorporar estándar de observabilidad mínima:
  - Logging estructurado por request.
  - `traceId` propagado en respuestas/errores.
  - Métricas por integración externa (latencia, tasa de error).
- **Consecuencias positivas:**
  - Diagnóstico más rápido de incidentes.
  - Mejor visibilidad de performance por flujo.
- **Trade-offs / riesgos:**
  - Sobrecarga inicial de instrumentación.
- **Acciones derivadas:**
  - Iniciar por flujos críticos (CV upload, operaciones remotas, autenticación).

## ADR-005 — Seguridad y gestión de secretos por política
- **Estado:** Aceptado (con refuerzo).
- **Contexto:** La solución usa Azure Key Vault, pero requiere disciplina de exposición y rotación.
- **Decisión:** Endurecer política de secretos:
  - Sin secretos reales en repositorio.
  - Rotación periódica y owner definido.
  - Verificación CI para detectar filtraciones.
- **Consecuencias positivas:**
  - Menor riesgo operativo y de cumplimiento.
- **Trade-offs / riesgos:**
  - Mayor rigor de procesos para desarrollo local.
- **Acciones derivadas:**
  - Plantillas seguras de configuración local.
  - Check automatizado en PR para detectar credenciales expuestas.

---

## 2) Matriz de responsabilidades por módulo (RACI simplificada)

Roles sugeridos:
- **ARQ:** Arquitectura.
- **BE:** Backend.
- **DEVOPS:** Plataforma/DevOps.
- **QA:** Calidad.
- **SEC:** Seguridad.
- **PO:** Product Owner.

| Módulo / Capacidad | ARQ | BE | DEVOPS | QA | SEC | PO |
|---|---|---|---|---|---|---|
| API Controllers & contrato | A | R | C | C | C | I |
| Servicios de dominio candidato | C | R/A | I | C | I | C |
| Servicios de dominio compañía | C | R/A | I | C | I | C |
| Repositorios + EF Core contexts | C | R/A | I | C | I | I |
| Integraciones remotas (Companies/Recruitee) | C | R | C | C | I | I |
| Autenticación/autorización (Cognito JWT) | C | R | C | C | A | I |
| Gestión de secretos (Key Vault) | C | C | R | I | A | I |
| S3/Textract y gestión documental | C | R | C | C | I | I |
| Observabilidad (logs/métricas/trazas) | A | R | R | C | C | I |
| Release/versionado de API | C | R | R | C | C | A |

Leyenda: **R** Responsible, **A** Accountable, **C** Consulted, **I** Informed.

---

## 3) Backlog técnico de adopción (siguiente ciclo)

## Fase 1 (rápida, 1 sprint)
1. Crear carpeta `docs/adr/` y mover cada ADR a archivo individual (`ADR-001.md`, etc.).
2. Definir plantilla oficial ADR para decisiones futuras.
3. Registrar owners por módulo según matriz RACI.

## Fase 2 (2-3 sprints)
1. Refactor de DI por módulos.
2. Introducción gradual de `ApiResponse<T>` en endpoints priorizados.
3. Instrumentación de observabilidad en 3 flujos críticos.

## Fase 3 (continuo)
1. Revisión trimestral de ADRs (estado: Proposed/Accepted/Superseded).
2. Revisión de acoplamiento entre módulos y deuda técnica.
3. Auditoría de secretos y rotación.

---

## 4) Definición de Done (DoD) de arquitectura para PRs
Un PR con impacto arquitectónico debería incluir:
1. Referencia a ADR nuevo o actualizado.
2. Actualización de diagrama afectado (C4 o flujo interno).
3. Impacto en observabilidad y seguridad.
4. Plan de rollback/migración cuando aplique.

Con esto, la documentación de arquitectura deja de ser solo descriptiva y pasa a ser **operativa y gobernable**.