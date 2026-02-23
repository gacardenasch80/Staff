using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CandidatesMS.Persistence.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Document Type
            SeedDocumentType(1, Guid.NewGuid(), "T.I", "T.I", modelBuilder);
            SeedDocumentType(2, Guid.NewGuid(), "C.C", "C.C", modelBuilder);
            SeedDocumentType(3, Guid.NewGuid(), "C.E", "C.E", modelBuilder);
            SeedDocumentType(4, Guid.NewGuid(), "Otro", "Other", modelBuilder);
            SeedDocumentType(5, Guid.NewGuid(), "Pasaporte", "Passport", modelBuilder);
            SeedDocumentType(6, Guid.NewGuid(), "PEP", "PEP", modelBuilder);
            SeedDocumentType(7, Guid.NewGuid(), "Visa", "Visa", modelBuilder);
            SeedDocumentType(8, Guid.NewGuid(), "INE", "INE", modelBuilder);

            // Seed Marital Status
            SeedMaritalStatus(1, Guid.NewGuid(), "Solter@", "Single", modelBuilder);
            SeedMaritalStatus(2, Guid.NewGuid(), "Casad@", "Married", modelBuilder);
            SeedMaritalStatus(3, Guid.NewGuid(), "Unión libre", "Civil union", modelBuilder);
            SeedMaritalStatus(4, Guid.NewGuid(), "Separad@", "Divorced", modelBuilder);
            SeedMaritalStatus(5, Guid.NewGuid(), "Viud@", "Widow/Widower", modelBuilder);
            SeedMaritalStatus(6, Guid.NewGuid(), "Vacío", "Empty", modelBuilder);

            // Seed Study Type
            SeedStudyArea(1, Guid.NewGuid(), "Ciencias administrativas, económicas y financieras", "Management, economic and financial sciences", modelBuilder);
            SeedStudyArea(2, Guid.NewGuid(), "Ciencias de la salud", "Health sciences", modelBuilder);
            SeedStudyArea(3, Guid.NewGuid(), "Ciencias sociales y humanas", "Social and human sciences", modelBuilder);
            SeedStudyArea(4, Guid.NewGuid(), "Diseño", "Design", modelBuilder);
            SeedStudyArea(5, Guid.NewGuid(), "Comunicación", "Communication", modelBuilder);
            SeedStudyArea(6, Guid.NewGuid(), "Ingeniería y tecnología", "Engineering and technology", modelBuilder);
            SeedStudyArea(7, Guid.NewGuid(), "Educación", "Education", modelBuilder);
            SeedStudyArea(8, Guid.NewGuid(), "Derecho", "Law", modelBuilder);
            SeedStudyArea(9, Guid.NewGuid(), "Empresarial", "Business", modelBuilder);
            SeedStudyArea(10, Guid.NewGuid(), "Otra", "Other", modelBuilder);

            SeedRelationType(1, Guid.NewGuid(), "Amigo", "Friend", modelBuilder);
            SeedRelationType(2, Guid.NewGuid(), "Familiar", "Family member", modelBuilder);
            SeedRelationType(3, Guid.NewGuid(), "Compañero de trabajo", "Colleague", modelBuilder);
            SeedRelationType(4, Guid.NewGuid(), "Otra", "Other", modelBuilder);

            // Seed Study Type
            SeedStudyType(1, Guid.NewGuid(), "Educación formal", "Formal education", modelBuilder);
            SeedStudyType(2, Guid.NewGuid(), "Educación complementaria", "Complementary education", modelBuilder);
            SeedStudyType(3, Guid.NewGuid(), "Certificaciones", "Certifications", modelBuilder);

            // Seed Certification State
            SeedCertificationState(1, Guid.NewGuid(), "Por certificar", "To certify", modelBuilder);
            SeedCertificationState(2, Guid.NewGuid(), "Certificado", "Certified", modelBuilder);

            // Seed Title
            SeedTitle(1, Guid.NewGuid(), "Bachiller", "High school graduate", modelBuilder);
            SeedTitle(2, Guid.NewGuid(), "Técnico", "Technician", modelBuilder);
            SeedTitle(3, Guid.NewGuid(), "Tecnólogo", "Technologist", modelBuilder);
            SeedTitle(4, Guid.NewGuid(), "Profesional", "Professional", modelBuilder);
            SeedTitle(5, Guid.NewGuid(), "Posgrado", "Postgraduate degree", modelBuilder);

            // Seed Gender
            SeedGender(4, Guid.NewGuid(), "Vacío", "Empty", modelBuilder);
            SeedGender(1, Guid.NewGuid(), "Masculino", "Male", modelBuilder);
            SeedGender(2, Guid.NewGuid(), "Femenino", "Female", modelBuilder);
            SeedGender(3, Guid.NewGuid(), "Otro", "Other", modelBuilder);

            // Seed Industry
            SeedIndustry(1, Guid.NewGuid(), "Corredores de seguros", "Insurance Brokers", modelBuilder);
            SeedIndustry(2, Guid.NewGuid(), "Aseguradoras", "Insurance companies", modelBuilder);
            SeedIndustry(3, Guid.NewGuid(), "Almacenamiento de cadena", "Chain warehousing", modelBuilder);
            SeedIndustry(4, Guid.NewGuid(), "Retail", "Retail", modelBuilder);
            SeedIndustry(5, Guid.NewGuid(), "Temporales", "Temporary", modelBuilder);
            SeedIndustry(6, Guid.NewGuid(), "Consultorías - Asesorías", "Consulting-Advice", modelBuilder);
            SeedIndustry(7, Guid.NewGuid(), "Servicios financieros", "Financial Services", modelBuilder);
            SeedIndustry(8, Guid.NewGuid(), "Sector Petróleos - Energético", "Oil - Energy Sector", modelBuilder);
            SeedIndustry(9, Guid.NewGuid(), "Relaciones públicas (Marketing)", "Public Relations (Marketing)", modelBuilder);
            SeedIndustry(10, Guid.NewGuid(), "Sector Salud", "Health sector", modelBuilder);
            SeedIndustry(11, Guid.NewGuid(), "Vigilancia y Seguridad", "Surveillance and security", modelBuilder);
            SeedIndustry(12, Guid.NewGuid(), "Servicios", "Services", modelBuilder);
            SeedIndustry(13, Guid.NewGuid(), "Desarrollo de páginas web - Tecnología", "Web development - technology", modelBuilder);
            SeedIndustry(14, Guid.NewGuid(), "Consumo masivo", "Massive consume", modelBuilder);
            SeedIndustry(15, Guid.NewGuid(), "Otro", "Other", modelBuilder);

            // Seed Equivalent Position
            SeedEquivalentPosition(1, Guid.NewGuid(), "Pasante", "Intern", modelBuilder);
            SeedEquivalentPosition(2, Guid.NewGuid(), "Practicante", "Practicing", modelBuilder);
            SeedEquivalentPosition(3, Guid.NewGuid(), "Analista", "Analyst", modelBuilder);
            SeedEquivalentPosition(4, Guid.NewGuid(), "Coordinador", "Coordinator", modelBuilder);
            SeedEquivalentPosition(5, Guid.NewGuid(), "Líder", "Coordinator", modelBuilder);
            SeedEquivalentPosition(6, Guid.NewGuid(), "Gerente", "Manager", modelBuilder);
            SeedEquivalentPosition(7, Guid.NewGuid(), "Desarrollador", "Developer", modelBuilder);
            SeedEquivalentPosition(8, Guid.NewGuid(), "Asesor", "Advisor", modelBuilder);
            SeedEquivalentPosition(9, Guid.NewGuid(), "Tester", "Tester", modelBuilder);
            SeedEquivalentPosition(10, Guid.NewGuid(), "Consultor", "Consultant", modelBuilder);
            SeedEquivalentPosition(11, Guid.NewGuid(), "Asistente", "Consultant", modelBuilder);
            SeedEquivalentPosition(12, Guid.NewGuid(), "Auxiliar", "Assistant", modelBuilder);
            SeedEquivalentPosition(13, Guid.NewGuid(), "Director", "Director", modelBuilder);
            SeedEquivalentPosition(14, Guid.NewGuid(), "Ejecutivo", "Executive", modelBuilder);
            SeedEquivalentPosition(15, Guid.NewGuid(), "Entrenador capacitado", "Trained Trainer", modelBuilder);
            SeedEquivalentPosition(16, Guid.NewGuid(), "Ingeniero", "Engineer", modelBuilder);

            // Seed Language
            SeedLanguage(1, Guid.NewGuid(), "Español", "Spanish", modelBuilder);
            SeedLanguage(2, Guid.NewGuid(), "Inglés", "English", modelBuilder);
            SeedLanguage(3, Guid.NewGuid(), "Francés", "French", modelBuilder);
            SeedLanguage(4, Guid.NewGuid(), "Alemán", "German", modelBuilder);
            SeedLanguage(5, Guid.NewGuid(), "Mandarín", "Chinese", modelBuilder);
            SeedLanguage(6, Guid.NewGuid(), "Portugués", "Portuguese", modelBuilder);
            SeedLanguage(7, Guid.NewGuid(), "Otro", "Other", modelBuilder);

            // Seed LanguageLevel
            SeedLanguageLevel(1, Guid.NewGuid(), "A1", "A1", modelBuilder);
            SeedLanguageLevel(2, Guid.NewGuid(), "A2", "A2", modelBuilder);
            SeedLanguageLevel(3, Guid.NewGuid(), "B1", "B1", modelBuilder);
            SeedLanguageLevel(4, Guid.NewGuid(), "B2", "B2", modelBuilder);
            SeedLanguageLevel(5, Guid.NewGuid(), "C1", "C1", modelBuilder);
            SeedLanguageLevel(6, Guid.NewGuid(), "C2", "C2", modelBuilder);
            SeedLanguageLevel(7, Guid.NewGuid(), "Nativo", "Native", modelBuilder);

            //Seed SoftSkiill
            SeedSoftSkill(1, "Negociación", "Negotiation", modelBuilder);
            SeedSoftSkill(2, "Adaptación al cambio", "Adaptation to change", modelBuilder);
            SeedSoftSkill(3, "Toma de decisiones", "Decision making", modelBuilder);
            SeedSoftSkill(4, "Planeación ", "Planning", modelBuilder);
            SeedSoftSkill(5, "Empatía", "Empathy", modelBuilder);
            SeedSoftSkill(6, "Influencia", "Influence", modelBuilder);
            SeedSoftSkill(7, "Motivación", "Motivation", modelBuilder);
            SeedSoftSkill(8, "Sociabilidad", "Sociability", modelBuilder);
            SeedSoftSkill(9, "Orientación al logro", "Achievement orientation", modelBuilder);
            SeedSoftSkill(10, "Trabajo en equipo", "Teamwork", modelBuilder);
            SeedSoftSkill(11, "Orientación al detalle", "Detail orientation", modelBuilder);
            SeedSoftSkill(12, "Persistencia", "Persistence", modelBuilder);
            SeedSoftSkill(13, "Responsabilidad", "Responsibility", modelBuilder);
            SeedSoftSkill(14, "Compromiso", "Commitment", modelBuilder);
            SeedSoftSkill(15, "Escucha asertiva", "Assertive listening", modelBuilder);
            SeedSoftSkill(16, "Receptividad", "Receptivity", modelBuilder);
            SeedSoftSkill(17, "Tolerancia a la frustración", "Tolerance to frustration", modelBuilder);
            SeedSoftSkill(18, "Resolución de problemas", "Problem resolution", modelBuilder);
            SeedSoftSkill(19, "Análisis Numérico", "Numerical analysis", modelBuilder);
            SeedSoftSkill(20, "Servicio al Cliente", "Customer Service", modelBuilder);
            SeedSoftSkill(21, "Creatividad", "Creativity", modelBuilder);
            SeedSoftSkill(22, "Liderazgo", "Leadership", modelBuilder);
            SeedSoftSkill(23, "Iniciativa", "Initiative", modelBuilder);
            SeedSoftSkill(24, "Autogestión", "Self-management", modelBuilder);
            SeedSoftSkill(25, "Resiliencia", "Resilience", modelBuilder);
            SeedSoftSkill(26, "Proactividad", "Proactivity", modelBuilder);
            SeedSoftSkill(27, "Aprendizaje rápido", "Fast learning", modelBuilder);
            SeedSoftSkill(28, "Pensamiento crítico", "Critical thinking", modelBuilder);
            SeedSoftSkill(29, "Gestión de conflictos", "Conflict management", modelBuilder);
            SeedSoftSkill(30, "Otro", "Other", modelBuilder);
            SeedSoftSkill(31, "Apasionado/a", "Passionate", modelBuilder);
            SeedSoftSkill(32, "Aprendizaje continuo", "Continuous learning", modelBuilder);
            SeedSoftSkill(33, "Facilidad comunicativa", "Communicative facility", modelBuilder);
            SeedSoftSkill(34, "Atención al detalle", "Attention to detail", modelBuilder);
            SeedSoftSkill(35, "Autoconfianza", "Self-confidence", modelBuilder);
            SeedSoftSkill(36, "Autocontrol", "Self-control", modelBuilder);
            SeedSoftSkill(37, "Autodidacta", "Autodidact", modelBuilder);
            SeedSoftSkill(38, "Comportamiento ante el fracaso", "Behavior in the face of failure", modelBuilder);
            SeedSoftSkill(39, "Comunicación", "Communication", modelBuilder);
            SeedSoftSkill(40, "Comunicación asertiva", "Assertive communication", modelBuilder);
            SeedSoftSkill(41, "Disciplina", "Discipline", modelBuilder);
            SeedSoftSkill(42, "Empoderamiento", "Empowerment", modelBuilder);
            SeedSoftSkill(43, "Escucha", "Listening", modelBuilder);
            SeedSoftSkill(44, "Flexibilidad", "Flexibility", modelBuilder);
            SeedSoftSkill(45, "Habilidades sociales", "Social skills", modelBuilder);
            SeedSoftSkill(46, "Honestidad", "Honesty", modelBuilder);
            SeedSoftSkill(47, "Integridad", "Integrity", modelBuilder);
            SeedSoftSkill(48, "Organización", "Organization", modelBuilder);
            SeedSoftSkill(49, "Paciencia", "Patience", modelBuilder);
            SeedSoftSkill(50, "Perseverancia", "Perseverance", modelBuilder);
            //SeedSoftSkill(51, "Proactividad", "Proactivity", modelBuilder);
            SeedSoftSkill(52, "Pruebas de razones", "Proof of reasons", modelBuilder);
            //SeedSoftSkill(53, "Resiliencia", "Resilience", modelBuilder);
            SeedSoftSkill(54, "Respeto", "Respect", modelBuilder);
            SeedSoftSkill(55, "Temple", "Temper", modelBuilder);
            //SeedSoftSkill(56, "Tolerancia a la frustración", "Frustration tolerance", modelBuilder);
            //SeedSoftSkill(57, "Trabajo en equipo", "Teamwork", modelBuilder);

            // Seed TechnicalAbilityLevel
            //SeedTechnicalAbilityLevel(0, "No Asignado", modelBuilder);
            SeedTechnicalAbilityLevel(1, "Básico", "Basic", modelBuilder);
            SeedTechnicalAbilityLevel(2, "Intermedio", "Intermediate", modelBuilder);
            SeedTechnicalAbilityLevel(3, "Avanzado", "Advanced", modelBuilder);

            // Seed TechnicalAbilityTechnology
            SeedTechnicalAbilityTechnology(1, "HTML5", "HTML5", modelBuilder);
            SeedTechnicalAbilityTechnology(2, "CSS3", "CSS3", modelBuilder);
            SeedTechnicalAbilityTechnology(3, "Javascript", "Javascript ", modelBuilder);
            SeedTechnicalAbilityTechnology(4, "Angular", "Angular", modelBuilder);
            SeedTechnicalAbilityTechnology(5, "React - Redux", "React - Redux", modelBuilder);
            SeedTechnicalAbilityTechnology(6, "VUE", "VUE", modelBuilder);
            SeedTechnicalAbilityTechnology(7, "SQL Server", "SQL Server", modelBuilder);
            SeedTechnicalAbilityTechnology(8, "MongoDB", "MongoDB  ", modelBuilder);
            SeedTechnicalAbilityTechnology(9, "Oracle", "Oracle ", modelBuilder);
            SeedTechnicalAbilityTechnology(10, "MySQL", " MySQL", modelBuilder);
            SeedTechnicalAbilityTechnology(11, "IBM Db2 ", " IBM Db2", modelBuilder);
            SeedTechnicalAbilityTechnology(12, "PostgreSQL", " PostgreSQL", modelBuilder);
            SeedTechnicalAbilityTechnology(13, "Redis", " Redis", modelBuilder);
            SeedTechnicalAbilityTechnology(14, "Firebase", " Firebase", modelBuilder);
            SeedTechnicalAbilityTechnology(15, ".NET", " .NET", modelBuilder);
            SeedTechnicalAbilityTechnology(16, "NodeJS", " NodeJS", modelBuilder);
            SeedTechnicalAbilityTechnology(17, "AS400", " AS400", modelBuilder);
            SeedTechnicalAbilityTechnology(18, "Java ", "Java ", modelBuilder);
            SeedTechnicalAbilityTechnology(19, "PHP", " PHP", modelBuilder);
            SeedTechnicalAbilityTechnology(20, "Python", "Python", modelBuilder);
            SeedTechnicalAbilityTechnology(21, "Ruby", "Ruby", modelBuilder);
            SeedTechnicalAbilityTechnology(22, "Cobol", "Cobol", modelBuilder);
            SeedTechnicalAbilityTechnology(23, "Kotlin", "Kotlin", modelBuilder);
            SeedTechnicalAbilityTechnology(24, "Swift", "Swift", modelBuilder);
            SeedTechnicalAbilityTechnology(25, "Java2", "Java2", modelBuilder);
            SeedTechnicalAbilityTechnology(26, "Xamarin", "Xamarin", modelBuilder);
            SeedTechnicalAbilityTechnology(27, "Ionic", "Ionic", modelBuilder);
            SeedTechnicalAbilityTechnology(28, "React Native", "React Native", modelBuilder);
            SeedTechnicalAbilityTechnology(29, "Microsoft Azure", "Microsoft Azure", modelBuilder);
            SeedTechnicalAbilityTechnology(30, "Google Cloud Plattform", "Google Cloud Plattform", modelBuilder);
            SeedTechnicalAbilityTechnology(31, "IBM Bluemix", "IBM Bluemix", modelBuilder);
            SeedTechnicalAbilityTechnology(32, "Heroku", " Heroku", modelBuilder);
            SeedTechnicalAbilityTechnology(33, "Firebase2 ", "Firebase2", modelBuilder);
            SeedTechnicalAbilityTechnology(34, "Firebase3 ", "Firebase3", modelBuilder);
            SeedTechnicalAbilityTechnology(35, "Selenium", "Selenium", modelBuilder);
            SeedTechnicalAbilityTechnology(36, "Appium", "Appium", modelBuilder);
            SeedTechnicalAbilityTechnology(37, "NUnit", "NUnit", modelBuilder);
            SeedTechnicalAbilityTechnology(38, "JUnit", "JUnit ", modelBuilder);
            SeedTechnicalAbilityTechnology(39, "JMeter ", "JMeter", modelBuilder);
            SeedTechnicalAbilityTechnology(40, "Testing Funcional", "Functional Testing", modelBuilder);
            SeedTechnicalAbilityTechnology(41, "Azure DevOps", "Azure DevOps", modelBuilder);
            SeedTechnicalAbilityTechnology(42, "Gitlab", "Gitlab", modelBuilder);
            SeedTechnicalAbilityTechnology(43, "Jenkins", "Jenkins", modelBuilder);
            SeedTechnicalAbilityTechnology(44, "Git", "Git", modelBuilder);
            SeedTechnicalAbilityTechnology(45, "TFS", "TFS", modelBuilder);
            SeedTechnicalAbilityTechnology(46, "SVN", "SVN", modelBuilder);
            SeedTechnicalAbilityTechnology(47, "RPA", "RPA", modelBuilder);
            SeedTechnicalAbilityTechnology(48, "Apache", "Apache", modelBuilder);
            SeedTechnicalAbilityTechnology(49, "IIS", "IIS", modelBuilder);
            SeedTechnicalAbilityTechnology(50, "Tomcat", "Tomcat", modelBuilder);
            SeedTechnicalAbilityTechnology(51, "Blockchain", " Blockchain", modelBuilder);
            SeedTechnicalAbilityTechnology(52, "Machine Learning", " Machine Learning", modelBuilder);
            SeedTechnicalAbilityTechnology(53, "WSO2", " WSO2", modelBuilder);
            SeedTechnicalAbilityTechnology(54, "Otras", "Others", modelBuilder);


            // Seed TimeAvailability
            SeedTimeAvailability(1, Guid.NewGuid(), "Tiempo completo", "Full time", modelBuilder);
            SeedTimeAvailability(2, Guid.NewGuid(), "Medio tiempo", "Half-time", modelBuilder);
            SeedTimeAvailability(3, Guid.NewGuid(), "Por horas", "Per hour", modelBuilder);
            SeedTimeAvailability(4, Guid.NewGuid(), "Jornada Diurna", "Daytime", modelBuilder);
            SeedTimeAvailability(5, Guid.NewGuid(), "Fines de semana", "Weekends", modelBuilder);
            SeedTimeAvailability(6, Guid.NewGuid(), "Temporada fin de año", "End of year season", modelBuilder);
            SeedTimeAvailability(7, Guid.NewGuid(), "Otras temporadas", "Other seasons", modelBuilder);
            SeedTimeAvailability(8, Guid.NewGuid(), "Horario flexible", "Flexible schedule", modelBuilder);

            // Seed Wellness
            SeedWellness(1, Guid.NewGuid(), "Salario emocional", "Emotional wage", modelBuilder);
            SeedWellness(2, Guid.NewGuid(), "Actividades físicas", "Physical activities", modelBuilder);
            SeedWellness(3, Guid.NewGuid(), "Teletrabajo", "Teleworking", modelBuilder);
            SeedWellness(4, Guid.NewGuid(), "Desarrollo carrera profesional", "Professional career development", modelBuilder);
            SeedWellness(5, Guid.NewGuid(), "Estabilidad laboral", "Job stability", modelBuilder);

            // Seed File Type
            SeedFileType(1, "Pruebas técnicas", "Technical tests", 9, modelBuilder);
            SeedFileType(2, "Pruebas psicotécnicas", "Psycho-technical tests", 4, modelBuilder);
            SeedFileType(3, "Soportes de idiomas", "Language knowledge support", 10, modelBuilder);
            SeedFileType(4, "Otro", "Other", 19, modelBuilder);
            SeedFileType(5, "Hoja de vida subida por candidato", "Resume uploaded by candidate", 0, modelBuilder);
            SeedFileType(6, "Hoja de vida", "Resume", 0, modelBuilder);
            SeedFileType(7, "Archivo subido por candidato", "File uploaded by candidate", 0, modelBuilder);
            SeedFileType(8, "HV", "CV", 1, modelBuilder); // Subida por administrador o cualquier usuario empresa autorizado
            SeedFileType(9, "Autorización de tratamiento de datos personales", "Authorization to process personal data", 3, modelBuilder);
            SeedFileType(10, "Publicación de vacante", "Publication of vacancy", 2, modelBuilder);
            SeedFileType(11, "Informe de selección", "Selection report", 5, modelBuilder);
            SeedFileType(12, "Propuesta laboral", "Job offer", 6, modelBuilder);
            SeedFileType(13, "Aceptación de propuesta laboral", "Acceptance of job offer", 7, modelBuilder);
            SeedFileType(14, "Confirmación de jefe inmediato", "Confirmation from immediate manager", 8, modelBuilder);
            SeedFileType(15, "Referencias laborales", "Job references", 11, modelBuilder);
            SeedFileType(16, "Referencias personales", "Personal references", 12, modelBuilder);
            SeedFileType(17, "Validación académica", "Academic validation", 13, modelBuilder);
            SeedFileType(18, "Novedad de ingreso", "New entry", 14, modelBuilder);
            SeedFileType(19, "Solicitud de personal", "Personnel application", 15, modelBuilder);
            SeedFileType(20, "RUT Actualizado", "Updated RUT", 16, modelBuilder);
            SeedFileType(21, "Validación de antecedentes", "Background validation", 17, modelBuilder);
            SeedFileType(22, "Documento de identidad", "Identity Card", 18, modelBuilder);

            //Seed File Type Hiring

            SeedFileTypeHiring(1, "HV", "CV", 1, modelBuilder);
            SeedFileTypeHiring(2, "Documento de identidad al 150%", "Identity card at 150%.", 2, modelBuilder);
            SeedFileTypeHiring(3, "Copia del pasaporte", "Copy of passport", 3, modelBuilder);
            SeedFileTypeHiring(4, "Foto Formal 3*4", "Formal photo 3*4", 4, modelBuilder);
            SeedFileTypeHiring(5, "Certificados de estudio", "Certificates of study", 5, modelBuilder);
            SeedFileTypeHiring(6, "Certificados de educación no formal", "Certificates of non-formal education", 6, modelBuilder);
            SeedFileTypeHiring(7, "Copia de tarjeta profesional", "Copy of professional card", 7, modelBuilder);
            SeedFileTypeHiring(8, "Certificados laborales", "Labor certificates", 8, modelBuilder);
            SeedFileTypeHiring(9, "Referencias personales", "Personal references", 9, modelBuilder);
            SeedFileTypeHiring(10, "Certificado de pensiones", "Pension certificate", 10, modelBuilder);
            SeedFileTypeHiring(11, "Certificado de cesantías", "Severance pay certificate", 11, modelBuilder);
            SeedFileTypeHiring(12, "Certificado de EPS", "EPS Certificate", 12, modelBuilder);
            SeedFileTypeHiring(13, "Certificado de Cuenta Bancaria", "Bank Account Certificate", 13, modelBuilder);
            SeedFileTypeHiring(14, "Informe de selección", "Selection report", 14, modelBuilder);
            SeedFileTypeHiring(15, "Autorización de tratamiento de datos personales", "Authorization to process personal data", 15, modelBuilder);
            SeedFileTypeHiring(16, "Validación de antecedentes", "Background validation", 16, modelBuilder);
            SeedFileTypeHiring(17, "RUT", "RUT", 17, modelBuilder);
            SeedFileTypeHiring(18, "Solicitud de personal", "Staff request", 18, modelBuilder);
            SeedFileTypeHiring(19, "Otro", "Other", 26, modelBuilder);
            SeedFileTypeHiring(20, "Propuesta laboral", "Job offer", 19, modelBuilder);
            SeedFileTypeHiring(21, "Aceptación de propuesta laboral", "Acceptance of job proposal", 20, modelBuilder);
            SeedFileTypeHiring(22, "Referencias laborales", "JobReferences", 21, modelBuilder);
            SeedFileTypeHiring(23, "Cartas referencias personales", "Personal reference letters", 22, modelBuilder);
            SeedFileTypeHiring(24, "Validación académica", "Academic validation", 23, modelBuilder);
            SeedFileTypeHiring(25, "Novedad de ingreso", "New entry", 24, modelBuilder);
            SeedFileTypeHiring(26, "Soporte retención en la fuente", "Tax withholding support", 25, modelBuilder);
            //SeedFileTypeHiring(27, "Solicitud de personal", "Staff request", 26, modelBuilder);

            // Seed Social Networks
            //SeedSocialNetwork(1, "LinkedIn", modelBuilder);
            //SeedSocialNetwork(2, "Facebook", modelBuilder);
            //SeedSocialNetwork(3, "Twitter", modelBuilder);
            //SeedSocialNetwork(4, "GitHub", modelBuilder);
            //SeedSocialNetwork(5, "BitBucket", modelBuilder);
            //SeedSocialNetwork(6, "Otra", modelBuilder);

            #region LifePreference
            // Seed LifePreference
            SeedLifePreference(1, Guid.NewGuid(), "Actuar", "Act", modelBuilder);
            SeedLifePreference(2, Guid.NewGuid(), "Acuarios", "Aquariums", modelBuilder);
            SeedLifePreference(3, Guid.NewGuid(), "Aerobic", "Aerobic", modelBuilder);
            SeedLifePreference(4, Guid.NewGuid(), "Aeromodelismo", "Aeromodelling", modelBuilder);
            SeedLifePreference(5, Guid.NewGuid(), "Aerostación", "Aerostation", modelBuilder);
            SeedLifePreference(6, Guid.NewGuid(), "Aikido", "Aikido", modelBuilder);
            SeedLifePreference(7, Guid.NewGuid(), "Airsoft", "Airsoft", modelBuilder);
            SeedLifePreference(8, Guid.NewGuid(), "Ajedrez", "Chess", modelBuilder);
            SeedLifePreference(9, Guid.NewGuid(), "Animación", "Animation", modelBuilder);
            SeedLifePreference(10, Guid.NewGuid(), "Aquagym", "Aquagym", modelBuilder);
            SeedLifePreference(11, Guid.NewGuid(), "Aromaterapia", "Aromatherapy", modelBuilder);
            SeedLifePreference(12, Guid.NewGuid(), "Arte digital", "Digital art", modelBuilder);
            SeedLifePreference(13, Guid.NewGuid(), "Arte", "Art", modelBuilder);
            SeedLifePreference(14, Guid.NewGuid(), "Asociaciones", "Associations", modelBuilder);
            SeedLifePreference(15, Guid.NewGuid(), "Astrología", "Astrology", modelBuilder);
            SeedLifePreference(16, Guid.NewGuid(), "Astronomía", "Astronomy", modelBuilder);
            SeedLifePreference(17, Guid.NewGuid(), "Atletismo", "Athletics", modelBuilder);
            SeedLifePreference(18, Guid.NewGuid(), "Audiolibros", "Audiobooks", modelBuilder);
            SeedLifePreference(19, Guid.NewGuid(), "Autocaravanas", "Motorhomes", modelBuilder);
            SeedLifePreference(20, Guid.NewGuid(), "Automovilismo", "Motoring", modelBuilder);
            SeedLifePreference(21, Guid.NewGuid(), "Aviación deportiva ", "Sport Aviation", modelBuilder);
            SeedLifePreference(22, Guid.NewGuid(), "Avicultura", "Aviculture", modelBuilder);
            SeedLifePreference(23, Guid.NewGuid(), "Avistamiento de aves", "Bird watching", modelBuilder);
            SeedLifePreference(24, Guid.NewGuid(), "Backgammon", "Backgammon", modelBuilder);
            SeedLifePreference(25, Guid.NewGuid(), "Badminton", "Badminton", modelBuilder);
            SeedLifePreference(26, Guid.NewGuid(), "Bailar", "Dancing", modelBuilder);
            SeedLifePreference(27, Guid.NewGuid(), "Baloncesto", "Basketball", modelBuilder);
            SeedLifePreference(28, Guid.NewGuid(), "Balonmano", "Handball", modelBuilder);
            SeedLifePreference(29, Guid.NewGuid(), "Banda o grupo musicales", "Band or musical group", modelBuilder);
            SeedLifePreference(30, Guid.NewGuid(), "Barcos de motor", "Motor boats", modelBuilder);
            SeedLifePreference(31, Guid.NewGuid(), "Barranquismo", "Canyoning", modelBuilder);
            SeedLifePreference(32, Guid.NewGuid(), "Batik y estampación de tejidos", "Batik and fabric printing", modelBuilder);
            SeedLifePreference(33, Guid.NewGuid(), "Beisbol", "Baseball", modelBuilder);
            SeedLifePreference(34, Guid.NewGuid(), "Belleza y estética", "Beauty and esthetics", modelBuilder);
            SeedLifePreference(35, Guid.NewGuid(), "Biatlon", "Biathlon", modelBuilder);
            SeedLifePreference(36, Guid.NewGuid(), "Bibliofilia", "Bibliophilia", modelBuilder);
            SeedLifePreference(37, Guid.NewGuid(), "Bicicleta (ciclismo)", "Bicycle (cycling)", modelBuilder);
            SeedLifePreference(38, Guid.NewGuid(), "Bicicleta de montaña", "Mountain biking", modelBuilder);
            SeedLifePreference(39, Guid.NewGuid(), "Bikejoring", "Bikejoring", modelBuilder);
            SeedLifePreference(40, Guid.NewGuid(), "Billar", "Billiards", modelBuilder);
            SeedLifePreference(41, Guid.NewGuid(), "Bingo", "Bingo", modelBuilder);
            SeedLifePreference(42, Guid.NewGuid(), "Blog (y videoblog)", "Blog (and videoblog)", modelBuilder);
            SeedLifePreference(43, Guid.NewGuid(), "BMX ", "BMX ", modelBuilder);
            SeedLifePreference(44, Guid.NewGuid(), "Bodyboard", "Bodyboard", modelBuilder);
            SeedLifePreference(45, Guid.NewGuid(), "Bolos (bowling, boliche)", "Bowling ", modelBuilder);
            SeedLifePreference(46, Guid.NewGuid(), "Bonsai (arboles enanos)", "Bonsai (dwarf trees)", modelBuilder);
            SeedLifePreference(47, Guid.NewGuid(), "Bordado sobre papel", "Embroidery on paper", modelBuilder);
            SeedLifePreference(48, Guid.NewGuid(), "Boxeo", "Boxing", modelBuilder);
            SeedLifePreference(49, Guid.NewGuid(), "Bricolaje o diy", "DIY", modelBuilder);
            SeedLifePreference(50, Guid.NewGuid(), "Buceo ", "Diving ", modelBuilder);
            SeedLifePreference(51, Guid.NewGuid(), "Caballo (equitación)", "Horse (horseback riding)", modelBuilder);
            SeedLifePreference(52, Guid.NewGuid(), "Caligrafía y lettering", "Calligraphy and lettering", modelBuilder);
            SeedLifePreference(53, Guid.NewGuid(), "Campismo", "Camping", modelBuilder);
            SeedLifePreference(54, Guid.NewGuid(), "Canaricultura", "Dog breeding", modelBuilder);
            SeedLifePreference(55, Guid.NewGuid(), "Canicross", "Canicross", modelBuilder);
            SeedLifePreference(56, Guid.NewGuid(), "Cantar", "Singing", modelBuilder);
            SeedLifePreference(57, Guid.NewGuid(), "Capoeira", "Capoeira", modelBuilder);
            SeedLifePreference(58, Guid.NewGuid(), "Carpintería", "Carpentry", modelBuilder);
            SeedLifePreference(59, Guid.NewGuid(), "Carreras por montaña", "Mountain racing", modelBuilder);
            SeedLifePreference(60, Guid.NewGuid(), "Carrovela y blokart", "Carrovela and blokart ", modelBuilder);
            SeedLifePreference(61, Guid.NewGuid(), "Casas de muñecas", "Doll houses", modelBuilder);
            SeedLifePreference(62, Guid.NewGuid(), "Cata de cerveza", "Beer tasting", modelBuilder);
            SeedLifePreference(63, Guid.NewGuid(), "Cata de vinos", "Wine tasting", modelBuilder);
            SeedLifePreference(64, Guid.NewGuid(), "Caza (deportiva)", "Hunting (sport)", modelBuilder);
            SeedLifePreference(65, Guid.NewGuid(), "Cerámica", "Ceramics", modelBuilder);
            SeedLifePreference(66, Guid.NewGuid(), "Cerveza (fabricación)", "Beer (brewing)", modelBuilder);
            SeedLifePreference(67, Guid.NewGuid(), "Cestería", "Basketry", modelBuilder);
            SeedLifePreference(68, Guid.NewGuid(), "Cetrería", "Falconry ", modelBuilder);
            SeedLifePreference(69, Guid.NewGuid(), "Chalkpaint (pintura de tiza)", "Chalkpaint (chalk painting)", modelBuilder);
            SeedLifePreference(70, Guid.NewGuid(), "Chi kung o qui gong", "Chi kung or qui gong", modelBuilder);
            SeedLifePreference(71, Guid.NewGuid(), "Cianotipia", "Cyanotype", modelBuilder);
            SeedLifePreference(72, Guid.NewGuid(), "Cicloturismo", "Cycling", modelBuilder);
            SeedLifePreference(73, Guid.NewGuid(), "Cine", "Cinema ", modelBuilder);
            SeedLifePreference(74, Guid.NewGuid(), "Cocina", "Cooking", modelBuilder);
            SeedLifePreference(75, Guid.NewGuid(), "Coleccionismo (antigüedades)", "Collecting (antiques)", modelBuilder);
            SeedLifePreference(76, Guid.NewGuid(), "Colorear libros", "Coloring books", modelBuilder);
            SeedLifePreference(77, Guid.NewGuid(), "Cometas (volar cometas)", "Kites (kite flying)", modelBuilder);
            SeedLifePreference(78, Guid.NewGuid(), "Comics (creación de)", "Comics (creating)", modelBuilder);
            SeedLifePreference(79, Guid.NewGuid(), "Comics (lectura de)", "Comics (reading)", modelBuilder);
            SeedLifePreference(80, Guid.NewGuid(), "Comidista (foodie)", "Foodie", modelBuilder);
            SeedLifePreference(81, Guid.NewGuid(), "Composición musical", "Musical composition", modelBuilder);
            SeedLifePreference(82, Guid.NewGuid(), "Compostaje", "Composting", modelBuilder);
            SeedLifePreference(83, Guid.NewGuid(), "Comprar", "Shopping ", modelBuilder);
            SeedLifePreference(84, Guid.NewGuid(), "Conducción de automóviles ", "Automobile driving ", modelBuilder);
            SeedLifePreference(85, Guid.NewGuid(), "Conducción de motocicletas", "Motorcycle driving", modelBuilder);
            SeedLifePreference(86, Guid.NewGuid(), "Conferencias (asistir a)", "Lectures (attend)", modelBuilder);
            SeedLifePreference(87, Guid.NewGuid(), "Coro", "Choir", modelBuilder);
            SeedLifePreference(88, Guid.NewGuid(), "Correr (running)", "Running", modelBuilder);
            SeedLifePreference(89, Guid.NewGuid(), "Cosmética", "Cosmetics", modelBuilder);
            SeedLifePreference(90, Guid.NewGuid(), "Costura, corte y confección", "Sewing, cutting and tailoring", modelBuilder);
            SeedLifePreference(91, Guid.NewGuid(), "Cristal teñido", "Stained glass", modelBuilder);
            SeedLifePreference(92, Guid.NewGuid(), "Croquet", "Croquet", modelBuilder);
            SeedLifePreference(93, Guid.NewGuid(), "Cruceros (viajes de)", "Cruising (travel)", modelBuilder);
            SeedLifePreference(94, Guid.NewGuid(), "Cubo de rubik (rompecabezas)", "Rubik's cube (puzzles)", modelBuilder);
            SeedLifePreference(95, Guid.NewGuid(), "Cuero (creaciones con)", "Leather (creations with)", modelBuilder);
            SeedLifePreference(96, Guid.NewGuid(), "Culturismo (body building)", "Bodybuilding (body building)", modelBuilder);
            SeedLifePreference(97, Guid.NewGuid(), "Curling", "Curling", modelBuilder);
            SeedLifePreference(98, Guid.NewGuid(), "Customización de ropa", "Clothing customization", modelBuilder);
            SeedLifePreference(99, Guid.NewGuid(), "Customización y restauración de bicicletas", "Customization and restoration of bicycles", modelBuilder);
            SeedLifePreference(100, Guid.NewGuid(), "Damas (juego de)", "Checkers (checkers game)", modelBuilder);
            SeedLifePreference(101, Guid.NewGuid(), "Danza aérea", "Aerial dance", modelBuilder);
            SeedLifePreference(102, Guid.NewGuid(), "Dardos (lanzar dardos)", "Darts (throwing darts)", modelBuilder);
            SeedLifePreference(103, Guid.NewGuid(), "Decoración de interiores", "Interior decoration", modelBuilder);
            SeedLifePreference(104, Guid.NewGuid(), "Decoupage (decoración de superficies)", "Decoupage (surface decoration)", modelBuilder);
            SeedLifePreference(105, Guid.NewGuid(), "Deporte (asistir a espectáculos deportivos)", "Sport (attending sporting events)", modelBuilder);
            SeedLifePreference(106, Guid.NewGuid(), "Deporte (ver deporte)", "Sports (watching sports)", modelBuilder);
            SeedLifePreference(107, Guid.NewGuid(), "Deportes de fantasía (liga de fantasía)", "Fantasy sports (fantasy league)", modelBuilder);
            SeedLifePreference(108, Guid.NewGuid(), "Diario (escribir un)", "Journaling (writing a diary)", modelBuilder);
            SeedLifePreference(109, Guid.NewGuid(), "Dibujo artístico", "Artistic drawing", modelBuilder);
            SeedLifePreference(110, Guid.NewGuid(), "Dioramas (y belenes)", "Dioramas (and nativity scenes)", modelBuilder);
            SeedLifePreference(111, Guid.NewGuid(), "Dirigir, entrenar, gestionar.", "Directing, coaching, managing", modelBuilder);
            SeedLifePreference(112, Guid.NewGuid(), "Disc golf", "Disc golf", modelBuilder);
            SeedLifePreference(113, Guid.NewGuid(), "Diseño de ropa (moda)", "Clothing design (fashion)", modelBuilder);
            SeedLifePreference(114, Guid.NewGuid(), "Diseño y creación de páginas web", "Design and creation of web pages", modelBuilder);
            SeedLifePreference(115, Guid.NewGuid(), "Dj (disk jockey)", "Dj (disc jockey)", modelBuilder);
            SeedLifePreference(116, Guid.NewGuid(), "Documentales (afición a los)", "Documentaries (hobby)", modelBuilder);
            SeedLifePreference(117, Guid.NewGuid(), "Domino", "Domino", modelBuilder);
            SeedLifePreference(118, Guid.NewGuid(), "Electrónica", "Electronics", modelBuilder);
            SeedLifePreference(119, Guid.NewGuid(), "Encuadernación de libros", "Book binding", modelBuilder);
            SeedLifePreference(120, Guid.NewGuid(), "Enmarcar cuadros", "Picture framing", modelBuilder);
            SeedLifePreference(121, Guid.NewGuid(), "Escalada", "Climbing", modelBuilder);
            SeedLifePreference(122, Guid.NewGuid(), "Escribir literatura ", "Writing literature ", modelBuilder);
            SeedLifePreference(123, Guid.NewGuid(), "Escultura", "Sculpting", modelBuilder);
            SeedLifePreference(124, Guid.NewGuid(), "Esgrima", "Fencing", modelBuilder);
            SeedLifePreference(125, Guid.NewGuid(), "Esmaltes sobre metal (al fuego)", "Enamels on metal (on fire)", modelBuilder);
            SeedLifePreference(126, Guid.NewGuid(), "Espeleología", "Speleology", modelBuilder);
            SeedLifePreference(127, Guid.NewGuid(), "Esports", "Esports", modelBuilder);
            SeedLifePreference(128, Guid.NewGuid(), "Esquí alpino", "Alpine skiing", modelBuilder);
            SeedLifePreference(129, Guid.NewGuid(), "Esquí de fondo o nórdico", "Cross-country or Nordic skiing", modelBuilder);
            SeedLifePreference(130, Guid.NewGuid(), "Esquí náutico o acuático", "Water skiing or water skiing", modelBuilder);
            SeedLifePreference(131, Guid.NewGuid(), "Estudiar", "Study ", modelBuilder);
            SeedLifePreference(132, Guid.NewGuid(), "Exploración urbana (urbex)", "Urban exploration (urbex)", modelBuilder);
            SeedLifePreference(133, Guid.NewGuid(), "Flamenco", "Flamenco", modelBuilder);
            SeedLifePreference(134, Guid.NewGuid(), "Floorball (o unihockey)", "Floorball (or unihockey)", modelBuilder);
            SeedLifePreference(135, Guid.NewGuid(), "Flores kanzashi", "Kanzashi flowers", modelBuilder);
            SeedLifePreference(136, Guid.NewGuid(), "Flores secas (trabajar con)", "Dried flowers (work with)", modelBuilder);
            SeedLifePreference(137, Guid.NewGuid(), "Flyboard", "Flyboard", modelBuilder);
            SeedLifePreference(138, Guid.NewGuid(), "Fotografía", "Photography", modelBuilder);
            SeedLifePreference(139, Guid.NewGuid(), "Frisbee (disco volador)", "Frisbee (flying disc)", modelBuilder);
            SeedLifePreference(140, Guid.NewGuid(), "Frontón", "Fronton", modelBuilder);
            SeedLifePreference(141, Guid.NewGuid(), "Futbol", "Soccer", modelBuilder);
            SeedLifePreference(142, Guid.NewGuid(), "Futbol americano", "Football", modelBuilder);
            SeedLifePreference(143, Guid.NewGuid(), "Futbol sala", "Indoor soccer", modelBuilder);
            SeedLifePreference(144, Guid.NewGuid(), "Futbolín", "Foosball", modelBuilder);
            SeedLifePreference(145, Guid.NewGuid(), "Genealogía e historia familiar", "Genealogy and family history", modelBuilder);
            SeedLifePreference(146, Guid.NewGuid(), "Geocaching y búsqueda de tesoros", "Geocaching and treasure hunting", modelBuilder);
            SeedLifePreference(147, Guid.NewGuid(), "Gimnasia de mantenimiento y fitness", "Gymnastics and fitness", modelBuilder);
            SeedLifePreference(148, Guid.NewGuid(), "Globos (trabajo con globos)", "Balloons (balloon work)", modelBuilder);
            SeedLifePreference(149, Guid.NewGuid(), "Go (juego)", "Go (game)", modelBuilder);
            SeedLifePreference(150, Guid.NewGuid(), "Golf", "Golf", modelBuilder);
            SeedLifePreference(151, Guid.NewGuid(), "Grabados artísticos", "Artistic engravings", modelBuilder);
            SeedLifePreference(152, Guid.NewGuid(), "Graffiti y arte urbano", "Graffiti and street art", modelBuilder);
            SeedLifePreference(153, Guid.NewGuid(), "Groundhopping («ir de estadio en estadio»)", "Groundhopping («going from stadium to stadium»)", modelBuilder);
            SeedLifePreference(154, Guid.NewGuid(), "Hacer vino", "Making wine", modelBuilder);
            SeedLifePreference(155, Guid.NewGuid(), "Halterofilia (levantamiento de pesas)", "Weightlifting", modelBuilder);
            SeedLifePreference(156, Guid.NewGuid(), "Hapkido", "Hapkido", modelBuilder);
            SeedLifePreference(157, Guid.NewGuid(), "Hidroponía (cultivo en liquido)", "Hydroponics (liquid farming)", modelBuilder);
            SeedLifePreference(158, Guid.NewGuid(), "Hockey de mesa (air hockey)", "Table field hockey (air field hockey)", modelBuilder);
            SeedLifePreference(159, Guid.NewGuid(), "Hockey sobre hielo", "Ice hockey", modelBuilder);
            SeedLifePreference(160, Guid.NewGuid(), "Hockey sobre hierba", "Field Hockey", modelBuilder);
            SeedLifePreference(161, Guid.NewGuid(), "Hockey sobre patines", "Roller Hockey", modelBuilder);
            SeedLifePreference(162, Guid.NewGuid(), "Hockey subacuático", "Underwater field hockey", modelBuilder);
            SeedLifePreference(163, Guid.NewGuid(), "Horticultura (agricultura)", "Horticulture (agriculture)", modelBuilder);
            SeedLifePreference(164, Guid.NewGuid(), "Huerto casero", "Home gardening", modelBuilder);
            SeedLifePreference(165, Guid.NewGuid(), "Hydrospeed", "Hydrospeed", modelBuilder);
            SeedLifePreference(166, Guid.NewGuid(), "Ikebana (arte floral)", "Ikebana (floral art)", modelBuilder);
            SeedLifePreference(167, Guid.NewGuid(), "Internet ", "Internet ", modelBuilder);
            SeedLifePreference(168, Guid.NewGuid(), "Invertir en bolsa", "Investing in the stock market", modelBuilder);
            SeedLifePreference(169, Guid.NewGuid(), "Jabón (hacer)", "Soap (making)", modelBuilder);
            SeedLifePreference(170, Guid.NewGuid(), "Jardinería", "Gardening", modelBuilder);
            SeedLifePreference(171, Guid.NewGuid(), "Jiu jitsu", "Jiu jitsu", modelBuilder);
            SeedLifePreference(172, Guid.NewGuid(), "Joyas y bisutería (creación de)", "Jewelry and costume jewelry  (making)", modelBuilder);
            SeedLifePreference(173, Guid.NewGuid(), "Judo", "Judo", modelBuilder);
            SeedLifePreference(174, Guid.NewGuid(), "Juegos con dispositivos electrónicos ", "Games with electronic devices ", modelBuilder);
            SeedLifePreference(175, Guid.NewGuid(), "Juegos de cartas o naipes", "Card games", modelBuilder);
            SeedLifePreference(176, Guid.NewGuid(), "Juegos de mesa ", "Board games ", modelBuilder);
            SeedLifePreference(177, Guid.NewGuid(), "Juegos de mesa temáticos", "Themed board games", modelBuilder);
            SeedLifePreference(178, Guid.NewGuid(), "Juegos de rol", "Role-playing games", modelBuilder);
            SeedLifePreference(179, Guid.NewGuid(), "Jugger", "Jugger", modelBuilder);
            SeedLifePreference(180, Guid.NewGuid(), "Karaoke", "Karaoke", modelBuilder);
            SeedLifePreference(181, Guid.NewGuid(), "Karate", "Karate", modelBuilder);
            SeedLifePreference(182, Guid.NewGuid(), "Kayak polo", "Kayak polo", modelBuilder);
            SeedLifePreference(183, Guid.NewGuid(), "Kendo", "Kendo", modelBuilder);
            SeedLifePreference(184, Guid.NewGuid(), "Kenpo", "Kenpo", modelBuilder);
            SeedLifePreference(185, Guid.NewGuid(), "Kick boxing", "Kick boxing", modelBuilder);
            SeedLifePreference(186, Guid.NewGuid(), "Kintsugi", "Kintsugi", modelBuilder);
            SeedLifePreference(187, Guid.NewGuid(), "Kitesurf", "Kitesurfing", modelBuilder);
            SeedLifePreference(188, Guid.NewGuid(), "Kokedamas (cultivo de plantan)", "Kokedamas  (plant cultivation)", modelBuilder);
            SeedLifePreference(189, Guid.NewGuid(), "Korfball", "Korfball", modelBuilder);
            SeedLifePreference(190, Guid.NewGuid(), "Kung fu", "Kung fu", modelBuilder);
            SeedLifePreference(191, Guid.NewGuid(), "Labores (punto, bordado, encaje, etc)", "Needlework (knitting, embroidery, lace, etc.)", modelBuilder);
            SeedLifePreference(192, Guid.NewGuid(), "Lectura", "Reading", modelBuilder);
            SeedLifePreference(193, Guid.NewGuid(), "Lego", "Lego", modelBuilder);
            SeedLifePreference(194, Guid.NewGuid(), "Lotería", "Lottery", modelBuilder);
            SeedLifePreference(195, Guid.NewGuid(), "Lucha (olímpica, grecorromana)", "Wrestling (Olympic, Greco-Roman)", modelBuilder);
            SeedLifePreference(196, Guid.NewGuid(), "Madera (tallas en madera)", "Wood (wood carving)", modelBuilder);
            SeedLifePreference(197, Guid.NewGuid(), "Magia (ilusionismo, prestidigitación)", "Magic (illusionism, conjuring)", modelBuilder);
            SeedLifePreference(198, Guid.NewGuid(), "Mahjong (juego de fichas chino)", "Mahjong (Chinese tile game)", modelBuilder);
            SeedLifePreference(199, Guid.NewGuid(), "Malabares", "Juggling", modelBuilder);
            SeedLifePreference(200, Guid.NewGuid(), "Manualidades", "Handicrafts", modelBuilder);
            SeedLifePreference(201, Guid.NewGuid(), "Marcha o paseo nórdico (nordic walking)", "Nordic walking (Nordic walking)", modelBuilder);
            SeedLifePreference(202, Guid.NewGuid(), "Marionetas (teatro de)", "Puppetry (puppet theater)", modelBuilder);
            SeedLifePreference(203, Guid.NewGuid(), "Meditación", "Meditation", modelBuilder);
            SeedLifePreference(204, Guid.NewGuid(), "Mercadillos/flea markets", "Flea markets", modelBuilder);
            SeedLifePreference(205, Guid.NewGuid(), "Mermeladas (preparar)", "Jams (preparing)", modelBuilder);
            SeedLifePreference(206, Guid.NewGuid(), "Metales (búsqueda de)", "Metals (search for)", modelBuilder);
            SeedLifePreference(207, Guid.NewGuid(), "Mindfulness o atención plena", "Mindfulness", modelBuilder);
            SeedLifePreference(208, Guid.NewGuid(), "Minerales (búsqueda de)", "Minerals (search for)", modelBuilder);
            SeedLifePreference(209, Guid.NewGuid(), "Moda (afición a la moda)", "Fashion (fashion hobby)", modelBuilder);
            SeedLifePreference(210, Guid.NewGuid(), "Modelismo (aviones, coches, barcos, drones)", "Modeling (airplanes, cars, boats, drones)", modelBuilder);
            SeedLifePreference(211, Guid.NewGuid(), "Modelismo con cerillas", "Match modeling", modelBuilder);
            SeedLifePreference(212, Guid.NewGuid(), "Montañismo/alpinismo", "Mountaineering/alpinism", modelBuilder);
            SeedLifePreference(213, Guid.NewGuid(), "Moto acuática", "Jet skiing", modelBuilder);
            SeedLifePreference(214, Guid.NewGuid(), "Muñecas (hacer)", "Dolls (doll making)", modelBuilder);
            SeedLifePreference(215, Guid.NewGuid(), "Mushing", "Mushing", modelBuilder);
            SeedLifePreference(216, Guid.NewGuid(), "Música (afición a la) ", "Music (hobby)", modelBuilder);
            SeedLifePreference(217, Guid.NewGuid(), "Nadar (natación)", "Swimming", modelBuilder);
            SeedLifePreference(218, Guid.NewGuid(), "Observación de trenes y aviones", "Train and airplane observation", modelBuilder);
            SeedLifePreference(219, Guid.NewGuid(), "Orientación", "Orientation", modelBuilder);
            SeedLifePreference(220, Guid.NewGuid(), "Origami (o papiroflexia)", "Origami", modelBuilder);
            SeedLifePreference(221, Guid.NewGuid(), "Padbol", "Paddleball", modelBuilder);
            SeedLifePreference(222, Guid.NewGuid(), "Paddle surf (surf a remo)", "Paddle surfing", modelBuilder);
            SeedLifePreference(223, Guid.NewGuid(), "Padel", "Paddle boarding", modelBuilder);
            SeedLifePreference(224, Guid.NewGuid(), "Paintball", "Paintball", modelBuilder);
            SeedLifePreference(225, Guid.NewGuid(), "Palomas (cría de palomas)", "Pigeons (pigeon breeding)", modelBuilder);
            SeedLifePreference(226, Guid.NewGuid(), "Papel mache", "Paper mache", modelBuilder);
            SeedLifePreference(227, Guid.NewGuid(), "Paracaidismo", "Parachuting", modelBuilder);
            SeedLifePreference(228, Guid.NewGuid(), "Paramotor", "Paramotoring", modelBuilder);
            SeedLifePreference(229, Guid.NewGuid(), "Parapente", "Paragliding", modelBuilder);
            SeedLifePreference(230, Guid.NewGuid(), "Parkour (freerunning)", "Parkour (freerunning)", modelBuilder);
            SeedLifePreference(231, Guid.NewGuid(), "Pasatiempos (crucigramas, sudokus)", "Hobbies (crossword puzzles, sudoku)", modelBuilder);
            SeedLifePreference(232, Guid.NewGuid(), "Pasear", "Walking", modelBuilder);
            SeedLifePreference(233, Guid.NewGuid(), "Patchwork y colchas", "Patchwork and quilting", modelBuilder);
            SeedLifePreference(234, Guid.NewGuid(), "Patinaje sobre hielo", "Ice skating", modelBuilder);
            SeedLifePreference(235, Guid.NewGuid(), "Patinaje sobre ruedas (roller)", "Roller skating (roller skating)", modelBuilder);
            SeedLifePreference(236, Guid.NewGuid(), "Perros (concursos/exhibiciones)", "Dogs (contests/exhibitions)", modelBuilder);
            SeedLifePreference(237, Guid.NewGuid(), "Pesca", "Fishing", modelBuilder);
            SeedLifePreference(238, Guid.NewGuid(), "Pesca submarina", "Underwater fishing", modelBuilder);
            SeedLifePreference(239, Guid.NewGuid(), "Petanca", "Petanque", modelBuilder);
            SeedLifePreference(240, Guid.NewGuid(), "Pilates", "Pilates", modelBuilder);
            SeedLifePreference(241, Guid.NewGuid(), "Ping pong o tenis de mesa", "Ping pong or table tennis", modelBuilder);
            SeedLifePreference(242, Guid.NewGuid(), "Pintura artística", "Artistic painting", modelBuilder);
            SeedLifePreference(243, Guid.NewGuid(), "Pintura de figuras ", "Figure painting", modelBuilder);
            SeedLifePreference(244, Guid.NewGuid(), "Pintura sobre seda", "Silk painting", modelBuilder);
            SeedLifePreference(245, Guid.NewGuid(), "Piragüismo (canoismo/canotaje)", "Canoeing (boating)", modelBuilder);
            SeedLifePreference(246, Guid.NewGuid(), "Plantas de interior", "Indoor plants", modelBuilder);
            SeedLifePreference(247, Guid.NewGuid(), "Plantas silvestres", "Wild plants", modelBuilder);
            SeedLifePreference(248, Guid.NewGuid(), "Podcasts (afición/creación)", "Podcasts (hobby/creation)", modelBuilder);
            SeedLifePreference(249, Guid.NewGuid(), "Polo", "Polo", modelBuilder);
            SeedLifePreference(250, Guid.NewGuid(), "Porcelana fría", "Cold porcelain", modelBuilder);
            SeedLifePreference(251, Guid.NewGuid(), "Powerlifting", "Powerlifting", modelBuilder);
            SeedLifePreference(252, Guid.NewGuid(), "Producción musical", "Music production", modelBuilder);
            SeedLifePreference(253, Guid.NewGuid(), "Programación informática", "Computer programming", modelBuilder);
            SeedLifePreference(254, Guid.NewGuid(), "Puzzles", "Puzzles", modelBuilder);
            SeedLifePreference(255, Guid.NewGuid(), "Quad y buggy", "Quad and buggy", modelBuilder);
            SeedLifePreference(256, Guid.NewGuid(), "Radio (afición a la)", "Radio (hobby)", modelBuilder);
            SeedLifePreference(257, Guid.NewGuid(), "Radioafición", "Amateur radio", modelBuilder);
            SeedLifePreference(258, Guid.NewGuid(), "Rafting", "Rafting", modelBuilder);
            SeedLifePreference(259, Guid.NewGuid(), "Raquetas de nieve", "Snowshoeing", modelBuilder);
            SeedLifePreference(260, Guid.NewGuid(), "Reciclaje creativo", "Creative recycling", modelBuilder);
            SeedLifePreference(261, Guid.NewGuid(), "Redes sociales ", "Social networking", modelBuilder);
            SeedLifePreference(262, Guid.NewGuid(), "Reiki (técnica espiritual sanadora)", "Reiki (spiritual healing technique)", modelBuilder);
            SeedLifePreference(263, Guid.NewGuid(), "Remo deportivo", "Sports rowing", modelBuilder);
            SeedLifePreference(264, Guid.NewGuid(), "Repostería/pastelería y cupcakes", "Baking/pastry and cupcakes", modelBuilder);
            SeedLifePreference(265, Guid.NewGuid(), "Repujado de metal", "Metal working", modelBuilder);
            SeedLifePreference(266, Guid.NewGuid(), "Restauración de coches clásicos", "Classic car restoration", modelBuilder);
            SeedLifePreference(267, Guid.NewGuid(), "Restauración de muebles", "Furniture restoration", modelBuilder);
            SeedLifePreference(268, Guid.NewGuid(), "Leer", "Read", modelBuilder);
            SeedLifePreference(269, Guid.NewGuid(), "Robótica", "Robotics", modelBuilder);
            SeedLifePreference(270, Guid.NewGuid(), "Roller derby", "Roller derby", modelBuilder);
            SeedLifePreference(271, Guid.NewGuid(), "Rugby", "Rugby", modelBuilder);
            SeedLifePreference(272, Guid.NewGuid(), "Scalextric", "Scalextric", modelBuilder);
            SeedLifePreference(273, Guid.NewGuid(), "Scrapbook (album de recortes)", "Scrapbooking", modelBuilder);
            SeedLifePreference(274, Guid.NewGuid(), "Senderismo", "Hiking", modelBuilder);
            SeedLifePreference(275, Guid.NewGuid(), "Series de tv ", "TV series ", modelBuilder);
            SeedLifePreference(276, Guid.NewGuid(), "Serigrafia", "Serigraphy", modelBuilder);
            SeedLifePreference(277, Guid.NewGuid(), "Setas (búsqueda de)", "Mushrooms (mushroom hunting)", modelBuilder);
            SeedLifePreference(278, Guid.NewGuid(), "Skateboarding", "Skateboarding", modelBuilder);
            SeedLifePreference(279, Guid.NewGuid(), "Slime (jugar con slime)", "Slime (playing with slime)", modelBuilder);
            SeedLifePreference(280, Guid.NewGuid(), "Snowbike", "Snowbike", modelBuilder);
            SeedLifePreference(281, Guid.NewGuid(), "Snowboard", "Snowboard", modelBuilder);
            SeedLifePreference(282, Guid.NewGuid(), "Softball", "Softball", modelBuilder);
            SeedLifePreference(283, Guid.NewGuid(), "Speedriding", "Speedriding", modelBuilder);
            SeedLifePreference(284, Guid.NewGuid(), "Spinning", "Spinning", modelBuilder);
            SeedLifePreference(285, Guid.NewGuid(), "Squash", "Squash", modelBuilder);
            SeedLifePreference(286, Guid.NewGuid(), "Surf", "Surf", modelBuilder);
            SeedLifePreference(287, Guid.NewGuid(), "Taekwondo", "Taekwondo", modelBuilder);
            SeedLifePreference(288, Guid.NewGuid(), "Taichi", "Taichi", modelBuilder);
            SeedLifePreference(289, Guid.NewGuid(), "Tampones o sellos de caucho ", "Rubber stamps or stamps", modelBuilder);
            SeedLifePreference(290, Guid.NewGuid(), "Tarot", "Tarot", modelBuilder);
            SeedLifePreference(291, Guid.NewGuid(), "Tatuajes", "Tattoos", modelBuilder);
            SeedLifePreference(292, Guid.NewGuid(), "Taxidermia", "Taxidermy", modelBuilder);
            SeedLifePreference(293, Guid.NewGuid(), "Tejer ", "Weaving ", modelBuilder);
            SeedLifePreference(294, Guid.NewGuid(), "Tejo ", "Shuffleboard ", modelBuilder);
            SeedLifePreference(295, Guid.NewGuid(), "Tenis", "Tennis", modelBuilder);
            SeedLifePreference(296, Guid.NewGuid(), "Tintado/teñido de tejidos", "Textile dyeing/dyeing", modelBuilder);
            SeedLifePreference(297, Guid.NewGuid(), "Tiro con arco", "Archery", modelBuilder);
            SeedLifePreference(298, Guid.NewGuid(), "Tiro con tirachinas", "Slingshot shooting", modelBuilder);
            SeedLifePreference(299, Guid.NewGuid(), "Tiro deportivo con arma de fuego", "Sport shooting with a firearm", modelBuilder);
            SeedLifePreference(300, Guid.NewGuid(), "Tocar un instrumento musical", "Playing a musical instrument", modelBuilder);
            SeedLifePreference(301, Guid.NewGuid(), "Toros (afición a los)", "Bullfighting (hobby)", modelBuilder);
            SeedLifePreference(302, Guid.NewGuid(), "Tostar café", "Coffee roasting", modelBuilder);
            SeedLifePreference(303, Guid.NewGuid(), "Transferencia de imágenes", "Image transfer", modelBuilder);
            SeedLifePreference(304, Guid.NewGuid(), "Trenes a escala", "Model trains", modelBuilder);
            SeedLifePreference(305, Guid.NewGuid(), "Triatlon", "Triathlon", modelBuilder);
            SeedLifePreference(306, Guid.NewGuid(), "Uñas (decoración)", "Nails (decoration)", modelBuilder);
            SeedLifePreference(307, Guid.NewGuid(), "Vehículos de control remoto (rc)", "Remote control vehicles (rc)", modelBuilder);
            SeedLifePreference(308, Guid.NewGuid(), "Vela deportiva y recreativa", "Sport and recreational sailing", modelBuilder);
            SeedLifePreference(309, Guid.NewGuid(), "Velas (creación de velas)", "Candles (candle making)", modelBuilder);
            SeedLifePreference(310, Guid.NewGuid(), "Viajar", "Travel", modelBuilder);
            SeedLifePreference(311, Guid.NewGuid(), "Viajar lentamente ", "Slow travel ", modelBuilder);
            SeedLifePreference(312, Guid.NewGuid(), "Viajes de aventura", "Adventure travel", modelBuilder);
            SeedLifePreference(313, Guid.NewGuid(), "Viajes temáticos", "Thematic travel", modelBuilder);
            SeedLifePreference(314, Guid.NewGuid(), "Video (realización de videos)", "Video (video making)", modelBuilder);
            SeedLifePreference(315, Guid.NewGuid(), "Videojuegos", "Video games", modelBuilder);
            SeedLifePreference(316, Guid.NewGuid(), "Visitar monumentos ", "Visiting monuments ", modelBuilder);
            SeedLifePreference(317, Guid.NewGuid(), "Visitar museos y exposiciones", "Visiting museums and exhibitions", modelBuilder);
            SeedLifePreference(318, Guid.NewGuid(), "Visitas urbanas", "City tours", modelBuilder);
            SeedLifePreference(319, Guid.NewGuid(), "Voleibol", "Volleyball", modelBuilder);
            SeedLifePreference(320, Guid.NewGuid(), "Voluntariado ambiental", "Environmental volunteering", modelBuilder);
            SeedLifePreference(321, Guid.NewGuid(), "Voluntariado animal", "Animal volunteering", modelBuilder);
            SeedLifePreference(322, Guid.NewGuid(), "Voluntariado cultural", "Cultural volunteering", modelBuilder);
            SeedLifePreference(323, Guid.NewGuid(), "Voluntariado en deporte", "Sports volunteering", modelBuilder);
            SeedLifePreference(324, Guid.NewGuid(), "Voluntariado social", "Social volunteering", modelBuilder);
            SeedLifePreference(325, Guid.NewGuid(), "Vuelo a vela ", "Sailing ", modelBuilder);
            SeedLifePreference(326, Guid.NewGuid(), "Wakeboard", "Wakeboarding", modelBuilder);
            SeedLifePreference(327, Guid.NewGuid(), "Waterpolo", "Water polo", modelBuilder);
            SeedLifePreference(328, Guid.NewGuid(), "Windsurf", "Windsurfing", modelBuilder);
            SeedLifePreference(329, Guid.NewGuid(), "Yoga", "Yoga", modelBuilder);
            SeedLifePreference(330, Guid.NewGuid(), "Youtuber", "Youtuber", modelBuilder);
            SeedLifePreference(331, Guid.NewGuid(), "Zumba", "Zumba", modelBuilder);
            SeedLifePreference(332, Guid.NewGuid(), "Otra", "Other", modelBuilder);

            #endregion

            // Seed Study State
            SeedStudyState(1, "Actualmente estudiando", "Currently studying", modelBuilder);
            SeedStudyState(2, "Aplazado", "Deferred", modelBuilder);
            SeedStudyState(3, "Sin finalizar", "Unfinished", modelBuilder);
            SeedStudyState(4, "Finalizado", "Finished", modelBuilder);

            // Seed Document Check State
            SeedDocumentCheckState(1, "Automático", modelBuilder);
            SeedDocumentCheckState(2, "Manual", modelBuilder);
            SeedDocumentCheckState(3, "Mixto", modelBuilder);

            // Seed Document Check Group
            SeedDocumentCheckGroup(1, "Hoja de vida", "Resume", modelBuilder);
            SeedDocumentCheckGroup(2, "Soportes", "Support", modelBuilder);
            SeedDocumentCheckGroup(3, "Documentación adicional", "Additional documentation", modelBuilder);

            SeedDocumentCheckGroup(4, "Vinculación", "Linkage", modelBuilder);
            SeedDocumentCheckGroup(5, "Evaluación", "Evaluation", modelBuilder);
            SeedDocumentCheckGroup(6, "Soporte experiencia y referencias", "Experience and references support", modelBuilder);
            SeedDocumentCheckGroup(7, "Soporte educación y formación", "Education and training support", modelBuilder);
            SeedDocumentCheckGroup(8, "Hoja de vida", "Resume", modelBuilder);
            SeedDocumentCheckGroup(9, "Otros documentos", "Other documents", modelBuilder);

            // Seed Currency
            SeedCurrency(1, "EE.UU. Dólar", "USD (EE.UU. Dólar)", "U.S Dollar", "USD (U.S Dollar)", modelBuilder);
            SeedCurrency(2, "Peso colombiano", "COP (Peso colombiano)", "Colombian Peso", "COP (Colombian Peso)", modelBuilder);
            SeedCurrency(3, "Euro", "EUR (Euro)", "Euro", "EUR (Euro)", modelBuilder);
            SeedCurrency(4, "Dólar australiano", "AUD (Dólar australiano)", "Australian Dollar", "AUD (Australian Dollar)", modelBuilder);
            SeedCurrency(5, "Real brasileño", "BRL (Real brasileño)", "Brazilian Real", "BRL (Brazilian Real)", modelBuilder);
            SeedCurrency(6, "Peso chileno", "CLP (Peso chileno)", "Chilean Peso", "CLP (Chilean Peso)", modelBuilder);
            SeedCurrency(7, "Peso mexicano", "MXN (Peso mexicano)", "Mexican Peso", "MXN (Mexican Peso)", modelBuilder);
            SeedCurrency(8, "Emiratos Árabes Unidos Dirham", "AED  (Emiratos Árabes Unidos Dirham)", "United Arab Emirates Dirham", "AED (United Arab Emirates Dirham)", modelBuilder);
            SeedCurrency(9, "Afganistán Afgani", "AFN  (Afganistán Afgani)", "Afghanistan Afghani", "AFN (Afghanistan Afghani)", modelBuilder);
            SeedCurrency(10, "Albania Lek", "ALL  (Albania Lek)", "Albania Lek", "ALL (Albania Lek)", modelBuilder);
            SeedCurrency(11, "Armenia Dram", "AMD  (Armenia Dram)", "Armenia Dram", "AMD (Armenia Dram)", modelBuilder);
            SeedCurrency(12, "Antillas Holandesas Florín", "ANG  (Antillas Holandesas Florín)", "Netherlands Antilles Florin", "ANG (Netherlands Antilles Florin)", modelBuilder);
            SeedCurrency(13, "Angola Kwanza", "AOA  (Angola Kwanza)", "Angola Kwanza", "AOA (Angola Kwanza)", modelBuilder);
            SeedCurrency(14, "Peso argentino", "ARS  (Peso argentino)", "Argentine Peso", "ARS (Argentine Peso)", modelBuilder);
            SeedCurrency(15, "Austria Chelín", "ATS (EURO)(Austria Chelín)", "Austria Shilling", "ATS (EURO)(Austria Shilling)", modelBuilder);
            SeedCurrency(16, "Aruba Florín", "AWG  (Aruba Florín)", "Aruban Florin", "AWG (Aruban Florin)", modelBuilder);
            SeedCurrency(17, "Azerbaiyán Nuevo Manat", "AZN  (Azerbaiyán Nuevo Manat)", "Azerbaijan New Manat", "AZN (Azerbaijan New Manat)", modelBuilder);
            SeedCurrency(18, "Bosnia Marco", "BAM  (Bosnia Marco)", "Bosnia Marka", "BAM (Bosnia Marka)", modelBuilder);
            SeedCurrency(19, "Barbados Dólar", "BBD  (Barbados Dólar)", "Barbados Dollar", "BBD (Barbados Dollar)", modelBuilder);
            SeedCurrency(20, "Bangladesh Taka", "BDT  (Bangladesh Taka)", "Bangladesh Taka", "BDT (Bangladesh Taka)", modelBuilder);
            SeedCurrency(21, "Bélgica Franco", "BEF (EURO)(Bélgica Franco)", "Belgium Franc", "BEF (EURO)(Belgium Franc)", modelBuilder);
            SeedCurrency(22, "Bulgaria Lev", "BGN  (Bulgaria Lev)", "Bulgaria Lev", "BGN (Bulgaria Lev)", modelBuilder);
            SeedCurrency(23, "Bahréin Dinar", "BHD  (Bahréin Dinar)", "Bahrain Dinar", "BHD (Bahrain Dinar)", modelBuilder);
            SeedCurrency(24, "Burundi Franco", "BIF  (Burundi Franco)", "Burundi Franc", "BIF (Burundi Franc)", modelBuilder);
            SeedCurrency(25, "Bermuda Dólar", "BMD  (Bermuda Dólar)", "Bermuda Dollar", "BMD (Bermuda Dollar)", modelBuilder);
            SeedCurrency(26, "Brunéi Dólar", "BND  (Brunéi Dólar)", "Brunei Dollar", "BND (Brunei Dollar)", modelBuilder);
            SeedCurrency(27, "Bolivia Boliviano", "BOB  (Bolivia Boliviano)", "Bolivian Boliviano", "BOB (Bolivian Boliviano)", modelBuilder);
            SeedCurrency(28, "Bahamas Dólar", "BSD  (Bahamas Dólar)", "Bahamas Dollar", "BSD (Bahamas Dollar)", modelBuilder);
            SeedCurrency(29, "Bután Ngultrum", "BTN  (Bután Ngultrum)", "Bhutanese Ngultrum", "BTN (Bhutanese Ngultrum)", modelBuilder);
            SeedCurrency(30, "Botsuana Pula", "BWP  (Botsuana Pula)", "Botswana Pula", "BWP (Botswana Pula)", modelBuilder);
            SeedCurrency(31, "Bielorrusia Rublo", "BYR  (Bielorrusia Rublo)", "Belarusian Rouble", "BYR (Belarusian Rouble)", modelBuilder);
            SeedCurrency(32, "Belice Dólar", "BZD  (Belice Dólar)", "Belize Dollar", "BZD (Belize Dollar)", modelBuilder);
            SeedCurrency(33, "Canadá Dólar", "CAD  (Canadá Dólar)", "Canada Dollar", "CAD (Canada Dollar)", modelBuilder);
            SeedCurrency(34, "Congo Franco", "CDF  (Congo Franco)", "Congo Franc", "CDF (Congo Franc)", modelBuilder);
            SeedCurrency(35, "Franco suizo", "CHF  (Franco suizo)", "Swiss Franc", "CHF (Swiss Franc)", modelBuilder);
            SeedCurrency(36, "China Yuan/Renminbi", "CNY  (China Yuan/Renminbi)", "China Yuan/Renminbi", "CNY (China Yuan/Renminbi)", modelBuilder);
            SeedCurrency(37, "Costa Rica Colón", "CRC  (Costa Rica Colón)", "Costa Rican Colon", "CRC (Costa Rican Colon)", modelBuilder);
            SeedCurrency(38, "Cuba Peso convertible", "CUC  (Cuba Peso convertible)", "Cuban Convertible Peso", "CUC (Cuban Convertible Peso)", modelBuilder);
            SeedCurrency(39, "Peso cubano", "CUP  (Peso cubano)", "Cuban Peso", "CUP (Cuban Peso)", modelBuilder);
            SeedCurrency(40, "Cabo Verde Escudo", "CVE  (Cabo Verde Escudo)", "Cape Verde Escudo", "CVE (Cape Verde Escudo)", modelBuilder);
            SeedCurrency(41, "(EURO) Chipre Libra", "CYP ((EURO) Chipre Libra)", "Cyprus Pound", "CYP (EURO)(Cyprus Pound)", modelBuilder);
            SeedCurrency(42, "República Checa Corona", "CZK (República Checa Corona)", "Czech Republic Koruna", "CZK (Czech Republic Koruna)", modelBuilder);
            SeedCurrency(43, "Yibuti Franco", "DJF  (Yibuti Franco)", "Djibouti Franc", "DJF (Djibouti Franc)", modelBuilder);
            SeedCurrency(44, "Dinamarca Corona", "DKK  (Dinamarca Corona)", "Denmark Krone", "DKK (Denmark Krone)", modelBuilder);
            SeedCurrency(45, "Alemania Marco", "DMK (EURO)(Alemania Marco)", "Germany Mark", "DMK (EURO)(Germany Mark)", modelBuilder);
            SeedCurrency(46, "República Dominicana Peso", "DOP (República Dominicana Peso)", "Dominican Republic Peso", "DOP (Dominican Republic Peso)", modelBuilder);
            SeedCurrency(47, "Algeria Dinar", "DZD  (Algeria Dinar)", "Algerian Dinar", "DZD (Algerian Dinar)", modelBuilder);
            SeedCurrency(48, "Estonia Corona", "EEK (EURO)(Estonia Corona)", "Estonia Kroon", "EEK (EURO)(Estonia Kroon)", modelBuilder);
            SeedCurrency(49, "Egipto Libra", "EGP  (Egipto Libra)", "Egypt Pound", "EGP (Egypt Pound)", modelBuilder);
            SeedCurrency(50, "España Peseta", "ESP (EURO)(España Peseta)", "Spain Peseta", "ESP (EURO)(Spain Peseta)", modelBuilder);
            SeedCurrency(51, "Etiopía Birr", "ETB  (Etiopía Birr)", "Ethiopia Birr", "ETB (Ethiopia Birr)", modelBuilder);
            SeedCurrency(52, "Finlandia Marco", "FIM (EURO)(Finlandia Marco)", "Finland Mark", "FIM (EURO)(Finland Mark)", modelBuilder);
            SeedCurrency(53, "Fiji Dólar", "FJD  (Fiji Dólar)", "Fiji Dollar", "FJD (Fiji Dollar)", modelBuilder);
            SeedCurrency(54, "Islas Falkland Libra", "FKP  (Islas Falkland Libra)", "Falkland Islands Pound", "FKP (Falkland Islands Pound)", modelBuilder);
            SeedCurrency(55, "Gran Bretaña Libra esterlina", "GBP  (Gran Bretaña Libra esterlina)", "Great Britain Pound Sterling", "GBP (Great Britain Pound Sterling)", modelBuilder);
            SeedCurrency(56, "Georgia Lari", "GEL  (Georgia Lari)", "Georgia Lari", "GEL (Georgia Lari)", modelBuilder);
            SeedCurrency(57, "Ghana Nuevo Cedi", "GHS  (Ghana Nuevo Cedi)", "Ghana New Cedi", "GHS (Ghana New Cedi)", modelBuilder);
            SeedCurrency(58, "Gibraltar Libra", "GIP  (Gibraltar Libra)", "Gibraltar Pound", "GIP (Gibraltar Pound)", modelBuilder);
            SeedCurrency(59, "Gambia Dalasi", "GMD  (Gambia Dalasi)", "Gambia Dalasi", "GMD (Gambia Dalasi)", modelBuilder);
            SeedCurrency(60, "Guinea Franco", "GNF  (Guinea Franco)", "Guinea Franc", "GNF (Guinea Franc)", modelBuilder);
            SeedCurrency(61, "Grecia Dracma", "GRD (EURO)(Grecia Dracma)", "Greece Drachma ", "GRD (Greece Drachma )", modelBuilder);
            SeedCurrency(62, "Guatemala Quetzal", "GTQ  (Guatemala Quetzal)", "Guatemala Quetzal", "GTQ (Guatemala Quetzal)", modelBuilder);
            SeedCurrency(63, "Guyana Dólar", "GYD  (Guyana Dólar)", "Guyana Dollar", "GYD (Guyana Dollar)", modelBuilder);
            SeedCurrency(64, "Hong Kong Dólar", "HKD (Hong Kong Dólar)", "Hong Kong Dollar", "HKD (Hong Kong Dollar)", modelBuilder);
            SeedCurrency(65, "Honduras Lempira", "HNL  (Honduras Lempira)", "Honduras Lempira", "HNL (Honduras Lempira)", modelBuilder);
            SeedCurrency(66, "Croacia Kuna", "HRK  (Croacia Kuna)", "Croatia Kuna", "HRK (Croatia Kuna)", modelBuilder);
            SeedCurrency(67, "Haití Gourde", "HTG  (Haití Gourde)", "Haiti Gourde", "HTG (Haiti Gourde)", modelBuilder);
            SeedCurrency(68, "Hungría Forinto", "HUF  (Hungría Forinto)", "Hungary Forint", "HUF (Hungary Forint)", modelBuilder);
            SeedCurrency(69, "Indonesia Rupia", "IDR  (Indonesia Rupia)", "Indonesia Rupiah", "IDR (Indonesia Rupiah)", modelBuilder);
            SeedCurrency(70, "Irlanda Libra", "IED (EURO)(Irlanda Libra)", "Ireland Pound", "IED (EURO)(Ireland Pound)", modelBuilder);
            SeedCurrency(71, "Israel Nuevo Séquel", "ILS  (Israel Nuevo Séquel)", "Israel New Baku", "ILS (Israel New Baku)", modelBuilder);
            SeedCurrency(72, "India Rupia", "INR  (India Rupia)", "India Rupee", "INR (India Rupee)", modelBuilder);
            SeedCurrency(73, "Irak Dinar", "IQD  (Irak Dinar)", "Iraqi Dinar", "IQD (Iraqi Dinar)", modelBuilder);
            SeedCurrency(74, "Irán Rial", "IRR  (Irán Rial)", "Iranian Rial", "IRR (Iranian Rial)", modelBuilder);
            SeedCurrency(75, "Islandia Corona", "ISK  (Islandia Corona)", "Iceland Krona", "ISK (Iceland Krona)", modelBuilder);
            SeedCurrency(76, "Italia Lira", "ITL (EURO)(Italia Lira)", "Italy Lira", "ITL (EURO)(Italy Lira)", modelBuilder);
            SeedCurrency(77, "Jamaica Dólar", "JMD  (Jamaica Dólar)", "Jamaica Dollar", "JMD (Jamaica Dollar)", modelBuilder);
            SeedCurrency(78, "Jordania Dinar", "JOD  (Jordania Dinar)", "Jordan Dinar", "JOD (Jordan Dinar)", modelBuilder);
            SeedCurrency(79, "Japón Yen", "JPY  (Japón Yen)", "Japan Yen", "JPY (Japan Yen)", modelBuilder);
            SeedCurrency(80, "Kenia Chelín", "KES  (Kenia Chelín)", "Kenya Shilling", "KES (Kenya Shilling)", modelBuilder);
            SeedCurrency(81, "Kirguistán Som", "KGS  (Kirguistán Som)", "Kyrgyzstan Som", "KGS (Kyrgyzstan Som)", modelBuilder);
            SeedCurrency(82, "Camboya Riel", "KHR  (Camboya Riel)", "Cambodian Riel", "KHR (Cambodian Riel)", modelBuilder);
            SeedCurrency(83, "Comoras Franco", "KMF  (Comoras Franco)", "Comoros Franc", "KMF (Comoros Franc)", modelBuilder);
            SeedCurrency(84, "Corea del Norte Won", "KPW  (Corea del Norte Won)", "North Korea Won", "KPW (North Korea Won)", modelBuilder);
            SeedCurrency(85, "Corea del Sur Won", "KRW  (Corea del Sur Won)", "South Korea Won", "KRW (South Korea Won)", modelBuilder);
            SeedCurrency(86, "Kuwait Dinar", "KWD  (Kuwait Dinar)", "Kuwait Dinar", "KWD (Kuwait Dinar)", modelBuilder);
            SeedCurrency(87, "Islas Caimán Dólar", "KYD  (Islas Caimán Dólar)", "Cayman Islands Dollar", "KYD (Cayman Islands Dollar)", modelBuilder);
            SeedCurrency(88, "Kazajistán Tenge", "KZT  (Kazajistán Tenge)", "Kazakhstan Tenge", "KZT (Kazakhstan Tenge)", modelBuilder);
            SeedCurrency(89, "Laos Kip", "LAK  (Laos Kip)", "Lao Kip", "LAK (Lao Kip)", modelBuilder);
            SeedCurrency(90, "Líbano Libra", "LBP  (Líbano Libra)", "Lebanon Pound", "LBP (Lebanon Pound)", modelBuilder);
            SeedCurrency(91, "Sri Lanka Rupia", "LKR  (Sri Lanka Rupia)", "Sri Lanka Rupee", "LKR (Sri Lanka Rupee)", modelBuilder);
            SeedCurrency(92, "Liberia Dólar", "LRD  (Liberia Dólar)", "Liberia Dollar", "LRD (Liberia Dollar)", modelBuilder);
            SeedCurrency(93, "Lesotho Loti", "LSL  (Lesotho Loti)", "Lesotho Loti", "LSL (Lesotho Loti)", modelBuilder);
            SeedCurrency(94, "Lituania Litas", "LTL (EURO)(Lituania Litas)", "Lithuania Litas", "LTL (EURO)(Lithuania Litas)", modelBuilder);
            SeedCurrency(95, "Luxemburgo Franco", "LUF (EURO)(Luxemburgo Franco)", "Luxembourg Franc", "LUF (EURO)(Luxembourg Franc)", modelBuilder);
            SeedCurrency(96, "Letonia Lats", "LVL (EURO)(Letonia Lats)", "Latvia Lats", "LVL (EURO)(Latvia Lats)", modelBuilder);
            SeedCurrency(97, "Libia Dinar", "LYD  (Libia Dinar)", "Libyan Dinar", "LYD (Libyan Dinar)", modelBuilder);
            SeedCurrency(98, "Marruecos Dirham", "MAD  (Marruecos Dirham)", "Moroccan Dirham", "MAD (Moroccan Dirham)", modelBuilder);
            SeedCurrency(99, "Moldavia Leu", "MDL  (Moldavia Leu)", "Moldova Leu", "MDL (Moldova Leu)", modelBuilder);
            SeedCurrency(100, "Madagascar Ariary", "MGA  (Madagascar Ariary)", "Madagascar Ariary", "MGA (Madagascar Ariary)", modelBuilder);
            SeedCurrency(101, "Macedonia Denar", "MKD  (Macedonia Denar)", "Macedonia Denar", "MKD (Macedonia Denar)", modelBuilder);
            SeedCurrency(102, "Myanmar Kyat", "MMK  (Myanmar Kyat)", "Myanmar Kyat", "MMK (Myanmar Kyat)", modelBuilder);
            SeedCurrency(103, "Mongolia Tugrik", "MNT  (Mongolia Tugrik)", "Mongolia Tugrik", "MNT (Mongolia Tugrik)", modelBuilder);
            SeedCurrency(104, "Macao Pataca", "MOP  (Macao Pataca)", "Macao Pataca", "MOP (Macao Pataca)", modelBuilder);
            SeedCurrency(105, "Mauritania Ouguiya", "MRO  (Mauritania Ouguiya)", "Mauritania Ouguiya", "MRO (Mauritania Ouguiya)", modelBuilder);
            SeedCurrency(106, "Malta Lira", "MTL (EURO)(Malta Lira)", "Malta Lira", "MTL (EURO)(Malta Lira)", modelBuilder);
            SeedCurrency(107, "Mauricio Rupia", "MUR  (Mauricio Rupia)", "Mauritius Rupee", "MUR (Mauritius Rupee)", modelBuilder);
            SeedCurrency(108, "Maldivas Rufiyaa", "MVR  (Maldivas Rufiyaa)", "Maldives Rufiyaa", "MVR (Maldives Rufiyaa)", modelBuilder);
            SeedCurrency(109, "Malawi Kwacha", "MWK  (Malawi Kwacha)", "Malawi Kwacha", "MWK (Malawi Kwacha)", modelBuilder);
            SeedCurrency(110, "Malasia Ringgit", "MYR  (Malasia Ringgit)", "Malaysia Ringgit", "MYR (Malaysia Ringgit)", modelBuilder);
            SeedCurrency(111, "Mozambique Nuevo Metical", "MZN  (Mozambique Nuevo Metical)", "Mozambique New Metical", "MZN (Mozambique New Metical)", modelBuilder);
            SeedCurrency(112, "Namibia Dólar", "NAD  (Namibia Dólar)", "Namibia Dollar", "NAD (Namibia Dollar)", modelBuilder);
            SeedCurrency(113, "Nigeria Naira", "NGN  (Nigeria Naira)", "Nigeria Naira", "NGN (Nigeria Naira)", modelBuilder);
            SeedCurrency(114, "Nicaragua Córdoba", "NIO (Nicaragua Córdoba)", "Nicaragua Cordoba", "NIO (Nicaragua Cordoba)", modelBuilder);
            SeedCurrency(115, "Países bajos Florín", "NLG (EURO)(Países bajos Florín)", "Netherlands Florin", "NLG (EURO)(Netherlands Florin)", modelBuilder);
            SeedCurrency(116, "Noruega Corona", "NOK  (Noruega Corona)", "Norwegian Krone", "NOK (Norwegian Krone)", modelBuilder);
            SeedCurrency(117, "Nepal Rupia", "NPR  (Nepal Rupia)", "Nepal Rupee", "NPR (Nepal Rupee)", modelBuilder);
            SeedCurrency(118, "Nueva Zelanda Dólar", "NZD  (Nueva Zelanda Dólar)", "New Zealand Dollar", "NZD (New Zealand Dollar)", modelBuilder);
            SeedCurrency(119, "Omán Rial", "OMR  (Omán Rial)", "Oman Rial", "OMR (Oman Rial)", modelBuilder);
            SeedCurrency(120, "Panamá Balboa", "PAB  (Panamá Balboa)", "Panama Balboa", "PAB (Panama Balboa)", modelBuilder);
            SeedCurrency(121, "Perú Nuevo Sol", "PEN  (Perú Nuevo Sol)", "Peru Nuevo Sol", "PEN (Peru Nuevo Sol)", modelBuilder);
            SeedCurrency(122, "Papúa Nueva Guinea Kina", "PGK  (Papúa Nueva Guinea Kina)", "Papua New Guinea Kina", "PGK (Papua New Guinea Kina)", modelBuilder);
            SeedCurrency(123, "Peso filipino", "PHP  (Peso filipino)", "Philippines Peso", "PHP (Philippines Peso)", modelBuilder);
            SeedCurrency(124, "Pakistán Rupia", "PKR  (Pakistán Rupia)", "Pakistan Rupee", "PKR (Pakistan Rupee)", modelBuilder);
            SeedCurrency(125, "Polonia Zloty", "PLN  (Polonia Zloty)", "Poland Zloty", "PLN (Poland Zloty)", modelBuilder);
            SeedCurrency(126, "Portugal Escudo", "PTE (EURO)(Portugal Escudo)", "Portugal Escudo", "PTE (EURO)(Portugal Escudo)", modelBuilder);
            SeedCurrency(127, "Paraguay Guaraní", "PYG  (Paraguay Guaraní)", "Paraguay Guarani", "PYG (Paraguay Guarani)", modelBuilder);
            SeedCurrency(128, "Catar Rial", "QAR  (Catar Rial)", "Qatar Rial", "QAR (Qatar Rial)", modelBuilder);
            SeedCurrency(129, "Rumania Nuevo Lei", "RON  (Rumania Nuevo Lei)", "Romania New Lei", "RON (Romania New Lei)", modelBuilder);
            SeedCurrency(130, "Serbia Dinar", "RSD  (Serbia Dinar)", "Serbia Dinar", "RSD (Serbia Dinar)", modelBuilder);
            SeedCurrency(131, "Rusia Rublo", "RUB  (Rusia Rublo)", "Russian Rouble", "RUB (Russian Rouble)", modelBuilder);
            SeedCurrency(132, "Ruanda Franco", "RWF  (Ruanda Franco)", "Rwanda Franc", "RWF (Rwanda Franc)", modelBuilder);
            SeedCurrency(133, "Arabia Saudita Rial", "SAR  (Arabia Saudita Rial)", "Saudi Arabian Rial", "SAR (Saudi Arabian Rial)", modelBuilder);
            SeedCurrency(134, "Islas Salomón Dólar", "SBD  (Islas Salomón Dólar)", "Solomon Islands Dollar", "SBD (Solomon Islands Dollar)", modelBuilder);
            SeedCurrency(135, "Seychelles Rupia", "SCR  (Seychelles Rupia)", "Seychelles Rupee", "SCR (Seychelles Rupee)", modelBuilder);
            SeedCurrency(136, "Sudán Libra", "SDG  (Sudán Libra)", "Sudan Pound", "SDG (Sudan Pound)", modelBuilder);
            SeedCurrency(137, "Suecia Corona", "SEK  (Suecia Corona)", "Swedish Krona", "SEK (Swedish Krona)", modelBuilder);
            SeedCurrency(138, "Singapur Dólar", "SGD (Singapur Dólar)", "Singapore Dollar", "SGD (Singapore Dollar)", modelBuilder);
            SeedCurrency(139, "Santa Helena Libra", "SHP  (Santa Helena Libra)", "Saint Helena Pound", "SHP (Saint Helena Pound)", modelBuilder);
            SeedCurrency(140, "Eslovenia Tolar", "SIT (EURO)(Eslovenia Tolar)", "Slovenia Tolar", "SIT (EURO)(Slovenia Tolar)", modelBuilder);
            SeedCurrency(141, "Eslovaquia Koruna", "SKK (EURO)(Eslovaquia Koruna)", "Slovakia Koruna", "SKK (EURO)(Slovakia Koruna)", modelBuilder);
            SeedCurrency(142, "Sierra Leona Leone", "SLL  (Sierra Leona Leone)", "Sierra Leone Leone", "SLL (Sierra Leone Leone)", modelBuilder);
            SeedCurrency(143, "Somalía Chelín", "SOS  (Somalía Chelín)", "Somali Shilling", "SOS (Somali Shilling)", modelBuilder);
            SeedCurrency(144, "Suriname Dólar", "SRD  (Suriname Dólar)", "Suriname Dollar", "SRD (Suriname Dollar)", modelBuilder);
            SeedCurrency(145, "Santo Tomé y Príncipe Dobra", "STD  (Santo Tomé y Príncipe Dobra)", "Sao Tome & Principe Dobra", "STD (Sao Tome & Principe Dobra)", modelBuilder);
            SeedCurrency(146, "El Salvador Colón", "SVC   (El Salvador Colón)", "El Salvador Colon", "SVC (El Salvador Colon)", modelBuilder);
            SeedCurrency(147, "Siria Libra", "SYP (Siria Libra)", "Syria Pound", "SYP (Syria Pound)", modelBuilder);
            SeedCurrency(148, "Suazilandia Lilangeni", "SZL  (Suazilandia Lilangeni)", "Swaziland Lilangeni", "SZL (Swaziland Lilangeni)", modelBuilder);
            SeedCurrency(149, "Tailandia Baht", "THB  (Tailandia Baht)", "Thailand Baht", "THB (Thailand Baht)", modelBuilder);
            SeedCurrency(150, "Turkmenistán Manat", "TMM  (Turkmenistán Manat)", "Turkmenistan Manat", "TMM (Turkmenistan Manat)", modelBuilder);
            SeedCurrency(151, "Túnez Dinar", "TND  (Túnez Dinar)", "Tunisia Dinar", "TND (Tunisia Dinar)", modelBuilder);
            SeedCurrency(152, "Tonga Pa'anga", "TOP  (Tonga Pa'anga)", "Tonga Pa'anga", "TOP (Tonga Pa'anga)", modelBuilder);
            SeedCurrency(153, "Turquía Nueva Lira", "TRY  (Turquía Nueva Lira)", "Turkey New Lira", "TRY (Turkey New Lira)", modelBuilder);
            SeedCurrency(154, "Trinidad y Tobago Dólar", "TTD  (Trinidad y Tobago Dólar)", "Trinidad & Tobago Dollar", "TTD (Trinidad & Tobago Dollar)", modelBuilder);
            SeedCurrency(155, "Taiwán Dólar", "TWD  (Taiwán Dólar)", "Taiwan Dollar", "TWD (Taiwan Dollar)", modelBuilder);
            SeedCurrency(156, "Tanzania Chelín", "TZS  (Tanzania Chelín)", "Tanzania Shilling", "TZS (Tanzania Shilling)", modelBuilder);
            SeedCurrency(157, "Ucrania Hryvnia", "UAH  (Ucrania Hryvnia)", "Ukraine Hryvnia", "UAH (Ukraine Hryvnia)", modelBuilder);
            SeedCurrency(158, "Uganda Chelín", "UGX  (Uganda Chelín)", "Uganda Shilling", "UGX (Uganda Shilling)", modelBuilder);
            SeedCurrency(159, "Peso uruguayo", "UYU  (Peso uruguayo)", "Uruguayan Peso", "UYU (Uruguayan Peso)", modelBuilder);
            SeedCurrency(160, "Venezuela Bolívar", "VEB  (Venezuela Bolívar)", "Venezuela Bolivar", "VEB (Venezuela Bolivar)", modelBuilder);
            SeedCurrency(161, "Vietnam Dong", "VND  (Vietnam Dong)", "Vietnam Dong", "VND (Vietnam Dong)", modelBuilder);
            SeedCurrency(162, "Vanuatu Vatu", "VUV  (Vanuatu Vatu)", "Vanuatu Vatu", "VUV (Vanuatu Vatu)", modelBuilder);
            SeedCurrency(163, "Samoa Tala", "WST  (Samoa Tala)", "Samoa Tala", "WST (Samoa Tala)", modelBuilder);
            SeedCurrency(164, "CFA Franco BEAC", "XAF  (CFA Franco BEAC)", "CFA Franc BEAC", "XAF (CFA Franc BEAC)", modelBuilder);
            SeedCurrency(165, "Caribe oriental Dólar", "XCD  (Caribe oriental Dólar)", "Eastern Caribbean Dollar", "XCD (Eastern Caribbean Dollar)", modelBuilder);
            SeedCurrency(166, "CFA Franco BCEAO", "XOF  (CFA Franco BCEAO)", "CFA Franc BCEAO", "XOF (CFA Franc BCEAO)", modelBuilder);
            SeedCurrency(167, "CFP Franco", "XPF  (CFP Franco)", "CFA Franc Franc CFP", "XPF (CFA Franc Franc CFP)", modelBuilder);
            SeedCurrency(168, "Yemen Rial", "YER  (Yemen Rial)", "Yemen Rial", "YER (Yemen Rial)", modelBuilder);
            SeedCurrency(169, "Sudáfrica Rand", "ZAR  (Sudáfrica Rand)", "South African Rand", "ZAR (South African Rand)", modelBuilder);
            SeedCurrency(170, "Zambia Kwacha", "ZMK  (Zambia Kwacha)", "Zambia Kwacha", "ZMK (Zambia Kwacha)", modelBuilder);
            SeedCurrency(171, "Zimbabue Dólar", "ZWD  (Zimbabue Dólar)", "Zimbabwe Dollar", "ZWD (Zimbabwe Dollar)", modelBuilder);


            // Seed RequestType
            SeedRequestType(1, "Actualización", modelBuilder);
            SeedRequestType(2, "Eliminación", modelBuilder);
            SeedRequestType(3, "Restauración", modelBuilder);

            //Seed Job Profession
            SeedJobProfession(1, "Administración aeronáutica", "Aeronautical administration", modelBuilder);
            SeedJobProfession(2, "Administración agroindustrial", "Agro-industrial administration", modelBuilder);
            SeedJobProfession(3, "Administración agropecuaria", "Agricultural and livestock administration", modelBuilder);
            SeedJobProfession(4, "Administración comercial y de mercadeo", "Commercial and marketing administration", modelBuilder);
            SeedJobProfession(5, "Administración de aerolíneas", "Airline management", modelBuilder);
            SeedJobProfession(6, "Administración de bienes raíces", "Real estate administration", modelBuilder);
            SeedJobProfession(7, "Administración de empresas", "Business administration", modelBuilder);
            SeedJobProfession(8, "Administración de negocios", "Business management", modelBuilder);
            SeedJobProfession(9, "Administración de obras civiles", "Civil Works Administration", modelBuilder);
            SeedJobProfession(10, "Administración de personal", "Personnel administration", modelBuilder);
            SeedJobProfession(11, "Administración de seguros", "Insurance administration", modelBuilder);
            SeedJobProfession(12, "Administración de servicios", "Service administration", modelBuilder);
            SeedJobProfession(13, "Administración de sistemas informáticos", "IT systems administration", modelBuilder);
            SeedJobProfession(14, "Administración de transporte", "Transportation administration", modelBuilder);
            SeedJobProfession(15, "Administración financiera", "Financial administration", modelBuilder);
            SeedJobProfession(16, "Administración hospitalaria", "Hospital administration", modelBuilder);
            SeedJobProfession(17, "Administración industrial", "Industrial administration", modelBuilder);
            SeedJobProfession(18, "Administración pública", "Public administration", modelBuilder);
            SeedJobProfession(19, "Administración tributaria", "Tax administration", modelBuilder);
            SeedJobProfession(20, "Administración turística hotelera", "Hotel and tourism administration", modelBuilder);
            SeedJobProfession(21, "Bachillerato Académico", "High School", modelBuilder);
            SeedJobProfession(22, "Bachillerato comercial", "Business high school degree", modelBuilder);
            SeedJobProfession(23, "Bachillerato  técnico", "Technical high school degree", modelBuilder);
            SeedJobProfession(24, "Ciencias políticas y gobierno", "Political science and government", modelBuilder);
            SeedJobProfession(25, "Comercio internacional", "International commerce", modelBuilder);
            SeedJobProfession(26, "Comunicación publicitaria", "Advertising Communication", modelBuilder);
            SeedJobProfession(27, "Comunicación social y periodismo", "Social communication and journalism", modelBuilder);
            SeedJobProfession(28, "Contaduría", "Accounting", modelBuilder);
            SeedJobProfession(29, "Derecho", "Law", modelBuilder);
            SeedJobProfession(30, "Diseño gráfico", "Graphic design", modelBuilder);
            SeedJobProfession(31, "Diseño industrial", "Industrial design", modelBuilder);
            SeedJobProfession(32, "Docente", "Teacher", modelBuilder);
            SeedJobProfession(33, "Doctorado en administración", "Doctorate in administration", modelBuilder);
            SeedJobProfession(34, "Doctorado en economía", "Doctorate in Economics", modelBuilder);
            SeedJobProfession(35, "Doctorado en humanidades", "Doctorate in Humanities", modelBuilder);
            SeedJobProfession(36, "Economía", "Economics", modelBuilder);
            SeedJobProfession(37, "Especialización en administración de empresas", "Specialization in business administration", modelBuilder);
            SeedJobProfession(38, "Especialización en alta gerencia", "Specialization in senior management", modelBuilder);
            SeedJobProfession(39, "Especialización en educación bilingüe", "Specialization in bilingual education", modelBuilder);
            SeedJobProfession(40, "Especialización en finanzas", "Specialization in finance", modelBuilder);
            SeedJobProfession(41, "Especialización en gerencia de empresas constructoras", "Specialization in construction company management", modelBuilder);
            SeedJobProfession(42, "Especialización en gerencia de la calidad", "Specialization in quality management", modelBuilder);
            SeedJobProfession(43, "Especialización en gerencia de proyectos", "Specialization in project management", modelBuilder);
            SeedJobProfession(44, "Especialización en gerencia del talento humano", "Specialization in human talent management", modelBuilder);
            SeedJobProfession(45, "Especialización en gerencia logística internacional", "Specialization in international logistics management", modelBuilder);
            SeedJobProfession(46, "Especialización en gerencia prospectiva y estrategia", "Specialization in prospective management and strategy", modelBuilder);
            SeedJobProfession(47, "Especialización en gerencia tributaria", "Specialization in tax management", modelBuilder);
            SeedJobProfession(48, "Especialización en gestión de servicios de tecnologías de información", "Specialization in Information Technology Services Management", modelBuilder);
            SeedJobProfession(49, "Especialización en legislación aduanera", "Specialization in customs legislation", modelBuilder);
            SeedJobProfession(50, "Especialización en mercadeo", "Specialization in marketing", modelBuilder);
            SeedJobProfession(51, "Especialización en negocios internacionales e integración económica", "Specialization in international business and economic integration", modelBuilder);
            SeedJobProfession(52, "Especialización en proyectos de desarrollo", "Specialization in development projects", modelBuilder);
            SeedJobProfession(53, "Estadista", "Statistician", modelBuilder);
            SeedJobProfession(54, "Finanzas, relaciones internacionales y gobierno", "Finance, international relations and government", modelBuilder);
            SeedJobProfession(55, "Finanzas y gobierno", "Finance and government", modelBuilder);
            SeedJobProfession(56, "Gobierno y relaciones internacionales", "Government and international relations", modelBuilder);
            SeedJobProfession(57, "Ingeniería administrativa", "Administrative engineering", modelBuilder);
            SeedJobProfession(58, "Ingeniería comercial", "Commercial Engineering", modelBuilder);
            SeedJobProfession(59, "Ingeniería de energías", "Energy Engineering", modelBuilder);
            SeedJobProfession(60, "Ingeniería de mercados", "Market engineering", modelBuilder);
            SeedJobProfession(61, "Ingeniería de procesos", "Process engineering", modelBuilder);
            SeedJobProfession(62, "Ingeniería de producción", "Production engineering", modelBuilder);
            SeedJobProfession(63, "Ingeniería de redes y telecomunicaciones", "Network and telecommunications engineering", modelBuilder);
            SeedJobProfession(64, "Ingeniería de sistemas en computación", "Computer systems engineering", modelBuilder);
            SeedJobProfession(65, "Ingeniería de software", "Software engineering", modelBuilder);
            SeedJobProfession(66, "Ingeniería de telecomunicaciones", "Telecommunications engineering", modelBuilder);
            SeedJobProfession(67, "Ingeniería eléctrica", "Electrical engineering", modelBuilder);
            SeedJobProfession(68, "Ingeniería electromecánica", "Electromechanical engineering", modelBuilder);
            SeedJobProfession(69, "Ingeniería electrónica", "Electronics engineering", modelBuilder);
            SeedJobProfession(70, "Ingeniería industrial", "Industrial engineering", modelBuilder);
            SeedJobProfession(71, "Ingeniería mecánica", "Mechanical engineering", modelBuilder);
            SeedJobProfession(72, "Ingeniería mecatrónica", "Mechatronics Engineering", modelBuilder);
            SeedJobProfession(73, "Ingeniería química", "Chemical engineering", modelBuilder);
            SeedJobProfession(74, "Ingeniería telemática", "Telematics engineering", modelBuilder);
            SeedJobProfession(75, "Licenciatura en inglés", "Bachelor's degree in English", modelBuilder);
            SeedJobProfession(76, "Maestría en administración de empresa", "Master of Business Administration", modelBuilder);
            SeedJobProfession(77, "Maestría en derecho", "Master's Degree in Law", modelBuilder);
            SeedJobProfession(78, "Maestria en desarrollo humano", "Master's degree in human development", modelBuilder);
            SeedJobProfession(79, "Maestría en dirección de marketing", "Master's degree in marketing management", modelBuilder);
            SeedJobProfession(80, "Maestría en economía", "Master's degree in economics", modelBuilder);
            SeedJobProfession(81, "Maestría en emprendimiento e innovación", "Master's degree in entrepreneurship and innovation", modelBuilder);
            SeedJobProfession(82, "Maestría en economía", "Master's degree in economics", modelBuilder);
            SeedJobProfession(83, "Maestría en finanzas corporativas", "Master's degree in corporate finance", modelBuilder);
            SeedJobProfession(84, "Maestría gestión integral de la calidad y la productividad", "Master's degree in integrated quality and productivity management", modelBuilder);
            SeedJobProfession(85, "Maestría en ingeniería industrial", "Master's degree in industrial engineering", modelBuilder);
            SeedJobProfession(86, "Maestría en mercadeo", "Master's degree in marketing", modelBuilder);
            SeedJobProfession(87, "Maestría en innovación", "Master's degree in innovation", modelBuilder);
            SeedJobProfession(88, "Negocios internacionales", "International business", modelBuilder);
            SeedJobProfession(89, "Planeación y desarrollo social", "Planning and social development", modelBuilder);
            SeedJobProfession(90, "Profesional en logística", "Professional in logistics", modelBuilder);
            SeedJobProfession(91, "Profesional en marketing y negocios internacionales", "Marketing and international business professional", modelBuilder);
            SeedJobProfession(92, "Psicología", "Psychology", modelBuilder);
            SeedJobProfession(93, "Publicidad y mercadeo", "Advertising and marketing", modelBuilder);
            SeedJobProfession(94, "Secretariado", "Secretarial work", modelBuilder);
            SeedJobProfession(95, "Sociología", "Sociology", modelBuilder);
            SeedJobProfession(96, "Técnico en administración de personal", "Personnel administration technician", modelBuilder);
            SeedJobProfession(97, "Técnico seguridad industrial", "Industrial safety technician", modelBuilder);
            SeedJobProfession(98, "Técnico sistemas de computación", "Computer systems technician", modelBuilder);
            SeedJobProfession(99, "Técnico en profesional de producción", "Production professional technician", modelBuilder);
            SeedJobProfession(100, "Técnico en desarrollo y mantenimiento de software", "Technician in software development and maintenance", modelBuilder);
            SeedJobProfession(101, "Técnico en gestión contable", "Technician in accounting management", modelBuilder);
            SeedJobProfession(102, "Técnico en gestión empresarial", "Technician in business management", modelBuilder);
            SeedJobProfession(103, "Técnico en logística", "Logistics technician", modelBuilder);
            SeedJobProfession(104, "Técnico en sistemas de computación", "Computer systems technician", modelBuilder);
            SeedJobProfession(105, "Técnico de mantenimiento", "Maintenance technician", modelBuilder);
            SeedJobProfession(106, "Técnico profesional en producción", "Professional production technician", modelBuilder);
            SeedJobProfession(107, "Técnico en mantenimiento", "Maintenance technician", modelBuilder);
            SeedJobProfession(108, "Tecnología en banca y finanzas", "Banking and finance technology", modelBuilder);
            SeedJobProfession(109, "Tecnología en comercio internacional", "International trade technology", modelBuilder);
            SeedJobProfession(110, "Tecnología en desarrollo de sistemas informáticos", "Computer systems development technology", modelBuilder);
            SeedJobProfession(111, "Tecnología en electricidad industrial", "Industrial electricity technology", modelBuilder);
            SeedJobProfession(112, "Tecnología en electrónica", "Electronics Technology", modelBuilder);
            SeedJobProfession(113, "Tecnología en gestión administrativa", "Administrative Management Technology", modelBuilder);
            SeedJobProfession(114, "Tecnología en gestión comercial", "Commercial management technology", modelBuilder);
            SeedJobProfession(115, "Tecnología en gestión de mercadeo", "Marketing Management Technology", modelBuilder);
            SeedJobProfession(116, "Tecnología en gestión de sistemas de telecomunicaciones", "Telecommunication Systems Management Technology", modelBuilder);
            SeedJobProfession(117, "Tecnología en implementación de sistemas electrónicos industriales", "Industrial electronic systems implementation technology", modelBuilder);
            SeedJobProfession(118, "Otra", "Other", modelBuilder);

            // Seed Candidate Origin
            SeedCandidateOrigin(1, 0, "Agregado desde Portal", "Added from Portal", modelBuilder);
            SeedCandidateOrigin(2, 1, "Migrado", "Migrated", modelBuilder);
            SeedCandidateOrigin(3, 2, "Agregado manualmente", "Added manually", modelBuilder);
            SeedCandidateOrigin(4, 3, "Migrado desde BOT Comercial", "Migrated from Commercial BOT", modelBuilder);
            SeedCandidateOrigin(5, 4, "Agregado vía Análisis", "Added via Analysis", modelBuilder);
        }

        public static void SeedDocumentType(int id, Guid guid, string initials, string initialsEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType
                {
                    DocumentTypeId = id,
                    DocumentTypeGuid = Convert.ToString(guid),
                    Initials = initials,
                    InitialsEnglish = initialsEnglish
                });
        }

        public static void SeedMaritalStatus(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus
                {
                    MaritalStatusId = id,
                    MaritalStatusGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedStudyArea(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyArea>().HasData(
                new StudyArea
                {
                    StudyAreaId = id,
                    StudyAreaGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedStudyType(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyType>().HasData(
                new StudyType
                {
                    StudyTypeId = id,
                    StudyTypeGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedRelationType(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelationType>().HasData(
                new RelationType
                {
                    RelationTypeId = id,
                    RelationTypeGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedCertificationState(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CertificationState>().HasData(
                new CertificationState
                {
                    CertificationStateId = id,
                    CertificationStateGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedTitle(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().HasData(
                new Title
                {
                    TitleId = id,
                    TitleGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedGender(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    GenderId = id,
                    GenderGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedIndustry(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Industry>().HasData(
                new Industry
                {
                    IndustryId = id,
                    IndustryGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedEquivalentPosition(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquivalentPosition>().HasData(
                new EquivalentPosition
                {
                    EquivalentPositionId = id,
                    EquivalentPositionGuid = Convert.ToString(guid),
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedLanguageLevel(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageLevel>().HasData(
                new LanguageLevel
                {
                    LanguageLevelId = id,
                    LanguageLevelGuid = Convert.ToString(guid),
                    LanguageLevelName = name,
                    LanguageLevelNameEnglish = nameEnglish
                });
        }

        public static void SeedLanguage(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    LanguageId = id,
                    LanguageGuid = Convert.ToString(guid),
                    LanguageName = name,
                    LanguageNameEnglish = nameEnglish
                });
        }

        public static void SeedSoftSkill(int id, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoftSkill>().HasData(
                new SoftSkill
                {
                    SoftSkillId = id,
                    SoftSkillName = name,
                    SoftSkillNameEnglish = nameEnglish
                });
        }

        public static void SeedTechnicalAbilityLevel(int id, string level, string levelEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TechnicalAbilityLevel>().HasData(
                new TechnicalAbilityLevel
                {
                    TechnicalAbilityLevelId = id,
                    Level = level,
                    LevelEnglish = levelEnglish
                });
        }

        public static void SeedTechnicalAbilityTechnology(int id, string technology, string technologyEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TechnicalAbilityTechnology>().HasData(
                new TechnicalAbilityTechnology
                {
                    TechnicalAbilityTechnologyId = id,
                    Technology = technology,
                    TechnologyEnglish = technologyEnglish
                });
        }

        public static void SeedTimeAvailability(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeAvailability>().HasData(
                new TimeAvailability
                {
                    TimeAvailabilityId = id,
                    TimeAvailabilityGuid = Convert.ToString(guid),
                    TimeAvailabilityName = name,
                    TimeAvailabilityNameEnglish = nameEnglish
                });
        }

        public static void SeedWellness(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wellness>().HasData(
                new Wellness
                {
                    WellnessId = id,
                    WellnessGuid = Convert.ToString(guid),
                    WellnessName = name,
                    WellnessNameEnglish = nameEnglish
                });
        }

        public static void SeedLifePreference(int id, Guid guid, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LifePreference>().HasData(
                new LifePreference
                {
                    LifePreferenceId = id,
                    LifePreferenceGuid = Convert.ToString(guid),
                    LifePreferenceName = name,
                    LifePreferenceNameEnglish = nameEnglish
                });
        }

        public static void SeedFileType(int id, string name, string nameEnglish, int orderList, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>().HasData(
                new FileType
                {
                    FileTypeId = id,
                    Name = name,
                    NameEnglish = nameEnglish,
                    OrderList = orderList
                });
        }

        public static void SeedFileTypeHiring(int id, string name, string nameEnglish, int orderId, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileTypeHiring>().HasData(
                new FileTypeHiring
                {
                    FileTypeHiringId = id,
                    Name = name,
                    NameEnglish = nameEnglish,
                    OrderId = orderId
                });
        }


        public static void SeedStudyState(int id, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyState>().HasData(
                new StudyState
                {
                    StudyStateId = id,
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedDocumentCheckGroup(int id, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentCheckGroup>().HasData(
                new DocumentCheckGroup
                {
                    DocumentCheckGroupId = id,
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }

        public static void SeedDocumentCheckState(int id, string name, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentCheckState>().HasData(
                new DocumentCheckState
                {
                    DocumentCheckStateId = id,
                    Name = name,
                });
        }

        private static void SeedCurrency(int id, string name, string shortName, string nameEnglish, string shortNameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    CurrencyId = id,
                    Name = name,
                    ShortName = shortName,
                    NameEnglish = nameEnglish,
                    ShortNameEnglish = shortNameEnglish
                });
        }

        private static void SeedRequestType(int id, string name, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestType>().HasData(
                new RequestType
                {
                    RequestTypeId = id,
                    Name = name
                });
        }

        private static void SeedJobProfession(int id, string profession, string professionEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobProfession>().HasData(
                new JobProfession
                {
                    JobProfessionId = id,
                    Profession = profession,
                    ProfessionEnglish = professionEnglish
                });
        }

        private static void SeedCandidateOrigin(int id, int ismIgrated, string name, string nameEnglish, ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateOrigin>().HasData(
                new CandidateOrigin
                {
                    CandidateOriginId = id,
                    IsMigrated = ismIgrated,
                    Name = name,
                    NameEnglish = nameEnglish
                });
        }
    }
}
