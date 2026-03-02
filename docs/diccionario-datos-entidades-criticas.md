# Diccionario de datos — Entidades críticas (`CandidatesMS`)

## Objetivo
Documentar campos clave, reglas esperadas, origen de actualización y consumidores para las entidades críticas del backend, como continuación del mapa relacional.

## Alcance
Este documento cubre inicialmente:
- `Candidate`
- `Postulation`
- `Evaluation`
- `DocumentCheck`

> Nota: es una vista arquitectónica/funcional y no reemplaza el contrato exacto de migraciones SQL.

---

## 1) Entidad: `Candidate`

### Propósito
Representa la identidad y estado transversal del candidato dentro del dominio principal.

### Clave primaria
- `CandidateId`.

### Campos relevantes
| Campo | Tipo (aprox.) | Descripción | Regla esperada |
|---|---|---|---|
| `CandidateId` | int | Identificador interno | Único, no nulo |
| `CandidateGuid` | string | Identificador externo/global | Estable por candidato |
| `Email` | string | Correo principal | Único por candidato |
| `FullData` | bool | Perfil completo | Derivado de avance de registro |
| `CreationDateNoText` | datetime | Fecha técnica de creación | Set en alta |
| `IsDeleteProccess` | bool | Marca de borrado en proceso | Cambia por workflow de eliminación |
| `isAuthorized` | bool | Consentimiento/autorización | Requerido para ciertos procesos |
| `CompanyUserId` | int | Contexto empresa asociado | Relevante en operaciones multi-tenant |

### Relaciones clave
- 1:1 con `BasicInformation`, `Description`, `ExperienceCount`.
- 1:N con `Study`, `WorkExperience`, `CV`, `DocumentCheck`, etc.
- Vinculación transversal por `CandidateId` con entidades del contexto de compañía.

### Origen de actualización
- Flujos API de candidato (alta/edición).
- Sincronizaciones con contexto compañía (proyecciones espejo).

### Consumidores
- Endpoints de perfil candidato.
- Flujos de postulación, evaluación y reporting cruzado.

---

## 2) Entidad: `Postulation` (CompanyContext)

### Propósito
Representa una postulación de un candidato a una vacante (`Job`) y su estado dentro del embudo.

### Clave primaria
- `PostulationId`.

### Campos relevantes
| Campo | Tipo (aprox.) | Descripción | Regla esperada |
|---|---|---|---|
| `PostulationId` | int | ID de postulación | Único, no nulo |
| `CandidateId` | int | Candidato postulado | Debe existir en dominio candidato |
| `JobId` | int | Vacante objetivo | Debe existir en `Job` |
| `PostulationDate` | datetime | Fecha de postulación | Set al crear |
| `PostulationStageId` | int | Etapa actual | Debe pertenecer al catálogo de etapas |
| `LastPostulationStageId` | int | Etapa previa | Útil para auditoría de transición |
| `BlockReasonId` | int? | Razón de bloqueo | Nullable |
| `CompanyUserId` | int? | Usuario empresa responsable | Nullable según flujo |
| `AcceptResponses` | bool | Permite respuestas | Control de interacción |

### Relaciones clave
- N:1 con `Job`.
- N:1 con `BlockReason` y `PostulationStage`.
- 1:N con `Answer`.
- Espejo/proyección en `Candidate_Postulation` del `CandidateContext`.

### Origen de actualización
- Procesos de reclutamiento (empresa/candidato).
- Cambios de etapa y estado por workflows internos.

### Consumidores
- Paneles de embudo de reclutamiento.
- Integraciones y trazabilidad de estado de candidatos.

---

## 3) Entidad: `Evaluation` (CompanyContext)

### Propósito
Almacena una evaluación de candidato realizada por usuarios de empresa, asociada a criterios de evaluación.

### Clave primaria
- `EvaluationId`.

### Campos relevantes
| Campo | Tipo (aprox.) | Descripción | Regla esperada |
|---|---|---|---|
| `EvaluationId` | int | ID de evaluación | Único, no nulo |
| `CandidateId` | int | Candidato evaluado | Debe existir en dominio candidato |
| `CompanyUserId` | int | Empresa/usuario evaluador | Debe existir en `CompanyUser` |
| `MemberUserId` | int | Miembro evaluador | Debe existir en membresía |
| `CreationDate` | datetime | Fecha de evaluación | Set al crear |
| `Observation` | string | Comentario cualitativo | Opcional según caso |
| `JobId` | int | Vacante relacionada | Contextualiza evaluación |
| `TalentGroupId` | int | Grupo de talento relacionado | Contextualiza evaluación |

### Relaciones clave
- N:1 con `CompanyUser`.
- 1:N con `Evaluation_EvaluationCriteria`.

### Origen de actualización
- Flujos de evaluación de recruiters/hiring team.

### Consumidores
- Reportes de scoring.
- Flujos de decisión en selección.

---

## 4) Entidad: `DocumentCheck` (CandidateContext)

### Propósito
Controla checks de documentación/cumplimiento del candidato por grupos y estado.

### Clave primaria
- `DocumentCheckId`.

### Campos relevantes
| Campo | Tipo (aprox.) | Descripción | Regla esperada |
|---|---|---|---|
| `DocumentCheckId` | int | ID del check | Único, no nulo |
| `CandidateId` | int | Candidato objetivo | FK lógica de candidato |
| `DocumentCheckGroupId` | int | Grupo del check | Debe existir en catálogo |
| `DocumentCheckStateId` | int | Estado del check | Debe existir en catálogo |
| `OrderId` | int | Orden de presentación | Útil para UI/flujo |
| `IsCheck` | bool | Marcador de cumplimiento | Actualizable por workflow |
| `IsEnabled` | bool | Habilitado/deshabilitado | Control operativo |
| `CompanyUserId` | int | Contexto empresa | Auditoría/tenant |

### Relaciones clave
- N:1 con `Candidate`.
- N:1 con `DocumentCheckGroup`.
- N:1 con `DocumentCheckState`.

### Origen de actualización
- Flujos de validación documental y compliance.

### Consumidores
- Endpoints de estado documental.
- Vistas de revisión por reclutadores.

---

## 5) Reglas transversales sugeridas
1. Toda entidad crítica debe tener política clara de **fuente de verdad**.
2. Validar integridad de `CandidateId` en cruces CandidateContext/CompanyContext.
3. Estandarizar auditoría mínima (`CreationDate`, `EditionDate` cuando aplique).
4. Definir estrategia de soft-delete cuando el dominio lo requiera.

## 6) Checklist para cambios de modelo en entidades críticas
- [ ] ¿Se actualizó este diccionario con nuevos campos/reglas?
- [ ] ¿Se evaluó impacto en sincronización de entidades espejo?
- [ ] ¿Se revisaron consultas/reportes dependientes?
- [ ] ¿Se definieron migración/backfill si cambió semántica?

## 7) Próxima iteración sugerida
Expandir el diccionario a entidades adicionales de alta criticidad:
- `Job`
- `Candidate_TalentGroup` / `Candidate_TalentGroupAux`
- `Candidate_Tag` / `Candidate_Source`
- `Answer`