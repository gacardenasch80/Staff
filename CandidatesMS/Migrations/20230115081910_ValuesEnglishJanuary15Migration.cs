using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesMS.Migrations
{
    public partial class ValuesEnglishJanuary15Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "a80ecdf6-5333-43cf-b529-75cd4bdd30fe");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "94c18c77-71a2-4183-a042-5d440dc2cc45");

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Dollar", "USD" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Colombian Peso", "COP" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Euro", "EUR" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 4,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Australian Dollar", "AUD (Australian Dollar)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 5,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Brazilian Real", "BRL (Brazilian Real)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 6,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Chilean Peso", "CLP (Chilean Peso)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 7,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { "Mexican Peso", "MXN (Mexican Peso)" });

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "4fd8771f-78c4-409f-94be-7e73eb7202e0");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "78b47de0-7e94-49f2-90c9-86cc4ceb15c3");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "540d891b-2021-4685-b4af-b8150bd6e4fa");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "a5e278ce-b68f-4a81-ba0b-19e515ae43a7");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "25f6d054-bd2d-4e19-ac4d-6609c6cfb066", "T.I" });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "47a1d0a2-11d8-4454-a29f-6345d28b818a", "C.C" });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "bce54ca9-0f3d-4d1f-a975-f80f971c4124", "C.E" });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "6595718b-0abd-42ac-87e4-2809825fee50", "Other" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "7788d21b-2eb7-4672-9876-696201abbf5c", "Intern" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "c5f725f4-92a2-4c9f-a31b-8a05696dcd34", "Practicing" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "a52e6b58-97c1-4c15-8194-b660da0fc338", "Analyst" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "9f11b4c1-3b2b-47df-b7a2-ec46c01ef82b", "Coordinator" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "729d47ff-b894-437d-bc44-dd9690b763b4", "Coordinator" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "c6f7ae11-3d31-4914-83ea-444d0daa00ae", "Manager" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "ab9a223a-ef8c-4e38-b453-1a4ec12f9d1a", "Developer" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "2582a4bb-0ab2-435a-ac9f-4e8e0f260cb7", "Advisor" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "8c5b2495-fed0-4be4-8d0d-87fede604f1c", "Tester" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "4238b4f5-26b5-4524-b821-f293f397149b", "Consultant" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "67ae74e8-7b5f-4d10-9aac-d26eb7a4edd2", "Consultant" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "cce7097f-0e1b-491c-928c-5a3c91642307", "Assistant" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "a20b5c68-94dc-4cc7-8c91-04d3d5a02a7d", "Director" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "ec8c5436-44d0-4ca6-8940-e3ff3a9e373b", "Executive" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "c4a7a795-19ce-490d-b0b5-627cd84a4aef", "Trained Trainer" });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "f6cc47b2-2046-4acc-9c67-dad9ccf50035", "Engineer" });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "78579235-0d81-4aff-a67f-6b10bef40b66", "Male" });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "911c63aa-d556-4ecc-89fd-5427eb96d545", "Female" });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "2a566312-602b-4a39-8d84-dd57489c5456", "Other" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "6e388c6d-56ec-4faf-be7a-7d2c2604cc12", "Insurance Brokers" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "bfe1cbd5-f3b8-4504-9991-dd5bc2b2b11d", "Insurance companies" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "c28c76c6-3ba1-40f2-b9cd-9fa7e5bd9f6f", "Chain warehousing" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "7ded8425-0384-42e0-95c2-d0c7a5224bd0", "Retail" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "b6b8f324-df32-40ef-a85f-19d70a94865c", "Temporary" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "8ce50996-3872-432c-aa99-83c3f803c3eb", "Consulting-Advice" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "9bafe597-041e-489c-a721-b29e7822e850", "Financial Services" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "e3d00447-db76-4ff7-903d-ab6d99c47896", "Oil - Energy Sector" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "786faaa3-e5ae-414c-8b71-ddd593c56a06", "Public Relations (Marketing)" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "00105948-351b-4aaf-8a2d-202623e48af6", "Health sector" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "71cf3855-98e4-4dd0-8f28-9866dcbd56c7", "Surveillance and security" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "d63f7d7d-d22b-4aa1-b496-a995e7c209a2", "Services" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "db968e9c-fa77-4369-a167-adc7dece07ae", "Web development - technology" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "477ab27c-a13d-4774-a540-338a745caa5e", "Massive consume" });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "5559dac1-be55-425d-aaa9-2d817a611e54", "Other" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "a2a27f4b-3c32-4ddb-8fb0-d23720271308", "Spanish" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "a9d79399-e2ca-4c3c-859e-383c66d1c242", "English" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "c5d7542b-5efe-4c17-8b99-45f591ce6823", "French" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "e896d43f-c844-41f6-a1fe-51178a02fc8a", "German" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "98a73096-7b64-4214-a11d-f1bfcf6bb51f", "Chinese" });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "14f8c79e-0cce-4195-b117-fe2679575a70", "Portuguese" });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "LanguageGuid", "LanguageName", "LanguageNameEnglish" },
                values: new object[] { 7, "19d22054-7983-4b22-8154-6ba4175def42", "Otro", "Other" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "a5af2f80-2235-48d1-aa0d-767e78e332d1", "A1" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "9ab2f951-18ab-4c28-8127-612e8c934cd6", "A2" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "4bca61ef-55d1-4706-b7ca-60e0ce876a60", "B1" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "ac68be40-6851-478a-98ed-5a84dda885c0", "B2" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "d81695f4-ef8b-4692-a868-a3612c2ec1a1", "C1" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "67166367-e588-4402-bebc-488e13990a1c", "C2" });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "36877569-e3c5-4db3-a88b-33a5a5abe986", "Native" });

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "00bdcaca-172e-4f8b-b3d7-ee66d65f6151");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "f810fbce-881a-44fe-8b01-aedfdd9a3f06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "6657d307-c146-46ec-938f-debcb606b12e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "abd58b45-f4ab-42b5-bb0e-5947f3ffb3df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "bbe1392b-53ea-403b-8b91-966ec33ba20c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "c582bbe2-8fe1-40d1-98b7-b002978dd351");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "94a993e8-67df-4c55-925d-b964ba0acc67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "0d51fab2-11cf-446f-850d-a62324d28095");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "0ded60e0-eb03-413c-8654-af99706bf570");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "8fd0b8ae-ce11-46a3-9afc-3cb1fcd51632");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "4aec2b72-15c3-4f7c-8c23-0a9453f8aaba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "0cebb3f3-b1e6-45f5-8c61-73de39a1d61e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "a0be279a-feb7-4c2e-985b-8cea9466f660");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "f79e9f35-4d3a-4662-a2a0-170a629d7e2c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "ccc7625f-9078-4572-be21-a283b2dedc0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "e28d292f-ae8e-4a86-815a-aa467af3b6de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "42b6f714-bd3f-4252-9392-2eac8fce48fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "e78e4474-dbda-4aff-97da-511b2e049097");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "63b2b732-79e9-48ba-8e19-a7e03bb46689");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "ddc9d101-ff01-4c94-b9ed-362ed117d9dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "e0ec27d7-8181-46f3-9b02-2f01a54201e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "0fd90444-0e5d-48ff-a534-713ef36b86a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "7a47f7cb-e604-4658-8564-e56b9dd78d45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "67f2616a-ebb6-45d6-852c-ae2ec35cf65f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "4cb97555-b18f-4408-9995-ff616f96dac7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "bc18edcf-7d6e-4bfb-8ac2-c2aa7113aab8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "f01bfda1-f7e9-4d9d-a60e-a80b033da4e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "32496efd-5b6c-4924-932a-9379f2498588");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "5054e786-6ad4-46c3-8f34-bcf2cdf76d2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "b6518d6f-0118-42d1-99de-dded5178f6cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "c4c3867e-9d56-47fa-8bd3-6ee7d4529a96");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "d1e64d97-b64c-4d73-a5bf-b7fcb5502e1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "c33bc2b5-0833-42d4-b101-86a02b7555e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "4a88dd4a-050e-4ad5-8b80-8d4b715a7a93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "46302cb3-d02f-4355-81a9-970c43272ed6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "c2dd88bf-b8af-404c-b9f1-1bf737f69172");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "6ed42d1c-30fd-4d55-a3bc-f74946525e21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "e87dd066-f00e-448f-8dc2-9cb4f55321fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "6e69f121-2539-4857-9665-5e5caa06dab8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "bc0ac23d-02fd-4b9f-a885-c4ad1b86eb67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "1907c7f1-a7d6-485c-b2b9-62a89e3385c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "ef051cfd-484a-45e1-af67-e8d4adf63655");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "07ee0293-7cea-4cf4-b9dc-3cddbcf26ed3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "2876e54a-627f-4d43-b2f2-30000f45c6d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "abdf7197-03f3-4300-8e82-14a7f2c3e9da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "25e68050-2eae-45d5-95f2-6a62190356b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "e0f8d792-a5c4-46e3-9b52-e75ee3fa3a2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "884ab258-3ff5-43db-8cbe-24442764baa2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "bf63b466-3327-4a19-9420-2deb4ca5db74");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "f09b1f0f-8e5e-4c94-ae5c-89c884000b7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "959a44c2-a851-4502-87ee-6657ef592bb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "ed8cc931-9019-451e-908d-4f175183e2fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "a03ca312-e6fc-41d4-b81a-c6324aa6d7cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "0e002bdf-4533-4792-803f-11b64d67a4b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "12ee67e3-8c17-421f-ae1e-ab6f7d027165");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "915b5544-0e99-4a2c-9647-238b514904f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "08eb4b6f-cb1a-4a81-927f-3fcc2f3ed6b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "f68b9302-875d-43d1-a08f-82f739b7e3bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "9a075ec2-c374-4b74-b64f-6edd6fe5783e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "0820c85a-b497-4031-a89b-5dc367ab95c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "d37e0ab2-d297-47f1-999e-92a434b9400d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "64042d9c-7800-4fb9-b8f1-630d88d4d230");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "455964cc-2210-42c4-9aef-f5b26d4629d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "b00ac467-f201-433c-8040-8c9f9d40c222");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "9403c23f-2fd5-4f25-bae3-e134ab94af34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "1334c12e-a937-4fb8-8b5d-8bfd8d53a74d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "eefcec81-3ead-4554-86bd-ccafb06acaae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "f052f471-3c91-4db9-a732-602f392bc3b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "418585f9-bae6-479c-8049-b93dfcc846c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "93f19507-1591-4efd-a401-af18f5d66dbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "32af1073-5a15-440c-883b-e4b3ca6f6a28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "79695aec-6c15-4fd4-89de-a42889219a14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "0db4884e-cc9b-4d9d-95b2-324486fdacb1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "36e7b85e-5360-4c69-98aa-b82bb088eafd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "1363ee88-4253-4f3f-930e-1767f4c229a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "6b42c742-c9ca-4b15-9768-5177a8c65611");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "626832aa-10b0-4a96-9d68-84815e5b619d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "78f3ba23-0112-49ab-9513-10142ffb3ad1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "4972406d-af47-420f-9151-8e6ea321b3a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "8775000a-c83b-4c7f-bf23-3573047211ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "a4c58d94-c343-4173-a541-010fc8f5eee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "17e854a7-761c-43c5-82c1-98f6a037e7f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "833ff5e2-7164-4198-aa12-ccc2cd95e91f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "ae1be779-9c54-4c87-a506-24a421c9108a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "a49362c4-03e5-4498-a9df-0f8c71d752a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "d0798974-312a-4071-9a8a-8ac2624bc968");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "a0b30b6f-b7b8-4a15-95e8-3cb9ef3f6dde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "dad57a94-554f-47bf-9c33-1db1b9c5d204");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "de516437-af03-4941-9100-4173ea157947");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "e665be87-39df-416c-8659-f182e3857fc2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "128697a8-3756-42a0-869b-dcd92fc92b50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "db2ad856-cc7c-46e3-8c43-7cdd7006365b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "a4af353c-3380-4037-b365-ab37e0c4dfb6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "1f5a1563-8b33-4756-9cda-89683a6566d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "2101c37f-3c03-46ce-94fb-d8cf41a062b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "fffa79c6-4310-4a3f-b75d-fc7b1bd4507e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "75501521-211b-461f-ac2b-428ad74cdef3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "79c1f093-b90f-469a-8461-86457cba099d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "1fa2b9a4-69f4-4c5f-83e2-2238e7c98810");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "5c871ef9-1fcd-4e2e-a899-ce62a72b472d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "dd9fc98b-08ff-4731-8b90-e38c9034b020");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "7f27eb23-ffaa-4855-8ec3-a66ce3d8e24b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "93e73e90-5cdc-447b-adca-2be285d107c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "8240e167-60f5-4a66-a71d-ad04ca169c4a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "68cf8e00-8cf7-46a5-8746-76ffe3a950f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "d5400571-4169-4bcd-a1df-29abab619a4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "4333434b-d2db-4a08-b349-ae5b635c8d90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "e33cd9d6-cf02-414a-9d62-c4fdc626fa8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "4ffed8d5-b49d-4bba-98bd-4c149bafc09b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "0110de6c-6889-494c-9a89-ee9cceba6d1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "fddf5b22-ebe9-4594-9ffa-dbd4e6346e75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "a79c227f-8841-46ce-9ec9-26b0a993616d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "5b19b73b-678b-4fd6-aa84-a76b52004c7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "6970cfe4-20e0-46f8-a167-fa52f20d2a20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "f7354056-6c31-40dd-bad2-d04d872f71ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "5b4f618f-208f-4726-b234-1b99668d4ca1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "e3384138-0c61-4508-b1ed-5518bd96f722");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "cd197f5d-28ff-4999-83d5-5fd2234ec2f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "c25fe7f4-9303-4091-930e-07be81bec93b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "aab12ee4-3de0-4869-9022-abf43c072343");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "75b05a92-d8c2-47e5-acd7-4a42d590fa58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "400fee53-eeeb-4f82-8a81-4f9d5189ea25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "66269435-7ad6-4ab6-91dd-32598cb1b389");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "be5f3664-38d0-4c6c-9995-ebd8f62935d8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "d8be0974-9e9e-429e-a302-cd2f45e78c35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "8a6d7388-40ac-4402-a761-93d89d56eefd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "a8cadad0-b1f1-4b50-a7c6-c6a013801f8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "ba8a1b38-9b89-4995-ae91-2a007d393357");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "dd9d9fb2-0ea2-4c13-9117-391bee737a58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "12185d08-34fa-4397-b620-c9f1d5b42f46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "c2c85bef-c62a-415a-bcf6-ea5bd18d3e2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "354dc372-9cf2-4e10-b78a-2aab0cfc4e1a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "12eac849-d748-4492-8e36-d6194438efa9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "ea1e7abf-679f-41d1-b0c6-4d41d8a6a945");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "25d1e003-24ec-4533-85bb-f6d57def5421");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "34a8b8db-7718-4f34-bf57-f407c56d27c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "e8c859b5-3b17-4a3f-9688-2ba69e879b00");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "85995576-1f38-424f-a6db-df72388cc96f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "8465138e-629c-4d70-9144-7be83955c0ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "c3930b3a-75ea-490d-a0b7-5363438969bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "61d9ed62-de51-4afe-bfff-c3f14d4eab15");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "555360e1-5bb1-43a9-a9dc-f98a6e5d1300");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "4cce34f5-ec6e-4ca1-9e38-f306c53b2c8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "5a5a25de-eb33-4479-bf75-20d37b1a70ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "90a05167-7e99-4156-a2a6-63444781f50e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "e0b2fa63-0f5b-42c7-9758-7f840427bafb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "2aa7989c-f493-4300-b57d-d513ce1cbed1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "5210c9b7-8f39-4c0f-ba73-8577f49e9ec3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "a91dccf8-715d-400a-b94c-e17e6fa9676f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "664e4922-854a-4cf8-9509-911d3dd0ed20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "02178e14-00d0-4abf-8cfc-9042d643ab9d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "dee83056-4266-474d-a3ea-c31d13f6457b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "262fe26e-ccb8-4655-8d40-d9cb6b2adafa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "4ba5478b-8279-486f-a5ea-f94c97fbf73c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "1cd82ff1-cd67-488d-a68a-c9a95697c97a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "2fff268e-7d43-4047-9f6f-39c1ad3c3bd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "fc9f7cf9-6663-4dd8-a8f4-9b31754738ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "89341c70-3538-4c40-8d7d-e3372c160761");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "b85c3cb9-5ea8-45fe-9f8c-f1a101be6250");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "ab217192-dc5f-4898-ad1e-188d413be175");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "14c5e689-5e65-4499-983b-76a46e2632aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "89546a39-f090-4b26-8114-bec8d5e4422e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "54f10abe-b4d5-4d6f-9b78-96773fd808ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "32ed49e7-b2ee-4c0e-a54c-1352b20e597f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "48972c09-849f-49c2-88b2-0101ba4f0c38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "ab97ed11-55d2-4e35-aaa3-86c27de48bc9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "f8774ff7-4cc9-479a-8e43-2004e16438eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "a2a33e17-c7b6-40ae-972f-289cf58f358e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "fdae8a78-4a6e-46e2-b072-f0e5e8a0ca76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "0f1f8e60-0049-43d2-b982-73d4b7e608e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "e16a66c9-f38f-4a7c-ab0e-2f9f5e9b8bdf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "f12092a9-22e7-4c88-9fc5-8a0fa1f9b096");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "648daa4b-b823-42bf-96cb-ffc7393d5ac5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "8cdb19f8-caa4-42df-81d8-e7433dfeccac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "1a0c64ef-3548-46a5-8e55-19580c16f272");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "1efec6ef-a70a-463c-96e8-8eb4b68d2944");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "7ccddea7-72ad-4c8d-b803-ceb3b1ed374f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "58b12e3b-635a-4e35-87d9-6bf62fb4a34d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "1fb4445a-9af1-4b93-b7fc-4663d7c43b88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "7b6c0df7-afae-4752-8362-561b6dd3de8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "83641e42-e9e0-4a99-aade-b707108e3e57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "15236706-3b38-4301-b166-9a5ba3eba533");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "dbf7d5aa-6118-40de-aba2-5ac080c05128");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "67760182-03be-4540-8042-961e7a311670");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "fe758a9c-d43b-4b76-a801-0dd40368fb51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "2038d7bb-8043-4d1b-816c-c9de049f8a15");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "9d765a1b-62e5-4453-bbd5-133076748ce5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "35c779f3-b39e-4ed5-aed0-0a3c0180b77e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "abab7746-1d50-48e6-9de0-18bfa2869b21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "f80f00ac-4a5b-446b-bbac-17a0f5f0b684");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "209d03af-d306-45ec-b4db-b5da1108eef0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "6c332b29-0bfe-45fb-ac01-6edce6d2454d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "d585160e-1099-4b2f-abe1-f8bd4f45ba2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "57f8794d-b393-40da-ac84-c1d03ec9f4fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "3901afa4-818e-4dc2-8a27-ca8a8b551922");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "8956b0d3-202f-41ea-b38d-8dec04611789");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "1e9ec8f8-59c1-4eb7-90f0-1f5d7bc05345");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "53e64f4d-ed49-4805-97b5-6c66318b953b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "41df25c3-b12e-4826-be77-2af690937fca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "39ea975a-1eb5-437d-ac6a-ddf8c359107a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "e2ad8c5d-9ff4-41a7-bbbf-9f4ea4d1c3c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "d303e3cd-82ee-429b-9490-7316efa48b75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "08f31797-2de1-4657-8ce0-7db7bdaed71d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "0081cf76-8bf5-46c9-b9d8-e4dc29d1c504");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "0a101a3e-c5e6-46a7-9442-32023e463bf1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "6f61fdf1-198c-466a-bd65-53f4fff9a457");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "b0e347e2-2fdd-4ba5-8c91-64f364d5c88c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "4fde0d66-fa4d-4962-8499-f88411149812");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "73844a71-3426-41b2-b800-a637e3d820d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "435be223-7725-48b7-aed2-e8e1d8a2ca1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "0cd122dd-b055-406b-ba1c-aedb2d1d1c24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "b069856c-c48e-48cb-af41-ad09a3a0dae4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "e6f8a1be-c20e-4ce5-af0b-21c09ddd71ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "6eb8a90c-71a3-4eb5-a916-35edc93076aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "29625519-89d3-4f35-865d-a0e298c1ccb3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "847a34f1-6d6a-40c5-a056-6eb82b7c60ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "7f3a1824-f513-434c-8f64-c245bc01eb6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "2fb44a60-47c5-4097-8d71-342af87b9458");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "bca6a653-8f34-4b81-9b81-ec2a870ea668");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "fe272913-580f-4305-a927-ab30bbe1d940");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "a7ede808-4291-45b2-98c7-e16c898473ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "0b6e5f04-bb1c-4e37-b59b-290b88ab7ef2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "ad75f99b-aafd-41eb-a711-b5442407ebde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "bcd3efe9-c5bc-4aa6-9b90-85fcdb6fd20c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "72881168-0d2c-4a3f-9d67-15012deab18a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "42832920-166b-488d-812c-6060495296c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "790b1fb3-2ef2-4dcc-8450-f3d28fe781bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "61efd920-9267-48b9-9fc2-c29166edb411");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "0ddda279-7eb8-4e1e-bd72-d843cc325c21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "1c53d4bd-e77b-4cd7-93db-2e4b5767f9a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "fa65bae9-f494-4a1f-a999-bd23749bfc1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "1e5d7310-70f0-4f9c-9e30-4f01edc8da0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "12bcd63b-f513-4a48-a2f1-a7ac3620a645");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "8c0fd997-3fe6-4869-ad2d-a0b393abe0a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "ac87d29f-8e3b-496d-8a95-6a324efc2404");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "d09c01c4-21d9-402b-9aaf-00b799f79d1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "fa20c22e-182e-4387-9690-adc6f649c2d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "22362e4f-70a9-4b99-9107-be24bf2472e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "648840ce-1d63-43d5-865f-bd15cafe108b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "ca3128ef-ee3d-476f-b4c5-2ee7ef2a7d8d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "dc92d4da-1561-4a88-ac4c-90ad3e8bd903");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "51c57fbb-a2a2-4cde-ad90-cf4d83f03ae1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "cfb17dc7-ef84-43fe-a2e0-8d856d75131d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "667cba37-3c55-40fc-b6ff-0e437e640b75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "d1305260-457b-4411-b91f-d7d869d9e897");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "0f07319e-be65-4709-bf41-e1e49cfdd683");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "e7629c40-46f1-4a03-8b2e-b59f09117b84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "1606035f-78c4-4ab9-a259-d5f0d7e29eba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "205dedf0-f6f8-47a5-985d-334cf6a21f2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "feada5b0-53fd-4321-9e80-01207286cef1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "59cefa1d-044a-4639-8b3e-23c720ca77db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "4be54891-aeda-42bc-bd28-62f487506317");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "cd956ade-943c-49bd-bcc3-c1ab87715b0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "d6d919f6-e04a-4359-8eee-1ed6624bd847");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "5cae8b2e-d7b7-4313-8b9e-70665d09fed3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "ab4afeb1-12b9-40b6-96b1-13ad56b35ea7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "6ab28649-2aab-41cb-babf-d378edebdf43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "1d601fa3-0684-408f-9db2-bd2359664a76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "d75fb36f-c7bd-4c00-9a76-da87b04fbecd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "4cfecec4-0c45-4f9a-959b-653b229059ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "75b0196f-b643-4089-816a-c11909ee3f4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "9b790f7d-b1d3-441e-9893-9982311b6beb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "39dc90c4-4b1c-4326-b019-6d42ad404f3e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "9134d5c4-de5e-4a96-8fb7-00b325fe2590");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "9c04af1e-26aa-4a1d-9966-a5a094ce15f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "d6d937f3-17c4-4178-9b5b-84d0b9fca5c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "bf0d7fbf-d5ad-4989-bfbd-53adc97a3a3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "ef40268c-8cd0-4e51-bd55-fd20e2c9d1f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "7acc44e4-13cb-4de7-9041-df8972fc8024");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "2150f633-86ef-4461-9f35-e852aba6cd8d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "5ed7ccab-aed3-4625-bb10-9e1e59be15d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "d2f049d2-7074-4fb9-8cc9-3c5155920962");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "c1978ebb-e24f-4c0b-9f7d-5bf5f3ff6abe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "155e18b6-1442-465d-809d-005c44fb63e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "47b3ee1d-0516-4910-8032-5e1320b89df8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "f5b13541-ffc7-4a91-8122-6c65c1620fdb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "0cb4dd36-fa59-445a-a080-a615c3228812");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "12446ac8-b2f4-43b2-8478-a406197c2e84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "3e275f92-f9ed-4fe1-90a6-a311b2f2fcec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "16fe7f72-0f3a-41c8-bfbb-28466cabec42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "9b2d3cd8-1410-4be2-9a1b-02fe9f59dc0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "79d5ccce-be81-4385-af58-b0b237a01949");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "493a6040-b04c-4d47-96fe-1c823d4e8695");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "b4c54f42-a784-4100-8495-cf932a8844b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "8bafe23b-d6bd-4726-b14f-3f09fc3c7bcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "b01a60e9-ab6d-4282-8bc1-6c701f862bff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "863e7519-beed-4616-868f-2be956134ebd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "3c37057e-2fe8-4280-ad23-e01cd0ab11aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "fa44c534-543a-442a-8222-c94012e83334");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "89f7c748-02ca-4bd7-ae9b-62309dc5572d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "bed6d21c-5c43-4711-8775-606a3317e235");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "56316898-99aa-4dd1-9362-d8e8b740518c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "25c5d85a-ee4a-4dfd-92ac-6c1995ff54ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "2f469c78-026c-4231-9155-5f4f23eebd3e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "479ff244-69c6-4837-9e9d-089555399cb9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "f28682b7-002a-462f-b432-7afa056c5e94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "7fb22e87-e64d-4fdb-8bbc-6bd3139ce716");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "85920aa9-97a4-4bd3-a92a-142b6505835b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "bb64a3f0-2edf-42e1-9442-42f0df60f8ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "d573192d-a498-45ab-8bb1-a5e665fa9337");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "ff72b6b3-0e17-4536-b150-089e4d49a0c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "4ec37847-54cb-48d7-9432-8d5307f67f2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "8a604322-19e3-471c-b2d0-41853b39230a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "bc20bef0-b7a6-45a5-893a-14f37680bfb0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "b3fa398c-61f7-44e8-bd5a-121cf1d06b41");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "52c5048d-0859-4a2a-bf81-0246f6b98c78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "fe93e1e8-32bb-40e1-a89b-a808c0005863");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "1cc5d35a-0fb3-41d3-b3d7-3fb0c01ae1a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "cdc30574-3c05-49aa-a2de-edd5fda40238");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "63782dce-586a-4c37-b86c-9db1da4968df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "83cf35cb-ce72-4067-abb3-77db095adb3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "e0e3be2c-57f8-437d-a77f-675c9be3f8d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "c4713979-d2c3-4f9a-94fc-453b80e5926c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "a714aa7f-66d8-4053-8256-88036282c38b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "c0be94b5-b3f8-4ecc-b31b-7168716af995");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "5fc20492-03ec-4d05-bfb1-98b1cd416204");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "c25f69f1-f9fc-4e2b-8997-c76fde0b736a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "c31a90d2-467d-4c98-a329-fe77e5c706f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "3203fd20-0080-4496-b07e-2c0896253090");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "07aa70ac-6df6-42e4-ab5f-0a1a73608709");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "de833d31-7ff7-4a8c-8b46-415c7147bcfb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "1c0d22b5-dff7-4055-8f6a-29a167f0884a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "a564317e-5726-4e6c-be94-fe6667c969ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "7b0c77a4-cf77-437a-8ec4-c198b928ec8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "624fcab6-3aba-4746-bbda-361bb3379def");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "b375611c-b7bd-448d-b80a-c0ba1ea413af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "47b49364-c367-48b8-8407-1e6456931497");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "936bec1e-711d-4802-a82e-1aa178167485");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "4e63a63f-bc10-45e4-b6ee-8e84737f7066");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "72168869-ca97-4874-9523-ae9287b9ae9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "41bcaf96-b3c0-4cd1-a75d-22b6fd51c5dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "e471f942-212c-4b34-b257-f387a45bde53");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "9316467f-feef-4040-9d0b-1bd02cfe83bf", "Single" });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "8641b462-7420-4f36-8cb4-20f0522d6624", "Married" });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "bd776335-c074-4e71-ab04-f6813eb4212a", "Civil union" });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "243212f4-baa8-4a34-bdad-53d8e5f46798", "Divorced" });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "95a090be-c081-4112-acd6-4477b0de1a27", "Widow/Widower" });

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "63fba51a-b800-4bc7-bcb4-71650d5b3471");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "2f33400a-482d-4508-8900-cfba803e8258");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "84139735-f29b-49b0-a8cc-56e6fafec935");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "5d397317-2f9e-4e91-b8b4-a6fefb34942b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "d65a3170-c6a3-4e9f-9c5f-957a0e6df757", "Negotiation" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "919654f6-5e91-42b8-99f0-d65785e89bbd", "Adaptation to change" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "d747ae85-21ef-40d1-9be8-cdafd1e9e1f9", "Decision making" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "c1fe024f-66af-448d-a91a-329f432a06b4", "Planning" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "6dac1cac-f69f-4cbe-a52e-2f94110ada30", "Empathy" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "cbe593f9-50b1-4fad-babc-01a3d37484b6", "Influence" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "582949a4-701a-4c06-b4e7-001f51ea3fc7", "Motivation" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "242e00b8-2896-4a79-84aa-484262a55be7", "Sociability" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "b112800b-94ed-4d79-a8cc-201e7279e99d", "Achievement orientation" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "1b726423-3bd4-4f47-86cd-6ae89b3332bc", "Teamwork" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "73efa2ad-9fe1-470c-8aac-8bceccc1f67a", "Detail orientation" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "11b00172-4db0-46c9-afa5-9eb0c786f119", "Persistence" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "d8c56c21-4f73-4f40-a6ff-f3f112c31b4c", "Responsibility" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "81e82b9e-a35d-4853-bcbd-325e9d9d5188", "Commitment" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "6b55bae1-dd9f-461a-bbae-d3e6938a9448", "Assertive listening" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ee5ced94-c2e2-428f-bd62-aa2624125b61", "Receptivity" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "bbad784b-c9e2-4488-94c6-286cefed1130", "Tolerance to frustration" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "697ba90e-f20f-469a-902c-7796552a42da", "Problem resolution" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "301ce2d0-e2e6-478f-81ee-e6d176fa84cb", "Numerical analysis" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "2d2f6513-4d19-47ef-a9ac-63eec324cc56", "Customer Service" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ec3bbaef-34d7-4443-9b8f-ef6e8d6b2387", "Creativity" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "dd28560f-5e9d-4982-9d27-33d6b9033c8b", "Leadership" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "3af4b2b1-6402-40ee-88d6-5c0f54f9f1e4", "Initiative" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "0eaa6ee5-f2fb-425c-88f6-affc9232e2f7", "Self-management" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "d06b2d29-e99f-41db-b511-52f31d871c13", "Resilience" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "1febdc18-065d-4271-9433-e2e4a8646e7a", "Proactivity" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "59696c0b-3498-40d5-a5f7-5f76e96487e5", "Fast learning" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "5066f824-4db8-4d2c-92e5-9d881202bb78", "Critical thinking" });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "66219923-8c63-4c38-8003-bafaf7bd8938", "Conflict management" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "13fb265b-91a0-4abe-bd2e-da4e7f69c5af");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "74a426fb-5fd3-4f86-9fcb-ba51d1c39af0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "db1140e5-d0cd-4a14-9d87-26b1fd0bd9f0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "dc28e7d7-b084-4846-8fd8-59ed8dca2ca4");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "f58c362b-e599-4811-b6ae-7410cbae749a");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "2aa75ffd-0f7b-4879-acf5-9e05d7e4e222");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "525e6811-8e54-44c0-812d-42b9278b24fa");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "7397b2cd-93b9-444e-82a1-f8f44e9d93b4");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "64cdd442-03e6-4387-b8b8-2f3679bc388a");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "90dec70b-272c-4b3d-8400-343cdbc40b73");

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 1,
                column: "NameEnglish",
                value: "Currently studying");

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 2,
                column: "NameEnglish",
                value: "Deferred");

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 3,
                column: "NameEnglish",
                value: "Unfinished");

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 4,
                column: "NameEnglish",
                value: "Finished");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "98ad07ac-cd97-4af8-ba36-b6c5b98cd51f");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "affec285-0943-4987-a9bd-40d151b19bc5");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "d90e0ec8-7ac9-4397-aefb-8f71ce04f75c");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 1,
                column: "LevelEnglish",
                value: "Basic");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 2,
                column: "LevelEnglish",
                value: "Intermediate");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 3,
                column: "LevelEnglish",
                value: "Advanced");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 1,
                column: "SectorEnglish",
                value: "Insurance");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 2,
                column: "SectorEnglish",
                value: "Chain stores");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 3,
                column: "SectorEnglish",
                value: "Retail");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 4,
                column: "SectorEnglish",
                value: "Temporary");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 5,
                columns: new[] { "Sector", "SectorEnglish" },
                values: new object[] { "Consultorías - asesorías", "Consulting - advising" });

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 6,
                column: "SectorEnglish",
                value: "Financial Services");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 7,
                column: "SectorEnglish",
                value: "Oil - energy sector");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 8,
                column: "SectorEnglish",
                value: "Public relations (Marketing)");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 9,
                column: "SectorEnglish",
                value: "Health sector");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 10,
                column: "SectorEnglish",
                value: "Surveillance and security");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 11,
                column: "SectorEnglish",
                value: "Services");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 12,
                column: "SectorEnglish",
                value: "Web development - Technology");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 13,
                column: "SectorEnglish",
                value: "Consumer goods");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "5ce9a431-2ec0-43c4-91c7-81e3db3f617b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "15fa8853-8f14-425f-a1f0-fc51a8e012a2");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "4b68316c-d3a1-4d90-a132-9971f60811fd");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "eb2e8762-bd86-4887-81cb-19ff0528da04");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "30d95042-c1e1-4418-a08e-eaf1e1b8f06d");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "8fafaa79-07a1-4d6b-b569-2e97b39efeb1");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "7e45ec0a-c256-49c4-8862-732680647185");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "205a31c1-028f-44b4-bc96-648a19aba70d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "49d61443-8a3f-4bc6-9d3a-bf5d6cb3f88f");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "1eb547a3-b86b-499c-93db-98e1385cf8ab");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "a1db8aea-5746-4b04-bfe3-8c8391af25e6");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "5944167b-3eeb-4f89-ae2f-6a6babc2d565");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "d223d897-63be-4705-b5ee-ee270bc47aca");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "f06b92bd-d075-40b6-858b-218924986f45");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "87e45cad-7880-49af-94ab-35933fefd499");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "2fa486b3-f447-47fc-8147-5976e72dd806");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "636e9da9-5f96-4abf-92e5-b4fa61dfe31e");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "3cda4306-6f32-429a-8a5e-fc2391038aa6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "22a4111f-2860-47d1-97b2-34446e1492a5");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "d3b3b514-e8ff-43d4-9e22-a468a52e2ea2");

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 4,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 5,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 6,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 7,
                columns: new[] { "NameEnglish", "ShortNameEnglish" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "76eda17d-cc54-4b57-891c-81d7aa25f729");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "14f362f1-2abe-4996-83a3-030fd4ecbcee");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "f97fbcf7-e0ee-4ee1-a8de-efd9314efb9a");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "596e4e21-0df8-436b-87ef-8f60bd26ff5d");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "fcd486ec-0768-40c2-a587-98d01696b84f", null });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "9cdbacb6-1d85-495c-95f7-6555d43310c4", null });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "49bf0464-9cff-4a36-b6b3-5e604b4103e3", null });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                columns: new[] { "DocumentTypeGuid", "InitialsEnglish" },
                values: new object[] { "77defd5b-d971-4a50-980f-60ea8600ab4f", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "b07fb4a2-455f-4731-b75d-5f2094bde764", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "20a83484-be34-48b0-b903-93f52b9cf5ca", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "b3384a48-8d22-4883-8bb3-4fb3ca0e3577", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "7b3f8404-8e93-48e2-a720-91a33f4044aa", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "e32a7f80-43aa-4185-9251-520cf792be4b", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "07de9b04-ba53-4d9d-b3eb-d58c7a9ab8cf", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "6e815f45-849b-4258-8efd-829e12f5010e", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "4806a94d-882d-44f1-a912-c2620caf7aa1", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "c813d775-3747-4eef-8404-a0b1bdb86c1b", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "3ebc3d73-7a3c-4d59-83d2-e35ecfa56fd0", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "b5b6b8d6-9133-4fa7-ae9d-dc09509a1528", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "58bef8e9-3b6b-4da9-a327-851d55d0214a", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "5d981c26-4d98-476c-a681-d06b6e488588", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "d6457e6f-8bfd-42ef-a91c-0f60313721e4", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "746924f3-be94-48ed-8a51-0640383f67bd", null });

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                columns: new[] { "EquivalentPositionGuid", "NameEnglish" },
                values: new object[] { "053c158f-1f7f-43e3-9b4b-439bb31a0a2a", null });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "d9cbfafd-4b5f-4844-b886-2030b389fcda", null });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "538ffa6d-6922-4976-816b-8afe3ceca037", null });

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                columns: new[] { "GenderGuid", "NameEnglish" },
                values: new object[] { "54fb9748-93e3-4d64-9f35-9a3d35e89e5c", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "e4533a7c-95eb-4e38-ba2d-c68e74973d1f", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "d525ce5f-6968-4993-a518-10b08bd31803", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "fcf67e42-42b2-4290-a0bc-da89a33ee18e", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "b1ab3d52-ad52-47ee-986c-d046fa8821d6", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "667aba71-78f3-4fd7-b9ca-ac456b9c74fd", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "42e2ffd1-69d0-41a5-bf38-c8c8d1e1a031", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "b9c62382-6cbb-49b7-9a51-6cd43e3ae29a", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "74b38b9c-d97f-415e-a94e-d61441c4ec63", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "6092b7bc-7f91-4eff-bea5-198fb2ec0a8a", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "3665b456-c258-4e7b-b15f-7c29453ebb15", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "6dde3196-d790-4566-bfac-d28889e695a0", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "d2707ac6-72f4-443c-9190-bb76a1784604", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "2a6c75cd-2a41-4128-adf3-4356a70733a8", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "9d97f8f3-0b53-4a8f-a36e-b22ffde4cc97", null });

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                columns: new[] { "IndustryGuid", "NameEnglish" },
                values: new object[] { "d19c808e-48ff-4d60-90cf-e7d0aab58541", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "8c0db2c2-f5eb-4664-b43c-597a9ea63dad", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "340eb628-c912-4e48-9806-5152e41f64ea", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "6d236dd4-016f-4bfd-986f-a5411a53bfea", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "9a9a9253-81c8-4cf8-8ee9-f36596bc5dfd", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "6d407c01-e117-4712-a57f-f41a695f1d82", null });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                columns: new[] { "LanguageGuid", "LanguageNameEnglish" },
                values: new object[] { "6dc62ffb-a096-4809-a040-87d7b0a11573", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "2c528c89-75af-4daf-9d91-86190dd0a2d9", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "0cd86e4d-c34e-4d3e-890b-58133a64e901", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "1db7a91d-2ea6-4540-bbcb-66db09e0f0b3", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "a55167f5-06ea-4ac9-a3c2-d43681a08339", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "77424e65-21af-49ae-87b9-c8e796aaee78", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "b6878761-0451-46b7-b78a-42157578e385", null });

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                columns: new[] { "LanguageLevelGuid", "LanguageLevelNameEnglish" },
                values: new object[] { "2887ba94-4f94-434d-ab75-4e148dc7b261", null });

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "95669b1a-56c8-4c7f-804d-a7784abf5ad9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "00288ba1-8bbd-4dfd-8dd3-69ee76f9257b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "3cdfae44-f85e-4191-bc5a-490bb1059ae6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "fb557f48-6cd6-4464-be4a-5ae9451a72ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "0668e636-de1e-4e1f-a329-5e845e6b4f07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "d0ddfd4b-a286-4aa9-a743-c82d44331614");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "69c46b92-dbdc-4f20-85b6-ce4288c61cd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "9952d6c0-3391-4868-aef6-e54052bb1c5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "e2e16ed2-8afd-42cf-9e72-8994c26b6ac8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "f0aa1291-5066-4d0f-82e1-235e8b23d4fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "f7a99dae-2deb-437f-927b-180e93ea4dcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "d5809f3c-256a-42a5-bb5e-e7204f11d70d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "00dab55b-ba92-4249-9019-8b0dd6ed3b8b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "1e0a0124-aad0-479a-a217-6e840aae543b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "460da968-4765-4f28-9858-40f7c7ad6b33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "01ad2c02-d559-4940-a4b1-2e71b985c470");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "b9355bb2-e787-48b7-a859-b5833a718396");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "203946c7-8d58-478c-bac7-c217068d1021");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "e153f43e-5b77-4c62-a191-f3cd2020a09e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "c05c0e61-02e4-44c1-a4e2-c35dc182552d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "53bc5d82-13ad-4f45-9827-c0349c143629");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "792483df-2e0a-4afd-851a-c8af76330986");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "9e7d1991-bcd9-40d4-a574-479bf7071e89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "a5ac597b-6afe-4379-9e29-598ef9506317");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "5886f7d8-65a9-42b4-9172-7f0aaf02721b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "2a48553c-a468-4a09-ac2e-04a10a8581a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "ee9f3014-1985-4311-a049-71e831f57326");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "98a92ba2-491b-4e5e-9999-16c9c7b00455");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "7b348ed6-1e76-4af2-b52c-eb23b60f8df1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "796ef7f0-f57b-4368-8a1d-60efdd771a31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "35a9734b-2b85-4bce-acd6-be2be52a0145");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "2eece453-4af0-4b5e-b55d-2d3526cd01be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "3347d6aa-2b82-4f62-b362-ba0108a2238b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "2cf6f60f-8cf8-4503-b4a3-d771174aeeda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "0a9d7ecc-1b8d-454a-b344-85caf47f33b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "431b5175-5fb9-4fd8-b5c3-eea629f59857");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "c0da1cfe-767b-48d3-a1cd-bc7583d1e6f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "6342a842-f37b-4f8c-b7f0-182e3805b003");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "52b63dd9-abd2-464e-a8df-cdf3c8a3862b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "230fceef-65f2-4530-bfc1-309d2d94efa3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "3b1ade05-eded-4eb9-807f-a9d3c5cf907a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "0e049daf-6088-4a06-b736-724a9e098f77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "cb41cd26-0b45-4552-b859-5f11a2834e3d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "73c37cc7-8568-41e7-aac9-d40bae0ee561");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "fc0797b2-8421-451b-af2b-9bf806d56c11");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "790add4d-55b4-4f76-ae80-3b463b3eae30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "5957c282-0849-469d-ba87-785e2ca7fe58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "0d557016-bfaa-401c-a22c-e7ae1f233cc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "cfc9c701-89bd-42a1-a521-3bbd73aade94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "f5d214f2-dcad-44b1-a25c-12b7c7160877");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "3fd869a7-66ab-4351-b5d0-cb9bfa30fcc3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "e7348bd0-0841-404a-971e-7a2b1a6d037f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "0d870c1e-7416-4b61-b801-8e932bb939bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "9c7e868b-6518-4d5b-b1ed-c276ae4fd1dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "b67287c4-5bda-4029-845e-d687767a5e57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "2fd1f9cb-4377-4b8f-867e-ff3794ba99b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "b2fb4e26-da5a-4155-a653-d339e354cd58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "36d18420-5295-4243-ace5-34fd94850ecf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "f55cac4e-7db5-4eec-b410-41bf06672b6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "f3606d11-da7c-4834-9fd1-9dae9a2b8160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "b7363fcd-1dee-4908-8f6b-8a0f9e772c2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "650a3233-1383-4e71-87e0-28254dadf32a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "723efb0e-9275-4b8f-b656-4834f91a20e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "7c3f2839-77e3-4135-8c27-96955119df47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "e511f88b-a506-4eae-a094-a4b5c4969334");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "a8f52bb2-46e5-4305-ae4c-c5e23646ed91");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "b56b62c5-b7d4-45b6-a294-d0efc44d715d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "6c5b6c12-e2cd-4a18-83d6-688d7e4041b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "65bf402c-50c7-4d5b-bfc3-0641da094a8d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "83b055b5-f3cb-4f98-ab7c-d9a1cbc619a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "c943d57a-2e32-4527-b770-2bee284d9d10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "a86003e1-3706-4c5b-b96b-b8932b3b62ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "19ecea49-cb0a-4799-ae34-b63022a92466");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "dfe51ae5-b901-4a88-a5af-b91fb3b74763");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "c6816ded-eb9a-4e3c-9ebb-646391d12f36");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "23c86af4-31f6-4fe4-a847-5fa829321595");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "bee9f773-2ce4-49b0-8e04-02b2efa1c3cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "5f038df6-1b94-4855-b1a4-1d0a06885e41");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "1128c4f9-810b-4ea1-bf01-2d6a7c648ac3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "3c26868e-7681-47b6-be1c-1b054f574412");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "217213d1-5e8f-4eb9-b1ce-09c6910cadac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "8ba0596b-424f-44f5-93d0-cae2c8bb8112");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "ad92d689-5711-41f7-a4a2-85ef8b618ba7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "8edc32b0-a981-4f49-b8a9-4403479c620e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "085fb4a6-3f34-439e-b054-f1869fa5b041");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "987ab5be-cd21-4ef8-98eb-d24ad6e33f2f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "c0d3c584-448e-4de3-acb2-680c60db8619");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "2a3381a2-62a4-4264-8818-95029efb4c73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "93c504dc-2653-4ec0-a5ac-b19b50c8d567");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "1c539184-57b4-4239-a5b0-10e5c0da595b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "bd9837ca-71fa-472c-a6c2-e9f9fd3c40e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "9fd23b21-7a14-4850-848a-81f0be0f6f6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "3f2bdf11-6256-4de4-870d-6a232245d7b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "deb6f390-a5b8-48a9-b77c-968eb6322424");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "265e22c3-2110-49c6-87e2-b6ceed76baf0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "68e5f9f6-9ef4-48ae-8c9c-4aeeb6b7bcaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "96991b35-2afe-4f83-81d3-1394ed3434f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "9d1a3642-9ea9-4696-a38d-7d1ba4353492");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "8423388f-28fb-4311-b0c8-c1c437a7fcc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "e743ca6c-56a1-4990-8604-d64792f1e316");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "f1cb9166-5671-4935-982a-221f5e4fa87b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "8a0cd941-5a2e-4312-807f-f687c16a71f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "c5a545fb-d4d8-4f18-a1c7-ed5bebd843e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "6832d4de-5d6f-4f0e-b145-a80036f23ac3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "9088dfe2-6dbe-4f35-b5ca-941e35b42052");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "8f1fb99c-f6a1-43dc-b40e-0e8734c168c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "5b3050e6-672d-44f7-b25c-86f215e94cec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "8b86a6e3-4f67-45ab-8d12-fe7a2403a5e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "8f842bf8-f935-45f0-9be7-13fdf4f60c68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "d1c8d206-2731-4fc3-84ba-d252118d9d15");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "b1ab144f-3b08-4b55-b142-73d3f077d732");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "3ed582d1-9b7c-4b07-a41c-edfcefda14af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "16994c4a-dc53-40c7-af74-4f01bf024c58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "eb097fae-70ac-4d8a-9b3b-e1426ad5046f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "b4d08bb2-b4c2-4819-a725-5f16859442d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "f4b56fbd-95e1-406e-85d1-653a4a4d491e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "0e76b42f-5da0-49e0-a497-9a21da979ee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "18437c14-cb4a-487a-8695-2cafffec7249");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "22593d74-86e6-4f17-b4f7-b66c31515256");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "4013093e-55b1-4717-a37c-079b338b9a4d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "e370fe83-f3d4-40b8-8a7e-752b5de54978");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "07eee08b-31bd-4540-be28-d3d4f5186316");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "eaffc71b-876a-427b-b125-5555ab4af97a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "2396a766-ef18-488b-8b3c-e0cd41e5ba53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "a9e532fc-742c-4156-8bd5-af4ccc971b35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "419e1b72-41ec-481d-a9b4-c1236c37d803");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "30b579b0-6c91-4644-8b8e-84f887c93ef0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "49ea6ed9-d867-42da-83ea-bf02c3344b56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "bce830ee-04cf-477f-9fb1-910db7184315");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "576ef496-f8b7-4dc2-abfe-2ebc5a0af936");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "96e0dfdf-a38a-4d83-bbec-44086537e11c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "b43a645d-a5db-4c58-9af6-4c02ca5a2113");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "d5cdfda4-cf54-4ea1-86b5-2171b7ddc3e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "385c32b5-eb87-4113-81e0-e7701a06b2cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "d4218fa7-25e8-468a-a71e-cdb7da67da57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "3f843eb3-7e84-4e84-8694-03bb162ea1a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "87ae4e86-d1f4-4680-ad47-a02705cd9ba1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "5c56ef28-5674-4dfb-a985-831dbe189b61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "f8eb4374-542c-436f-9f91-346d79be303e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "5b24a0ef-2e33-4d43-8b20-c1e46b1d6d0c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "0d3258bc-9097-4b05-b5a7-b1039d4477ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "63094166-0ea0-4d7d-a3b5-7fdc858f36f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "70e375c2-4e37-4795-9389-def0ac6c05e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "ca7fa473-1748-43ed-a99f-13dc5fd5482a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "43fd863a-b495-42db-9d78-bf890049f3ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "db75e314-f9fe-4271-85b8-0ee069d9a721");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "1d4664db-e5ac-44ab-847b-84737e92c792");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "13d592bf-911d-45ce-a231-510e1b12ec55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "aff10780-68b5-4d96-b44e-f3d17b73b78e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "edc3f48d-a24f-4f8c-bace-7b434e24024f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "8b7fed67-2e98-4293-9850-c2b846480bae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "581a83c6-e8e9-4780-9f97-b0f19a302222");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "10744051-b1f8-440d-9669-fc7a2792038a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "634b5c8d-d4e5-4bed-b0fc-8d6b4a4247a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "0d12047c-fb66-445c-8a7f-2cf0cfe060c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "def3e2ca-b5ae-4861-bba0-9aa0c407651a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "f74923ad-4384-4c50-a87b-e2e25fb08848");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "e08a6c29-5b05-4c23-8342-6ca2e9bfbbf3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "8a9536d4-8fa6-4e2c-b291-b090d0a12710");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "52ae4912-4fbf-487a-9f17-042d22ff9aa7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "b2391582-e7d2-435c-b4f4-7a0a6ae01ef6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "a7a67dae-7bb4-49ac-9161-1f2ee1d69f61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "ff80e9f3-af16-4171-82fb-ed5126f8e671");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "71837e47-2faa-470c-9d51-2bddc61e1e33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "81d8220f-5bec-4965-aeb9-8942192535b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "87c574e7-04a2-49a4-82f3-60df7774592c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "fb98bce7-9c08-40e4-8a59-d1b34c1d3176");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "d376f21a-f966-44f2-9812-1e43d932f029");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "0d1391cd-2489-426a-867d-61efa0244986");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "72c41ac1-da25-49ab-b136-bec6ca9732b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "49b000a5-9003-4138-8e68-9713455ce80d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "c40f982d-fd17-4ff0-95e9-418cef70a9f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "8b5be346-cb1b-4729-933c-2a6eaabb05c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "f8f7f11f-042a-4f6d-b737-e8f20472bcde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "e970e73c-7623-4e75-a24f-8409dbb3920a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "c14187b9-51ba-4aea-8ace-22077eb84111");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "5a935fc7-216d-4e08-aae8-15620ba474ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "5a7c05c4-0082-40ae-a455-fbb60c8a1059");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "9f1f85f6-8eff-4e66-a08a-09829597d2e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "92ade2da-6622-42f2-9fa9-90a01bee4c08");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "5070cf2f-5073-4b42-a66b-03aae05e0262");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "6648a629-6fc1-477d-af51-65872bc2129e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "c629b60e-96b1-4195-aa1c-3aa04340eb73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "12a1cee3-e9cc-4600-b732-b078673e32d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "4d1e8f78-7b5d-470d-be89-d2cd55b62c44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "e8b98cb6-fad2-4fe1-85f9-24e9ac28e949");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "057f8d27-f670-4a0f-aeef-14b9fd34035d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "412cab44-4860-470f-beca-bc7bb46a7e73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "83fedc9c-c49b-4546-a3b7-f2587aafdb17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "423f6005-c63e-44d8-9959-35fd7bda0c7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "6aaa0d90-210e-4d2b-8710-96a11f75e260");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "ef2676e8-8eb7-4e31-89a7-630c42848b25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "3e98acf9-22e6-4e44-af3a-b33b1f627d8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "cf789642-cfe4-4d62-bd20-7fcafdf5b77e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "2ebc7583-343c-449c-80aa-a5531284672d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "8cf0e13b-71fb-4add-9ff6-62e0e8bad9dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "ff4319d4-153e-4e97-9686-7278f250d690");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "1a8c1d70-6f3c-4acd-82cb-00474b31e015");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "591b5484-b8bd-4269-aabf-5447eb696ba7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "c252ab8b-083e-4f01-b1cf-0745ca5e8a50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "fc2c61cd-613f-4884-922a-08a09a5b3547");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "7fd758db-5947-4472-b302-533f21eed15f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "20c48853-8a10-409c-b500-143eb203b289");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "23b1a4f9-5ab6-409f-b5e2-f9fd82b7c3a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "f162374a-5d19-478b-aae5-df022af2008f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "790c1c99-6c8e-43e4-943b-f4de9b9d91d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "282215c4-2d95-482d-b414-5bf58875a979");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "5ab34912-1b6a-409e-bf0f-16f0f6783bc9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "3bf7b2ec-7db7-4ec0-bfab-2f7f6b8f4faf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "b036354c-5908-4fcc-b5a0-b46f5fa03b46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "cd353a83-a2b8-46a0-858d-a088bdf66104");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "00728547-7d11-4329-978c-ee7b1f954ada");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "4bb7242f-e569-405f-9dc3-c6c550a0c9b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "06c16a60-fb5f-4448-8cff-e49646e48dc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "224829c4-3fea-41ef-bdb0-fe79fad91f1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "a8500ad7-26d9-4e2e-bad6-3c01dccab8f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "749836df-29fa-4dfd-a6ad-9d59e050a504");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "6d7ef483-1fcf-44bf-8e98-34e6b5edacc2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "56b1746a-36b1-4f61-9416-1a1e7ee1fb63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "654e584d-c7a2-4cc5-87a3-0229eda8fe25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "9d4368e6-3a15-45f7-8b50-e799ef3ea1b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "c5ccff2f-7c45-4581-95f5-2700e61e05ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "a55d5747-213c-465b-986c-9c7e4e3f96e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "cef60a3d-113b-45f6-8231-0bde60a63a56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "50bba997-388e-4ab8-a323-9f1afd8389f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "0803be37-125f-40aa-9c33-54d9ff1687c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "65717974-6010-4dc9-b91b-11364442c967");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "f4abec86-0985-4424-af5b-97e998846140");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "ce29d3b2-cc27-41ea-990e-00fa5708b373");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "ee6713a0-c192-40c9-9bfa-703d1343ccfd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "1706d7fb-8c11-4e3a-8573-24ae6d0ef7b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "b2f97c52-3ae6-4026-aa5a-cb661eff01a6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "9852fe4f-4cbd-40a8-8985-7b4dab6d4bc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "05db3466-628d-4e1e-9bc2-f0679e0fc717");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "a5319fb5-c06e-4226-8ac7-c3a4172bf3c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "9acf4e40-79f0-4925-b506-2b9e4173e2ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "b433b522-974a-4cdc-acd7-aaebb4dd670e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "fef56df6-c750-4aa9-92ea-11e829b63c31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "43f32fab-7eb8-4d99-b386-a8dbb35368a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "0cb4d155-3569-408b-88da-aa8345875838");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "f0a465e3-1c6d-4a09-89a2-38fcb6c809df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "df22d411-ddb0-498f-b37f-d622d0824a7b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "5402fc11-68f2-4e08-bd73-0aa641d1647b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "9e1f87c9-283c-41e6-995e-873a90209bfc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "3f819950-b160-41f7-a3b8-417cfc96ea2c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "69f5cb08-665a-4cda-8884-9df5ddb7d33f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "b8d7cfb5-b726-4416-afdd-4e1861ffedfc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "ea3964fa-1baa-41f0-9090-f8e1424b43d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "b5ce8594-d2c6-4ffb-8cf4-88afb62a968e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "29dd0597-c9a8-4593-bf10-6fc0dc03bbc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "88504943-16dd-4cc4-a4dd-09bab7abfbd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "244625a8-1d51-4196-8038-19461a24c701");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "df0de620-bd8e-4358-9fa3-569a7adb2b65");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "517daa82-2e8d-470b-a615-998245d7e8b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "7138f15b-ed0f-4ed1-99e3-877b5f12b60c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "436e1c51-7da2-4482-ad72-5c308bd98e7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "be29eadf-7817-4f61-8be8-f5b01f011e54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "7f9924f2-2de1-447b-8231-e1caa105c006");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "48eed767-f83b-40b0-8be8-4cba60392f55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "7415fda8-e6b8-4200-9b29-8f4423dc575f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "f95d1620-9277-4889-9603-0c3328503879");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "22589c44-aadc-4625-a8f0-6d3690a893b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "e667896a-0ff9-4f5e-8292-a0ec1e6fd8ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "6bf8250f-1bb9-4dfc-8e06-33cf1d76bec6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "bbeee182-189f-4322-864f-6817915fe56b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "06b87fc4-27c2-4cb5-b775-037e03d95386");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "20f5731a-42ae-4140-814e-e01316dd92b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "83cd591e-c92e-4b04-8345-570669584db1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "ba0323ba-028e-4f89-823c-be89197f3c35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "4f23c560-e17e-4656-aba9-0797f4a442d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "40aacf4c-53df-4390-b8e4-ac92ab28a7a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "f95723cd-68a5-48ed-860e-4ac03e0edebc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "2e8a77ce-3d66-4073-acca-17232a86fb35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "e7f7e33e-8402-483e-a853-6a5f59843602");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "214d1a92-fb1a-416a-abad-9ce11eb4fe43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "a508402c-3e1f-4f6c-9b36-2122df7d35d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "cbf81917-1314-473d-a2f7-dfd56e87f0e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "4222b6a0-c792-4b47-b7fe-6464b8854d29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "d670477e-1b26-43f8-9e60-4cf68e2709f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "cf8c425a-2f50-4273-bd22-c0b89a0efcd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "e9265b9b-26d6-4702-9655-fa9909b6137d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "8caba10a-0dc8-47b5-9c6d-d3f6051c4c21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "dc154f59-4a0d-42e6-9703-80cc14584f2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "0ec276ee-ec33-4027-9c37-3e5f7bbc5e6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "c405c236-00c2-4d49-b877-32ce08a506f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "84e4591e-bf73-4186-a2d8-3ff60b9fbb59");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "bba85868-a36c-4fa1-b343-915d85592dd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "23901816-476e-491e-a183-4579bd3df529");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "a6ba4e56-3bf2-45f8-982b-91a5f373065d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "3b352634-c7e5-475d-8f6a-8d1bf19bb9c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "940c30bf-2d37-46c6-b605-6680a1f49711");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "0bf41200-4dff-451c-93bd-9a0e1aa5e2bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "2f2c21ca-8199-4ba4-9f36-57b1b6df874f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "bbd41faa-10d0-47a9-b58f-3b169c29e895");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "9fef9942-1e8c-4cfa-9514-fe13dee9818e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "d88ef343-b569-4bd3-8823-7835b970aa29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "3a63e557-75cc-4079-8694-9263c89fedf4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "959fa4fb-bfad-48ff-9502-55a0eb527f6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "39161135-f3da-4169-918a-c44e1a27292f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "db32883f-3b51-4aa7-99fc-1c695be8db17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "6c9f7153-12dd-43b2-ad09-3d03b2767b04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "4c5100c9-1291-434d-b966-f26f616bf006");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "67fffbbc-d6b1-4c1a-b14e-a03a4a18af28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "eaec4db3-3082-4696-b03c-d18764e1b738");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "97c77cd4-ca26-4dc4-9ae1-54b8c13b21c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "44c9c6d0-4ef9-45cf-bbed-58f872639f5b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "5125f1bf-8daf-4ddc-9440-3df28d138446");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "644195fd-f9f2-4863-b38b-d9896316b33b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "5836f7ec-3e9a-4115-b3b1-b71c6361b385");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "cdfd12eb-236b-450b-938f-0f5c2d8df7c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "c714ff92-d6f2-4ae9-83c9-9b2d2ece2953");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "080131cb-01dd-4df3-afd7-2717465a1553");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "6938af69-fbe0-4b0d-8581-e2b44ab8ddeb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "bf82651e-2ba0-4ece-9652-0c54c660c0f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "9d641a4b-3e05-400c-8e08-c9892298e31c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "e87eca7d-8797-4505-8072-f768a4e19216");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "16be60eb-0b70-44e4-8220-c1290c16ac7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "c5b85220-7f35-4b4e-9d31-4b8112313e67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "6f1f5c53-5394-466c-8e8f-de82e4a150a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "d4be5641-4a5b-4a8a-bd9c-d76d8fbdc59d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "5e949052-ba1e-44db-a889-784ce694302d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "fd874119-1169-4980-a578-4eb3ddafa703");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "5f51085f-aa89-441c-ad86-22ee900cfd81");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "0095f199-0a1e-4525-951a-3c67ce839619");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "dbb7894a-f2ac-40fe-b3eb-fe471a13d342");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "3caabc17-986f-4076-9859-3009aca13c48");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "9b50c0f1-0f22-48df-b19e-63ad78c1f82e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "4c79a48c-b83b-4ed2-badf-47669e831a17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "87c1deb7-3735-4012-9a01-c9c81c9b2beb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "7b386cec-323a-46e4-82ef-9fc2bb2d0b62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "05be222c-8898-4dd3-bdc3-9f0d90d7a8b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "1cded683-5bb9-4d45-a704-db3a1aa0ac5a");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "de03a99b-db65-4235-976a-a08509ea62f5", null });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "fc971800-fc14-4282-bcb7-af4a4c5a73a0", null });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "4860e976-e9ce-45a9-9bbc-c3ef3937755b", null });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "d892fb0f-a9ee-4658-bb87-9e5de7382580", null });

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                columns: new[] { "MaritalStatusGuid", "NameEnglish" },
                values: new object[] { "0660b48d-d7c6-4cb2-a96a-db5ab490b874", null });

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "0db42f10-7acd-48e8-b143-7186e48ec170");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "b814c4fc-8ecc-4d6a-ab5a-484cc6a8f321");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "836cd4b9-29bf-4656-9cf0-d1d33c84127b");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "37c0a485-8ade-47a5-8987-a1d8a38d29d6");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "274174ed-a092-45e6-ab24-204303a675d6", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "2cbdeb65-0132-489a-9a9c-131eb4890ba9", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "d34c683c-d34d-42cf-b938-75d232ce9b56", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ae4839db-1e66-49de-b0ae-68e84cc8581c", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "bcc29453-2027-48b1-9c59-5d9d7eada90f", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "370e4e2f-27c6-48bc-bddd-59390149df36", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "013c0c5d-5882-48ef-9ca4-a7c6b547fcd4", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "e5b3c2cd-e45a-40d7-9729-47d199f50982", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "058f62d6-e80e-4d5d-bd7a-77ec2a9b5f22", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "56f14395-af35-457d-872f-4d3796c5bad5", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "e7b42eb2-56c2-4b8c-b71d-90e7f414c677", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "64ce5ca5-eba2-427a-bd60-9a49ba907937", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "37794dc6-cbec-484e-a3bb-d7028bc23a26", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "6988494b-8f90-475f-b8f8-535b84e3b303", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ed42e7f1-cead-4291-9a9b-add3d63868e6", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ca9efbbb-d627-4218-9db7-a79a99d117ff", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "70721306-4ab1-4c99-bba0-456e40c209c8", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "37f24aa0-82a3-41e4-8fc3-d3bfc70ab5e3", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "94f5606d-afe8-4988-9b0e-e8d5d5d27d80", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "fc19facb-7d64-44d5-8263-acbe6a4d1dff", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "20d208e9-fc38-4bd9-9f0a-38b2fe6a6116", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "3bd700da-816f-4260-9a35-9590e4e91d48", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "ae2fe5d4-4484-4377-a858-8db618d5fe1d", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "413239a8-38cc-4ea6-a0b2-02b27661dd94", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "04b953ae-5a27-428f-a09a-a5c29cb19ef6", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "e4e1f3ae-cef5-4b8f-984f-ae7af0c715f8", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "5cd94bda-9a45-430d-9319-364997ecdcd9", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "40185586-511a-4ad1-b219-7648095819bd", null });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                columns: new[] { "SoftSkillGuid", "SoftSkillNameEnglish" },
                values: new object[] { "4ad0e5d2-b642-4977-b054-62fc22a4935e", null });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "abb65257-97f2-4f96-8f0c-e6262c83b27e");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "9fe189c9-5824-4b71-9e4c-e923a0479a78");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "9df071ad-011c-4f3d-b9e9-f0e774b9c9f1");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "339b0044-feda-4dc6-a2f5-e95ef0ceab18");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "e3447689-e11d-4333-a740-673a29a39a68");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "719f4ca5-592e-4bdc-8688-c22775147bba");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "8da19d6d-9c17-4a33-b9c5-5b32615ebf80");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "9274050c-70e6-47b5-8f69-692a5fe34933");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "51ec4c11-815e-494c-8fba-6df81673d2b3");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "cebd94e1-28e8-4ea2-80ee-a9bc99ad6ba5");

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 1,
                column: "NameEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 2,
                column: "NameEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 3,
                column: "NameEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudyState",
                keyColumn: "StudyStateId",
                keyValue: 4,
                column: "NameEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "8978cbc7-b6e2-4641-9f60-38c12a017cab");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "640f68b0-82dd-4bd6-98c8-cee2a2b518f7");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "b23f5bb7-0f67-483d-af01-5628b663b1e7");

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 1,
                column: "LevelEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 2,
                column: "LevelEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilityLevel",
                keyColumn: "TechnicalAbilityLevelId",
                keyValue: 3,
                column: "LevelEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 1,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 2,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 3,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 4,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 5,
                columns: new[] { "Sector", "SectorEnglish" },
                values: new object[] { "Consultorías-asesorías", null });

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 6,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 7,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 8,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 9,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 10,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 11,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 12,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TechnicalAbilitySector",
                keyColumn: "TechnicalAbilitySectorId",
                keyValue: 13,
                column: "SectorEnglish",
                value: null);

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "8ad08eca-86b9-4f5a-9f42-dbbdbb03b34a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "632f770c-2d13-4ab5-a32d-ecbdf52b89b9");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "82a635a6-ab67-488e-90dd-783d41cbd968");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "6a4c8fbf-0cf9-4f38-ba05-07b41cbb445b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "f3aaffb8-b48e-42d8-9558-577551a19e4e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "dcffb08d-ff72-41f0-8c85-e9816a575666");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "6c0ed887-1703-4c46-9aaf-ee204db79e61");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "6bae9969-cb4a-443c-aabe-7113b03a677c");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "4d18518e-93e5-49c4-bd10-ede18ae91cce");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "9bb8bfae-ec53-4069-8ed1-36639ed397a1");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "5cd12cf4-6737-4887-b095-5fc89a3dea0c");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "2cb5903e-439a-45c9-a792-46388adb4b30");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "c3f3771f-103a-4f8b-a3ec-a491314181e5");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "b821d3f1-5f96-4e26-92bd-b7d5ffd58c46");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "5b9d07f3-16d1-41ce-80ff-ecfd93a1c489");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "a6ed6185-a01c-404f-8532-3b9469418b00");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "abe064b7-2179-4dab-88bb-741a1d3a070e");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "888a8cce-3a28-4a63-b33d-25d19b119197");
        }
    }
}
