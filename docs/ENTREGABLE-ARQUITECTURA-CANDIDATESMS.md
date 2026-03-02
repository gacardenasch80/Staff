# Entregable descargable — Arquitectura `CandidatesMS`

## ¿Qué incluye este entregable?
Este documento resume y referencia todos los artefactos de arquitectura generados en el proyecto para que puedas descargar un único archivo índice y navegar todo el material técnico.

## 1) Visión de arquitectura
- `docs/arquitectura-backend.md`  
  Resumen técnico del backend: stack, arranque, seguridad, persistencia, integraciones y recomendaciones.

- `docs/mapa-arquitectura-solucion.md`  
  Mapa central de arquitectura (C4, flujos, gobernanza y enlaces a todos los artefactos).

## 2) Flujos y operación
- `docs/diagramas-flujo-procesos-api.md`  
  Diagramas de flujo internos de la API (request autenticada, bootstrap, CV, integraciones, errores).

- `docs/playbook-gobernanza-arquitectura.md`  
  Playbook operativo con cadencias, NFR/SLO, riesgos, KPI y checklist de PR arquitectónico.

- `docs/roadmap-arquitectura-90-dias.md`  
  Plan táctico de ejecución por fases (90 días).

## 3) Decisiones (ADRs)
- `docs/adr/TEMPLATE.md`  
  Plantilla estándar para nuevas decisiones arquitectónicas.

- `docs/adr/ADR-001-monolito-modular.md`
- `docs/adr/ADR-002-di-modular.md`
- `docs/adr/ADR-003-contrato-api-response.md`
- `docs/adr/ADR-004-observabilidad-transversal.md`
- `docs/adr/ADR-005-politica-secretos.md`

## 4) Datos y modelo relacional
- `docs/mapa-relaciones-bd.md`  
  Mapa de relaciones y submapas de dominio Candidate/Company.

- `docs/diccionario-datos-entidades-criticas.md`  
  Diccionario de datos de entidades críticas.

- `docs/catalogo-tablas-campos-relaciones.md`  
  Catálogo completo de tablas, campos y relaciones inferidas desde entidades.

- `docs/diagrama-bd-interaccion-sistema.md`  
  Diagrama de interacción entre CandidateContext y CompanyContext con tablas críticas.


- `docs/iteracion-export-local-githubdesktop.md`  
  Guía de exportación/publicación local (PowerShell + GitHub Desktop).

## 5) Priorización funcional
- `docs/capacidades-y-endpoints-criticos.md`  
  Capacidades críticas, riesgos técnicos y priorización impacto/riesgo.

## Instrucción de descarga
Puedes descargar este archivo directamente:
- `docs/ENTREGABLE-ARQUITECTURA-CANDIDATESMS.md`

Si quieres, en la siguiente iteración te lo empaqueto en un único `.zip` con todos los documentos de arquitectura listos para compartir.

## Estado de regeneración
- Catálogo regenerado desde entidades del código fuente.
- Última regeneración: **2026-02-27 23:18 UTC**.
- Conteo actual: **157 tablas** y **281 relaciones inferidas**.
