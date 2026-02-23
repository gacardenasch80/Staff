using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesMS.Migrations
{
    public partial class MigrationAddingRelationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherRelationtype",
                table: "PersonalReference",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "cd8ad267-25d2-4de7-8fca-8a073a552e32");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "3d384948-0f00-49fa-bc61-c6d17ece6c88");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "c3cd77b7-654d-4c58-85df-4b760c179f56");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "c2b9ed1c-fed3-425c-843e-92721ea69156");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "a262ce3d-ff8e-453e-9962-037502b002c8");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "4ac4be0a-0717-42a7-b3b0-f70e6e9ac214");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "57ce6229-8228-4d57-97af-4cbbc12b9b54");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "88eb85ea-4d43-42b4-ae2d-bf030638d739");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "af2e8d53-43a9-409c-9a0e-86845f81f4d9");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "c1d074a0-c5c0-4c19-b54b-fce036f9a718");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "18437104-f785-4687-aac2-42ae10e5d012");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "894d2b18-8f2f-46ec-bd7a-87895f5947b3");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "7517d051-41ad-474a-9011-f62d53904d17");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "e3e630ec-f27b-4144-9df5-7b5b7497d30e");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "3f2ec12a-cfce-4b51-a14e-e1af90a966d6");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "6e749a6e-88ac-43d7-a1c8-4f25412d9be5");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "c4d41845-3e11-49ce-b778-c18b0c109f71");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "d20a5df9-d834-491f-8acf-8b5da25e314d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "fc6e21de-bb58-4b74-a4b5-6b032a35e8e6");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "fc7ab467-807d-4f4c-a090-a4759a09548b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "be33604e-eee9-499b-a803-7adffab873a5");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "64210dab-1ec0-492a-8702-65fa924ae005");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "e7e2e8b6-3d8b-404f-874d-2bedff3ecc82");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "d2fdc2d3-bf8d-49fd-9843-3f3530d61dfb");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "58f22585-bf34-488e-9989-da5f4428551d");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "99eae98a-8ea9-4f3d-8b72-8f26f13d6176");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "66f8fdfe-1df1-4262-a6e2-14d443862d81");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "f7dd2880-1730-4c80-b63a-447f1dea6a68");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "4bf11900-1425-4ba4-b820-1e47b0c41ef0");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "0848ce49-4078-45ac-8a36-6e4e98d043b3");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "508d6cb5-7f72-44e2-bc4a-c24ed6d52401");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "8a871639-3697-412d-a6b5-a061cdebdd1a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "b015b167-5d49-46a7-8f61-9c56a4fbc6c0");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "e882fd52-740d-4182-b000-b161d31dd3d2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "feb17281-075a-4014-a981-d0d74155efa9");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "aba7c8a3-1c2a-4373-a20d-9ad7d478a818");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "9f91f10f-de6a-4abb-b50c-4eb306396920");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "9262fb9f-878e-4637-bc51-3ffa5171b076");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "2d7e5af5-1b28-4a0c-87f8-3e689b25952d");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "04867d4f-5e3e-475e-afd7-57a6a1220b2a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "4311ed2c-663a-429d-94cc-a33e6f04d8fa");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "a2d2de64-c9b8-4ae5-9555-cb6580d3e284");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "9e154e5f-b6f9-4b31-9f13-3fa2c1a59eda");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "e0db9246-ab08-4138-96c0-4fe151db445b");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "9dd2a44c-0469-4662-8b0a-af2e70636a93");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "632b4b8e-8529-4aea-99d3-0be59266a446");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "86b1f76c-4898-422b-9423-59e0c77759f9");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "e4debd8f-ccb5-481e-9183-56866948b336");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "a1139171-2b74-49f9-9a0d-84808b0dbbde");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "1b022fde-2936-46b1-9f00-2f979f989676");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "7d60a51e-5389-4b82-a952-3456a275b53b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "0eedc8f1-1ee9-4475-837a-9d2dbe384190");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "db759102-d16c-457d-b787-7f6ac32261ec");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "b8fb01b5-1d4b-46ca-af98-a2281f462e10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "c7726ae8-7ec0-4bff-a4ff-1c5da9ae1af1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "abc4e7d1-8e29-4ab2-a2a3-e704fe246dd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "0486e6ce-f83b-44c8-8592-1aa450b83955");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "865bef23-8ea5-42f2-b0f0-015e83712a6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "fa890c2f-d494-4134-a1d7-9cf599450fbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "20063429-4145-4f9b-8c78-a813e364d280");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "7d1276bc-c5a9-49db-8074-1bbf9736deac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "49a32ab0-8cc3-41df-a8b5-23345db175c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "89164d38-6ffa-4a91-a006-159ddca91db4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "02bea5f8-1d2b-44fe-bb42-2c770df52066");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "46f027a4-6f94-4883-924f-2b0a0a3d2eb9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "9e6cef6c-ffcc-4649-879b-fb34329df423");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "d9b78825-4a35-4ab3-a3fe-786353008e65");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "bf7af999-b731-4e22-8ca4-5e6903c97569");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "fa2c9162-cb28-44ba-85fc-2e3dee8b0d72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "dcc44a1a-c9a5-4bf6-84b8-e0b2eca08e89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "325e1b67-343a-488b-a980-10a7de794331");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "32b265d4-9d2c-443f-8127-8f165da37ab8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "f7b9ec6e-4f1a-4804-bad4-4969da903e12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "83ca14c8-6a5f-4e21-a92c-9d2c21984554");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "ec7e87d2-e2aa-41fc-9ed6-700a0fae6b37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "bc6b2c76-ec24-453e-9ad4-f3839e906ae5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "500fc79b-fb2b-4511-89fa-1ed0db0b93f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "7950aa9c-f085-435b-a8ef-b56ca737c220");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "4dc56137-fac2-41f1-849a-7ee9cd751583");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "9830ea1c-9ca3-4b69-bd38-bb894e2717b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "894774c3-f74f-413b-8390-a88d1724a62f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "a5042875-9cd7-4412-af56-2eaae4350479");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "7b1d1e28-0e7d-4ccf-a851-811a1b10e290");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "dd8ae2c8-f62e-47f1-94ad-cbe5690d0800");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "bb24142e-8fb0-41ce-a170-11e02155d534");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "801e739f-5519-496c-9781-a6a1c7155bae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "084a3b20-3274-478e-a613-f6b90b1c1660");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "3e1c507d-8a55-46a4-b02f-7827c3eaca1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "9ac52fdd-b2f6-4d99-9ac2-bd4d7067cb89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "3a1d70e7-b8d4-46f6-962a-49e8ff0ed273");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "e701227c-4a06-41c4-8d99-51796cb303d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "fe4d8a49-f25f-4a3b-abe7-4e7c1a1ce286");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "3d8fc91b-d0ce-4be6-9f3f-a066d8b9ee6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "f475e568-f4e6-4e92-a9ee-572c31a98408");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "98cccb1d-cefb-4dd9-99da-e9def3ddbd1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "ca03bab8-989a-4180-8ff5-355ff3c578c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "4022d034-2477-41b9-99ab-88d19c3b6d9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "154df7b8-2eec-40ba-ac11-d3f89eec0d92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "2c6d1554-1929-44d2-beab-aba15d85bb0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "931d3cd1-dfb6-49de-8d40-9be9a8e2ffa2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "2d46b5f7-cb24-4496-8371-9bce2ae73d63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "2a26b964-f715-4ab8-b662-0b46f7601ba7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "8bef97b9-c9c6-45f0-9207-820b5c5e820b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "8b90c1cd-586c-49fe-ba4a-0c86b213ac34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "b7f87d84-1e4a-4e4d-86bb-8d0289e1bb42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "f5b40417-ac3a-4fff-bdf2-027a5362aec0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "371b72ae-de21-42ad-9a1a-cdaf640b7510");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "13b65956-fd84-4876-84b0-02279631edd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "a75fb725-e815-4807-b031-150e30c27c6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "7a1bf7b5-3a48-44ea-87f2-1ca8c17b8c6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "89d33fba-07ee-4d7c-8683-61c71e18e3e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "71f45e56-023e-4daf-bcb0-dbdb7f96eaff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "a1b87869-85b9-4081-93ae-f87e684b7267");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "4ac9110d-bc08-4833-be83-7e723be1c377");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "b087a6b3-c359-455a-9c29-1336145b365b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "906830e2-7df4-4b26-8f5d-70068d3c10ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "c50a2ade-259b-4f6e-851d-d50bc880acab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "dbb232cd-00de-414a-bfb3-24a3846c2f75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "c33bd5e2-4719-40d0-8dbd-4f65bff10060");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "28ee285f-7115-4d57-afb5-399e87b405e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "7a06d12b-89e4-4dd1-9f93-7abb1447b8f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "5bbf81fd-a90f-4373-8ede-6494a0fbb416");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "4be0ac4b-4d51-4435-b3fb-3bef09852d2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "75946522-7027-4a28-a72d-7506e5c3855a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "09c7121a-a96c-4080-95c6-f6c03f6446d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "f6623475-869e-499c-8c04-72df2bac9309");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "bc06567f-040b-49ef-a922-f7c4364939cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "447cd858-8ede-47cd-9564-b68628a04e94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "a2f859d3-72b3-4a74-83f0-9ff136396bc9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "d6f169d1-5cb5-4b4a-8e09-7c486c3e50bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "00a8e05f-d685-499a-a2e7-d575155084f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "dc39f003-8c76-49e9-b8f0-506aff4193eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "2610df90-be7d-46d3-ad6a-419308059444");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "4de2569c-a4dd-440d-b257-9cb6a04d270c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "daea5cdd-8a6a-4038-b73f-dfe76495fc82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "40116545-cadd-4336-8437-0e6caa9bce07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "5a483c6f-2ec7-4179-9f97-f19a8486edfe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "67b49b43-6cce-4b02-9e37-7b948caa59f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "e5d146e9-2e50-49fb-ac53-e8c4ed8f8c84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "4f3cc66d-9bb5-41d2-8999-65c2741f4f89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "50c98305-f49b-4530-ab6d-25b6e0c51260");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "5704da4b-75ab-4413-ad51-a9f6c3cf782e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "29ce29e0-1e2d-4d5b-83f4-e481bd96a961");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "7911b1c3-9931-428c-9376-e9079ca6d98e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "7ef86b4b-06ac-4fcd-be65-8020d22a37b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "eca0fda3-5a0d-44ba-805e-4625280d27f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "a5eaaffb-5daa-4dcb-8409-4376250219c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "38f3ee73-543e-4aca-bf29-ca4a936d370a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "0bf1b430-417a-4dcd-9a16-bff5627b1c4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "f60178df-5d3d-46de-b930-2fb43aedb0a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "d576f722-2fb9-4afc-b470-3153b88199fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "f0401012-7aa8-4efd-836c-9b4aa6312727");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "dc658801-34fb-4de6-8176-6b715c64e905");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "96dc878a-77aa-43ec-b8a3-a9f4d30525f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "400fde60-a043-4d21-b419-2f33d8ce18f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "0314f1c2-3bf7-4a08-a953-f2d3ec9783c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "94325336-9334-4ba5-8bb2-e7c4fb4a8d77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "5c9c5589-1384-4baf-b214-0ce2a7280f9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "633445df-d4e9-4d20-82f2-a8375f0cc7a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "872c1059-0427-4b46-a6ea-b11a5d73204c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "2aba7bd2-bf2c-4db8-b40f-c08532ac2c35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "4990b64e-9218-43cb-831d-62ab7b86116c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "4894cce5-1134-4929-9f92-bcd6326b8c2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "fca303e6-bf9a-4d43-83c9-e673cd7c56fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "432a386a-6afa-4482-bb6b-29bec94698e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "ea075f3b-a400-4fe1-ab61-0dad762c3b0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "2ca70e87-08c5-4978-bd01-db3ba3c5a6dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "00e311f4-8929-47c8-9a2c-a699b6c95c3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "6b7b0661-7b9d-4bef-97fb-861211ada0e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "730336dc-9228-48d0-b32c-c5f8bac66d35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "0dc44b26-1333-4c62-bfcd-cea2013251ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "97e156da-28d1-4497-858f-8c8c702813e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "92ec95e0-6b0b-443b-914b-c81da68c5f0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "3d1a36ab-634d-49af-88fe-c54115d26258");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "0815364e-b853-47a2-9485-a28b031f7229");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "5fd8eaf5-8008-4a82-93d5-d1e287c1aa14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "7dd8ba31-c79b-4076-875c-ee638f43f911");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "dc627f27-5152-4508-a511-9bef37b9c8aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "f002b7ea-cb25-4aa7-80f0-b83b7ca3d2ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "0f6e0116-5341-4d1d-8634-7e5aeb8b36df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "579a03a2-c3af-459a-a60f-a6bff68ee62a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "84f32c69-8a3e-448b-986e-043ed6a02360");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "4b2dce86-394a-444f-8f73-24296753a09d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "0b6453f7-ac21-479b-9fdf-4425ef241a52");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "b9ab4e6f-bc3d-4a31-ac7b-efd4c452691a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "a94bf85e-bfd9-4443-9177-0e2c00ec9056");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "d9b84038-a2ef-43fb-862c-38b99d71c419");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "fba18315-5d09-43a4-8af9-8fae20c9f386");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "59ef5d4a-0892-49b0-a5d9-4825a6e2cb52");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "b1695f23-e41c-40f4-953f-33715e843f7e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "00e26f71-b1b7-4c8d-93a7-3d60dd24decf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "6248705a-cb19-4b11-a5ee-41d6238deb91");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "e6777d32-3789-4917-9fe7-62c07314585d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "2b6802dd-830c-456d-bdfa-cc77d561171c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "8640e4c7-0d4e-47df-a36e-fdf24f4a995d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "274dc22c-7f6b-4a4f-8621-3dafd90641fb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "0313cbee-eb34-4f23-a71a-760b86bd51c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "bb17fdfe-6b04-4aad-bfe3-fc1a237c05d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "1dfe0036-09e4-418d-811c-17011f491028");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "f054b1f5-d7f9-4367-92ac-1f2fff6d3450");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "4e03a5ff-2046-4084-9071-cda377f95436");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "e608d333-c0fd-4c02-9d63-c30ebd12b0ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "016cbcd2-3f85-42cb-abb1-0c9fc10071b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "a1620cba-06ff-4684-9a8a-68fc63e85524");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "cd9ab2d8-3b65-4238-9730-11d83e9a301e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "79ed2813-febb-46d6-84f2-be582a5238f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "b77cdfc7-d612-499e-a66b-2b50f2840d3d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "3484fa7f-541e-46d5-9dcd-c1c28c0297c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "f98163d1-fca4-4d6d-9729-6ab25980827e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "7205e709-93ee-4a25-a042-bc0241ef30e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "e628de59-bf4c-4d30-a3fd-e783be3d9dcb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "c1219493-92f8-45b4-9974-c188f50d2b5c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "b2d9cf3f-b96b-4700-8d8c-5024b96367f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "0f4f78c1-325f-4a8d-b674-1b31a574c8b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "16ca4829-e01f-4d03-87c3-9d62b1f7c5dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "013356cb-5475-45d3-bffd-d4383d0c91bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "11939c1c-ec0b-40a9-9cdd-78344f294eb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "d53e90dd-fd96-419b-bcc3-e0badd3f6671");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "d2e8a7e0-5079-4287-9384-f8a91120ba82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "a5e3f6af-7733-4985-9d4b-35da16724ec9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "879f864d-0657-4ef7-b669-5619a1d9cdaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "3be45620-c38a-4f03-b5ca-ac74967d8af4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "c602c709-34db-4a7a-8117-203763e21616");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "a0dd2163-e036-4073-af70-d4c6f48c104b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "93669150-1e8c-4fd2-ba80-72e589ecdc2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "a2464251-1871-417a-8939-81c46a24ba1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "2f1cbc4b-2ac5-42c3-abe7-06e3ff05e075");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "70df94ce-2022-48d1-ac35-f0b7442afe65");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "76093f22-d8a5-4d46-b863-879ee6516f54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "194dcbe3-9b8b-45e5-8f20-aa2d203438ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "8b01aef6-8ba8-463a-9cb5-ee389ba4f5f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "0792bafa-b2af-4c1c-8585-a4647e638d9d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "114dafe9-18eb-4c65-bbfd-b694c47d2f42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "e7ed8823-bc35-4252-ad7a-2da39ff3eae5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "24d7d209-8742-4dc4-bb1d-8999669f9756");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "10c30b80-7716-49ac-b54b-6c15e48f7e12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "fb202367-d1b6-4839-bc78-1a2d83c4a64e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "5bcdfbed-9976-4a4f-835d-2d59c20ab602");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "f72b386a-377c-4d31-a587-acb55cbcc7bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "78e87bb4-1331-463d-a7fe-3abce0fb2d9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "17af9439-3d44-45d4-84c9-2769e9bcc25a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "88703596-94f3-4e0c-8a27-4adf6e171e29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "d4d16885-e7a4-4949-a143-3e2d6dbb2111");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "9ce4091f-41d5-425b-be87-451e6f8064a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "0b94e512-58fd-4a0d-a511-0959756ebaa6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "286057e7-0f5e-4b9f-8a18-0dda9c0b99e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "7e0b1018-ccc5-4f01-97b3-bc0ab7b8c7ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "89992aaa-7b95-46dc-98cb-8e13c46bf727");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "150fb968-5669-47e5-89c6-0b18591c0f7e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "964832f9-a73c-48e5-a26d-b058564d0df5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "6d4f261c-8772-4dae-8718-9b31c0a6cf33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "4506ebbd-13f9-487e-9817-dbfbcf286b6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "143dd6c1-ec20-4bdb-bd9c-7e50888f3cd3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "bba45e47-6114-405c-bfc2-3d524c1b7b7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "941ebdd3-4428-4ba9-94bc-bc9ffdd728b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "6b13cd55-8bcd-4cab-aee3-b4524f031f5a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "7f4f6741-8e78-43be-8c85-67858d607723");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "19935c0c-fe05-449f-97a6-d6ad56990a5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "6bd9d884-6d56-40a9-b01b-f16089824fe1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "d6a75a07-98bd-457c-8651-96a7761012f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "86b24512-3e90-4395-b7c6-76623e720fc7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "31a35de7-6589-49d0-839d-01dc31e36bec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "1d013de7-eedd-4dd8-b78e-b16c0f575fae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "9df2b76c-20b9-4a8f-badb-a59c8e26c6d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "7a6e1049-1ce4-4d53-9538-822a51781617");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "e45b596c-9b43-4c24-a4c4-88c7de99990c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "8424b255-e157-4256-b29b-3d064052a7e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "65c153d4-eae1-4cbb-b378-011be8238b12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "b8f2b14c-106c-43c2-9953-85d898c2c3d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "e900b0f4-a34f-4a3a-a742-bfea0f7cfbde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "04256e3d-bcb9-4696-bad3-0dbc7607b750");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "55daf7c9-e0c6-44bb-b8f1-af5ae8518b45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "6b38a206-596a-43d0-ad99-0bf948b54a53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "de7364b1-b58a-4592-9163-aa365c08ee53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "f794ebc2-67b7-491d-8c50-20de0cc28124");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "c671d2c9-77f5-4f91-8d2b-aa12533a30d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "3427d5db-61ca-48b9-a675-989e527b8341");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "f5cc8ed1-4503-41cb-ad54-d2b32a25b8dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "c2dfaa2a-2b2a-410e-90d4-7ce7c7e24f74");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "61b29995-093f-45e7-aa97-7fd28f90b246");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "77840c2c-79b3-4592-96fd-0e006424746a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "50cb4049-6867-4a55-a1a8-95f2df7c8abb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "b6655f70-80a0-4c7f-9a2b-6f8ed45af670");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "18529488-c4ac-4516-8990-554f5d88922b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "e1d32d36-b682-4f35-a1df-3835daba8766");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "f11d4e4b-029b-443e-b703-608401872fe1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "b4c2a410-7124-4211-adc3-b5e71c6d6e1a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "ce3ff7f9-195b-4bda-b786-a5bd7aec8d09");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "87393a75-4bfe-4c30-9d8b-15adb504819c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "6a4fd30f-d696-4a83-8349-39a9485126aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "5aeed856-b08d-45d5-95eb-11a3a6f558fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "38f51130-87a3-424a-994e-23b4e52e90a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "d190d987-55b8-48e1-9293-80820419f4f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "8e127280-1c8c-4c18-ab9b-95b604a65bc8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "3e7367c7-96dc-4a54-b7cc-3f67a89dcc7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "16f060cd-2ebd-42f1-9a29-0fbc435ac95f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "99fe2d72-389c-4928-9844-f117b8e4a5e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "c4c9d6bc-4b37-453c-885b-1bd038f0f87b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "19d31325-ec6d-48d7-a5ca-2d9f86adf5cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "7de58c44-01ea-40d1-bfd3-cbeaa4fc1046");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "84235246-6e63-4bd9-a699-b1df9f2e3cc2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "bbc43ef1-ae05-4b92-bdef-4aeecc0af6e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "ed05b78d-5a03-47a1-96d7-b38b0bbbaddc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "bd788b54-9d6d-4717-aa51-0e61d8e3b739");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "77cb8638-4b04-492e-88c7-9c0eeee7ed7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "5a3aa5d4-58a4-41c9-8c4d-b0f97cb8bee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "7fdf97bd-38a0-4bb3-b17e-39bb08312089");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "17e2efb0-f86b-4d4e-b145-f9106b79cccd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "25d0af38-9de5-4611-ae79-12f205cd9c0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "0c055501-ce29-41b7-a193-267ae0c2b237");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "2a511925-cc43-4776-9557-450b60177437");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "5c42e6f2-b912-4b10-bd25-13270498b2de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "ff3c064c-3f0d-4fcc-83df-4dfa5a40c906");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "63673e74-8447-4f77-b5f9-7835376c39f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "8b735b24-a89c-4a00-8810-494f93136a13");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "84850f01-c029-4d1b-a946-53d13f2da51f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "e7af1ca2-ef0b-40a2-b84b-a29c4879c6b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "f76d5cea-f5fd-40ec-94a8-38f7bd930853");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "00e0b9b2-281f-4eed-9ab1-a06302804008");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "e7e8ff08-f3e0-4916-b8da-0082cf15fb57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "26a1293e-6995-48cb-8adf-789acd8f9e1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "18e7f54c-b623-4adc-89d9-381cf4350241");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "af329726-730e-4d2f-bec2-c7647c1f4dd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "c49330ca-dfc2-4082-875f-01a7e780f8ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "930073f2-b265-46bf-a7eb-b3b885c1403d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "3ae79706-b0e2-4768-8078-c8843c2b13e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "1239c736-f533-4cf8-80fa-7a429982a3f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "12b33d4a-af94-4dfa-b2d1-60a3863cf860");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "039660ab-855e-4257-85d5-10a206108321");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "edb7d5b0-a699-4567-b758-898cc9641bbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "537178bb-4420-4706-ae48-fa9745cb27b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "b3fa3acb-b79f-46f6-a585-37a2ae8b36e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "f551c81a-4a2b-4f7d-b771-eb60dc5f58ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "7b6bbf9b-dbc2-48e9-9491-18d8e368f04a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "95b5878e-bc45-4ed0-aee1-f0368f1b6dd9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "7abec1b7-233c-4cf0-8f56-8ecd0e796062");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "34a4eb33-6f33-49bf-b1f3-915da49ba624");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "a2aac2e6-b1e2-4eb6-a4fe-86ca357a494e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "9654153e-7e09-42f2-bd9a-533ab1f680f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "2b743d43-8674-40c0-b89a-f2c600bf8345");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "9f5ffdde-e157-4253-850d-fdb5e6146a92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "fc764956-4b2d-47c0-9cbb-4bd737336e72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "f45594ae-703c-4394-817f-18dc21c548b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "0ff836fb-e41c-49ea-91be-ef7e375c2f19");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "ead5efd3-a79d-4ea1-a845-f4bdd9108593");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "9a48f76b-83ff-475b-94be-254064c9a9d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "940f61e1-ff2f-42b1-a171-cbb0f7682e02");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "304df69d-d103-407a-ba16-057762933833");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "44f4c47b-3742-42d9-b967-b6b6934208bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "ba8595b2-aa85-459f-b859-4c6b4a348ae4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "71e1a56d-f0ea-4e65-aacb-e64139860560");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "e2fd187d-3438-4f8e-b787-661f97b06c64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "200b6860-798f-4836-b2f3-d305441300c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "77cdbe73-5b49-4578-81ab-b204ef7b2daa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "dec6b2b8-fdfb-4b2d-8d34-c9dcc038ad70");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "df56ca28-76c8-4314-8d61-e994da7da38e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "284b3022-2c4b-4de9-9033-6da876181977");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "03ffe2d4-8c62-4049-9a21-526c74951a34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "fe907134-f1d0-4503-8614-bcaca514ae20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "1523f23b-9319-4248-b027-cb4fe44b64e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "4eb1d8dd-c115-493d-9364-cd840b5334b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "8c0e4ac5-3b72-49b4-abaf-e74a0b737ac4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "9d46446c-c05d-4da5-8d5c-c461f31ec0f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "e12e8329-2daa-4417-9442-aa387e2e5ead");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "8185a040-43f7-40c3-bdd4-32f21c4f007e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "e22d07de-7dbe-4620-b506-eca5e6855f98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "35d29e60-9ceb-4f7f-8706-d61a91f72721");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "c3c7b55c-22f4-4621-8d5d-ff80913eb400");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "c47b262b-8a0c-466e-9dae-dc471db2b89e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "e23acb47-e38d-4602-ac67-34184f3e8210");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "4dcb19ba-90bb-43ba-8d01-8f5e3dee857c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "d114ce41-f65b-40e7-be98-8f4831b81d9e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "3af92ec1-bb4c-41d8-a055-587d042bf8dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "17ac860e-13d2-4389-9dc2-9e2433910104");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "5d76efc0-a2b0-4234-819c-ff6f306fff22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "ad4d7a1a-908f-49c6-ab58-ad49fd042584");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "3d1e697e-9028-4aad-9d18-5efe67d7152a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "fee5cbdd-b67f-4f46-b52e-f6efb16532c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "da00d174-01cf-4976-80bd-a34a6d5c1ce3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "0932a7db-f066-4bd8-874c-1540bf3e51ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "ec5e56fd-be2d-425a-ae06-637bb3666dd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "72de53af-9f99-4e47-a45f-f3e508144918");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "a023d08f-a61d-468c-bdf3-0aeb3eaf60d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "a03d82fd-91d1-4f79-a416-9730b6d01ec0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "7fad0770-1091-4b5b-ad9a-d24e3dd92d04");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "caacedbd-fb16-4017-b15c-c9b51f8934e6");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "c2e92895-6413-475c-bad5-8ffbdc9f3f60");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "0aef0a61-c183-4cb6-896e-259820d38f65");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "64f6281d-e395-4b90-b128-40171440b866");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "360b1180-c963-41f1-bfe3-317ff2fa7f47");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "117da347-6942-4939-bbe0-2e3705461254");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "bb97c2ad-14aa-4e2e-ab2e-15597ad22af1");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "faea500b-efc9-47b5-bdfe-76da4763ebf6");

            migrationBuilder.InsertData(
                table: "RelationType",
                columns: new[] { "RelationTypeId", "Name", "RelationTypeGuid" },
                values: new object[] { 4, "Otra", "1d1c9ca6-b3fb-4e72-9a56-5ecbedcb9464" });

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 1,
                column: "SalaryAspirationGuid",
                value: "e1f8ec71-df92-4a55-838b-a04dd618fa04");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 2,
                column: "SalaryAspirationGuid",
                value: "152712fc-828d-49f1-8de3-1cf34abe51dc");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 3,
                column: "SalaryAspirationGuid",
                value: "3f8a7085-c34e-4154-bbd0-b81e0ef44c3e");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 4,
                column: "SalaryAspirationGuid",
                value: "9f7ebe8d-d1ff-45d2-b76c-080020a927fb");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 5,
                column: "SalaryAspirationGuid",
                value: "e27b67c1-4565-4f94-b5e8-8682f7d5bccc");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 6,
                column: "SalaryAspirationGuid",
                value: "24ea640c-8911-4df3-ac98-2d77d8725e89");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 7,
                column: "SalaryAspirationGuid",
                value: "9a8f3e81-2ab7-4bd1-a48b-8238dde58071");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 8,
                column: "SalaryAspirationGuid",
                value: "210c9045-de46-4c15-b499-fbc04101a841");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 9,
                column: "SalaryAspirationGuid",
                value: "82bdafdb-d908-4d9b-9629-3c1d3bb6baba");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 10,
                column: "SalaryAspirationGuid",
                value: "0d07ff90-6b81-44ea-8b3b-1a2f79c9c673");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 11,
                column: "SalaryAspirationGuid",
                value: "bc6d12fb-7dfc-4496-98ba-fe7862e6aa9f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "6fba3c94-7a2f-4136-a633-3a03487ec4dd");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "0f4ffb84-3c29-49e6-8732-f37676fb1a07");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "23953f27-7ded-4deb-a0f0-6e115194a43f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "34b17254-44be-4200-b297-17f1e928fc59");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "aa9c2012-23e9-40c6-88a4-6431294d845d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "ba142d47-41e3-46fd-bb17-d4d0f351bafa");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "811b8f36-ea64-4f42-bc44-c86b864bc26c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "32081bc1-3478-4eb4-a7bb-ddc4b6a6d0d6");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "a6a2f3f7-0d94-45f2-a226-c5c06e4272b6");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "3414666c-d261-4011-b01d-78c0fc786fd1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "d70b13f3-b377-42cf-ae72-d4b166cd3441");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "afb6f0df-8e4f-4c1f-8345-79305d3d71d8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "ea6b4b07-6f43-49a0-b227-3937b4465ff1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "7ac9d30f-9028-4bda-bfac-2553bff3b64a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "1c2325bc-d025-49a8-bf41-71c5f33e1db3");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "76a5e803-68d2-4ee4-bc29-6c4758d73d22");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "d090f4c8-479f-419d-9672-2d9229cff290");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "9f474cb5-0918-4e44-8360-1fa9b1213b17");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "2d42c0c4-090d-41fa-b844-db7b5f8da5e2");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "1f86c00d-848b-4032-baa0-342923128237");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "2eef91b3-0d99-4ec1-8e7f-d748ac5e2007");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "6eb517eb-de33-4a41-87ca-5b975f51fb67");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "4212e5c7-bd87-4819-a740-46b2d57a8385");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "0b2b4a24-1033-482a-a175-04bca4b55d2f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "0efad471-78c8-416c-a8cb-18961fac3e3f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "f9f48e6b-97c3-42dd-9ec8-7b5714cf4a0d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "dce4b280-ed66-4d6e-9625-809849dddca2");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "420189b0-bed4-453c-95d8-275760b49a67");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "7f3a4e24-e00e-4e5f-b3d2-ea2abfac7411");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "9d9ad027-0bd3-47c0-bf2e-e84af37563bb");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "e3d53cb3-fa24-4fda-b8fa-34bf54702f64");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "5ec97b21-7351-4d0f-b80e-6156fd9a3ed4");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "62e1560b-2cc0-4f46-9c41-848d0d1cbc0e");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "b2184e67-5bc6-438a-a813-b09543f976e7");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "9540c033-d335-4055-bc50-f3639a4e57dd");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "87898aa5-5055-4121-b48d-c6fd6ea527d6");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "74e87944-bffd-4623-a82b-5a15a522328a");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "3512e82e-58a8-4376-9763-8a2b1afc86c8");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "1fb1541f-7523-4928-b6b5-f17e7513fcfc");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "906f8fb3-94fc-44df-a97e-006f5b6a6cc1");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "6de4374b-0ac8-4f81-9530-1f561121b7a7");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "5bac19dd-c8b9-454b-a03d-d2278b45c9ab");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "10307b60-044b-488b-a938-4c9a14e2a429");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "399a1099-5dbc-4b9b-861d-5081f21e6d42");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "213f2237-308a-494a-84ef-f4810fe811ab");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "c9c813a0-3a54-4886-89d6-ff60bdb66157");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "d51375f0-13a3-4324-bfd0-7ec248af20d9");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "1f721ac2-1d0f-4c19-bf86-64ce3d68831c");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "d570ca7c-f6e6-4b8b-8898-032ac4c7c97f");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "fd855204-d2f0-4665-8f4e-66168f909518");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "3b4d24ee-095f-40f2-b957-e7f0b679d3c2");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "1523ac1b-ee40-4849-9457-43cd100ed9af");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "79897169-d660-443b-ad83-cdbb84dc65b4");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "c6e1cae7-6a86-4d46-bd97-0c889c976451");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "98a5902a-ca16-4e14-8e46-c9790fff416c");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "95fc4fad-63a8-4c1f-bf1c-2530423af280");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "4420fd7c-6788-443c-ad03-5890da111662");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "f4ed2dda-5609-4198-b33c-6c043f573aa3");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "63b6c9b3-7dac-49e8-a0ae-3eaa3ce3a2e4");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "6a85502d-89b0-4392-85ea-a33785550849");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "OtherRelationtype",
                table: "PersonalReference");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "3f684b91-b850-46b5-827f-7903c370ca0a");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "2a0e999e-7e31-49e2-b43d-44d2a4923ce5");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "66914de7-1232-4774-9be9-594eae8d6f21");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "f8195332-3a9b-4b53-bedc-786ab8a36d47");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "6e9c3d7f-6315-4133-984c-d09052cd6306");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "c8fe58a9-57ad-41cf-ae3b-874ee1058c1d");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "e264be54-db93-4731-ab19-8adb563fd960");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "9663c330-b49d-451b-9cd2-b52c3ce825d0");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "b7677da0-8652-4882-a858-e9699a786837");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "c7c3c113-f3bd-4e12-bfab-7757b64777dd");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "4d3cd802-7abe-4372-9dea-286722646aed");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "ef769dcb-63c1-4d22-b534-06b10ee9658a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "048ad4cc-a1e7-4e9c-b691-cd7350590917");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "c59043d0-562b-4264-a645-3120ababb7ba");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "e729fa38-b22f-402a-9966-1033da1464e7");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "5355e41c-5fb6-4efa-8b38-beb0830c3bce");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "aebd27d2-4f78-45be-8957-aa55198a5bb2");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "8906163f-b340-44b6-8aca-713df48c5eec");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "f998af9d-9461-4f69-8b54-3839f55cccb8");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "d4d36292-c254-4eca-a14a-32244b970f12");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "f6aa1af1-ed17-442c-9955-6144ff583014");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "101bfe7e-e701-4a4e-a11b-84184e148a43");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "4cc93813-990e-46f7-b180-c5d845a6b938");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "644531e9-6399-466b-9cda-86b8b48a438b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "1469fc76-1b4b-4d24-9fec-4b309dd17472");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "85b148a5-c2cd-4cc7-a1b2-660e92221193");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "c9b8cba4-9f56-4ead-a2b8-7e42fdaeafbe");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "f59ef42c-cf31-493e-9051-de45a783f482");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "d314b8d4-b510-472b-84aa-d503a055ee65");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "556ac00e-7e8d-4734-8d42-667a9f2e4baa");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "f96f3490-f3fe-4559-bc16-8a7f8e499a89");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "7e954aac-e835-44a4-95e7-fb810ed4d17a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "c7ae9bba-a4e8-4cea-80ee-0f3fd41066d1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "722e86d0-62cd-4340-b1e7-5bae60db987a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "20a14dd9-51e9-44b9-8aa5-9f4c7fa332bc");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "451f9d4f-1a22-433e-8121-fe25cf6098b8");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "bbd6bb4e-0519-44f7-9482-614cb5dda8bf");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "6fb3957d-5866-4ee5-800f-fa0f47242c00");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "b2ada334-d9ea-4b5b-9d49-d17a8175fe98");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "063827b2-b502-4dbe-acea-0b077d8ed559");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "edd8e999-3ccb-4d21-bd46-ff3b68ae7d58");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "59d327e7-1689-4caf-86be-ad3ca0aec281");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "6f436e44-1354-46b5-a510-9640200f4418");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "e8f4ab5b-5350-4955-b58d-6a785dd33827");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "c79a2eac-fa6d-4aba-aefe-0f4b64810f08");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "f0ec40e4-14df-4f11-b35f-cb0576de5909");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "fe8b2784-bff0-440d-b76f-eecd5a3296fb");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "7752a0fc-1105-46e9-ae10-b23e40bec33e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "7820d483-4e90-4b28-803f-9de71c60eb42");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "3a7b18e3-f4e6-43dd-8e3d-252918db4ccf");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "07e42826-bb5d-4329-8d5a-a7b1d7005b2b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "5b988161-5ece-4e22-90ab-ee38fb8c7b64");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "f252dac6-3f15-41ba-8738-5e93e800a24e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "7e15ac2f-810b-4ed9-83b7-49d3280f471b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "3329e814-9ac4-40ff-ac4a-425f7a7792c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "52cc5499-9285-4211-9717-33754c6e0701");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "4ced8525-3eb3-4479-8fdc-60729d68949d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "b8dd8504-fa97-4440-a428-c6e01ef67b1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "daa33c26-a7ec-4215-a882-fcb5c19d6545");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "825b8d70-1942-451c-b0f6-25328657a775");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "006e9e23-eea1-48bb-8ed4-0c1ca36f3758");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "408ddbbf-1276-4f39-bd44-e8d81f97dc78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "8c9f1fa0-2b75-4858-83fb-05eff05370db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "6599b59d-b622-4d79-a9dd-522fc9c5de92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "9ffc2b6a-9646-4e3c-9939-733585d1d12b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "1dfed900-5f4b-4268-b152-0b84afc2ac67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "704a34a5-19fd-403a-a1d7-881a2251eafc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "152fc31e-6ec1-4eae-a695-3ad6894f3475");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "4f94a968-47c5-4b04-92e1-cbaffe8257d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "837ac547-7a1e-4eae-b184-9a441ba732e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "c08ada11-f89e-4ad0-b8ce-1644d7d6cbca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "033cf38e-f8ff-49f3-9c31-7e780f6c2719");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "7c7f0248-67a6-4366-9d3c-fa64df4c4834");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "da18c5f8-1723-4acd-b0bf-ba185ddf6c21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "b9dbebee-f4f3-4b2d-b3a4-60bfe471bdea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "a312a7cb-d247-4dc0-b2e6-9c14a75944c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "46aefc4e-2fa2-4ffc-98dd-6d322d522dcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "c799377f-2cfd-40c3-ae80-803ca376e170");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "2fdb73e1-6a69-4ee5-9ac8-e026796b3090");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "58fedd60-c30c-4004-9bc8-0c091214befc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "1b907b47-b4cb-4f82-89f4-16253f8ae52d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "6da41312-18b4-4402-866d-755d42c03f0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "c9d6897e-aaf6-4e3e-9540-c317778f32ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "f8b4f21f-bb38-45dd-9da5-55098ae05d60");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "849d08ee-af06-4190-910b-0e8763e737ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "c5dc5300-cb34-4c4f-8ace-6d98858bf1a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "6d023a7f-f69a-422e-88db-1e1451a1986d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "9a5d1b8d-d0f3-43d1-9b4c-e559a29bfb5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "35498d9a-2820-4be4-b32e-b3992a600125");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "c7da8cd0-5c1f-44d0-a11d-32a18bda6b56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "f1c49379-3cd2-4bfa-93e2-96e77a668381");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "78b784c7-8e78-40f5-b270-b740429e406a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "c216558b-b31a-4899-b043-5cb56d389403");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "adba89a2-fc46-4f79-b705-a4adbdc463f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "fd3278e6-7619-4cb4-b4dc-fc384077adf5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "7ab52b4a-8c75-457c-9556-2ac552ee918f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "178d8ab5-f482-42ef-b48a-cb7501ccbdcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "1b8adb3b-9c99-4dc2-a280-2ed3c50356c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "8011790e-1fd5-485b-a673-f3d1dbce3e1e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "d093e376-9679-4ad8-aebe-07f535178059");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "239f8804-97ec-4a1f-b9fe-3eaf755208ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "9db599a3-9339-40e5-9520-73786a74e3c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "1cf8fe59-68ae-4d1f-b9a2-8ab8b4699e73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "7640069a-1cb1-457a-a418-76ca678c8a30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "dcde89b7-e698-415c-a0b2-8ee99e1c2af0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "3885942d-d630-45ec-90f0-e3f0c8ccc427");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "a9e5fc75-6e69-4dc7-bfe0-23b194e0d07f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "d3500df4-d34b-4ce1-909b-c21cbb17a040");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "be557f7c-1961-448b-b23b-b049afec52fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "c50dd16a-07f0-4bea-a096-ab7a5e56893b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "85f41c0e-8b3c-4096-80b7-9770d958d2d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "59862e40-15de-4e79-af63-59baa0faaeb1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "5c81932e-424e-4093-85e1-78e928bd8d80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "0782a7fc-ebc7-48fe-b5a5-35a9a68bf88e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "54eb4a3f-32d1-4e38-a67e-95eea3aabf06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "5c62720c-af41-4c0f-8c97-0c0b77a3aef9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "7740502b-c23e-4739-9234-2a578af247b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "52f02856-7958-49a4-986c-e44b7a8d609b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "248653a8-324a-4523-89ed-11f9c50e2730");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "d6469312-a2fd-4c8a-8021-8a23972616ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "1dbb182b-57e1-42da-8880-51418c1b7a1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "d605079d-ce1c-4542-8f41-2cb95a666607");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "495dc4eb-f87a-4c18-857b-ec6052ea9f9e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "bed8f45f-0b5c-4b79-be90-7f647e384e6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "945bbe5d-da94-4df8-bc5d-fbbf977b59c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "e2bca20d-c2ad-46f6-a70e-9932b68cf37e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "a62a989a-b125-4087-9882-3eafd54f87a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "803ed31c-027e-43c7-9e49-95584988d9b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "9661d0fd-ca6c-423e-b894-0c9e17678fa6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "592352a0-f41c-40cb-a712-77e5527f8d0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "7fa00d51-a585-4c84-8a17-74b9c53f62ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "868bbfe2-1af3-4d9d-af3a-6f3b32d196f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "fccb8e9f-077d-4147-930c-20e11d901a46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "c73b5f37-a06d-4ff8-961a-57dd521669a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "0b7dec0a-e5e3-4e82-8b65-405085fd3874");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "e7048b57-e124-4e7d-ade7-a924f401af57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "34fda004-ca64-4759-8f41-c20c1d88052c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "0cb53fb8-c819-417b-89a4-163da0e6b9ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "15c841ce-5445-49a0-9424-63d7e6fa1ed2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "321187fc-e0bc-482a-bc9a-4e088643abee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "3c3e113b-ceae-4237-b3c1-658d8581cef1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "7b2d81f6-d256-4797-8b6e-dd3833241155");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "dbdb3748-2f08-4808-8c17-741ecb14d741");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "d32e32f6-1315-43ca-be02-e6d08299a8e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "e6009cab-85d0-4b71-8c8d-dc84611f78d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "71f41098-9683-4747-9a6f-ef5c8fdb53f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "b9a339a1-1dee-4aa9-80b8-d879901ef5d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "577e92d8-5f10-4f9e-abab-0e935b307e67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "b425cdfc-d4c2-4837-8eb0-d62d49348ba6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "7d813782-fc5e-41c1-8445-4e14b5a57975");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "6cc3f3bb-a53e-4245-9cef-63c4e7e61c43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "9e33a041-14e5-4775-9b8d-e4d455aa25f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "224b8848-723f-4f61-9359-13d5db5da9ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "b363d2fc-e5d9-4253-8021-6c5977d599af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "9c80f5f4-9c97-4432-bcd6-52fca716effb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "e156038a-d641-4517-8769-5c9337e9f1c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "5a8a0b9f-3557-4565-9572-9a8a5b9bec91");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "3a2efc54-95de-4728-9af3-857892665d07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "3a97b3b8-56b2-446f-8c41-6c292c776092");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "8dfc6039-3c1b-497f-8a83-2dca5005df24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "2f7af1d2-1dc8-4ae5-877e-59e3d2d63bd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "74fb2f76-ab93-46d9-b255-f2dbdd19b0f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "f627848d-c512-4ff9-9e36-4fafcbe674d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "3eb98be0-eb15-4af4-b4f6-8bfb9c9e0ece");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "0c1b0573-e2e2-42e0-8f76-70973d197cdc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "c38b052f-e70e-48ce-a142-6c2d1bc20c7e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "b94a7d12-8f34-471c-99b5-f2de712856df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "dac78d84-c38f-4754-948b-28a79bdf3865");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "edcb3715-9b9d-4536-9d84-3297679a3d44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "b7cdfab5-e9d8-4fff-83f9-21cc86a72ebe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "96882b3a-e331-4857-a9e6-a0b500204a08");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "5c8d6ced-b42d-4cde-9259-ea8dc6b49aec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "5b0dfda1-4dc5-4daa-a779-5b2700cd9a20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "a2acd5e1-9a11-4a44-80e5-3bd44b29bb46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "611ed9e5-612d-4bb9-9e68-98f754745fca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "c3dff945-920e-462c-8c08-3ff05ae8e5ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "a1d1aa30-94b8-45a7-94b8-7baaa2d45706");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "6eed67d5-92f9-4f1c-b760-fc12827df805");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "9b758956-7f65-4bfa-b67c-bf0f1d1e6e81");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "0e7af41b-9ad2-4314-ba73-cc5cec1028c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "5230a8d2-2a26-4f5e-8cd6-b81b79a89f87");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "7aebe895-a258-4a29-9b2f-6dac6f85ecb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "eb3688c1-2321-4497-a7ef-ab8af23ba202");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "aa6f4056-a0a7-45e8-aa64-7462f53ea972");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "a6c7d504-0138-493a-acaa-cf455b46c9cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "78c5ad72-da8e-4946-b8c2-7138c08ad456");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "2e336776-0123-432b-abc3-75242349a606");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "dbd8bd75-993d-4dcc-9a13-7b4e2eeb8034");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "c2af7cfd-0e30-41fb-85dc-fddf518e55f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "5d3006b8-0781-4d11-8194-0993410c2b8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "5f302306-43bd-4144-93f5-d2e0430e7568");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "e976e0f8-9da1-4267-8f62-1e8836a37af7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "e39ed5e3-1726-4511-8b91-8b1429a594c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "6304e5b4-2038-41e8-856a-66eb6f57a2dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "b4aa01b6-8f62-4187-9912-bdd2760c7ac4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "bcab9ad3-010b-4538-bbbf-494eb7838b54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "6af655cd-508d-46d9-ab60-463ba9f62458");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "50f0f201-0c01-4507-95d1-03ea76ddd718");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "d1984bc1-ed4a-448f-a2b2-8a06abb10954");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "4ef41062-5263-401d-bef5-381ea150373c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "62977ee8-1c09-4bc5-b408-8281ec34372d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "b3cd3e34-5d84-45d3-a86d-779359925b2c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "489c7645-ca75-4a44-9c8f-85900aade589");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "29d0073c-ed12-41cb-997f-70c5fc63ec36");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "24716088-f556-4ec5-affd-dd219e426f40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "7d0d58bd-0667-48c1-9136-da41bd41b221");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "8d1864f1-4338-452e-b81c-af312a0f7baf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "f9f74960-1d3d-419d-9c7a-8c328cc03583");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "9ddd35e5-8e74-449c-82cb-0ca3ab26bd84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "a77229f0-716e-4a82-b4e4-9390a38b06c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "e18f8ad2-9d84-445c-bd56-320541891734");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "d91b6335-0550-4040-9aff-5655282174dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "55b32022-f0ec-42bc-87a6-c3b7707f3ef6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "d144f0af-0e4d-44c0-9c5f-3eca38c09e9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "1e203a38-d332-48a5-ba0e-4f76e55e30f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "240ee86b-e9b3-41e4-9e79-f5fb57daa6bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "0ffc28ca-12e7-4555-ba22-c21249c7865b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "c74ed30f-f477-4529-bdbe-ffb93a9a3c54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "fc803310-8307-4a81-87c5-88473a081da3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "94393707-26dc-4a53-9bdb-a873de10dc8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "b8758cf2-4891-4d8a-8046-c2d62765255d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "fd7457fb-4b1b-4c6d-a920-90d42edf45d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "065f90f4-87c5-474c-ab09-3f3d0b199811");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "a4ed1267-c5ca-4198-ac5e-b9ca4fc27dfe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "f391a76b-8ddb-496f-85a5-611374469729");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "eaee2dc1-2480-4649-bda1-2e69d73cf0ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "f6318505-1b4b-40f2-a958-c2b64e9314eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "d27c71dc-f568-45c8-bb8f-8a62655aae0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "7dc72bc3-ae07-4a05-900e-b318f2598a44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "e584befa-93b8-4d52-a756-6c6552141e84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "10e62b64-86de-4243-8b91-ce8a77b14e34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "12bc008f-422e-4c0b-bb49-504970ad2342");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "7ca3a579-3c6e-4bef-a0a2-bd1b7fdfcc86");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "9d16e11e-ae39-4be3-b48c-91a2c9cf57c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "7dda8221-d0c0-4fa9-8f49-6d92ab5b737f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "786238b9-38c8-47eb-b47b-af9ae005e473");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "1aa4b74f-d585-41cc-8f80-e75d4f85bee5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "d13a8008-8e11-4b8b-af41-07678fff8cce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "4957a4d2-345e-4d90-88d7-dbadf6637440");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "7b2bc6e7-05c9-413a-bbc1-12429136c247");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "43e99fc4-a9df-4cc9-8efc-0ab94cf0aa72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "9fc13b90-dc5b-40fb-99a8-defcb12d0357");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "e6537440-144b-412a-b13d-742c2d618469");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "bd707bda-8cda-40ac-8c04-fb3204470b98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "d36f3712-e8d6-48dd-a183-87fab2e47346");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "a182855b-0e59-4e0e-a392-6e8d7b9b0b6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "81c9d742-eaae-40aa-a522-9ad2908f2a20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "4e29c87b-bbf9-44f6-bc18-f03b5d833ba9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "012ded9d-1493-49b4-aaa8-75f0293e2681");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "b230d297-e5ae-4890-a212-7630e0cf6dec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "77ae79f0-5fbf-4406-a5af-b98f90a09116");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "f3c52070-5af5-4615-8cca-a7479b714f7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "133f2025-5a63-4373-b203-250eba0ce090");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "ab32bb9f-8dcc-4667-ba9d-354b3303520d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "aa5e98b7-3fd1-4291-a565-ea3358bca4a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "74282c9c-d983-4df0-8b28-e3c707d89fa1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "5185884d-d3b7-43f3-8870-af504f9a0606");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "ba3b706f-7fa2-4223-b9bb-908b288308d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "f508d1d7-a529-48d7-bfc0-7824be95c3c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "c29b5fba-8bd5-42a6-969b-6756a7b2d8b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "d261cbbc-6cfe-4259-ab48-1f80affb14fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "240de3d2-5e5f-4d24-b1c7-fc55753d94bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "35ced62a-61c3-4659-9cfa-f242fa2c019c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "57de9ad4-a13b-446d-9558-b31203ca98ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "9455d260-314c-43e1-8bbb-36ee48c5026e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "991106c2-b9f7-499a-a3ce-0337cb11d003");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "49380d70-77db-4b87-a37d-505d803127e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "b585489d-a5d4-4f7b-9822-58241009c50a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "b6811293-47a4-4a81-92d7-3b4af8c36f31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "0b713b1a-59aa-432d-989a-b0d339a13dec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "c4d7656a-72a4-4c12-91ea-4ab9ddbf6397");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "fdb503bd-a8fa-46fe-8a10-bcbbb42bd324");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "b250c0b3-9de6-4d0f-8df4-404911ba077e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "2e264378-febc-46f9-a180-19d0935ac0fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "b0c998cb-a28a-4a54-8869-2a90d96395bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "0d7c97d7-46eb-41df-8ac1-571e7e2c012f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "8e9defec-177f-48df-89da-d0cf8fef2948");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "4c3b393b-e870-4ac8-9601-f5ff8754ede8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "6b1073ba-04c0-4d37-ad64-5cc6215be66d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "cf7594a5-deb3-41e8-a7c8-99ca7c62648d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "66d8850b-7888-4c06-a184-bec258afa70a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "b66faa83-d9f3-4579-a75d-22653fe402bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "a9188332-7486-4c2b-bd89-4e852f2c2cda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "ce87d937-a44a-4802-83ce-54945981c43c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "7d9c1640-ff27-4641-b9c0-f19fc2470733");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "fc13a012-4d8d-419f-a4e2-3c7c152ba0ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "18e01d93-1e04-48bf-87d8-82d92c42deda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "549bcda5-f0eb-4e72-b534-c10475c89a48");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "28026142-3fbb-43c9-b849-ab11a44beda2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "6f47ef22-fbdf-4194-9990-18e84ced90a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "49e03c40-c369-4d12-95c5-574acff79ff7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "9c24d377-2606-49a4-9fa1-bac869e180fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "47635b6b-6ea6-4782-88a2-dcbbf6c5109c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "4ac81c2b-f1df-4472-b6f3-2e43018fc66f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "fb1c11b6-a8da-4d8e-9726-6ac75652791c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "77649378-7f01-47c2-a44f-85924132b1b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "9e40f055-e48a-46f0-8c67-4f37c25f2ecd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "7162ea44-a9bc-4d6e-944b-47ec1312aae9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "f3bcc5f1-c51f-4501-a308-28616b2f7edf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "fed2e2ab-738a-4893-9fff-d125ee744646");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "1a278ab5-643b-4ee7-ae33-874800855794");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "2156eb1f-4d41-43aa-bdaa-3bc14ba37512");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "011faf78-3a42-4fce-ab00-440d1e847046");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "daa48e65-8526-4e63-999a-2bb8b378518e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "67a8a7ce-bb50-4b2a-88e4-5395a1a48ef7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "1e6d5be3-df34-444a-a42b-b84b0f9a948b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "bd72058f-5005-44b7-9d00-418c1e9e17d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "ad250215-b52f-4c37-8b65-ed1be9b86145");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "53de228d-0ff3-422c-b585-f85d243636f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "8bcedb14-83b6-4cfa-b3db-7834d903ace9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "8f5d6789-9c66-4ab5-a8e0-d4033c7d2125");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "c63651af-9182-438e-8a8c-b92c9a4dbd1a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "fba4476a-f276-40cb-910a-421631e6cdfe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "65061454-d27d-4277-a889-19da199576dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "27dc45df-588c-4203-904d-ab6a0f15576f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "b850786a-65f9-4057-b3df-ece954b3d8b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "c53f6bb9-1169-4411-b702-285ce922b769");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "4cef2075-da3b-43e8-a5ae-94344977583a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "8b5b4eed-e5d0-43bb-a177-cd4346f05943");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "c9b59c4d-8640-46c6-9e3b-50caf25bc10d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "796ea4ea-0bee-4bd5-a0d2-910cd8460e6e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "4c932b9c-2c02-47b5-b287-4168a99109f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "60b808df-1a50-4995-a546-fdc9a3b9492a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "b6a300eb-fd47-4ed5-9a6f-5ca4592615ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "63020d1f-729d-4170-acdc-60dd6e4ba519");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "a5c62a30-b7e7-410a-9aea-b8ae2bc3cded");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "ea9978bc-e36f-4121-89c2-ff73b63102ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "0640b55e-ce8d-42b7-8012-659e798d5ef9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "3fa0fd3a-b294-4797-8483-82ca15fd71db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "e17797a1-ec2d-423d-b17e-8fa524bd590d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "ca7d4c7e-a963-4bed-a06e-5c331fbd4205");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "bd532bb5-0eae-4676-ad69-75e0518cdfe9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "ca7b16fc-f76b-44fa-bfc4-7ab229105c02");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "bc20af05-000b-44cc-a891-b4eb2712fe4f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "30d46d5c-9bc2-4172-8253-a7624d033dc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "1b0a5a03-e9df-4df4-8885-1a169a83280a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "abd519d6-b17d-4af8-87cf-783ecc88131d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "1dd20c4a-02ef-49fc-942b-4e41cb256f78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "0a355ef5-1f5f-402b-a234-1c5e7d59bc50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "e317f223-9ddd-4c89-b8f4-d66aaf0e4431");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "18fef113-ad47-4552-b95d-6b491ad5b953");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "077f885f-194a-4e1f-bf94-8a478ae12747");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "b49ab4dc-fc8e-4b07-84b4-b5ad5580b34b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "de2fa356-8a20-413c-b9b8-dce619bf9407");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "6bec3a2a-68ed-47dc-a9bc-991bf49ff1ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "8e03a4bd-db15-4cb1-9cf7-d0c11ecbea7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "a386296f-db09-4763-a749-e4d324590baf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "f7b621fb-5662-425b-93b4-691f60d73171");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "27857178-ec25-4043-bd24-0a262b80acf8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "d84b837c-159b-455e-abbe-62f7531d53c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "354fcf87-ab69-478e-8303-76ee17984f38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "7d460672-85ce-4fa5-8d19-f6c43ffd2fd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "d839cd17-ac66-4603-99d9-493905f5efe3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "f4430647-6909-49ac-bab6-697551dddfdd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "05f950ee-c531-4fd6-ae21-d079a24f1f47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "96513ec4-bcfe-4a8f-8d9a-011ea28b41a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "29cc45b2-f72f-4e83-afa0-d6b1c76ffe56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "70919a09-a061-4a57-9fde-4ebba211d332");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "86e20a88-0ac2-4904-86f6-c072c5c76866");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "6a00ffbb-31c8-4bb4-b83c-b2783e86a7a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "22817ef1-0d0f-40c7-891e-51bac3b6d08a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "56447262-3170-4c74-8f7b-6b42f2429586");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "287819a9-fd22-422c-846d-ea9cd5e8eb50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "f265fa08-a1ee-4c2a-9e5a-fb07f5a77bcc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "9b74649f-6e37-403a-a5af-b41b27753eb6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "41d22cf6-7cff-4509-b9bd-a3e429d46a75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "97112ab9-5adb-4bba-bdc6-02aebee5eb29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "257c05b3-4c69-4963-9c17-03072a1e5889");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "76a6884c-042d-4d03-b286-cbf48dc9de33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "4bb72664-5b70-4fb6-af60-7608b3db4938");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "05d311af-0a20-46b4-839f-052e1526bbac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "95d16db3-2a48-46b9-82cc-b58e3a9d8fca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "305d7ce5-6e6b-4e37-afac-c93ef5b802c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "49b0be89-e29a-4ae1-8fe6-caed9cf7a986");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "d9f67e68-fdfc-41ca-88f1-3e87d5d51bd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "35256071-2147-4a57-a250-dd5a4d32289c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "664b9d68-4489-4e2f-9611-390f38e78ca4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "ce744c75-f5ab-4560-a56b-1f72d1500da5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "c6fa7252-3738-40d9-a36a-e9216ffa061e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "fabe3440-a61a-4e66-ac91-ddf43f8f1c76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "e5b781a2-6c97-4508-96e9-50377f1272bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "bf26fdfd-4611-40eb-b702-53a89f6ee52d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "8a765be6-dcb2-4e62-a258-34fdad3a6837");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "35120231-3bf5-4e4f-9b92-7a2078e1a8f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "57a4f712-0a3e-4c71-b659-5517b878884e");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "9fa3deaa-3f3d-439e-8c58-d80c89310eb1");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "7c6a0261-611a-449b-97f5-ae26b760877d");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "e628a388-fb0e-4fb3-88f0-ddb234da0cd6");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "27578ff5-2214-4522-b310-c653a3149850");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "01aaf249-eb16-4142-bd40-458a7fd1e074");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "46d0017e-f64b-472a-aae9-0998f8482463");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "6c1447c7-297f-4009-94e8-2a1f653e83cd");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "d7ff4196-d1be-4dbe-80ed-fdff851a921c");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 1,
                column: "SalaryAspirationGuid",
                value: "8cb0be76-1456-4e05-a94f-434d31504e9e");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 2,
                column: "SalaryAspirationGuid",
                value: "e8111218-e9e9-46c7-8d5f-dda67f3585fa");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 3,
                column: "SalaryAspirationGuid",
                value: "01c3ad8c-f236-45ed-bf26-c07b23dff0d0");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 4,
                column: "SalaryAspirationGuid",
                value: "f91d5b76-a08c-4ef9-858d-ecd30d1f1553");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 5,
                column: "SalaryAspirationGuid",
                value: "4894ba0f-8b38-44f8-909c-669f27abc6c6");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 6,
                column: "SalaryAspirationGuid",
                value: "17abd00d-4d18-43d0-bbea-3bc1da4f461e");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 7,
                column: "SalaryAspirationGuid",
                value: "bedbc4e4-c262-4422-803f-005a2d363be3");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 8,
                column: "SalaryAspirationGuid",
                value: "58246fe3-70b0-48dd-89ca-33c24a7ad242");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 9,
                column: "SalaryAspirationGuid",
                value: "a28b1c35-2d3b-4df8-b55c-e1a9ec897d7b");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 10,
                column: "SalaryAspirationGuid",
                value: "7cde868d-3264-4ea5-a061-812a178cb0c5");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 11,
                column: "SalaryAspirationGuid",
                value: "07fc6b0f-25c1-47f5-a544-2f8acf633a65");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "dcc573b4-27f1-4627-88e0-79031ff3901d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "1d0887da-28bf-4886-b102-775bc80a231d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "4b3e6f4a-acf3-4247-9736-5b672072ea06");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "a47dea4f-6427-4630-8d54-e0ae94e22fee");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "1fe34313-f664-4a9b-9c09-96c00211b834");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "9ecdc731-ba3a-400d-a7d7-ff0f7a56f523");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "206cd62b-4849-4c2f-8a75-443d09509332");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "797cd0ad-e439-41df-a78f-dcec1b43b510");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "55a8f949-e884-4fbc-819c-67817d2d28d7");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "310e225b-7759-4813-805f-f2a19d6957b8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "d5f1ff4b-ddfb-45a3-9a43-73066decc615");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "17631307-38b9-4914-982c-45fcd0a72c38");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "8bbace55-624a-4d78-a65c-c43eb1efde89");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "da5be200-c362-4723-b6fb-c44a6619bb3c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "ac9d92dd-b888-4257-b7ad-fa128d52a2ad");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "72bea9f2-009a-4d8e-8bd1-7eca4c9213f0");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "77865ce9-c5b4-4095-8cf6-c9d25850c79e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "61f6d4d8-890f-4129-8ed3-4f05ad8a39d9");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "bbbee699-e9ec-4988-9648-4d807f337c64");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "62f70266-41ac-43a9-a67b-f3008f3f7d32");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "8650bb9c-fe77-48a0-b431-2cae94adaec3");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "5a07482a-af04-4379-ab6e-218c3b197614");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "474a31c4-b4bb-4fb9-94b4-29fe84a20952");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "9bd14053-0834-48d1-8f05-cba68878ce64");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "f7a4f641-818c-4bf9-b44f-b89b0c331865");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "4bcbff32-47c9-41ab-8cc7-5d3ff020e46e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "16f5b9d2-2150-4d96-8dba-72f9d680f6d9");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "49f4178a-f76a-4076-a85e-7d41d01d9381");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "2c6d8c1a-81c7-4ab4-9071-9bc7052a6fb5");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "b324b983-da73-4b75-8054-fb376377231a");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "8336c186-ba36-473e-ac3d-74f82bab8fbc");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "8cb6d5c9-c464-4251-99f3-2a6241eb0e47");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "44de6469-8678-440c-a143-09f13be4f6c7");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "5936401e-6c25-471f-b4dc-8c709b4e68a8");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "3d7fb8bb-84e3-4aa7-9fc3-cc46187b32b8");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "200734fb-4e46-43d0-b9db-13e00d09dc1d");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "e127203b-5595-4177-9a1c-87c62b3d9828");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "02d0eba9-a10e-4ac0-b225-5cf54a3dc28c");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "a3f49d6e-2153-4983-826d-fca73ee6ee27");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "aa50039d-2844-4919-ac6d-d45f1f378f11");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "2f27bce1-a36e-4569-bc97-ad2dc43ec257");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "d5adf049-0e50-4a14-84bf-18e38e2935d0");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "fa6dd19d-5e36-4444-9c4a-9557528f9e58");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "7328e350-49ca-4412-8329-83f24881b760");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "4088c815-d8d1-4a6b-85c8-e4ab88af602b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "9d1f3ada-6928-433b-aba6-fd05b354bd8f");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "62572b01-ecde-4013-9110-7cefece7240d");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "71ff7244-5890-46a7-a00f-4e418bc914f3");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "4bfff26d-0801-4353-a49a-4e1a6b9a11df");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "ce864267-5421-49e4-9a20-3695bce7e41d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "66e58294-0be7-4963-9fff-856352c330b6");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "0777b910-e20e-4950-b3b7-aa16aacc3575");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "97084b22-0b88-4cc9-affc-a3df61cdda12");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "847244d9-9dd3-4a3a-8a53-c3d0fca82182");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "ea7f4895-f6ab-46f0-b498-2408ff1d8ae5");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "6d872fd3-3dc0-48b1-aa22-39dfb7330a65");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "f2c0cb4c-44b2-481e-9932-e4e80fdafba0");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "65ef7b2f-f9d8-41d2-acf2-3b61b0e249ce");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "994fd7b1-7c49-4b2f-9b5f-2f0153857f83");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "f930fa70-f553-4ce4-b915-e9ca5b55348c");
        }
    }
}
