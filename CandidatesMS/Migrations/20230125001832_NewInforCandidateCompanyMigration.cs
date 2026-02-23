using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CandidatesMS.Migrations
{
    public partial class NewInforCandidateCompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateCompanyId",
                table: "UserLink",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Study",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateCompanyId",
                table: "SocialNetwork",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateCompanyId",
                table: "Phone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "PersonalReference",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateCompanyId",
                table: "Email",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "DocumentCheck",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "CV",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "Company_Candidate_Wellness",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "Company_Candidate_TimeAvailability",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Candidate_TechnicalAbility",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Candidate_SoftSkill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Candidate_LifePreference",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Candidate_LanguageOther",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyUserId",
                table: "Candidate_Language",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidateCompany",
                columns: table => new
                {
                    CandidateCompanyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CandidateId = table.Column<int>(nullable: false),
                    CompanyUserId = table.Column<int>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BirthDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    HaveWorkExperience = table.Column<int>(nullable: true),
                    SalaryAspiration = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateCompany", x => x.CandidateCompanyId);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateCompany_MaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "MaritalStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "be8aa040-5ee5-4098-8524-3cd9381cd132");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "021375a0-196b-4aeb-8c0f-67895f2796fa");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "e7da74b5-9cec-484d-97f3-055d3a44b80e");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "ec610166-9da3-4262-aed9-d3bfca4d9bdd");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "29e58f2b-3fd9-405f-b01d-2443a8442c64");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "f18eba14-03a4-4273-8503-e57c12ae46fc");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "20838a84-6982-4829-9b9d-31bd709677c1");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "9db8594b-6dd4-4322-92d9-250e92b4fdf4");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "7dd6e137-a96a-4a70-892a-fe31d91c7174");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "ef500744-1028-43f0-a952-921eca6be178");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "85185dfa-3be1-4f6d-aabe-5cbb47c553a5");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "77390fe2-fe7b-4972-8d3c-83228b0116bb");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "a3071f2b-a1d6-4831-b247-b671e842b69b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "1b14517b-fe39-4c4b-828e-2668c858a862");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "4fe5503c-ac03-4df7-8e79-9aa357eac941");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "642e46f9-5c66-464a-86da-e8883646fcab");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "160b9f1f-dea8-4951-bfbd-72f7e89033ec");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "24248e59-b8ab-4b84-84bb-af1797de6eb2");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "b12f3d46-ca26-490e-a50f-f6c1a8318874");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "3efc3131-ac31-47b5-8bff-74559bc2cf09");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "027f3a52-9e97-4848-b1fa-119375004994");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "74e27d67-9398-46ac-a5ff-0b8af46d3420");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "f4bdfcc9-42e2-4f03-b408-24522f907a8d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "31614b94-c981-432b-911e-0d8c47ba525b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "2d889df2-6c5c-479a-9ec4-918550465a08");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "d76fd951-1a8d-4e29-baa4-5096092774c5");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "f4b9f352-99e5-4f0e-afea-c3e766c7d546");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "d68c9cad-41d2-43dc-90f4-7aec6a1efe85");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "cb44a39d-ec43-4cf7-b043-5e9e45de3989");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "4955489d-1b0a-4e46-b45d-038aa83aa7ef");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "a7a19287-e889-4cfa-a155-de665f48fc0e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "0e2a31b5-e5b4-4305-803b-d280d9016e34");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "07bc9f4e-9cd2-4494-badf-77112d8a2f89");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "051f0fb6-ae85-429f-8303-45061a1cbbdc");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "9af18eaa-3513-40b5-be4a-fbab8d317119");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "836954d2-a22b-43b4-90fd-fce413751fc9");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "2633fa6e-3099-463c-befd-94999b1ec9ac");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "2b0a96a0-23e9-4c32-a4f7-97f790aa87ab");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "b6971be0-7931-4e8f-8bf7-9caf7ab77757");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "382d3bf5-2ff3-4511-a36d-d42dd98eab68");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "de167d60-5ff1-46d7-8088-128bcb130d56");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "94a41df7-b5d6-4b6f-b5d2-8f0a57c13f36");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "b82b799e-0fc0-4c9d-953a-99b2b50bfa64");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "0751d5d8-e92c-41f1-908e-14d53ec88978");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "68134400-49c8-402e-93dd-54d3f41d14a5");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "905239c9-b7d3-47db-b05f-c6c6983cb19a");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "21e63450-d55d-43a5-9e0b-ae7d86f00cdc");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "b9bada94-880e-4696-bbf2-8c4cec982544");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "92cf9850-3014-41bc-b9d5-b8ec647c5d42");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "cc174bb4-6ef4-4e44-9cee-218e1af6feb7");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "48f18bcb-485b-4504-80de-34d8fb3793fa");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "0d7d27b6-7629-41cd-8343-2952266adf59");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "f29c3496-9a14-402a-ae6b-db8390f54108");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "a732bbff-af5f-4a6d-b655-28a481669dba");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "3e14fb18-160c-4c00-a3d6-131801aa1cff");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "d22414ac-d1af-46e0-8fe0-bbc6ded8b36a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "2c9816e4-b575-4890-82e9-ddfb6d1c62dc");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "ba963a07-a443-4d46-8a1e-03762c2f88b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "69b6442d-2b40-4b86-a082-2bfc3e2ecc2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "e0320ef0-1888-4465-98c2-1ab6c87cff45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "73f6f9e9-9a88-4524-b1a5-bbb67d0b3203");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "08de839a-f5ee-40bf-b364-da147c824779");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "c8615735-b546-4d59-b15b-1daf0bc9f4ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "edabbf89-601a-4162-8990-99ea8fddbe10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "f4a926a5-2ac0-4f10-b2fd-94b44af91047");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "b9fd93d9-728e-4675-ad9d-a32a4667a4be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "e407c482-82a0-4e96-8ffe-dc87983683cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "6dfe3b9e-7785-4f57-9a33-4ce25e0525a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "a0e7a759-9501-468d-98eb-fb8c23ca95e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "29097f25-8d33-4e4f-b366-3d691a0373c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "e0903604-73e1-4e3b-b040-ea03f5cade93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "f57ed12f-6d33-4a8e-8753-2fa2f48b4acf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "ea99f37d-7306-4dc6-a2f5-2c63d57b1052");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "2a21f907-bea1-487c-b9bd-b87341ee102f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "952bed5e-b8c0-430d-9df5-ffab0cbfef3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "304533a9-6d37-4e73-8029-02f424c5f2a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "f984220c-4667-4e82-90bc-c95d94e93389");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "f84844cb-30c4-4911-b902-3c9fe3b26823");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "10e1a1bf-2d34-412d-b4e5-c4daff0b8b3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "18d3f453-6b7b-4515-b199-5e141f8e41b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "17983d37-d2e7-4e9e-a2cd-27240a9e5fb2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "4b680eb3-b705-4f73-942a-fd1ce7051bac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "d4f83103-27da-4ad2-a664-c9425ff5513d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "125a0040-d128-42be-a6aa-dd74a567f744");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "8f4e1dcf-2664-4763-a0f7-200d3c38ed04");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "704fe0eb-9464-4e55-9385-c2d3dc62e022");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "24ba2620-5f5a-4563-8172-f6ed9514c6b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "646deaa4-69c0-40fe-b474-2f87f7015e89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "5c20f0c9-ce09-46ac-8038-d0dd551150bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "689d6714-0914-47d1-8a15-5c5016fb9b27");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "aa9b7045-5be9-451a-beb8-884293e7942e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "1bffbf37-ea36-45f1-8ce4-99af860c2322");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "026c137f-b2fc-4537-b2a8-251805726901");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "a4c29230-1d20-4c90-ad1c-5d29561d278c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "e65c3414-6d00-4e4e-bbdd-881c172a1919");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "d56e155a-0f84-44ce-b694-6a1cbf3bba94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "9a93deb2-28f3-4260-bba6-39d6291b60e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "15242b53-ffdf-4543-ae57-5577bb970724");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "fab51a81-46c4-4776-8010-aa69437896b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "ef378fb4-439f-479f-80c8-aa43a02759f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "8d883822-ce18-45da-bb46-66cfdd8dad80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "fa624c88-7608-475c-b9da-52018439db12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "11c26084-4170-4f4d-89f0-4b8a45c51a69");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "fbe67ba6-7211-4d1e-bdac-8f42605a6792");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "4e7ded10-cccd-41cc-b9c2-a30b2fd3a4da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "81cacc89-6049-4c8d-934a-530a4ef45381");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "10edb5bf-fad6-46b8-ba8a-400f4cd262e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "5a8e76f5-d1ff-4714-9877-507e7679e892");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "f584c331-2b0f-4d8c-a9dd-ad0b802339b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "e13bfbfc-267f-4f2f-bea0-bed6869ee037");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "e2b102da-7b4e-4117-a110-396597b4a9e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "68ce9256-4d8b-4904-9be4-a15436a6c1f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "c646a221-6bb7-424c-8bd5-528340cc8719");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "47e94956-abdf-49f7-b4c1-a8e12560d34a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "8a7ea7e5-3d91-485f-ad7d-f5279edaa7f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "ba60b772-663e-4c36-8a67-8cbb3e47065b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "42e2e9bf-9ecc-450f-9529-91a721b4fffc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "d56f7b8a-3867-49cc-b74b-f99869cd9717");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "d081310c-03b3-45c7-971e-d287cba2a03a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "cef8c2ee-c8c4-45c7-b105-7d4d67940d9d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "3314a4d0-59db-423c-afc2-1b0ca131c7b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "88d30ece-f8fc-475a-ad68-78c128b57200");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "7113b590-c685-498b-b7c1-1b115dd908c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "635c2389-9bd3-44c6-bb6e-facfd32af274");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "d244ed19-83a6-4a90-9303-28f004735c0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "826d07bc-c4db-4478-a406-0c2e47eb4cfb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "793d08f1-ba5b-479e-936e-a1f442b01166");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "5b04ff7c-a608-45ac-9fe1-6bad8df82b44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "783d6e4f-b5d2-4390-8410-5e6e8fd9c0b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "d69cc3d9-59ad-41cb-8bf3-2b960eff4520");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "ea69153f-0358-47da-b185-2d5eeb17044e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "8afe512e-e122-47b8-84ea-9d161fc7e430");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "887e2801-8446-43f6-8a9c-9bdb089e04e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "c9e5eb90-b503-43bc-ac37-cfd07fbe67c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "9761bd42-0739-4d5c-a59d-cfdcfc72f4c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "03b99357-af44-4902-86c9-4613a2ab62c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "1b463b52-ebb5-4020-b05c-6a2dda666942");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "d0206180-d8b5-494d-8f20-e3ec1b4adf53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "9cc1ae86-9dfe-4689-bbe2-2a466be77cd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "065ab44e-af58-41fc-8767-d63cb7e38476");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "b6ccded5-1af2-4ba5-aab8-92ac14317a57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "b9e18256-50b9-4b71-b642-f7fbb0928db0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "7aa44df1-4971-4686-a2c9-d381b3536944");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "025df6f9-cfe6-4577-a6a4-c8fdebc0e7c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "c2ef455a-efb8-4d42-a633-303525de667f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "960392bb-346a-470d-afbf-c4e40fe8b6e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "7bba45a5-599a-47e9-b4e4-15b82d82c5c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "03d631ab-e1a0-4b72-a07a-d929570b2895");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "bcd6f7d8-ad06-4a12-baab-9d264dfd0114");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "446dbcf4-5325-449e-9dfb-8b4f32c80c4f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "19b98186-c538-456a-9eba-a28991531a77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "d22d212b-b8dc-48d8-95a2-8c27273f988f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "23b8487b-ba52-4da6-9912-211c577912a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "f1be0f00-7e4d-446a-a6c7-4ff30f9dcb6d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "e3cacd8a-6ead-44b8-8c55-653b3bfa3d82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "e8270b74-8642-4776-9b2a-142ec51d18f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "6e1a8f60-24e9-4216-9af8-192af4dc4a35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "68320609-3dc3-4cb4-89b0-3fef68dd45eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "c99f3439-7354-4587-98be-3965cac62d3c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "469aa96a-a2e7-464c-8f77-651625e170db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "f86b6249-8e5f-468f-b25d-eef9fdd7ced2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "09c2b2c1-9d58-4b7d-8712-d29190824301");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "5bbfbbb8-b627-4e58-bd72-44590308b6b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "1a310a40-85b2-4ed3-95a5-20275f2ee760");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "7bef9461-09cf-4b11-ad1d-83a39e3efe1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "2a3a1ece-6ebb-46ea-ba00-947b92e57d8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "0c62460c-378c-4cf2-904c-3a008e2fe4cd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "9abb69ea-a42c-401a-b93c-7c30c3a420fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "95c4c974-3ceb-49d9-a8fb-47a88532250d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "3fbda006-b66c-4bb7-a724-a822f653cb71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "48646bd1-1b14-490a-a6b4-5326831f04a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "486fe139-dc4d-4dc0-bd69-c048869c80a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "a56ec76b-4ec5-49b8-9177-35c0c7f09211");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "40224e71-620c-4b08-b134-23490ce8eb93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "400aa82a-b557-4b72-b72b-7be4149c8cf5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "05adc43b-490d-4d15-9b4b-5ce315a7c432");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "15ad7fb6-b1a9-4f96-ba61-3be57a12baa8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "05cfb6c2-f96b-4e0b-84c0-c316329d97f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "6c7da7c6-1c94-468d-b20c-65b028bba6d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "5a7e6bef-1714-4e29-8b56-6584182594c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "9f514c8d-06c0-486e-90fe-90c21a860bb4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "f309ab12-9948-46da-b32f-41c9923886e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "56e1c36e-6264-4e14-a552-1955d58266f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "d36e1bbe-473a-4a2c-8f72-d181a9f3a53c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "5d2c9e2d-0441-411a-a5a6-2caa041925b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "8866ab6e-ce23-4b9f-9e08-a6ec2fa403fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "be5b8cf3-8355-4bda-85a3-9ea52ea63b44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "0ff0bd01-d63d-49e5-a15a-7a06f472d397");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "eef6f4fd-fcba-4b8b-9750-3e2af434ddcd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "1abe86de-6c5e-4add-8271-5827941e8041");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "32851838-d48b-4c9e-b094-989cd5e457b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "200f6c3b-09b6-4a39-bae6-1a46c8f196ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "0785c59a-1802-4a06-a0fe-117f5eb2865c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "e363c85a-b05e-4ad6-b056-5b49b928f605");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "5a9e21b3-c3b1-46ed-82da-466a96bf9082");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "1a66c6a6-ea24-4a1e-9480-eb8b5e4891d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "1a81dda2-16ff-4314-a0e9-6da73816ad0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "f14e502d-0242-49ec-8a64-dedeed70ba73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "e1a51558-fe34-4ec0-a697-be944dd5619d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "4cfd682e-8a99-47a6-ba15-b87d7b397661");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "0dffca94-fc98-4af8-9038-fa5848175278");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "fd9da99f-bed0-4da9-8a96-f9414c1afb16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "a83352f1-013d-4061-8617-b0ec16d708c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "4e0977c3-fc43-4d6e-a198-a23727f7c33c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "b8bb8a2e-ce0a-4fd6-bb01-bb4179ae80aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "476874d4-0b53-43c1-a243-7e7b03c063f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "f6cd700d-21f6-45bc-ba88-9d80672c53f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "4ab622a7-a3d3-4f86-b4a7-10dd57d016bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "4260f41a-7dee-4940-a6e6-ce391877d993");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "aa9411ed-5c7c-4b33-ad22-62541401755a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "6700350f-b55b-48b7-92fb-6f2a1438efa6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "8bc9de3e-302d-41c1-8500-65ee9e78140c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "fbfa0926-9bac-4eb0-8506-a3f60ec42c3a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "ee32eb41-0e10-49b9-9484-38d6d7feb137");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "53a30d34-fc56-4323-8524-70df0dbfcac0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "9056a81d-e47b-4968-b767-1241cf7d6276");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "3953f9aa-66f4-4705-91c2-30903e8a55e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "4fced655-b299-4862-9a46-028bd699e3af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "ca6622e9-abb6-454c-aeec-e49d992521b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "2fa7a7e2-9556-43be-805f-94e1acaa7de0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "54587b89-e27b-42e8-9896-e51bbb6e7ccf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "3a16d567-c93f-4cb6-bd3d-cb727dc6db56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "c3ff5881-e1d8-43b9-a5eb-6070a8f95529");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "be7dc0b6-9f6f-46b7-8e8c-5e094a409f12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "d0eafb2c-9965-4cd7-b949-cc5593352c76");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "e8a50067-e939-44e4-8206-b55aafdafe47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "22bdc19c-a703-4b62-acbf-b6c779ab4fe9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "1c983f25-f37c-4694-8d7e-9b0a71d29ea6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "9ecc9873-212d-4eb6-b930-8e2b4120d7f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "b302712a-d4f5-4d6e-9496-a1a90b16b6b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "65e714fb-c1b9-4450-b8b1-f5685acf53d8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "ed81819b-c5f7-4147-86fc-dc8779e86bc0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "bd5ca9d4-9b8c-4ca2-905d-b1b1ba82b6f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "e665f329-18c9-4dd4-bbc4-31a85d4414ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "2de106a3-cb95-4be5-bd04-f5a3558e2da6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "b8475caf-1b77-4131-a0db-2be7cf0c3195");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "8a9ebaac-ce38-46bf-afe7-35b3665f21fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "692b3cd9-661b-48a8-ab9c-db8fea58e7ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "7aee3212-98c1-4b9a-968a-d90e16ff50d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "0160dcd6-033d-4e69-9109-94429f5dfaca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "492c13ab-3b4f-4163-8996-6921c7dbad38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "f82b4669-1b11-4ab8-8f85-561ce1456eb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "6959d038-6a19-42eb-883f-57d59b475932");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "4c4ea7c9-4f12-4902-854e-88df3a732e63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "fecef8e5-f7b5-48f0-be09-6f49c016a6d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "4fcfce03-8e1b-4a11-adc1-2b0c8c83ee72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "60c274e7-649b-4d16-8e62-0fec7ee8c62a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "eddaa4cd-2e89-4dd8-84db-dd8b9d39ce87");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "a3d16efd-cca7-46b7-8366-8c4d45035baa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "ac74c6ff-63d9-4834-8754-ded79f5b269c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "85180a4e-5fab-4b2e-9818-479ed2d98cd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "1299577d-a94a-47bc-8a31-4d0063febe92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "96ed9433-c94b-4a3d-8dbf-8dfe214797c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "08130f4c-d405-4436-9f1e-44f49482cffe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "05b7772b-21fc-4576-a377-b8eb6e414c23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "3124002d-dd1d-47f8-a4f1-922e606b883d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "c8e5214f-d576-450d-94a6-eec817434b20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "12762f37-318f-423b-b053-df6f2df9e4a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "d87432cb-94e9-4d25-8d39-7efbc268ef6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "b1b97623-7d21-4a13-9ae2-c4761f4db64c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "995f4adc-79d5-4259-bedf-d527ae1a43bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "6daf56e4-15c6-4d00-a0d0-2b4c7d61435d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "f657767c-2364-476d-a740-c4d2452627d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "93875129-7fbb-4390-b854-6fe1e81af77f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "47d372e3-a8d9-4a0c-abfe-ea349e80eed2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "df3f8a3b-1633-4a24-bd70-ebf0f79f8b4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "38977445-26f9-46e2-b20f-0385bddf02f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "2252c9fa-3a27-4cef-bd40-bb0e3c269f16");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "d09104c5-f2df-48d9-8ba9-b495782fe19d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "59e24c67-964d-4935-b629-fbd62d0b886e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "c4566f2c-0513-473f-b2dd-3f248dbab76c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "ddd80304-c156-428a-bd5a-796218ebd9f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "fa988d27-d981-48cb-94f8-e7b3fd35e852");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "016bedc8-79ee-4254-946e-7e2b2b757ad1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "9d4a5548-319d-4bb2-8461-1a7c1254fed5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "d89becb4-769e-449d-9253-341ba1e83182");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "05d6abca-9576-4e77-822f-213ebb1085a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "8f56d9e5-a743-4ee0-ab68-dc8187a5ae05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "b5f94cc7-fb97-4395-a206-09ef2bd0ab4e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "872a060c-49a2-4b81-b475-ed8e6231416d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "dac135bf-0de3-4f62-8d4d-7d92c289106b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "0f97a67c-c378-40cb-86c5-c2c837e74032");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "dedbab0d-5960-415e-9b97-37822be2407a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "56f07458-3494-43ee-bbb4-284d243d7f4a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "cea48a1a-a9a3-4f6f-9b19-fb500b6ac877");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "0798b8ad-b943-498b-a481-00d5182c0663");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "698124bd-185e-45ec-94cf-90ca1cc3e967");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "7d6e60d7-5435-4010-ad77-e1e355898bfd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "e2cd7a88-0874-480e-8f56-688f3146ea92");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "33c5ac15-22ad-44db-925e-ba47b23434ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "a1ef359e-26cc-4e72-9f0e-1db7968217bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "ba50332b-d72c-49a2-9605-3303e893f5ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "80306ff2-dcd2-4428-bced-c4dcc0f5600c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "c72008da-4435-43ce-b0cb-80008bd0b4a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "c40821f6-512c-4b11-baff-4ca45d220a2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "10ffa5d0-a248-4547-8941-a71de45d69e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "5c98c181-52a1-478f-91ca-a7ce23a428b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "ea6c7640-9ea0-44b8-8d1c-e182b9ae64ad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "eac2fe2c-26c2-46c1-a710-d3ea285892c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "64579fe9-852a-41a7-b293-6a8d7b3ce5d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "254e8181-e581-4045-98b5-bd62387c7c7d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "f436737b-bc46-4e2f-bf65-ed7f1adeaaad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "1d6b4bfd-c464-46d3-a1d7-aa5fb61b175a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "4b47c182-b672-4785-bb17-5987f1fc6101");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "5d33fd53-ead6-4803-95f0-86ab1f6fd401");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "a152478b-41a6-4124-a6dc-7508dd7f0c0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "e4a75475-4557-4e66-8895-fb0d0294a652");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "0aab8682-c8bb-4f72-ac4a-1355473d8798");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "12671a5a-b4c2-41b6-83b2-13ecd25790cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "7722322d-525e-4956-bfe5-ddc2bd62a5cc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "950c02b0-f7e8-4613-8a1e-ead5a7d24152");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "c59f96c3-1345-4efd-801a-2ea79d22b398");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "56539d72-12b4-48cc-a92a-c84c13094cd8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "63c40024-1f70-454b-8a9f-94713263de30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "02c8f069-c684-480c-9d3e-5662ba2bf9fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "b2c24117-ecfb-4d8a-b271-6d43ee5cc9c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "e3f4988e-9d60-4765-ab0d-1e26955fdbd5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "ae0406ca-84ec-4e4b-8631-1e662f4c53a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "881bed41-4321-46a6-a260-a52ef5fd8d66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "88d38f6b-a443-43c3-a4c1-1948eb976e59");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "c00f1ced-d9c3-408b-ac23-ffab0d54fdc2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "0bf28a91-0c7f-4d9a-9b55-6aca5b227078");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "a1e3fe3f-2631-4597-9e75-6f59a1212635");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "63b976c4-a5b9-45c0-92c9-69aac9fb57a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "1fd8d4b7-3fab-4ef3-9480-c227432f68bf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "641dcd10-2416-4633-be4b-2e591387e237");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "faba1588-67f7-4e60-925b-3ea95d9bcfe3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "2641d1db-f157-4db8-b83d-13b758ee4f1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "24b7288f-1ef6-4e75-b09f-e1eb89ed95e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "29e38d27-24d8-4044-a036-727bc6272800");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "bf977ed2-3bfe-43c5-a6f9-9022279cdeaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "918afff3-fc6b-4c88-a83e-c042bd87bbff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "575f87d8-8f55-4fbe-b6c9-1f53836ef160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "a1b29bf1-c67d-4d9d-a63d-da9cd900b79f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "d0d82e35-6cbd-4b2f-802a-e60155752c8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "8bfe3b96-c15e-40de-8e3f-de860761ffd1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "28d9d412-7b62-46df-ae7b-1c68e45c4485");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "465c480f-0b7b-46e0-a252-c5f9ee47862e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "5c0d8a13-5be5-4f12-931a-0015e3f60487");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "23ed6ee8-c3aa-4eeb-be66-b307b2ecde19");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "5a820a1b-035c-4a45-a2cf-ebd279494405");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "38c9045a-e710-463c-b44a-5130ad079d52");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "506a91b0-008e-4e55-bd3f-d6f8289b3742");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "1e4b1673-a155-4326-b0ee-4c4515ebdc5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "7fea9bb8-f5d4-40e7-bf66-b0459a3f903d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "07da5dae-e5fb-41a5-8e5c-164bea1eea10");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "b831648b-7f34-49a9-8d3b-2aa00c6e95e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "3028f127-05d6-45c1-ab10-034c7f46bf2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "7042e06c-fabe-485e-ab43-1da09573b465");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "c684e4c0-502d-4df6-81e7-4db820f1e3e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "47507cb4-9473-4634-8b9b-c91c3674bba3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "999f11f5-8945-42f7-8a50-1fecd397d30d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "a1893a84-cec2-4b1c-b251-ec9b5263f58a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "ac47af1c-5ca1-4d4b-b1ec-dab0b99160c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "463efbb4-47fe-486a-9aa3-7e82528473a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "42dbbb2a-449b-4615-adc0-0f5956fef13c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "273acac3-e0f9-4560-9ff7-97be253bc19e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "9272d34f-9c51-4e3b-b6bf-0889bfc3176a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "627bf1a1-4400-4d93-b929-82a607709992");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "71aebfa5-5fdf-464f-8c9a-4177f77f6117");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "b492ed46-b0c5-4cf1-a417-3618ccb29e7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "d0debd07-482f-4eb5-8151-98609f321b19");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "f1177c4d-86cf-4230-828e-7c38b61acf39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "435cc117-a69e-470c-addf-5a5d045dca5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "27385038-9863-47de-a3d3-e286cc4fe01d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "4561991e-28cb-47d8-8e7b-2ec744721730");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "f90da3b0-f4d5-4b8c-a37d-0f56db19c019");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "553e1c3f-93bc-4931-81b4-fb10c1e865ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "3d9cce6f-961f-418f-b109-10f16f0f7139");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "2efbc162-b1f5-4d58-8573-f3bbd3d5fdc7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "4866f0ec-4280-423b-a350-d41ccddc2a7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "d7a525ac-07c9-4df7-acda-12f771b9b68f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "57d2bccd-da7d-4914-993f-ea5c007cf130");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "1ec0d86f-94ac-4d62-b6ba-c57e37ff8a84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "bb8a2f03-b31b-4c1b-b647-a1832b5bff38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "0298a25b-5468-4452-a135-1cc25b50152f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "c8649001-e454-4447-b6bb-b2136503e62f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "9a9010b5-9fc9-47f9-a232-798a96b3fa5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "adc5661f-fd59-43fc-b135-1c3420ea0160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "9d53dfa7-a03c-494b-a6d4-9ec9ce5077dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "5f75c0ac-2105-4534-be67-7bf2fc5ebf2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "a133dea0-f9f6-477b-ac3a-62720252ec3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "9d12d8b5-744f-4485-afd8-49286b1a93c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "0aba9cda-00b9-4c25-bed2-f4e94dd5213d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "499d19fd-191f-4c49-8edf-a309622d39ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "9f38bb84-3051-4f9e-8e7f-d8521f34ab55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "400d46ea-f92e-49b0-8c6b-03373973d9e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "c7332c39-1cde-466a-8b35-1f9818b0854d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "4ee44e27-476b-453a-9096-d9ac31d53cca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "5a34d574-0af8-4dc8-9d4f-e33dcbb20a6a");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "f30beca1-011f-4725-b5b5-94d538ac5b52");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "5454639f-0c4e-4002-82c4-5c4a16dcf06a");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "2ccb4d60-3b75-48c8-a163-8a1c68ab25c5");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "9c18a59d-535b-4f78-a4fb-c34132aa4903");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "302bc23f-3ddc-4dbd-a916-3007f77a653f");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "c805f3d8-b041-4438-9ca3-b30e16bf4c58");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "32cc83c4-69ed-4840-a86a-67e1efc0b01c");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "9aa9c22b-5942-4d5e-aa53-199886a0e0b8");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "8e2ff804-0599-4ace-b008-8ebea021004d");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "70168249-116a-46d9-8962-28fed46216ee");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "7146f6b2-ac3d-4c8e-85cd-6a073db7a727");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "5c8c79b1-1b65-47a2-841e-cf5bd31436df");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "7b5edaa8-caf3-43ae-8d3f-6dac2c151e00");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "02c881b4-61c5-49c7-aae6-da07bc312a92");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "fdf1f974-2d70-4594-b266-4a74ce6a83dd");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "fe834ae1-78f9-4af0-89ef-a435250b9278");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "96234100-f1df-43a5-bb8f-8b98ef55a487");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "22e38259-1944-4005-b96d-a37fb747f6eb");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "15fe2a6d-ae18-4a1b-b4e0-0f9d4bd66d80");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "53e92edc-98cd-43e6-848f-0fbe71fbb911");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "2ba5d100-12a8-4d39-a9b4-3f42e4377d85");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "0e27390d-bdbc-4620-b1e1-f8ab127589a5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "12f45b76-5975-4e29-bc1f-4f3231027c32");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "dc708a0b-3c7e-4268-8dad-b6d1a4d5f3fe");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "1322ce67-0fe7-43f1-8a58-a783ea41814f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "ac6eb8cc-b04f-4dc9-9a2c-1674e882da30");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "fc024d94-0ee4-4e1d-85f0-fe997406c630");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "60b106e3-3d80-41e2-ac1c-0458eea39279");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "fed5f5e3-a0db-4a09-bdc6-2323ee04dd9f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "7fbf1147-38a4-453b-87f7-a80883f0a3b9");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "404f09fa-66d0-49ef-9eca-4511b35c9b1b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "93f0461c-991b-4642-a02e-067698c498c2");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "97223221-292f-463f-81ab-f5b542fecd6b");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "2baa5237-2c65-4d4f-bc42-b9494db738d5");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "52b0ca1d-4d29-4d63-a835-8d5ac70d639a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "eae51225-d884-456e-af85-173074cde687");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "c232f13d-89dd-43e9-9b7d-a335bc641477");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "d6b1f06e-a378-4268-8e4d-fba594325b1c");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "7b2cf966-309d-4e0d-89fc-7895a35b120e");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "f20ddcad-c9c1-49fa-9b12-b7e1f1ceb7c8");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "05d8be55-8f66-4dd9-9f5b-2ad85a77fd04");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "f499330d-d105-4ca4-a925-93851ae9df48");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "3357ed93-751e-4bd8-8638-71c30ac1aace");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "647eb00f-b435-4a0f-a50a-0e587fbe24e9");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "c885ef59-956c-4efa-84f0-da5695fd1217");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "e8a86ccc-73b9-4a85-a4e9-7d52e96587bf");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "191493d4-188e-4d05-b403-74676674c918");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "67f0e0d1-5913-44b1-9f86-d7a00d63b305");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "84549a66-8a20-4edf-a434-ab213aa634e5");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "aadb16e8-e530-4de7-af8c-94b7d24dfcd0");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "344a56a5-7e6d-4c2f-a71e-7ab2751a4725");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "82887d2e-703f-4330-90b7-d2886591a6e9");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "7272eb11-525a-4985-bd0e-f3090c5b1fd6");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "3ee40793-823f-4395-9622-19eb56bd43b3");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "004d83ac-f14b-4273-a9a4-0bbfe74e0749");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "64f87460-62ee-4f2c-af78-72f7d10f7590");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "6967030b-e5e5-4734-a7b5-3ec16cfc4abb");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "45f067b2-4743-43d5-8c9e-e32d6e410d63");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "10e84e14-7e10-4514-9926-4afd7ec414be");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "a393962a-28d9-4574-b2fe-554be27f10ff");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "415c4599-de3a-4090-bc54-08c1f8ac9c71");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "a3e6c521-40c6-40e1-bb32-419fe54e16ac");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "d65c3e52-5eda-498e-8f43-3ea1e3ff1cb1");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "f8a33baa-980a-4e97-b96b-f1d67f0d5cd6");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "e9f700b5-531c-4d9c-a46c-05f7058e219e");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "559da539-a0c4-4772-b79c-bd87583020ea");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "70b2ed86-b55a-4b1f-8e21-fd8d62826f3d");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "36c607aa-22df-479c-829b-5bbbc9f3bd43");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "60434d50-e7af-4638-aea8-82d81ec18c7b");

            migrationBuilder.CreateIndex(
                name: "IX_UserLink_CandidateCompanyId",
                table: "UserLink",
                column: "CandidateCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetwork_CandidateCompanyId",
                table: "SocialNetwork",
                column: "CandidateCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CandidateCompanyId",
                table: "Phone",
                column: "CandidateCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_CandidateCompanyId",
                table: "Email",
                column: "CandidateCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CandidateId",
                table: "CandidateCompany",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_CurrencyId",
                table: "CandidateCompany",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_GenderId",
                table: "CandidateCompany",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateCompany_MaritalStatusId",
                table: "CandidateCompany",
                column: "MaritalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Email_CandidateCompany_CandidateCompanyId",
                table: "Email",
                column: "CandidateCompanyId",
                principalTable: "CandidateCompany",
                principalColumn: "CandidateCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_CandidateCompany_CandidateCompanyId",
                table: "Phone",
                column: "CandidateCompanyId",
                principalTable: "CandidateCompany",
                principalColumn: "CandidateCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_CandidateCompany_CandidateCompanyId",
                table: "SocialNetwork",
                column: "CandidateCompanyId",
                principalTable: "CandidateCompany",
                principalColumn: "CandidateCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLink_CandidateCompany_CandidateCompanyId",
                table: "UserLink",
                column: "CandidateCompanyId",
                principalTable: "CandidateCompany",
                principalColumn: "CandidateCompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Email_CandidateCompany_CandidateCompanyId",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_CandidateCompany_CandidateCompanyId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_CandidateCompany_CandidateCompanyId",
                table: "SocialNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLink_CandidateCompany_CandidateCompanyId",
                table: "UserLink");

            migrationBuilder.DropTable(
                name: "CandidateCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserLink_CandidateCompanyId",
                table: "UserLink");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetwork_CandidateCompanyId",
                table: "SocialNetwork");

            migrationBuilder.DropIndex(
                name: "IX_Phone_CandidateCompanyId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_Email_CandidateCompanyId",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "CandidateCompanyId",
                table: "UserLink");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Study");

            migrationBuilder.DropColumn(
                name: "CandidateCompanyId",
                table: "SocialNetwork");

            migrationBuilder.DropColumn(
                name: "CandidateCompanyId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "PersonalReference");

            migrationBuilder.DropColumn(
                name: "CandidateCompanyId",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "DocumentCheck");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Candidate_TechnicalAbility");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Candidate_SoftSkill");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Candidate_LifePreference");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Candidate_LanguageOther");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Candidate_Language");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "Company_Candidate_Wellness",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyUserId",
                table: "Company_Candidate_TimeAvailability",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "3bbc5c37-3037-4b1c-9504-10cd0bb16b25");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "77c47e03-4e80-4288-b871-56d523bdaf9e");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 1,
                column: "DataOriginGuid",
                value: "12f81994-0420-4cd3-8454-3b8588d78645");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 2,
                column: "DataOriginGuid",
                value: "6d831b51-8a3b-41a9-8f62-7fb4e26a871a");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 3,
                column: "DataOriginGuid",
                value: "d444a47d-f9dc-420a-bf2d-94ff870c6e75");

            migrationBuilder.UpdateData(
                table: "DataOrigin",
                keyColumn: "DataOriginId",
                keyValue: 4,
                column: "DataOriginGuid",
                value: "9cbb89ab-7107-4a97-9d32-012cb36f1356");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "63929693-0a99-4e4e-8b31-eea2baf39b68");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "70cbba2d-8f35-46d4-a870-1c7b27ea8330");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "cc8c4448-581e-40e1-bf30-88af4653f273");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "5dd090c9-5da0-4453-b9bc-e31e5ea438c7");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "7edfe126-8676-4ae5-b032-300f8dec840f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "10d80abb-db01-49e5-a4a8-c98d978a4a36");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "388d45c9-ee5e-4eea-92f9-6264751cbbf2");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "39efa151-557b-49aa-8525-4b69f9f7c772");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "a5a1df68-9622-4fbb-a40d-29e52f65ee5f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "472a0f5a-70d2-404f-a644-b6b86bfa4843");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "be6cb410-a1ab-4579-a2c6-2d5e1cceb8e6");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "a8015e47-163e-4875-a56a-58ea2f0f27e4");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "f3edc6d1-2ebb-47ef-b1c1-6a682a1b31fe");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "416ad3de-5199-41c5-81c9-a1cd7bfc7b15");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "35568c36-0ef9-45a5-9dbb-0d9858f53540");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "a40133de-917c-481c-91dd-03f301bf25d8");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "065fefee-14cd-4060-a798-d2c9606f7a1d");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "018d6b61-b854-4f3b-bdc1-07036c5949c7");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "9a4f0d69-a015-4a93-b5f7-22b0c3abc808");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "cfc820be-b737-4ad7-b8bd-1c8b40dfc5fd");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "f5260ce5-9266-4935-b841-5e2ee8b7dd11");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "d097b48f-1760-4bbc-8914-ae38380d8dca");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "e70d705f-7b61-4469-8186-5eedbf2d9a83");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "6bf590a9-7b5f-4531-8415-3ec953671ac9");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "e7d873d7-261c-4aea-b944-686fbad8ce35");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "a1762f1b-a3bf-48c6-a943-97ccf066794c");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "e3b3260e-a4d7-4785-930b-f9f332b5db9f");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "2e0c0cab-bd19-4d77-836d-080c508ce8a9");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "90e3984d-8aed-4c11-ac47-1c4072eceeff");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "9c8cde63-fe19-4da7-9573-755355e5e33e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "fdd42494-9922-4994-adf5-025e4e682951");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "16daf6a1-cc4e-4307-9ea5-d6adfdf51c74");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "b708dae5-407c-4399-8e4d-a1392332649a");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "f30bd3a8-528e-4010-b14f-45acb044c372");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "e3eaece2-8d1a-4540-aab9-b2cf1676cf58");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "f91995e4-5d1d-4901-95d4-891e46dbe7bd");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "be152f81-a4b7-4d8b-8dfc-e3e045d7112c");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "2c830f26-c322-47a1-b916-1949eadb77ea");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "192900d5-e9af-4292-8014-3b837d7a4342");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "dc0f0157-fd36-4567-98ac-10dbd2993bfe");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "5e28f594-a5ab-483f-9568-2ff019512f32");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "9debe651-1a10-4336-afb7-8d8ba0de181b");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "00c47921-5f35-4be1-a33a-7e71b5c19f92");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "2ef3df8d-c4bb-4838-9d54-a1b6071559ab");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "b6feefd6-ca7d-4f4f-8625-36eb344ba586");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "93c0b46a-a096-4ac0-b2b1-2472a6492bd5");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "40159b40-5d97-4c0e-b067-a0ab3d22de5a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "addc3186-3c72-46dc-a15a-9446bfb95340");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "fdda267d-72ca-4549-9e91-e1d412ca8022");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "78e214c4-b233-4a10-bdc3-f9ae1e073530");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "fad18fc7-ed90-4fe4-9392-d7ccb796a13f");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "ef7d131e-35d0-4137-83b9-adcdd7231aa1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "f29457c8-db49-447b-ad96-86bc8a55c50b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "0ba62d7a-7c29-445b-89e9-c3ba7f902da0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "068a093c-3ee4-42cf-8726-59dd267305c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "47ba0d61-36f4-4d13-865f-0bfff6ea8951");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "849d18ec-c651-45fa-a28b-3f36c9685d25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "3e5a50b2-790b-4dff-99ac-185fb26b21b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "ccfe9cfb-cd79-4286-99c5-854e7d597a77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "6a78cf48-fb5b-453c-aafa-d8aa3bdca4f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "9ba73624-5938-4506-8a40-eee9fb50d4ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "ebfca0a7-af11-400f-a8e5-73e31c0bada7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "240b3eb4-e369-4573-809b-b0fff25ffbac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "13c55007-ec9a-4b31-8ee3-70e008007a6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "06ecf18b-8a51-4cef-9f19-fe0515449943");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "1857706b-7785-4252-a97d-dc72bbd425a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "49723d7e-2c9b-474e-bea6-6a1537c33517");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "aae4d5a8-7eb7-43ac-babb-17f884be1203");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "609ada37-c2bd-4db9-ba52-c54162573d09");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "965db701-93ca-4774-b607-803f4dbb596c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "46e6a5ea-0f8a-467a-bb3d-3c55b44fa118");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "cca35cb5-c5a0-438a-bd11-8c860675a2c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "f16cf498-0a0c-463f-8de2-5f18faa97f8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "8561c2a1-ce4b-4c28-8a56-990507fe38e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "2d848e45-9552-407f-ba75-164020244754");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "086d0433-3b26-4fcc-89d1-bbf785721141");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "b3037d82-23af-4919-a0bd-bdd59af62dd7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "86427e69-e96a-403b-aef4-465142d91b8d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "1f86fa11-d179-4f15-a70d-17a926bccf23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "237c53df-f570-47ca-b8a2-6103ed19e211");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "6146668a-5629-43da-9924-04b7633c93d8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "7ac506ad-ac1a-40aa-ad9b-a09c7eaef72c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "697d62f3-985e-49f8-b790-7c701477fd1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "55fdde82-eacc-4e65-a74a-8beb85ff4160");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "f41648ca-5a3c-45d4-a961-9d3902c60694");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "1111cbec-ffbe-41bd-8d93-52ab14663247");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "ecc4b61c-084b-465e-9982-22b410bdd30d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "2282a821-59da-4a04-816c-aee5ecef3cc5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "4a62cd7c-9f4c-4a7a-810d-df3bf467fe7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "c2b47e6f-046b-4cb6-9c3f-1c7e23509485");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "89afe18b-a9da-4bdc-8b86-a4fd8aa38588");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "db560a6f-d29d-492f-ae8a-1c2a6ebd1a35");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "69c60624-c40b-4d05-a1c5-504b9a0e6b5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "36f03ee4-b2e6-4cf2-804a-093437a062a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "12f4c826-6435-437b-aec4-b2f88e1b8e77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "cf0edfb7-6700-418e-8364-516a95bb87af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "f618fa93-6560-4e48-9a93-d037c93b4bfc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "aeba18fc-e342-4540-8671-9c8f70ae25d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "1f341348-4b16-44e7-a59a-82b60fbd4448");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "e195579b-6837-4b40-9cf8-1ebbf3d12ba4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "22ff7010-a3e6-4d29-afe6-b8b4a0fbcace");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "223313bf-42ec-445e-8cab-0157c47e6975");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "d43e87dd-aff0-4044-9ded-8d6a0f7f37b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "87e4492d-a4a1-4cb0-acf0-567a588facaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "01f054e2-47f4-49e5-b132-cafa5344bcd2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "fb7c4356-290b-4db7-a1de-04073680b859");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "7683dceb-285b-4dbc-ab3a-55a4e363f43b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "01498f97-f7a4-4f13-a487-a16c50bd12f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "c1c5d4ef-8730-48c1-82cf-cdfe22fc7ab5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "037b9de1-c8e1-493f-90bc-39878f80b12b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "173bbdae-092c-4cff-8558-033b571dbdc1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "e620eddf-263f-40fe-9434-2eb57f58050e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "fce02a83-992d-49eb-8bc1-5873296edd24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "ba0ef28f-fbda-4dc8-9c7a-2b21405ab1c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "ffe5c8b9-576a-40f1-a196-cc8f567694a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "756e33da-dbaa-4e7b-bfe1-25ad1686a82f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "5fc4e933-ef94-4488-9b64-3de430fc1dfa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "ae8e0039-ec44-45de-b034-99fe687582ea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "3873979a-4131-4116-a0ad-62c2c16e4c1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "1b581e49-6a2a-41e6-81c8-c6fb4b56ea65");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "b6d828cc-f610-441e-acce-1945a35cd489");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "e285999b-a2aa-485a-ae65-61d3623c73b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "2cec5584-9975-4fab-b06a-8fa1fabd6081");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "65396bb3-8af3-40f4-87f2-c445c1b56001");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "416e9929-16af-492a-a007-e54ee3254852");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "ef81e7c9-98e1-4dfb-b4fa-cd9ce766725d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "87585fc2-e2ec-4d3d-abb8-3e016dcdb159");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "d6af2a82-d8c9-4c92-a3b2-a80a235577d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "8d94a097-1bc4-45f6-b3a2-b67a08014907");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "3df11395-6197-4d34-9f1e-a5a4b7e5f8b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "feb24efc-3c9d-4331-a39d-e64e5262b084");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "a83110ff-ac76-4a39-b993-0187cce9a71f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "8035e916-d13c-42c3-a80b-918df6a193b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "62a2d91e-923b-47c3-a18b-d06b0431b952");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "a5929408-8318-4970-b459-2702f4b81ad1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "a21efd24-4fdc-4f20-bda8-35dbb32f060e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "96b494bb-e3ae-425a-9af6-d380df56cb3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "854b391c-8471-4b50-ad1d-c1d8a69346b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "1c4b8564-1417-478c-9f6f-62df7cad1c6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "47febc0b-67c8-43e9-8d9e-436da533ca8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "c1b17208-a336-4d42-a2ac-d34304d830fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "90b03da1-c18d-4e5e-a9e7-3ebbd58ee683");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "c2b00965-a66d-4f57-8f39-7210f0b3e534");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "63a3f724-b2ab-4b82-a791-6235752fca14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "a60d0aea-7ddc-4340-9d61-64a64ab0ab9e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "f02ff867-121b-47b6-814d-9691dd405878");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "c01aedbd-7047-4c3f-baa7-c617a61f519d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "8ec3f693-99ad-4879-9b57-fd297c13b407");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "54c8cc95-8149-4e6b-a503-d377821f36e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "5554bd35-f6b3-41cf-8b21-42e371ee983f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "ae6c66aa-4613-4a17-a04f-9c6b94dde626");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "0972dc67-fe4a-403c-bb48-92ad1e36f4ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "9f6f3176-de8c-4576-a522-58ed973d547f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "b7914701-2f48-4686-b4fc-a7da8841547b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "e8e334c3-cd05-4b51-9f44-af1e8c08f641");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "6d494a2f-b95d-4982-9615-423a6ee0e06e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "479013c6-69c4-4b0f-8d62-759a9ef979db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "098e740e-7fc7-4695-957a-9c4c77c6f8c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "bece150e-51b1-4c3f-adb2-e151ab5f422a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "ea5ffb9f-019c-478b-bd0d-d2d1802cca88");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "e9859142-d099-49e2-81da-7f2419891d28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "9047a567-771b-4f77-a143-f2ede69cf1a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "c6c3c742-5f8f-4539-84a9-4d49407bf19c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "a62e6751-1d0a-411b-95c3-f0b8b944e7b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "782fde5c-f43b-45e7-93ed-e1d188143a85");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "388f90e9-2aad-430a-af92-c189e53d413f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "047820a0-1585-45a9-a19d-f7b2f36c038f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "dee44255-91fe-4116-b376-2f83a9c7a38a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "72204550-196c-4893-975f-f5c4cff00159");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "83cf3e31-3475-45f0-9dec-e93cbc0b283c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "39101eec-0db9-40f8-94c0-e84e1239c4e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "470c9cc9-3166-4bec-91ab-42c53bb37129");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "c874b03f-002f-4d8e-b26e-0af9f9e088c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "a77462e0-52a2-4e9e-9f3e-6a4e743b315b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "8b81afcb-bd6d-44b7-b6c4-e7a48926635d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "9564b968-abef-4502-8505-f0bbc90ae2c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "c74d1549-2a71-4992-b600-19d204ef0541");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "759b7e25-6263-4a49-b3e5-2f3b72952437");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "54f57347-51d1-4215-a88a-b2324d1a0b9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "b8a3c050-7b5e-4470-a52c-8dab3c4110f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "298223d7-0c1a-4d8f-8db9-d0718acf7bc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "a5eff36d-9bb4-4829-8e76-86acd80c4383");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "f6021c7f-fb44-4e56-b962-70a9f3d8e86d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "b6ffa514-55ae-411a-8216-0d8dc63f5fcd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "4c0fcf1f-bf1d-4095-99f6-21b6efb6cd3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "2810ddf2-e599-468e-9ac7-fbb0fd441ab2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "d1756ef3-77d9-4003-90c4-dfc1b47fa6d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "61bc93f9-ebc1-462f-b8b0-e60135a2ef9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "12b55453-fe03-4507-91fa-665b79c34451");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "4ba02180-2627-4d59-89f9-5387c33868fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "1b3f6b33-ebd0-4ccf-b7d4-79bfcb324c3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "a1294eb0-39d1-41b9-ba3d-61300bcd971b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "596a05a3-2910-4706-8b1a-214e22f61ed5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "6eb363b8-6610-4bb2-af0f-8134c3e374b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "de4e1298-872c-4256-bbc0-96329f1bb424");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "94ebdd53-89b1-429c-8202-8afbb51d0a46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "c06a68be-c70f-47db-b327-8050d4cf996e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "1239b87a-fac2-42c2-b917-6b16c9cd9d0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "e570195a-c76c-47fc-a715-5315c58613df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "dd190f07-4922-4691-b6fc-8869cfcd23c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "4846372c-788a-4945-bba2-ae8872a351fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "2d5b4133-8fa2-4517-b5c6-96ac07c0d76b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "0b20b403-73ff-4988-804e-7c8b10b4ee80");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "eaa2de3f-83f0-416e-a9d2-c040158357af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "54004386-3926-4731-887a-1edc24c996de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "9c24a2dd-3e4a-48d5-8da5-38db059d2305");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "9b7f0bd6-20cd-440c-8abb-4d509740f530");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "96d33812-e043-4c80-9154-c0e9672397ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "5502cc21-e0f5-42e9-baaf-3fa7eebe528d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "20a10b27-e0c3-4915-8b9d-156aff5e0804");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "ee1dab36-b98f-4391-ad09-f096ce8b348e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "17e59476-7d7d-41fe-91e1-3f76e5337e57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "edabc91a-ffe8-4d85-ab67-e253197e9fdc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "1d87cfdf-07aa-4df0-8027-b39890fed14c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "c60eee83-de75-42ed-ace1-85e48d4ecdb5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "d25b00ac-6dc3-4ae7-a2fd-93196aff7b89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "08f9277f-3920-47bd-96e7-def777a29e62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "7bf69005-7f6a-4f80-9d3a-4ffa5f8e0b5b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "67b22936-0d5e-4cc4-9263-fdfcb1152f4d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "3e731878-f9de-4663-8666-c87d6d52de56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "3c83cecd-b5b2-48d2-a067-d6e11aeb9f84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "b50a8f85-9f73-494a-8e6f-7967dda6a4e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "890a6931-e125-4013-be74-4ea132253a25");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "08eaab48-a212-412b-a0f0-b0ecd0562a48");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "e64ec111-abc4-4142-ac00-0f8e8c5cac55");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "6c7e37b0-fb31-4f68-a5ce-f822cde5d210");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "44b8cead-c2c9-4cc8-af31-18bea0fdf06d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "a12c9f0a-d046-4fe0-a809-75e153fb1710");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "20b50d74-0be6-47b6-8fe9-0ec46db5f00c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "54ec5b23-80dc-45d8-98a1-e56369a8ee22");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "e05f494c-1e8c-4414-aa3c-79e920f64e1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "86b940e2-4b78-4164-bb21-60064c8e2d98");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "9ee8745f-a936-47f3-995f-51e8757a0a17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "4f45123f-f4a6-471f-a37a-2ebd8e8e1889");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "8c470c55-e015-46a5-a10e-bd5b5cc11d7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "bc51bf95-9395-459a-8768-d909fe2c73e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "246002ae-43c3-4575-a9fa-2a9b470e8657");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "414ca84b-9e16-4b93-a7d2-6d4a1c73b392");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "d8913e5b-2ea5-44dc-9b14-af61f45d96d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "9a8fbb16-b510-4a0b-8c79-ebb2496254dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "e6497c83-37b3-4810-b3b2-2e09c9965e93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "a00e6061-0278-4922-b596-f89a3505e6c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "4f26b331-9404-4e91-be51-f10eba11e77b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "0b8fa154-4e3b-4efa-8440-581d728d7c12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "b84793d5-7c93-4b60-b1ae-76a906b1ffbf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "1762a2ba-1646-45a9-a949-be3b1240e182");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "01d29af1-22e3-4132-8273-4358bbf62720");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "b08cb34c-2e29-4085-b21b-984ecb7161da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "df4028d3-0650-4ad3-b8d3-f91f35a41b75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "03020909-aebb-486a-b54c-7d6f14d84f93");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "46785260-1fe7-4bd1-b124-1802c2d452f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "976d505e-a058-4760-b850-48e50a5af649");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "4c4b1e76-6f4b-439e-8897-1ed49d2896fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "6b93c554-d423-4e18-98e8-5b71575f90b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "7848553e-2c0c-4524-84e4-6e5c6aed4825");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "48f3b531-6c96-4166-9fa8-95008260c6cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "f7955562-ada5-45b5-8ce7-b4b9fd12cdb4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "8d49cdda-c15d-421b-acaf-3670292d7752");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "25f30b07-f45f-44e1-92dc-251acb81bd68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "92d9f45b-2b03-4ec9-ae85-4bb91125229d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "ba4a475b-1b87-4d36-a71a-278e54560195");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "df17648b-88a2-46f5-a518-da5dd74c0d08");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "afb4581e-5a93-44b5-b6a4-772848f758e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "eabf3eaf-604d-450b-8493-813f95a21274");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "d6acee0c-2614-4ff5-ac22-58e911d26666");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "92f41d4a-f1ff-4323-930a-8be6c35bafcc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "02a1b342-9881-4bec-a77e-31f7e932a7db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "70096147-6a2f-49a1-9f3b-51c4367f90ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "b7e86d32-079a-41aa-a827-ec2b0145499f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "21811e20-054d-4a64-b6e9-0a5cc02ae746");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "af612355-e931-42e4-b5b9-e478404ae2b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "4461d49c-260c-4e57-bf6f-73015de9ba61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "c361504d-14b5-488a-b2e9-81a372aaace2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "349efde6-88aa-4075-8633-e933641901d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "3620befc-432b-4f69-882b-b8f958011359");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "06316500-7efb-4e8d-ba8a-641f5442a96c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "7974e331-e4f9-4c4b-909c-ba34d1e4128d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "e331c9d4-efdd-4365-969c-744b6c1939be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "07fb2681-6a0d-459a-8acf-1dcd55aaa9f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "48a7dc8f-15fd-44f1-a909-5e0250f72608");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "b62ea442-1b05-4fe9-bfad-6be6bba246d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "bd46f3ba-dc2d-4945-917a-f79c36654638");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "1d753adb-baa4-4d57-9f1a-ec581eb44e1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "a9c623dc-b776-4565-b0ed-e9ec5378c391");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "5f32bd5d-6997-4e31-be82-78241a2c80e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "e8cbe6ce-780b-463b-8e00-d4f65d7c9990");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "6d296a69-a268-4ea7-9fca-eeb560976067");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "aaaeb142-fc1f-45b9-81bc-860dede08477");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "2d364e63-0e1a-4eaf-9f45-e5bdd562053d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "b684fd3f-b7b8-4e96-b42b-47c8954c1469");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "aa5a07e1-4902-4db1-ae8c-9b5156e61538");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "55ab5730-fb12-436c-819c-86705c023892");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "eee4d854-9415-4468-a6e8-651e62ddb655");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "20f44f04-7758-494a-a9a2-2334a83f2673");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "6c325151-fefc-4ac4-b4b7-218d27a1a8c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "827ae5f9-d483-46b0-919c-64734161e606");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "4bf914a2-2957-43f3-9513-30e731938e89");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "464dd53a-914b-47e1-9665-1a161fe346c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "e8cd280e-1767-4af0-9c0f-47382dd4dd44");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "7ddf6acc-08ae-4848-927e-c6d7831bb15a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "618e385d-2d44-4b5f-a070-e05101e583e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "d6f73bc4-dcce-444d-8404-72cc4a58d399");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "eceac7a3-611e-4ecc-a9bb-2d6d5ca1b0d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "89300ac7-0858-47d4-9a14-62ee24a9111e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "e1b9cae5-4611-497f-8fe8-cc5741629b23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "802b0b26-1259-46b0-b46d-a5076c766926");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "ea6f90a8-0d78-4570-8259-9d40502b3e21");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "7a5cb245-beb0-413d-aed2-c2e21a9280ab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "01cc0e05-633c-4162-a054-6879d3130711");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "0622d14f-a16f-4597-9ab6-add87ca163ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "86004e1a-938d-44ee-8f0f-113f5b2342d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "08ccf980-8cad-4437-8155-3035ad7158ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "89e42954-d9d5-4cff-8862-2b9ddd3989ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "80f1feb5-f95b-40db-95d4-707f7f9c5978");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "c81c1d01-eccd-40e0-b395-f817a30fc689");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "1d4fcadf-6b01-4bc2-9bd5-8516a4c1d4f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "4d212a24-8de0-4879-8c43-8ead1fb1c416");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "c1117629-e9ce-4dc1-ae55-cbbd96a448ff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "f9a61d23-44f7-4944-adc9-461e49cc55b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "a61fc3e9-eccf-4882-8f6f-c120590cd3ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "2f8f1f29-8cb3-4c53-9ebc-1f20cea274b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "27af4938-b2ad-453c-afe4-5c530715610e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "892cf353-4f48-4b5f-80b1-e2876028e995");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "3ab00e12-6621-4c49-ade1-5749769db69a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "e0f61c3b-ca4e-40c1-90f8-4250ba93b12e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "eea4d746-32b7-4f96-a637-99590e4cf935");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "96d4a44d-d09a-4e38-9d07-95a183cf6450");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "58872805-aa86-498c-8613-f5b13c62169f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "129a53a4-fe32-4d51-b213-9a669b342312");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "08004250-52a5-4844-a0cc-71c6c251118b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "bb920d32-e3fb-4e51-8e81-865106daf3e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "18a76daf-699c-4252-bdd5-9184b04c0932");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "2dfe509c-bef4-4964-afd7-d987549a8ce6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "8018d554-66bc-4694-8b38-cec9cefb9eec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "635928bf-6816-4c33-ad75-3afbd89a3351");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "7a51b3f6-b23a-4b8f-bf6d-90c567ac83c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "00ee481e-36a1-4abd-8e17-8ca5de8039e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "3c5e1e78-b975-4dcb-bc33-abbf11f6ed54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "813d925f-b994-40e4-b429-005b2b5761d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "d2e28af1-472f-44d3-89cc-c8378d17f3c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "69cbdcb0-284a-423f-bca6-11d1e0a68fbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "1a515ef0-8bb4-43ea-80ae-8346126c79a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "4de18f82-acbe-41f3-b427-43752466bd07");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "d5b5ff4e-5592-4ec0-90a7-251a913b6476");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "9ad36a26-260e-47b6-b312-03a075a98d45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "5f4b8b94-9f96-461f-9cba-23df3f0ef88e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "00da6c10-4f4b-4db8-84c0-52e33af367b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "5281f2f4-e70b-4e60-a4af-3ee4a404a30f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "9f0b8b5e-1978-43a0-80ab-83b7ec91efad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "26b14b6d-191e-4dbe-a194-5e7a9b102439");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "58370229-2863-4839-a8c9-190506e8b6b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "3aa6660a-f184-4bec-ab93-544942da2c34");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "1b006c3c-8eb1-48e0-b6a4-125955f24803");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "2ae06e70-8e88-4d3a-9e9e-9345a2abd3d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "1ca2fb92-84db-4ddf-acc4-9f463cbad065");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "8b49d370-d3ea-4b41-b4f1-c35a46642a79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "12ba2eb3-80e3-49c1-bbda-b56fd23f33e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "56a64e81-5774-4122-92f5-2558cc55118d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "6db4e588-30ec-4f8c-b86c-783145f27181");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "b47d0ecf-cd13-49bd-bd7b-39492814df24");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "ba039c7e-f097-49b9-a77a-5dc741d55140");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "94b9a89b-ec93-4474-94ce-9fc07819138f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "cb64b959-2142-44c4-beb4-7760a83c4ee8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "f52a8dba-f8cf-4fe7-9ab1-0be020bf169c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "0466fec8-f594-48ef-a948-28d6b54490d2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "5f26167d-0ce3-4c4a-8c93-a131f9db9342");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "abfa6a4c-2aa9-487d-a4ff-006fec7b95d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "bc86defc-4bc2-4e74-870d-0777420c1698");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "6a157b46-0c77-4e0a-ba11-59ca8d1d3571");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "c93b4684-9e29-4e91-84d0-a29355f3b7fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "cb144654-9646-415f-905b-01108b7eab47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "82c8c205-e40c-47ba-91bb-d3db1a83c6ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "db56342f-fa13-4b97-90f6-3c6edabcf55e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "d4506a5c-6a5d-4171-96ae-f0ea096a3979");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "6e697046-ecd9-4f01-ab82-d355f15e80b4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "43f2401e-9ec5-4c82-a1b5-a5e1c0216654");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "c79746f0-8ac3-4633-b6b2-212c04fed236");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "c4c059cb-52d9-4bbf-b024-cda99407953b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "62a59468-54bb-4aa4-b318-4ad5af9dcda6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "4fa99717-6143-48ba-a0c0-275e056fca14");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "23324fe6-a637-4808-bfa2-cfe3738c6a0f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "3e08c3d0-30a6-4213-bed0-f187298c718f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "9e8b20c6-4cd8-487a-88bc-3ec2d87f7a6c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "f6a88972-7ef2-4cff-a5ae-7fcc49ab8a63");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "c43d99be-1982-40e0-87c8-3b4fab9d5541");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "60455988-3d7e-453c-b4bf-d2d62c7344cb");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "d2dcfba7-d1cb-4546-8821-b67e391461de");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "5d98f760-1ca5-4627-b598-b6c60a3e3b2a");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "55105bc5-b97f-4d29-86cb-e6863fd84cab");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "40548f55-474e-4d37-9c1e-3c6317cb68e4");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "9931a65c-0e14-4ac8-96d3-f82725a87a56");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "52f497b2-ceb8-4729-beb0-e1cbf9954b14");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "987261c4-322d-48b4-a17b-dd910041706a");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 1,
                column: "SoftSkillGuid",
                value: "ef1dca4f-8e78-48ce-8f09-c4d94baf6586");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 2,
                column: "SoftSkillGuid",
                value: "cee3c1b4-d4ff-4ea6-b54c-15c86e221987");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 3,
                column: "SoftSkillGuid",
                value: "a98a6d5a-ec4c-4fec-8ca0-53499f52ae1e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 4,
                column: "SoftSkillGuid",
                value: "9d575ff7-770f-4470-8fa2-2fb8cb72af9e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 5,
                column: "SoftSkillGuid",
                value: "cd6e9462-d82b-4ee7-9568-2d950c0c2075");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 6,
                column: "SoftSkillGuid",
                value: "3c99ea16-7bb5-405c-a374-69bd5ace2462");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 7,
                column: "SoftSkillGuid",
                value: "0ce76917-e12b-47b6-ba56-91f1654591e2");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 8,
                column: "SoftSkillGuid",
                value: "ca504093-e9f5-4205-8f2b-7c4048f29f31");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 9,
                column: "SoftSkillGuid",
                value: "f2220d5c-a200-43d1-a4b1-cb698d40b576");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 10,
                column: "SoftSkillGuid",
                value: "a17c013b-0494-4fca-b9a2-d29156bd0818");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 11,
                column: "SoftSkillGuid",
                value: "1171df8e-7b0f-4df2-a1cb-28173faf8d80");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 12,
                column: "SoftSkillGuid",
                value: "283ad267-183b-48b6-94cb-2abe5c443a53");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 13,
                column: "SoftSkillGuid",
                value: "e104cecb-52c8-48ea-a5f8-6fb04f2c60eb");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 14,
                column: "SoftSkillGuid",
                value: "f46372d8-a5bc-457d-87a3-cb453fb4f845");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 15,
                column: "SoftSkillGuid",
                value: "f4af900c-927c-4d7e-8d73-ddcbb86aac50");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 16,
                column: "SoftSkillGuid",
                value: "59313304-8ee5-4b0f-8d95-98e1eb58f9f8");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 17,
                column: "SoftSkillGuid",
                value: "d5beacf4-5a5f-4a7f-ad4d-a740166f0a29");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 18,
                column: "SoftSkillGuid",
                value: "61d186e7-2592-4ece-b34a-d98eabaf48fb");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 19,
                column: "SoftSkillGuid",
                value: "c195dc7d-e380-4a3e-9b4f-7bda171fc53f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 20,
                column: "SoftSkillGuid",
                value: "ed44cd68-482c-4136-b9b8-d8927c11b059");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 21,
                column: "SoftSkillGuid",
                value: "e2f611ce-dcb1-455e-b379-bbabc7b8086e");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 22,
                column: "SoftSkillGuid",
                value: "dd523d85-5f2a-419c-975a-bef15237a63f");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 23,
                column: "SoftSkillGuid",
                value: "353a51e7-2807-4a09-8b78-18e8e82242a1");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 24,
                column: "SoftSkillGuid",
                value: "9bc4c6d0-49ba-40de-bbff-86890ec5dc55");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 25,
                column: "SoftSkillGuid",
                value: "f8ef5f13-429d-4fed-ac00-36628bf68a78");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 26,
                column: "SoftSkillGuid",
                value: "ec5b320a-0679-4076-91cd-7ca43af89d38");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 27,
                column: "SoftSkillGuid",
                value: "a0519508-7295-4efe-9ee1-455fc4b542dd");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 28,
                column: "SoftSkillGuid",
                value: "54951eba-eb28-4154-8461-3714f10ad314");

            migrationBuilder.UpdateData(
                table: "SoftSkill",
                keyColumn: "SoftSkillId",
                keyValue: 29,
                column: "SoftSkillGuid",
                value: "6f380e69-9c9f-4600-8a37-1df06c04b742");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "253e4996-e196-4df2-940e-a232df4fbf9e");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "a6d343ce-0e13-4875-b8fa-6ba64b7908bc");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "0594ee7c-70b4-43ce-ae56-d46cdbc474c5");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "e436cdfc-798e-4cfe-8630-bfaf8169eda2");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "15bb5f63-cdf0-44b7-b490-a399d30ad772");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "1b4b1f2e-8143-4bef-8df2-2f4d314ea985");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "28f287f2-4296-4143-8652-b846417adbb9");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "48ccb815-2459-4b6f-856d-33b4a3df1979");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "a92c4b43-5978-45a7-8959-671f73b2f1c1");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "7d03eebd-0112-4e17-bbb4-3d424931e45a");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "ff270d32-1653-4e33-bdbd-119a1367c459");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "9aa90798-a1fd-4de0-83ee-2bc6b1262035");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "6b34f859-0ae1-47d1-8239-f1ce30546d15");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "13620d97-c903-4340-aca6-4b3ba96de22a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "e429592b-a37e-49d5-8904-e8aed7a71355");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "e0a24792-1527-44eb-9579-cfabe254186c");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "de5e1015-71e0-4827-a9ba-d42b17329708");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "b0196b6b-2161-4494-98e4-d148a0c2a5e0");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "8338df95-b3ca-4a15-857e-c6bad01b60e1");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "cb163b86-eca9-4624-872e-00061f301e0e");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "bc9729f8-98dd-40d8-83ac-88bc9ae262a1");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "15879253-55a5-4645-b1e5-d4f28cc40ea3");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "f2a79b77-770a-49f2-8931-a94e111c3b2e");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "b82bbf53-1773-4c40-9176-fd372168fb29");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "5a00b4ad-a5dd-4f07-9033-64bcfc9a4d05");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "1e4e1ad6-74ca-4bd1-aa0d-0e0a66b166eb");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "f9bd1970-0be3-49c8-b0a5-75c0c1f88645");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "3686754e-63d8-4bc5-875d-9ca34f86b2e9");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "c6a80d79-cf60-4958-a101-dd4c43a902f9");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "cbed707c-c9f0-4f81-b512-33675e22381d");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "518691f0-1fab-42e8-b9b3-79a555a941cd");
        }
    }
}
