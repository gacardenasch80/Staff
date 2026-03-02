# Diagramas de flujo de procesos internos de la API (`CandidatesMS`)

## Objetivo
Documentar los **procesos internos más relevantes** de la API para entender cómo se ejecutan las operaciones desde que entra una request hasta que se responde al cliente, incluyendo autenticación, capa de servicios, persistencia e integraciones externas.

> Nota: los diagramas están modelados a partir de la arquitectura y convenciones observadas en la solución (Controllers → Services → Repositories → DbContexts + integraciones cloud/remotas).

## 1) Flujo interno estándar de una request autenticada
```mermaid
flowchart TD
  A[Request HTTP] --> B[Middleware Pipeline]
  B --> C{Bearer token presente?}
  C -- No --> R1[401 Unauthorized]
  C -- Sí --> D[Validación JWT Cognito]
  D --> E{Token válido?}
  E -- No --> R1
  E -- Sí --> F[Controller endpoint]
  F --> G[Validación de modelo/inputs]
  G --> H{Datos válidos?}
  H -- No --> R2[400 Bad Request]
  H -- Sí --> I[Service / caso de uso]
  I --> J[Repository]
  J --> K[(CandidateContext o CompanyContext)]
  K --> L[(PostgreSQL)]
  L --> M[Resultado de persistencia/consulta]
  M --> N[Mapeo DTO/Response]
  N --> O[200/201 + message/obj]
```

## 2) Flujo de inicialización de la API (startup/bootstrap)
```mermaid
flowchart TD
  A1[Inicio de aplicación] --> A2[Program.cs crea Host]
  A2 --> A3[Startup.ConfigureServices]
  A3 --> A4[Leer appsettings]
  A4 --> A5[Construir credenciales Key Vault]
  A5 --> A6[Resolver secretos]
  A6 --> A7[Configurar Options]
  A7 --> A8[Registrar DI Repos/Services]
  A8 --> A9[Configurar JWT Bearer]
  A9 --> A10[Configurar DbContexts]
  A10 --> A11[Configurar HttpClients nombrados]
  A11 --> A12[Startup.Configure pipeline]
  A12 --> A13[API lista para recibir tráfico]
```

## 3) Flujo de consulta de candidato por ID
```mermaid
sequenceDiagram
  participant C as Cliente
  participant API as CandidateController
  participant S as CandidateService/Repository
  participant R as CandidateRepository
  participant DB as Candidate DB
  participant MAP as AutoMapper

  C->>API: GET /api/candidate/{candidateId}
  API->>R: GetById(candidateId)
  R->>DB: Query Candidate + Include(BasicInformation)
  DB-->>R: Entidad Candidate/null
  alt candidato encontrado
    R-->>API: Candidate
    API->>MAP: Map Candidate -> CandidateDTO
    MAP-->>API: DTO
    API-->>C: 200 { message, obj }
  else no encontrado
    R-->>API: null
    API-->>C: 404 { message }
  end
```

## 4) Flujo de carga/procesamiento de CV (alto nivel)
```mermaid
flowchart TD
  B1[Request upload CV] --> B2[Controller de CV/archivo]
  B2 --> B3[Validar archivo/tamaño/formato]
  B3 --> B4{Archivo válido?}
  B4 -- No --> B5[400 Bad Request]
  B4 -- Sí --> B6[Service CV]
  B6 --> B7[Guardar metadata en DB]
  B7 --> B8[Subir binario a S3]
  B8 --> B9{Procesamiento requerido?}
  B9 -- No --> B10[201/200 éxito]
  B9 -- Sí --> B11[Invocar Textract/análisis]
  B11 --> B12[Persistir resultado de análisis]
  B12 --> B10
```

## 5) Flujo de operación remota con `Companies API`
```mermaid
sequenceDiagram
  participant CL as Cliente
  participant CT as Controller CandidatesMS
  participant SRV as Service CandidatesMS
  participant REM as CompanyRemoteRepository
  participant HC as HttpClientFactory(Companies)
  participant COM as Companies API

  CL->>CT: Operación que requiere sincronización
  CT->>SRV: Ejecutar caso de uso
  SRV->>REM: Método remoto (con token)
  REM->>HC: CreateClient("Companies")
  HC-->>REM: HttpClient configurado
  REM->>COM: HTTP request autenticado
  COM-->>REM: Response
  REM-->>SRV: Resultado boolean/DTO
  SRV-->>CT: Estado final
  CT-->>CL: Response API
```

## 6) Flujo de errores y control de respuesta
```mermaid
flowchart TD
  E1[Inicio request] --> E2[Controller]
  E2 --> E3{try/catch del endpoint}
  E3 -->|Éxito| E4[Ok/Created/NotFound según caso]
  E3 -->|Excepción| E5[StatusCode 500 + message]
  E4 --> E6[Respuesta al cliente]
  E5 --> E6
```

## 7) Mapa de procesos internos por capa
```mermaid
flowchart LR
  subgraph API
    C1[Controllers]
  end

  subgraph APP
    S1[Services]
    H1[Helpers / Validators]
  end

  subgraph DATA
    R1[Repositories]
    D1[CandidateContext]
    D2[CompanyContext]
  end

  subgraph EXT
    X1[Cognito]
    X2[Key Vault]
    X3[S3/Textract]
    X4[Companies/Recruitee]
    X5[Mail]
  end

  C1 --> H1
  C1 --> S1
  S1 --> R1
  R1 --> D1
  R1 --> D2
  C1 --> X1
  S1 --> X3
  S1 --> X4
  S1 --> X5
  S1 -. config/secrets .-> X2
```

## 8) Recomendación para siguiente iteración
Para convertir estos diagramas en una herramienta de operación del equipo, el siguiente paso ideal es:
1. Priorizar 5 procesos críticos (ej. alta candidato, actualización perfil, carga CV, envío correo, sincronización con companies).
2. Asociar cada proceso a endpoints concretos + servicios + repositorios.
3. Agregar SLAs/SLOs y puntos de observabilidad (logs, métricas, trazas) en cada diagrama.
4. Mantenerlos versionados junto con cambios de código (Definition of Done documental).