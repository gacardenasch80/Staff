using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesMS.Migrations
{
    public partial class EnglishColuimns3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                columns: new[] { "CertificationStateGuid", "NameEnglish" },
                values: new object[] { "08195b6a-b35e-4650-9a2b-3cb84ebd16b4", "To certify" });

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                columns: new[] { "CertificationStateGuid", "NameEnglish" },
                values: new object[] { "b51aafd2-d0c9-48af-92fb-590b17588c27", "Certified" });

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "339fc587-8bb1-4a77-b7c9-4b460858801f");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "7263d9fd-bb24-45ae-968f-d0934772a697");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "ff60c62a-9195-4404-9c35-5d2441ebaeac");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "59731fe3-c10d-432b-916e-405c78b64490");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "c5b1040f-48ce-45dd-9ed9-a26a4d0a91dd");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "a9c6e5f3-94b6-4c52-b4ea-8596d38a68a7");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "cb94cf7a-eb8c-41e2-a131-ae245f79a780");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "7c256637-3c5d-4ff7-895b-3f56cb8a06ac");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "1a87e12d-3346-421d-b212-355af5e88f50");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "92d95cc4-1367-4dcb-827e-f38be3c86b12");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "77493e6c-3dc9-487e-b606-e50074e24296");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "509592e4-5bef-43d3-8262-b88cbb348189");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "2f76c336-7251-4f14-9070-eb9a74d0facf");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "544be6e1-a2e5-42e7-9517-889bc89735d8");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "deceef51-4bc3-4917-9874-5999d40f1c9a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "5a896a27-c31f-4604-bbac-cde2d471748c");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "9623fa51-c3ac-4ae1-8e0d-4e8df152e168");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "8c2fc0b9-433f-4f2f-85e9-b1c6b877d10d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "d05c4054-b395-46c9-b156-929edec519e9");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "1566c4eb-ee68-4a1e-983b-6c4705b61e89");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "8d9b4b28-088c-46d3-8ce0-ec97df432372");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "f3222ad9-96d7-461f-8530-88b3f1f98ecf");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "a3b7d675-69c3-428f-9785-36d600a4bb65");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "743b5ebc-df72-47c8-b3b9-d11d6a70b1b7");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "be8beb84-f720-4dde-a95c-cbd7c55c360e");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "d0599c68-e26d-4557-9185-eaa58f8982f9");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "388d93fb-e67b-4ea9-9993-46bc72d84c78");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "52dc7d42-9bb1-4d9b-8cc7-a5485eacb343");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "da9634b8-19f2-45e1-846d-039c6347bba8");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "2e73a060-f61e-42d7-b5ec-5ad32e193b65");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "44e061fa-2229-499d-bc21-e7395181a9dd");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "b1628a4a-9308-4f10-862a-57e67df51048");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "3c817770-e969-4336-a76e-a0e29f230efb");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "02af45b1-f27d-487e-8cc6-0270670f278a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "69bd0bce-9f2a-4900-95ea-d98cb07f7ff1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "ab896a82-b37e-4bed-b72a-7f3d8f406164");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "48e71c4a-341f-4c4c-ba5a-45504f09ec98");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "d013d69c-9ec1-4c98-ab18-1eb49f03d1ad");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "fc0171e4-51e8-4d2b-9cdf-de1717213742");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "1ff1ad12-a698-4476-818f-60e4f649f65a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "e8ad8549-22a3-4349-89dd-847cb6fbf219");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "4754e9cf-ad04-4224-b58a-f7cccf8fced3");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "3427b3d5-2739-43ac-ad0d-356197a4e599");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "4815a54d-5f44-446a-ad74-d28c2325cf6b");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "16ccf6ef-fec3-4f42-b839-11f58c592754");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "8bc76286-8996-4c21-9c70-06176b4fa088");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "6d0ebb04-fbf2-4c97-afde-6d320629e8e1");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "2d329013-edd9-4488-9b2c-49ef01ad9ed6");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "3f125d16-977c-41df-8bd9-8a9fd20b9b2e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "6ba78948-5b2a-4567-be21-dbaead5337b2");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "0850e0db-7b5a-4bc8-9376-ec5ff5a6495a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "9b12835d-858b-4039-9b47-ad4e146b78f1");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "82fb50f4-a925-490f-8edd-f29a4f0021f4");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "4342c406-502e-45ad-b991-6a917b8bf484");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "fe86be63-3538-4b3c-bfb3-46551d004b86");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "85e75579-2ce1-4fb6-9a96-6f9c7a6b018a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "5cc142fa-e1a5-4202-931d-aabd70ff0ec1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "4c5b2c57-6513-408f-9447-34aada80ea0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "c4491759-c032-4bbc-bdb5-ff9fd6cc60b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "de81ea1f-1ed3-4162-84a3-213e25861380");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "c6a37762-983f-46d9-8b44-08fe3f28e36f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "b5ae75fa-1924-4c07-9565-612525e91ff7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "c4d557f9-f405-4fe6-8878-6c41ff7d8c08");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "5292db15-8a5b-4c85-94c6-fda7414d3ee8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "84078efd-486e-434b-b483-f1fd19474302");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "f988b87a-45bf-4955-aae0-352b2cec4a42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "9610ad8a-90ce-475a-852f-cc86fc864559");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "42096453-84cf-47a6-891c-00adb99be463");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "abbc7786-be9e-492f-824b-7fbd794bc318");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "3385bd66-1a7a-497b-9d2c-58ce92998bdf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "949885cd-04b3-4f5f-b057-fc43e6f0d334");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "6091206d-0cdb-4fe1-9c6f-319839fb178e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "79ba118a-eba8-4b42-841a-6507625710fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "af03a476-f24d-4f8b-a8fb-147999dffc6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "5821ab19-c0ad-45bb-858a-0b07b1004875");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "857c8137-f8cd-4c57-8f2f-0155f7a0edae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "3a5c56af-50ec-4c98-92eb-c2feef19b26f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "766d2cfd-9d3c-4bf2-a038-90a58455ec9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "790ae1d0-6f2f-4e87-9f40-5a3bf89fc9a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "aa4c4dd1-639a-425f-87b1-be7cae1d7784");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "e81edfe6-2802-4ba8-bf3f-5b7d4c628327");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "a956eac0-4015-47c3-9628-8af9034ca336");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "285e453b-fe76-4a5e-b52c-58577f1d65af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "a381f8eb-8e02-451d-bdf0-834bd79c4fe1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "1ad6a116-8a60-4b2d-acad-3d35afef10f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "1be49f76-9b96-445a-850a-595403e146fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "1dba53ec-4747-4f40-a579-80a0ec54c355");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "ec8c73af-cd73-4daf-bce7-b80e3656b002");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "4a4deec9-b153-452f-b217-5bb6d9118bb1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "48cb6c4e-ad82-4453-beac-5b80c2ddee83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "a5ecef10-b7dd-4205-b589-cf5a13e5a4d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "b0fed56c-762d-4837-87a4-f598b51a55c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "0e8956be-1aa5-426d-9838-177f12e2b416");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "a60492af-d082-4fa1-8d18-ea780ac79060");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "55426493-495d-46bb-b64f-b85cf1518f0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "bf4fcf17-3a15-462f-8a7a-9d11ce4b604d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "a3c05985-c68a-410f-9c30-19ac25cc10e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "cdbff5e9-aab0-46ea-ba0b-576007503744");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "ec5eebae-f7f1-410b-81cb-d3e797906b23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "b3cd3a3c-3a12-4c4d-931c-e825494311de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "2bb6b58b-a089-4f86-8c6f-2c87948a65cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "5bf57f99-ee4f-4b11-91c5-0312fbe6cbd0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "32b51e2f-386a-42f1-9047-f2a67289a789");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "e2c7c904-91a5-49fa-9987-457c21a5a1ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "55a00548-09af-46d2-a3b6-19c2e1547685");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "564b5560-cd3d-4622-af5b-f8d63015ab7b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "761f224a-569c-4510-b893-64c82166c339");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "990bbd0c-1d81-4eda-a67a-46e2d40c3ffb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "82997408-3192-43a0-adec-fc06fe029370");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "5e392b34-428b-4161-8378-5cd9f8141c58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "a94e66e0-86ce-471a-ae8e-18d3a6c44d9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "7b5da633-1e41-4e52-b636-dfcf2f241c73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "dc3d2399-6a05-43ca-9cf3-d20ac45bf824");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "5eeb3ad3-a753-4422-b811-657f28be70ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "cf60d6f9-2815-4517-be3f-0054f1ee5d2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "8bc52703-5ed5-47d2-aa13-1b6b9ba2a0d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "6de3184b-34bd-437e-8ad9-4464a55ccdee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "37bd60b8-02a5-4a62-b1ff-b3057cf18eca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "d1cfca85-e807-4efa-b5ed-de531ef94912");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "47637317-c645-4c86-a386-2f2e32a89425");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "92f01a2e-0d96-4db1-b721-31d6ab25585c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "b4576ed4-a73d-4bf3-b273-0cbfab93331d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "97e06a0b-eeca-4024-baf8-2fdf63dd76a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "bd564056-90cf-4ef1-9d2c-dc14d36dd980");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "b3a6f0c0-fbf3-4c20-b7d4-6dea515d40b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "653bf42c-f443-498c-9feb-5f20ff3a20ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "773ec664-6aa4-47c7-808a-78a1dd245709");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "7dc5d9e1-da52-41bd-9657-b2a10cabf680");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "c5331eae-56ba-4ff8-93c3-7a73d4244d3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "883a8ad3-b339-4d8c-8848-43cf008187d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "340399dd-613b-4e54-83ac-f551ce715bd7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "b5fa57a0-2504-4fc9-8015-84ae579370ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "0125dee3-52a7-4513-b69c-1d50eeee0d6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "5367d345-38c0-4851-99a3-acf289591810");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "6245a1f2-b8de-4150-933b-029610c911f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "9c6b24f0-ff98-4256-b256-c2761b66b885");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "50407e3d-6a26-4b78-af9d-98dc26cf2b2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "4c11d333-da17-4980-888b-af0ec37c14d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "18579097-9d1e-425f-a64e-96d5e8a8a33b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "206bab36-3032-4030-947e-086e8ea450ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "bc595e86-935a-477c-ad75-00c03dee219d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "e84d3c62-7d5d-4066-839b-9a1b508c0308");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "199c0f2d-210e-49f7-be09-f8c3d0b8b497");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "4f30b092-aca2-4b6a-adf4-1578159050a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "31b0fd6c-8891-468c-9fb5-768268a30dcb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "23b99872-e7e5-4c5e-881a-a5e8ce50946a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "306f9491-c032-470d-a3ba-10950d6c01a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "bb8571c0-7a97-4da0-a4c9-72149c455488");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "348fcea8-251f-4d41-93f9-add889256eed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "57702e07-7e5c-4cf8-9f4c-3ffc10854353");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "0dee3436-03dd-4754-98ae-3d789be42039");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "b37dc0bb-f5b2-44c1-8fee-e8cf7e24d362");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "758d59d8-21ac-43f9-a850-8a5bf5b18b51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "bf072d19-92c0-41c3-97ed-2693b998e20b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "de6eb05b-4ff1-44d3-b0d8-4b47e4ec3988");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "e5ec9631-0b8e-4ff0-8c5a-737cd8833186");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "2e89692a-a910-470b-a780-9a3ef8660f10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "0007563d-b937-405a-b621-26d1cfeef20d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "1eebb599-c88d-4d9d-81bd-422493542f37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "abcfda44-42c0-4e09-a559-8342ec563bcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "f464cecf-0d0f-468c-90b6-9962e29011c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "827f36ad-0e20-4044-b555-52aecbb91edc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "bdebf91e-bd5f-4093-80dc-3f7a21411af0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "c9cf7b2a-22f9-4e3d-97e2-4daddfb2704f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "c61c2c60-145e-4e0a-9ade-f8fffdc1ddc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "2df7aee9-60fb-4bd0-bab0-d58369d38f92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "7a95f5d4-d680-4348-ad59-28ecfd66e3c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "dad22336-406d-4ea2-9b2a-8449ec3326b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "22c9db26-c17c-43b2-84e2-6b0ad143f46b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "33b2e98f-aac5-40da-b6ce-2e6915eb5ed5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "07cb4ffb-53f0-447b-a6f9-067bd94d9ef3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "adafb07c-4a39-4649-8097-0c71c65c10ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "b93241f2-db69-4b1c-90cd-66700a7cfd35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "093d3500-0782-4024-b087-6d3cf8160b6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "bc89d485-192d-4240-910a-abcca9185b38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "4ec424a7-94e0-4979-8c06-e587aa316dff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "b283213c-a1b1-4f28-8019-ae9937db4552");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "2e4d9400-49d0-4be1-a888-ddce38d30576");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "dd310055-0221-41ab-a27b-3608bbedd158");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "06bd2c93-e50b-4090-8558-7dbf216b9ee6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "6bce21c1-37ec-4e32-b495-cfeb91257dc1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "6e58a385-017b-4c69-9896-dade6883208c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "df726992-0042-42c5-bb76-81d6e2572782");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "ab213cc3-5d79-427b-87e4-16e552eb6dc4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "6146da64-8329-48f2-96f3-5a06855d1f10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "8b555406-1701-4f3c-b978-1d06fb8f3aa3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "6bb29af4-e0a9-4b84-8510-dfb4e6bf3ade");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "cdaccf12-0119-4ac4-8724-60a547ad4e5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "926bde97-0bf6-4b54-baf9-c8a7612fe88b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "43e01ceb-5360-427b-8550-b2d82cddd445");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "bbf05d9b-3612-4658-96ed-2b0bb48d8e3d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "10350b3d-4621-43fb-9b27-ae272f089551");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "f5dffd2d-a67a-494a-8637-78dbb3f27594");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "10193d0d-f5c8-4e08-9fe3-d9eafbe914bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "eb576c12-5b0b-4bde-bfd8-b2dd7637f5ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "42357685-d63f-4347-baba-cf2688e8e850");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "96d1fbe1-95f1-437d-98c3-5f15eb8703c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "8bce63f2-04f6-413c-8c43-92b90246324f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "4346e524-5da9-47e7-87d9-b5ed57cf090c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "b59c60d3-49cb-4a78-8686-a1af0b03dcaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "33f137c7-bfff-499b-a8b7-2a8137d312c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "0166dd91-7a1f-410c-8e07-efefcdc76a98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "7c0435e5-6713-4bc1-9be8-2fe2c3025212");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "d5ee30c4-b15b-4bfc-89da-23fc82c6bfd7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "dfb856c6-b4d9-4c49-b685-0cc6b587c8cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "e5785b27-9f9b-450a-9cbe-47c64a9918ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "ae52e1c5-7f52-4435-b8e0-147902540c1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "3587af72-d754-4de0-bda5-b7b4cd6e2ff4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "7cd7fb22-2705-4ddc-897b-0675bd9a1852");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "f562ccff-a961-4b2d-a60d-37d983bf67d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "0e64f6e4-a714-4b3e-8884-cf6d3b512b7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "8c57fea5-b54a-4e34-93f3-7492e1a59e92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "9435d3fd-c729-4af6-89e3-18f7f02d5add");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "c2edac10-0f63-4855-aabd-198ef5885323");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "4510583c-3b22-4129-bf19-03b6856b9795");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "5bbc7327-1c4b-40a4-a166-63e802cf68c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "e32a71d2-1cd7-41b7-a16b-7f5c5239f823");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "02e1e3d3-01c3-4809-b02d-b43cc49876cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "a0a0a2a2-d306-480e-85ef-8ed43d5c09c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "595acb13-5630-48ce-9624-8f78e3c545b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "4b217f33-3ce8-44cd-b07f-37a84be21d71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "76a8b4d1-1537-499a-9634-465b1e560808");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "934cf886-60de-4dee-a0e0-3e94aaab1a40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "90f5ef36-11d0-4408-94ae-10339fce8e4a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "d8f0a266-b72b-4fee-b5b5-f79d26ac035a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "597d89e4-2618-46bf-8e80-275a5187a7ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "0bcef86e-1878-463c-95e1-eaf925279857");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "8b753087-dcdd-4600-9757-287306944e11");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "b5bf8d2b-fa07-4840-964c-49ab189e69ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "9256cb46-552f-464c-ab1c-0d436c7244bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "7dabfedd-3526-442c-a54f-15dbd70f40ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "afa73af7-325d-4ea5-b987-5ec21a067bf4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "2a78bf5b-2aac-41e3-a86b-93b8ee497750");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "79d49f1b-c23a-4095-b198-9c4a1510504e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "eb03e408-4852-4c0c-9e55-9ef89bdf5f06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "2564e910-6c00-4a4a-9800-2066dcac0256");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "d434e82c-e4a3-4db5-8531-6a1b420880b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "bdf2e182-4488-40fb-a590-f446b5da45c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "fe38e763-00c7-455d-8ea9-3afb5ead801b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "c640c308-cf6c-41eb-aba7-c5c0c05d01b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "cd2cd0d8-ac71-4b27-9d43-9505df46f12c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "4f807d62-5f1f-4bf7-8dbe-8653c8c492c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "694344c3-2965-41f8-8f57-e59a25c9f405");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "623a3ded-4f6c-4301-8838-55b7ce28e4ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "53e29b1e-2cb9-4f72-bcb8-273bf72971ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "cbcfe198-f043-4fc2-b8ab-e392c4c71b06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "495f9c04-25a4-4ab3-ab36-c2eca83142fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "ac4df9ca-c30a-4bee-875a-90df2562b480");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "68b1f225-f7db-46d7-97fd-6b4e7f28bc8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "d178c28f-2ff4-4c84-acfd-90e3dea69e6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "0fab1876-c787-491b-b85a-1124c15536c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "93ba336a-4cdb-4a53-b853-2658162f5dee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "4789cb98-ac31-4870-af37-a040d26cc3ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "10f94dd7-87e1-401c-b82a-c01eb319f0ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "885ff2d2-dbf4-463e-a211-f33c9e9bfce8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "2ab7d1b3-1663-47e1-9e15-390815f63e7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "48f98e79-5539-4bcb-8c25-e322e7d61866");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "4f1633e6-10e6-427a-b0c2-21c8d27a0132");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "55e27595-a2b7-4581-8674-09d34f770143");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "7e311845-59dd-4ea1-ab08-c191f0023e41");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "0a2d20a4-0477-45dc-97cc-f433dae9eb9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "f1ab003e-99af-4477-a40d-ce83daef711a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "feaa019e-004a-42ac-86b1-8fb92ffe6654");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "52a21841-f77f-4835-9243-d0b79ded9289");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "40461e07-6595-4e53-9b7e-38870e53f0a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "90ab2275-f9fa-4baf-90aa-0670418d70f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "1c62ac58-1166-49af-a9f2-0aa8c0eaa81c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "0937f853-f6f2-41e4-b4ba-dda215edc265");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "baba8de0-fcb1-43e1-8a47-bb20e81df59a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "df8f557d-db51-4483-96f0-81c4dae136e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "a1f8769f-30d7-457c-b50a-1002cd312f9d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "5bc6f0e1-1394-4b13-a3d4-347aa4549c44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "5058363b-9cab-45d2-9187-ec7e59463a88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "4be44fc9-9b1c-4bd3-9cc2-9a197e9585eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "dfb4f473-449a-433d-aaf3-5dfbd5a9198e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "85c5fd6a-f349-4937-aff6-abe3840dd104");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "40be17e5-3fe5-44fb-9708-935550b101a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "59f8d556-37de-4d8c-9c6d-b42dbbbde8fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "0bcb1441-85b3-4112-aba1-c97762745710");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "6cb7aebb-0edf-4a4b-b194-b953907089ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "216d99ca-ce2f-4d6c-a735-e8f0b1bb201f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "6ef90325-c51f-4ae0-a734-ed34393d1e68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "1e6c148e-1f76-41fe-acf8-f5832b9cb0d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "02992965-0cc0-4619-ac76-2d10b0cdcee1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "f266ac7d-89bf-4106-984b-748cb33efcfb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "2b4dd666-8fab-4abc-b748-343755b88b78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "3c9444a2-7aae-430e-aed9-a4a359ce2941");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "1c610b0a-acca-480d-bb79-50a02d0e497f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "dbc78bb9-a8c2-4105-8248-0711462e96ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "9e82bb1c-ccb4-43e4-b0a5-f0a8da01d2d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "edf23e03-f1e7-49fb-8697-51fce1b72e23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "90f3786a-c21e-48c3-b82e-f0730a1baac6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "bb36589c-0d81-4a2c-8de2-0d8c01f944e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "4f30e976-35d9-4ce5-89f6-2cf3216a93cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "992bd9eb-eb71-41c8-9836-ee30bef5bc05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "9d886ef4-cb76-43c9-8420-65bd6460f815");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "082b6912-fd0d-41d6-aced-dd0042cf60dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "f9633ecd-555a-4316-b5b9-c210446c3bcb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "9ec4c336-a9b7-47a4-ae57-865cde36299b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "16dc8760-bbd7-4887-b9da-a267d17d62e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "be0e2f0d-c9a4-4e72-80b4-47fc258e62f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "1187da98-7e3e-4f09-b929-541d593a46f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "c8f0c1de-3b9c-4dd8-87af-376d8ad68dac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "898f7f25-d08e-4531-944f-e1b06cd9f9d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "2cbbb683-6f32-4328-b210-de1d62c0dcbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "fe967151-e127-40a0-950f-01e73953e4f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "35923a6d-ab4c-4020-a60e-c3a24c060a43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "c24abfbf-8241-45bb-b290-049920962359");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "1c98c500-4b49-4806-9eb2-4830f35096ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "3777317c-6c62-4de2-8ed8-ec4ea79e04f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "be34619f-7aaa-4c9d-ae10-c44bb246f131");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "60d3d9e8-d4ce-49ac-a37b-4376e4d905a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "1c01bd18-7acd-4f3f-a64a-8121ee54e046");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "ee5181ed-286f-4bc8-975b-079972321fa0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "ea5717ea-a884-460a-8b37-0360cfda57ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "773d6b68-6a6b-4b86-b9e5-4458db727e6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "c2c68c73-1659-4162-94ac-3a4bb84ecd83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "8b07e56a-1d11-4955-adcd-906bd7cb54b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "06ef0ff6-1117-42fe-8e5b-11c5e8cda2af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "8029db70-bd44-4fa7-baf6-c86da063f2ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "31e43423-3f02-4df6-9da4-7e28fbc0a946");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "02d0e6a7-d3dc-4985-8568-72dbeb930bdc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "d8397fe4-4d04-4c63-9114-aa94c78237e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "dcffcd78-df0e-4e5f-ac52-1daf2d4551b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "7f5c0ab0-d22e-4137-9f23-f5e4490d9c22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "743010f2-5b38-4697-b56b-30b0337f4424");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "f9a6af82-27ca-4de2-b18a-05e04d40c7a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "dbf54d36-af1f-45ae-b87c-70433cf821cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "660aaeb4-0c42-4d62-a56f-b9743512c5f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "d3fb25ad-f00e-4f98-80d6-70843202cbf7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "fa40a2c6-3bc8-476d-afe9-5193921e44bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "16efb120-97a1-4b41-bcd0-3f62b0fb4c29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "d974bbde-bc3e-4557-9b43-f5d475d9bf25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "79ffef0c-00c5-40a2-9d57-02780d734e61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "3ef4865d-50f0-4e77-9108-777bb87e6913");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "96ac2f64-1982-4ca7-a879-f4337798742b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "dd86f12f-ecd3-4bbc-9a4b-f8bec7261538");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "1c7ed769-4745-4cb4-bbf8-27e0e89edea7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "cabf2843-5a7b-4507-a732-4affa415914f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "e2b2044a-fbb8-49dc-9ab2-7522c4962995");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "bfaad8be-71ca-4069-82d7-d29971c2253f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "3dfc997d-04bf-4255-923c-ed7926859ecb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "de29715c-5b6a-4c56-9517-f2117cc8ac1a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "6e3a19a5-1602-451e-a175-e3d9b19d2b6d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "0f68d4db-64c6-43e4-83c4-a6ad2b0ec9e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "bf1448fe-df84-4e8d-99d5-8ff6c29e3bff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "a2221054-ec77-41c0-b312-65a218ed14df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "36b3f407-5564-4a0f-a31c-687c5dec6fc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "7906caaf-beaa-4c69-a37e-41f37ee13a16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "ff86c3cc-7705-457b-a03a-a19b92b91700");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "9a50233d-e38a-40a1-83fa-a15428f7003c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "9a2d3280-ff09-4d2e-b15f-c63a93c8a16e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "face042a-48e2-470e-afd1-845623eb3d2c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "cac43f00-ed40-4048-9b3b-2281cc51398e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "4761478a-1f79-48ca-a2a9-41eee25dcd21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "c6d33fb7-6b14-4cf9-a2f6-a51d20dad636");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "687b91aa-f82c-4cc9-8e99-66b4ee52163b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "c196ac74-e640-4a08-bcc5-8f045236f154");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "b02c347b-05f5-4dc1-ad1a-ab0a2945d2dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "b15fd7b7-c3ca-4e75-9ce6-b277a519ba0c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "cfa393c0-e651-4085-ad35-4f8ec570019d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "2769e4a9-5231-464c-9a84-f094682f68b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "7cf9b9d2-ba8a-4610-a119-01dce1a6aaed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "50fce61d-faa7-4822-af80-8862fe05bb7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "544f42af-a117-4ac1-9382-a94f788ad41e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "dec32d61-9309-400f-af2d-cc3b5887a969");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "697a0313-1900-43e9-a225-13449cb73561");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "8954ee61-dc6a-4b71-858a-ca428c12c263");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "9ba0e7f7-6d90-40ef-a61d-06143064c25a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "08be3561-4523-45ac-8b23-cd469d964739");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "52dfcf8d-537d-475c-9c11-b9f289b84cf7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "0e1bde0a-0abc-4675-92b9-e03cddd60f77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "9554440f-1e63-43eb-bacb-388e31052ae0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "98d3cf47-530b-4358-a310-d6d163c5a17b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "d5284327-7670-473c-b9d4-5753f5e54c22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "2a749b46-cfce-4b35-91bb-fcbaadc8f1dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "15b84d1b-8606-493d-ade3-70b6dfedf1d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "258c396e-5cfa-4497-a4bb-26068d1965af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "c3c3e847-0a9a-4a32-84ee-b1b9be53c9e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "ec1409c1-3bfc-491b-a8f3-72183711ade4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "d7603b6e-5f65-4355-8b01-26870ec01b44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "60f2d7b4-d43a-4f72-8357-550b2493670f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "6b0cdb2a-5e23-47cb-b1a0-369e5ba18f4d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "0d826c6d-6f52-495d-a880-b295209e4397");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "752d822f-2451-486c-8b01-1ca66eb0a701");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "3dfe7eed-7fdf-445c-8fcf-1c1394a8e071");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "6bb540a0-106e-4e2e-bff8-24f29194fded");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "730a6f0e-7a0f-4858-ae77-264af8d5035c");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "44a390ee-eee9-43c8-99d9-08ff83f47926");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "cdf9528a-c9d8-4cd5-a38f-1f6fd04f82ca");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "2f3405db-9f31-4c4c-b8e2-98a15e6500b2");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "2cd46724-117d-43d1-a8f8-6ec593621104");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "e69d3da2-8ef2-43c9-8080-bb397ccfde90");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "0aa8d2f3-94c6-4b89-ac4d-8efff0be4934");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "dbb8a27d-5b7d-4f10-be29-0dda599e9c13");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "4df54b02-9f95-44cc-98af-04ed30a1946b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "5103665e-391f-4936-a0c9-ed7f679fc735");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "2aaf67ad-302a-4c10-a7eb-0d2ed159ee59");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "038c29c5-044a-4a84-aeb4-cdbd98f531f4");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "81c9a196-f518-43b5-9a38-d465b396dbdb");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "3be9685a-ca30-48c8-a330-dd593a733221");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "493c68fc-d98b-4376-82b5-6f9e9c326256");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "9a7af655-c5eb-4b6c-b413-99200a412afa");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "bbf939e4-6ba0-40aa-b399-0e546f9408e5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "822593b9-0962-4afb-8acd-701a20093049");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "db810ca2-21cc-4743-980d-a5f86a1850c8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "bfe8abc0-c6ef-483a-8899-b6083b34215c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "a7415d4b-a300-441f-9ff7-dedf16c85aa5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "ffdb9b8f-5725-41c5-8c84-7479290acf49");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "3ec6618b-64eb-4995-85c6-0749e96ef869");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "b63e2f17-48f1-420d-ae2c-0ca646b4850b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "79b4cbc0-9166-4b5b-b77a-75c71356a399");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "8bfec55e-6705-4e3c-95c2-c0801e6e2ecf");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "0fe7a4fb-915e-45f1-97b3-cf9f030d1327");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "d5a0bf80-2678-49ff-b9d0-4826044c27a6");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "bd7a2bb5-efb3-4cc1-b34b-3ad2f93645a8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "bfac6301-1bbd-42f8-8650-723f08daddf4");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "b530ec10-11bb-4826-b49f-cfc4124522fe");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "94b3ba6d-4a24-46cc-a34d-9a44382c2b99");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "cd0a5a38-9fd4-4f00-a9b0-e63ea50c9c6b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "b76d32a6-1a78-4122-8a07-026dcd48142c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "18171f12-00f8-41b7-b3a4-cdbfe9a05861");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "73d923c6-166b-420d-934e-02872ed07b88");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "2229d48e-7524-4a2f-9a50-ec30f3d907af");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "a81984bc-944f-4094-98eb-a27f0f511408");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Management, economic and financial sciences", "bed0b796-b29f-440e-a321-c458455fa395" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Health sciences", "084ede75-a7ae-458d-96ed-40e872458c92" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Social and human sciences", "5cec61f3-8e91-44e0-bc32-3c7533704798" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Design", "2cc1d391-c0cd-4a00-ab35-24160c5c2d10" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Communication", "62ccaf97-f44a-429b-b28c-98f0d3c9b061" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Engineering and technology", "df5bcbf6-1544-4d10-8822-299628145888" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Education", "e9cb86c8-bc72-448f-b265-d27ee2b633a3" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Law", "31d1a8d9-9239-4710-b094-85751cdc0e4d" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Business", "5d1fa667-c78b-4c72-888a-1c45c213e17a" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { "Other", "7eabffbb-beb2-49f0-8907-a788e4b80513" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { "Formal education", "3176aa0b-6539-4d86-b27e-35831c6ef8cd" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { "Complementary education", "b8878fd1-514e-44f3-a568-12923f89a0a4" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { "Certifications", "cd1d7863-0526-45a6-9ec5-a4c95ddb74c8" });

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "41b61afa-8019-4cbc-a8c6-db91d4f05c96");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "b6cb7887-9166-40cf-a97b-b78a65ddeb40");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "6174dd0c-d234-4d41-920a-b33280e2350a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "03098917-3af9-40cc-844d-080654014648");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "6991a597-9c8a-4cd1-b832-bb1b60c4b63a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "543e5957-3af7-47e7-871d-5993d7eda372");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "75ea41f8-1844-4e9d-a864-6682814a7caf");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "efb67db9-994f-4060-812f-91d72d1c4071");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "0efc98be-31c4-4d98-b057-dec4d7716e87");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "5b2e8d8f-3cc2-49cb-a469-75ffcff8c5f8");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "21bf1037-4f97-48ac-b610-dc147f8e0f43");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "5470191c-cdbb-4285-9fde-67f12357c6fb");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "3675b1a5-7b41-4aae-bdb6-51f74dba24af");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "b4a42815-14bf-45a8-941c-7e480269a992");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "b81d1885-1339-4ba9-8043-119a677c9008");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "73b7a895-f788-4c97-b4b4-88970bd8860e");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "2bbce88f-d385-44ec-bdcb-11eeac7cd969");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "ecdd33b0-4d97-420e-8df5-85c9a6aeb0c9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                columns: new[] { "CertificationStateGuid", "NameEnglish" },
                values: new object[] { "6e7ad274-2125-4e87-9597-f544f40d7a56", null });

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                columns: new[] { "CertificationStateGuid", "NameEnglish" },
                values: new object[] { "75a35718-edd9-42fd-9971-1dd9862f8b04", null });

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "ce5bdd1e-006a-4212-9332-e0c353f08027");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "703e9a7b-6ed1-47ab-8489-802ad10cf9f3");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "85913f6a-b764-4ec2-8ad3-ad8f8a01e2c9");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "77962bde-878c-455a-95f3-7ec94c76b7e7");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "4e544153-39dd-4cbc-9d62-14b070629f07");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "3ac832e6-0939-4f99-b7c1-ac6183ff086b");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "ec6e2a58-d9ae-44f9-873e-7c8686624e42");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "3b5b4951-93c2-40f7-9614-9ef0736793ca");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "10e7b5e2-11de-46c3-b013-46fc16891230");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "7e62a678-25eb-41a3-8041-4daae7509953");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "0069e7d4-dcad-4f7e-8a69-c3370f487ed9");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "19e88f46-2110-4cb7-9d97-d5923da3d776");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "96caf138-d5bf-4a14-859f-44996176a122");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "4aaaf07c-1232-434e-8b23-274342a11025");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "07561b45-36fc-4a88-9d49-1653b5787b3f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "daf31f98-e8ef-42da-a6dd-74236031285d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "4bf27d04-f1c4-44b3-905f-f28565afb0ad");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "41bb8e89-685e-4d06-84ab-cb24605181ad");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "995149a7-8547-4816-a4c7-071907f1d3c7");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "d46197d8-ff2d-4b24-80fd-316214b09db0");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "137d1505-8ba2-48ac-902b-97c241675840");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "f57212a6-d439-40d2-9c56-aa4789f8acf3");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "beabfae1-6c4f-4ada-bacb-ea50c0d40eef");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "a2d4b457-67f2-4843-932e-1b63ab2b8ff0");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "3b045a8d-3ae0-4b76-9582-9b60bd8d17fb");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "09004832-53e9-43d9-a4b9-fb3c4857fbc8");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "76c74778-ea58-491e-a532-32d76eb889eb");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "cdec8d4f-700c-4ec5-b83c-7b5e8f324a09");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "29686541-d50f-45ff-85b3-1b65b4da807b");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "fbc2efe8-748b-4f50-9157-74a3c9745c01");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "90bdc93e-9df2-4d77-b3dc-ab102a1a7ab4");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "9724a146-5d50-4c4b-95df-bbccbd7233bf");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "fccc50f4-5c06-4ea4-9880-89b8886c8c83");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "807a5b99-0954-455b-932e-72dddc80d73a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "90676623-faa1-4da4-8cf0-896c82c98b38");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "b65c1319-7e0f-4105-a198-68d145ce38cb");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "8cb59bf9-4ef9-4175-a970-a802aab58796");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "8a25b874-d2f6-453a-9ca0-204053911303");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "f2825a05-5a60-4185-a367-5e31b1d034a5");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "9b9b12e8-f53a-4087-830f-df17e32d90b6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "d4432f6c-eaca-474d-8379-8303b87c2cbc");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "67138669-2647-4d4c-85cc-88fc15279635");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "99a12096-8918-4578-a329-d4ac549e8656");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "01ae6a9f-1abd-422f-bd77-89cb6e3c131e");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "f978c148-a869-4a96-bd81-52c8319cd815");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "4b772abb-3c36-4202-843b-6de2f86a6c04");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "45b013c3-b90c-4d14-a30b-594eff26e5d1");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "b90ee478-de60-4841-a23f-290ebc2dbbe0");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "4c920086-0205-4eb6-8e4b-b4fc4e7ef558");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "7afb9f22-deff-41de-911f-10b21788ea6d");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "d39706da-b798-4d87-b813-bcd71ad5ec29");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "2dc02cb5-8ee2-47dd-abaf-25bc9a91a3e7");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "f413c210-ebaa-4a22-b55f-e67183b3e3f2");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "3540d10e-28bf-49f9-b44b-3413d04b4e5b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "a835d83c-057b-4ce0-a37c-e342663b15f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "56929aa0-69f5-4c7f-8f2d-210ede13bd21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "5798cbf7-8ac6-44f0-84c7-cd4100283e0b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "fdf3ffe3-f332-4c87-b21c-3fc8bd7a6aed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "c040b07e-cced-4c90-abfa-4317258fd459");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "064019eb-05e5-4f34-872b-77e495bb373d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "bd45b05c-d280-4727-bcdd-e3747cb4946f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "3ff024fb-0462-4c12-9c0b-a1c1e737ec51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "ed11df52-edbe-4130-a3b5-399ec8f2d5ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "0002ebf0-7447-4614-9bc9-1122d4e72321");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "d3664ec5-5f7c-4b56-b025-28d1b03edfbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "ae661f1d-3dd5-40b3-8e5b-7e71a024e6b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "4aa5bf93-d3d3-46db-979e-4d57f3b2bee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "0ebe061c-4865-4171-be4e-6656c3e05079");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "bff67593-3a56-42ed-9f84-b1ab342deb1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "a6f5322a-f343-4bc8-9f15-3b0d947083ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "2527ee36-6b91-4621-9ca3-0aad767835de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "965fb475-e6b3-48dc-a7ad-cdadad01e39e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "5e490739-45e7-4bc4-8e30-61c0bb270573");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "144a3db1-0a7d-4822-bc2c-e7689e2461da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "95820c8c-9044-4cf4-b4d0-9fd4be13bf1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "fff5f7db-5d03-4d84-8bfd-287af2d298b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "24b69975-6fdd-4be2-865f-2c62027a9136");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "749ab847-96e7-497c-8941-bc21a7c9b935");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "8d816508-0413-4193-8aa1-a9dec5e1c9d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "0ee46f3d-8fc8-464d-8033-4e6d6c6ae6ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "cf2d3845-9edd-4e80-a743-1c26c0b0784a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "b0f5ad71-2b4c-4cde-ac46-21eaa4d72a2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "3d0f154f-30f0-45a0-b682-d5368931972c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "0f052f58-698f-46c6-914b-3e6aaea25fc8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "f6acd11f-c381-42af-9f7d-4365d3cd5c4d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "4400da1a-22af-43b5-b645-c16d9a29ef8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "258bc72d-b6a5-4cd3-b6bd-326d3f92a046");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "ffdaefce-270a-4fe2-8088-0893aa2419af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "0d206be2-5a0c-4b84-a9cb-299db9f17e28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "ffc7889a-4e17-445a-a960-440b52b4756d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "b83a849c-51a7-484b-a87d-64d889b7394c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "b0d1d181-a384-4377-b031-1d0ac74dee9c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "bc65c1fd-5026-43ee-acc5-a95109634f74");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "e3e1bf97-1536-4ae4-94bd-b82f90086ff5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "e7fa68e0-f682-4e91-ac7b-258803d3a672");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "a1988f87-76fe-4efd-884a-5513c9ecc0ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "69965234-2681-4adf-b209-ab30bd93fb0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "65d8dcde-e0a7-441d-8327-7109f1a50db0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "f241ca4b-8b4c-4363-9ef7-3f7fedffb41b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "ac93fcde-b2c5-406c-bbfd-7808948db31f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "2002083a-61b7-49b2-821b-c5a3ee34fbbe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "d15fc712-143e-4415-a930-5f29a851c86f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "6de87765-3122-455a-b3c7-bf1e76d3d8a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "9a85e9bc-fc6d-4120-89dd-82fa63e42387");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "82a2cf3f-2904-4036-9648-56d5493a4edf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "00d4f570-8634-4240-b56d-8f128f12a485");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "10149eac-886e-454a-8cf4-7236a5cf3cec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "edb97954-69c6-4ef4-beb6-385c1970693a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "fe636b62-da52-49be-a46a-8fe8c3b372bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "22821576-6013-4089-aede-1acfe4d4ea7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "e62974bd-7010-4d82-ba4e-47cde6d99e50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "fb0c3992-26eb-4d7e-b83b-f9b897f43f93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "7570143c-05ac-4526-8cce-264f02f63fd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "2633631b-1397-4e08-a5b6-fa5b60b360f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "7a08fd13-6a11-452f-b569-56004f962a7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "01ec7a71-e9e4-4906-8575-3ffe9c875b8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "d7658454-08c7-443a-8ef5-f85057259d6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "2bece545-8cb0-417c-b49e-86bd302a9cef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "22c41560-3fd6-46ee-a0f8-d84d17a69abe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "81ee7a58-2bc3-4052-a917-3c68225ee4ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "2855d71a-1a08-400d-bb26-2aaa96ed0c49");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "31a97cb4-c6e8-4a8a-a168-07b7731629cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "12b390d8-7715-4802-a016-c8c56d092c1a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "06270b7c-9e08-457b-abbd-df5ccc83cefe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "7183a1fa-535c-418a-8b4d-f02da835cea3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "64358a85-5400-4f33-846b-f6cf0a319d68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "420164f8-c415-4f95-83b2-6909f38aef12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "49426e68-f6c7-45f3-af22-8f64e954a7bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "f6d235b4-86c0-4f93-9cf9-f9497c6ddaff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "8d74cfea-f063-4ba0-a3fa-01fc7d6e5d74");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "49f62fe7-b80d-4452-b383-7ad68825e8d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "e6acd0dc-8e7a-413c-ac30-5c71b6d1ad77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "791389ee-3266-4b1a-86ac-3b441a63333a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "9a260367-47c6-499c-a276-e4b3350ae366");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "5e15ecbc-3aa1-4e1f-b5ef-a9a031941afa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "6d49635f-0509-4d3d-8745-c90f2a84b3e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "f1faa744-ec9d-4a6a-8456-bed9e4322495");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "b9db8600-f6cc-4275-afc9-b8b4dab9a96b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "2b90f2ff-4d9d-4c1f-8a13-d39f22c60715");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "28659334-6079-40dd-a125-5b0df365f3d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "9f65f14b-8792-4dd5-9ed7-79fa2f6873da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "a50de96f-2ab7-4451-9d5d-ef44a070c4aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "27197b04-aefb-47e9-8008-dfae7f2a60d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "70349059-c1a8-43e7-ba9a-76245f9588d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "55558f9b-11ea-487b-b362-ed07e4cf0021");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "2c2f47b8-53a6-4431-b59b-083b5bdb0bc7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "cd277446-821b-455e-a166-9da4dcf1992b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "5e0bfd42-3fb4-4284-9630-0f9323d58f0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "b523b9fe-6579-49f7-b1d1-acb8913570af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "e8fbdae5-ac35-4d57-a0bd-72e57c92a711");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "fdf2cbea-9563-4c87-b0ed-ba87dfa89111");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "167e9a9d-755b-4f45-9f3a-07cb8ff7ee47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "278da8d0-208a-400a-9d70-47536d5c9974");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "dea00723-60ac-4331-a6c2-f16554222de3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "377cf3aa-b8fc-489b-a8c8-471a1d976274");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "a4585ccf-7f10-4c7f-af54-2bcd1fa97e72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "25f750ed-a225-4cdc-ad55-9bcfd690f09f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "6e126cc0-93b6-439c-9697-fc17aca11f60");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "f386fe30-8724-4817-9b3e-3683918fb281");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "73809b22-68e8-4627-9013-3930da3e6071");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "7b354a29-945e-4538-8d78-32efec999f3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "d32cc8c1-c9fb-4e71-84a3-4b58129925a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "051e1558-aec1-48bf-a2a2-323d12c70e66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "dcc8b06b-c415-406d-84a2-3b13e54cfe6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "7116f3e9-f8d4-4c35-a3b5-07e70a55d8ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "e204ffac-4b03-4fac-ba1e-340b0adbf913");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "c0456182-0e5c-4e6c-983f-57d78bd28968");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "a9ed9ebc-1909-4a67-a216-f219599a75c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "6e8005bd-cedb-4f42-8261-db0a92be934f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "a47a359b-ef18-4ac2-a860-fb68169cb55d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "c9837eac-1a17-453a-a1a0-8f6d7c48a2b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "06e5cdf3-826c-46e2-af25-2e99c18408a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "86e04361-96f3-4e9a-a53c-28639284384b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "3f7c9ab8-fe69-409f-abc2-2aaa136023f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "92763a1a-c9a5-4703-a51c-92e8cfaf47df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "6d37b64b-d734-4c4f-b461-e6af4344a12a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "8d6f338d-8ff9-4f7c-852e-13e9e16027af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "e2c7c7f7-53a7-497f-99a9-612b2d557546");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "f1d777a6-fdca-4ad0-8f87-2751bf86922d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "aab2e157-98a7-41ff-91bd-40932ce64449");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "ae74b409-27fc-4efe-91a9-a29183670101");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "756b38a5-48de-493c-b025-d4ff319e8149");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "a8fc738e-692a-4fa0-a978-3598289ac5af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "ec33e939-f881-45fb-8b90-2fe2757d6ade");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "3708f6cd-bad5-405e-bf7e-6f759a86f2cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "995361a3-955d-4b41-9eb3-3d82e3865002");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "59499bcd-e475-40b4-b68c-cfae4e956ea3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "f00d6425-2bfc-4731-80bc-93cb96db222f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "e02467a1-852f-4449-8def-3b1ecb71a181");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "34b48a00-4e51-455a-8ec0-6841cef6c71b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "2b24d1c5-c0f7-4db3-9efe-8398b49707e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "17ee1938-7beb-48da-b383-42b83bd8fb93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "70f5d533-e280-4dd4-aa08-e859215fb2f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "a2ce5538-ff68-4741-905a-4602ced91a6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "cbd6db7b-4cd5-49d4-b8bb-e13cb8ee4883");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "fea2c71a-2198-439a-991a-46cc5cc23192");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "6c9a9178-0bba-4767-a45b-422874db116b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "a615350e-f653-4e83-af2d-bc5d0bc77008");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "09260953-1d05-4db3-9627-efc490daac3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "07a882fa-ca16-4b12-b774-2946d45f41f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "6282e5b3-0292-4be3-a4a8-551a1fc8de84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "a06beaff-7196-4202-9181-a0d9ee747b98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "64b85ecb-2235-40da-9c00-c29373356fdd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "34371a36-e014-473a-933e-0895f45387aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "9bcd32e5-5963-4dbe-bec0-9e0fbd6f8b57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "7cf9cd99-10ea-4779-87c8-511b55333925");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "21464157-63da-42f2-8560-3721b2464085");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "f04f5568-dde1-4e32-987c-442bbd11b9ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "59613fb5-ff7d-47d3-8b5b-6ab44e9735bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "b8d064ef-6e5d-4299-b23f-ac7ed355839a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "ca27a785-8280-4d2f-83ba-d8ce36bd91dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "b898bf05-b486-4fc8-bd72-90506cc84c55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "9e19ab97-4811-40eb-9dbe-095dfe0bd93f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "fd162d7e-dd40-47c6-9c4a-eb2549b9fd9d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "0260db4d-ecc5-4de3-90da-339e700832ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "fb701e3c-b887-4ca8-8667-e00152618ab0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "41af4bac-9b67-431d-b9b4-d3eb3f6164de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "4956e8f5-7689-4fe0-8afb-43fa0bd01e80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "f3e924af-e18b-4f48-b6c2-c86f32221c03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "d3f73c73-e807-4e45-a7a2-c47a07b178d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "5bec670c-1ebe-4c30-a8f1-7b7bfa95b8c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "e9e7d334-3def-432f-8cb5-53289453abed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "b90b461b-5104-4d74-b4ba-28b294cbd561");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "4e936622-fef1-4902-b049-25162c67e040");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "9b35870f-ce64-4861-bd97-860fb0278026");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "8590758b-f0a5-4017-ba1d-46e9f23ae383");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "d0d47b58-c724-40ec-b923-dd39a61472c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "2887afd4-9127-465b-a50a-65591874a376");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "cf05a675-e505-4cc3-b18a-a86ed6ab9293");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "369c657d-1544-4629-a0fb-bfa289d09853");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "679a25e7-d1cc-4706-9083-5f06dad02d43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "ba6466fb-7407-48e0-be4c-5cefcb2a7b1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "7aec67ff-918b-4d38-ad03-50fc63582e94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "60cd7968-1ecf-448f-bd33-f1777e2c389a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "42fe394d-f07a-4915-ac41-f688791109ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "f4fe2432-19e0-4bd5-8021-d4fd5162fa22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "fbe39e09-3b74-4cd9-a018-2cc3124aed1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "04717f9b-d024-4b39-900b-9ce3891ee654");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "4596f75c-3792-4a88-bbc7-e33865090e0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "f0c4710e-b9de-40e2-94e3-283b8530f702");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "c86f786f-016c-4f3a-bf0b-be221e938322");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "de1b5f50-58f8-4507-aa29-6e8d465a2134");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "95da38da-87cf-4f3d-b1ea-e4bcd1aac34b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "7c2de791-7597-40c0-b4a2-14ef5cdb37d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "af2acae9-6a44-4f7b-b27e-a37f4429d999");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "b14ad979-4b8d-4374-9c25-8ac6f1709002");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "40c39299-c7b0-4be4-b994-f5099a9fe39b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "5e7c71d9-a4f7-4406-b02e-a5114c488ab5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "2eece8bf-f480-45cc-a23a-cfba5a70d0b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "29748b4f-b5f3-47f9-8f57-9ce724aec4ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "a3938508-59d5-48a6-ad81-8ddd8e1c2ad3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "31268951-deaf-4500-9437-0a5db617cbca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "e4a91280-8e2a-41cc-8952-352418de3a3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "b7aac0b0-1c36-47cb-9d65-35d4414c9714");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "bedfc643-2ec3-4956-9880-fdce40e5cfef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "ffc2c5d0-97b5-4596-b978-8c497f02032e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "d76d56ef-2d11-4f8b-8842-07810634a99a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "ddb783a3-de4d-4337-a7d3-4f6bd9f3acce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "cf21f0cb-8502-45eb-bc37-5a58175786e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "8b2e5c57-7891-4275-a236-5a034724b9d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "67828077-d4df-4c1b-a776-119af67d0604");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "c1b6cca2-a936-445b-857a-e890ce78eb6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "660969ed-be7f-4e9c-9b51-b4f5a19be527");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "ee05546f-87fe-40b4-b050-2853508dfd54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "6a1b8bb7-eda5-4765-b612-944fe5b7f144");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "d3b16bd4-3d6a-4872-a7cf-45607e71ed39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "00865b97-36ba-4cf7-91e3-7cb5a1677ffc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "471aa822-0beb-4306-bd88-897c47ecc18f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "e616875e-ea1a-432d-ac5a-965733465409");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "e842430b-ba97-42bc-b562-c4c842c23357");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "392a0c24-3ede-46fb-a77d-fa095dd284c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "339daf0c-64e8-4074-b26e-301dc4a0d17f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "0b3b9172-d34f-4abb-b43a-efb2be0c9160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "26507465-7617-49b2-93bc-2ddb945bc449");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "f18c3f5a-354e-4dec-a29d-76774ac6a82b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "328d0281-bcc0-4798-8ede-1ab673dca896");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "721ffcda-94d9-46cc-afb4-1fe4fc9591ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "87d48c0d-c72b-4b97-83d6-3e6d9ebd6d78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "8a72fb78-3455-4409-8b62-64cd315e28d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "74cd9e7b-a3bb-4fe8-a945-44024ec44e03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "0c895f16-17bd-4cdd-8ee6-49336bd4373b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "1d6b7183-7402-46b5-a208-602b70e1d812");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "29d871a9-ec22-4e3e-97fa-6ef758b18434");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "db8a2592-bb77-4733-88d7-1a5c09637f99");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "7a9e2981-aa46-4583-85f7-6ff4516698c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "dd3fe069-d15f-48d7-a3b4-b7cdac873404");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "fd6159f2-7ae1-4a61-a723-a1dd9a81750f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "4be297c7-e1d3-4861-9908-a0e481a01086");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "30e7636d-3b17-4d2e-9b93-e0b3ece65965");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "df17e168-884a-4317-ae65-e66a89ec2c16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "1683fbe6-150f-4606-9cfb-d628e76d4cec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "e051d1dd-afb1-476c-87ce-9308aa75f54c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "715eb8cf-2061-4458-9784-3e258eb50f62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "b60d2cf2-62f8-451c-b5df-40758f8dfc72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "86346931-4d93-4048-92f5-e9e88dc6ece2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "b8ccb338-9dc4-4721-b500-a594030460e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "8990e0b0-1924-4df1-8809-fdb4224fc3ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "6a4d5cbd-f22e-4810-a15a-4ce7f472201d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "e3b8a1b4-fa03-4ce5-91fb-ebaff9a530f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "8f9535f9-f085-4ad7-ab2c-d6fa56e04e71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "96de2c84-37f2-4364-9b35-77a2f01c49a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "f8215d0a-2703-47b6-8868-b6cd56f9336e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "945426e8-b15d-436b-bfb0-e50c68640536");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "98528e96-d6cc-434c-8849-ecf7d26bc01a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "639f6f86-963b-4c0f-9082-a42a59c3bf80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "2ef68d51-90e5-4761-b27c-d4df1d882817");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "c7c8de0c-a690-48fd-a896-b8127a9c24ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "d86c0c49-37a6-4f0c-bf67-c4c2f2f72725");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "8cfefec8-0e48-4826-a488-57d3e250c59c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "9764fbca-00ea-4a78-87f5-be5cca341d1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "56e42b17-56e1-44fd-9897-a7640ae911ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "418c5b36-af6e-4e62-93d6-72d930d807be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "754ea422-7ab5-437a-bac2-ded3397d8aa1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "128cfbc1-f1ff-4a3a-9eea-6acbb282cee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "9d9d17d4-431a-45dd-b9d7-940b5aa9d949");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "07e0c66e-aa5d-449c-afb2-c9464397f6b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "1aff82d5-b58e-4ce9-b385-61302ebdda06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "cf508a69-16e3-4913-9bbc-a2b0b4ccdac8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "db7687b4-68d2-45fb-a416-e52ff0b53802");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "4dca794a-2c43-4eec-a2eb-fe27965664ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "141bbae5-b2f3-41f4-8961-6893b4e7d0a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "f47e5577-8fd5-49e6-a1e3-12cf3977d0b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "5e85611a-0465-42fb-b6cd-fd25a3a68141");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "9441a3c5-260f-43cf-8cc8-3ef3c219cb45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "e03836b8-6333-4864-8290-489e95dcd12b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "06c69fd7-58a7-421c-8689-4188c37f8a6b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "ed7c0db8-c114-49ec-950f-b5f460bcd150");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "ff531e1d-cd3e-4073-98de-3ce1d81da3b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "1be96024-fac5-42f0-8148-36a7e6720806");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "ed14997e-6505-4f88-b0b6-e2c8a9eee53b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "48c7cd47-af13-42d3-9847-044d2af8b17a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "2820eb68-80e3-4659-95c5-6c3b796cbf6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "702828ed-cdac-4bcc-9dd4-059b405e3771");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "36d7a849-3e06-4b36-9d11-f45dfce669e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "514e8b4e-0562-4055-9cef-bd8330c77a78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "c3860f25-7212-451c-873e-f57c4a400c42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "cade394d-77a4-45b7-b429-d483477ea25d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "efc708bd-4584-405c-bc99-e6bbe46fb84d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "afed53c1-2d91-4bb2-8505-f238dc52b574");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "883c85cc-36ec-411d-9159-f4ecdac3a058");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "814844b2-5e27-4456-ac68-13a35bba6baf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "b6c0d777-eb1e-47d4-b1e6-ee42c18c8609");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "bd8d8ccc-1a8a-486c-b398-30b623fb6d89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "f5b39b63-38ec-4ec0-bc56-7eaaa1c22e46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "80ff58d8-b4df-4bd2-9995-20bde1b01f44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "f4be579b-ef41-4382-aa80-56a31c3187f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "ac4f70ca-8463-49e8-b631-b4e4785b9bf4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "11d20163-8647-4223-892a-a945ddfcbf85");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "c7c13d09-d157-4a59-9d5c-8814ef474d5a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "d8f59e6c-7ea1-46e4-ab41-3893ee016088");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "a0f2799b-7495-42ae-9b58-7df09b51972e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "5b4b63cb-6c36-4b52-bf24-17fc096219ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "78a7ece2-4fb3-493d-a732-c95249dd159c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "0bd9530a-81ff-49fc-8deb-a37409ec49f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "43ae6978-ef82-4215-a288-95264b17f295");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "f60c750b-a764-4f1c-bd85-441fb5f9de7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "4401202e-bb7e-4a6c-92be-65dc07bfa223");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "c88952fc-041c-4d3f-a246-af98cf155803");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "0ade4b63-11a8-44b6-8e99-9f5f231f216b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "6d24ca43-ab5c-44ec-8786-7bed503d178d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "e009f416-8185-4ae7-8f41-f0bb85b2b889");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "7f264e6c-7f26-4a75-b538-93e61bc95c0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "48b6f891-e740-4fb4-975b-b240e63f5584");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "01477be0-de2a-487b-bc83-ec205ae77046");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "4247e215-2ef2-4c80-a783-7210d2924f17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "37f3ae10-9bbf-4760-b348-a5aa0ad077c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "7490b8d4-75c3-4142-9649-1f3e69ae55ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "54828943-d4c2-445c-b14d-040652979869");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "6047d0a7-80f0-43e5-9263-3ab1e840dcf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "dd764e14-382d-4863-827e-e5e6ab0ecc9c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "565ddb21-745e-4423-9f4c-2c8c8496faf1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "9fe0d2b9-479f-4bc9-906d-53abbf980a3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "7a21e427-487e-4f4d-b146-e6771366c489");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "25878536-50f0-425e-ac24-eda2f7823221");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "ec1822aa-ffbd-4ebe-a347-bede5bf0f785");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "6dbb753b-5bbb-4ebf-87d6-379013ee64a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "76a8e4e7-8103-4962-b3a0-f202bd720c47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "4fc02cde-181a-4a57-a179-16a8907ad6dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "020d2d8c-6aae-43fb-a410-4fe1e0ebd610");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "a371c71c-1bc9-4a20-977e-b6b2d6775fbd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "cca2c33e-84d3-4e0b-8f28-adb074abff5c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "5a586cc7-1fcc-42c0-a61a-75108ef191ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "3626e062-f1e9-4dda-b7ec-20cb8643b876");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "d726d9df-78fd-4d1e-bf79-05b84eac4ee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "35c28d47-9e92-4920-80a6-afd0a3e62fc4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "0ca4666c-4258-4ced-98c0-1a8cc4b43fc3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "12bf9ab9-dc6d-4407-b61e-748d9e18fc66");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "3e630450-1d9f-4b71-b842-ca8e2331503b");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "c429670c-2327-40f7-a1e9-cd50a2f6e776");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "aa73203a-a855-4e7c-ab8f-3b148ee4c455");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "9f02bd47-2089-4354-a3af-5f4ddc0c70b2");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "24e13488-d1a1-4f44-af3f-a4380416b72c");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "995636cd-6a14-4cec-8d9f-c005580c1d81");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "83b1fc88-d6f2-4236-ab10-ddd547753f3d");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "94d4dc11-49ea-4318-8c61-dd3c943a7ea8");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "e608cfb7-5705-476d-9f77-c1b1a2244f0b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "9ec09c84-636a-443c-ae6a-47cef268f0fa");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "9d53b3f7-455f-4992-9443-b8d69dc35bc5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "fe9d334f-b44a-42d5-9cb9-2515d4b44bdb");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "823cdac6-16dc-4820-a39f-3bf6e5081bd4");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "76c28282-d141-4128-b45b-f6ec9d753b1f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "29bd6947-7cab-457d-b159-6f2197144b0d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "37d489ec-b41d-41ab-8941-e5c7a7aca3a1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "d01921d5-2089-4e02-83ed-03e281ee991c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "d786167c-a37d-427c-8990-94bb4dd732c6");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "7f57d548-41bb-4e57-9797-69dc3e7b40fc");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "0dd4b4ed-b041-4f14-adc6-28dfc43c7766");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "59a22f1c-4a07-4ae6-a021-1d997b404a6a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "adef151b-7c9f-4044-a1b0-2a2895ea6a29");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "2db4109e-8222-4ed0-adc6-168b22c1e903");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "38aef29f-577e-4874-9ba7-ef628d51615e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "6e8ce90e-514b-4012-9846-5f4aa921d191");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "d948dd05-c35c-46bb-ab7d-51ff46cd4914");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "05dd1258-ca61-404e-ad1b-48fdd7047361");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "cef26f80-a07c-474b-b8d9-efb40a240e58");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "e22a87fb-3be4-4e33-8804-64bdabed483d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "acb97759-41b4-4e3d-be7f-014eea033b74");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "6f98950d-6426-4920-b5db-040a8e385684");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "eb71d43e-159f-458c-b4d9-e04cf0ca05fa");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "b9083061-a7eb-4569-8f76-526da320f45b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "870bc2a1-43af-4a14-bfd9-e519470649b3");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "7e007b9a-3238-45e3-ac01-49b611471a2c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "205efbbc-99fe-4b70-b9f0-021b08c3b0d8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "b1983094-40ed-476f-941e-13c979db3ba7");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "41e63235-c7b9-4e6d-8b91-7f62e761a468");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "04f91257-0188-4e48-870a-d515832d2544" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "7d680bdd-7955-488f-a355-c3b0c81fe39e" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "8d13e6fd-bb32-46b8-8609-af9374cb9cf0" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "7f7274ec-ec51-4e4b-82ea-5da6a26c36a7" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "21fce49c-5e36-4721-be3a-41ae9dd072fc" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "39849372-c712-4b6e-8946-006f4b8b3e14" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "578ba337-da45-45bd-9aa4-ccd3d5bbe324" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "6cfd7830-5daf-456a-aff1-60e9499d9ab2" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "ddc96265-9eb4-4a1b-b2ae-57d28790a726" });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                columns: new[] { "NameEnglish", "StudyAreaGuid" },
                values: new object[] { null, "82c6b418-ceac-42d7-a163-514e68334a2c" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { null, "cb42f75e-eef4-43e0-b71d-8adcfdd9a025" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { null, "bd3e350e-f3de-4410-aeaf-9123ba3d5145" });

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                columns: new[] { "NameEnglish", "StudyTypeGuid" },
                values: new object[] { null, "f4589b5f-054a-4b2b-9316-7d83e760da13" });

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "e766ed4f-55c6-4fa4-8bf8-b372fa084660");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "ecb2a069-741b-4c6d-b282-cf9cbef6d5ab");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "804f5ca4-d7ba-4cb2-a110-38c98483b4d4");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "959e664f-edaf-4b5d-bf76-9e4b619e1212");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "616d1af3-1bb7-4aea-ac06-b6cc1661b62e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "889bc0b4-434c-4c2a-ba1c-9001e03264a9");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "5bf7563f-16de-4848-beb0-753d532936db");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "4b8f092e-73cf-494f-8742-3c6d5e3ff579");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "2d10a7bc-08f9-48aa-a459-0dfd5cea97d7");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "93e45fae-71b6-48b4-b7e6-8390546146b4");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "a4def4e4-ac2b-4f13-a646-25509968fece");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "baba3188-a017-4232-b1d7-6d97fe0d546e");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "3155ef24-c031-468e-af9d-175338eb7370");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "b1e754d6-81aa-492b-b760-7ef18b791142");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "4cfdd04a-cfd5-4070-bf6f-a0e5af6c13dc");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "8be85ad4-3113-4ae4-a77d-7247006b2ca4");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "07352ede-ef60-4dc1-9651-a46f84538b5a");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "4ee365b4-635c-4a82-91e9-5ec4e2168f3a");
        }
    }
}
