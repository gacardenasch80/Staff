using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesMS.Migrations
{
    public partial class MigrationHaveWorkExperienceNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HaveWorkExperience",
                table: "BasicInformation",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "6d03e0f6-85a2-4618-a796-ad5dfac53787");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "3796be3d-e930-4f64-aee5-452b25476b29");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "e9060a0e-754a-42da-99c3-d2e9dfba6949");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "24f69242-e71f-4f6b-af10-e46f8f09e45f");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "b8bd44c6-bdf9-4987-895f-ae09d6446158");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "38b87742-a930-4306-97f1-0bfcc3e5567c");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "f44f35ad-5528-4b81-8ec8-8353e3e61cdb");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "06cac050-34b3-4538-8759-b3f86c102359");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "bbc099c4-a201-4bbf-982e-7217ad273808");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "28eb8b76-ec26-4264-b8f1-c00d8ae97f48");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "8b018560-9738-4fa7-8229-0f3952e1c80f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "2814144b-797f-436c-ac8f-92d4c45713de");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "a9fde15b-cb3e-44ed-924c-0fd5fc1210e0");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "5d16376f-3076-48be-bd3f-f9fe38976495");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "70c7ee7e-6e62-4b13-84e3-98f2d135bbd8");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "fb21c504-60cc-46f5-ba91-c8d5234bae5a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "977791f0-c3bf-482f-bb37-eea8309c8129");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "3e69f8a5-fad5-4789-a2af-e2df010163a0");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "712291fd-5810-4480-b1f5-79c0bbf0fef8");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "2553583f-f24d-47dc-9c9d-1b1b4217bf60");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "87303b2e-a868-49a2-8144-0f29d27a4c4c");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "87a3fc21-2757-456b-b647-e8984fca7947");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "17c0582f-8f75-4241-a648-4aad0109afdf");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "cc596384-b9fc-4b53-bfb4-2987b47a228e");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "4b172ff3-47d1-481a-b231-d98f8b4569f2");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "657c01b2-919f-4c69-b8ce-fa604579748b");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "f53a45bb-7ab0-4da7-aead-1ad0ba99332c");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "66733b05-cdee-4359-bd33-e7400ea48520");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "1178a023-b19f-4cc1-9691-38d520cd1bb6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "5bb096ab-2ab7-469e-a11e-8b0a21a53460");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "3eaf86d1-ab52-46ba-b750-8b372e569d3d");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "34f1a00c-010f-45d4-8b78-360e7db917a5");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "952b8f73-3652-4abb-ab82-429657581a37");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "0f184286-efb0-44c8-9952-a09d381eff17");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "fc85ccb3-c3c0-4d37-a936-680f66a2cab2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "f8900f4a-4688-4238-96f2-7de787658923");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "a65ed78a-c52a-4414-b679-29bd5480df08");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "2e5b0d72-0227-4ac5-8c40-aae66f5ed83e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "7d063782-443b-4c43-b8db-f79853a28a0b");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "ed9af244-b336-4bb8-8a6c-2b009191a30b");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "c29aa3c3-398d-4c22-83d0-7c7c43830c85");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "1a16560d-9251-4a40-8dd5-e8531f2b7b31");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "110555a0-dac2-487a-9528-53e3755ee70d");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "ba1f8b76-24e0-48f1-b521-efe3721c559e");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "11fbd8f5-87dd-48cb-afa7-19315e966618");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "2326facb-6093-47fc-9d8e-63f54e8da3c2");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "b37e4dbc-c8a7-4c85-998c-0be9f14e355e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "d3ca2312-2d83-4245-bc63-c31fca4dd9c7");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "736b687f-d6e0-4c14-8302-0b3d87ef689d");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "77b9a58d-571b-4cdc-8551-49c4a544f776");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "764241e5-63b0-47aa-977a-4ef35f61e23c");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "b5e2e9cc-899f-4367-9cce-03e591ddcfcb");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "4fca1291-5ff5-4f4b-bc18-47c45f8d0016");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "227100c4-6c02-41a6-98e1-cbacfcb62ff5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "38724ab3-cd56-424b-a75f-c763654916f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "3305ad7e-2950-4d60-a17e-6f666f0d9446");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "602f1edf-2f23-4456-8215-7eba78c7a008");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "3212ad97-be18-4f57-81ea-12bcbe7e847f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "6b288ba3-1347-4ae1-80d2-853e78a6b749");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "823c4d3a-157c-461a-a561-6edead80ba64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "75e4cdbf-6f24-4e4c-b907-067c0e94a6df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "7fac2b8a-2f55-41cf-b0b0-44413c15b76b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "2d189329-90c7-4053-9f56-d0356b17b53e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "9c44e6e7-3a5e-487b-b827-6174edf9662b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "ebe8a4fa-6dbb-418d-ae89-c90bef7b50b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "f0178791-324c-42dc-ac89-74b1622d023b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "7e9fb0bd-95e2-4f31-819c-33be456983d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "88003cbf-0df9-43fb-a240-b03ab51113ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "ae26ccd5-aa7c-440d-b2bc-9c94130faa84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "ed455abc-1d91-483c-9b9a-fa80256e6fb0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "9192b8e3-039f-45af-b827-f71eee126fb6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "911c325a-f7f9-48ea-adc4-83aa6ab1e425");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "fb225d61-b4ff-444c-9b83-ceac4dc607ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "965e40a2-510b-4b57-9bc0-1b9d7e35db0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "1daeb09b-1f95-451b-8c92-827eeebbba37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "1f6ab754-ab1d-4275-aa80-b65e51cc77e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "6db3e78e-7dfb-4a58-9415-09364839ba67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "a36c0063-b136-46b6-9494-ea8c7cee6097");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "d9125165-dcbc-4e2a-aa02-32b2e2c13bac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "4e007490-e0b3-488f-9bab-9fa626fdc19b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "cf37c2d9-3ce8-4899-9009-cc7ca9c27e48");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "5b866dea-ea49-4b18-a419-790d9ccccdaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "14db01f1-a46c-4e07-b4a6-2292ce531856");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "b8d51435-3b44-4aca-ab58-dbe596cb06de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "b69f8d09-74dd-434f-9a44-a395fe560522");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "16327bcd-e7d4-4c38-8b39-66ca35092853");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "52361e11-e9ae-4718-b668-d28b40bfd520");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "d62c4773-11fd-4f12-95d3-70012cbff4f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "02d097f5-93ba-4e82-9992-454dece9a23b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "be658e3d-b254-4a24-8d21-c815600fa2fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "1544b602-2559-4c78-a2a6-0a9225f0ed7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "bab9edcc-2a79-4727-950a-bf7532a3a40e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "4c941dff-2ce9-4f38-b657-19709187135d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "a4464366-7073-44e8-8bce-6ee9bbf93cee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "1b2ddc9c-2617-4cdb-aaec-9622b2811273");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "eae02b92-dfd4-4020-8c2f-9fb73c4cfd68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "2bc059b1-bae5-470d-bf8b-0dc146e8eb5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "f474f455-8008-4512-9208-0f3d91b101a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "04acbf1f-8fc8-473f-adad-ef5df2644fda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "03ac8e46-0d2a-466c-94cb-e7b48480a710");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "23817ccf-8559-4442-a3a2-fb8ca3192b49");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "8e403ea3-5903-4258-b6bd-84d148bc841f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "9ba3a8a4-0d3d-415f-a573-b5e67acd5db2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "82ca14a5-8647-449d-951e-69562266a201");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "bd4175a6-4be1-46ce-a714-9906805a8e76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "a90459c6-2a78-40c9-83f7-4c98b8d7f471");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "9a4565c9-2d3e-4f5b-bc14-c90c3df580d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "22bf7ca7-4d9e-4238-bd92-079872cdba90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "1dc6695a-6857-4add-ad98-9a9cf7b7dd9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "7b0040fd-bee8-4cca-b560-39a6093da7f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "9321133f-205c-4f15-848a-7ee892a2ab2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "64928291-e8b3-4fff-8702-1f7299f5085e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "a2d0c3b4-ab06-414e-a573-4029a0735aef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "ba880f4a-2bc2-48ef-9e98-dd19b5c7c89f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "e8a12730-9c38-4e6c-bd6f-1d1cd693eef8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "286113c6-9778-448b-8ebe-780211fec990");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "480018ac-4ca7-47e8-b4a5-9f4629589401");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "c62bc9f7-4cef-412f-b851-e643d81eb40b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "99588c4c-adab-468d-ba4f-627073ea6af3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "4615a61d-f18b-4ac8-af20-f9058431ef18");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "46e89a97-98ae-4501-a438-6763bba2fc53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "13219934-f89d-43a9-8740-d5202eeb106a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "75af7b1f-f36c-407a-851b-e6de93f7a3df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "ea238a6f-bd12-4cd6-b359-94dd1a91b01c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "402cfb62-8f12-43b3-a22b-d101f1f53d42");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "9b71b715-2907-441d-8462-c6aec820b838");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "06232421-9934-4fd7-9836-1702e7c28cf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "1d607d4a-28c9-4a23-8111-ebf4947949d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "72dff986-5f78-4d9d-9bc8-51a3fd14d414");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "b3cee272-fd7e-494d-8afc-543a1b1f566d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "9bcac146-089c-4d0e-9e3d-1f11d7ba8a11");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "3036e1e2-efd8-43f2-bf9d-ad0af15b70b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "54505840-ff80-4d61-8ad7-f2ce4b6b622a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "afc7bf6e-a04a-44bc-be4e-5df114e144c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "11b2e9b5-8d0b-40c1-b845-d282e559fa1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "69aa2a90-e62b-4af9-ac04-493658350cbb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "9d89ee11-3974-4cad-8e2f-10ff63f516c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "db34db4b-7446-4722-b186-5d193ddf85eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "0da2d3ce-0269-45c5-bc53-697e82d34813");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "9158a2f2-b165-4f58-8aab-0ffcb1681055");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "d9dc44e1-070f-46ed-be00-6a7f302ce513");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "dfeb333c-049c-4141-9b03-659c1efeb174");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "8afb3018-7e6e-41cd-889c-42266c2cfdb6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "efb2ae6e-6797-4a28-888e-07678fd6779b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "70596d70-52a0-4624-8b4a-9b394c840c95");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "f853758c-c593-48ce-b8f8-e3e8efea4939");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "fd1a20be-763e-4446-a8de-d4d0b8a78915");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "71706b21-dd94-4a1f-9b0d-25c3bc33ffd3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "cc463282-1c8d-4686-808f-06fc9d7b39d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "ec213e64-6abb-4ce7-9a01-ba1e8b860517");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "317d5e1c-f990-4cdd-bfa3-84de5038c8d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "a191734e-1ab3-4a6b-93b5-453515790a69");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "f2a4d0e7-1b13-49ba-8f6f-38ee962b8d03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "0b390b32-6bcd-4b39-982b-23b3694b9065");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "9167506d-8ee5-461c-b95f-636087c81815");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "706bc49e-33d7-474a-9498-d3c7cc2c7c34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "981d6e04-f60c-47e7-984a-66389262400c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "97f1a69b-7b47-4a1e-a7ff-48a1d29447cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "81a72445-d1de-4230-b87f-4638030c0a38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "5d8ce07b-9246-488d-a4c3-1cafd0629ad4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "1b857ecf-d24e-4a91-ad6d-9dcf21ec518b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "01dd6367-6107-46f8-87e1-4ca256511c1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "a958ce49-cf24-4522-a39c-c63c72f27f9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "f2f0c8fc-845c-4bb6-991f-29899a81765c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "04274d81-d577-4f45-a130-072fb1ad56f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "9aa136a3-1293-4855-ab5d-535f17fd5667");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "408ec30f-9f6c-4db4-b929-06d0a1639753");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "1ea9c641-b5fa-457c-87f7-f6c0bf3d805c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "0bedf829-7b9b-4c45-9d90-51acec52c0b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "55b9cf2b-3937-4962-8fd1-63c3df60cccf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "a9408620-f71c-409a-aa2a-f42aee128a89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "355fe5e4-a6c0-407b-8789-1a0765784a61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "6e7ac59a-bbf5-4cd2-a733-1337a05cd9be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "75b29937-7ce6-41a2-b644-05ca514828ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "176d6a5c-064a-4529-90bf-54fb333530c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "c2afd796-daac-46bb-9de8-c5eb9c02432f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "2b2cf998-3996-459b-8b5f-2480af6ea8fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "52cbbc89-ecbd-41ac-b14a-c62db677a038");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "343fee96-681a-4024-a9ed-be6156c40fe0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "4287284d-bfc0-41ff-9c57-f801a645b9cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "cd6a4539-e0a5-4f93-a08a-be2916312665");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "d9615a7b-3917-4481-82ac-02c9cec87990");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "13b35447-06d9-43d3-92cf-e83ef7c624f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "48ce041c-63e8-4afd-88a5-7b9d6fc7f1b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "55e98c72-168b-47fb-b875-efcb79367da2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "24476f86-4a94-493d-a96b-b95c871b79f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "6950e1c8-f74e-4633-a8a4-fcd78f69c90c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "f7e553cb-7df0-414d-8a32-62a63151ca96");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "c096e77b-061d-48b2-b0c1-62f70d02e4bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "27010f9e-2d84-4a4e-a52e-e77cf1e9ce17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "d3862dcd-a4ab-4f92-8a24-44e5dec5b648");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "19db12ee-b14b-4c68-8615-f4870d20a100");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "7d47df2c-e2dc-4e18-943a-e4aee1735b51");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "f08dd8ef-3727-4015-ad29-504cb3933cc0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "f4989743-f438-4114-9a17-7950e883e3bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "5f0096ae-435a-4891-9440-423301c9ae47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "2c6c3402-10f5-4e7e-92f4-c710fef36938");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "00437e20-2497-4079-a09e-bdb2e480185b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "e68c3c91-1bcd-4aeb-b2cc-5688b2f5763d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "4807c7a8-46ad-4cc2-9eca-89666fb26f4c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "6aa354cc-3328-4aac-b4d7-b3ab1ca2eca3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "b8491552-68c3-4b30-9a3d-ac881e1625e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "11afdd55-8c9d-4971-b862-8bf60d1c86c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "3f1b5467-3776-47c1-a450-b90e8b3f14f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "41c905a0-b534-4940-ae45-94d70d86d13b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "34405a93-5678-4a1b-9dae-ab723490393a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "f3423efb-5b2a-42a0-878c-62387dff4de3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "61a99e5d-0138-410e-8a3a-7c520ee1ab82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "a4f17388-c9c3-4f9f-b3ee-b404bb318cd0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "c0ff246b-4afe-4cc9-a9a0-f5804d83acc9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "da713c0a-61e2-4f95-91f4-15eeafe2634b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "030e381b-d33d-4971-b401-c97e97dbdca0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "6d1c8ce0-fca6-43e8-baac-7a68239997a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "81e246d5-ce41-4580-97d2-24209ec410ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "52fa1857-4d3a-42af-94b8-7aee13c25a04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "89817229-2073-4a9b-9b6a-51082d48eb6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "4d7a5435-423e-42c0-b293-0afe5c32b69d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "113742f1-df44-403a-9478-6a4d11d438ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "6099de13-7ebb-41f6-a7f6-225b170c6da2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "b71f5c4f-3c6b-4fb6-9b01-5e4b167a1c37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "7399cf5c-4549-40e3-830c-3a52b80bde35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "bf94fb44-1ce0-441c-b0a4-1968bac84da4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "b306bb28-39d7-4974-9bca-95868bc83367");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "1f740752-8fc2-4cda-a4dc-f352ce824980");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "15a55473-c1e7-497b-9d66-de12564b08a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "32a446d2-f69a-4d68-a611-de00f4fc642c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "7337bc44-5a0f-4a16-9b6d-a87ae760e2ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "9eca2cf4-68d4-4657-9266-db9bb03c06ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "55ea3a27-839a-4790-b8e8-54ad4ec46a90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "8a37969e-693e-4783-922f-faba27c8c63c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "ff5a685c-a094-4a5d-badb-696db38bf019");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "7701e61b-5c36-4cb4-9b5b-f99298a2236f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "28bba6dd-3155-4fbf-8816-e5db6886fdb3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "034d772a-1ffb-42fd-b29c-6036a41664d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "9168ce0a-57e3-413b-99e0-6821c6025db2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "ceef8bca-da9f-4845-bb0f-8791f4ef1adf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "dd38f26e-b429-40d8-8e6b-f2cfe6f34381");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "5064c41a-ca14-444c-a497-c026887cefc0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "8016cae5-5e63-4408-9c58-7a72bf12618b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "4ddadde7-8b18-418a-82e5-29e910cac472");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "7cbd892c-7e1b-4634-867e-0e391c904476");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "d100da16-83b1-49b9-a787-4a2aab44cc08");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "6c853e94-ebb3-43f3-a453-6bc9ab7db10c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "eefe70b0-089d-4fe5-98cb-a230394289cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "80587c53-ddaa-421c-8886-73e9040e8999");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "7986e180-2bac-40f4-941b-9d867dccb1d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "145478b7-078a-462d-b8f0-be43d045ecd3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "57251e5e-4cc5-4147-916f-e17bb453ed74");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "399c7826-fba6-458e-ae40-7b7035851799");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "0436d428-fd33-40f2-a9db-3cee44fca630");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "cd82a72d-e6bb-4484-bfb4-c9ce04e1fb3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "8f419593-a973-483d-b987-7fc380abb966");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "de0ad523-f796-4df2-a7c3-8c3e4c4c2ace");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "6685a3e6-113d-4020-9dd5-1cf6d73d77c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "05ed51a7-928f-4396-89b4-34087cfe3aa7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "0926149a-9c4f-4dfe-bd7c-755d504c6b7b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "a36a22f9-2b27-4b9d-8ea2-976f5b855384");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "ee5af956-964a-4fc1-a19f-2f73bbe6db64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "15ef0c94-d1af-4b88-a61e-f8138e269e39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "1d9ab90a-a150-4a2a-9009-35e797a28280");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "d4a8ff26-1c9e-4dbf-a349-314f6f6617f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "2d06dabf-7be6-4450-b778-af7ae5598382");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "4313f3df-ac7a-4485-9868-2909f6e868c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "d2b5940d-aa4e-4517-b870-643fe1cdf793");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "44462884-d587-4c3b-85bc-df641d037dd0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "fe7392bd-ee8e-425f-850e-68970340966b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "c8201890-a99a-430d-b2b2-ddd6fd723d98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "299e05ed-4359-4455-a1bf-39fadafabd79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "1dfdd0f0-8912-41d2-bb9c-23cf4efa6375");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "5ab4ec6e-aeef-4dc6-a8b6-f9b1cebf79c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "eff5bd38-8e2e-4bc5-86ca-656d29c2944d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "9202586a-6c04-4e4c-91cc-5cd2682bf6fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "206e9168-fe5a-43c8-88e4-f2425e7ec757");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "df846030-7a67-4ccf-9fd8-a2932a010320");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "1e493860-8c1e-47ad-97d1-2612e85b6786");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "90a3db62-cfe5-4d29-afc2-7d0595325ee7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "aee38bde-5498-4464-9ae5-a7eddd4c6365");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "ab20d064-2293-4c40-b3a4-c426ed06e022");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "f5d2beab-2d50-4b1a-a359-72318e074c18");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "4439774d-12b7-4f6d-8f7d-f1ee9de5fb9a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "c2bad3f0-3868-48fa-8601-a23f60c5a6c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "ff2565f2-9c2b-46c1-a165-9ffaf3d60b3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "1887e029-375a-4675-b0a9-523c908f87d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "80872f0a-34d6-471d-8f9c-775931a6866b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "be790b3b-f87a-4df0-86e5-c8f0fb409a05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "79270abf-75b9-45d9-9c96-e009bff60bf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "58a6e161-fcff-43c3-9e6a-e53a12c9e0cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "5c385463-57c3-4903-9b7a-b0787997b7ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "1b424a1d-b454-4652-a3a4-23d78b44a4b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "a97284c5-4bd2-4513-8f5e-64128e87b7f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "4638a983-befb-4202-a7e0-e4d6401c8c34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "38c69dd2-0d3d-4686-aa8a-091fe283521c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "608ec43f-96c4-42c8-ad0f-c6d92a28195f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "5175bc57-3515-4b7a-88a4-cbc1f82b9e45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "d1657d22-e6b6-40c2-b31b-501825459a47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "b369b1c8-91a6-417c-8470-abb42d080417");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "27a87179-26c2-445e-9eb6-46282db337b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "870f2226-73e9-481f-b5a2-23b465e1c3a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "0a28f052-70fb-476b-8658-9b582e6a01dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "a8e5d2d3-2993-4fe8-8bdc-84b46f465c27");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "4e868c9d-462a-4205-9bd1-8d9c7b0b925d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "7663bf6c-e086-47cb-a3ba-e3feb277d264");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "63d50ac1-522e-42e3-9227-e6c52a041b62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "d7235b6d-fb1d-4bd4-86c5-ddadef237c8b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "ce429ccc-f2b4-4f12-bc9d-1531c3397980");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "915d7211-c9aa-4806-88d8-ad90af98eeb3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "f3195c12-cde3-4954-a82f-fdbabf0c1006");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "d1610b54-392e-467d-a5ad-20c727a045b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "c94bfafd-dd28-4e15-9481-d9319c7d2337");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "abdf2923-cef1-44d2-bc1e-6a55e832405c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "d9efac72-0a34-43c1-abc1-1f2eb9f0cdd2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "61a198f6-9fda-486b-99b0-74c5a36cef5b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "c16eddea-1f37-4d9c-a40b-d986a09e24fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "bda9be7a-9b1a-49c2-84b2-3fcf8da75228");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "bdf716f5-82d5-4762-971c-3d57ca3ae113");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "cc3ef796-de30-4236-b8c5-5219d37c8479");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "91053185-3dfe-43c0-9635-08560f91d26c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "8f655859-acfd-488d-977d-6a6fda497594");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "b80f1444-1d75-4605-a057-c55bc528e38a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "0c111a49-0bb2-4a58-b062-ff77e8be04cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "9f240c1a-b5da-404d-a50f-66018e0e5292");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "03290f35-ca90-4dd4-a333-c24b95f654af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "70afa798-ce44-4656-bd4b-1319429a83ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "539b9577-8277-4d82-8830-bbc5822cdb79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "b744161f-f20c-44e1-a727-ad7260c012e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "4a2103b7-d394-4edd-9d3a-768e88563da8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "579643ec-69ea-479a-83ee-264bc613b6a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "56cc7266-6545-4b5b-80af-a28de5afdf94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "84452fc3-f6b5-4c09-ad75-3981d2669e3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "d8b3f3d3-f452-4d9e-b7ce-30985d777fa2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "170d141d-5a48-4dba-bbab-0d2f3335b524");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "dce6cd39-58a7-49b7-9d6d-5233c0612243");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "42f24f40-8c63-4d78-be10-925ab81fe637");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "88592862-0e7d-43d9-83bc-0852a89d06d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "8450f56b-45a7-401a-8a4f-9190c8c82467");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "17f3269f-3731-4cef-a56f-f4a571756b2f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "a1561b67-a243-4fc2-bdaa-86af5460484b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "cdff3801-0ef2-4244-9c57-93dec3b69e75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "68b4ee34-dafb-453f-96af-362b20a92070");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "35252656-c33c-4435-bc1a-5db1bc98b967");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "d192c5f0-fc57-41b1-8cff-71658903488a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "f7593523-8360-4b95-9d5f-5473c48ff296");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "236443a9-7cba-49bb-8176-84bd98ba3ae5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "a86642a5-dd15-44b9-b747-982b4729652d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "3572a898-5b37-4efe-bcf8-691145548f07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "9770ffe0-8b58-456d-b106-d85fb616159e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "f69b8df7-b80d-4ea0-ab3c-eea6f44ad945");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "5d73eba4-2d8a-483c-92bc-9cc1d2f797c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "595466b0-965b-4781-a9f3-477f527e6a4b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "4ab2d3b5-c210-4279-ac57-b29f5daaca04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "3bcaa0e5-e2d9-4849-bc95-364e6d70b116");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "23676d9c-2f3c-4c79-a4ad-3e2345887df4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "ea1f2695-fd92-474a-8b20-611ae35060e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "a67b4359-1876-4a51-a0d8-7143e741d623");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "5424c34b-c83c-4eff-a080-6a937c87f1e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "0f00a3d1-604e-4856-ad07-aa115bfdcab7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "fb53f687-a5a2-4af9-85e9-870e81b58927");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "88850184-5ad6-46ac-9328-8b55e3d78318");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "a0a278d1-91cd-4318-94cf-d52dbec57afd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "a8ca8161-5119-471a-bf3c-cfc8703979df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "d71f77a2-7072-48b9-b876-375127225614");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "aa14b0cd-e31f-4f54-ac4f-8b4e44f36742");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "0ecfdbe4-05da-408d-9bdf-26041f2dd4ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "e8c647c2-f8d4-4524-a9a0-68bcad3b88e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "128947a2-37e4-4c3b-aafe-318137de9f07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "172e75ea-4089-41f0-87ff-465fc4f4d8ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "760445b3-ad4b-4b27-9cb7-5349894b9df4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "dfd1a9c8-b0fa-478d-b66e-23f246d16a75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "54b149cd-5efd-4e36-a50e-d584bed01b76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "041e0124-8dd4-4d6e-a533-3f2305a97c83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "4bf27883-dfef-42c2-a08d-1a1dafc602cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "856cd408-3e3e-4e41-84c4-f8f0187c9f8b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "23a078ee-c1eb-4271-a113-fde54e05f999");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "1304e986-ca9d-43bf-b4f8-58e55d3253cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "3918ef85-f9a3-46d5-89f0-d9e91f0cdc59");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "56ec3994-75d7-496d-b7a1-9d6d4638123e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "b98437ea-8789-4097-ba15-8dd81bbcf78f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "e02f9126-2a45-4442-86f0-bdef19e027ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "9907b61b-84c2-424f-887c-b6c5764a0583");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "78bea7c8-e4f8-4927-9a12-0250cf1bd182");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "765a8a3f-bf21-4375-8bc0-67852cd7dd16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "89ba5e9d-7d4a-46ab-9b2f-bb87e86e9936");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "e25380df-c104-4a01-9ff1-559790dddf5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "70dd2b1a-e782-4312-84fe-d8db44e35e73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "704c015b-d523-44b8-b5fe-0f5bf9dba43d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "3f345f0e-405d-4c88-84b9-2dad5c5e42a5");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "d018ccf4-0d6c-4d39-9728-a34b65116d81");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "b0a27708-e893-44e4-a4e8-901759697bde");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "fac94e48-a80b-4388-bbcb-b40d10be32f8");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "25e82542-c551-4915-aeb7-6442999c5d66");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "93bc98eb-c58d-4195-ba44-b93bcd1c1256");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "ff4e0305-04e0-4dd1-91a8-9dcd8ef62ac8");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "5a881e4f-e43b-4f5e-bde9-8f8958de2a04");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "264c3998-5d6d-4c52-8762-3e427ebc32af");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "1087a5ed-3ef1-40ea-adba-686b15123845");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 1,
                column: "SalaryAspirationGuid",
                value: "0916a743-459e-4be3-997d-b4ced08891ec");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 2,
                column: "SalaryAspirationGuid",
                value: "5fd2c5d9-a274-410f-a240-8158b71c4706");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 3,
                column: "SalaryAspirationGuid",
                value: "35a5dd9f-cdd9-4774-a526-81bbfd94572a");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 4,
                column: "SalaryAspirationGuid",
                value: "561f91c9-b1bd-4d0a-873d-d04449746566");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 5,
                column: "SalaryAspirationGuid",
                value: "0da4b013-736f-4139-b4ba-cb958236c178");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 6,
                column: "SalaryAspirationGuid",
                value: "7217ccda-9627-49d4-868b-b6f2366d6621");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 7,
                column: "SalaryAspirationGuid",
                value: "01aa1591-4801-4fe2-8756-0b483769c2ac");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 8,
                column: "SalaryAspirationGuid",
                value: "3d2778b7-d084-4fef-a829-c6772e5f06f1");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 9,
                column: "SalaryAspirationGuid",
                value: "551ae1e7-4478-4eaf-bc88-75663678b793");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 10,
                column: "SalaryAspirationGuid",
                value: "d941864d-beb2-46bf-b7b4-6b645b4a9db1");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 11,
                column: "SalaryAspirationGuid",
                value: "212d14dd-b8b3-49d0-bc81-2210a9efb9dc");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "bddfb8a7-1660-4607-91d2-c5ca861ed1c0");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "a08cb262-c97e-4a68-9996-8338a96bfb82");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "e896b104-fa52-4fb7-9832-7dd7819410c1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "0e812f62-16e1-4b99-8f67-02548ef88472");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "b51b9476-c328-44e8-97c7-f2df7256925e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "fa60a5bf-563d-47e4-8d5e-52b8d8dc644b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "c2c04f82-f5cd-49ec-a05e-48074c4de618");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "b5f377e3-8299-42fa-8aaf-39f900dd24e8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "51fe9a28-0b21-42b3-9042-e7433df39877");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "91fa59f9-0792-4a29-b803-643423a5e7ed");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "d34ada63-98f3-40fd-bfef-af5c416701b7");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "cf1287bb-bdf5-477f-870a-ca9c99e4370a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "2fe19879-976d-46b6-abcb-263d0690e916");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "7ae2a440-d734-4c39-a7ba-e2bda34b08c0");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "96e06eda-3866-4383-a54c-06307b8d26b5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "00659311-abae-4ab6-9bd2-43994db6c7e3");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "3a7f9298-22aa-4d85-9233-5545880806f7");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "6ff68b31-4e76-4ef5-8c25-ef1b2e0c4527");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "a44bc2d3-1571-45d7-92db-7807119cc57e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "f340408b-19f4-4fe8-9004-5e9e5aa21277");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "d93ec18c-4b99-4d45-b264-22a77411021d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "6b876de0-43ae-48b7-9837-fd72e84c9632");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "cefef71a-8e0f-475a-9001-8d24091a85d0");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "22182e75-9723-4010-90e3-94d5956ed758");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "55627699-c919-40bd-b6cd-053510cb8b9a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "3ef51ed4-9c20-4b17-be67-65ed5b5dadba");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "ace53263-f25e-4653-956d-60f109959b82");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "65427b98-aeed-471e-9d23-eb1ad02d2e66");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "c9bfee01-6d3f-420c-898c-f447afd0d00f");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "e80f9a92-94af-4a66-88a4-01731a006552");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "905b1ce8-a9d2-4fbb-8815-04a9138a54dd");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "7787eb6d-481a-4457-9704-9ad350a8a686");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "6832505b-88c9-4a57-a2fb-bc938fed63bd");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "51474671-39be-45a8-bc0e-63cecf4a9ef9");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "06154d2c-4fda-4edd-ae21-fb3d2b1f7f50");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "b51a70fc-40c9-4906-8370-d0b2142c61db");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "05662ad8-fbf1-4d15-a88e-51d8af742e03");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "ff040870-e0de-4738-b7b2-7467b282e3f0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "03918066-77fd-469f-8bef-7c747d694b43");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "71075d0d-f1d0-4d15-a8ca-792c80768340");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "76ba0335-2863-4fb8-8326-91e42c1a85f7");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "c725eb60-239d-4d66-94cc-d2d39573005d");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "cbe37d21-6a52-4bf7-b1c0-95528803b716");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "b1fc00c1-5b35-458b-ae6a-1f770d0e5c3e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "0f978e1a-e594-441e-8803-02421ff6588d");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "e7fb0c65-a5b0-4374-b38e-cd190d909215");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "eef7bb7f-093a-4e05-8874-c2020ad51b01");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "18c8e1ff-710e-4bc4-affa-fdb270e68b3e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "466906a0-c740-46c0-a263-c4b61e28ad90");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "d6d10318-ab78-44fb-b9f7-7587f77292de");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "025a90c6-66c2-41ca-906a-6de0a9db765d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "402cbc83-d32f-4387-8a73-5a69c1435ba2");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "b869456d-3cd9-49fb-8003-eac627569006");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "07915b7f-61b2-4a68-87a2-3a4066993878");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "00d2dbd2-ba8b-416e-a8c3-c42a110d5c51");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "9608b30a-6752-47fd-9846-25a93d74377f");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "c7108446-da90-4821-bfa7-b8cc3b79a9f8");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "c152b2df-2832-4965-92b3-bf8eea2c3988");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "8c61ee92-34d5-4b0d-b2f3-a7ad692ce593");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "974417b3-4c70-4280-ac0f-9eb6e0464293");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HaveWorkExperience",
                table: "BasicInformation",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "aba59f22-f986-4885-91a9-393c3116b079");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "d47fa518-4776-4db9-a68d-0dabed264a9b");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "2b4a88a0-1c91-4344-8512-88d9283f4732");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "207d56cb-4753-4343-b02f-8a81fcd24ff6");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "ca2ed3da-4244-4468-87f8-3285bb34477d");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "48d94300-7e1b-405a-bd2b-ac463cde392a");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "64b76ed4-c293-4e05-8b93-4016f5a7cb93");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "bdf08cb4-c928-42ae-9512-38820a28076b");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "6db0b933-6517-48b7-b2df-4e2ccab24040");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "b4a80113-95ce-4dba-8e3c-24c4b9ee9376");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "f0ecf77d-c490-4690-a077-1af65758f4d6");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "795a1128-413f-4881-9279-00efc37f7c70");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "336695b4-7a09-4a27-bc8c-e469b1949649");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "3f3e2d13-d1bd-48fa-9a57-e8d4a5bc0ef1");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "e7771080-5129-47aa-90e3-2a0a3b36b07b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "17e52629-0585-422a-a749-b8a86fc18637");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "02569ef3-e959-42b8-9ae8-7e27fb80ed03");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "9d5a2fd6-f462-4dd5-9a93-cdd9705fd817");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "a37cedb6-1b0c-4091-b756-b8159ea295cb");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "36f871fa-9563-4307-87b2-4d3305962ac5");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "9e101133-08a1-48fd-bcf6-3b30a1008b3f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "30b2c228-2c94-416d-a467-5931c44c7c37");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "a9860e7a-49d1-4c34-a0d7-1cd790fece64");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "5ccb5f8d-3c29-42ad-837c-5653240ac3c1");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "3f046070-30d4-49a6-af2a-1c821084b9ee");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "8da06ae8-095c-4533-813c-3dca42839fa6");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "55c83621-04c2-4034-963a-f2fef2158bc2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "e817f05b-9a99-4762-96bb-5cedd783d9e3");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "73f2e731-92da-40eb-aac4-54bc02c4f103");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "df9796a0-a651-484d-97ba-af9484c9c453");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "0dd36e62-8158-400c-ad53-425524850fc6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "0bd64d0a-f894-4be2-9801-00e847c6cc9f");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "89942780-debe-46a4-8f47-5a4eba109d41");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "9deb536c-360c-4e96-818d-916d02372377");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "d63baa12-7693-4e41-874f-c367fa8240a8");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "81414ca1-587f-41b1-b543-dc1925fd2c30");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "a7786be8-2f99-4b36-b3d7-39abe86f3bc6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "7dc7ef07-8824-411f-9ec9-e65d76435cac");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "ef6d234d-d14e-4411-8891-da81e57854e2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "f2496090-af4a-43c4-9764-0707817a2492");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "2261ea1e-07d5-4824-8fa4-7f76565cf277");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "bffa9207-981a-4cb7-a223-24a1265d3805");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "9684e457-f884-44ba-8e64-8b31877cbbae");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "aa7614d0-63e6-48db-8e3f-052ccf9cb02c");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "bf9c0ea8-06cd-42ff-a7ef-84e5ddcc52d2");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "1b602144-d189-4d55-9a86-c395e5ce0186");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "4fe5f6e0-5b02-472e-b169-88582f890976");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "cd184832-8253-4d9e-b2ef-7f4f24f5d86b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "e3f7eef4-cc01-4077-a3a2-8267efe2cd38");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "812f0d72-0e09-4d78-ae60-28a01d762fb7");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "66fa3699-7248-4ca7-b092-35b4b0f9719a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "42e736cf-f42c-437a-b81d-b7df6a6ac02e");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "f028ef96-9c53-4973-8e77-3302bcfe7a70");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "9a2e36cd-cd34-4edf-a928-47f9f9f783a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "09cfeff9-3f13-4591-b346-55410d3b7116");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "9f84d3cd-aa61-4e24-80f6-7e1dd03501e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "c422823d-aaa0-49fd-862f-bc7d24b41688");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "d258b14e-1c5e-48f1-922b-55ad302205d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "5e263976-d832-4ce9-83e3-aa7aa537c5b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "86c35e74-634b-4295-a928-381c66b6d270");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "e14b7268-3d4e-4436-8692-f168ccd453de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "e90ec4e2-c7ea-403f-8cd2-edcec0e0c3fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "58d5113c-490a-41b4-8ada-30a4a9073219");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "c02e2e90-8749-44a5-85c2-9ec90ae7ffde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "6a4c100a-f616-4681-aff8-e8a358e72887");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "0e119046-594a-47a0-8d57-cbd5e527805a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "5aad9f53-342d-4cf0-87d6-59a4ee6b838f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "91ac4350-a7ea-4e06-aac7-c7e84d2329a6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "cfedd3ac-aac4-473c-9a23-c656e1ee1fb9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "cb212a4e-a421-48e5-83f8-e1d7dfd7b7f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "dfe55c24-76a8-4f29-bf59-bc57f0c29d28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "ba47eef3-20e9-4b2f-8ad3-569c6b44a7f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "cabdf8c7-a475-43ff-accb-d7f20aec4195");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "2e0bd3b9-78ed-456c-8493-d441f37e7c8b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "b036c969-c161-4645-a6ed-f28641370c3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "b1ce0c08-d7f7-4fd7-af49-cc27fe064f15");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "202e55cb-bf2e-48c6-8cab-1162d5679fd2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "7765b7dc-1070-4acd-8e68-b8c9f052839f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "210900ee-0d78-40fa-a5c0-f4f9fac7dbb7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "7a406863-7b52-4ceb-a85e-7b2e4a1dd14b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "7177b01d-1274-4ca9-b4e1-78e4ccf73b83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "46120d6b-6970-4623-bba1-2d7809355baa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "04816b62-ab74-4753-aefb-75c0607058c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "753b09a8-7a21-4986-bb9d-d4a066728e4f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "0b2caaf1-294a-4da9-9406-278faf8706e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "fffa9862-0b55-4213-93af-623aea771387");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "49073eb7-a2d5-4279-a368-83b061ac799c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "a13efd58-caf3-4a8c-a79a-19a9ad45fc2d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "2826db41-ae98-4da4-ac3e-ed4dbf254f37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "c45ee31e-c7da-4935-94d2-e7e811347654");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "65a31d68-f46a-4d6e-9808-8e20befa6658");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "3c5302bc-b387-4a32-ba02-6f578a31f23b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "a18e14c9-2fce-4750-9625-0be11ea87a7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "25df083f-6a34-407e-acf4-ddf69588f452");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "8238df71-329b-4c68-a76f-f87483670bf5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "9bb85625-2b5e-4c7e-b4d2-133cdad87bf6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "59812abd-2a1c-4a50-913f-abdc8ae6cda9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "d4ff7f5a-bf2f-4508-aad0-e782033a8faa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "8be18835-24c7-4a23-9eca-ee72110c4011");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "af6bf952-975c-493d-804f-6a9447b7d33d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "46ba3d1a-41ff-4778-94fb-b615a6787bc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "e8b0203e-dec5-4ee8-b183-1e0e71e6ab25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "6d320089-a807-4a7c-8be5-2dd7f545c37a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "027a2694-0f69-4141-b64c-293c7c3988ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "fd4df2cb-ff12-4ca7-ad2a-2bbdd65d4df2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "317d3fcf-706d-476f-83a6-5322c8b750e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "2a4fc745-d6af-4c8f-9e06-170dd2f59f12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "50fa77a3-d7e1-46f6-9427-2d69324cfca4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "7744c178-6736-4200-91ac-c6e5ef1dc0f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "95d96618-1204-4c9a-b3fc-8b317dba2252");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "75774809-2331-4e53-8aa3-860894ef75ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "f66fb81e-a160-4e47-9a24-afaea4aadb84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "b34efaa1-ce80-42ae-adc5-dbc737122810");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "fd5bb8dd-aebb-42fb-817e-d48c5494d8dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "587bf59a-443f-4793-ab69-d4721abd7390");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "0f12613b-dfbb-4d02-8ae9-5f7c92087120");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "4b0e5a9d-2973-4aaa-8534-1839233eb4c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "df1f12d2-fc7d-44a6-b708-c673869ff576");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "9c080043-90f5-43dc-a191-410bb6863be6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "11dea669-8dea-43ca-8509-bff09b4adf03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "69de6c87-3bbb-402f-9f1a-ecf44d952772");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "61abc13e-ceca-43f8-a581-36bd61e7c9c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "7f34e0db-1442-443b-8cb4-091235293a1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "f89f5e4b-b5bc-4a41-9a47-ba6258c658e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "1b309b39-4c9a-4e75-9e78-ede969b2ec98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "97ef3704-b117-4b13-8796-3979066bf904");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "dfb3c7cc-dae6-4c4d-972e-f227b0407b73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "9ffacf1e-4388-4af9-ae99-9b8636bd473c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "b84d1dc5-a89a-49f6-abf6-6f4b7e89e2ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "ac8987ef-cc4c-4197-88dc-10495152070d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "a408e027-2262-4ebd-b08a-581aefd50999");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "0c4768ba-55e3-4193-a824-e962a4cfcd9c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "8f78bd0e-6c93-4a84-a696-235fc88c7a3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "2c6afeb6-61b8-4c06-bd3f-bff27cfd873e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "3ba4d283-af0a-4cd2-aa2c-692000211886");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "936678fc-75fb-47c6-b4f0-c64109c1425d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "d542879a-ee8d-4b75-8cf8-07b78835189a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "83a23d3c-7e50-4e35-bc43-e10e3f86f551");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "c1e13cd5-e330-48c7-b48d-b279dabc74a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "0344e15f-9fbb-4992-8b34-74278b50c02a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "e7137479-e24f-49a9-87be-235f9ec070af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "bce967fb-948a-49fe-b21f-c029c8d0ab3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "b4057219-0690-4843-88de-9901a37062e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "99cd9ce2-0757-4448-aa81-1196184849e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "2239c2a9-39a7-47ea-ba4d-8514a8ebbc90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "62cdda2c-d032-41ce-83f0-8e25f35a21b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "bf618c2e-3228-4ae2-ab88-4a6e46659009");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "403eca71-044e-416b-a64a-671fbe3f1e3d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "2a60c140-d9b3-4277-afc4-d4a5d0839df1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "1812b2c8-1b5d-42ad-b717-6df72a536a98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "f65eab72-03d8-47ac-9d52-a9ad17a0d202");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "5c80f34e-98ce-4a1b-a4ca-b847615141bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "b7c2dd2d-da33-4b99-8ffb-eced63d166dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "4d124412-b174-4e92-bf0d-29f5e2f2caba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "a706b2ce-7afe-43c8-ab95-84894419e5da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "cc24338b-303b-49e1-9f7c-eca8dc42596e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "d3e8c01a-58c4-4835-8146-030d59c70eff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "0ed5835c-bd9d-49da-a1a6-93661925a692");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "d40ba2a9-57f4-4588-99d7-dd1544e2d4f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "80bd940f-bd8d-44a4-9354-ff176e21ff57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "3dce9f98-51c1-4a9f-9820-d065759f2f6b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "daac3c26-0d11-42c6-8e1f-48db6a6c7992");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "5d923de1-bcfd-488f-80d9-cb53c20cfe05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "5c717d55-1e52-4b0e-9641-3ea634da160d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "c65e545c-409b-4a2a-a845-9c6c5ca96e0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "58f34b5a-fd9c-4bc0-8f5f-549ffd69b4c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "7713ec1a-4d77-4a0b-8133-33bd20cb555d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "e863bb0a-652f-4a7e-b60e-c75552e87761");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "790283d1-2658-445d-8de7-41a2dd3b211a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "6e1c08eb-54b2-4603-b7c7-6b5f8c34a0d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "9206e96c-5572-4d7a-ba84-e52154eed9a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "80be0921-8fc5-48a3-8080-024ace75a546");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "6ec0a9b2-d2a5-4ea0-83ee-322049fab0ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "925d0758-a7ce-4d2e-bbd3-8d53a54a86f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "840b8e38-1494-488b-be40-5853bbb2b3c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "a7e009a3-42f7-4881-a987-77044a455297");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "0e6eaad5-dff1-49b4-9881-3b2153f93c7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "e9b1168e-f62a-471d-a807-78820409b215");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "4c581660-f51c-4808-997f-ae53345a564e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "da9dd8fe-eb94-41ab-88e5-01e0b0ba6af1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "5b5185df-9867-49a9-9146-36ecf3fc7ef6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "20805b80-66c2-442d-add0-5cd3746170cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "8f7e35b9-a90f-4b24-b9b8-e3660a644b5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "9e9572fa-2d76-4aef-94d2-192c52162893");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "b362f774-b1e2-4c12-9a81-69c3c1f0635f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "7b2cbfb2-e27e-4528-936c-8e65e6c2a6de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "17486952-0529-4b65-a75f-1cff54b22064");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "8ac6d756-c2f9-4a8a-a2e9-3c385a722a1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "2b2451fb-ddad-4028-9b80-3179262a4f88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "86e847af-efba-4b58-b5a2-e02b01c64e04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "ad73d0f1-e20c-4fed-bd7e-549078e969bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "d141fb66-b0ec-41ed-b5f4-b38bdb21010b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "8968215b-3956-46a8-858f-feee6fb99e5a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "73d9d6ca-3e66-439a-a1b0-b93f4298230c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "0c91cb62-b9cd-41a6-a26b-8189263f4e77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "f49f5fd7-b685-47b4-a765-c5bc45931ce9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "eefb0566-eb80-42dd-98f0-efb825e5e39f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "991f3a1c-7aad-4b85-b2e9-ad807249c952");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "3215f2ae-1639-4d19-a252-a2b005a8a948");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "a40e1967-8f42-4454-b958-86ac7f3697dc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "a1c4830a-48bb-4e6e-a700-a244ba47e8ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "f6122175-3b6d-4371-8788-a144bb3646c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "ad846f46-e0a9-4923-a384-a5007ed18b7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "13a00653-c4a7-44ae-90ff-94302cbfb237");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "8265c1bb-c9dc-4bf6-81c7-362dbf1fc44a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "85199c8c-a00e-47fa-bad8-c75d1252ebd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "ae992c30-ca26-4453-845b-9b93334a31c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "8db5347e-5513-4b55-8dc0-d5f72381c351");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "1975cc68-b32f-4995-8e09-e75ab399be82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "bed2ac6c-afd3-4d80-a9f6-580b12530000");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "1f01363e-ffd4-4dfd-8961-5a7dc8aff304");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "5f803fa1-dd92-4b02-8a28-08a68d793ce1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "06e1f545-768c-49ad-9405-24cdcd58272b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "bcbb29e2-b6fe-4b34-bbf1-9c9afbbce301");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "465ecec2-dd6b-41c2-9819-536ddfae54c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "4f94651a-b1a0-476d-a684-d51ff174a59b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "80411654-95a0-451f-86b8-9e7064610317");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "d805f095-a10e-4e3e-a04d-3a1ec4b20120");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "ab4bb984-cd7a-444b-ba35-0eeed37fa6b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "4dbcc0e9-b839-4b4b-b0d0-8811beec6366");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "e70045b8-4a4e-40d1-a147-2defbe3f456d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "69815e22-88b0-4e09-9686-0758a454058f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "7e358845-1499-433a-abdb-6958f48f98ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "1a7279ec-5d16-48ad-876d-feff2b969b5a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "5e7901cb-332b-4ac3-a7a5-7344aa179392");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "5ca9fde0-99c8-4c27-b645-d33b23a91dbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "bc1ae807-4ca6-4e50-8a72-4665cba6a678");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "b3b8eda6-c20f-4eb3-ae7d-1977bc3f2da0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "6ebbdbfa-0e30-42e3-ab4d-ded6e3e741e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "609fb4b6-dc52-48de-849a-29714eeed999");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "5a797211-3bc5-40d5-b2e0-4f01bd2ce7ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "a7f7d2ac-a599-46e4-8b0c-d33caba45aa0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "624cc55b-871b-4dcd-b63a-44cc4bc78fd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "936ca473-462d-40da-a98f-44124b98c11d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "c30506f9-f184-42c9-ab54-905276483d8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "0916efb9-1dc2-484b-aef1-1336cebea72d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "10faff72-41ef-4beb-a289-8107e5aea239");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "98028c91-1a13-4fce-9a87-45f0c63795cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "1bc83ee5-cab2-4d8b-a272-4bae7c04ab1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "c0e02a48-8a5e-49a8-8c0f-a524c2dd62f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "8d008147-2cf5-44e4-8b48-5b237e22af13");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "e8c4a390-89f6-4043-9c9b-0c225445e322");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "b99e7348-7dbd-4490-b14f-a42ecad74ee8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "40da2941-8248-4aa0-89b5-47d7a85fd099");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "2125d854-ed44-463e-bf93-a5a94a996324");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "93c8c8a6-1775-4c7f-9ecd-f36baf9af58c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "5749c561-105b-442e-bdbe-3b4dd23d1e67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "2d29672d-47a9-4d05-80a6-653bb7e100ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "8f1eb0a2-3672-4f15-aa37-422c1dfcae14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "732b22ee-5222-48eb-b952-86e3b9adfc83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "89ccbbde-1a18-4a7e-a93e-a47227a10102");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "397e18c7-78b4-4510-81ac-47cd2edac8a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "0a28fb66-28a2-4721-8dc5-0859e62df878");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "a47e86f1-f446-4315-ae73-ddedc44c1b16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "8ea84ae7-28f0-435b-b9fa-804a5eeecaa7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "e3ca2ebd-0fca-47df-a794-ad29f886711d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "0c1e27bc-abd9-4152-b513-da57a2e309c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "6122bd8e-0a97-4308-9c97-ba04212070db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "307c539f-6d84-4315-bcca-6a8e94a29d43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "5f89a358-ad65-4310-92f1-80da3293f512");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "1719e441-e2f8-4a57-88b3-ad9f4b1311d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "bd8fd40a-6906-4f23-ba6b-4295b9964a1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "5acec153-c45f-4e04-8ac1-aef53d8d3f2d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "dbdd7be7-111a-4eb4-b383-0219e29c9c9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "ef2aa2c3-a6e4-4207-a45b-73393c996baf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "060e8811-2bd5-4b70-8302-a8f00483891d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "4c59ff5f-895a-407e-800c-f964d18a1114");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "34d07540-c60b-4097-aeee-23b3d5544ce6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "496450b0-af98-47b5-ba54-61f0f1811b64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "68563aac-707d-45f5-8d47-d00b45096f15");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "538e8b66-1b25-4e43-8d9e-81c059a6bff8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "9f9e8fe1-c8e3-46fa-bb2c-9132e278a9f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "3a88cbfa-178f-43a8-91ce-f8410ceb5c40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "17cb039f-edba-4235-b7e1-4a012ac2c948");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "7b7e063f-1eff-406a-adf3-b4e38a21f25c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "d7d08615-d0b9-461d-934f-a08ad25199a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "b125e0dc-6d69-45e1-9070-069f42ac0119");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "84258cb8-414a-488e-b201-22c845a7796d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "eceaf012-ae73-4597-9714-f7f560ad2eb8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "352876f8-ddcd-4882-a638-bb60b8aaf62f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "503b1e7d-b486-485a-ab12-2d416dc98e77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "8209b994-f72e-4c96-9200-dc94cdd2bcb6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "1bc961e7-6499-4202-9602-0add19630566");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "dd49fdab-b944-404d-b6f7-fe0c7b9653c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "878b9738-ce56-4050-afa0-658c4281dd58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "6f16cf21-023f-4c7d-8b80-a9109883dc7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "b39acdad-79c9-472e-a4cd-08e9aa47a690");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "4c0c6db2-4b7f-400e-874d-5c94693a28fb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "21438fbf-8a73-4421-a513-8e5b9cd23a7e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "e00aef31-ce43-435b-b8c6-e4bb5e8297a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "51e932d0-8bf3-4b02-8d71-61be8fb915f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "b33d6f73-7f96-4820-a67b-bb4b76b491cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "9dea1cca-52c9-4319-b176-218bcc53feef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "33097ed3-d450-4701-bf9e-d5cbc4e9410e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "0e9acfa2-d6eb-4e8a-80f4-75a43b7214ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "67e86041-8b61-4753-bce0-cb597d21c7f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "15984d6b-0f46-4a71-9422-8683761880a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "322195d8-7005-49e4-a844-82d2dbb9ef39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "824cae58-0b00-4078-a782-eba0133fffce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "38f86899-331d-462f-8e4c-c19a0728ff9e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "1ac9a177-a1e1-4793-bf09-d633bdb156da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "8a940a24-2807-4b54-942a-7ba73ce7bb80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "58e79143-7559-4786-a374-a875c4eb330a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "ea79b95a-7220-4ed3-a351-66711fcf27f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "4cb1f7f1-6384-407c-967e-3d06659a0288");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "6744bd38-d095-4800-ad74-c2333e3e9e32");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "21d1487a-389e-4018-a2db-9337386130d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "33eeb332-4ab4-4217-a5ba-38ce22ab651f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "2d0a10a1-f131-49ce-bc64-4645abc9296a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "92fc7204-6030-4e17-9539-91b0c7d1e9c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "69248997-7c7b-4def-8ab1-a680868c505a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "5e66a4d4-315f-49c6-91d7-8f70bef062cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "dc52c0b5-a999-44f7-9503-4589f5470e34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "8009056d-4357-48a9-aad6-7c01ebde1be8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "1b0d58c2-c993-4577-80d8-707ff8da400b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "040f8dd4-131d-447c-a501-839bf69c213e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "fcb1dc21-a1af-4557-b8ae-9eb9cf8788fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "05f09acf-6b01-429f-9f67-3594471007f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "afe49131-066c-498b-b13c-7eb35d6036be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "f1b1e1f5-1ef0-4850-b639-d6268f6e1f4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "4f3507c6-b1a7-4277-a8db-1d7a97063414");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "b520694d-8839-4b73-87d5-326ed1535b97");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "83a7d994-65b8-4b00-9f36-eab13d475acf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "8be62819-44ad-4254-8e0e-4a5acc82f593");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "22efd926-3cba-4eff-b648-a33b32548449");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "d1a4e14b-df2e-4da7-a27c-6a7d770383af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "ff16538b-1e30-49da-8730-8e1d25be9b95");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "9499c616-f222-403b-afb3-034a47374bbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "c15c72dc-6d64-47e0-ba5b-af80763118fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "e1682244-0642-4510-84c9-91c2844029eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "a739a451-5d9b-41ad-b5e1-e5696496d905");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "0b7665ce-3970-432e-a67a-191eaa2da63b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "35a2deda-b4e6-41d3-8894-f88757697215");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "8f37e96e-26dd-43e3-b867-b1f9b474909e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "650e4ac3-2f8c-4987-8445-3076bf11c96a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "5f931130-d872-4f6b-82ec-8eeb517704a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "c8dc49e5-d15f-4165-98a1-2f826cd6d0d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "dbeca9ce-b430-4bb5-a85e-6630624ec637");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "310bfe02-a7f3-4683-bb95-17b6d549a8ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "08eb7438-d542-4b43-a9e0-93d2ef6adcf0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "b3603e98-4f15-4072-bbc6-3b8a8764b0e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "41af2b58-57db-4d5e-8850-ef3785377f1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "581dca9e-2660-41e2-bb6b-f6cda1e44577");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "23b600de-47de-4b3c-aba7-74d25c1a1b24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "4e8da772-3743-4fac-97fc-9a6a2ecfd81a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "2d9c8590-b743-485e-b824-8a92cb09fe5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "f9a6830f-f519-409d-af17-1444490cae4c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "269f1c2c-1fd8-4125-a8f5-476b6ccc8cf0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "2c89d522-3f7c-47a4-abaa-223cb2200a2f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "10208fb7-8bbd-4872-b032-f13a1df82e10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "a1d85e38-8716-47ba-9506-f0317d0097f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "3f6601d2-7ac0-4a67-b051-e1197bef8d99");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "a7b64e49-54a5-4c97-b558-e62cdc93573e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "646df451-6655-4f88-b563-412fedbfc26b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "f288780b-6982-4482-b3a7-bb8394864f88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "c6d78c33-803c-40fe-8a4b-4a83abdb6654");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "9b7f7e7d-0ff8-4dad-b65f-7740e2f5227e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "cc48ec7a-a6c7-4153-8258-b7a940e1609c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "3a77cbf1-518e-49ab-a200-74d751d4b03f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "eff83b49-1f9f-4970-b34c-ae3a7fc060b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "2670c554-68eb-404d-8666-dbec98f64766");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "587cc426-a61f-459c-af03-d2191fbd8ede");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "31ca467e-2596-4f86-bb31-a018d7ed3a0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "42066c8c-20f6-4eb1-b5ed-a0a8a9ec50bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "259cc9b5-f945-465c-bf0d-4049a115563e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "2aebec3f-6cd3-415d-a30a-a50f7483da31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "933902ea-1c27-4432-a1c6-a3cbb31e6c3a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "987946ad-3453-49a4-8739-eb89a05bb49e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "8125aa16-f2b4-4bde-a04a-7e35dcc7bc29");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "f7b55637-2ab9-4a6c-ba1a-be3ffa61e7f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "e45e1b9b-4496-4230-861d-691bb235e12d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "ebbfaba2-fca8-48aa-bd36-efeaa6deb2c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "94534c00-ce6b-4281-9ce3-73fcd35c56e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "c76b2cb9-f5a3-42d1-885c-0a9caf354e0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "63e71e5d-6909-43f0-83c4-25e194a8b629");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "039146e7-c9d0-4d3d-bf8b-a715bfcaf14d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "497ec6b9-6c87-4590-be02-8f74c5982bdf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "a881a2a4-dd23-4b72-aa8b-2937ea138c01");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "1c593cbf-8df1-4e46-8193-eea6b8399e34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "b2ee9189-362b-4366-9faa-a6eda7da3798");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "c3915ef2-f0a0-4cdc-aa4f-e7b7956ab528");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "af1afced-2f48-4959-9c51-cd47d91f5115");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "a40dd77d-dc08-4f85-ad7c-491f58309cc7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "f132d1b6-1fe9-41e1-8d10-b7d278b9a3ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "9921a1fe-3a9e-43f5-abc4-73517916374e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "fab90089-91c0-471d-9eb2-eb0133ec7372");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "e91a2de9-1e94-4fcd-8ccb-b3bec3adb9c1");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "add21331-99b9-4f49-ae5f-4eaf65d96a6e");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "08d8309e-8349-47c7-9a5d-71f6872d8a1b");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "eb313795-7f76-48f6-82b7-46500ee88c41");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "f4e7df74-36ec-44cb-933a-2a0b01f91d3c");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "e814906f-a9b8-4d78-8c29-6937f18658de");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "1574c8e1-c578-4445-abce-29f38b9e6ba6");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "151ec054-393c-405e-be95-51fbc89b8d6e");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "2e9f6cd6-e786-4013-8545-30fbf2999d5e");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 1,
                column: "SalaryAspirationGuid",
                value: "4568ae0b-f65b-463d-bcfd-d60d41e0e6f7");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 2,
                column: "SalaryAspirationGuid",
                value: "796205f3-2390-4f35-9744-ffd89d2a8ed6");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 3,
                column: "SalaryAspirationGuid",
                value: "e6fb2f15-7a7f-4194-aefd-d7a396294332");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 4,
                column: "SalaryAspirationGuid",
                value: "4d237d17-0e98-4621-aa1d-5ce93b8696fe");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 5,
                column: "SalaryAspirationGuid",
                value: "18ff1650-1b00-4620-b73c-5539a7041c76");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 6,
                column: "SalaryAspirationGuid",
                value: "43876cf3-79f1-40b7-91c6-25f125f42362");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 7,
                column: "SalaryAspirationGuid",
                value: "12c6fd07-ade4-4432-bca5-5eb25d6812e6");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 8,
                column: "SalaryAspirationGuid",
                value: "d04acf65-89b6-419f-ae1d-57a1a3b95b5b");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 9,
                column: "SalaryAspirationGuid",
                value: "830127ed-a7be-4dee-8a31-6868f8a914c0");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 10,
                column: "SalaryAspirationGuid",
                value: "23600258-9f1c-4247-89c8-ba690a77e9a7");

            migrationBuilder.UpdateData(
                table: "SalaryAspiration",
                keyColumn: "SalaryAspirationId",
                keyValue: 11,
                column: "SalaryAspirationGuid",
                value: "b3961d2c-4d51-4c7d-a2d5-d59012745733");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "931b7de6-cd3f-47d7-81e9-195c6aaf312b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "330c7f60-9711-4d86-84b0-ec7a54be99af");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "1523ac98-3ddd-42f9-8369-035350ba9b0b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "6f66dba8-70bb-4224-a276-99fbbe741b2a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "2da82969-35be-4e06-a94c-437ad31b2b70");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "23123dab-374b-460b-9832-26c3d7961269");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "4938cd84-dae3-49df-8865-06544180ff52");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "455034ea-b6ae-4d7b-a048-0c084c9b275e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "237a453c-7af1-4688-84d3-4fccee6d39b8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "ca9ebe9b-5c59-4a33-81e9-a3ac0853107c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "4ded6459-cb27-4b07-a4a0-1c983c38651f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "fabb9593-7b8d-452c-8c5f-c0d9a2ccd3fc");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "873d0fcb-d017-46b3-8aca-41ab58e28165");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "c02259ab-f541-4f37-914a-b9fac506f3e7");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "4a32815a-9262-40cf-876d-059835b0a74c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "1acc2fdd-71a2-4a3d-9a3b-ce3d37b0b0e3");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "f50b3ed3-210b-4cbd-906d-49a4d771895d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "ec4e78c3-4c86-47b2-8c6f-b32cd511ad3c");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "5734cc3b-9197-4aec-8f47-16a6f37f9234");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "9477b248-73b8-4f0b-b888-65d90a617ab8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "cadc44d7-d31b-4d48-a1b0-39a6e71937ca");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "71dfd659-33c3-4bb6-8494-9ddab38d69fe");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "17234aab-9818-4fde-a8c6-690795d21b54");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "a5235b54-8926-405b-9184-6d1c68d1aab5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "03d5498c-f84c-497f-abdb-08b3f357a4e1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "21236f6c-d634-48cb-9732-e58c04b226b9");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "6b2a1e3a-1773-4cd7-ba8f-a6da85610a37");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "25668007-b972-4003-ba62-546720c74572");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "3e8cd6fb-15c0-4e76-be3e-3bddb15df823");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "07452383-2e7b-4539-a102-965e0a1d4009");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "3da3afed-d3ce-4025-b4d9-63ca65182821");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "579e65df-95a7-4a02-babb-8ca68b268635");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "7e0c6fef-ff35-42ca-a2ff-328200234b94");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "ecda87b2-35ef-4d49-96b7-c3be59dcf4d5");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "105ad795-5165-441f-8b4f-6e76032a9bf0");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "101b0732-2746-433b-a231-088fb7f37f21");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "5d84434e-d193-4949-967d-880e817eba92");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "0b3c44d5-8148-46ff-9141-cd680f11f7b9");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "dd761fdc-aa71-4b9b-8e77-785615fdcfcf");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "694b001b-04c8-458e-b15a-256e41e78efb");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "5dea919b-0304-4868-a535-dc08f4918579");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "3b92f90d-e8fb-43b7-8113-3655fb711cec");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "50bccf23-8adf-4d01-813f-a5ad4fc21726");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "e93b6195-302b-48b2-8d40-4632d513ddac");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "54981b60-b916-4556-a012-608e93bde269");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "6dff0386-a2a0-4c2a-b056-f286d2e2e975");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "ed83132f-bda7-44ca-b5da-908f5339ff0e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "14c4c1ea-27f0-4c2d-8c69-14bb03671789");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "2ade8eec-78dc-459f-a00a-96f4b5a2f3e0");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "5fda43f3-fe62-4554-87cb-69ae80ebfdc0");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "f8ced55a-4eb7-4809-a575-6bc2a3748d4d");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "e0a9c903-9722-41c6-9452-832e8eee60e8");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "b5ade2db-299d-4a8e-b265-eb793b20173e");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "1f4606aa-53e1-4141-bc1e-eb9009aaf799");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "0eea736c-bf60-4a45-9c2c-7b76f4564228");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "f0ca3406-16c0-450f-8c37-6dffb871c0b6");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "05486351-4fa1-4e7e-b5b5-d0862f7894f2");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "0623eb30-1c9a-47d6-a48a-fb830bbbc321");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "a162d172-c428-4c0d-ae65-5ef567ed5a21");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "0f96fb27-52dc-4f70-9700-368a0062fc99");
        }
    }
}
