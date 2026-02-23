using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CandidatesMS.Migrations
{
    public partial class OtherSoftSkill1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftSkill_SoftSkillTranslation_SoftSkillTranslationId",
                table: "SoftSkill");

            migrationBuilder.DropTable(
                name: "SoftSkillTranslation");

            migrationBuilder.DropIndex(
                name: "IX_SoftSkill_SoftSkillTranslationId",
                table: "SoftSkill");

            migrationBuilder.DropColumn(
                name: "SoftSkillGuid",
                table: "SoftSkill");

            migrationBuilder.DropColumn(
                name: "SoftSkillTranslationId",
                table: "SoftSkill");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "a5344d4b-3b45-4215-81d6-932c58b32682");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "9e1f9b28-b336-427b-9e6d-f965038e7b10");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "53fd2a66-8bf4-4bed-bbbb-ca3a8b80987d");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "d54e3de0-64d8-409d-9f09-96958cd96458");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "335d7ebd-071b-420b-b9e3-80072dff9c38");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "d1dafb2b-e316-4e46-bd33-8ffed454cb5d");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "34595db6-e850-453f-acd8-1e79754e7353");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "1565c318-f675-4c47-bbb4-1de0ba01fc4b");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "b4793760-a808-4d6e-82a5-d428c1f83d88");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "2bc488bc-45b6-4c19-9366-508b635d10ca");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "6c83ba8e-e34f-4972-8110-ef5f9e69f3b9");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "37e8c556-b125-49c5-bd3a-479e1dda929f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "9e37c65a-6b62-41b4-b1be-4c90c33c08cd");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "bf0645c4-edab-451f-808a-8df7567a1c8d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "5f24fda6-4fe8-4106-9612-bde146f2856f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "186c6ef3-af63-460b-9000-cd26cde979f3");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "c3f6d0bc-7199-4e44-8a22-6aac595ec878");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "33c7e5b5-2300-4a8f-b0e7-e113ff3fe7c7");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "e06849c9-a0b7-420b-a031-cc838cde4623");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "0138774b-3856-4eb3-9757-895e5ba83056");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "497639c8-8f50-4213-a8fe-c6eeb3f5538c");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "b587269c-313d-4cc5-857b-b1a154de1387");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "744b884f-c2b7-4343-be08-c839e77cd2cf");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "52d148b6-3a25-44fe-8b23-3dcf30b64cff");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "971c5272-3c41-499a-8bc2-58f7d8c5080a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "3df90e77-1d82-4702-a2eb-244c862342ee");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "ebc42fcf-86d5-469f-b0b6-d8702a04bfcb");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "46858704-7b15-4e03-98d5-77b394da94d2");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "1911467d-7510-43f1-840b-0a444bfd2b0a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "14b86ae3-e201-465d-8bb2-d8f48f1cd9f8");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "cf6622af-e00c-4ebb-90d6-d27ecdfe5066");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "4b614b5f-5291-40b7-81b7-e1be044c8586");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "d8d373cf-8451-4f7f-a537-90b8a805a7fe");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "06ccdb37-2258-4adb-b949-e05afaf8d4b1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "9cd723c8-0803-4776-940e-43796f65e9fe");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "ee17dc1d-090c-4da1-9be7-0279e2ce5387");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "5e88d2f4-704c-4f19-a334-70c38df3e1d4");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "ddaed692-da7c-44b7-8a81-40e6a26324e5");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "aa05f144-11e6-45ab-96c3-6826648609f6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "54d711f4-5b3d-49dc-8438-47c9d5badc17");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "e665ce25-0ec3-415d-b94d-e5e626594e79");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "1269ea63-cce2-4ac1-a5f9-6758b9164625");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "b022e5bb-06b7-454d-9f1c-806c0cedc928");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "d0a82972-4434-449a-a2c0-d2eb91cba018");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "29a60d06-6158-4ff9-bf95-68d1d43ac8e4");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "d3659563-decf-4ba2-95c4-9522e790ee9c");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "ef7c72a7-5d91-49ac-a8f8-671ed11f2c9d");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "755dd95b-f0e6-4501-a2da-4aeb05e0244e");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "c4e916ab-f3b2-4d2f-ab55-3e6a0b6a8d8e");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "63392a11-8035-4eea-9d32-e7dbfae2611a");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "e1b33eb2-aafa-4002-8d3c-7c0b31325e04");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "d5dea7c2-6b29-4923-abf4-683de2247e8e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "f1608f4d-20be-40a3-999b-32cecadd4fd6");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "22a04cd4-5b0a-421c-8895-ecc04f3ef566");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "8e42d555-84c0-46f4-98cd-c67928f39109");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "2600fc6e-75a4-4583-9c4f-b5342a7034fe");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "1ae6c064-bf81-4b83-9eae-3eb3f96743f3");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "8c358ebe-43a1-44de-9e0e-ed7ac6506d9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "7f2222bd-f713-44e9-9ad8-17ed56d64906");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "8d0b0479-ee71-4c50-bfd4-7b950d95823e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "ad55f2b5-6930-4f64-98cb-f4e37eaa8fb2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "f338f283-7ada-4a79-8d36-dc7a7a1a3845");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "5a64728d-33e3-46d2-a81d-1782ec75dc51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "43008c52-be71-4f97-b3ad-2553d6d128ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "526b71db-a1e4-479a-9a37-7b11f8d8dde2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "a41a8e0a-a204-4c3d-b569-04921933bf9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "96294463-3835-45fd-b9a7-d739e9ed3d3a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "fc0bb13d-5f51-4fc3-b11d-39215f4ffc1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "d31529c4-85e5-4666-9c2b-c9ce20caf7fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "9c88d7d7-04cd-46e9-977d-2b35609cf58f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "35e4bf94-f6a9-4a52-8b72-dce6a9fdd964");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "1071d48f-246a-4d13-b5e1-c5a8709ea2db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "6a117722-b2ff-400a-bac5-128707426b66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "3a83dd8a-a24b-498f-9215-8be29ba3333b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "c5929497-d995-4e2e-9a05-330800b4d1de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "c04becdf-58a5-43dd-ab97-085b69650ac4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "f2cf1c62-d8d2-4231-926e-c5dddebff9b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "2101cea8-fc41-40e1-8c32-75f38b4c4220");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "40282f87-c505-414f-a810-316b30b67012");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "d926e59f-135a-42cf-b463-b3e4c792066c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "b75dbfd8-8b40-4c0b-a6e8-7fcb41ec4001");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "501300bb-63c0-485a-8f66-0ca8ad1c4f11");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "0f4b2db3-72d2-48a6-8c5a-cc775ef2fcd7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "3ee58088-ec2e-406d-98c3-35fd978cec9c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "24cbb855-827e-4153-8018-bc2b6685446a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "24e82369-51c6-4bcf-85d2-517c35e87ce2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "5ef04de9-1dd4-4c8f-8965-33756b9f1349");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "23b862e6-5204-4121-86b5-928d7028bb0b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "dabe9197-6a21-4bc2-96c0-19965d848fc1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "83ed51d8-34bb-409e-a1ea-01bf20f58afa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "f3437551-944d-431c-80f7-4108996bfff9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "e82ae32e-7e10-4488-9fe3-57203825c408");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "236da198-af91-4dd7-8afe-f371f9666f7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "83c9ffdb-2de2-41de-822e-1ac4d12079e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "0e0da3e2-a314-4142-bf0a-92052f527941");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "03e73459-2f7f-4b7b-b5a9-6f855579d792");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "f3571fa3-7cce-4a69-8be1-1a19bf0db354");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "85d11829-c1a4-4439-8814-8769c490b250");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "0a3925d7-cb64-4d84-a971-7b504541987c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "ec5c6a72-083d-453f-985a-e518df81e57d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "546aad38-cd16-4b30-b008-61a5189399fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "f0665816-978c-4a4f-a3bf-1cba26313c97");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "1caafb9b-da3a-43d3-83ec-030b2b7fffbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "66c6b661-d10d-49bf-925d-e114fe700c31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "9f4dbb07-9aeb-4e45-b956-28eb0ad01e88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "5b77ecdf-6229-4831-9f17-775782376b2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "bf827931-3e41-48db-a4a2-cb5ca2a335d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "5eefef8b-bf98-46da-aac4-3470a0ee2b6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "bb206e9d-503b-46d2-96fa-9d038d2eedc2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "32bee973-3066-4dec-9429-c65bf04c8f07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "c894c1bc-724d-4c15-b1d6-5da2837998b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "15bbae2a-b206-497a-aeea-1a0184f91e06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "c7254672-ed67-4298-b309-e5bdc88e51cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "038eef20-1179-414a-9e4a-ab1b0ca4aef7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "db8545ef-2384-4c2c-b305-a05ea31ab25c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "5d09661a-7538-47b9-99ae-5159bb134b63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "57f47ee2-9a96-4050-af7b-4b5625bc858d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "0bcd6efa-2f88-401e-a2e4-52f746319f54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "247e40fd-b3a4-4790-bcf9-724524d33ba7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "d4252ea8-b9a4-4944-8d78-bc4f1294283e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "ee80a715-d8e2-4f0d-93ff-8b509b3f210a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "ae6b1f1d-f735-44db-9107-cc4bd93c61ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "636f1d02-25d5-4ca1-9bdc-5e0406ed553a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "d39e5d6b-6de5-486a-9938-30366a287aba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "aa1bc3d0-4057-4242-8382-c5f06eb3b0a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "c2971310-9054-4672-aca8-0ee88f6b82be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "996507b2-1670-4d04-84ad-d6842ec91cf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "bc323949-6f4a-45d0-b58e-0758ebd65748");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "e5dad010-b535-40fb-9091-c2f4369168b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "256afb53-47f2-45ba-b29b-ff6cb3e74410");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "12917a81-0403-4b03-9156-1a743a461f30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "733f454d-3d59-4673-868f-cb23f86e768f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "dabbbc8b-c6a5-4ee9-93f6-96962be7eca8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "b437a267-cbbc-4cee-a140-23f9cca4ba8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "801bb2af-6175-404c-aae8-793bb1d80075");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "8d14a25d-52ca-42be-b837-c2aa82c876bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "a60947fb-e573-4509-b7c3-7b0166fa3dcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "fbb0e02a-40f6-45a9-9ce2-b6fe0832b079");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "32489454-8b9c-4d1c-995f-5111785e2f26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "3cb9f11f-a7b9-4e7d-8d40-7a22352889c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "4d66d5a2-29f9-4bee-815b-bb13a0fedb45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "08f99c86-0b00-476f-938e-aec88c96b8eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "da173c96-4473-4321-bfc0-c07e59f5ec28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "a040db92-a8f2-4741-a1a2-a7f00aa40f84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "b2368674-3612-4c47-9910-43111c34fc16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "6f11607a-52db-41c6-add5-8dd87ab6450c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "4dfde801-bb3c-45c9-802f-995a351ff5e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "873fb442-b80c-4108-8cd7-aa98925529e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "361b396b-f25b-4250-86df-6f2887c2932f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "e3d8e084-e6f8-415c-a6f8-5afe8ab282ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "6ee9dfb7-03b9-425d-879c-7e9896d22d26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "b49b6581-d5ff-40a5-baae-3eb2d6eb0926");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "86f1d05e-50a1-46ec-853d-ce40a29aeabf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "b6ce5566-fa59-42c0-b535-ec5ecf6ddb0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "f14d6449-cb15-470a-a60a-f470a3ff4d39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "a69e5920-6deb-4734-b225-047589536ed8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "7791a620-2d98-4eb7-8305-0c4550979b5b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "3d251ff4-9142-4056-931f-4e71e7b9162b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "29ae8791-9849-49ce-b7fc-fafa225bcadb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "ba6a2437-2d63-4b91-a76b-c7c922b59d8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "18dedf5d-bead-4089-9340-2bb2ed1a50d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "a82af41c-488f-438f-815b-e19fe0aad347");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "408b7890-d501-485d-bdcf-caf8fe5cad93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "9aabddcf-e3d6-4a4f-a87d-f36ce68f5787");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "c0090302-9fd6-428e-a768-f27b398fc8c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "5060fd74-f7aa-4607-a595-3383120341a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "34624c14-e74e-44c6-821b-3dc3d738b16f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "df4412d4-b82a-4308-8ace-07bce01bf6e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "4f1b337a-babb-4157-a9db-130826237d69");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "b7ff3078-57dd-4d46-b18b-dc3376e5164d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "2ca67fd6-4827-4617-93f7-cb184b2e39a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "b785d8de-9ea7-4100-b845-5d8377dc2c02");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "5b73a3ee-5029-416a-ae66-4c68cd73b138");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "11898a46-3647-4ade-84f4-e629e7ca3cbd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "13ac4d31-364e-4475-bedf-d17266c97afd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "6bfc4ca2-81f8-462e-a347-e036fa480d25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "8d4a061e-f2a0-4b83-bc49-24d552822746");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "493495eb-398a-4556-b948-3836cb8f94c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "2402234c-6243-48de-bf5d-96df15e33d7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "0fcb8772-ca1b-4b3d-b492-9e92d5c1be40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "8b9c45cb-2499-4036-9e3f-b50a388eeddd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "cdb41ac2-2336-4de9-894e-0a2b0de289c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "6b1f3da9-42b1-4492-9948-8485884ad322");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "babfea0e-6321-40ad-9025-4811d0c7ebd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "d0382394-6502-47b1-8de3-55cb145e6c54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "e7bc435b-a1d7-4349-8483-9f22cc17062d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "5276aef1-3d72-4afa-94ab-688692bba76d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "aa461f4c-aa15-4528-b157-57d8c744ee67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "2ce25e30-650d-4297-9d96-d6c2e830124a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "71169d37-7131-453d-8e12-108843d77cc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "311f120f-7089-4d5e-bb6b-24323e39f5c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "41349351-56ab-46f1-b3f0-5b6015fb94a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "2563c67d-6ac8-47ed-be6c-1cc4ad9982c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "4112dec5-0954-44f2-a1a0-1db6c67e0eda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "93a540af-dc83-4670-9bb8-3a1bfa5a90f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "a4dbac51-7e0e-4b63-b744-7dd3159d139b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "e9ed2827-a3be-4024-86b2-d1ef56aa370a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "2ccf326e-7cdc-4810-974a-2d43328be4f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "85b8db35-196d-46c3-8fb4-00e2a673f396");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "e049ffdb-053e-4482-92ba-b579b5aa4a26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "dfde0821-bf94-4a07-904c-e2e6944f0b8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "c65087f4-a77e-45a1-88ab-3bd90759f518");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "9ecd4c43-ecfc-4fa7-aa2e-4cc5ed5c80dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "40fbf367-22c5-492d-a833-0efb9c63fc2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "6cc966b1-7a34-4e76-8f1f-41cefde31ed2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "8aae5703-d641-4bb7-8fb8-aeec425537a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "62e8d500-cb64-4b60-a201-d35280010be3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "77c62b65-39ca-492d-a8e2-727ddd729293");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "bbea7790-db54-4384-a891-f28c759fb1cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "8c65277f-5e0b-49ee-a20c-af4edf2377c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "8d4731d0-3843-46d5-9d07-192a95aa4b5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "3674c3c8-8387-4d0c-9392-3da5fb03ccf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "1a50b97a-8f65-40ec-8d77-0fe89e809ecd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "665465aa-36b5-4028-adf5-3bef3dcfa4f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "0be4b25a-2908-435f-9654-d54b51f37c29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "3dce6eae-4648-4ce5-ae7e-327ffb356eff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "ab8fe7b1-9efd-41ee-8257-8031395064ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "0d4759f3-2d0f-4e2d-bb22-11aeeea42240");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "ff158e9b-ed22-4bb6-bbfc-4b7d914a76e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "9e455690-6360-41cc-8ff4-1c2c76f59890");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "db9d6030-934e-453a-896c-e0a29fc2bdf4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "56932754-c9f5-4de4-a96d-8000052fe4c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "c06d26cd-dc10-45e1-ad2b-eb36df522d7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "2185c03a-178f-4c98-81eb-7abbf341a6bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "5e0c7681-311b-4779-afdc-f9450e6d564d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "22b4a80c-3912-4be9-beec-e4e984bdce17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "3c23bb23-d0a5-4bb3-9889-2afc647698b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "592c4e5d-8eb8-48e3-bd94-fc1b2f402ad3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "daf8f567-2f03-48c7-869c-8016ee1b6b47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "205bd825-6ac9-4798-abeb-844a4a628b9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "ce32c5de-e62a-4d07-b8c3-64b6ce3fca14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "48a6cc03-428b-4ce3-822a-221cfc4b054f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "80f5378e-ff83-4802-bc95-9fb932eacfb1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "6a36dfd4-c21f-4f47-ae2f-1a0a52c97de0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "d414b721-6f70-4158-b491-6b0f45b040ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "08b5086c-05ed-45b0-a305-3d7ebab3c973");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "0e8edba6-ad5d-4740-b550-a78745498b3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "6b274e7f-2da2-422b-b0d2-ffe61b2915a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "fc0a968c-66c8-4e43-b818-7aad54d13756");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "109f85ea-d0de-4b9a-ad9d-435417131af4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "d059202b-7937-40b7-8eee-9776d637ca16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "edfa128c-6a28-4765-938f-e1087731cc7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "18a2eb98-b642-4d56-aa47-000e09667f50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "2dfa11be-fa69-4e47-be06-9648256e1d98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "b422af32-0433-4961-8e74-30d0057a1187");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "4940baa6-be8f-4587-b764-e0aabd6f3269");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "718231cb-3140-4b02-ad6b-6ffe685c4642");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "f644edc3-87d2-4558-a2f5-920a272cd843");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "7efbc849-34fe-4df8-8a7a-d8a8f3fd1e6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "75cb6e0e-a3f5-468b-ae87-ba8ec338f184");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "8cba0681-c1fd-4fbb-8862-8a6345eefff8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "07c51777-b5ba-4991-969f-9549ddbf529c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "e38a2602-170e-4001-ac1e-5d4205cb2dce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "40899912-31e8-4ce6-b4ed-3b7604d0a891");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "13246e24-9a39-4aea-b25d-28ba666604f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "f641e829-c260-414d-a82b-a7a0a7f2c0ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "0980f74d-2ae6-4aea-8366-c7ecef58095a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "68df28e3-dee2-41cc-a633-c67a4f326cef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "f988120d-60a4-4b85-a089-b7f381ca94e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "405729fe-d909-43d1-b2cd-74994619dc37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "50590842-a672-443f-bac0-a4a9b8964f04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "fc4d29df-3755-47d7-826c-832ead62c3a6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "cac99e8a-b790-4e18-8742-3cf2338f5177");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "ca85263b-d86a-4bd9-b9ee-fe7ada1ce356");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "19ff8169-41f9-402a-b7a3-067b7c1cfe6d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "6aff89e6-c652-4b57-8419-a0f29a3ffe85");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "4a32f233-df07-4b50-882d-fb8a29d85c22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "3074f8a0-0d62-4012-bda1-568f4f8ee395");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "d237a941-fb54-48f8-9946-e6f6533675f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "433cb303-f8b6-4ede-a491-287f49bca712");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "863b2255-ac38-4a97-8943-0b8dda145fa4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "1170ffb1-1106-4822-906f-23237c3b1263");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "b2c93267-a0e9-4704-a324-f1ba399d6c45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "f3e786b5-c8dc-4196-83de-587d403eed70");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "41ff577a-4968-4bda-ad3b-3b3c76a9b9ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "2d21a5d6-c610-450e-9b39-f6ea43d80053");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "00d62d2d-fa33-4062-8e17-9922a64a1a82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "584e32e2-2487-415d-9ce8-dd516520f1e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "6b46134e-b4ff-4335-b1a3-1a4377f8d11a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "d8c4a8f3-4afa-475c-ab0f-5a049a34e15f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "df5f24da-4d8b-44e5-9cb7-26966026b6a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "5b897720-e8d8-4d06-9cac-1414ff0c95cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "567418ff-f905-4c5c-8751-75fe201cff54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "604056cb-5733-465d-945e-d55f8fd902e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "3a51495c-513b-4edc-a8f6-ac7ac8ccecd2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "22abebce-d20f-4d8b-8c2f-3e29459739bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "57bafe94-a68c-4e18-93b9-65cfa9511cbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "b9c98a97-5acc-4744-9412-a6354d189791");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "f5e22558-5c04-4f62-b3a7-df25b815598f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "44332d90-82ea-4450-a851-42af87e0979c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "d01083f4-b7a9-4afa-beb2-e1ef8a532171");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "69b73e76-b215-4f89-b600-112eca375240");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "58aa5d24-de08-4839-8a34-cebcac5d3e13");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "bdba4b91-8dc5-4947-927b-7487d11bf7ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "4881b957-e6a6-4469-8f50-b3a02fad091d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "89198e43-e7eb-43c0-87e9-822884553b73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "a8222dca-e976-404f-b904-9637bf5d0d69");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "43663068-2398-4e30-9496-930602c68946");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "0b149b09-9c07-461d-93fd-58aaea0f8c67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "82117bd4-b892-42d8-84ed-b253d7713884");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "93022086-966b-44c6-83c6-086d760ab279");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "fdfa0044-e2b1-4c52-b485-ba939d290b6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "66a494f9-44ae-4726-8b6f-904d6f725a9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "579ed4bc-bc8d-4db7-ab9c-3d00a3dea488");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "d812de3e-f8f4-4149-bc10-7d34aa4c08f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "35441b61-a223-4a6e-b1e0-35d974bfefda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "6b8df4ff-688b-4fb3-ab9a-60c446d2c267");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "0cf398e5-ee0f-4a14-9cde-3f17b19ec64c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "0c605488-1c36-43ed-acd0-64dd0275c831");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "656e008d-fa6f-4cc2-8fb0-d3e846a8b927");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "c0f5aacb-64f7-495b-b62b-92b211340dd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "2d0e06e3-d62c-4a36-b332-1afc6d6c30b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "d830cc38-2808-4409-bf5e-6267c30cce3a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "8c3ca1d7-4720-4cae-a700-02e1e6fcb4d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "9f32c1c7-a7fe-4e1f-82a3-a0b88789db0c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "78f09f6c-fb44-4b88-9408-029ef85a49f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "e6b9b654-d995-4d9b-bc8a-989e9e8e1b00");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "8b093746-f4b6-48d6-a058-ce7891693740");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "84707727-d958-4cc8-8b39-509f7b19360b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "33e4fe1c-be8f-4a3d-a1de-d5f51a0c8516");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "44960a00-2d8b-4356-9c36-4dd8e46a5602");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "6cb919ba-b1d5-49bb-b2d3-6439d8527c24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "792616e1-0ae8-4c9d-a5a0-cfcb5afc6c3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "6d80d748-ccea-4f69-aee2-e49b9244d9f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "22741a42-d6f1-44a5-8db3-1014639cadc3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "12bd8fa9-9abf-4502-a507-f8126fcfbe96");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "e40cb795-f61e-4c60-8165-e027ea593636");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "041f4ecb-a705-467f-863a-6b7f79054bc3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "4bd9d633-f014-4907-b686-48a891e08761");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "b89dcd24-43de-4198-bc0e-48835f4a9714");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "6acefeea-6e4c-49b5-b342-97a2ef2238a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "1de787c2-33f5-4a73-918e-c98654588125");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "0bb51be2-38dd-4646-9b2a-f42d537aaab7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "101c1926-b347-409e-9d4b-c39e7efe0cb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "2e6d0e5e-2297-4be8-aac8-49090175a7ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "65116de0-79d4-45ab-a2d0-6140e08bef88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "6f483335-c451-4023-a0e0-a4ad44389069");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "417421c6-fec8-4e9a-86c9-8d7eb68fd18b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "375da683-78ea-4da5-8d5a-a4f8718a6637");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "321df05c-4260-4d1f-9b1c-c196302a6dba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "f7c11350-7ad8-441c-bb92-1333fe56818d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "26eb39d1-6f0b-4986-a106-c5dfb6ecdeb4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "2cd57955-8916-46f5-8afc-94eb95a8e3fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "d775d7f1-f219-472f-aad7-62af8c48e4c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "487aae66-b2d1-46ee-9949-0671d18ce070");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "b0cf73a7-06a8-443a-b328-cfce4e0a5648");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "c8a02ef2-c93e-439f-8e56-2957182ce896");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "7ade1b6d-aa31-4fa3-b58c-8720feb980b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "f1c6f01c-0c8c-4336-ba03-38765bfc5b03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "8954d6d3-ccb8-45e3-bb5b-490a2ceb49ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "67658da5-d383-4cc2-81dc-f8c8b84e52c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "346879a1-800d-4f7e-853d-63f226cc9f37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "be6f3f26-18b1-4abe-9ab7-b952cf79eab6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "633ea4f0-9624-4938-a288-9d3a129233c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "ca90b838-2624-4582-9a5f-a5f78f0b51c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "1e2a29a5-50bf-4093-b707-192d84de4d40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "73247ea1-1618-4f07-bccb-e139b6d9202b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "a184dd30-b466-4b5f-8c21-27824b0356f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "31efbb12-e12e-4f64-91b7-c328ea162fa3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "6a325050-db9f-4bae-8620-5fdcd0d90ed0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "d10da308-e41a-4045-a645-745a667a7a5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "c46e2e45-baff-458e-9c89-1ccc6927a237");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "eb0534d9-ca53-48ec-a6ea-eac95d39c366");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "75b0a97b-86dc-4754-a3b0-6149487ddd1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "2f16a76a-4438-4199-80b8-620aebb36345");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "f8870b10-365c-4ea6-b0f3-3da2461c037c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "eed2390a-7f37-450b-928c-7b5c89a6726f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "2e1a5c93-78a9-4b61-805e-2228162b5c61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "c26c3780-4037-42db-b977-49919d949064");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "72f8b91d-f11b-456e-9023-1e80e2ccf193");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "1a2e7eae-a2dd-44c1-a148-2bef9a869d60");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "5797f62a-2ad1-49af-af6e-ac78cb386d9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "ebdd9d96-0a28-44c1-ab1a-aea6b7b3660a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "0da2a81a-c8cc-489b-bc83-4aed414e2344");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "ee0fe6bb-7bf9-4ee7-83de-c69202f06568");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "b704f4e0-2107-44a8-9c77-b8e4d05db407");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "0f235ce4-41e0-49d3-8275-031f8bafdedf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "be515346-e5bd-4d03-abbe-3076923b46b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "416c2da3-1949-43ef-887b-104992c13e4d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "9a63203b-ee87-407f-930c-98184501d19e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "dffc2c72-aeff-4a61-b7fd-1697fca42b84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "a79e4031-5978-495b-a79f-c53505cedae5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "aa1a54dc-d186-4e7f-9649-669a3075eb06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "0d7d55e1-2077-46fc-b78c-e594435a6305");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "39854a82-6efd-4b44-adcf-c37ed6c7642f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "e5036a06-4752-470e-92d3-6f54e1c33612");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "c5c4ba84-575e-4188-b228-665c5edb9b65");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "321612f3-58dc-4f18-bafd-08bcd7fc71e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "1430fd38-7705-4e92-8867-7e71c7ae81d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "31c7d94a-2701-4d79-8374-2fa825ced2b8");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "e2bde506-bb1a-4f22-9693-23a427bc9e38");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "9957a626-7055-4336-8f1d-1b72582b46b7");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "a02637c9-1bca-4324-9f62-a26342cc95c0");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "4befc5e9-00fd-4917-a1fb-d81c986d2c88");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "4ba055fd-4a83-40ef-98b0-255f8ed0166c");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "8945392b-834c-4e55-8842-edfd1bec97cf");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "1c057276-3273-4ff5-b8c1-175bcd570196");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "cd548065-6509-4f95-a8c1-4cbad73f98a4");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "a0d29277-5719-4c1f-abaa-70618d79b9d1");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "60ff6aae-af3b-472e-a1d4-597858fb8f34");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "cc41a18f-5700-4413-8fd4-81ec6299dbb8");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "764a7a96-c976-46f3-b2f8-46a1d1a604a7");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "c61601cc-947e-4976-858c-275b85a1d528");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "f1e4c8d8-8b1a-41c7-8597-c90ca044cb68");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "16e465f2-8d66-417b-bfe3-ba7602cd1239");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "9e8edecb-62b0-49f3-a276-8a11a3eef816");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "08e43df8-7ce5-47fd-9fbb-580898530cf0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "b8b2f320-4efe-4cde-9173-6f92cfe03396");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "e5fa1780-c8e6-4433-b6a2-98864bc46770");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "ab4ae45c-12a6-4b51-8262-dfd4fa35bb27");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "8c500868-eaf4-49cc-ae38-4d227e5e8eb2");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "f880e418-4770-47c8-a701-9fb5e3abdb5a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "f5999a6a-b8a8-423f-823e-073442d43511");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "ce2a01cb-1b5f-41a8-aa1c-4752097cc8c7");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "25aae7fd-ab5a-4cce-bbb0-23c4d46e945a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "aebddeb8-7bdf-4752-82a4-320938dcc42b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "5a1998a9-1264-482d-907c-f1bcbbcc3e19");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "00d6cf09-f742-4658-90c6-85b80ea80a42");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "ec525870-07b0-4f9e-b2c2-6781c223a40e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "44a596b7-7c18-47e9-98b9-b86b4eae1e23");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "bea637fc-8059-4ebd-9f56-3253feff2afa");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "f9612cf3-72f9-4d3c-8c6c-8b9931b4a074");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "e11fb887-d21d-4639-8702-15ba67c0789d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "be6b0d0a-fa12-4370-a0ac-43a9ade70d5d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "46f2ea0c-0fe2-4d39-8932-4e09a726df58");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "bdf78b0c-01c4-4102-a7c7-595eb0b43dec");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "afe7caad-711e-4fef-9daf-29c9c905c0ab");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "b04b554e-0d78-4465-86d1-2b9b2d2fb639");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "ad4ceb16-025f-4438-8288-695dd44d1c3d");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "6eb7533f-7ab3-4c55-a122-1922d0facab5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoftSkillGuid",
                table: "SoftSkill",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoftSkillTranslationId",
                table: "SoftSkill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SoftSkillTranslation",
                columns: table => new
                {
                    SoftSkillTranslationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    English = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftSkillTranslation", x => x.SoftSkillTranslationId);
                });

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "638bcb88-8958-4a67-b228-65eeaac3b22e");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "b334e0b7-af18-4dda-ac84-cf05ca185439");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "9690cba1-983a-4a9a-928a-833b9061cc11");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "8d01a673-7997-4950-9d2e-32e666f8c78b");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "00c946c0-f16d-49f6-8ad9-a13dc731b9c2");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "9c1101b8-5d22-474d-ae36-c7aa5e208c90");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "f24dbb30-0797-4d1e-9ca3-a3b4cbd2f9c2");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "e6fb50e8-1241-49a3-92bc-58558fa95e95");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "4536dd05-3bc8-46eb-944f-55885ffc0067");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "45b39cb6-109e-41fd-87f9-78a11fa1b456");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "2f2d286b-a370-4d18-96ab-49c64d6901eb");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "bc56a3f8-de94-41e5-96e1-908c9f91b488");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "b3bcd019-5b6e-446b-a3b3-55c7bba4cd90");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "69235280-c805-49b4-a8c8-a240452fed59");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "a250e677-9e8f-4da3-9f97-5eda6c5bc04f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "8f610246-c6aa-4d58-bdf2-058d03268357");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "b5a56d26-e8ea-43c0-8caa-9f2cb8c2dc8a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "2bb08fe4-33ec-4846-98e3-3fb0121d1c8b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "3eb78efd-945c-4bb6-b74a-827bc737600a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "ea706f63-abb9-42f1-8619-8ca243c2d294");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "981ff769-609e-404e-b966-0ec2518cddd5");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "5355f350-ce2c-47b9-b89b-dde9c666ee9d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "17ad9176-0b7d-4e0b-a826-5356fc17fe26");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "36130486-4d6e-49a3-8b31-11aceb0ff8d0");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "4cbb918c-f587-4ff6-a135-faae5eda6abd");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "ea73bea5-d858-4aff-bb67-9e1d41df1956");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "db5b7d1c-2bb6-457d-bf4b-1e5630919b2b");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "cdb2a1ad-26a8-4c8a-b1db-e6a7cbf2c101");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "730045eb-53b4-4cfd-9810-d52d33445697");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "58e5adbd-07f9-40de-9fa2-fa62dedf12a5");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "b7eceba9-e64b-44c2-b0ff-6f911b2baaba");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "5d782425-d6c8-4fdc-b5b6-8e1da37a01f1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "1f6bca07-7c76-40e8-854b-07424babbb08");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "ecc074ba-f107-4986-9328-899cd0a3b004");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "6c24b62b-b088-43d8-99f9-95ff7b582656");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "2868cd25-8729-40c3-aa88-39222d8fcfc7");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "22223739-62fc-4b9a-bd3f-c7ce798f072a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "995f3244-7261-4d7e-8f50-6f93b5aa78b1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "19e7703b-b087-45e3-991e-03c2f5483750");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "b24b9c43-094b-4976-a38a-07e724f35e5e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "2f3c3765-bbfb-417e-a01c-9e46506a8d13");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "fe6ab64b-1f44-421b-bd46-67329bdab1f8");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "54ff09da-bc6a-4dab-ae1c-b2b89fff001f");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "2c7a3d7b-37b3-4ad9-8d73-1b20c3aa05aa");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "a7c45817-f5f0-46c1-92b9-f20d90102415");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "d7b31129-fb83-4591-b526-1b78fcd9db35");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "6822da85-8e5a-41bc-9d3a-da20bc44b890");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "519ad27c-c39c-4db5-855d-596e291f3d68");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "2c90bcb4-b79e-4902-9118-327a0990f45a");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "63982ace-3f00-42fb-990e-17b090d6a6f2");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "7d01a46a-077d-41a6-a1e7-ca310c7b4fd7");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "c5fd1aa9-3018-4e72-b99b-1db795347f1d");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "ca36c8ee-eb6f-4693-9db8-294ea04023b3");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "31c213ec-fa91-445e-beec-3331be1505cc");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "c2146924-9141-4e40-9523-c6ab2a1b9875");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "ce2f63a7-4a46-46be-90d8-c54dbfa981d4");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "3b40d1ba-6204-47cd-a139-4a6dce2a62ed");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "75b71992-1cfc-4eb8-9afc-1bc43babc985");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "666de4ad-eaa0-4b65-bbd8-24706c038abf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "f9005c1c-13e0-4730-a33e-17485029a25f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "23123486-e469-4f22-9be8-293e3fbd5e86");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "e5b52244-98c4-4693-9c01-5f4d87fdbdac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "3357d8cd-d128-46ca-ac38-c52514d27df8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "d4ce5597-a746-4466-8cb9-163402b79ede");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "84096cd6-d536-47b5-b91d-55c4946311fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "e0ae76a6-0ef5-41ff-aae2-8e0fb90a9b70");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "277c7a95-3f72-4f97-8b9e-3a864a5ab59d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "90f465d9-0f54-4e05-acac-292fa7b33421");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "a2c3e1ce-4b66-4692-8b36-7778d81fe77e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "14e36585-3ea4-41ec-8e67-433407cd4861");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "97bcc338-d92d-422d-960c-f0b537c91d93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "24b7a45d-ed4b-4a3a-8dd9-17df5006d657");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "50b7d33a-116d-4b53-b282-81bf2d1da2f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "b6c13611-d98f-4b29-b5f6-472df5420d5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "082310d3-d5d5-4572-8f21-e1920a80f501");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "9b980bc7-1f68-4ba1-9f14-4b600fc1d962");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "6a1a919b-8b19-4d17-a4f5-df00e34ea646");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "4a92b862-673f-49c1-966c-37b2f1599afb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "38e128fa-2909-4bcd-aa7a-83942331ad42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "152f42ae-6bc0-4821-8daa-3e16d6001768");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "06c04ffb-1bb5-4f1b-8071-47d507f5e47e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "fa1d5c8d-128d-4b6c-814c-db4175b86e2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "74a56fc0-18e1-457f-92a1-12b7a6651c50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "ec96ef59-9827-427d-aa80-9f0b6908c289");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "25bd03bf-66dd-421f-911a-8a78bea9afe5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "f895e4d4-ed2a-4c78-85d9-142d5327d247");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "f5b47108-ba72-4a6d-ae51-2c6a348938ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "75602a02-fbb9-402e-80a0-c9d00de8bde5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "6cfc626f-ef49-420c-9ed8-f08d76b767bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "70734602-f8d3-4a17-b667-34b20b0ef1c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "fa29c9f9-2bf2-4b80-bf9c-5c542b9add97");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "c393d213-65b5-417d-ae58-635237fcd105");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "a83c3f39-537e-41af-a318-9beae35c842d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "72b58eb7-7335-4e14-b84b-19d9f2acd617");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "bafb25ca-3300-4d74-9cb8-7ec9e458ce80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "81878fd7-e35a-4cee-90ad-26637f1ea99e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "7eecde31-7668-4815-8876-58e0d460d928");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "2b07da0d-2b40-4bec-b37d-5bb324f9a148");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "109c25ba-8a06-4585-990d-c5b7b6e4c16e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "2edd6178-a266-46c3-89ef-260e9712374f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "9407e5ec-08ae-4d37-85b7-7e16da2b1387");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "12780f53-6e62-44e4-aba6-d3113abd7f68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "4225a0c1-def8-443a-ab92-a6a1be654afe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "d2e201be-83bf-42f0-90f8-47f8131078f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "d7f8e817-dbd2-415d-b05f-231c08257235");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "658ad933-fb92-453f-8b25-963f78763f7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "bfc7160e-570c-4d98-8916-d73c6ca95f42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "827b99cf-832b-4bdf-a54b-730863b13a88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "8c70d2d3-c598-44b4-8cc4-a2f1589eb14f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "23d27800-0be2-40eb-a08c-b31b3fa32578");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "d2374133-4031-4259-9bc9-c2fbdd7c97da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "2d400091-81e0-42f2-a4b0-93a1fe529909");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "75b664f9-0742-47ab-b4ed-6d40191ac963");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "6565f0eb-b7be-4df5-a104-df1420c3f4af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "a0a98713-eb70-41fd-9fd0-4c6d0bc5fbd0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "2db6d52f-d114-4c67-add2-9af8aabf0f62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "448fb354-f454-4c8d-baae-7bd6cae4755e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "a8dc3dab-d7e0-426e-9daa-dff035531967");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "a76424fa-11fc-4988-b350-47cb5d452194");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "93ec52d2-1870-470d-a9dc-be4d86651f49");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "aa6ba64b-9d58-486b-a2e0-1da91a724fca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "9741b211-561c-443b-a605-682109e83a85");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "aaf007ec-5dbf-430d-aaaa-1f836080ef67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "959e5cae-86f7-4af0-981e-42783bf14af8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "7e08936d-0a2e-4d16-a1d1-a4909d79526e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "8142abda-b368-48c7-ad3d-ccdc98e80438");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "fb69e952-42c4-4b14-8476-df120e445a7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "51d1f95a-4f97-4905-8c8a-7ab4d0283d20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "0543d8a5-2d20-4745-be61-64f046c5f85e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "3b4aa4b6-7383-4719-aac1-d064f334ca2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "c16c12c9-9dd0-4b40-a3ce-ff9ce263d5e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "4b3f8d5b-28e2-4ee7-b28f-26d808ed8e92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "20486052-a64a-4683-a89d-ad394a4f75dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "ca157a97-8cdc-40d4-85d4-f4ac32012f90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "ccea0101-662e-4908-abc8-69d9e20aa737");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "1494fd69-c6e7-4fa8-ac8a-96876a68178e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "0bde9d21-018f-49e4-8bda-b2111dade985");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "296fcc71-30da-4103-b268-27f9bc7461d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "ccbb94ee-0dfe-4ea1-9599-2332f100dc26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "eb7c96bd-5046-4505-a9b2-9e229cdba711");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "c70cff56-83f2-41bc-9dcd-7533ab8a01f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "512ba63d-7f05-4917-84da-d64a3dc11ba5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "5d5aa3a7-76e9-4d06-a291-9d5d3f3c6b2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "798ceefe-976c-40b2-a3c0-838a2a2b11f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "e62c875f-1ec2-4ba9-ac02-d030a1de327b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "15ef0a2c-c36c-4bd4-b8e7-1a7199b26127");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "1002a1d7-0823-4454-a3ac-bfd68b256f62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "9f1269c1-eb72-457d-9ec3-01c365512a66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "8832c26e-3ca0-4d2e-bdca-c9ad06acb0c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "b721896d-3b63-4be8-b0da-9bf971f94ba5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "084ab000-6de0-45d3-b0c6-6b89efa91978");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "30e50520-e561-40a8-bfcc-7b28dd9846b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "18d9dbd1-bead-4d53-bc80-d41a67d956a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "6a14e378-ccdd-4e9b-98fc-d337434567d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "e8581d4e-c168-42fa-aebf-89ff4d086ca5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "c54e6a4c-18fd-4a2f-9c59-eb7edb5ebccb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "a9b6b283-9598-40cb-b26a-716eaa3a73f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "d882648f-7238-4b42-b77b-c72c7e5426d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "c5836dc5-f404-4f74-898c-8a2905f58a3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "2fa63624-43cd-46ad-8f51-5abc116e77aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "79fff917-a448-4b75-abb0-afae594d1df9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "d49d4eb7-d025-4855-89e9-e4bde51ed7bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "7eb46cb9-c3c1-4c58-9e02-89316dd44336");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "09720dcd-34ee-4f0f-9965-f1835bad9344");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "dc99000d-cf90-4a97-bb2b-a71a5094c202");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "07a69759-e361-48d0-9f11-0aa5dc327e5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "cfb21767-ca4f-4bbb-8f8c-580eafaa3fa8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "99df7d67-de65-449f-949b-01187ee176b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "ae5f0e99-ff7f-4627-85fb-7b9531a942a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "d8d0189a-7ca5-432d-8836-2c0a033915e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "7adb1f13-e4d7-4175-9125-02ca45fb7886");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "687eff00-a341-4524-b878-a115b2a3ea98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "d5d9ef50-8085-48b8-9932-59d25597e176");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "b2b4696c-a87e-4324-8519-ef8bbab4f3ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "9c662bc3-3d86-49d7-bcd5-2c9ec237c26d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "de17f9a3-5d7d-4496-a06c-c88123387bd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "33c7773c-ced3-4c02-b8e4-e27a7ccf71a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "e05fe3cf-67af-4824-a058-51fa42ec9e25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "5c0bc5af-912d-4eed-b65f-fa024a014d7b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "19f189b1-29cc-41a0-880f-2585c998ddbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "b8afed1e-cbcb-4ec6-9cfd-0c2daa63c980");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "507adfa9-0af8-46c1-b168-ab8e35e6eed4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "3dca2b7e-fd71-4703-b276-7462110a9780");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "3c24ceb6-9702-43be-889c-6d2df43fd47e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "614a60d5-c61a-486b-b6a7-a064d1175d79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "af6cfd40-d9a3-4cfc-94f7-913e8c595c94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "a056b8fc-5f0f-4fb0-b1e6-d0c53fbca0e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "869181f3-5797-493d-86c0-44d91046f461");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "a454e1a4-490b-4ea7-b722-eddc9062d4c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "d1591809-4ea8-45c8-ab9e-f9690cecd7ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "69ed7609-3a5d-4449-babe-47adf80d97e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "a0c24098-b597-44d8-a5dc-7f6d57f23819");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "e3ab33de-a46b-4daf-ada6-4a45c9133a42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "8c917f70-0ac6-4336-ba2e-85d78905b6c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "dd40f3cb-06db-44a5-9834-7d3d330161a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "4f7cc5e9-f2fd-42bb-a26c-a8e5963276fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "5691f759-e237-4031-9354-1a47e5d42f87");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "42da0ccc-866e-4679-97ba-7ae1c57fbbfb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "87985c69-5016-4d22-b309-8e5c390d8194");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "78f8f9f8-73ec-442c-a50f-042bddb51ed2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "cf3629aa-c45e-4882-8f49-e30e333230d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "0c1a2ccb-d356-4f6d-b890-ba77d35125d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "f713eb33-a3a6-4c4e-97d5-78b0a5f0cafb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "f57f1421-1e1b-45b7-9d4e-d4dbcf1056b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "433a085e-b48d-4ef4-81b1-d1e6a8b092cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "264cd548-b761-43cd-bea7-4e447173a19b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "fdc99da3-623f-4300-bda5-be9b26d6bb75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "e28a549a-4609-433b-af3f-ab543cbbd68a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "2c28c779-a786-429c-8368-d3bcbfc1c7ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "9e57695e-d554-45d7-a81c-03496f56bed1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "e6e304b8-d98e-45cd-aaf7-409f9bd47d52");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "2dd0138e-bc1d-4bc4-8c81-95758f1cac9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "91fb5d82-bffe-46e0-a3dc-8b25b8efd7e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "ce4a07b8-9d34-49e3-9f53-70ac1accc6ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "7f2d0b98-18d2-4a9b-8d51-d0ba02f594c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "070559ba-f5e4-4f61-babb-d4bba5f514cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "73e21c92-8eab-4514-aa23-3ec5aad4d92b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "8271cda4-7156-4d66-88a0-2737ac3ddd4f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "7f9d59eb-acd5-4551-9b9b-e9497860aa84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "9da87e7a-62bf-4873-975c-18c4f20aaab8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "a56cfa74-8edc-4b6d-ade8-aef2cb41124e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "702db756-7b5f-4e86-853b-01fa7d4a1ee2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "f1a62cd5-2ef7-45df-8dcb-c5f6937d7689");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "87d14e07-dc26-47ad-98d2-24fac4316f3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "0886b3fe-c476-4990-8fd2-3be5d1b21e8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "f894307a-a102-479e-8de6-9eef6020ad55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "b187f252-2cfc-4516-9d66-87b1a0bcdab7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "484f67ff-ec6e-46dd-9462-883c89768be9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "c821120f-bd3d-4fbf-b45f-9918be0f5796");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "9a49f415-5104-461b-a70d-76764651d0fb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "ce25b459-bb06-4662-a93f-df22efcae6be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "70bb2247-cd9a-410f-8562-387a9a11c437");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "e7919cfb-02b9-4105-9418-50a59d5a7248");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "c65c321e-bdd1-4241-b3d2-ab3c1ed39192");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "9238aba5-b177-497b-8396-b9b3c18ca344");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "b5118159-cedd-4aa0-aab7-7f0bf24500e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "d716a11b-f815-4b5a-9a1c-421d2e130c0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "13d49a27-601f-4cee-8336-55e3178df7e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "7a0b472a-1e95-424c-af17-6c0523b2b692");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "937f845e-153c-421c-a87d-866cf6b26b94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "131f7720-35b1-4e49-be68-efe79c25a623");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "f2770f92-47a3-4abe-abea-ddfb9819cb1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "84f4cd76-781a-4a3d-a815-9ddb04953b72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "4c6fb34e-5580-47ef-b40a-94ee9ed0ee37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "a044365c-1df5-48a8-945c-9dc61e147bdd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "bc743172-1480-4acb-b5ef-6f9d79cc0ecc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "2138eb28-d234-4980-adeb-754faa735205");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "0b7df926-fe3d-4e84-a0a3-624480af9b79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "e337f789-34a1-4fe3-93db-dd38f30ae3f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "f6803746-a0dd-4e3f-96d4-3fb9da9658b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "3e4ab19a-c983-452b-91d6-cad462be6bba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "26ab1366-7c6c-4f96-8b83-030ee3cc7b2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "b4fdb762-f4b4-402d-b59b-3d7e24ad110b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "76030141-def4-45e3-8000-8b253aba5724");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "7211cac4-3dfd-42d4-8007-2467e342d160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "3a3fcd80-1209-4670-8eb2-703ed2c86901");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "e4dd96ba-bb4e-4b98-9ab7-446775551214");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "f019bfc3-0543-4902-b3f3-9443392844ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "b4090016-9aba-4493-8541-f6f0112e980a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "8fbb07fd-2ed1-42a7-bbf9-a60ec7ee5cd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "0b3cd4ef-da4f-4490-a629-774434e068d8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "88aff30a-c092-4f65-8301-0767e2f0ae56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "e0af08c1-5330-4f48-9d2a-dbcf041cef99");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "1fe091e1-2757-42e6-b7c7-7fd602f81a4a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "8b3ec02c-d46b-4a10-87d8-561a59702960");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "29cc55d8-6d11-4ffe-9ea9-3612d4e94b63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "73c27b52-612c-440f-9356-e1d8422ca6e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "7af0c207-73d8-45fc-94d3-52dc0133ff95");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "f4fe0c5a-2dd7-4d54-85b4-f1af0ab93721");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "050f548e-9712-4736-add2-9251341526b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "53833a6f-4ca8-4698-9017-4660a1653893");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "78080631-558a-4871-afbf-e19bf0806dbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "a55aef1d-4dcf-41bb-8fd4-ea58fc55eba9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "93a786ba-335d-4024-818f-7e0f89fa1de6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "1fe06079-493f-401f-99fe-8a266a0eb7cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "95c94c82-4405-4d19-95f0-0777a73e9c51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "659c0c4e-6b81-435b-b09e-35731a270e40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "c455a654-7465-42f6-899e-61c63c79dcdf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "ad88323f-e29e-4563-beee-dfc76c13322b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "0672fe25-3645-47f9-afca-abff9a312544");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "bba2d5c8-e7f6-4c10-862a-c635a6992fd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "8bf37d9f-19cf-471e-9539-30393fd44805");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "c5cab238-2cfd-4d8f-82af-43f771d26b44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "0362bfa4-774c-4523-870c-5852a403dd06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "5249a074-7274-4ba8-b0b3-b27e59515237");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "c0654b8b-a78c-4251-9563-3edc3dc9baaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "26f1d2dd-721e-46ae-b5ab-227078977762");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "a12ac6b7-9324-45af-a899-db38de6c9064");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "221e1b69-eec2-4c0c-8fd8-fe4d668a4e7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "c7663717-afa4-4cbe-bd5f-0bd2d6f60f8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "adf2d847-256f-4338-a0ec-b97cc5cf6b7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "afe28116-a979-4a2e-9d6f-c0d3bfd35937");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "b151e2df-ff8b-41e8-bb44-8b4613ebda26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "bec468ce-15d8-4f5d-969e-8ec160662a55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "2102119f-0174-4c9d-b662-423ea94a2780");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "65f22ede-a459-491d-844e-22bdb8a87b7e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "c8ddbb91-4e8a-4f36-9932-9f47ec6a2feb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "22d8d071-12d2-4ab1-aa23-601cb31770d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "2327293d-c05b-466f-a423-239f0157a106");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "06c0904b-8e5d-4adf-8ea9-23e42413195f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "385fb683-6cbe-4130-97de-314596375b05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "8394f69f-ea4e-449d-a2ba-e6088cb381f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "1b39e4f9-03d8-47a6-a056-7d88c1910079");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "6f1aa1c7-f385-4d54-88e7-277d740b0816");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "e16b4dd7-6755-44c3-9f17-37321272d44b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "007e4224-4c2b-4dba-b130-089e8f9c4b24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "ab8217e4-250f-4414-a2d3-ca923fad1f20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "7d3779af-d488-4cf2-8813-42a53c664efd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "ec54fde0-ccb8-4fed-8c75-2dcc24e8998d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "cfaeef19-458d-457a-a0a1-c9ebe47b9e00");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "72ade8d4-644f-448a-8de1-0fcae5dd7c1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "26a8a7ef-8003-439f-ad89-3910d64c8c0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "0dedb158-4831-41c4-9baf-00cf8e271271");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "7d156896-b501-4ed2-854e-a289bd7a6ce5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "3a1202a3-b89f-4dce-aa45-9c3e7e6a5e5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "524f9826-ed48-44a2-affb-4f910f65912a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "2b445445-885b-488a-a946-46270083c2c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "22781574-5c77-4a62-8870-b120862bc5e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "fc00ac53-5432-4c43-9de4-aa72df722ca9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "718515fe-b3fb-4ad0-9566-e7381c7f3cea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "035ad29e-8eb2-4298-9ebc-bb2ff992a28f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "9fb23214-a479-4024-88fa-96ca736de7db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "df5c32cb-c940-417e-a4ac-8a20b3c240d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "ab4a7181-be8d-4cbe-9e8f-f24a76428881");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "2c73a8a8-a46c-4a33-b4ec-ad63b0879398");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "051f7044-e8bb-4461-904e-1cdf03e03ddf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "ef9c7a44-b2f6-46a5-9987-34bb3cd26a6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "32ba64a1-7e7f-44bf-b0b4-6cdbcac0d3fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "630dea89-71e1-432d-beb9-e66756cf97ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "9faed002-831f-4619-81e1-4fec8aefe41f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "efd1a4b4-cbd9-45a9-aa32-d0656a492935");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "fbd790a0-4607-4fff-8b4b-2e54b9baf19d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "551ae7a3-1e33-492c-b856-45cba3471a93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "cac847d4-2855-45ea-b902-402826fba231");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "5c815f8a-7a34-495d-9ff5-c87ce087a492");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "b770e1d8-488e-4df3-8786-3c4dc4400f3e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "7cea0137-3499-4a1c-85dc-fa7c0dc3e5cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "9858b598-8d86-41fa-8224-339712b2fd64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "b28bf659-5658-4dc5-bd22-f75500556a5c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "564d0d3d-d957-4cd7-a965-6fef10852eba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "bdf17dd7-3117-47bc-8efd-c56ad8ca5f36");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "72d2c093-cfac-452b-adeb-12469f0d689c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "1900636e-ff17-4359-846d-2b7dad7772cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "b1e284c7-9205-4f2a-9ab3-ff7c0d50182b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "71531bdb-9550-423d-b84f-17a567723056");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "0b2101b3-7709-4802-bc7a-a3bd223ccc21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "ec09ade8-ccdf-4e61-9e4e-8473a2ec9082");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "11f284ba-b2d8-4ce2-9453-bab82859447a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "eb01fda3-ce12-4b17-a731-dec3deb4f1b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "bf4108a4-8753-49d1-b64e-a7c000a338c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "85d3e18f-02ad-41c1-8719-a5092baf621d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "29233853-022a-42b1-85f5-c873bafe8b4c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "50f5ebc4-f3c7-43fc-9b46-89a6156fa6a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "58eefc2e-6aef-434e-9703-54b48b7fa854");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "75713560-b4e8-4e0a-a388-8a62669303ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "3235f902-9190-4540-a77b-97c8b0a68adc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "b8aa5894-1192-471b-b6dd-da931da96480");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "e83992d7-5e46-46a4-887b-0e17bea22015");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "5ed7e2a8-cff1-4718-8cdb-284e0b155a86");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "fac409c8-8bf4-43f6-ac9b-6669c9785ace");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "2af9d7de-82c0-4552-a2c2-bc94851ca6b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "e0cfff6d-9e49-449d-b99b-464547069d3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "d99d9e4f-8b80-4894-8a85-fef361a71438");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "de4feb19-2398-4393-803b-0acfc17b8ab2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "00c323ea-0b73-4376-9ba4-a3db91d17a80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "07330e9f-ae0e-4745-9684-71b7f77f4f05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "6aadbcae-92b9-45fb-b767-f0320fac6c8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "8a7ff018-b0d8-4e56-b3fb-fce1931a4d2d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "c21a1f45-bcb9-485b-b01b-3ad1f1448e71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "491bb14c-c77c-4ff0-8c52-0555b419e46d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "d7e16827-b598-4118-a0b7-4db0b5a6a5d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "5947f350-4c24-4942-8d51-04e689add6a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "60671da6-487a-4942-ac6a-75b5530261ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "e34d4c46-e001-47e6-8acf-bef69f3fd83f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "8a72750b-c1f3-42d4-a77d-4491529b0f50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "8f9796fc-f389-42e6-b624-c488e832a1b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "64b78d11-949d-4077-bd95-16f1ca520558");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "e5124da1-1b0e-4787-b82b-784302077b7b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "dddf4ffb-e89d-4ec5-bb28-81b784509c99");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "0154cfbc-a362-434f-8031-678ab138e9ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "722cb25e-4fe0-44ed-a06a-ebf6ba9c401e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "54c5cd0c-ab0a-4e66-ae04-381804b7143d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "f862dd85-6f71-442b-8c9b-23a77ee56ed0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "85a00116-3e39-4854-8189-8ecef2c995b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "555a65f0-1efe-419a-b9e6-c3fe697a08fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "f6ae45a6-9c40-4d5a-b471-71ecf676e1c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "e674a42b-07cb-47b2-83a8-1467600d8982");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "025c9782-ff0d-45fc-992c-94b757530ab5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "4586bf95-f053-4e82-a13f-f5106dc00b66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "9b53c493-1c3c-4093-a554-8286a4407ae3");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "0768b5e4-8122-43df-89cb-c017f162b19c");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "7b1ee071-71cd-4074-8fdd-3c4c5957d1c1");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "ca77c4ce-100b-4901-9580-6a50a9016f30");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "7344f015-313a-4d55-a56f-2d971271bee7");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "e89ca27f-822f-43c5-a4c9-34945d878e9d");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "bf2871f7-2c24-4234-a5ff-4d9c9948d767");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "eb968424-89f2-43b8-b83e-333153fd1955");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "5a8bb623-ae96-4774-8f9e-a69e8bb109b6");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "953920aa-9353-422a-8a1e-42b7af5d31e5");

            migrationBuilder.InsertData(
                table: "SoftSkillTranslation",
                columns: new[] { "SoftSkillTranslationId", "English" },
                values: new object[,]
                {
                    { 1, "Negotiation" },
                    { 14, "Commitment" },
                    { 15, "Assertive listening" },
                    { 16, "Receptivity" },
                    { 17, "Frustration tolerance" },
                    { 18, "Problem resolution" },
                    { 19, "Numerical analysis" },
                    { 20, "Customer service" },
                    { 22, "Leadership" },
                    { 13, "Responsibility" },
                    { 23, "Initiative" },
                    { 29, "Conflict management" },
                    { 28, "Critical thinking" },
                    { 27, "Fast learning" },
                    { 26, "Proactivity" },
                    { 21, "Creativity" },
                    { 12, "Persistence" },
                    { 10, "Teamwork" },
                    { 25, "Resilience" },
                    { 2, "Adaptation to change" },
                    { 3, "Decision making" },
                    { 11, "Detail orientation" },
                    { 4, "Planning" },
                    { 24, "Self management" },
                    { 6, "Influence" },
                    { 7, "Motivation" },
                    { 8, "Sociability" },
                    { 9, "Achievement orientation" },
                    { 5, "Empathy" }
                });

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "d86294f0-d997-4dfa-b17e-27b77b78e17f");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "5a9c9962-1b60-4575-a571-98071c10b7ff");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "cf76b166-d9c5-430e-b4a9-765ca570426a");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "fe0216fe-ce56-49e0-9c21-74afa951ed15");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "b1df91f8-6b42-4731-99cb-e399501911c3");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "70056bf4-ca7a-499d-9b4a-d262a3d9fd78");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "5c27dc2f-1b6b-4d13-b608-203deff967e0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "5f89d205-87d2-403b-ac20-59753743a780");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "9aa61c77-e8d2-4de0-a533-a1ee43b51728");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "c38a46df-e68b-4d58-af37-08f8ba9dcda0");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "c96ad334-28ab-41dc-9774-95d03f436571");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "5477f4a0-3d4f-41a4-a148-7fb38134712a");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "41b12708-a41e-4dc2-a8d0-57acdf51d1e0");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "e3c36bad-cf94-43c4-a97b-ccbcfec5ac34");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "378d725b-27d3-4298-ae9e-6fd61c9d3e84");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "6116af76-19a5-48e8-b497-c7b8276e63de");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "df983fcc-8474-4d5b-84da-2e565a3851b5");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "f3ba1a19-4eb3-49e8-9e82-741ef3bac93e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "515460b4-5533-47e8-b436-bf449592acb4");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "651c06ac-b917-4fd5-8f08-cb4fb68172e6");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "c7b149e1-aa94-4317-a9a4-0752f7ff8e40");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "3ad8f241-1a1c-42dd-8a41-51b234b306f4");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "44bfabe0-218c-4d67-ac4b-cfe5760affea");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "13c32c13-723d-4836-8ade-79df15b06dba");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "fdfe39a1-b2d9-4763-b637-6cbf610fc2d3");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "7df01559-063e-4ec3-899f-9e1e125d8ebd");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "3fd081f2-1e5d-40b0-ab5c-cfd683e1e182");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "2699aa08-f7f7-4ca5-9de5-2d79e68c54c2");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "41adfb2d-bbdc-4452-828a-ce72bca3cf42");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "cabd87c0-1aec-475c-b3aa-db26ad8c820c");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "a8d85e2b-7bfd-4715-9103-880b6a639ec5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "ba98795a-0505-40bf-86f2-8849052e61ea", 1 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "20bf7320-7e39-4c63-bda2-558c0fa0d373", 2 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "59b3cdb5-8010-496e-91b1-f3cd8327d9b1", 3 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "45548a20-6357-495c-a015-f3d405634801", 4 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "1bdeb673-fbfe-4664-b157-a1ecb5d67ab2", 5 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "45f208bd-e308-48e9-94b4-bea9f1f4b395", 6 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "f2628a26-827d-4ae4-8737-d7a89b46f862", 7 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "bca32e88-6333-456d-b2c2-030c212cabe0", 8 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "d4939a0e-7f85-4a0d-99e3-f683a51c7ab3", 9 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "a0da3a91-f958-4e7f-a13d-be1a6631e04b", 10 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "41c37816-979f-4fe2-af31-a8d0f8e0d814", 11 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "07256cfe-0777-40ff-89a8-704a09430f52", 12 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "f7c96b8a-5097-49c5-9c43-d0fce1a40c00", 13 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "98481c49-9500-4d97-9e39-8082f1889b35", 14 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "2821ea9c-a731-447e-91a5-58b95282a541", 15 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "16e463e6-db7a-4c52-9a27-06f5b6d9ff80", 16 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "fb01db49-0f31-4e10-b85a-a8ae57e586d6", 17 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "f5aad2eb-049e-4506-b71a-39f500f7f387", 18 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "998f81b9-4f36-4da4-8f85-46cc9fd94472", 19 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "2977492a-57a9-4905-8032-0df801138473", 20 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "4c836555-a350-463e-889f-8bd4eb23fd84", 21 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "1405fc98-29c2-49d2-9351-c916e460831e", 22 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "c142e06a-52b2-4be8-8c27-5cd20f1fe3ba", 23 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "3c5fc223-135d-4e0c-b6bb-ed7c8551cd81", 24 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "4aaf835f-01e4-4ca6-8101-65f269210e18", 25 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "bc873215-f42f-4979-9cf2-0bdb9aae3810", 26 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "64e5c888-4fd1-4a94-a84e-470227cf85bb", 27 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "cec2400a-71b3-4812-a551-d7c558657847", 28 });

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                columns: new[] { "SoftSkillGuid", "SoftSkillTranslationId" },
                values: new object[] { "a4f7e471-8818-4f0c-85ef-da83d4f4919b", 29 });

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkill_SoftSkillTranslationId",
                table: "SoftSkill",
                column: "SoftSkillTranslationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftSkill_SoftSkillTranslation_SoftSkillTranslationId",
                table: "SoftSkill",
                column: "SoftSkillTranslationId",
                principalTable: "SoftSkillTranslation",
                principalColumn: "SoftSkillTranslationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
