# Catálogo de tablas, campos y relaciones (`CandidatesMS`)

## Objetivo
Este catálogo documenta las tablas (entidades), sus campos y las relaciones inferidas desde los modelos de `Persistence/Entities` y `Persistence/EntitiesCompany`, para acelerar análisis de impacto, onboarding técnico y gobierno de cambios de datos.

## Alcance de la iteración
En esta versión se mejora la capacidad de consumo del catálogo con contexto operativo adicional:
- Se incluye una guía breve de lectura para equipos de arquitectura, backend y datos.
- Se explicita la metodología de inferencia para interpretar correctamente cardinalidades y falsas positivas.
- Se agregan recomendaciones de validación para contrastar el catálogo lógico contra la base física.

## Metodología de inferencia
1. Identificación de clases de entidad en código fuente C#.
2. Extracción de propiedades con convención `*Id` y navegación entre entidades.
3. Cálculo de relaciones inferidas (`1:N`, `N:1`) por referencias directas e inversas.
4. Consolidación en una tabla global y detalle por entidad.

> Regenerado automáticamente desde el código fuente: **2026-03-02 00:00 UTC**.
> Nota: este inventario representa el **modelo lógico** inferido desde EF Core y convenciones de nombres. Puede diferir de constraints físicos reales si existen configuraciones Fluent API, migraciones manuales o scripts SQL fuera del código.

## Resumen ejecutivo
- Tablas detectadas: **157**.
- Relaciones inferidas: **281**.
- Contextos fuente: **CandidateContext** y **CompanyContext**.
- Uso recomendado: impacto de cambios, trazabilidad de dependencias y priorización de hardening de datos.

## Guía rápida de lectura
- **Relaciones globales:** vista consolidada para identificar hubs de acoplamiento.
- **Detalle por tabla:** inventario de campos y relaciones directas por entidad.
- **Cardinalidad inferida:** orientación arquitectónica; validar contra BD antes de cambios críticos.

## Recomendaciones de validación
- Validar entidades críticas contra `INFORMATION_SCHEMA` o `pg_catalog` en ambiente objetivo.
- Confirmar claves compuestas y constraints únicos no deducibles por convención.
- Revisar tablas puente (`*_` y variantes de tablas puente, o relaciones `Many-to-Many`) antes de ajustar joins/reportes.
- Incorporar esta revisión al checklist de ADR/PR para cambios de persistencia.

## Relaciones globales (inferidas)
| Tabla origen | Tabla destino | FK / Correlación | Cardinalidad |
|---|---|---|---|
| `ActionUser` | `Permission_ActionUser` | `ActionUserId (en Permission_ActionUser)` | `1:N` |
| `Answer` | `Postulation` | `PostulationId` | `N:1` |
| `Answer` | `Question` | `QuestionId` | `N:1` |
| `AttachedFile` | `FileType` | `FileTypeId` | `N:1` |
| `AttachedFileHiring` | `Candidate` | `CandidateId` | `N:1` |
| `AttachedFileHiring` | `FileTypeHiring` | `FileTypeHiringId` | `N:1` |
| `AttachedFileMail` | `Mail` | `MailId` | `N:1` |
| `AttachedFileRemoteMail` | `RemoteMail` | `RemoteMailId` | `N:1` |
| `BasicInformation` | `Candidate` | `CandidateId` | `N:1` |
| `BasicInformation` | `Currency` | `CurrencyId` | `N:1` |
| `BasicInformation` | `DocumentType` | `DocumentTypeId` | `N:1` |
| `BasicInformation` | `Gender` | `GenderId` | `N:1` |
| `BasicInformation` | `MaritalStatus` | `MaritalStatusId` | `N:1` |
| `CC` | `Mail` | `MailId` | `N:1` |
| `CCO` | `Mail` | `MailId` | `N:1` |
| `CCORemote` | `RemoteMail` | `RemoteMailId` | `N:1` |
| `CCRemote` | `RemoteMail` | `RemoteMailId` | `N:1` |
| `CV` | `Candidate` | `CandidateId` | `N:1` |
| `CV` | `FileType` | `FileTypeId` | `N:1` |
| `CVHiring` | `Candidate` | `CandidateId` | `N:1` |
| `CVHiring` | `FileTypeHiring` | `FileTypeHiringId` | `N:1` |
| `CalendarEvent` | `MemberUser` | `MemberUserId` | `N:1` |
| `Candidate` | `AttachedFileHiring` | `CandidateId (en AttachedFileHiring)` | `1:N` |
| `Candidate` | `CVHiring` | `CandidateId (en CVHiring)` | `1:N` |
| `Candidate` | `CandidateCompany` | `CandidateId (en CandidateCompany)` | `1:N` |
| `Candidate` | `Candidate_Language` | `CandidateId (en Candidate_Language)` | `1:N` |
| `Candidate` | `Candidate_LanguageOther` | `CandidateId (en Candidate_LanguageOther)` | `1:N` |
| `Candidate` | `Candidate_LifePreference` | `CandidateId (en Candidate_LifePreference)` | `1:N` |
| `Candidate` | `Candidate_Postulation` | `CandidateId (en Candidate_Postulation)` | `1:N` |
| `Candidate` | `Candidate_SoftSkill` | `CandidateId (en Candidate_SoftSkill)` | `1:N` |
| `Candidate` | `Candidate_Source` | `CandidateId (en Candidate_Source)` | `1:N` |
| `Candidate` | `Candidate_Tag` | `CandidateId (en Candidate_Tag)` | `1:N` |
| `Candidate` | `Candidate_TalentGroupAux` | `CandidateId (en Candidate_TalentGroupAux)` | `1:N` |
| `Candidate` | `Candidate_TechnicalAbility` | `CandidateId (en Candidate_TechnicalAbility)` | `1:N` |
| `Candidate` | `Candidate_TimeAvailability` | `CandidateId (en Candidate_TimeAvailability)` | `1:N` |
| `Candidate` | `Candidate_Wellness` | `CandidateId (en Candidate_Wellness)` | `1:N` |
| `Candidate` | `CompanyDescription` | `CandidateId (en CompanyDescription)` | `1:N` |
| `Candidate` | `Company_Candidate_TimeAvailability` | `CandidateId (en Company_Candidate_TimeAvailability)` | `1:N` |
| `Candidate` | `Company_Candidate_Wellness` | `CandidateId (en Company_Candidate_Wellness)` | `1:N` |
| `Candidate` | `LanguageOther` | `CandidateId (en LanguageOther)` | `1:N` |
| `Candidate` | `Mail` | `CandidateId (en Mail)` | `1:N` |
| `Candidate` | `Note` | `CandidateId (en Note)` | `1:N` |
| `Candidate` | `PersonalReference` | `CandidateId (en PersonalReference)` | `1:N` |
| `Candidate` | `Request` | `CandidateId (en Request)` | `1:N` |
| `Candidate` | `Study` | `CandidateId (en Study)` | `1:N` |
| `Candidate` | `Video` | `CandidateId (en Video)` | `1:N` |
| `Candidate` | `WorkExperience` | `CandidateId (en WorkExperience)` | `1:N` |
| `CandidateCompany` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_BlockReason` | `BlockReason` | `BlockReasonId` | `N:1` |
| `Candidate_Language` | `Language` | `LanguageId` | `N:1` |
| `Candidate_Language` | `LanguageLevel` | `LanguageLevelId` | `N:1` |
| `Candidate_LanguageOther` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_LanguageOther` | `LanguageLevel` | `LanguageLevelId` | `N:1` |
| `Candidate_LanguageOther` | `LanguageOther` | `LanguageOtherId` | `N:1` |
| `Candidate_LifePreference` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_LifePreference` | `LifePreference` | `LifePreferenceId` | `N:1` |
| `Candidate_Postulation` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_SoftSkill` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_SoftSkill` | `SoftSkill` | `SoftSkillId` | `N:1` |
| `Candidate_Source` | `Source` | `SourceId` | `N:1` |
| `Candidate_Tag` | `Tag` | `TagId` | `N:1` |
| `Candidate_TalentGroup` | `TalentGroup` | `TalentGroupId` | `N:1` |
| `Candidate_TalentGroupAux` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_TechnicalAbility` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_TechnicalAbility` | `TechnicalAbilityLevel` | `TechnicalAbilityLevelId` | `N:1` |
| `Candidate_TechnicalAbility` | `TechnicalAbilityTechnology` | `TechnicalAbilityTechnologyId` | `N:1` |
| `Candidate_TimeAvailability` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_TimeAvailability` | `TimeAvailability` | `TimeAvailabilityId` | `N:1` |
| `Candidate_Wellness` | `Candidate` | `CandidateId` | `N:1` |
| `Candidate_Wellness` | `Wellness` | `WellnessId` | `N:1` |
| `CertificationState` | `Study` | `CertificationStateId (en Study)` | `1:N` |
| `CompanyDescription` | `Candidate` | `CandidateId` | `N:1` |
| `CompanyUser` | `BlockReason` | `CompanyUserId (en BlockReason)` | `1:N` |
| `CompanyUser` | `MemberUser` | `CompanyUserId (en MemberUser)` | `1:N` |
| `Company_Candidate_TimeAvailability` | `Candidate` | `CandidateId` | `N:1` |
| `Company_Candidate_TimeAvailability` | `TimeAvailability` | `TimeAvailabilityId` | `N:1` |
| `Company_Candidate_Wellness` | `Candidate` | `CandidateId` | `N:1` |
| `Company_Candidate_Wellness` | `Wellness` | `WellnessId` | `N:1` |
| `DefaultEvaluationCriteria` | `EvaluationCriteriaType` | `EvaluationCriteriaTypeId` | `N:1` |
| `Description` | `Candidate` | `CandidateId` | `N:1` |
| `DisqualificationReason` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `DocumentCheck` | `Candidate` | `CandidateId` | `N:1` |
| `DocumentCheck` | `DocumentCheckGroup` | `DocumentCheckGroupId` | `N:1` |
| `DocumentCheck` | `DocumentCheckState` | `DocumentCheckStateId` | `N:1` |
| `DocumentCheckGroup` | `DocumentCheck` | `DocumentCheckGroupId (en DocumentCheck)` | `1:N` |
| `DocumentCheckState` | `DocumentCheck` | `DocumentCheckStateId (en DocumentCheck)` | `1:N` |
| `DocumentType` | `BasicInformation` | `DocumentTypeId (en BasicInformation)` | `1:N` |
| `Duration` | `Event` | `DurationId (en Event)` | `1:N` |
| `Email` | `BasicInformation` | `BasicInformationId` | `N:1` |
| `Evaluation` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `Evaluation` | `Evaluation_EvaluationCriteria` | `EvaluationId (en Evaluation_EvaluationCriteria)` | `1:N` |
| `EvaluationCriteria` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `EvaluationCriteria` | `EvaluationCriteriaType` | `EvaluationCriteriaTypeId` | `N:1` |
| `EvaluationCriteriaType` | `DefaultEvaluationCriteria` | `EvaluationCriteriaTypeId (en DefaultEvaluationCriteria)` | `1:N` |
| `EvaluationCriteriaType` | `EvaluationCriteria` | `EvaluationCriteriaTypeId (en EvaluationCriteria)` | `1:N` |
| `Evaluation_EvaluationCriteria` | `Evaluation` | `EvaluationId` | `N:1` |
| `Event` | `Duration` | `DurationId` | `N:1` |
| `Event` | `EventType` | `EventTypeId` | `N:1` |
| `Event` | `Event_MemberUser` | `EventId (en Event_MemberUser)` | `1:N` |
| `Event` | `TimeZoneEvent` | `TimeZoneEventId` | `N:1` |
| `EventType` | `Event` | `EventTypeId (en Event)` | `1:N` |
| `Event_MemberUser` | `Event` | `EventId` | `N:1` |
| `Event_MemberUser` | `MemberUser` | `MemberUserId` | `N:1` |
| `ExperienceCount` | `Candidate` | `CandidateId` | `N:1` |
| `FileType` | `AttachedFile` | `FileTypeId (en AttachedFile)` | `1:N` |
| `FileType` | `CV` | `FileTypeId (en CV)` | `1:N` |
| `FileTypeHiring` | `AttachedFileHiring` | `FileTypeHiringId (en AttachedFileHiring)` | `1:N` |
| `FileTypeHiring` | `CVHiring` | `FileTypeHiringId (en CVHiring)` | `1:N` |
| `FollowJob` | `Job` | `JobId` | `N:1` |
| `FollowJob` | `MemberUser` | `MemberUserId` | `N:1` |
| `FollowTalentGroup` | `MemberUser` | `MemberUserId` | `N:1` |
| `FollowTalentGroup` | `TalentGroup` | `TalentGroupId` | `N:1` |
| `Gender` | `BasicInformation` | `GenderId (en BasicInformation)` | `1:N` |
| `GenderCompany` | `Gender` | `GenderId` | `N:1` |
| `GuestUser` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `GuestUser` | `GuestUser_Job` | `GuestUserId (en GuestUser_Job)` | `1:N` |
| `GuestUser` | `GuestUser_TG` | `GuestUserId (en GuestUser_TG)` | `1:N` |
| `GuestUser` | `Role` | `RoleId` | `N:1` |
| `GuestUser_Job` | `GuestUser` | `GuestUserId` | `N:1` |
| `GuestUser_TG` | `GuestUser` | `GuestUserId` | `N:1` |
| `ICS` | `MemberUser` | `MemberUserId` | `N:1` |
| `Industry` | `WorkExperience` | `IndustryId (en WorkExperience)` | `1:N` |
| `InternalCode` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `InternalCode` | `TalentGroup` | `InternalCodeId (en TalentGroup)` | `1:N` |
| `Job` | `FollowJob` | `JobId (en FollowJob)` | `1:N` |
| `Job` | `InternalCode` | `InternalCodeId` | `N:1` |
| `Job` | `JobContract` | `JobContractId` | `N:1` |
| `Job` | `JobCurrency` | `JobCurrencyId` | `N:1` |
| `Job` | `JobEducationLevel` | `JobEducationLevelId` | `N:1` |
| `Job` | `JobExperience` | `JobExperienceId` | `N:1` |
| `Job` | `JobLevel` | `JobLevelId` | `N:1` |
| `Job` | `JobLocation` | `JobLocationId` | `N:1` |
| `Job` | `JobLocationModality` | `JobLocationModalityId` | `N:1` |
| `Job` | `JobModality` | `JobModalityId` | `N:1` |
| `Job` | `JobPostingStatus` | `JobPostingStatusId` | `N:1` |
| `Job` | `JobSector` | `JobSectorId` | `N:1` |
| `Job` | `JobSubLevel` | `JobSubLevelId` | `N:1` |
| `Job` | `JobType` | `JobTypeId` | `N:1` |
| `Job` | `Job_JobLanguage` | `JobId (en Job_JobLanguage)` | `1:N` |
| `Job` | `Job_JobProfession` | `JobId (en Job_JobProfession)` | `1:N` |
| `Job` | `Job_JobSoftSkill` | `JobId (en Job_JobSoftSkill)` | `1:N` |
| `Job` | `Job_JobTechnicalAbility` | `JobId (en Job_JobTechnicalAbility)` | `1:N` |
| `Job` | `Job_MemberUser` | `JobId (en Job_MemberUser)` | `1:N` |
| `Job` | `Job_OtherLanguage` | `JobId (en Job_OtherLanguage)` | `1:N` |
| `Job` | `Job_OtherProfession` | `JobId (en Job_OtherProfession)` | `1:N` |
| `Job` | `Job_OtherTechnicalAbility` | `JobId (en Job_OtherTechnicalAbility)` | `1:N` |
| `Job` | `Postulation` | `JobId (en Postulation)` | `1:N` |
| `Job` | `Question` | `JobId (en Question)` | `1:N` |
| `Job` | `WorkArea` | `WorkAreaId` | `N:1` |
| `JobLanguage` | `Job_JobLanguage` | `JobLanguageId (en Job_JobLanguage)` | `1:N` |
| `JobLanguageLevel` | `Job_JobLanguage` | `JobLanguageLevelId (en Job_JobLanguage)` | `1:N` |
| `JobLanguageLevel` | `Job_OtherLanguage` | `JobLanguageLevelId (en Job_OtherLanguage)` | `1:N` |
| `JobPostingStatus` | `Job` | `JobPostingStatusId (en Job)` | `1:N` |
| `JobSoftSkill` | `Job_JobSoftSkill` | `JobSoftSkillId (en Job_JobSoftSkill)` | `1:N` |
| `JobSubLevel` | `JobLevel` | `JobLevelId` | `N:1` |
| `JobTechnicalAbility` | `Job_JobTechnicalAbility` | `JobTechnicalAbilityId (en Job_JobTechnicalAbility)` | `1:N` |
| `JobTechnicalAbilityLevel` | `Job_JobTechnicalAbility` | `JobTechnicalAbilityLevelId (en Job_JobTechnicalAbility)` | `1:N` |
| `JobTechnicalAbilityLevel` | `Job_OtherTechnicalAbility` | `JobTechnicalAbilityLevelId (en Job_OtherTechnicalAbility)` | `1:N` |
| `JobType` | `Job` | `JobTypeId (en Job)` | `1:N` |
| `Job_JobLanguage` | `Job` | `JobId` | `N:1` |
| `Job_JobLanguage` | `JobLanguage` | `JobLanguageId` | `N:1` |
| `Job_JobLanguage` | `JobLanguageLevel` | `JobLanguageLevelId` | `N:1` |
| `Job_JobProfession` | `Job` | `JobId` | `N:1` |
| `Job_JobProfession` | `JobProfession` | `JobProfessionId` | `N:1` |
| `Job_JobSoftSkill` | `Job` | `JobId` | `N:1` |
| `Job_JobSoftSkill` | `JobSoftSkill` | `JobSoftSkillId` | `N:1` |
| `Job_JobTechnicalAbility` | `Job` | `JobId` | `N:1` |
| `Job_JobTechnicalAbility` | `JobTechnicalAbility` | `JobTechnicalAbilityId` | `N:1` |
| `Job_JobTechnicalAbility` | `JobTechnicalAbilityLevel` | `JobTechnicalAbilityLevelId` | `N:1` |
| `Job_MemberUser` | `Job` | `JobId` | `N:1` |
| `Job_MemberUser` | `MemberUser` | `MemberUserId` | `N:1` |
| `Job_OtherLanguage` | `Job` | `JobId` | `N:1` |
| `Job_OtherLanguage` | `JobLanguageLevel` | `JobLanguageLevelId` | `N:1` |
| `Job_OtherProfession` | `Job` | `JobId` | `N:1` |
| `Job_OtherSector` | `Job` | `JobId` | `N:1` |
| `Job_OtherTechnicalAbility` | `Job` | `JobId` | `N:1` |
| `Job_OtherTechnicalAbility` | `JobTechnicalAbilityLevel` | `JobTechnicalAbilityLevelId` | `N:1` |
| `Language` | `Candidate_Language` | `LanguageId (en Candidate_Language)` | `1:N` |
| `LanguageLevel` | `Candidate_Language` | `LanguageLevelId (en Candidate_Language)` | `1:N` |
| `LanguageLevel` | `Candidate_LanguageOther` | `LanguageLevelId (en Candidate_LanguageOther)` | `1:N` |
| `LanguageOther` | `Candidate` | `CandidateId` | `N:1` |
| `LifePreference` | `Candidate_LifePreference` | `LifePreferenceId (en Candidate_LifePreference)` | `1:N` |
| `Mail` | `AttachedFileMail` | `MailId (en AttachedFileMail)` | `1:N` |
| `Mail` | `CC` | `MailId (en CC)` | `1:N` |
| `Mail` | `CCO` | `MailId (en CCO)` | `1:N` |
| `Mail` | `Candidate` | `CandidateId` | `N:1` |
| `MaritalStatus` | `BasicInformation` | `MaritalStatusId (en BasicInformation)` | `1:N` |
| `MaritalStatusCompany` | `MaritalStatus` | `MaritalStatusId` | `N:1` |
| `MemberUser` | `CalendarEvent` | `MemberUserId (en CalendarEvent)` | `1:N` |
| `MemberUser` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `MemberUser` | `Evaluation` | `MemberUserId (en Evaluation)` | `1:N` |
| `MemberUser` | `Evaluation_EvaluationCriteria` | `MemberUserId (en Evaluation_EvaluationCriteria)` | `1:N` |
| `MemberUser` | `Event_MemberUser` | `MemberUserId (en Event_MemberUser)` | `1:N` |
| `MemberUser` | `FollowJob` | `MemberUserId (en FollowJob)` | `1:N` |
| `MemberUser` | `FollowTalentGroup` | `MemberUserId (en FollowTalentGroup)` | `1:N` |
| `MemberUser` | `ICS` | `MemberUserId (en ICS)` | `1:N` |
| `MemberUser` | `Job_MemberUser` | `MemberUserId (en Job_MemberUser)` | `1:N` |
| `MemberUser` | `MemberUserTalentGroup` | `MemberUserId (en MemberUserTalentGroup)` | `1:N` |
| `MemberUser` | `MemberUser_TGComercial` | `MemberUserId (en MemberUser_TGComercial)` | `1:N` |
| `MemberUser` | `Notification` | `MemberUserId (en Notification)` | `1:N` |
| `MemberUser` | `Role` | `RoleId` | `N:1` |
| `MemberUser` | `SearchHistory` | `MemberUserId (en SearchHistory)` | `1:N` |
| `MemberUserTalentGroup` | `MemberUser` | `MemberUserId` | `N:1` |
| `MemberUserTalentGroup` | `TalentGroup` | `TalentGroupId` | `N:1` |
| `MemberUser_TGComercial` | `MemberUser` | `MemberUserId` | `N:1` |
| `MentionMemberUser` | `Note` | `NoteId` | `N:1` |
| `Note` | `Candidate` | `CandidateId` | `N:1` |
| `Note` | `MentionMemberUser` | `NoteId (en MentionMemberUser)` | `1:N` |
| `Notification` | `MemberUser` | `MemberUserId` | `N:1` |
| `Notification` | `NotificationType` | `NotificationTypeId` | `N:1` |
| `NotificationType` | `Notification` | `NotificationTypeId (en Notification)` | `1:N` |
| `PercentCriteria` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `Permission` | `PermissionActivity` | `PermissionId (en PermissionActivity)` | `1:N` |
| `Permission` | `PermissionGroup` | `PermissionGroupId` | `N:1` |
| `Permission` | `Permission_ActionUser` | `PermissionId (en Permission_ActionUser)` | `1:N` |
| `Permission` | `Permission_Role` | `PermissionId (en Permission_Role)` | `1:N` |
| `PermissionActivity` | `Permission` | `PermissionId` | `N:1` |
| `Permission_ActionUser` | `ActionUser` | `ActionUserId` | `N:1` |
| `Permission_ActionUser` | `Permission` | `PermissionId` | `N:1` |
| `Permission_Role` | `Permission` | `PermissionId` | `N:1` |
| `Permission_Role` | `Role` | `RoleId` | `N:1` |
| `PersonalReference` | `Candidate` | `CandidateId` | `N:1` |
| `PersonalReference` | `RelationType` | `RelationTypeId` | `N:1` |
| `Phone` | `BasicInformation` | `BasicInformationId` | `N:1` |
| `Postulation` | `Answer` | `PostulationId (en Answer)` | `1:N` |
| `Postulation` | `BlockReason` | `BlockReasonId` | `N:1` |
| `Postulation` | `Job` | `JobId` | `N:1` |
| `Postulation` | `PostulationStage` | `PostulationStageId` | `N:1` |
| `PostulationStage` | `Postulation` | `PostulationStageId (en Postulation)` | `1:N` |
| `PostulationStage` | `PostulationState` | `PostulationStateId` | `N:1` |
| `PostulationState` | `PostulationStage` | `PostulationStateId (en PostulationStage)` | `1:N` |
| `Question` | `Answer` | `QuestionId (en Answer)` | `1:N` |
| `Question` | `Job` | `JobId` | `N:1` |
| `Question` | `QuestionType` | `QuestionTypeId` | `N:1` |
| `QuestionType` | `Question` | `QuestionTypeId (en Question)` | `1:N` |
| `RelationType` | `PersonalReference` | `RelationTypeId (en PersonalReference)` | `1:N` |
| `RemoteMail` | `AttachedFileRemoteMail` | `RemoteMailId (en AttachedFileRemoteMail)` | `1:N` |
| `RemoteMail` | `CCORemote` | `RemoteMailId (en CCORemote)` | `1:N` |
| `RemoteMail` | `CCRemote` | `RemoteMailId (en CCRemote)` | `1:N` |
| `Request` | `Candidate` | `CandidateId` | `N:1` |
| `Request` | `RequestType` | `RequestTypeId` | `N:1` |
| `RequestType` | `Request` | `RequestTypeId (en Request)` | `1:N` |
| `Role` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `Role` | `GuestUser` | `RoleId (en GuestUser)` | `1:N` |
| `Role` | `MemberUser` | `RoleId (en MemberUser)` | `1:N` |
| `Role` | `Permission_Role` | `RoleId (en Permission_Role)` | `1:N` |
| `SearchHistory` | `MemberUser` | `MemberUserId` | `N:1` |
| `SocialNetwork` | `BasicInformation` | `BasicInformationId` | `N:1` |
| `SoftSkill` | `Candidate_SoftSkill` | `SoftSkillId (en Candidate_SoftSkill)` | `1:N` |
| `Source` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `Study` | `Candidate` | `CandidateId` | `N:1` |
| `Study` | `CertificationState` | `CertificationStateId` | `N:1` |
| `Study` | `JobProfession` | `JobProfessionId` | `N:1` |
| `Study` | `StudyArea` | `StudyAreaId` | `N:1` |
| `Study` | `StudyState` | `StudyStateId` | `N:1` |
| `Study` | `StudyType` | `StudyTypeId` | `N:1` |
| `Study` | `Title` | `TitleId` | `N:1` |
| `StudyArea` | `Study` | `StudyAreaId (en Study)` | `1:N` |
| `StudyCertificate` | `Study` | `StudyId` | `N:1` |
| `StudyState` | `Study` | `StudyStateId (en Study)` | `1:N` |
| `StudyType` | `Study` | `StudyTypeId (en Study)` | `1:N` |
| `Tag` | `CompanyUser` | `CompanyUserId` | `N:1` |
| `TalentGroup` | `Candidate_TalentGroup` | `TalentGroupId (en Candidate_TalentGroup)` | `1:N` |
| `TalentGroup` | `FollowTalentGroup` | `TalentGroupId (en FollowTalentGroup)` | `1:N` |
| `TalentGroup` | `InternalCode` | `InternalCodeId` | `N:1` |
| `TalentGroup` | `MemberUserTalentGroup` | `TalentGroupId (en MemberUserTalentGroup)` | `1:N` |
| `TalentGroup` | `TalentGroupPostingStatus` | `TalentGroupPostingStatusId` | `N:1` |
| `TalentGroupPostingStatus` | `TalentGroup` | `TalentGroupPostingStatusId (en TalentGroup)` | `1:N` |
| `TechnicalAbilityLevel` | `Candidate_TechnicalAbility` | `TechnicalAbilityLevelId (en Candidate_TechnicalAbility)` | `1:N` |
| `TechnicalAbilityTechnology` | `Candidate_TechnicalAbility` | `TechnicalAbilityTechnologyId (en Candidate_TechnicalAbility)` | `1:N` |
| `TimeAvailability` | `Candidate_TimeAvailability` | `TimeAvailabilityId (en Candidate_TimeAvailability)` | `1:N` |
| `TimeAvailability` | `Company_Candidate_TimeAvailability` | `TimeAvailabilityId (en Company_Candidate_TimeAvailability)` | `1:N` |
| `TimeZoneEvent` | `Event` | `TimeZoneEventId (en Event)` | `1:N` |
| `Title` | `Study` | `TitleId (en Study)` | `1:N` |
| `UserLink` | `BasicInformation` | `BasicInformationId` | `N:1` |
| `Video` | `Candidate` | `CandidateId` | `N:1` |
| `Wellness` | `Candidate_Wellness` | `WellnessId (en Candidate_Wellness)` | `1:N` |
| `Wellness` | `Company_Candidate_Wellness` | `WellnessId (en Company_Candidate_Wellness)` | `1:N` |
| `WorkExperience` | `Candidate` | `CandidateId` | `N:1` |
| `WorkExperience` | `EquivalentPosition` | `EquivalentPositionId` | `N:1` |
| `WorkExperience` | `Industry` | `IndustryId` | `N:1` |

## Tablas y campos

### `ActionUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `ActionUserId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Description` | `string` | - |
| `StringId` | `string` | FK/correlación (convención) |
| `Permission_ActionUser` | `ICollection<Permission_ActionUser>` | Colección navegación |

### `AnalyzeCVData` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `AnalyzeCVDataId` | `int` | PK (convención) |
| `AnalyzeCVId` | `int` | FK/correlación (convención) |
| `FileToken` | `string` | - |
| `FileIdentifier` | `string` | - |
| `FileName` | `string` | - |
| `NumberPages` | `int` | - |
| `IsAnalyzed` | `bool` | - |
| `CreationDate` | `string` | - |
| `EmailMember` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `AnalyzeCVQueue` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `analyzefileid` | `int` | - |
| `isprocessed` | `bool` | - |
| `issuccess` | `bool` | - |
| `parameters` | `string` | - |
| `creationdate` | `DateTime` | - |
| `editiondate` | `DateTime` | - |
| `filegroupguid` | `string` | - |
| `filetokendalitica` | `string` | - |

### `Answer` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `AnswerId` | `int` | PK (convención) |
| `Text` | `string` | - |
| `YesNoResponse` | `bool` | - |
| `VideoURL` | `string` | - |
| `QuestionId` | `int` | FK/correlación (convención) |
| `Question` | `Question` | Navegación |
| `PostulationId` | `int` | FK/correlación (convención) |
| `Postulation` | `Postulation` | Navegación |

### `AttachedFile` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `AttachedFileId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `FileIdentifier` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `UploadDate` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `OtherName` | `string` | - |
| `FileType` | `FileType` | Navegación |
| `FileTypeId` | `int` | FK/correlación (convención) |

### `AttachedFileHiring` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `AttachedFileHiringId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `FileIdentifier` | `string` | - |
| `UploadDate` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `OtherName` | `string` | - |
| `HiringId` | `int` | FK/correlación (convención) |
| `Weight` | `double` | - |
| `Hash` | `string` | - |
| `IsUploadedByCandidate` | `bool` | - |
| `FileTypeHiring` | `FileTypeHiring` | Navegación |
| `FileTypeHiringId` | `int` | FK/correlación (convención) |

### `AttachedFileMail` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `AttachedFileMailId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `FileIdentifier` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `UploadDate` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `MailId` | `int` | FK/correlación (convención) |
| `Mail` | `Mail` | Navegación |

### `AttachedFileRemoteMail` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `AttachedFileRemoteMailId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `FileIdentifier` | `string` | - |
| `UploadDate` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `RemoteMailId` | `int` | FK/correlación (convención) |
| `RemoteMail` | `RemoteMail` | Navegación |

### `BasicInformation` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `BasicInformationId` | `int` | PK (convención) |
| `BasicInformationGuid` | `string` | - |
| `Photo` | `string` | - |
| `PhotoByAdmin` | `string` | - |
| `Name` | `string` | - |
| `Surname` | `string` | - |
| `Document` | `string` | - |
| `DocumentAdmin` | `string` | - |
| `Country` | `string` | - |
| `State` | `string` | - |
| `City` | `string` | - |
| `Address` | `string` | - |
| `AddressAdmin` | `string` | - |
| `Phone` | `string` | - |
| `Cellphone` | `string` | - |
| `BirthDate` | `string` | - |
| `BirthDateCompany` | `string` | - |
| `HaveWorkExperience` | `int` | - |
| `HaveWorkExperienceFromCompany` | `int` | - |
| `SalaryAspiration` | `string` | - |
| `SalaryAspirationFromCompany` | `string` | - |
| `OtherDocument` | `string` | - |
| `DocumentTypeIdAdmin` | `int` | - |
| `Phones` | `List<Phone>` | - |
| `Emails` | `List<Email>` | - |
| `SocialNetworks` | `List<SocialNetwork>` | - |
| `UserLinks` | `List<UserLink>` | - |
| `LinkedInURL` | `string` | - |
| `FacebookURL` | `string` | - |
| `TwitterURL` | `string` | - |
| `GitHubURL` | `string` | - |
| `BitBucketURL` | `string` | - |
| `MaritalStatusId` | `int` | FK/correlación (convención) |
| `MaritalStatus` | `MaritalStatus` | Navegación |
| `MaritalStatusCompanyId` | `int?` | FK/correlación (convención) |
| `Gender` | `Gender` | Navegación |
| `GenderId` | `int` | FK/correlación (convención) |
| `GenderCompanyId` | `int?` | FK/correlación (convención) |
| `CurrencyIdFromCompany` | `int?` | - |
| `CurrencyId` | `int` | FK/correlación (convención) |
| `Currency` | `Currency` | Navegación |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `DocumentType` | `DocumentType` | Navegación |
| `DocumentTypeId` | `int?` | FK/correlación (convención) |
| `DocumentCheck` | `DocumentCheck` | Navegación |
| `NameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |

### `BlockReason` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `BlockReasonId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Candidate_BlockReasons` | `List<Candidate_BlockReason>` | - |

### `CC` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CCId` | `int` | PK (convención) |
| `Email` | `string` | - |
| `MailId` | `int` | FK/correlación (convención) |
| `Mail` | `Mail` | Navegación |

### `CCO` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CCOId` | `int` | PK (convención) |
| `Email` | `string` | - |
| `MailId` | `int` | FK/correlación (convención) |
| `Mail` | `Mail` | Navegación |

### `CCORemote` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CCORemoteId` | `int` | PK (convención) |
| `Email` | `string` | - |
| `RemoteMailId` | `int` | FK/correlación (convención) |
| `RemoteMail` | `RemoteMail` | Navegación |

### `CCRemote` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CCRemoteId` | `int` | PK (convención) |
| `Email` | `string` | - |
| `RemoteMailId` | `int` | FK/correlación (convención) |
| `RemoteMail` | `RemoteMail` | Navegación |

### `CV` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CVId` | `int` | PK (convención) |
| `CVGuid` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `UploadDate` | `string` | - |
| `CvIdentifier` | `string` | - |
| `CvIdentifierLink` | `string` | - |
| `Name` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `OverViewCv` | `bool` | - |
| `FileType` | `FileType` | Navegación |
| `FileTypeId` | `int` | FK/correlación (convención) |
| `IsFromCandidate` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `CVHiring` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CVHiringId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `UploadDate` | `string` | - |
| `CvIdentifier` | `string` | - |
| `CvIdentifierLink` | `string` | - |
| `Name` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMemberUser` | `string` | - |
| `OverViewCv` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `HiringId` | `int` | FK/correlación (convención) |
| `Weight` | `double` | - |
| `Hash` | `string` | - |
| `IsFromCandidate` | `bool` | - |
| `FileTypeHiring` | `FileTypeHiring` | Navegación |
| `FileTypeHiringId` | `int` | FK/correlación (convención) |

### `CalendarEvent` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `CalendarEventId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnlgish` | `string` | - |
| `UID` | `string` | - |
| `Parameters` | `string` | - |
| `SyncDate` | `DateTime` | - |
| `Icon` | `string` | - |
| `Token` | `string` | - |
| `RefreshToken` | `string` | - |
| `MemberUser` | `MemberUser` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |

### `Candidate` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CandidateId` | `int` | PK (convención) |
| `CandidateGuid` | `string` | - |
| `Email` | `string` | - |
| `FullData` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CreationDate` | `string` | - |
| `CreationDateNoText` | `DateTime` | - |
| `EditionDate` | `string` | - |
| `DeleteDate` | `string` | - |
| `FullDeleteDate` | `string` | - |
| `FirstLoginDate` | `string` | - |
| `LoginCode` | `string` | - |
| `IsMigrated` | `int` | - |
| `IsFromCompanyAndLogin` | `bool` | - |
| `IsAuthDocuments` | `bool` | - |
| `IsAuthDocumentsHiring` | `bool` | - |
| `Source` | `string` | - |
| `IsNew` | `bool` | - |
| `isAuthorized` | `bool` | - |
| `IsDeleteProccess` | `bool` | - |
| `ViewHiringFiles` | `bool` | - |
| `ViewSelectionFiles` | `bool` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `EmailMember` | `string` | - |
| `EmailMemberDeleteProcess` | `string?` | - |
| `CompanyDescriptionList` | `ICollection<CompanyDescription>` | Colección navegación |
| `VideoList` | `ICollection<Video>` | Colección navegación |
| `StudyList` | `ICollection<Study>` | Colección navegación |
| `PersonalReferenceList` | `ICollection<PersonalReference>` | Colección navegación |
| `Candidate_TechnicalAbilityList` | `ICollection<Candidate_TechnicalAbility>` | Colección navegación |
| `Candidate_LifePreferenceList` | `ICollection<Candidate_LifePreference>` | Colección navegación |
| `Candidate_SoftSkillList` | `ICollection<Candidate_SoftSkill>` | Colección navegación |
| `Candidate_Wellness` | `ICollection<Candidate_Wellness>` | Colección navegación |
| `Candidate_TimeAvailability` | `ICollection<Candidate_TimeAvailability>` | Colección navegación |
| `Company_Candidate_Wellness` | `ICollection<Company_Candidate_Wellness>` | Colección navegación |
| `Company_Candidate_TimeAvailability` | `ICollection<Company_Candidate_TimeAvailability>` | Colección navegación |
| `WorkExperienceList` | `ICollection<WorkExperience>` | Colección navegación |
| `Candidate_Language` | `ICollection<Candidate_Language>` | Colección navegación |
| `Candidate_LanguageOther` | `ICollection<Candidate_LanguageOther>` | Colección navegación |
| `LanguageOther` | `ICollection<LanguageOther>` | Colección navegación |
| `Notes` | `ICollection<Note>` | Colección navegación |
| `Mails` | `ICollection<Mail>` | Colección navegación |
| `AttachedFilesHiring` | `ICollection<AttachedFileHiring>` | Colección navegación |
| `CVsHiring` | `ICollection<CVHiring>` | Colección navegación |
| `CandidateCompanies` | `ICollection<CandidateCompany>` | Colección navegación |
| `Candidate_Postulation` | `ICollection<Candidate_Postulation>` | Colección navegación |
| `Candidate_TalentGroup` | `ICollection<Candidate_TalentGroupAux>` | Colección navegación |
| `Candidate_Tag` | `ICollection<Candidate_Tag>` | Colección navegación |
| `Candidate_Source` | `ICollection<Candidate_Source>` | Colección navegación |
| `BasicInformation` | `BasicInformation` | Navegación |
| `Description` | `Description` | Navegación |
| `ExperienceCount` | `ExperienceCount` | Navegación |
| `Request` | `ICollection<Request>` | Colección navegación |

### `CandidateCompany` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CandidateCompanyId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Document` | `string` | - |
| `OtherDocument` | `string` | - |
| `DocumentTypeId` | `int?` | FK/correlación (convención) |
| `Address` | `string` | - |
| `BirthDate` | `string` | - |
| `HaveWorkExperience` | `int?` | - |
| `SalaryAspiration` | `string` | - |
| `Photo` | `string` | - |
| `Country` | `string` | - |
| `State` | `string` | - |
| `City` | `string` | - |
| `DescriptionId` | `int?` | FK/correlación (convención) |
| `MaritalStatusId` | `int?` | FK/correlación (convención) |
| `GenderId` | `int?` | FK/correlación (convención) |
| `CurrencyId` | `int?` | FK/correlación (convención) |
| `IsPotential` | `bool` | - |

### `CandidateOrigin` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CandidateOriginId` | `int` | PK (convención) |
| `IsMigrated` | `int` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |

### `CandidateRecruitee` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CandidateRecruiteeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Photo` | `string` | - |
| `Email` | `string` | - |
| `Phone` | `string` | - |
| `FullData` | `bool` | - |
| `CreationDate` | `string` | - |

### `Candidate_BlockReason` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_BlockReasonId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `BlockReasonId` | `int` | FK/correlación (convención) |
| `CandidateBlockDate` | `DateTime` | - |
| `BlockReason` | `BlockReason` | Navegación |

### `Candidate_Language` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_LanguageId` | `int` | PK (convención) |
| `Candidate_LanguageGuid` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Language` | `Language` | Navegación |
| `LanguageId` | `int` | FK/correlación (convención) |
| `LanguageLevel` | `LanguageLevel` | Navegación |
| `LanguageLevelId` | `int` | FK/correlación (convención) |
| `AdminView` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_LanguageOther` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_LanguageOtherId` | `int` | PK (convención) |
| `Candidate_LanguageOtherGuid` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `LanguageOther` | `LanguageOther` | Navegación |
| `LanguageOtherId` | `int` | FK/correlación (convención) |
| `LanguageLevel` | `LanguageLevel` | Navegación |
| `LanguageLevelId` | `int` | FK/correlación (convención) |
| `AdminView` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_LifePreference` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_LifePreferenceId` | `int` | PK (convención) |
| `Candidate_LifePreferenceGuid` | `string` | - |
| `OtherLifePreference` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `LifePreference` | `LifePreference` | Navegación |
| `LifePreferenceId` | `int` | FK/correlación (convención) |
| `IsFromCandidate` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_Postulation` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_PostulationId` | `int` | PK (convención) |
| `PostulationId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `JobPostingStatusId` | `int` | FK/correlación (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |

### `Candidate_SoftSkill` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_SoftSkillId` | `int` | PK (convención) |
| `Candidate_SoftSkillGuid` | `string` | - |
| `Description` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `SoftSkill` | `SoftSkill` | Navegación |
| `SoftSkillId` | `int` | FK/correlación (convención) |
| `IsFromEmpresaAdded` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_Source` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_SourceId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `SourceId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `CreationDate` | `DateTime` | - |
| `Source` | `Source` | Navegación |
| `CompanyUserId` | `int?` | FK/correlación (convención) |

### `Candidate_Tag` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_TagId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `TagId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `CreationDate` | `DateTime` | - |
| `Tag` | `Tag` | Navegación |
| `CompanyUserId` | `int?` | FK/correlación (convención) |

### `Candidate_TalentGroup` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_TalentGroupId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `TalentGroupId` | `int` | FK/correlación (convención) |
| `TalentGroup` | `TalentGroup` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_TalentGroupAux` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_TalentGroupAuxId` | `int` | PK (convención) |
| `TalentGroupId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `TalentGroupStatusId` | `int` | FK/correlación (convención) |
| `TalentGroupPostingStatusId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |

### `Candidate_TechnicalAbility` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_TechnicalAbilityId` | `int` | PK (convención) |
| `Candidate_TechnicalAbilityGuid` | `string` | - |
| `Other` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Discipline` | `string` | - |
| `TechnicalAbilityTechnology` | `TechnicalAbilityTechnology` | Navegación |
| `TechnicalAbilityTechnologyId` | `int` | FK/correlación (convención) |
| `TechnicalAbilityLevel` | `TechnicalAbilityLevel` | Navegación |
| `TechnicalAbilityLevelId` | `int?` | FK/correlación (convención) |
| `IsFromEmpresaAdded` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Candidate_TimeAvailability` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_TimeAvailabilityId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `TimeAvailability` | `TimeAvailability` | Navegación |
| `TimeAvailabilityId` | `int` | FK/correlación (convención) |

### `Candidate_Wellness` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Candidate_WellnessId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Wellness` | `Wellness` | Navegación |
| `WellnessId` | `int` | FK/correlación (convención) |

### `CertificationState` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CertificationStateId` | `int` | PK (convención) |
| `CertificationStateGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `StudyList` | `ICollection<Study>` | Colección navegación |

### `CompanyDescription` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CompanyDescriptionId` | `int` | PK (convención) |
| `Text` | `string` | - |
| `YearsExperience` | `string` | - |
| `NumberCompanies` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `CompanyUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `CompanyUserId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Address` | `string` | - |
| `Phone` | `string` | - |
| `Email` | `string` | - |
| `Country` | `string` | - |
| `Region` | `string` | - |
| `City` | `string` | - |
| `CountryName` | `string` | - |
| `RegionName` | `string` | - |
| `CityName` | `string` | - |
| `Prefix` | `string` | - |
| `Domain` | `string` | - |
| `LogoIdentifier` | `string` | - |
| `BlockReasons` | `ICollection<BlockReason>` | Colección navegación |
| `MemberUsers` | `ICollection<MemberUser>` | Colección navegación |

### `Company_Candidate_TimeAvailability` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Company_Candidate_TimeAvailabilityId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `TimeAvailability` | `TimeAvailability` | Navegación |
| `TimeAvailabilityId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Company_Candidate_Wellness` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Company_Candidate_WellnessId` | `int` | PK (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Wellness` | `Wellness` | Navegación |
| `WellnessId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Currency` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `CurrencyId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `ShortName` | `string` | - |
| `ShortNameEnglish` | `string` | - |
| `BasicInformations` | `List<BasicInformation>` | - |

### `DefaultBlockReason` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `DefaultBlockReasonId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |

### `DefaultEvaluationCriteria` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `DefaultEvaluationCriteriaId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `MaxPercent` | `int` | - |
| `EvaluationCriteriaTypeId` | `int` | FK/correlación (convención) |
| `EvaluationCriteriaType` | `EvaluationCriteriaType` | Navegación |

### `DefaultPercentCriteria` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `DefaultPercentCriteriaId` | `int` | PK (convención) |
| `PercentObjectiveValue` | `int` | - |
| `PercentObjectiveDecimal` | `double` | - |
| `PercentSubjectiveValue` | `int` | - |
| `PercentSubjectiveDecimal` | `double` | - |

### `Description` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `DescriptionId` | `int` | PK (convención) |
| `DescriptionGuid` | `string` | - |
| `Text` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `EditionDate` | `string` | - |

### `DisqualificationReason` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `DisqualificationReasonId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |

### `DocumentCheck` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `DocumentCheckId` | `int` | PK (convención) |
| `OrderId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `IsCheck` | `bool` | - |
| `IsEnabled` | `bool` | - |
| `Text` | `string` | - |
| `DocumentCheckStateId` | `int` | FK/correlación (convención) |
| `DocumentCheckState` | `DocumentCheckState` | Navegación |
| `DocumentCheckGroupId` | `int` | FK/correlación (convención) |
| `DocumentCheckGroup` | `DocumentCheckGroup` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `DocumentCheckGroup` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `DocumentCheckGroupId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `DocumentCheks` | `ICollection<DocumentCheck>` | Colección navegación |

### `DocumentCheckState` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `DocumentCheckStateId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `DocumentCheks` | `ICollection<DocumentCheck>` | Colección navegación |

### `DocumentType` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `DocumentTypeId` | `int` | PK (convención) |
| `DocumentTypeGuid` | `string` | - |
| `Initials` | `string` | - |
| `InitialsEnglish` | `string` | - |
| `BasicInformationList` | `ICollection<BasicInformation>` | Colección navegación |

### `Duration` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `DurationId` | `int` | PK (convención) |
| `DurationName` | `string` | - |
| `DurationNameEnglish` | `string` | - |
| `Event` | `ICollection<Event>` | Colección navegación |

### `Email` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `EmailId` | `int` | PK (convención) |
| `Mail` | `string` | - |
| `BasicInformationId` | `int` | FK/correlación (convención) |
| `BasicInformation` | `BasicInformation` | Navegación |
| `CompanyUserId` | `int?` | FK/correlación (convención) |

### `EquivalentPosition` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `EquivalentPositionId` | `int` | PK (convención) |
| `EquivalentPositionGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |

### `Evaluation` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `EvaluationId` | `int` | PK (convención) |
| `Observation` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |
| `MemberUserName` | `string` | - |
| `MemberUserInitials` | `string` | - |
| `MemberUserEmail` | `string` | - |
| `MemberUserPhoto` | `string` | - |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `CreationDate` | `DateTime` | - |
| `Evaluation_EvaluationCriteria` | `ICollection<Evaluation_EvaluationCriteria>` | Colección navegación |
| `JobId` | `int` | FK/correlación (convención) |
| `TalentGroupId` | `int` | FK/correlación (convención) |

### `EvaluationCriteria` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `EvaluationCriteriaId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `MaxPercent` | `int` | - |
| `IsMandatory` | `bool` | - |
| `EvaluationCriteriaTypeId` | `int` | FK/correlación (convención) |
| `EvaluationCriteriaType` | `EvaluationCriteriaType` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |

### `EvaluationCriteriaType` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `EvaluationCriteriaTypeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `DefaultEvaluationCriteria` | `ICollection<DefaultEvaluationCriteria>` | Colección navegación |
| `EvaluationCriteria` | `ICollection<EvaluationCriteria>` | Colección navegación |

### `Evaluation_EvaluationCriteria` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Evaluation_EvaluationCriteriaId` | `int` | PK (convención) |
| `EvaluationId` | `int` | FK/correlación (convención) |
| `Evaluation` | `Evaluation` | Navegación |
| `EvaluationCriteriaId` | `int` | FK/correlación (convención) |
| `EvaluationCriteriaTypeId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `MaxPercent` | `int` | - |
| `IsMandatory` | `bool` | - |
| `Value` | `int` | - |

### `Event` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `EventId` | `int` | PK (convención) |
| `StartDate` | `DateTime` | - |
| `EndDate` | `DateTime` | - |
| `StartTime` | `string` | - |
| `EndingTime` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `EmailMemberUser` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `Location` | `string?` | - |
| `Note` | `string?` | - |
| `PrivateNote` | `string?` | - |
| `DurationId` | `int` | FK/correlación (convención) |
| `Duration` | `Duration` | Navegación |
| `EventTypeId` | `int` | FK/correlación (convención) |
| `EventType` | `EventType` | Navegación |
| `TimeZoneEventId` | `int` | FK/correlación (convención) |
| `TimeZoneEvent` | `TimeZoneEvent` | Navegación |
| `UID` | `string` | - |
| `CalendarEventId` | `int` | FK/correlación (convención) |
| `Event_MemberUser` | `ICollection<Event_MemberUser>` | Colección navegación |

### `EventType` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `EventTypeId` | `int` | PK (convención) |
| `EventName` | `string` | - |
| `EventNameEnglish` | `string` | - |
| `Event` | `ICollection<Event>` | Colección navegación |

### `Event_MemberUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Event_MemberUserId` | `int` | PK (convención) |
| `EventId` | `int` | FK/correlación (convención) |
| `Event` | `Event` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `ExperienceCount` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `ExperienceCountId` | `int` | PK (convención) |
| `Years` | `string` | - |
| `CompaniesNumber` | `int` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |

### `FileGroupQueue` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `filegroupid` | `int` | - |
| `filegroupguid` | `string` | - |
| `isprocessed` | `bool` | - |
| `issuccess` | `bool` | - |
| `emailmemberuser` | `string` | - |
| `creationdate` | `DateTime` | - |
| `editiondate` | `DateTime` | - |

### `FileType` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `FileTypeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `OrderList` | `int` | - |
| `AttachedFiles` | `ICollection<AttachedFile>` | Colección navegación |
| `CVs` | `ICollection<CV>` | Colección navegación |

### `FileTypeHiring` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `FileTypeHiringId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `OrderId` | `int` | FK/correlación (convención) |
| `AttachedFiles` | `ICollection<AttachedFileHiring>` | Colección navegación |
| `CVs` | `ICollection<CVHiring>` | Colección navegación |

### `FollowJob` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `FollowJobId` | `int` | PK (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `FollowTalentGroup` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `FollowTalentGroupId` | `int` | PK (convención) |
| `TalentGroupId` | `int` | FK/correlación (convención) |
| `TalentGroup` | `TalentGroup` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `Gender` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `GenderId` | `int` | PK (convención) |
| `GenderGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `BasicInformationList` | `ICollection<BasicInformation>` | Colección navegación |

### `GenderCompany` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `GenderCompanyId` | `int` | PK (convención) |
| `GenderGuid` | `string` | - |
| `Name` | `string` | - |
| `Gender` | `Gender` | Navegación |
| `GenderId` | `int` | FK/correlación (convención) |

### `GuestUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `GuestUserId` | `int` | PK (convención) |
| `Email` | `string` | - |
| `Code` | `string` | - |
| `IsAccepted` | `bool` | - |
| `InvitationDate` | `string` | - |
| `InvitationDateFormat` | `string` | - |
| `InvitationMessage` | `string` | - |
| `CompanyUser` | `CompanyUser` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Role` | `Role` | Navegación |
| `RoleId` | `int` | FK/correlación (convención) |
| `GuestUser_Job` | `ICollection<GuestUser_Job>` | Colección navegación |
| `GuestUser_TG` | `ICollection<GuestUser_TG>` | Colección navegación |

### `GuestUser_Job` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `GuestUser_JobId` | `int` | PK (convención) |
| `GuestUserId` | `int` | FK/correlación (convención) |
| `GuestUser` | `GuestUser` | Navegación |
| `JobId` | `int` | FK/correlación (convención) |

### `GuestUser_TG` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `GuestUser_TGId` | `int` | PK (convención) |
| `GuestUserId` | `int` | FK/correlación (convención) |
| `GuestUser` | `GuestUser` | Navegación |
| `TalentGroupId` | `int` | FK/correlación (convención) |

### `ICS` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `ICSId` | `int` | PK (convención) |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `Industry` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `IndustryId` | `int` | PK (convención) |
| `IndustryGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `WorkExperienceList` | `ICollection<WorkExperience>` | Colección navegación |

### `InternalCode` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `InternalCodeId` | `int` | PK (convención) |
| `InternalCodeName` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |
| `Jobs` | `List<Job>` | - |
| `TalentGroup` | `ICollection<TalentGroup>` | Colección navegación |

### `Job` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobId` | `int` | PK (convención) |
| `CreationDate` | `DateTime?` | - |
| `PublicationDate` | `DateTime?` | - |
| `ClosingDate` | `DateTime?` | - |
| `FilingDate` | `DateTime?` | - |
| `DeletionDate` | `DateTime?` | - |
| `EditedDate` | `DateTime?` | - |
| `JobValidity` | `DateTime?` | - |
| `Name` | `string` | - |
| `Description` | `string?` | - |
| `ShowSalary` | `bool` | - |
| `Gender` | `string?` | - |
| `IsRemote` | `bool?` | - |
| `IsEdit` | `bool` | - |
| `Validity` | `int?` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `MemberEmail` | `string` | - |
| `JobSalary` | `string` | - |
| `JobStatusId` | `int?` | FK/correlación (convención) |
| `JobSectorName` | `string` | - |
| `IsCreationAndPublication` | `bool` | - |
| `IsConfidential` | `bool` | - |
| `JobPostingStatus` | `JobPostingStatus` | Navegación |
| `JobPostingStatusId` | `int?` | FK/correlación (convención) |
| `InternalCodeId` | `int?` | FK/correlación (convención) |
| `InternalCode` | `InternalCode` | Navegación |
| `JobLocationId` | `int?` | FK/correlación (convención) |
| `JobLocation` | `JobLocation` | Navegación |
| `JobLevelId` | `int?` | FK/correlación (convención) |
| `JobLevel` | `JobLevel` | Navegación |
| `JobSubLevelId` | `int?` | FK/correlación (convención) |
| `JobSubLevel` | `JobSubLevel` | Navegación |
| `WorkAreaId` | `int?` | FK/correlación (convención) |
| `WorkArea` | `WorkArea` | Navegación |
| `JobContractId` | `int?` | FK/correlación (convención) |
| `JobContract` | `JobContract` | Navegación |
| `JobEducationLevelId` | `int?` | FK/correlación (convención) |
| `JobEducationLevel` | `JobEducationLevel` | Navegación |
| `JobExperienceId` | `int?` | FK/correlación (convención) |
| `JobExperience` | `JobExperience` | Navegación |
| `JobModalityId` | `int?` | FK/correlación (convención) |
| `JobModality` | `JobModality` | Navegación |
| `JobSectorId` | `int?` | FK/correlación (convención) |
| `JobSector` | `JobSector` | Navegación |
| `Job_OtherSector` | `Job_OtherSector` | Navegación |
| `JobCurrencyId` | `int` | FK/correlación (convención) |
| `JobCurrency` | `JobCurrency` | Navegación |
| `JobLocationModalityId` | `int` | FK/correlación (convención) |
| `JobLocationModality` | `JobLocationModality` | Navegación |
| `JobTypeId` | `int` | FK/correlación (convención) |
| `JobType` | `JobType` | Navegación |
| `FollowJob` | `ICollection<FollowJob>` | Colección navegación |
| `Postulations` | `ICollection<Postulation>` | Colección navegación |
| `Job_JobSoftSkill` | `ICollection<Job_JobSoftSkill>` | Colección navegación |
| `Job_JobTechnicalAbility` | `ICollection<Job_JobTechnicalAbility>` | Colección navegación |
| `Job_OtherTechnicalAbility` | `ICollection<Job_OtherTechnicalAbility>` | Colección navegación |
| `Job_JobProfession` | `ICollection<Job_JobProfession>` | Colección navegación |
| `Job_OtherProfession` | `ICollection<Job_OtherProfession>` | Colección navegación |
| `Job_JobLanguage` | `ICollection<Job_JobLanguage>` | Colección navegación |
| `Job_OtherLanguage` | `ICollection<Job_OtherLanguage>` | Colección navegación |
| `Job_MemberUser` | `ICollection<Job_MemberUser>` | Colección navegación |
| `Questions` | `ICollection<Question>` | Colección navegación |

### `JobContract` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobContractId` | `int` | PK (convención) |
| `Contract` | `string` | - |
| `ContractEnglish` | `string` | - |
| `Job` | `List<Job>` | - |

### `JobCurrency` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobCurrencyId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `ShortName` | `string` | - |
| `ShortNameEnglish` | `string` | - |
| `Jobs` | `List<Job>` | - |

### `JobEducationLevel` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobEducationLevelId` | `int` | PK (convención) |
| `EducationLevel` | `string` | - |
| `EducationLevelEnglish` | `string` | - |
| `Job` | `List<Job>` | - |

### `JobExperience` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobExperienceId` | `int` | PK (convención) |
| `Experience` | `string` | - |
| `ExperienceEnglish` | `string` | - |
| `Job` | `List<Job>` | - |

### `JobLanguage` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobLanguageId` | `int` | PK (convención) |
| `Language` | `string` | - |
| `LanguageEnglish` | `string` | - |
| `Job_JobLanguages` | `ICollection<Job_JobLanguage>` | Colección navegación |

### `JobLanguageLevel` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobLanguageLevelId` | `int` | PK (convención) |
| `LanguageLevel` | `string` | - |
| `LanguageLevelEnglish` | `string` | - |
| `Job_JobLanguage` | `ICollection<Job_JobLanguage>` | Colección navegación |
| `Job_OtherLanguage` | `ICollection<Job_OtherLanguage>` | Colección navegación |

### `JobLevel` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobLevelId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Job` | `List<Job>` | - |
| `JobSubLevels` | `List<JobSubLevel>` | - |

### `JobLocation` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobLocationId` | `int` | PK (convención) |
| `Country` | `string` | - |
| `Region` | `string` | - |
| `City` | `string` | - |
| `Address` | `string` | - |
| `CountryName` | `string` | - |
| `RegionName` | `string` | - |
| `CityName` | `string` | - |
| `Job` | `Job` | Navegación |

### `JobLocationModality` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobLocationModalityId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Jobs` | `List<Job>` | - |

### `JobModality` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobModalityId` | `int` | PK (convención) |
| `Modality` | `string` | - |
| `ModalityEnglish` | `string` | - |
| `Job` | `List<Job>` | - |

### `JobPostingStatus` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobPostingStatusId` | `int` | PK (convención) |
| `Status` | `string` | - |
| `StatusEnglish` | `string` | - |
| `StatusAction` | `string` | - |
| `Job` | `ICollection<Job>` | Colección navegación |

### `JobProfession` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobProfessionId` | `int` | PK (convención) |
| `Profession` | `string` | - |
| `ProfessionEnglish` | `string` | - |

### `JobSector` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobSectorId` | `int` | PK (convención) |
| `Sector` | `string` | - |
| `SectorEnglish` | `string` | - |
| `Job` | `List<Job>` | - |

### `JobSoftSkill` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobSoftSkillId` | `int` | PK (convención) |
| `SoftSkillName` | `string` | - |
| `SoftSkillNameEnglish` | `string` | - |
| `Job_JobSoftSkills` | `ICollection<Job_JobSoftSkill>` | Colección navegación |

### `JobSubLevel` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobSubLevelId` | `int` | PK (convención) |
| `JobLevelId` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `JobLevel` | `JobLevel` | Navegación |

### `JobTechnicalAbility` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobTechnicalAbilityId` | `int` | PK (convención) |
| `Discipline` | `string` | - |
| `DisciplineEnglish` | `string` | - |
| `Job_JobTechnicalAbilities` | `ICollection<Job_JobTechnicalAbility>` | Colección navegación |

### `JobTechnicalAbilityLevel` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobTechnicalAbilityLevelId` | `int` | PK (convención) |
| `Level` | `string` | - |
| `LevelEnglish` | `string` | - |
| `Job_JobTechnicalAbility` | `ICollection<Job_JobTechnicalAbility>` | Colección navegación |
| `Job_OtherTechnicalAbility` | `ICollection<Job_OtherTechnicalAbility>` | Colección navegación |

### `JobType` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `JobTypeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `IsEditable` | `bool` | - |
| `IsDeleteable` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CreationDate` | `DateTime` | - |
| `Jobs` | `ICollection<Job>` | Colección navegación |

### `Job_JobLanguage` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_JobLanguageId` | `int` | PK (convención) |
| `JobId` | `int?` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobLanguageId` | `int?` | FK/correlación (convención) |
| `JobLanguage` | `JobLanguage` | Navegación |
| `JobLanguageLevelId` | `int?` | FK/correlación (convención) |
| `JobLanguageLevel` | `JobLanguageLevel` | Navegación |

### `Job_JobProfession` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_JobProfessionId` | `int` | PK (convención) |
| `JobId` | `int?` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobProfessionId` | `int?` | FK/correlación (convención) |
| `JobProfession` | `JobProfession` | Navegación |
| `Name` | `string` | - |

### `Job_JobSoftSkill` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_JobSoftSkillId` | `int` | PK (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobSoftSkillId` | `int` | FK/correlación (convención) |
| `JobSoftSkill` | `JobSoftSkill` | Navegación |
| `Name` | `string` | - |

### `Job_JobTechnicalAbility` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_JobTechnicalAbilityId` | `int` | PK (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobTechnicalAbilityId` | `int` | FK/correlación (convención) |
| `JobTechnicalAbility` | `JobTechnicalAbility` | Navegación |
| `JobTechnicalAbilityLevelId` | `int` | FK/correlación (convención) |
| `JobTechnicalAbilityLevel` | `JobTechnicalAbilityLevel` | Navegación |

### `Job_MemberUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_MemberUserId` | `int` | PK (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `Job_OtherLanguage` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_OtherLanguageId` | `int` | PK (convención) |
| `JobId` | `int?` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobLanguageLevelId` | `int?` | FK/correlación (convención) |
| `JobLanguageLevel` | `JobLanguageLevel` | Navegación |
| `Language` | `string` | - |

### `Job_OtherProfession` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_OtherProfessionId` | `int` | PK (convención) |
| `JobId` | `int?` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `Profession` | `string` | - |

### `Job_OtherSector` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_OtherSectorId` | `int` | PK (convención) |
| `Sector` | `string` | - |
| `JobId` | `int?` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |

### `Job_OtherTechnicalAbility` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Job_OtherTechnicalAbilityId` | `int` | PK (convención) |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `JobTechnicalAbilityLevelId` | `int` | FK/correlación (convención) |
| `JobTechnicalAbilityLevel` | `JobTechnicalAbilityLevel` | Navegación |
| `TechnicalAbility` | `string` | - |

### `Language` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `LanguageId` | `int` | PK (convención) |
| `LanguageGuid` | `string` | - |
| `LanguageName` | `string` | - |
| `LanguageNameEnglish` | `string` | - |
| `Candidate_Language` | `ICollection<Candidate_Language>` | Colección navegación |

### `LanguageLevel` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `LanguageLevelId` | `int` | PK (convención) |
| `LanguageLevelGuid` | `string` | - |
| `LanguageLevelName` | `string` | - |
| `LanguageLevelNameEnglish` | `string` | - |
| `Candidate_Language` | `ICollection<Candidate_Language>` | Colección navegación |
| `Candidate_LanguageOther` | `ICollection<Candidate_LanguageOther>` | Colección navegación |

### `LanguageOther` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `LanguageOtherId` | `int` | PK (convención) |
| `LanguageOtherGuid` | `string` | - |
| `LanguageOtherName` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `AdminView` | `bool` | - |
| `Candidate` | `Candidate` | Navegación |

### `LifePreference` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `LifePreferenceId` | `int` | PK (convención) |
| `LifePreferenceGuid` | `string` | - |
| `LifePreferenceName` | `string` | - |
| `LifePreferenceNameEnglish` | `string` | - |
| `Candidate_LifePreferenceList` | `ICollection<Candidate_LifePreference>` | Colección navegación |

### `Mail` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `MailId` | `int` | PK (convención) |
| `Subject` | `string` | - |
| `MailDescription` | `string` | - |
| `CreationDate` | `string` | - |
| `EmailMember` | `string` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `MailOwnerId` | `int` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `MessageId` | `string` | FK/correlación (convención) |
| `AttachedFilesMail` | `ICollection<AttachedFileMail>` | Colección navegación |
| `CC` | `ICollection<CC>` | Colección navegación |
| `CCO` | `ICollection<CCO>` | Colección navegación |

### `MaritalStatus` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `MaritalStatusId` | `int` | PK (convención) |
| `MaritalStatusGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `BasicInformationList` | `ICollection<BasicInformation>` | Colección navegación |

### `MaritalStatusCompany` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `MaritalStatusCompanyId` | `int` | PK (convención) |
| `MaritalStatusGuid` | `string` | - |
| `Name` | `string` | - |
| `MaritalStatus` | `MaritalStatus` | Navegación |
| `MaritalStatusId` | `int` | FK/correlación (convención) |

### `MemberUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `MemberUserId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Surname` | `string` | - |
| `Email` | `string` | - |
| `Phone` | `string` | - |
| `LoginCode` | `string` | - |
| `Photo` | `string` | - |
| `PhotoName` | `string` | - |
| `ShowNewFeatures` | `bool` | - |
| `CandidateProfileId` | `int` | FK/correlación (convención) |
| `CandidateProfileDate` | `DateTime` | - |
| `CompanyUser` | `CompanyUser` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Role` | `Role` | Navegación |
| `RoleId` | `int` | FK/correlación (convención) |
| `State` | `int` | - |
| `MemberUserTalentGroup` | `ICollection<MemberUserTalentGroup>` | Colección navegación |
| `FollowJob` | `ICollection<FollowJob>` | Colección navegación |
| `FollowTalentGroup` | `ICollection<FollowTalentGroup>` | Colección navegación |
| `Notification` | `ICollection<Notification>` | Colección navegación |
| `Job_MemberUser` | `ICollection<Job_MemberUser>` | Colección navegación |
| `memberUser_TGComercial` | `ICollection<MemberUser_TGComercial>` | Colección navegación |
| `searchHistory` | `ICollection<SearchHistory>` | Colección navegación |
| `Event_MemberUser` | `ICollection<Event_MemberUser>` | Colección navegación |
| `CalendarEvent` | `ICollection<CalendarEvent>` | Colección navegación |
| `ICSs` | `ICollection<ICS>` | Colección navegación |
| `Evaluations` | `ICollection<Evaluation>` | Colección navegación |
| `Evaluation_EvaluationCriteria` | `ICollection<Evaluation_EvaluationCriteria>` | Colección navegación |

### `MemberUserTalentGroup` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `MemberUserTalentGroupId` | `int` | PK (convención) |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |
| `TalentGroupId` | `int` | FK/correlación (convención) |
| `TalentGroup` | `TalentGroup` | Navegación |

### `MemberUser_TGComercial` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `MemberUser_TGComercialId` | `int` | PK (convención) |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |
| `TalentGroupId` | `int` | FK/correlación (convención) |

### `MentionMemberUser` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `MentionMemberUserId` | `int` | PK (convención) |
| `MemberId` | `int` | FK/correlación (convención) |
| `Note` | `Note` | Navegación |
| `NoteId` | `int` | FK/correlación (convención) |

### `Note` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `NoteId` | `int` | PK (convención) |
| `NoteDescription` | `string` | - |
| `MemberId` | `int` | FK/correlación (convención) |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `CreationDate` | `string` | - |
| `FileName` | `string` | - |
| `FileIdentifier` | `string` | - |
| `FileUploadDate` | `string` | - |
| `EmailMember` | `string` | - |
| `PinUp` | `bool` | - |
| `Available` | `bool` | - |
| `DatePinUp` | `DateTime?` | - |
| `NoteOwnerId` | `int?` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `MentionMemberUsers` | `ICollection<MentionMemberUser>` | Colección navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Notification` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `NotificationId` | `int` | PK (convención) |
| `message` | `string` | - |
| `CreationDate` | `DateTime` | - |
| `IsRead` | `bool` | - |
| `Initials` | `string` | - |
| `photo` | `string?` | - |
| `NotificationTypeId` | `int` | FK/correlación (convención) |
| `NotificationType` | `NotificationType` | Navegación |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |
| `CandidateId` | `int?` | FK/correlación (convención) |

### `NotificationType` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `NotificationTypeId` | `int` | PK (convención) |
| `Message` | `string` | - |
| `Notification` | `ICollection<Notification>` | Colección navegación |

### `PercentCriteria` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PercentCriteriaId` | `int` | PK (convención) |
| `PercentObjectiveValue` | `int` | - |
| `PercentObjectiveDecimal` | `double` | - |
| `PercentSubjectiveValue` | `int` | - |
| `PercentSubjectiveDecimal` | `double` | - |
| `EditionDate` | `DateTime` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |

### `Permission` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PermissionId` | `int` | PK (convención) |
| `PermissionGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Description` | `string` | - |
| `DescriptionEnglish` | `string` | - |
| `PermissionGroupId` | `int` | FK/correlación (convención) |
| `PermissionGroup` | `PermissionGroup` | Navegación |
| `Permission_RoleList` | `ICollection<Permission_Role>` | Colección navegación |
| `PermissionActivities` | `ICollection<PermissionActivity>` | Colección navegación |
| `Permission_ActionUser` | `ICollection<Permission_ActionUser>` | Colección navegación |

### `PermissionActivity` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PermissionActivityId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Description` | `string` | - |
| `IsAllowed` | `bool` | - |
| `PermissionId` | `int` | FK/correlación (convención) |
| `Permission` | `Permission` | Navegación |

### `PermissionGroup` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PermissionGroupId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Permissions` | `List<Permission>` | - |

### `PermissionRoleRepository` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|

### `Permission_ActionUser` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Permission_ActionUserId` | `int` | PK (convención) |
| `PermissionId` | `int` | FK/correlación (convención) |
| `Permission` | `Permission` | Navegación |
| `ActionUserId` | `int` | FK/correlación (convención) |
| `ActionUser` | `ActionUser` | Navegación |

### `Permission_Role` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `Permission_RoleId` | `int` | PK (convención) |
| `Permission` | `Permission` | Navegación |
| `PermissionId` | `int` | FK/correlación (convención) |
| `IsCheck` | `bool` | - |
| `IsDisabled` | `bool` | - |
| `Role` | `Role` | Navegación |
| `RoleId` | `int` | FK/correlación (convención) |

### `PersonalReference` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `PersonalReferenceId` | `int` | PK (convención) |
| `ReferenceName` | `string` | - |
| `ReferenceSurname` | `string` | - |
| `RelationTypeId` | `int?` | FK/correlación (convención) |
| `PhoneNumber` | `string` | - |
| `AditionalNumber` | `string` | - |
| `Country` | `string` | - |
| `State` | `string` | - |
| `City` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `RelationType` | `RelationType` | Navegación |
| `OtherRelationtype` | `string` | - |
| `CandidateId` | `int` | FK/correlación (convención) |
| `CountryName` | `string` | - |
| `StateName` | `string` | - |
| `CityName` | `string` | - |
| `IsAddefromCompany` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Phone` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `PhoneId` | `int` | PK (convención) |
| `Number` | `string` | - |
| `BasicInformationId` | `int` | FK/correlación (convención) |
| `BasicInformation` | `BasicInformation` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Postulation` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PostulationId` | `int` | PK (convención) |
| `CandidateId` | `int` | FK/correlación (convención) |
| `PostulationDate` | `DateTime` | - |
| `PostulationBlockDate` | `DateTime` | - |
| `BlockReasonId` | `int?` | FK/correlación (convención) |
| `BlockReason` | `BlockReason` | Navegación |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `DisqualificationReasonId` | `int` | FK/correlación (convención) |
| `PostulationStageId` | `int` | FK/correlación (convención) |
| `LastPostulationStageId` | `int` | FK/correlación (convención) |
| `IsLiked` | `bool` | - |
| `IsNew` | `bool` | - |
| `PostulationStage` | `PostulationStage` | Navegación |
| `IsCreatedByCandidate` | `bool` | - |
| `CompanyUserId` | `int?` | FK/correlación (convención) |
| `AcceptResponses` | `bool` | - |
| `Answers` | `ICollection<Answer>` | Colección navegación |

### `PostulationStage` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PostulationStageId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Postulations` | `ICollection<Postulation>` | Colección navegación |
| `PostulationStateId` | `int` | FK/correlación (convención) |
| `PostulationState` | `PostulationState` | Navegación |

### `PostulationState` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `PostulationStateId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `PostulationStages` | `ICollection<PostulationStage>` | Colección navegación |

### `Question` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `QuestionId` | `int` | PK (convención) |
| `Text` | `string` | - |
| `IsMandatory` | `bool` | - |
| `QuestionTypeId` | `int` | FK/correlación (convención) |
| `QuestionType` | `QuestionType` | Navegación |
| `JobId` | `int` | FK/correlación (convención) |
| `Job` | `Job` | Navegación |
| `Answers` | `ICollection<Answer>` | Colección navegación |

### `QuestionType` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `QuestionTypeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Questions` | `ICollection<Question>` | Colección navegación |

### `RecruiteeCandidateRaw` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `RecruiteeCandidateRawId` | `int` | PK (convención) |
| `RecruiteeId` | `int` | FK/correlación (convención) |
| `BasicData` | `string` | - |
| `OtherData` | `string` | - |
| `Notes` | `string` | - |
| `Photo` | `string` | - |
| `CV` | `string` | - |

### `RelationType` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `RelationTypeId` | `int` | PK (convención) |
| `RelationTypeGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `PersonalReferenceList` | `ICollection<PersonalReference>` | Colección navegación |

### `RemoteMail` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `RemoteMailId` | `int` | PK (convención) |
| `Subject` | `string` | - |
| `MailDescription` | `string` | - |
| `CreationDate` | `string` | - |
| `From` | `string` | - |
| `To` | `string` | - |
| `MailOwnerId` | `string` | FK/correlación (convención) |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `MessageId` | `string` | FK/correlación (convención) |
| `AttachedFilesRemoteMail` | `ICollection<AttachedFileRemoteMail>` | Colección navegación |
| `CC` | `ICollection<CCRemote>` | Colección navegación |
| `CCO` | `ICollection<CCORemote>` | Colección navegación |

### `Request` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `RequestId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Surname` | `string` | - |
| `CreationDate` | `DateTime` | - |
| `Message` | `string` | - |
| `RequestTypeId` | `int` | FK/correlación (convención) |
| `RequestType` | `RequestType` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `Candidate` | `Candidate` | Navegación |

### `RequestType` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `RequestTypeId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `Request` | `ICollection<Request>` | Colección navegación |

### `Role` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `RoleId` | `int` | PK (convención) |
| `RoleGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `CompanyUser` | `CompanyUser` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `Permission_RoleList` | `ICollection<Permission_Role>` | Colección navegación |
| `GuestUserList` | `ICollection<GuestUser>` | Colección navegación |
| `MemberUserList` | `ICollection<MemberUser>` | Colección navegación |

### `SearchHistory` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `SearchHistoryId` | `int` | PK (convención) |
| `CandidateId` | `int?` | FK/correlación (convención) |
| `TalentGroupId` | `int?` | FK/correlación (convención) |
| `JobId` | `int?` | FK/correlación (convención) |
| `MemberUserId` | `int` | FK/correlación (convención) |
| `MemberUser` | `MemberUser` | Navegación |

### `SocialNetwork` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `SocialNetworkId` | `int` | PK (convención) |
| `Link` | `string` | - |
| `BasicInformationId` | `int` | FK/correlación (convención) |
| `BasicInformation` | `BasicInformation` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `SoftSkill` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `SoftSkillId` | `int` | PK (convención) |
| `SoftSkillName` | `string` | - |
| `SoftSkillNameEnglish` | `string` | - |
| `Candidate_SoftSkill` | `ICollection<Candidate_SoftSkill>` | Colección navegación |

### `Source` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `SourceId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |
| `Candidate_Sources` | `List<Candidate_Source>` | - |

### `Study` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `StudyId` | `int` | PK (convención) |
| `TitleId` | `int?` | FK/correlación (convención) |
| `Institution` | `string` | - |
| `StudyTypeId` | `int?` | FK/correlación (convención) |
| `CertificationStateId` | `int?` | FK/correlación (convención) |
| `StudyAreaId` | `int?` | FK/correlación (convención) |
| `OtherJobProfession` | `string` | - |
| `CompletionStudies` | `string` | - |
| `IsStudying` | `bool` | - |
| `IsPostponed` | `bool` | - |
| `StartDate` | `string` | - |
| `EndDate` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `StudyArea` | `StudyArea` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `CertificateIdentifier` | `string` | - |
| `StudyType` | `StudyType` | Navegación |
| `Title` | `Title` | Navegación |
| `CertificationState` | `CertificationState` | Navegación |
| `StudyCertificate` | `StudyCertificate` | Navegación |
| `StudyState` | `StudyState` | Navegación |
| `StudyStateId` | `int` | FK/correlación (convención) |
| `JobProfession` | `JobProfession` | Navegación |
| `JobProfessionId` | `int` | FK/correlación (convención) |
| `IsFromCandidate` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `StudyArea` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `StudyAreaId` | `int` | PK (convención) |
| `StudyAreaGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `StudyList` | `ICollection<Study>` | Colección navegación |

### `StudyCertificate` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `Id` | `int` | FK/correlación (convención) |
| `Name` | `string` | - |
| `CertificateIdentifier` | `string` | - |
| `StudyId` | `int` | FK/correlación (convención) |
| `UploadDate` | `string` | - |
| `Study` | `Study` | Navegación |

### `StudyState` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `StudyStateId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `StudyList` | `ICollection<Study>` | Colección navegación |

### `StudyType` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `StudyTypeId` | `int` | PK (convención) |
| `StudyTypeGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `StudyList` | `ICollection<Study>` | Colección navegación |

### `Tag` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `TagId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CompanyUser` | `CompanyUser` | Navegación |
| `Candidate_Tags` | `List<Candidate_Tag>` | - |

### `TalentGroup` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `TalentGroupId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `Description` | `string` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
| `CreationDate` | `string` | - |
| `EditedDate` | `string` | - |
| `IsEdit` | `bool` | - |
| `NameMemberUser` | `string` | - |
| `SurnameMemberUser` | `string` | - |
| `MemberUserEmail` | `string` | - |
| `InternalCodeId` | `int?` | FK/correlación (convención) |
| `InternalCode` | `InternalCode` | Navegación |
| `TalentGroupStatusId` | `int?` | FK/correlación (convención) |
| `TalentGroupPostingStatusId` | `int?` | FK/correlación (convención) |
| `TalentGroupPostingStatus` | `TalentGroupPostingStatus` | Navegación |
| `MemberUserTalentGroup` | `ICollection<MemberUserTalentGroup>` | Colección navegación |
| `FollowTalentGroup` | `ICollection<FollowTalentGroup>` | Colección navegación |
| `Candidate_TalentGroup` | `ICollection<Candidate_TalentGroup>` | Colección navegación |

### `TalentGroupPostingStatus` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `TalentGroupPostingStatusId` | `int` | PK (convención) |
| `Status` | `string` | - |
| `StatusAction` | `string` | - |
| `TalentGroup` | `ICollection<TalentGroup>` | Colección navegación |

### `TechnicalAbilityLevel` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `TechnicalAbilityLevelId` | `int` | PK (convención) |
| `Level` | `string` | - |
| `LevelEnglish` | `string` | - |
| `Candidate_TechnicalAbility` | `ICollection<Candidate_TechnicalAbility>` | Colección navegación |

### `TechnicalAbilityTechnology` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `TechnicalAbilityTechnologyId` | `int` | PK (convención) |
| `Discipline` | `string` | - |
| `DisciplineEnglish` | `string` | - |
| `Technology` | `string` | - |
| `TechnologyEnglish` | `string` | - |
| `Candidate_TechnicalAbility` | `ICollection<Candidate_TechnicalAbility>` | Colección navegación |

### `TimeAvailability` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `TimeAvailabilityId` | `int` | PK (convención) |
| `TimeAvailabilityGuid` | `string` | - |
| `TimeAvailabilityName` | `string` | - |
| `TimeAvailabilityNameEnglish` | `string` | - |
| `Candidate_TimeAvailabilityList` | `ICollection<Candidate_TimeAvailability>` | Colección navegación |
| `Company_Candidate_TimeAvailabilityList` | `ICollection<Company_Candidate_TimeAvailability>` | Colección navegación |

### `TimeZoneEvent` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `TimeZoneEventId` | `int` | PK (convención) |
| `Name` | `string` | - |
| `GMT` | `string` | - |
| `Event` | `ICollection<Event>` | Colección navegación |

### `Title` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `TitleId` | `int` | PK (convención) |
| `TitleGuid` | `string` | - |
| `Name` | `string` | - |
| `NameEnglish` | `string` | - |
| `StudyList` | `ICollection<Study>` | Colección navegación |

### `UserLink` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `UserLinkId` | `int` | PK (convención) |
| `Link` | `string` | - |
| `BasicInformationId` | `int` | FK/correlación (convención) |
| `BasicInformation` | `BasicInformation` | Navegación |
| `CompanyUserId` | `int` | FK/correlación (convención) |

### `Video` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `VideoId` | `int` | PK (convención) |
| `VideoGuid` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `IsUrl` | `bool` | - |
| `URLvideo` | `string` | - |
| `VideoName` | `string` | - |

### `Wellness` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `WellnessId` | `int` | PK (convención) |
| `WellnessGuid` | `string` | - |
| `WellnessName` | `string` | - |
| `WellnessNameEnglish` | `string` | - |
| `Candidate_WellnessList` | `ICollection<Candidate_Wellness>` | Colección navegación |
| `Company_Candidate_WellnessList` | `ICollection<Company_Candidate_Wellness>` | Colección navegación |

### `WorkArea` (EntitiesCompany)
| Campo | Tipo | Rol |
|---|---|---|
| `WorkAreaId` | `int` | PK (convención) |
| `Name` | `string` | - |

### `WorkExperience` (Entities)
| Campo | Tipo | Rol |
|---|---|---|
| `WorkExperienceId` | `int` | PK (convención) |
| `WorkExperienceGuid` | `string` | - |
| `Company` | `string` | - |
| `Country` | `string` | - |
| `State` | `string` | - |
| `City` | `string` | - |
| `CountryName` | `string` | - |
| `StateName` | `string` | - |
| `CityName` | `string` | - |
| `Position` | `string` | - |
| `BossName` | `string` | - |
| `BossCellphone` | `string` | - |
| `OfficePhone` | `string` | - |
| `StartDate` | `string` | - |
| `EndDate` | `string` | - |
| `CurrentlyWorking` | `bool` | - |
| `Authorization` | `bool` | - |
| `Functions` | `string` | - |
| `OtherIndustry` | `string` | - |
| `Candidate` | `Candidate` | Navegación |
| `CandidateId` | `int` | FK/correlación (convención) |
| `IndustryId` | `int?` | FK/correlación (convención) |
| `Industry` | `Industry` | Navegación |
| `EquivalentPosition` | `EquivalentPosition` | Navegación |
| `EquivalentPositionId` | `int?` | FK/correlación (convención) |
| `AdminView` | `bool` | - |
| `CompanyUserId` | `int` | FK/correlación (convención) |
