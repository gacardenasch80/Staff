using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesMS.Migrations
{
    public partial class NewCurrenciesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "32167956-99fb-4932-88bf-88d78d4fb9d2");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "71e587c9-266e-4f9c-930b-dbaa9d45faeb");

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 1,
                columns: new[] { "Name", "NameEnglish", "ShortName", "ShortNameEnglish" },
                values: new object[] { "EE.UU. Dólar", "U.S Dollar", "USD (EE.UU. Dólar)", "USD (U.S Dollar)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 2,
                columns: new[] { "Name", "ShortName", "ShortNameEnglish" },
                values: new object[] { "Peso colombiano", "COP (Peso colombiano)", "COP (Colombian Peso)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 3,
                columns: new[] { "ShortName", "ShortNameEnglish" },
                values: new object[] { "EUR (Euro)", "EUR (Euro)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 4,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Dólar australiano", "AUD (Dólar australiano)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 5,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Real brasileño", "BRL (Real brasileño)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 6,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Peso chileno", "CLP (Peso chileno)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 7,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Peso mexicano", "MXN (Peso mexicano)" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "CurrencyId", "Name", "NameEnglish", "ShortName", "ShortNameEnglish" },
                values: new object[,]
                {
                    { 117, "Nepal Rupia", "Nepal Rupee", "NPR  (Nepal Rupia)", "NPR (Nepal Rupee)" },
                    { 118, "Nueva Zelanda Dólar", "New Zealand Dollar", "NZD  (Nueva Zelanda Dólar)", "NZD (New Zealand Dollar)" },
                    { 119, "Omán Rial", "Oman Rial", "OMR  (Omán Rial)", "OMR (Oman Rial)" },
                    { 120, "Panamá Balboa", "Panama Balboa", "PAB  (Panamá Balboa)", "PAB (Panama Balboa)" },
                    { 121, "Perú Nuevo Sol", "Peru Nuevo Sol", "PEN  (Perú Nuevo Sol)", "PEN (Peru Nuevo Sol)" },
                    { 122, "Papúa Nueva Guinea Kina", "Papua New Guinea Kina", "PGK  (Papúa Nueva Guinea Kina)", "PGK (Papua New Guinea Kina)" },
                    { 123, "Peso filipino", "Philippines Peso", "PHP  (Peso filipino)", "PHP (Philippines Peso)" },
                    { 128, "Catar Rial", "Qatar Rial", "QAR  (Catar Rial)", "QAR (Qatar Rial)" },
                    { 125, "Polonia Zloty", "Poland Zloty", "PLN  (Polonia Zloty)", "PLN (Poland Zloty)" },
                    { 126, "Portugal Escudo", "Portugal Escudo", "PTE (EURO)(Portugal Escudo)", "PTE (EURO)(Portugal Escudo)" },
                    { 127, "Paraguay Guaraní", "Paraguay Guarani", "PYG  (Paraguay Guaraní)", "PYG (Paraguay Guarani)" },
                    { 116, "Noruega Corona", "Norwegian Krone", "NOK  (Noruega Corona)", "NOK (Norwegian Krone)" },
                    { 129, "Rumania Nuevo Lei", "Romania New Lei", "RON  (Rumania Nuevo Lei)", "RON (Romania New Lei)" },
                    { 130, "Serbia Dinar", "Serbia Dinar", "RSD  (Serbia Dinar)", "RSD (Serbia Dinar)" },
                    { 131, "Rusia Rublo", "Russian Rouble", "RUB  (Rusia Rublo)", "RUB (Russian Rouble)" },
                    { 124, "Pakistán Rupia", "Pakistan Rupee", "PKR  (Pakistán Rupia)", "PKR (Pakistan Rupee)" },
                    { 115, "Países bajos Florín", "Netherlands Florin", "NLG (EURO)(Países bajos Florín)", "NLG (EURO)(Netherlands Florin)" },
                    { 110, "Malasia Ringgit", "Malaysia Ringgit", "MYR  (Malasia Ringgit)", "MYR (Malaysia Ringgit)" },
                    { 113, "Nigeria Naira", "Nigeria Naira", "NGN  (Nigeria Naira)", "NGN (Nigeria Naira)" },
                    { 97, "Libia Dinar", "Libyan Dinar", "LYD  (Libia Dinar)", "LYD (Libyan Dinar)" },
                    { 98, "Marruecos Dirham", "Moroccan Dirham", "MAD  (Marruecos Dirham)", "MAD (Moroccan Dirham)" },
                    { 99, "Moldavia Leu", "Moldova Leu", "MDL  (Moldavia Leu)", "MDL (Moldova Leu)" },
                    { 100, "Madagascar Ariary", "Madagascar Ariary", "MGA  (Madagascar Ariary)", "MGA (Madagascar Ariary)" },
                    { 101, "Macedonia Denar", "Macedonia Denar", "MKD  (Macedonia Denar)", "MKD (Macedonia Denar)" },
                    { 102, "Myanmar Kyat", "Myanmar Kyat", "MMK  (Myanmar Kyat)", "MMK (Myanmar Kyat)" },
                    { 103, "Mongolia Tugrik", "Mongolia Tugrik", "MNT  (Mongolia Tugrik)", "MNT (Mongolia Tugrik)" },
                    { 114, "Nicaragua Córdoba", "Nicaragua Cordoba", "NIO (Nicaragua Córdoba)", "NIO (Nicaragua Cordoba)" },
                    { 104, "Macao Pataca", "Macao Pataca", "MOP  (Macao Pataca)", "MOP (Macao Pataca)" },
                    { 106, "Malta Lira", "Malta Lira", "MTL (EURO)(Malta Lira)", "MTL (EURO)(Malta Lira)" },
                    { 107, "Mauricio Rupia", "Mauritius Rupee", "MUR  (Mauricio Rupia)", "MUR (Mauritius Rupee)" },
                    { 108, "Maldivas Rufiyaa", "Maldives Rufiyaa", "MVR  (Maldivas Rufiyaa)", "MVR (Maldives Rufiyaa)" },
                    { 109, "Malawi Kwacha", "Malawi Kwacha", "MWK  (Malawi Kwacha)", "MWK (Malawi Kwacha)" },
                    { 132, "Ruanda Franco", "Rwanda Franc", "RWF  (Ruanda Franco)", "RWF (Rwanda Franc)" },
                    { 111, "Mozambique Nuevo Metical", "Mozambique New Metical", "MZN  (Mozambique Nuevo Metical)", "MZN (Mozambique New Metical)" },
                    { 112, "Namibia Dólar", "Namibia Dollar", "NAD  (Namibia Dólar)", "NAD (Namibia Dollar)" },
                    { 105, "Mauritania Ouguiya", "Mauritania Ouguiya", "MRO  (Mauritania Ouguiya)", "MRO (Mauritania Ouguiya)" },
                    { 133, "Arabia Saudita Rial", "Saudi Arabian Rial", "SAR  (Arabia Saudita Rial)", "SAR (Saudi Arabian Rial)" },
                    { 138, "Singapur Dólar", "Singapore Dollar", "SGD (Singapur Dólar)", "SGD (Singapore Dollar)" },
                    { 135, "Seychelles Rupia", "Seychelles Rupee", "SCR  (Seychelles Rupia)", "SCR (Seychelles Rupee)" },
                    { 156, "Tanzania Chelín", "Tanzania Shilling", "TZS  (Tanzania Chelín)", "TZS (Tanzania Shilling)" },
                    { 157, "Ucrania Hryvnia", "Ukraine Hryvnia", "UAH  (Ucrania Hryvnia)", "UAH (Ukraine Hryvnia)" },
                    { 158, "Uganda Chelín", "Uganda Shilling", "UGX  (Uganda Chelín)", "UGX (Uganda Shilling)" },
                    { 159, "Peso uruguayo", "Uruguayan Peso", "UYU  (Peso uruguayo)", "UYU (Uruguayan Peso)" },
                    { 160, "Venezuela Bolívar", "Venezuela Bolivar", "VEB  (Venezuela Bolívar)", "VEB (Venezuela Bolivar)" },
                    { 161, "Vietnam Dong", "Vietnam Dong", "VND  (Vietnam Dong)", "VND (Vietnam Dong)" },
                    { 162, "Vanuatu Vatu", "Vanuatu Vatu", "VUV  (Vanuatu Vatu)", "VUV (Vanuatu Vatu)" },
                    { 155, "Taiwán Dólar", "Taiwan Dollar", "TWD  (Taiwán Dólar)", "TWD (Taiwan Dollar)" },
                    { 163, "Samoa Tala", "Samoa Tala", "WST  (Samoa Tala)", "WST (Samoa Tala)" },
                    { 165, "Caribe oriental Dólar", "Eastern Caribbean Dollar", "XCD  (Caribe oriental Dólar)", "XCD (Eastern Caribbean Dollar)" },
                    { 166, "CFA Franco BCEAO", "CFA Franc BCEAO", "XOF  (CFA Franco BCEAO)", "XOF (CFA Franc BCEAO)" },
                    { 167, "CFP Franco", "CFA Franc Franc CFP", "XPF  (CFP Franco)", "XPF (CFA Franc Franc CFP)" },
                    { 168, "Yemen Rial", "Yemen Rial", "YER  (Yemen Rial)", "YER (Yemen Rial)" },
                    { 169, "Sudáfrica Rand", "South African Rand", "ZAR  (Sudáfrica Rand)", "ZAR (South African Rand)" },
                    { 170, "Zambia Kwacha", "Zambia Kwacha", "ZMK  (Zambia Kwacha)", "ZMK (Zambia Kwacha)" },
                    { 171, "Zimbabue Dólar", "Zimbabwe Dollar", "ZWD  (Zimbabue Dólar)", "ZWD (Zimbabwe Dollar)" },
                    { 164, "CFA Franco BEAC", "CFA Franc BEAC", "XAF  (CFA Franco BEAC)", "XAF (CFA Franc BEAC)" },
                    { 134, "Islas Salomón Dólar", "Solomon Islands Dollar", "SBD  (Islas Salomón Dólar)", "SBD (Solomon Islands Dollar)" },
                    { 154, "Trinidad y Tobago Dólar", "Trinidad & Tobago Dollar", "TTD  (Trinidad y Tobago Dólar)", "TTD (Trinidad & Tobago Dollar)" },
                    { 152, "Tonga Pa'anga", "Tonga Pa'anga", "TOP  (Tonga Pa'anga)", "TOP (Tonga Pa'anga)" },
                    { 136, "Sudán Libra", "Sudan Pound", "SDG  (Sudán Libra)", "SDG (Sudan Pound)" },
                    { 137, "Suecia Corona", "Swedish Krona", "SEK  (Suecia Corona)", "SEK (Swedish Krona)" },
                    { 96, "Letonia Lats", "Latvia Lats", "LVL (EURO)(Letonia Lats)", "LVL (EURO)(Latvia Lats)" },
                    { 139, "Santa Helena Libra", "Saint Helena Pound", "SHP  (Santa Helena Libra)", "SHP (Saint Helena Pound)" },
                    { 140, "Eslovenia Tolar", "Slovenia Tolar", "SIT (EURO)(Eslovenia Tolar)", "SIT (EURO)(Slovenia Tolar)" },
                    { 141, "Eslovaquia Koruna", "Slovakia Koruna", "SKK (EURO)(Eslovaquia Koruna)", "SKK (EURO)(Slovakia Koruna)" },
                    { 142, "Sierra Leona Leone", "Sierra Leone Leone", "SLL  (Sierra Leona Leone)", "SLL (Sierra Leone Leone)" },
                    { 153, "Turquía Nueva Lira", "Turkey New Lira", "TRY  (Turquía Nueva Lira)", "TRY (Turkey New Lira)" },
                    { 143, "Somalía Chelín", "Somali Shilling", "SOS  (Somalía Chelín)", "SOS (Somali Shilling)" },
                    { 145, "Santo Tomé y Príncipe Dobra", "Sao Tome & Principe Dobra", "STD  (Santo Tomé y Príncipe Dobra)", "STD (Sao Tome & Principe Dobra)" },
                    { 146, "El Salvador Colón", "El Salvador Colon", "SVC   (El Salvador Colón)", "SVC (El Salvador Colon)" },
                    { 147, "Siria Libra", "Syria Pound", "SYP (Siria Libra)", "SYP (Syria Pound)" },
                    { 148, "Suazilandia Lilangeni", "Swaziland Lilangeni", "SZL  (Suazilandia Lilangeni)", "SZL (Swaziland Lilangeni)" },
                    { 149, "Tailandia Baht", "Thailand Baht", "THB  (Tailandia Baht)", "THB (Thailand Baht)" },
                    { 150, "Turkmenistán Manat", "Turkmenistan Manat", "TMM  (Turkmenistán Manat)", "TMM (Turkmenistan Manat)" },
                    { 151, "Túnez Dinar", "Tunisia Dinar", "TND  (Túnez Dinar)", "TND (Tunisia Dinar)" },
                    { 144, "Suriname Dólar", "Suriname Dollar", "SRD  (Suriname Dólar)", "SRD (Suriname Dollar)" },
                    { 95, "Luxemburgo Franco", "Luxembourg Franc", "LUF (EURO)(Luxemburgo Franco)", "LUF (EURO)(Luxembourg Franc)" },
                    { 8, "Emiratos Árabes Unidos Dirham", "United Arab Emirates Dirham", "AED  (Emiratos Árabes Unidos Dirham)", "AED (United Arab Emirates Dirham)" },
                    { 93, "Lesotho Loti", "Lesotho Loti", "LSL  (Lesotho Loti)", "LSL (Lesotho Loti)" },
                    { 31, "Bielorrusia Rublo", "Belarusian Rouble", "BYR  (Bielorrusia Rublo)", "BYR (Belarusian Rouble)" },
                    { 32, "Belice Dólar", "Belize Dollar", "BZD  (Belice Dólar)", "BZD (Belize Dollar)" },
                    { 33, "Canadá Dólar", "Canada Dollar", "CAD  (Canadá Dólar)", "CAD (Canada Dollar)" },
                    { 34, "Congo Franco", "Congo Franc", "CDF  (Congo Franco)", "CDF (Congo Franc)" },
                    { 35, "Franco suizo", "Swiss Franc", "CHF  (Franco suizo)", "CHF (Swiss Franc)" },
                    { 36, "China Yuan/Renminbi", "China Yuan/Renminbi", "CNY  (China Yuan/Renminbi)", "CNY (China Yuan/Renminbi)" },
                    { 37, "Costa Rica Colón", "Costa Rican Colon", "CRC  (Costa Rica Colón)", "CRC (Costa Rican Colon)" },
                    { 38, "Cuba Peso convertible", "Cuban Convertible Peso", "CUC  (Cuba Peso convertible)", "CUC (Cuban Convertible Peso)" },
                    { 30, "Botsuana Pula", "Botswana Pula", "BWP  (Botsuana Pula)", "BWP (Botswana Pula)" },
                    { 39, "Peso cubano", "Cuban Peso", "CUP  (Peso cubano)", "CUP (Cuban Peso)" },
                    { 41, "(EURO) Chipre Libra", "Cyprus Pound", "CYP ((EURO) Chipre Libra)", "CYP (EURO)(Cyprus Pound)" },
                    { 42, "República Checa Corona", "Czech Republic Koruna", "CZK (República Checa Corona)", "CZK (Czech Republic Koruna)" },
                    { 43, "Yibuti Franco", "Djibouti Franc", "DJF  (Yibuti Franco)", "DJF (Djibouti Franc)" },
                    { 44, "Dinamarca Corona", "Denmark Krone", "DKK  (Dinamarca Corona)", "DKK (Denmark Krone)" },
                    { 45, "Alemania Marco", "Germany Mark", "DMK (EURO)(Alemania Marco)", "DMK (EURO)(Germany Mark)" },
                    { 46, "República Dominicana Peso", "Dominican Republic Peso", "DOP (República Dominicana Peso)", "DOP (Dominican Republic Peso)" },
                    { 47, "Algeria Dinar", "Algerian Dinar", "DZD  (Algeria Dinar)", "DZD (Algerian Dinar)" },
                    { 48, "Estonia Corona", "Estonia Kroon", "EEK (EURO)(Estonia Corona)", "EEK (EURO)(Estonia Kroon)" },
                    { 40, "Cabo Verde Escudo", "Cape Verde Escudo", "CVE  (Cabo Verde Escudo)", "CVE (Cape Verde Escudo)" },
                    { 49, "Egipto Libra", "Egypt Pound", "EGP  (Egipto Libra)", "EGP (Egypt Pound)" },
                    { 29, "Bután Ngultrum", "Bhutanese Ngultrum", "BTN  (Bután Ngultrum)", "BTN (Bhutanese Ngultrum)" },
                    { 27, "Bolivia Boliviano", "Bolivian Boliviano", "BOB  (Bolivia Boliviano)", "BOB (Bolivian Boliviano)" },
                    { 16, "Aruba Florín", "Aruban Florin", "AWG  (Aruba Florín)", "AWG (Aruban Florin)" },
                    { 15, "Austria Chelín", "Austria Shilling", "ATS (EURO)(Austria Chelín)", "ATS (EURO)(Austria Shilling)" },
                    { 14, "Peso argentino", "Argentine Peso", "ARS  (Peso argentino)", "ARS (Argentine Peso)" },
                    { 13, "Angola Kwanza", "Angola Kwanza", "AOA  (Angola Kwanza)", "AOA (Angola Kwanza)" },
                    { 12, "Antillas Holandesas Florín", "Netherlands Antilles Florin", "ANG  (Antillas Holandesas Florín)", "ANG (Netherlands Antilles Florin)" },
                    { 11, "Armenia Dram", "Armenia Dram", "AMD  (Armenia Dram)", "AMD (Armenia Dram)" },
                    { 10, "Albania Lek", "Albania Lek", "ALL  (Albania Lek)", "ALL (Albania Lek)" },
                    { 9, "Afganistán Afgani", "Afghanistan Afghani", "AFN  (Afganistán Afgani)", "AFN (Afghanistan Afghani)" },
                    { 28, "Bahamas Dólar", "Bahamas Dollar", "BSD  (Bahamas Dólar)", "BSD (Bahamas Dollar)" },
                    { 17, "Azerbaiyán Nuevo Manat", "Azerbaijan New Manat", "AZN  (Azerbaiyán Nuevo Manat)", "AZN (Azerbaijan New Manat)" },
                    { 19, "Barbados Dólar", "Barbados Dollar", "BBD  (Barbados Dólar)", "BBD (Barbados Dollar)" },
                    { 20, "Bangladesh Taka", "Bangladesh Taka", "BDT  (Bangladesh Taka)", "BDT (Bangladesh Taka)" },
                    { 21, "Bélgica Franco", "Belgium Franc", "BEF (EURO)(Bélgica Franco)", "BEF (EURO)(Belgium Franc)" },
                    { 22, "Bulgaria Lev", "Bulgaria Lev", "BGN  (Bulgaria Lev)", "BGN (Bulgaria Lev)" },
                    { 23, "Bahréin Dinar", "Bahrain Dinar", "BHD  (Bahréin Dinar)", "BHD (Bahrain Dinar)" },
                    { 24, "Burundi Franco", "Burundi Franc", "BIF  (Burundi Franco)", "BIF (Burundi Franc)" },
                    { 25, "Bermuda Dólar", "Bermuda Dollar", "BMD  (Bermuda Dólar)", "BMD (Bermuda Dollar)" },
                    { 26, "Brunéi Dólar", "Brunei Dollar", "BND  (Brunéi Dólar)", "BND (Brunei Dollar)" },
                    { 18, "Bosnia Marco", "Bosnia Marka", "BAM  (Bosnia Marco)", "BAM (Bosnia Marka)" },
                    { 50, "España Peseta", "Spain Peseta", "ESP (EURO)(España Peseta)", "ESP (EURO)(Spain Peseta)" },
                    { 94, "Lituania Litas", "Lithuania Litas", "LTL (EURO)(Lituania Litas)", "LTL (EURO)(Lithuania Litas)" },
                    { 52, "Finlandia Marco", "Finland Mark", "FIM (EURO)(Finlandia Marco)", "FIM (EURO)(Finland Mark)" },
                    { 75, "Islandia Corona", "Iceland Krona", "ISK  (Islandia Corona)", "ISK (Iceland Krona)" },
                    { 76, "Italia Lira", "Italy Lira", "ITL (EURO)(Italia Lira)", "ITL (EURO)(Italy Lira)" },
                    { 77, "Jamaica Dólar", "Jamaica Dollar", "JMD  (Jamaica Dólar)", "JMD (Jamaica Dollar)" },
                    { 78, "Jordania Dinar", "Jordan Dinar", "JOD  (Jordania Dinar)", "JOD (Jordan Dinar)" },
                    { 79, "Japón Yen", "Japan Yen", "JPY  (Japón Yen)", "JPY (Japan Yen)" },
                    { 80, "Kenia Chelín", "Kenya Shilling", "KES  (Kenia Chelín)", "KES (Kenya Shilling)" },
                    { 81, "Kirguistán Som", "Kyrgyzstan Som", "KGS  (Kirguistán Som)", "KGS (Kyrgyzstan Som)" },
                    { 82, "Camboya Riel", "Cambodian Riel", "KHR  (Camboya Riel)", "KHR (Cambodian Riel)" },
                    { 74, "Irán Rial", "Iranian Rial", "IRR  (Irán Rial)", "IRR (Iranian Rial)" },
                    { 83, "Comoras Franco", "Comoros Franc", "KMF  (Comoras Franco)", "KMF (Comoros Franc)" },
                    { 85, "Corea del Sur Won", "South Korea Won", "KRW  (Corea del Sur Won)", "KRW (South Korea Won)" },
                    { 86, "Kuwait Dinar", "Kuwait Dinar", "KWD  (Kuwait Dinar)", "KWD (Kuwait Dinar)" },
                    { 87, "Islas Caimán Dólar", "Cayman Islands Dollar", "KYD  (Islas Caimán Dólar)", "KYD (Cayman Islands Dollar)" },
                    { 88, "Kazajistán Tenge", "Kazakhstan Tenge", "KZT  (Kazajistán Tenge)", "KZT (Kazakhstan Tenge)" },
                    { 89, "Laos Kip", "Lao Kip", "LAK  (Laos Kip)", "LAK (Lao Kip)" },
                    { 90, "Líbano Libra", "Lebanon Pound", "LBP  (Líbano Libra)", "LBP (Lebanon Pound)" },
                    { 91, "Sri Lanka Rupia", "Sri Lanka Rupee", "LKR  (Sri Lanka Rupia)", "LKR (Sri Lanka Rupee)" },
                    { 51, "Etiopía Birr", "Ethiopia Birr", "ETB  (Etiopía Birr)", "ETB (Ethiopia Birr)" },
                    { 84, "Corea del Norte Won", "North Korea Won", "KPW  (Corea del Norte Won)", "KPW (North Korea Won)" },
                    { 73, "Irak Dinar", "Iraqi Dinar", "IQD  (Irak Dinar)", "IQD (Iraqi Dinar)" },
                    { 92, "Liberia Dólar", "Liberia Dollar", "LRD  (Liberia Dólar)", "LRD (Liberia Dollar)" },
                    { 71, "Israel Nuevo Séquel", "Israel New Baku", "ILS  (Israel Nuevo Séquel)", "ILS (Israel New Baku)" },
                    { 53, "Fiji Dólar", "Fiji Dollar", "FJD  (Fiji Dólar)", "FJD (Fiji Dollar)" },
                    { 54, "Islas Falkland Libra", "Falkland Islands Pound", "FKP  (Islas Falkland Libra)", "FKP (Falkland Islands Pound)" },
                    { 55, "Gran Bretaña Libra esterlina", "Great Britain Pound Sterling", "GBP  (Gran Bretaña Libra esterlina)", "GBP (Great Britain Pound Sterling)" },
                    { 57, "Ghana Nuevo Cedi", "Ghana New Cedi", "GHS  (Ghana Nuevo Cedi)", "GHS (Ghana New Cedi)" },
                    { 58, "Gibraltar Libra", "Gibraltar Pound", "GIP  (Gibraltar Libra)", "GIP (Gibraltar Pound)" },
                    { 59, "Gambia Dalasi", "Gambia Dalasi", "GMD  (Gambia Dalasi)", "GMD (Gambia Dalasi)" },
                    { 60, "Guinea Franco", "Guinea Franc", "GNF  (Guinea Franco)", "GNF (Guinea Franc)" },
                    { 61, "Grecia Dracma", "Greece Drachma ", "GRD (EURO)(Grecia Dracma)", "GRD (Greece Drachma )" },
                    { 56, "Georgia Lari", "Georgia Lari", "GEL  (Georgia Lari)", "GEL (Georgia Lari)" },
                    { 63, "Guyana Dólar", "Guyana Dollar", "GYD  (Guyana Dólar)", "GYD (Guyana Dollar)" },
                    { 70, "Irlanda Libra", "Ireland Pound", "IED (EURO)(Irlanda Libra)", "IED (EURO)(Ireland Pound)" },
                    { 62, "Guatemala Quetzal", "Guatemala Quetzal", "GTQ  (Guatemala Quetzal)", "GTQ (Guatemala Quetzal)" },
                    { 69, "Indonesia Rupia", "Indonesia Rupiah", "IDR  (Indonesia Rupia)", "IDR (Indonesia Rupiah)" },
                    { 68, "Hungría Forinto", "Hungary Forint", "HUF  (Hungría Forinto)", "HUF (Hungary Forint)" },
                    { 72, "India Rupia", "India Rupee", "INR  (India Rupia)", "INR (India Rupee)" },
                    { 67, "Haití Gourde", "Haiti Gourde", "HTG  (Haití Gourde)", "HTG (Haiti Gourde)" },
                    { 66, "Croacia Kuna", "Croatia Kuna", "HRK  (Croacia Kuna)", "HRK (Croatia Kuna)" },
                    { 65, "Honduras Lempira", "Honduras Lempira", "HNL  (Honduras Lempira)", "HNL (Honduras Lempira)" },
                    { 64, "Hong Kong Dólar", "Hong Kong Dollar", "HKD (Hong Kong Dólar)", "HKD (Hong Kong Dollar)" }
                });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "ed6fa80a-bccf-49f6-a598-3a03100baec1");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "7c518085-6535-40a6-ba0b-f190a8e0bde8");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "261cd536-7409-4147-baf0-18282ed1cd12");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "994074f4-faa6-415d-a70f-9ae3954b4bb2");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 5,
                column: "DocumentTypeGuid",
                value: "f8e0ae51-33c4-41c4-b553-d1a6bcb1338f");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 6,
                column: "DocumentTypeGuid",
                value: "18f2e5d1-3aeb-4a8f-a7c2-0754b580dc8f");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 7,
                column: "DocumentTypeGuid",
                value: "44216df4-08c8-40df-bc90-a1fa7a987985");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 8,
                column: "DocumentTypeGuid",
                value: "00964450-5fe2-4dea-b09e-7faeddd1939a");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "b0d97950-7c67-4038-993d-da75911a962b");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "0458d18c-69e0-485e-81a1-0e2fe4368ade");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "a8185139-b53b-422d-91ff-dd3e6746ab46");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "74d18a86-031e-4f8c-b831-2e969cc6f03c");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "c1f0aec6-31e8-424c-ad34-9fc8ff42df52");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "37db5c83-38a9-4e6f-8525-ce2b7ed3b9a9");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "e563ec40-a95a-47f1-b241-41e8460b30ed");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "2f7c1ccb-cab3-4fd9-aabc-e16aacf0249f");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "6d03355e-c413-43e4-bdf2-0a627c2de724");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "4b3efdb7-38c7-4b5e-8983-5b6cc77cb554");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "2e25c54a-1d56-4868-bd90-1c4549360991");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "30914a5c-9ccb-4bb6-9598-39b599bd9e57");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "6dc1b107-5d4a-4d90-9d75-0470e8d624f2");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "9f8c63f8-d380-44ff-a673-e69c49174035");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "74a6c621-8079-4a12-a50b-824daac62b17");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "22739802-e46a-4b63-b20c-34328a0705f0");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "c9044d8a-251a-415b-9dc8-ed5e9eda85bf");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "4f270032-cf97-459e-bade-1335ad1dad70");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "14deb9a9-3f3b-48f4-8b82-9781cf048368");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 4,
                column: "GenderGuid",
                value: "47c27ffa-80b7-4766-a880-8f656e7ed415");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "e100e46b-2522-4e48-9df7-0d5aeacd0b3e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "d69932ea-0b3a-4361-9165-48d04f554ff2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "f7bebc92-7652-4448-a724-ffca64703475");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "0d39ab61-e223-4f34-8356-462a11e9139d");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "fb6eb155-f8d8-43cc-b10d-3e6eef4154b6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "03a4c634-4063-40cc-96fc-9ef6742a871c");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "643ecb44-a836-4b84-bb31-ea75957abe84");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "b2378161-639c-48b8-b01e-c7ec1761197e");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "5760e429-ae43-433c-802e-616a1c36b2e2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "5dd9cef2-7634-479a-80ef-967d797f4b84");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "9935a91c-0a47-42ff-b785-489874a77d94");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "936e5e97-7504-4b65-b28e-04bd2adf6b66");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "f5fc9340-a604-443e-8254-661f63ed0fa6");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "0c9f7287-37c6-4aae-8f77-85d7c226e1e1");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "14fbdb28-f3f1-435d-8b71-81a8bc12a314");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "033cb527-15fc-46f2-8f2d-e2905c6cdc16");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "335cf608-05f4-42d9-8eb3-586cf8a316ac");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "fac536ff-42ff-474b-8009-b39c1b8cbd94");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "de4ffd77-7909-4fba-901b-37d714b7679c");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "d0bbfb3c-3353-4055-ac54-1df747c90235");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "a6c2d02c-ac2b-4f4d-a966-cfb0abe739e1");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "68e09e54-4290-4028-b3c9-97ac1d840f0c");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "81b65cd9-bbd1-4403-b5e9-317548ee7678");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "a24d8690-a5ed-4e03-99fe-7085bd888879");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "cb4f6530-de1a-4ed9-95a6-4e18b21c79ee");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "8945c20c-c3f4-4b2f-ab25-285090358a02");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "9b436dfb-e4ef-4504-b784-606cac95c39b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "3052cf7c-9d33-4d73-b1c2-7a2f99504323");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "db544c14-ad04-4efb-bc2e-97b3986dd384");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "217c37cd-bd3c-459d-aedf-8f27e7a69279");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "79ca80e5-b77d-4363-a663-62e2349ac915");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "722d84ef-fb2e-4fc7-adae-ada79f693846");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "72803d78-b469-4f20-98ed-789599862e1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "a5332520-c963-42cf-bc28-7f2d1ee3d32a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "d4ffcb4c-f9bf-4576-8981-26e88f71efe4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "853ff88d-9b67-448f-bb9e-4fe40ed9b330");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "964947f3-56a0-4cd0-92f9-0b79b4741c90");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "2f004578-5b6c-4915-b960-e62b8adab96a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "b6fe8e06-404c-4994-b1b1-5f28acf8ca8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "721aa75f-8bd9-413e-b060-f1f0b7cf6e59");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "5bc64c81-0489-4d35-a2a4-6c606c924be8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "9588d89c-51a0-44e7-8a75-6670d4fef312");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "15711da5-5c9b-483f-b5ef-4b65ad0a2086");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "cf472071-7997-417d-a7ac-eb97cee199aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "e8d6b74c-ae67-4a40-8a31-26758dcc7a47");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "88c33e2b-c89f-45cd-99e1-a1e6f04ea732");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "ca4c6ec4-60a9-4251-b173-203f2c655db2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "cf950c2e-368a-4b4d-a395-b38773d2dbda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "c315c381-f8ac-4bf1-b3a9-38f1bb047894");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "2924ae78-3cbf-4243-bcca-2d8069db84c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "3b9d38c1-3372-4157-818c-c759b08f5fad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "b25493af-835d-4652-8640-5fe360cba3fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "e7fec4ca-e313-4b62-9549-be519e5c6246");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "ce50efa5-2af6-4e44-bf7e-4287774d7cd1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "b94960fc-ed92-464e-a14e-87d5bddc589a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "cd1ef0d0-082c-4864-b79d-5413f84e6c09");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "a3858ead-bbf9-413b-8b74-ec8fcc58778d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "66763b5b-aae6-4005-8866-30c8750606b1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "cf6ef6fe-6ec5-4a53-beb9-f7545a32c798");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "f97af316-0dd9-458e-97ea-61192e631a8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "065fad78-aecf-40fc-b30e-2e4f9c7d5772");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "bf3c0148-ba4c-4919-b51d-07c4c4e6ab26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "706e7b36-0d2c-4a7e-b0bf-828696d4f422");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "63d6d32b-8c57-4545-9f68-8c59174c4317");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "fad2be77-50e3-4eaf-aa4a-1e5545483398");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "3a50f4a6-8d67-4dc8-94cc-a78a0ff37c2f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "2cfa2ff4-3834-4adb-98a4-d8829e85d297");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "865d3cb1-eac8-43bc-875e-b7068e0c0cec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "6323dab2-32b3-4963-bb1c-704018e51e1b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "0b7f2f16-1890-4488-89d1-6ce5f380d9c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "651c7472-0f35-4057-be9e-44fda00a0292");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "8eba4407-4846-41df-8131-c7eee3632343");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "bfb17b6a-3928-4d95-a124-7df86a8c5c95");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "37e01b0f-6f39-4abe-b3bd-2b08f5c6d932");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "ad53b29d-0930-438e-9105-f24f5577339b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "85f129bd-d5d0-430b-9317-95ba2aaf8d6f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "3b2cbd01-5e2c-4348-bfae-8c8af43b8f5c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "618c3123-01b7-428a-ba26-68817df21ca9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "6600cd23-5887-4a5a-8764-84bdf3e428a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "73a739b1-95fa-482a-b718-0cb3b3e9fbf6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "f5697d09-096f-4063-99b9-bc977122936f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "01213ee2-2817-4aa4-8bd0-ffea02872e20");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "60182e58-4530-48d9-8c84-489d736bb467");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "10dbb680-1d92-416b-a01d-f7ee633e45f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "6f9e52d9-6a43-4331-af10-15eed6e3c220");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "c13bf5f4-2adb-4aa8-955e-97d71d72cd8a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "c5969333-8dd6-4a7f-b714-82a6bc034daf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "05f8491d-00de-4a06-8928-62af59858e0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "f228bf0f-a2e6-4361-bf16-ee67afd9164b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "4d8ac747-8f01-4afd-967f-2733a8d8be2b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "92fa79c3-f284-4336-a247-98e4b15c6bcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "87d15ed4-a808-40ef-ab4d-9e0220e14a1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "fd6d52a6-fd7a-486e-894b-55f5cdf661bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "bf5bd5d2-beee-43c6-8cd6-0225401252ca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "9f41564b-58e4-45d0-8578-3ef6655ce01f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "a8942856-c43b-4e6c-be40-f4810a40284e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "b069254d-fd31-459e-ad18-3653523f5b60");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "8fec0581-7aac-46be-a894-0609e703c34b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "433cf346-9b2e-4427-b7e5-206e2ae04a33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "7dab4d94-4fd3-4401-b1a2-5a3368340226");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "26d432f7-da8e-4146-80ea-e6ee207b72cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "6818de45-2829-4c90-9a86-60c23e044fd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "14c9a7b6-05b0-4167-b083-db60d78dee18");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "953f00b8-136d-47cc-a965-37ad60b47f1d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "81882c0b-8168-401d-b5d5-b6544c46ddcd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "280a6d0d-f182-417d-9b44-068450b04c26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "81f22eba-e446-4411-be20-2bc441613b02");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "cacf355e-fa67-43cd-b030-58fec0906259");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "597da5ad-c4ba-4a3f-8ba2-051dbf0041a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "ab42862f-71da-4bae-8518-a9faf92371b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "6cb4007d-eb35-4f31-85d1-d332334039a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "dbd0d82a-5653-4137-9776-1fdeb42854eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "42813298-042f-4cd5-a0ee-713dd5b9708f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "c98bf608-1fae-4a22-88ef-9b4af48982ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "1890e1c5-2692-4f39-9bdc-199a8b5a1803");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "131e6da6-225d-489d-8129-57a043d28d62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "b9ebf276-9867-4307-a265-bcba8b74c647");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "8bddf9be-a14b-4750-a309-a9a8d6c44a9e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "cf0e4992-b3cc-4220-a5e0-e1792c412fdc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "c39b9c78-d6be-47e2-ab34-4fe0c2dc13b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "59e08592-9424-4707-84ad-451859660a8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "71288b1e-7dd2-484d-a2a2-1545a17dc81c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "57d4f2c2-fd39-4246-9b52-ddbec2707ea0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "eebd8b5c-f031-4db7-a64e-cbfef9b40539");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "1e441a42-8398-408d-ae51-965d0b27fd61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "fe69effb-332d-4229-9479-2baf86d5aa2f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "ce1c0357-d851-4561-bfef-829af8f12e86");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "000b1e4e-b821-4fb2-aa9c-f34bd0b8bc30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "2a5def37-c428-4df3-a4da-68f7a64d469a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "5d45f9e6-dcd3-412e-be24-90aa9b5f3f01");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "4897341d-eb3f-4606-b67c-bdbe24f17073");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "e0f8cb21-ed46-4074-bfad-5b95928946d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "3dd65d61-fd97-4f51-896d-fbe11153e5fa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "b7bd5910-921a-4d5f-9dfe-4a6d4ea0e274");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "4b4a1d9b-ba11-4109-b76e-bc15cd43a0d8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "0069da2d-ce30-4e05-8512-60ee3e3e7b57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "efa5b06f-76dd-4650-921b-95211474950f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "0ea297ed-99af-4608-bd9b-f549ccebee8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "7f5b0f06-b5c0-47fd-8191-91bbdc391e46");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "38dfece8-dce6-4714-82ce-f02b665fa2e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "29eaa122-e70c-432b-bd27-3fa3d0501ea5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "73b02c83-613a-43db-89d5-6664ce6c68fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "8d6fff7f-ae4e-4bac-9cd2-c7de9f9478a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "70502f92-0438-4bbb-bb0b-d59942fab908");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "8f59390f-3c70-4f83-97b4-cf38b726b6d6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "1539cc76-c04a-4cd3-920d-83bd977facf7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "d4b5669b-fb48-4a09-85db-5e7419d53f57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "6ea0813a-eb80-45c5-97da-04d1b698cf60");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "5a92674c-5b59-4586-85df-47e6a50a2837");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "4585adeb-7eb7-4cc3-941b-8d519882814d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "f4038dcf-90a7-4e65-a900-3d473bd61d40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "eecf0ff8-b621-4a12-b697-46ba3119cc5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "3701ab0e-aca2-4531-971a-97849966f1eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "6f602337-9b55-46a1-87bd-7de5aa1dae8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "886ef4f7-5bfe-4bbd-84c6-42bfe0b95ecc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "73c86329-73e0-4f1c-8a0e-228170dab16e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "a4b974b2-afb1-464e-a63f-b7042b54a7b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "7ce9b339-a31b-4edd-824e-8a7faa9c72b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "156c66e3-19c0-4b2a-9596-874249d0e88f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "b7f21cca-ca5f-42b0-9a55-115116634bec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "8c832e26-2ddc-4641-9d10-540b4f8d1781");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "ae9f93c6-c392-4582-8bfc-94bb9e020223");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "3f3ae0fb-c611-4864-80ae-246e738ff54a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "a8134785-7657-4bba-a9f1-4a4edce70c26");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "d9ba5d3f-67a6-4f9b-9d24-f44318aee620");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "f5b0c992-da39-4f10-a7eb-2bd100cdcc45");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "33c9bd31-682b-4af2-98f1-3792cd84bc84");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "98794ab6-b70f-474a-91bb-6efe53c4b23c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "0fa43e56-9a2f-4b97-9010-2629a834fd17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "e177cf61-f2d3-4c84-b980-c95e11fd6f3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "3d6af892-3b3e-4c03-9d51-da974ea2f5bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "6ff46b10-5b6f-4198-8055-3e9e9a3125e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "f08db9d4-434e-45f5-9133-82011c9d8a06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "77b06e73-7b1a-40ec-9d9c-4ca31efae16d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "5e60f12e-c3d9-4575-9e97-2125367bdc77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "14a92f60-bcef-4021-966a-77c790ffadd2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "54a17c8a-9a34-4c8d-a8d5-e1840f0151e7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "12c3f476-273e-453c-8bcf-427aacf3aa73");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "2ef21f41-8c76-4bcd-9f54-f7f855330e0d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "7fa1f8da-3a93-48c4-a81b-808a7ff0ac9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "d00dde30-bebe-4286-b69e-cedf3fedc4a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "91183a7c-48b0-4902-8fa1-92dd1f2460f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "6e5108f6-ef49-49d1-89c6-d07673186ef5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "63284437-043d-44bf-bca6-4550948eb0c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "814fdf7f-a51a-44ac-92f7-4488a64f3ded");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "987bf006-7d58-4b01-ad0b-913b4a03fa30");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "69cb70f2-d7f3-4a99-a12c-300875c81707");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "a728f080-4fe9-499c-81e2-fc6c2b45c0f7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "61826b68-5996-49bb-92bc-bbd3b56d0ecf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "b6bd926b-8e4a-4127-b8fe-539b4fbb88e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "7bf97c7c-4593-4522-bb4f-d7e696ab531c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "faeb8ac7-1685-4b00-bd98-bc86a72e9ced");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "522dc183-3bfb-4051-a252-a1f9596d56c8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "b5ea0cb1-b64b-4397-a8e9-5f488795a4bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "4b5feae6-4be1-4eff-9fcf-551af2a0a8b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "e225d207-e115-480f-83bd-3e3f076c4b91");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "e2f2bbe2-e680-499a-986c-d4d330350b8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "665d118d-e1d6-43a9-9296-936dcd2941df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "2ff8f998-2c57-45ff-8cb5-9a8be791eee3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "b76498dc-61c0-42df-a864-b41ddef96341");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "6c147daf-c5b0-4d0d-8a3a-565169b8eb0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "aa63060a-f38c-4cb6-ac69-7e11a93ee25e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "dc15a919-50fa-47b3-93ce-18f671fde2e0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "8a210606-94e2-4f22-b7cd-28588c7cc185");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "85965396-ba5e-4702-ab4c-a8df309d2231");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "bbb985a8-3944-4298-b905-05ce6a3fc638");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "a3829f50-4f26-4b45-887d-a1721aa6076f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "dbbf5160-6d76-4ffb-bee5-df363b174caf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "c0559b97-cb46-42cb-8e20-8ce0bb861e87");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "f6f8f776-211e-40ed-9b86-0d21aaef0b06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "7f193f66-d667-4d03-8f16-94f658fe5969");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "20c2de72-7730-45f8-825c-6bf8ea8e3154");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "c549a93b-da36-4c78-ad7f-13a05eaa18e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "26617e94-120e-4946-ae73-1655e9d83484");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "5f46a32a-b0fc-4b01-adb3-cd729f2fc585");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "45e2e1a4-4c10-4629-a060-c1664e9da08a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "bbe69561-a4d3-41af-99d2-25ffeb00735e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "be52181f-87bd-47c0-86a9-3899dead1bdc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "82e29011-62f4-44ec-8b44-40b259d05051");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "a98cc3fd-bd45-4105-af8f-19c13ce71d5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "b0dca08c-2c9e-40de-b45a-2debf139ad7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "171259a3-8db1-42b9-b0f7-02f04bd3b001");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "fb258f42-cd85-4247-a39b-19e6417a75dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "2cbdfb6b-5ca4-4021-b9bd-cdec21ab447a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "2435c120-9c64-4951-bbca-0414270487fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "85d74934-7453-44c5-991d-451d344afaca");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "22891edd-bc29-470a-bbd8-c11cbee44060");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "079f98d6-2163-4c01-ac74-e9332e908ca7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "79856bab-0a6f-476c-a9f5-ac9d28b02040");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "2dc38b28-563a-4d43-899a-37a1f74665f0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "c5f97098-37b7-4a4c-9376-80649232ee57");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "5723d6cb-fccb-46f4-a3da-36bada5076d5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "9ffc78e5-bacf-4900-879c-cfe5190a3fa7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "b0ce1812-c57a-4e3d-8fee-b63fc873fec6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "ff001c7f-9370-4f0f-8917-7de2452a0809");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "1a978892-3516-4693-bbd3-6cfabef913af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "5b99c0f8-b472-4f2f-8341-9e2615bdaea8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "c2e55450-8a6f-4c63-b55d-2fa08de2bd06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "5fafd215-369f-49b8-8c7d-32b762fabd7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "bb79ba38-07d5-4269-8be1-526abeeb277c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "77e4193d-cc19-4bf5-8537-2e6fa84229a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "a3c65f24-2b56-46d0-bc2c-f7c256c3cfff");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "10358146-568f-4c5d-9d69-e83b09dda05e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "d4d4b748-4eec-4fc7-b18e-f736646c3c43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "964d8c9a-379c-4eee-9708-bbb20b6eaff8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "be0b990e-98a3-46c4-868b-34c557f5c065");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "d9ab235a-a86c-481e-9a1e-6b62b4ffc744");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "845a4af8-f671-4df1-85dd-d50f01227c43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "e390de49-f7b9-49e6-a4dc-5ed5e9d4b712");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "060f61d8-79ca-45a2-88b4-12f0c36f0b7a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "885cceb3-ec84-40f3-8def-dcdea62bd912");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "1d05aadf-6840-4bb3-a592-00733aed5ceb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "c922f6a0-d676-436a-b862-64381e6da84b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "a9e8b506-d23a-408d-88fc-a892e5e5d14f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "1b1ba7dd-a024-4460-a11f-0fdf5042e23e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "29c4a219-da15-47ce-85c6-1579a7f4afd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "73f2be75-b540-499d-b0dd-515a94e1c55a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "6ed49d5f-787c-4cd9-8571-9435c82c9017");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "e4708235-0d28-4e7e-88fe-8fee2532a417");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "c18854de-f5f2-40d0-aaef-f9e0003d27d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "a3864afa-678a-4185-99db-bbf3666f2b18");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "f7eb03e5-0681-4da9-8462-83ce926b1a64");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "b38ce1da-e1a2-4c97-ba68-ecb7bf8df98e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "f1c14102-c074-4c49-a806-a41c2256f6e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "ae8f8c07-def1-423a-8b5b-afe9d74579da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "3156d9b3-acc5-4c66-b77a-2ca18f509984");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "d9f7781e-95f7-4183-a28b-f568865c7781");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "15ad22b6-a476-44fd-9a8d-f437fd1424c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "9a832505-aa74-4529-b94b-1137831ea464");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "ce460831-459f-4831-a737-d29bd416a7ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "55ab60c7-7d3e-4e50-bfb9-f1ed3e721fc9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "f9b4add8-bd66-4ab3-9301-e1f7b5d5883c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "859c1bd9-56e5-40e0-b5ac-7408fcf809f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "6ba3ac7f-4b49-4477-acc7-65f86181f273");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "a5a8aaf1-fb33-4a52-a127-ca451f620a2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "91999b63-b1ba-4d5f-bb05-d13f6c6eba95");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "14c93ec9-f08a-438f-bcf1-18c84f0931cf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "a4bd9ed9-e9f8-43e6-b9fa-0eeb509c6afb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "eadaaa69-43e3-4b37-af39-a8cfcf2386f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "a5080c43-db52-4405-983a-539897947320");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "da177b4d-f1f8-48e5-b4a6-6f5d1da28263");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "f988b9c0-e9a4-4d8b-8ac4-c88f72ef2d8c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "73ff2625-155f-4638-a1f5-5b83596a50de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "8cb9593c-1931-48a1-91ec-f4b2acf4265b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "df9be928-e144-4703-9c43-85c0976a4b05");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "70932fd5-5427-4a1e-839f-4eeba48ccb9c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "1f7e60e9-86de-462d-a756-80838717a546");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "e206e9dd-a74f-456a-9970-d492ea7e4ba3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "7430ff3f-ae9f-48e5-a41c-3572103cb014");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "06523a4b-c7a6-42a2-acff-9df6b51dddf9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "7bc56c61-471c-4cb7-9cc6-bfe481bb46d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "fece4361-672d-4c88-9b5c-db403622ce3f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "93f5e8e1-6563-46b7-b415-a5096dfd206c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "c019da9b-bd67-4521-89af-257a39e55d8b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "d3d1d3e9-e61c-43b5-817e-0a5ae69047e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "550ddd52-1f55-46ca-8546-6264bbfb543c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "a3be9cb3-8cff-41c1-bdaf-4383b2e17bf8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "e532ddff-a874-4055-ad5d-fc11de14e468");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "003d7f26-32ab-4c7b-8119-aaa3685c9e68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "94a10354-f497-47d0-b617-22b28d90d1de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "16bc7ba7-aca7-4d49-82ad-af53947d8e31");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "89eb5303-c9a5-44b7-876b-4d20d0ba4561");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "d0eff031-8c01-4c4e-960b-423d85eed7bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "f3b7ca3b-4db5-489e-adfb-bbe6b81daf3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "52957702-a4b4-4e08-a0bc-acc4348316b5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "9d4807ad-cb0f-4636-a337-aaf8e4ab72ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "75b84e8c-2ca3-4e52-9140-e1a2b5d93e28");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "b3be7920-5c63-4c7d-8e28-32952effe776");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "5d3204a0-e40c-4fc1-8418-22f7d969fecd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "0a9da516-847e-4d8a-b519-51c46fac8a0e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "44588d06-a192-43d6-8bbb-6fd1eaa8e560");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "607dc98d-b5b5-4f02-a9bd-b0359bee6edc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "7f7e580b-ce9d-4c0d-a649-86df91f4edaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "90fa3ac4-7504-4c23-8c7a-6017176f1218");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "17361020-d76b-432a-9d88-fe31f3bdc4ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "2dfe5ea3-9cab-4df8-b1b1-5fadf7b6df5e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "675a8013-d133-42ff-8d9f-637a62c36ff3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "d6086b8d-0b0b-402c-b464-f27ef6c86d2a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "4756631a-b6df-4691-b7e6-ba7662559bde");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "a28a6550-44c6-4258-9f8a-75dc691fd4de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "4a552006-15fd-47d0-ab0c-2f95941b4ef4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "0a077df4-6ad7-406e-a09c-2c2bfbde9057");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "d45639df-6a1a-44da-8d89-bbd183ea5946");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "1803830d-ba4b-4b79-b233-65b529e7715b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "f80629f1-d6d9-4297-b175-2e9f4eefc1dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "7ca1add6-17e8-4395-928c-df1991c8f425");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "d2c8eaae-2ff3-40ae-b830-1d8f6fa0cb78");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "980bfd57-3c10-46fb-8f01-4f9b304d0b8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "7e01c43b-ec67-46ae-b9c5-30c05737a9d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "63ca1066-0030-4166-b6c0-a37a974fb5be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "caca1baa-692b-49b3-b072-501ed87c0cd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "b9f4deb8-5f56-475f-8953-5340da622282");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "a4072ff5-48a5-4562-8d85-524070e36441");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "22c825c9-5401-4775-a95c-74d17c61c042");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "05263b35-18a2-4040-a9c7-6eb445f6c83f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "21fd3f26-7b75-4314-b924-f7ed09d386d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "e54e3b69-8bb1-44ba-b2ee-c3c1cffe3b61");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "ff1090ac-e4ba-4e44-9b51-aeee512310b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "221e4be2-b0ca-4440-bdf3-49aa00781017");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "7971b170-b292-4676-9ae7-4352361beef6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "ccab6a6c-4d01-4a8a-aaa9-5546fb2fe823");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "0c305850-b142-4ba7-a367-b6efea31bacd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "6db6b8b2-428d-4fb5-8b54-3708fb04f6da");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "f38fff57-8e41-4532-99e9-5588b18705e5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "bea20b94-3e25-4d1b-8670-9a3b4cbd4d38");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "c0c8d981-617f-4120-be27-dc5a85ea8548");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "88f06666-888d-4666-bfde-6b00554d41a6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "e4817269-117b-4f66-9d78-14eb9b41482e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "248ffe0a-d699-4389-8136-7586f7d74ec0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "09f16e70-f085-496e-b708-6cfbc2988819");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "52c24908-c296-42d0-8798-6aa2992daaf2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "cb571f18-c349-4e29-a1e1-e5f0881aebe3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "f3975925-5653-427a-b775-ef2e8f1dcb67");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "3ba2e98e-5a60-4c52-aa6c-b7de0493fbee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "e3532815-fd88-4956-a353-3389207c3c23");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "b63989d0-b13f-498d-ba00-d6ead621e854");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "d1cd630c-13f0-45f3-a2a1-ab5987dc865e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "647bc11f-0160-4196-8f6a-98adc91f3403");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "ff33fc6f-e8de-428f-84d9-3b4ed9362013");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "41e08b06-dfef-40de-bd20-1d6ad0993bb2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "4625d11a-bb0d-493d-9daa-a6d8d8713a02");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "af5344f0-e550-4415-9393-1ee58118392c");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "5c808a22-cb3c-46ec-82f3-f0b67f876ed2");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "6c7cd7f3-a9e7-49b8-9766-52744de5899f");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "f1e39763-0770-40f3-8f66-c263d3e0d1b3");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "f65613ad-84be-4f58-8b30-b44c617be65c");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 6,
                column: "MaritalStatusGuid",
                value: "324e37a2-f504-4bac-bd87-e3187b8abdf2");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "0652c961-a28b-4672-95ab-887a35c69363");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "206d8676-393f-4b24-920b-e50fb532a738");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "16ce37c7-a4e5-405b-96b4-90ecf1da8318");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "3de7dcc8-4036-4b1d-93b4-e3b63f0b982d");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "c6efb626-2d29-404f-9442-794d175ec662");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "d0821bb6-db45-40b7-a046-797574fa464d");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "e10badc2-5269-4652-8cc3-8c298ed24701");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "b7483a18-47c8-46e2-98d7-86c6cd66c37b");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "c1871049-8883-44e1-bb12-4eb2edbae2d3");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "cf0a0acb-e6ab-41b1-8da1-4e20b6a17040");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "8ce8fb21-38a8-4637-8805-cde8cd9ec1c1");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "3d4c5106-ddf2-4169-90d4-82932c35ab28");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "725966ed-4372-472f-94de-fc6ba22da96f");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "192394e1-956d-431b-967f-c05c21db3d9d");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "8061d0de-a535-4fa5-9e47-f7f238ebb6cd");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "01774e6e-666e-43a9-98b0-94370a200075");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "6c6bb877-eba7-4d75-8b9d-d7d01862bcbf");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "19322004-69b0-40dd-8f4e-43ab9233875b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "73f71610-cc34-4b3a-ba57-0c10e2f7f407");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "22c244ad-e8b6-4759-9bdd-537b073a8532");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "89482912-d272-4472-b30b-50ff9c552aaf");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "3f763533-50f2-4740-b5d4-a31b8ae20965");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "d6d7bfa8-6725-410f-aaa5-568185bc9b58");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "170dd01c-0953-475c-b908-e91db76d60be");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "89a6d782-0210-4f84-94b6-65e6c59bb4cf");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "72ed422c-3561-46cb-a585-bb52062dedad");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "cc9b42da-21ad-434e-bbe9-ad4e8042658c");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "e0ab7c9b-e983-4f16-9611-e35a8ed7e766");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "e4805014-16c5-4d5a-ba63-42323557b228");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "75aa7075-95b3-4222-912d-314e7b0d063d");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "711c9cd4-fb48-46a4-8bd2-fa90912ecf2e");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "3868272f-51c1-4895-b6ae-9ac022e41837");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "7b8a3c36-3127-451e-9947-76bf2483ce13");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "92c9e302-1f8e-45d2-9b10-d06449c74d79");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "d0efd8a1-5018-4d85-bca5-4a95e39764cd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 171);

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 1,
                column: "CertificationStateGuid",
                value: "51e8c172-fba6-44b9-a8b7-8d4a9eecb89c");

            migrationBuilder.UpdateData(
                table: "CertificationState",
                keyColumn: "CertificationStateId",
                keyValue: 2,
                column: "CertificationStateGuid",
                value: "017de547-91fd-44ab-906e-b30e619a0476");

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 1,
                columns: new[] { "Name", "NameEnglish", "ShortName", "ShortNameEnglish" },
                values: new object[] { "Dólar", "Dollar", "USD", "USD" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 2,
                columns: new[] { "Name", "ShortName", "ShortNameEnglish" },
                values: new object[] { "Peso Colombiano", "COP", "COP" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 3,
                columns: new[] { "ShortName", "ShortNameEnglish" },
                values: new object[] { "EUR", "EUR" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 4,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Dólar Australiano", "AUD (Dólar Australiano)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 5,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Real Brasileño", "BRL (Real Brasileño)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 6,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Peso Chileno", "CLP (Peso Chileno)" });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "CurrencyId",
                keyValue: 7,
                columns: new[] { "Name", "ShortName" },
                values: new object[] { "Peso Mexicano", "MXN (Peso Mexicano)" });

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "DocumentTypeGuid",
                value: "786097fe-b2f6-44f7-a992-4dfdb0199902");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "DocumentTypeGuid",
                value: "4a8623e4-897e-4d01-83ca-db34103db41c");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "DocumentTypeGuid",
                value: "ce47c3bc-97be-4662-b5b5-8c03e9e0ec0e");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 4,
                column: "DocumentTypeGuid",
                value: "01fea538-7de7-4889-b915-7cf4e7c4c9a6");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 5,
                column: "DocumentTypeGuid",
                value: "c1f56ee3-4348-4b54-8c30-c1547919fc8b");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 6,
                column: "DocumentTypeGuid",
                value: "80465d03-a01d-46a4-9969-9cff3670a5eb");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 7,
                column: "DocumentTypeGuid",
                value: "7dc36b38-c7bd-412a-aaf9-f619c6cfd43b");

            migrationBuilder.UpdateData(
                table: "DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 8,
                column: "DocumentTypeGuid",
                value: "b7fcd5c4-2a64-4fc1-bc26-fa6b4f0eec50");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 1,
                column: "EquivalentPositionGuid",
                value: "ca63969c-4aac-42ec-82f7-a9bdaa2faa88");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 2,
                column: "EquivalentPositionGuid",
                value: "5a2c36fe-3e08-49cb-aa6f-55d711b20543");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 3,
                column: "EquivalentPositionGuid",
                value: "5dbef4b7-e012-4a4c-99d6-f67afac3bd84");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 4,
                column: "EquivalentPositionGuid",
                value: "69af2db5-1593-4091-982c-676fc72c8ed6");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 5,
                column: "EquivalentPositionGuid",
                value: "c712ca38-996c-4297-8a79-8320aee14fb3");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 6,
                column: "EquivalentPositionGuid",
                value: "8d90236a-39b4-45f8-9287-c9956f6096c4");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 7,
                column: "EquivalentPositionGuid",
                value: "cc0f89d1-cf80-4473-bad0-fe860fefcef1");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 8,
                column: "EquivalentPositionGuid",
                value: "1c2f380f-050f-44ac-9f5a-ed2a9f7e2a18");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 9,
                column: "EquivalentPositionGuid",
                value: "a2064132-170f-4fb0-8bf4-aa2b1e24ff38");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 10,
                column: "EquivalentPositionGuid",
                value: "638e53b1-f741-4813-82ac-54f4e203803e");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 11,
                column: "EquivalentPositionGuid",
                value: "b36af299-368e-4d9a-ab9c-d75462044fd3");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 12,
                column: "EquivalentPositionGuid",
                value: "e5c99700-07a7-4405-92d0-0c4c4ce33387");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 13,
                column: "EquivalentPositionGuid",
                value: "aa2499ca-d2e1-49fd-8bb6-132e3e43bf95");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 14,
                column: "EquivalentPositionGuid",
                value: "6615df67-cac2-4ea1-8dcf-89ce6fa6dce4");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 15,
                column: "EquivalentPositionGuid",
                value: "0809f51c-c6fe-4807-b14a-995cf35a190e");

            migrationBuilder.UpdateData(
                table: "EquivalentPosition",
                keyColumn: "EquivalentPositionId",
                keyValue: 16,
                column: "EquivalentPositionGuid",
                value: "cd0116dc-3952-440e-8794-ac8549a8e69a");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "GenderGuid",
                value: "eb1a1ba8-f9d3-4a26-9f9b-1dc39da438a1");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 2,
                column: "GenderGuid",
                value: "c2936fc9-95bb-4251-8cf4-5ba474214919");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 3,
                column: "GenderGuid",
                value: "b6ee16d3-35fa-4f0b-b7d9-68a17074aef5");

            migrationBuilder.UpdateData(
                table: "Gender",
                keyColumn: "GenderId",
                keyValue: 4,
                column: "GenderGuid",
                value: "79ccf53b-1172-462b-aaae-c1f551e11b66");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 1,
                column: "IndustryGuid",
                value: "36fa83f4-206a-4d99-b067-4b7b8f4007c2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 2,
                column: "IndustryGuid",
                value: "d47145c7-c37a-4d94-81d7-4443b162be6f");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 3,
                column: "IndustryGuid",
                value: "4b30727a-8f7a-4ce1-ab06-4d071d0038ce");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 4,
                column: "IndustryGuid",
                value: "074c3f01-52f6-49bd-a9e5-745ee941a223");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 5,
                column: "IndustryGuid",
                value: "5aadf072-3c83-4c62-8a50-f0c5001f6d12");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 6,
                column: "IndustryGuid",
                value: "43dcce19-4c40-4314-a74c-5117f3377180");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 7,
                column: "IndustryGuid",
                value: "ced559c4-4dc9-4101-ab49-6f9dcccd6204");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 8,
                column: "IndustryGuid",
                value: "f876375e-7dd2-4ebf-b089-2162a3e2beba");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 9,
                column: "IndustryGuid",
                value: "5fdc192f-18c8-4fdd-8d81-ebbe3bd36457");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 10,
                column: "IndustryGuid",
                value: "306b79b9-fd4d-4eb7-b1e7-8fd374dedc78");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 11,
                column: "IndustryGuid",
                value: "233e2953-dc9f-48e5-81e1-433d49dc0331");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 12,
                column: "IndustryGuid",
                value: "aa691e67-fdf5-40d9-8399-e98edb6cd9a2");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 13,
                column: "IndustryGuid",
                value: "e0f1e598-c69b-4fa7-b467-9c0705d5d5eb");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 14,
                column: "IndustryGuid",
                value: "98778459-b7a1-4bf6-b503-40f3ad6e75b0");

            migrationBuilder.UpdateData(
                table: "Industry",
                keyColumn: "IndustryId",
                keyValue: 15,
                column: "IndustryGuid",
                value: "f2f4bd72-9489-4933-b328-a34afbb2c62e");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1,
                column: "LanguageGuid",
                value: "1fdc57f0-a7ff-49dd-bd32-260dff063ba2");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2,
                column: "LanguageGuid",
                value: "6f3285b5-8f7e-4139-9b24-1944b1557cff");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3,
                column: "LanguageGuid",
                value: "29859da4-e5e8-4a4f-954e-16b2a192417b");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4,
                column: "LanguageGuid",
                value: "310ea3e9-8863-42b6-90f0-30c195495dcf");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5,
                column: "LanguageGuid",
                value: "239a2e5e-2750-4220-b6e2-649c3a846311");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6,
                column: "LanguageGuid",
                value: "9a0eddb6-71c8-4d1d-8165-3920898d731f");

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 7,
                column: "LanguageGuid",
                value: "3b69026a-ae90-4b3c-b9c2-8bb567d9f189");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 1,
                column: "LanguageLevelGuid",
                value: "e98eb780-eda0-412d-aa65-3047c08b003a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 2,
                column: "LanguageLevelGuid",
                value: "b3b3b756-51c3-44ca-81e7-dbfef9263acf");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 3,
                column: "LanguageLevelGuid",
                value: "d9d8c47a-d05d-4ee4-a7d4-80ff4f78a3fb");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 4,
                column: "LanguageLevelGuid",
                value: "62bc92fd-625c-4d0a-b277-6e0ec7f0e620");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 5,
                column: "LanguageLevelGuid",
                value: "ac0a48ea-2adc-4d10-a45f-a1e650a7195b");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 6,
                column: "LanguageLevelGuid",
                value: "d6f9a968-80c0-4184-a6b8-0cc98c3c999a");

            migrationBuilder.UpdateData(
                table: "LanguageLevel",
                keyColumn: "LanguageLevelId",
                keyValue: 7,
                column: "LanguageLevelGuid",
                value: "e9fcd85b-b263-449c-9aaa-5ae647407849");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 1,
                column: "LifePreferenceGuid",
                value: "619b1a38-7acf-450a-b1dc-df0afffc0077");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 2,
                column: "LifePreferenceGuid",
                value: "98356436-cd0d-4731-b51d-e1e539a28a39");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 3,
                column: "LifePreferenceGuid",
                value: "61dbbd20-5f6a-480b-9101-26affbbe2996");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 4,
                column: "LifePreferenceGuid",
                value: "4b47461b-4e8a-472b-b112-9026a2f9ce12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 5,
                column: "LifePreferenceGuid",
                value: "8e859bee-072e-4517-9612-ad2a9c96558a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 6,
                column: "LifePreferenceGuid",
                value: "df8ba91f-1d2c-4dea-8803-2e9a8f5d7aac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 7,
                column: "LifePreferenceGuid",
                value: "60e84933-7f26-4431-9fdb-462f69bc4bbc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 8,
                column: "LifePreferenceGuid",
                value: "419284d7-375f-44c5-bb10-58c5e9c697e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 9,
                column: "LifePreferenceGuid",
                value: "cc43a5ec-cef5-4c71-a7d7-8dfec2ea74ce");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 10,
                column: "LifePreferenceGuid",
                value: "39a38079-bbeb-4b01-846e-ea3d8dd0a6f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 11,
                column: "LifePreferenceGuid",
                value: "3925f781-0978-4b52-a936-920cf9cb0fa4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 12,
                column: "LifePreferenceGuid",
                value: "0b01d92a-9803-4d0f-ab6d-577d85a6e1ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 13,
                column: "LifePreferenceGuid",
                value: "2a7b84e5-7e2a-4300-96fa-bd70125094e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 14,
                column: "LifePreferenceGuid",
                value: "2b0c57e8-63a2-43cc-8fb8-77316d07da37");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 15,
                column: "LifePreferenceGuid",
                value: "54355fea-62c4-4cdf-960f-542c3b975844");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 16,
                column: "LifePreferenceGuid",
                value: "c8f135f2-1b18-4bfb-9edb-186c3ce01897");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 17,
                column: "LifePreferenceGuid",
                value: "eb27fc01-40db-4088-a7e9-6b3ee1c0c0a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 18,
                column: "LifePreferenceGuid",
                value: "c67697f0-81b1-4964-b5d9-99cf1f6c93ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 19,
                column: "LifePreferenceGuid",
                value: "7d2f76b2-1974-43d3-a1ac-38b0f51758c5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 20,
                column: "LifePreferenceGuid",
                value: "b2233d53-c81d-47f8-a709-3e491c8f8cae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 21,
                column: "LifePreferenceGuid",
                value: "398ae362-13fb-4381-adfa-bb821f0c27b0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 22,
                column: "LifePreferenceGuid",
                value: "04651cbf-dfa1-4a61-918d-382aedb8adb3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 23,
                column: "LifePreferenceGuid",
                value: "6f91cfb1-3936-4644-8ad8-6deabfcef53f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 24,
                column: "LifePreferenceGuid",
                value: "d2fc5433-e1ff-4124-bf0f-2eef968ee1db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 25,
                column: "LifePreferenceGuid",
                value: "f144146a-c749-440e-9b18-85f13a0e46ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 26,
                column: "LifePreferenceGuid",
                value: "d5e8246b-5b7a-4299-9972-7fc05244c676");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 27,
                column: "LifePreferenceGuid",
                value: "7f43a612-b1a0-4c6e-a130-ea12b5622444");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 28,
                column: "LifePreferenceGuid",
                value: "dc22ed10-5bd0-4a31-97d9-aafe3fb49d72");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 29,
                column: "LifePreferenceGuid",
                value: "07f2946a-c6b2-4d20-bcf4-ceaccb852bd4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 30,
                column: "LifePreferenceGuid",
                value: "f52432e1-46fe-46fb-beb0-5dd3f79be051");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 31,
                column: "LifePreferenceGuid",
                value: "c3d0fd0e-1d5b-4741-8dea-016419929482");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 32,
                column: "LifePreferenceGuid",
                value: "1aaf235d-5cf0-4724-9337-82826f94863a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 33,
                column: "LifePreferenceGuid",
                value: "394df941-24ef-4714-9da6-bfada45ca36a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 34,
                column: "LifePreferenceGuid",
                value: "3baf4923-6223-4735-9eba-08e68a001f53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 35,
                column: "LifePreferenceGuid",
                value: "81ea38a0-0448-481c-8b57-16d1293eec33");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 36,
                column: "LifePreferenceGuid",
                value: "30275fdd-4e96-49b1-aa12-8ac5a27c08a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 37,
                column: "LifePreferenceGuid",
                value: "1f948179-474b-4887-a711-aeeba63fdf83");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 38,
                column: "LifePreferenceGuid",
                value: "f8dd68c3-2a9b-428e-a71f-66c666b27c66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 39,
                column: "LifePreferenceGuid",
                value: "eba958c8-2b67-42fc-be46-5a6f60068dda");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 40,
                column: "LifePreferenceGuid",
                value: "d47a37c5-e7ca-4f47-9494-1891c1d98234");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 41,
                column: "LifePreferenceGuid",
                value: "15d92728-0be8-4e3f-9384-9cae3cff559a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 42,
                column: "LifePreferenceGuid",
                value: "0ee1fbb3-6819-427b-88dd-500795d03c53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 43,
                column: "LifePreferenceGuid",
                value: "d0717a78-6c49-4a2a-b821-6721b27be8de");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 44,
                column: "LifePreferenceGuid",
                value: "cbfd748d-0424-434d-b5de-354139ae5444");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 45,
                column: "LifePreferenceGuid",
                value: "f1b655c3-5e58-44fa-a3bf-813f8c7d524b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 46,
                column: "LifePreferenceGuid",
                value: "b0662592-7786-46c5-950b-9d8a746b0931");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 47,
                column: "LifePreferenceGuid",
                value: "26b30584-ac4d-47b0-9f1b-bd970ccfc6eb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 48,
                column: "LifePreferenceGuid",
                value: "081abc3a-d70e-41b1-8f75-b2a71a159081");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 49,
                column: "LifePreferenceGuid",
                value: "e1233f7f-1375-42c5-8f5d-f7ca0cd2c7b8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 50,
                column: "LifePreferenceGuid",
                value: "612faed7-b531-4962-85c4-441e1fb24581");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 51,
                column: "LifePreferenceGuid",
                value: "8899b139-2300-4275-b1a1-bf02e90b4f66");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 52,
                column: "LifePreferenceGuid",
                value: "de711adf-9f15-43e3-b1b6-c5fa84f15784");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 53,
                column: "LifePreferenceGuid",
                value: "a444fd01-ed84-40c8-b4ed-f435f76bbe58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 54,
                column: "LifePreferenceGuid",
                value: "de21f6af-b865-4de4-a184-0b58483d9b53");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 55,
                column: "LifePreferenceGuid",
                value: "1858eae7-d784-40ac-95d8-bc882077d688");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 56,
                column: "LifePreferenceGuid",
                value: "6f6041f3-4eb5-42d2-9858-b10772461ea2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 57,
                column: "LifePreferenceGuid",
                value: "fdce6218-485e-45b9-9a70-a9432a24466e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 58,
                column: "LifePreferenceGuid",
                value: "03cb3e9b-6193-48f6-9571-6f0a11aafbad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 59,
                column: "LifePreferenceGuid",
                value: "f5c3d93a-aa08-44d8-8c80-eff6f0f6c9d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 60,
                column: "LifePreferenceGuid",
                value: "470cef65-3805-42d7-b0f7-7552d826a216");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 61,
                column: "LifePreferenceGuid",
                value: "478e62f1-00af-468f-8d0e-124de1a58c5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 62,
                column: "LifePreferenceGuid",
                value: "3cd175e8-faee-41e9-ad97-4c4f9a7c375b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 63,
                column: "LifePreferenceGuid",
                value: "866d6d53-9756-462f-beae-9b196fde994c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 64,
                column: "LifePreferenceGuid",
                value: "5a62a4eb-f364-4589-a97d-c77897f5f16c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 65,
                column: "LifePreferenceGuid",
                value: "c1f396ee-f5fd-42b8-9db5-9432b2f40b09");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 66,
                column: "LifePreferenceGuid",
                value: "1815a33e-ee66-4206-bac6-594dc2702568");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 67,
                column: "LifePreferenceGuid",
                value: "17090604-d309-44ec-9c27-1ef7f865afcf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 68,
                column: "LifePreferenceGuid",
                value: "6058c113-46f1-413f-87d8-d96d76e6c0e6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 69,
                column: "LifePreferenceGuid",
                value: "73e00888-abe4-41d5-a5ee-f80f9ff1c0af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 70,
                column: "LifePreferenceGuid",
                value: "7223a11a-1d3a-45f8-87ae-91568925cafc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 71,
                column: "LifePreferenceGuid",
                value: "634b6c2c-fac8-4ee4-84f0-60a872f591ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 72,
                column: "LifePreferenceGuid",
                value: "82f5eb08-216c-4f10-aade-9273cb027e5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 73,
                column: "LifePreferenceGuid",
                value: "bf4a51f2-cb05-4801-9867-b8a9e64d28d3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 74,
                column: "LifePreferenceGuid",
                value: "51670a20-fd1f-45ca-9953-75e726772200");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 75,
                column: "LifePreferenceGuid",
                value: "f3e67266-a0cd-4f4b-8efe-829c967e6407");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 76,
                column: "LifePreferenceGuid",
                value: "1c632abc-e0d9-478e-9e82-d9587c4167a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 77,
                column: "LifePreferenceGuid",
                value: "2412e04f-fd58-4452-980e-c73cb82a9d9b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 78,
                column: "LifePreferenceGuid",
                value: "27b3781e-3033-4a0c-9c12-714c0bdfd030");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 79,
                column: "LifePreferenceGuid",
                value: "4831dbc0-ccdc-4269-b702-fd52dd4e3d62");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 80,
                column: "LifePreferenceGuid",
                value: "7bf4098b-026a-4284-9a7d-18924accd3f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 81,
                column: "LifePreferenceGuid",
                value: "22036967-74e3-4191-b984-74c7c8be07df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 82,
                column: "LifePreferenceGuid",
                value: "c64eceb6-ef04-491e-aa7c-b7dd06d9068e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 83,
                column: "LifePreferenceGuid",
                value: "4a0f2be7-0983-4b3f-bbf4-f1def2c92e71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 84,
                column: "LifePreferenceGuid",
                value: "f8aae424-4e10-4a6d-9942-fa4eab4e104f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 85,
                column: "LifePreferenceGuid",
                value: "7c1911d2-f187-40d2-8511-f6cdc5d2e34c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 86,
                column: "LifePreferenceGuid",
                value: "cc02eaf7-fc16-4390-ad58-284886f5e1ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 87,
                column: "LifePreferenceGuid",
                value: "32c2c24d-e082-4d58-9095-5341a6e3df6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 88,
                column: "LifePreferenceGuid",
                value: "fb470f8c-d3b8-4a95-b16d-c80f19409bfc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 89,
                column: "LifePreferenceGuid",
                value: "1e2d9744-5208-4d45-bc68-ed4a20f6c6a6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 90,
                column: "LifePreferenceGuid",
                value: "6e6a0edd-1b46-4f0d-977d-f813256a3e79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 91,
                column: "LifePreferenceGuid",
                value: "6b4a0a37-aaab-4663-b961-3e4b770c9c79");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 92,
                column: "LifePreferenceGuid",
                value: "bc5cb672-c08c-4b1d-8f19-831a7ad3637e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 93,
                column: "LifePreferenceGuid",
                value: "30e01c5a-f322-4fd4-9efa-473edcc11785");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 94,
                column: "LifePreferenceGuid",
                value: "640ff6ce-ccae-4b0e-920a-da605001d6df");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 95,
                column: "LifePreferenceGuid",
                value: "bba1420f-dc54-4b63-a858-431e7da84ac4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 96,
                column: "LifePreferenceGuid",
                value: "0472effc-1b53-4adf-b2c6-7a9ae0287ab2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 97,
                column: "LifePreferenceGuid",
                value: "41862c07-c012-486c-8cd7-ac0ea5afb3d0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 98,
                column: "LifePreferenceGuid",
                value: "9df99a7d-6137-463d-8c11-0162bafb6dab");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 99,
                column: "LifePreferenceGuid",
                value: "a5837630-7e3b-40db-9229-6b735d4a83db");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 100,
                column: "LifePreferenceGuid",
                value: "7aefef84-55a2-4c1a-b5e2-51bea53312a5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 101,
                column: "LifePreferenceGuid",
                value: "0a150622-635d-469c-808c-aba12a4f7b18");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 102,
                column: "LifePreferenceGuid",
                value: "34c9af88-0172-48a5-8b33-20d04fb64b43");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 103,
                column: "LifePreferenceGuid",
                value: "160090b4-2f38-4c2e-8b02-a6bb96b48f82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 104,
                column: "LifePreferenceGuid",
                value: "bcf9969c-b807-487c-91ea-c9c0a70a64b2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 105,
                column: "LifePreferenceGuid",
                value: "0267b667-16c0-4d5a-b033-567f00ccb264");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 106,
                column: "LifePreferenceGuid",
                value: "bad037af-8e3b-432e-b1ab-f1242b360142");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 107,
                column: "LifePreferenceGuid",
                value: "6eadbd73-2814-43fa-ad6a-961ad3ebb5a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 108,
                column: "LifePreferenceGuid",
                value: "08eee488-ac24-4ad5-8f87-aad2279d2b71");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 109,
                column: "LifePreferenceGuid",
                value: "40e6c6a3-3cf4-4f19-874f-5434722d0638");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 110,
                column: "LifePreferenceGuid",
                value: "deb43a48-7c8e-4392-a9a0-59dea97350cb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 111,
                column: "LifePreferenceGuid",
                value: "c78b8709-c1fe-4fcf-9719-ce1a244226aa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 112,
                column: "LifePreferenceGuid",
                value: "5bafa07d-e0ca-40c7-9c4a-d0acd758b9d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 113,
                column: "LifePreferenceGuid",
                value: "b3ad57a7-96aa-41df-9ba7-73a71909af50");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 114,
                column: "LifePreferenceGuid",
                value: "e966ba96-2e29-455d-84db-1d53873837c3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 115,
                column: "LifePreferenceGuid",
                value: "962e4433-8843-4446-ac45-d6623136223f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 116,
                column: "LifePreferenceGuid",
                value: "d2f1ad91-2614-4396-a2cc-ceda3afded68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 117,
                column: "LifePreferenceGuid",
                value: "8430d63b-db49-4705-9003-cc33d6673cfd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 118,
                column: "LifePreferenceGuid",
                value: "489bf810-7886-4307-bbac-39f7f47656ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 119,
                column: "LifePreferenceGuid",
                value: "e9ea1747-65cd-46c1-953d-4ef30c9dba17");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 120,
                column: "LifePreferenceGuid",
                value: "640e017d-b552-400a-b770-856ff568c4bb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 121,
                column: "LifePreferenceGuid",
                value: "4df61567-cba3-44cf-bf2d-c15e14b4ab52");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 122,
                column: "LifePreferenceGuid",
                value: "2009f731-3ef2-42ca-890e-2281a772f9fd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 123,
                column: "LifePreferenceGuid",
                value: "c0878890-dfee-4f67-9079-53e6adeb1820");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 124,
                column: "LifePreferenceGuid",
                value: "3b48e00a-8a6c-43c3-892b-6c873d9197a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 125,
                column: "LifePreferenceGuid",
                value: "7bee08ab-5773-4fc8-ba76-0d03e15f2bad");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 126,
                column: "LifePreferenceGuid",
                value: "19c861a1-f9fa-4d26-939a-b180a0c5ace2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 127,
                column: "LifePreferenceGuid",
                value: "3fcfa658-5b57-42a0-8a8c-93be202d1bac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 128,
                column: "LifePreferenceGuid",
                value: "6a8f17a1-de8f-4d44-a897-3964d0b3f55d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 129,
                column: "LifePreferenceGuid",
                value: "da5f6778-bcd2-4273-bec0-dc34b74c546f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 130,
                column: "LifePreferenceGuid",
                value: "0d8d829b-77e3-4179-a155-e1b2fdbae8a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 131,
                column: "LifePreferenceGuid",
                value: "71804f4b-187b-4014-9409-05e1f088e2bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 132,
                column: "LifePreferenceGuid",
                value: "f6ee5c6e-ae8a-4c4f-b13f-00cf22591879");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 133,
                column: "LifePreferenceGuid",
                value: "c4bb8210-eda4-4928-be8e-01a4c77917b9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 134,
                column: "LifePreferenceGuid",
                value: "5e8760b0-ab33-4ba4-988f-dfa4716350ac");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 135,
                column: "LifePreferenceGuid",
                value: "e56b286c-f108-4586-8dfd-4f656a9c70f5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 136,
                column: "LifePreferenceGuid",
                value: "bcbe4ffb-f7d4-477c-85a9-1209d93fc551");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 137,
                column: "LifePreferenceGuid",
                value: "ea258dd0-e639-46db-adb6-6da83486b069");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 138,
                column: "LifePreferenceGuid",
                value: "7ca7f7fd-5250-4e87-97ac-6280fd6bface");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 139,
                column: "LifePreferenceGuid",
                value: "800968ef-df1a-4b1a-a2a7-d67b9f9c0205");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 140,
                column: "LifePreferenceGuid",
                value: "a64518d4-9b8f-426d-8bde-048f1399527c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 141,
                column: "LifePreferenceGuid",
                value: "f1607d11-6a21-4a74-bdd7-51964ac2e8e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 142,
                column: "LifePreferenceGuid",
                value: "234102a4-ce74-4aa1-96e4-ff3eaf861b8f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 143,
                column: "LifePreferenceGuid",
                value: "a4e57a27-b7c1-4986-854e-229b485e6c5b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 144,
                column: "LifePreferenceGuid",
                value: "c241bcec-fb58-495f-ae80-14c8beb69de9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 145,
                column: "LifePreferenceGuid",
                value: "9c2779ff-1a36-42ba-8a4a-0d2c1a925572");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 146,
                column: "LifePreferenceGuid",
                value: "de0abfaa-4dcc-47d5-8c60-c83e108f3450");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 147,
                column: "LifePreferenceGuid",
                value: "256490e8-f862-4806-a697-2f1f766a45c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 148,
                column: "LifePreferenceGuid",
                value: "e3e70cd3-ff81-4583-8602-5250c328fe40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 149,
                column: "LifePreferenceGuid",
                value: "e8676bb1-4f49-4a77-a0d6-35a4a4aaf6b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 150,
                column: "LifePreferenceGuid",
                value: "79cfca3b-9bfc-4f46-843b-ab90cf33a74e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 151,
                column: "LifePreferenceGuid",
                value: "40008d50-4a1c-4248-b1b1-3bf1cb716242");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 152,
                column: "LifePreferenceGuid",
                value: "04487b63-9971-4c93-9635-ea61e72f030e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 153,
                column: "LifePreferenceGuid",
                value: "2abacd96-abfc-4aa2-bcfc-3283896f2648");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 154,
                column: "LifePreferenceGuid",
                value: "b8dd1290-5c14-4273-98ac-1afaf193f9c6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 155,
                column: "LifePreferenceGuid",
                value: "2eec13c0-84f3-41e7-93ee-1f654887d724");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 156,
                column: "LifePreferenceGuid",
                value: "bb6a30ac-909d-4ee7-9b1d-56405fc4a818");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 157,
                column: "LifePreferenceGuid",
                value: "40ff83ce-43fa-4ef3-9e9c-09584234ce3a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 158,
                column: "LifePreferenceGuid",
                value: "53edf74c-12d9-4cee-911c-0bcd66acac56");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 159,
                column: "LifePreferenceGuid",
                value: "c7450670-5f19-48ac-8f14-a345a4538bb3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 160,
                column: "LifePreferenceGuid",
                value: "55113070-1d03-4660-ba2a-208e3f6da165");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 161,
                column: "LifePreferenceGuid",
                value: "69cb8b50-6c4c-4f3c-a608-c35ec72f7be3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 162,
                column: "LifePreferenceGuid",
                value: "636716ad-ccef-487e-ba2c-e947dac269c4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 163,
                column: "LifePreferenceGuid",
                value: "3a9f6309-c331-4bc8-9811-e9ef0712bddd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 164,
                column: "LifePreferenceGuid",
                value: "8d8cc90a-7deb-4223-8808-4e65248ff61b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 165,
                column: "LifePreferenceGuid",
                value: "41ad0494-8f76-4c96-ba91-35a9c15437c9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 166,
                column: "LifePreferenceGuid",
                value: "77dbf598-db7b-48f7-b6ef-2cf8cde6f842");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 167,
                column: "LifePreferenceGuid",
                value: "eb275829-8e9e-47b2-90af-14376ae34ebc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 168,
                column: "LifePreferenceGuid",
                value: "e0549bfc-8474-46b5-a408-2c11a569d02c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 169,
                column: "LifePreferenceGuid",
                value: "662efb5e-d2d7-4c63-bfe7-bae73cefe7ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 170,
                column: "LifePreferenceGuid",
                value: "da30f3e9-23e5-4d45-a2a4-18d007ee0914");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 171,
                column: "LifePreferenceGuid",
                value: "6ecad094-41dc-4ebf-9b10-ed29b46027e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 172,
                column: "LifePreferenceGuid",
                value: "d456255a-4ddc-41b3-a570-92d4d356e4f6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 173,
                column: "LifePreferenceGuid",
                value: "df6192ed-c776-4e12-a5f7-c7dba5d074d1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 174,
                column: "LifePreferenceGuid",
                value: "e4ad9117-c829-4e9b-888b-466a4222ed7f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 175,
                column: "LifePreferenceGuid",
                value: "7c0f2efb-7f25-4f25-ad26-86d59874bab5");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 176,
                column: "LifePreferenceGuid",
                value: "1951ffce-43e4-4141-9d2f-68a7e691ecea");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 177,
                column: "LifePreferenceGuid",
                value: "f434207b-b892-49c3-8b02-c6453b404f2e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 178,
                column: "LifePreferenceGuid",
                value: "6798b29a-492e-4bf3-acea-67b357abcf1f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 179,
                column: "LifePreferenceGuid",
                value: "c2cf1bb9-a97a-4747-866a-3670e9905d19");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 180,
                column: "LifePreferenceGuid",
                value: "0003f1f8-9e71-4f08-8c98-eb62b59e7f32");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 181,
                column: "LifePreferenceGuid",
                value: "2131ff31-ba9d-4416-8cc5-ba21960cbbdb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 182,
                column: "LifePreferenceGuid",
                value: "2895a038-36e9-4cce-b49e-0cc9eeaac1a8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 183,
                column: "LifePreferenceGuid",
                value: "4b15637a-4272-4043-a5f9-f548fa5871ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 184,
                column: "LifePreferenceGuid",
                value: "1b975113-5c15-41e1-a34b-bdfee42ecb06");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 185,
                column: "LifePreferenceGuid",
                value: "481a0210-344a-4d1a-a49b-081418fc518f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 186,
                column: "LifePreferenceGuid",
                value: "8e4e8f20-4cca-44e2-a58a-bb04af420051");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 187,
                column: "LifePreferenceGuid",
                value: "18a01a67-ee25-4fa6-8cf2-0427fd414856");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 188,
                column: "LifePreferenceGuid",
                value: "a3e93ba5-7d79-4621-9638-6aba834a9fb9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 189,
                column: "LifePreferenceGuid",
                value: "44d137fd-53de-44fa-a000-b121963fc28b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 190,
                column: "LifePreferenceGuid",
                value: "f59329cd-c8ad-4f00-94bc-2766f00321b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 191,
                column: "LifePreferenceGuid",
                value: "33f474e7-0fe8-4800-b721-ccd6c514648f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 192,
                column: "LifePreferenceGuid",
                value: "e67a4e31-0ed7-46d9-b91b-7315e2015de3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 193,
                column: "LifePreferenceGuid",
                value: "9b391d15-bb55-46ae-83b0-a57a7d54ef3b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 194,
                column: "LifePreferenceGuid",
                value: "763dcbc9-ac5b-480c-9975-cb08d052a94f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 195,
                column: "LifePreferenceGuid",
                value: "ea4cc47a-83d7-4d0e-929d-31761d908b12");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 196,
                column: "LifePreferenceGuid",
                value: "bdab0d52-1ef7-45c9-bf2f-a10d093bdca6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 197,
                column: "LifePreferenceGuid",
                value: "c2ad5a5b-93f4-486a-8c67-d75c4f7bdb58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 198,
                column: "LifePreferenceGuid",
                value: "d37b7e61-a28e-4f7e-b69e-0a0116bbd8e1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 199,
                column: "LifePreferenceGuid",
                value: "3270354d-2296-4501-9032-9867ba8af5c1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 200,
                column: "LifePreferenceGuid",
                value: "86d38a9f-93e1-489c-be89-d8a3b34732f4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 201,
                column: "LifePreferenceGuid",
                value: "494abac7-c719-448c-8f20-3f1e60ecd399");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 202,
                column: "LifePreferenceGuid",
                value: "bc8be593-67ac-44f6-86ce-aece8a1c1559");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 203,
                column: "LifePreferenceGuid",
                value: "396133f7-838e-4cde-935a-17694c1f37dd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 204,
                column: "LifePreferenceGuid",
                value: "76948899-eac9-47b1-aac9-4c7167fe4091");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 205,
                column: "LifePreferenceGuid",
                value: "405e78ba-ee74-4be7-9004-265580750434");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 206,
                column: "LifePreferenceGuid",
                value: "770b9ecd-6f11-48d8-a81b-fe57869f069b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 207,
                column: "LifePreferenceGuid",
                value: "283db773-b98d-4da2-a8c1-173eb2d3d9b7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 208,
                column: "LifePreferenceGuid",
                value: "7aa61bf6-4e0a-4baa-b77b-36c90da64465");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 209,
                column: "LifePreferenceGuid",
                value: "f45c32c6-0f1e-4caf-90ce-f129bf40cfaa");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 210,
                column: "LifePreferenceGuid",
                value: "56ae41df-81b9-4664-92c8-1dc1605073a7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 211,
                column: "LifePreferenceGuid",
                value: "49210873-50c6-412c-90a2-322d599d0295");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 212,
                column: "LifePreferenceGuid",
                value: "13f44867-3282-4816-8522-efb2f5dec8ae");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 213,
                column: "LifePreferenceGuid",
                value: "016aa75c-8332-4b04-a7eb-40b6c3013d1c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 214,
                column: "LifePreferenceGuid",
                value: "2316647a-eee6-4b99-a9fa-f32e1ddc2ed6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 215,
                column: "LifePreferenceGuid",
                value: "f5756bb2-7e8b-4166-9247-a9826348f8a4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 216,
                column: "LifePreferenceGuid",
                value: "8d05e63a-a0da-42ad-a69d-0064451110a2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 217,
                column: "LifePreferenceGuid",
                value: "63b56e07-31cc-44eb-b5bb-4a7cea7f71af");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 218,
                column: "LifePreferenceGuid",
                value: "abf915e9-98ec-4990-a39a-4146bad934ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 219,
                column: "LifePreferenceGuid",
                value: "72178424-17d9-4ae3-a7da-2c61b81c3ce9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 220,
                column: "LifePreferenceGuid",
                value: "561b5550-03c8-4dfe-bf6b-9af59a654801");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 221,
                column: "LifePreferenceGuid",
                value: "f9fa6b11-8aa5-4230-a40e-186a19810ee1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 222,
                column: "LifePreferenceGuid",
                value: "7d54b825-b76d-4d6d-b298-8c73fa30e439");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 223,
                column: "LifePreferenceGuid",
                value: "ef19abec-471f-48cf-a28b-1b6ded6d0c9f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 224,
                column: "LifePreferenceGuid",
                value: "a7b4ed05-6f8e-4e7d-8d45-a6b7300d4178");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 225,
                column: "LifePreferenceGuid",
                value: "2c62721c-03e6-47d2-8a84-84aac6765b7c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 226,
                column: "LifePreferenceGuid",
                value: "1dac3e78-7c8f-498b-ba1b-748edf4467e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 227,
                column: "LifePreferenceGuid",
                value: "3de02367-964f-4274-acba-989861e8bc0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 228,
                column: "LifePreferenceGuid",
                value: "a1350078-f774-4797-ac3e-cd8e64d948d7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 229,
                column: "LifePreferenceGuid",
                value: "d376f4ee-a908-45dd-86c7-c7e8190cfe70");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 230,
                column: "LifePreferenceGuid",
                value: "b34c2bf4-12ff-4576-b5f3-92e7745bdfa3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 231,
                column: "LifePreferenceGuid",
                value: "2e6fa996-afca-4d71-a5dd-819a7e5819ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 232,
                column: "LifePreferenceGuid",
                value: "a3274cb3-7b2d-488d-9ca9-1ff8f57d8b63");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 233,
                column: "LifePreferenceGuid",
                value: "84073be2-301c-45c4-a048-3c016abd2ee0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 234,
                column: "LifePreferenceGuid",
                value: "2863c7b4-d371-4bd6-bdf9-e2fce9e6c3ec");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 235,
                column: "LifePreferenceGuid",
                value: "ba95a93e-4446-46b9-9b62-c35c760a891f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 236,
                column: "LifePreferenceGuid",
                value: "be2d4da1-1cd1-4904-a980-26fc51c535f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 237,
                column: "LifePreferenceGuid",
                value: "5f194ee8-7068-4b48-a665-cc4022a573f8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 238,
                column: "LifePreferenceGuid",
                value: "eb5ffec9-dbd5-4f71-a6c2-7da21071fbba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 239,
                column: "LifePreferenceGuid",
                value: "ab3ede92-55fe-457b-a272-fac2d346d551");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 240,
                column: "LifePreferenceGuid",
                value: "fc1ace56-48d4-4d8d-b124-18f7dd1d6e75");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 241,
                column: "LifePreferenceGuid",
                value: "63f9b632-aae4-43e5-ba16-b9ddb9eea450");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 242,
                column: "LifePreferenceGuid",
                value: "1a216eb9-f1c2-4cc8-abb4-42a6fd2ea1f2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 243,
                column: "LifePreferenceGuid",
                value: "682b8ef9-832e-47a6-8fa0-5774e971120c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 244,
                column: "LifePreferenceGuid",
                value: "fd8e7726-a13c-4e06-8134-aab3ea9cd9b6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 245,
                column: "LifePreferenceGuid",
                value: "584bd79d-807c-4407-97a9-abdcabcd00bd");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 246,
                column: "LifePreferenceGuid",
                value: "1b00ac25-cc38-43c0-b1e6-feecd04c09e3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 247,
                column: "LifePreferenceGuid",
                value: "425c8c80-ab3b-4389-b88a-bf4456aec47e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 248,
                column: "LifePreferenceGuid",
                value: "775cfef1-758a-4830-b1df-7947a467cbe4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 249,
                column: "LifePreferenceGuid",
                value: "f48043b3-37b5-415f-b789-c43ade4796ee");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 250,
                column: "LifePreferenceGuid",
                value: "7b79ed38-2526-4ff2-8455-2bb2c751b93f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 251,
                column: "LifePreferenceGuid",
                value: "ffee9ab5-320d-4a8d-9dd1-b474587a6ae8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 252,
                column: "LifePreferenceGuid",
                value: "a6fa5813-24b4-43b1-8daa-b461a8f3f845");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 253,
                column: "LifePreferenceGuid",
                value: "bab8c2b6-be37-41d9-907c-45163a5b5162");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 254,
                column: "LifePreferenceGuid",
                value: "8388e11c-389c-427b-ae5c-e75bc0336aba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 255,
                column: "LifePreferenceGuid",
                value: "bb2dfe79-26d1-4508-981e-586cedd963fc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 256,
                column: "LifePreferenceGuid",
                value: "c5e3a815-bf0f-421d-8f14-16a2ca408161");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 257,
                column: "LifePreferenceGuid",
                value: "059362a3-ce52-44f5-ba27-db563a17061c");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 258,
                column: "LifePreferenceGuid",
                value: "3d57910c-a7e3-4303-9370-c12cf807e0f1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 259,
                column: "LifePreferenceGuid",
                value: "43853f13-2437-4e90-af77-424824d94ace");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 260,
                column: "LifePreferenceGuid",
                value: "ea48a766-f796-4cfd-a3fc-07d620cc53ef");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 261,
                column: "LifePreferenceGuid",
                value: "8b881e9c-feda-492c-ad35-3df2db7bd91a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 262,
                column: "LifePreferenceGuid",
                value: "64c1ba57-7c21-4918-88bc-458cb857aeed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 263,
                column: "LifePreferenceGuid",
                value: "bea0fc83-3de2-4765-9888-b8ccb31f762b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 264,
                column: "LifePreferenceGuid",
                value: "d7d13bf5-9c9c-429c-880c-f40e1c71598d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 265,
                column: "LifePreferenceGuid",
                value: "c104a94e-2ac3-49fe-b184-5f8224663201");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 266,
                column: "LifePreferenceGuid",
                value: "683b58e7-5e03-4dd3-95f1-59790b6307e2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 267,
                column: "LifePreferenceGuid",
                value: "f844ebfd-2122-4f89-8ce5-ab080afa4420");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 268,
                column: "LifePreferenceGuid",
                value: "d08a6c7a-59f9-4ceb-9827-af111650fd0a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 269,
                column: "LifePreferenceGuid",
                value: "1f320473-17a3-44e9-bb91-1832073b43d4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 270,
                column: "LifePreferenceGuid",
                value: "17840b7e-8e2b-41d8-9b0d-2142a2eef3ba");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 271,
                column: "LifePreferenceGuid",
                value: "74f11a0a-6372-4eb9-a888-3f72880ef4be");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 272,
                column: "LifePreferenceGuid",
                value: "2ce6e2c3-dd51-43da-abc7-3014e1d0e3d9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 273,
                column: "LifePreferenceGuid",
                value: "0ec95115-c563-4c81-a9e6-5855ab5ad429");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 274,
                column: "LifePreferenceGuid",
                value: "44dfbf16-e58a-4aeb-ba39-0418a24d73c7");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 275,
                column: "LifePreferenceGuid",
                value: "c79be5b4-20bb-44bb-b104-ba00ea3bb1e8");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 276,
                column: "LifePreferenceGuid",
                value: "59f9c9f3-df7d-4729-8bb0-8e29ca8477e4");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 277,
                column: "LifePreferenceGuid",
                value: "4f195253-5261-4668-8c1c-f48feca6c8a0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 278,
                column: "LifePreferenceGuid",
                value: "190339aa-fc77-4d15-932a-18696fc8eb58");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 279,
                column: "LifePreferenceGuid",
                value: "d2bfb524-4a28-478c-b343-55809b8c5c40");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 280,
                column: "LifePreferenceGuid",
                value: "f7dd6f93-4878-406a-a846-d73354f7083b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 281,
                column: "LifePreferenceGuid",
                value: "7d7ee018-f14d-48d5-b699-385b3fc6635f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 282,
                column: "LifePreferenceGuid",
                value: "fb9486b3-a2c3-4bd8-9058-3b0fdde4c9c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 283,
                column: "LifePreferenceGuid",
                value: "f73742aa-41f0-45a5-9a1e-093489150fa9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 284,
                column: "LifePreferenceGuid",
                value: "870c4467-608d-45c0-af5a-9d7906440045");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 285,
                column: "LifePreferenceGuid",
                value: "aaca4642-5b18-489e-82d7-84302c4835fe");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 286,
                column: "LifePreferenceGuid",
                value: "2f61b023-a6ca-464e-ab43-3095d0445201");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 287,
                column: "LifePreferenceGuid",
                value: "e6a71304-3c3b-48b0-8d7c-54f6a8a4f5f3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 288,
                column: "LifePreferenceGuid",
                value: "d6d68655-bf63-48cb-bf85-0a3d64298dd0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 289,
                column: "LifePreferenceGuid",
                value: "61457278-b31f-415e-bc2f-b163ab055506");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 290,
                column: "LifePreferenceGuid",
                value: "9604ab34-af6b-49db-8de5-1e052338b454");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 291,
                column: "LifePreferenceGuid",
                value: "4b848740-9299-4453-ba32-2d83350cedc6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 292,
                column: "LifePreferenceGuid",
                value: "0175bccd-2e52-4bf6-bea3-aa955051304f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 293,
                column: "LifePreferenceGuid",
                value: "332034e5-0e93-4ecd-a07f-7c00adf1f2ed");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 294,
                column: "LifePreferenceGuid",
                value: "a1fca556-5e48-4403-b641-3f26a4584238");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 295,
                column: "LifePreferenceGuid",
                value: "a4a767d2-627a-4844-9f6d-b2ee3a4ca6a9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 296,
                column: "LifePreferenceGuid",
                value: "763a063f-1411-46cf-9c1b-889f0b4ca5bc");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 297,
                column: "LifePreferenceGuid",
                value: "310ade6e-b442-407f-841c-5cbdde0a5e77");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 298,
                column: "LifePreferenceGuid",
                value: "a9d01f45-a5df-4634-878c-9eadd7b9ddd6");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 299,
                column: "LifePreferenceGuid",
                value: "f6fef4b8-ebaf-4972-8fe7-e244b684a57b");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 300,
                column: "LifePreferenceGuid",
                value: "98cb8d7c-8164-441a-8da9-4dca1009b0c2");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 301,
                column: "LifePreferenceGuid",
                value: "9a1d483c-960f-4c09-b57d-5b26e3d13daf");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 302,
                column: "LifePreferenceGuid",
                value: "0b192c8b-7418-4dd1-ad88-9673b207ea94");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 303,
                column: "LifePreferenceGuid",
                value: "9225d58c-bec8-4148-ba1c-95a1826ab98f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 304,
                column: "LifePreferenceGuid",
                value: "ae03c629-b82a-4a5f-b2eb-6a5be30e67c0");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 305,
                column: "LifePreferenceGuid",
                value: "5ef40b04-4174-4344-ae65-191aa9c55b82");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 306,
                column: "LifePreferenceGuid",
                value: "25647e27-0113-4ff8-9562-563f78b858b3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 307,
                column: "LifePreferenceGuid",
                value: "7ec1cce5-dbbb-4056-8493-fab29a4ad6a1");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 308,
                column: "LifePreferenceGuid",
                value: "44715a2e-05a9-4561-9997-e3f5b1f3f559");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 309,
                column: "LifePreferenceGuid",
                value: "780eadc1-7117-45ad-ab2d-859e3d9dfc3e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 310,
                column: "LifePreferenceGuid",
                value: "8887ba51-fb42-48f5-8386-0c6bc6aca042");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 311,
                column: "LifePreferenceGuid",
                value: "b94ed419-c0af-467f-a7eb-6b143380fef3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 312,
                column: "LifePreferenceGuid",
                value: "1a80afe0-c14e-47ce-ae81-310e3f988479");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 313,
                column: "LifePreferenceGuid",
                value: "a9b46355-f058-428b-98d8-ae1bd059df03");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 314,
                column: "LifePreferenceGuid",
                value: "46e4f835-1a6f-4a11-a5be-de638ad45c5d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 315,
                column: "LifePreferenceGuid",
                value: "35517e3d-53a7-4190-8cfb-bee35be95abb");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 316,
                column: "LifePreferenceGuid",
                value: "93fd63e3-7612-4046-b439-8e82f6940c5f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 317,
                column: "LifePreferenceGuid",
                value: "a73aec69-9984-4682-9db5-b19e754231e9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 318,
                column: "LifePreferenceGuid",
                value: "4ba4337d-cff1-4475-8786-d336ab53d28f");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 319,
                column: "LifePreferenceGuid",
                value: "ef9a1858-e53e-4e2f-b317-d2f11100e68d");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 320,
                column: "LifePreferenceGuid",
                value: "4ec052b8-6ad2-40f8-bbde-21eb5e496c68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 321,
                column: "LifePreferenceGuid",
                value: "0c49a72c-e78e-4549-a31d-dd79eee53a6a");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 322,
                column: "LifePreferenceGuid",
                value: "b43b0af0-8d4a-43e0-89cb-bde3a3ffdc54");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 323,
                column: "LifePreferenceGuid",
                value: "ebb613ee-725c-4f9f-ac67-ddbf4b7f87a3");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 324,
                column: "LifePreferenceGuid",
                value: "286dd12c-4750-40db-ad71-74db6b4ce696");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 325,
                column: "LifePreferenceGuid",
                value: "dd9d2798-3494-4e32-8d2b-1763bdbbee68");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 326,
                column: "LifePreferenceGuid",
                value: "845a5844-a178-4716-8c4d-0ee055c05860");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 327,
                column: "LifePreferenceGuid",
                value: "763292bc-213b-43e9-822b-6c1649c321f9");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 328,
                column: "LifePreferenceGuid",
                value: "a8925e50-6a95-4598-9908-0c5338234366");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 329,
                column: "LifePreferenceGuid",
                value: "c96cf213-4821-4144-a500-6218910bfa8e");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 330,
                column: "LifePreferenceGuid",
                value: "3759b292-93e0-4d19-9124-d11fc7cb3405");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 331,
                column: "LifePreferenceGuid",
                value: "53506f60-24f4-4954-aaf9-8990d4630416");

            migrationBuilder.UpdateData(
                table: "LifePreference",
                keyColumn: "LifePreferenceId",
                keyValue: 332,
                column: "LifePreferenceGuid",
                value: "8146d0cd-0be9-4297-9050-058cfb5ff1ef");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1,
                column: "MaritalStatusGuid",
                value: "9242394c-b055-4b06-89e6-d038f30af6c0");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2,
                column: "MaritalStatusGuid",
                value: "beff4420-1ba5-4ebc-81da-e95462e8f00a");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3,
                column: "MaritalStatusGuid",
                value: "aab10230-89ad-46b2-8e9c-abe785b6ecbf");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 4,
                column: "MaritalStatusGuid",
                value: "ab16fd16-9dd3-4f0c-93cc-db840b5c3fcd");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 5,
                column: "MaritalStatusGuid",
                value: "990a730d-9f39-437c-82b6-c3f5953420a6");

            migrationBuilder.UpdateData(
                table: "MaritalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 6,
                column: "MaritalStatusGuid",
                value: "9f49c579-a327-4a6b-bd70-21a2b15f4739");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "RelationTypeGuid",
                value: "427913a4-cbea-4aa9-ac22-769da62f3f55");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "RelationTypeGuid",
                value: "21a71339-36e3-4320-8a39-1797ff30b6b9");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "RelationTypeGuid",
                value: "1690344a-9238-4a81-aa53-90e2a609d1c6");

            migrationBuilder.UpdateData(
                table: "RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 4,
                column: "RelationTypeGuid",
                value: "bf93031b-a19e-4e66-874d-6778b1432d6f");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 1,
                column: "StudyAreaGuid",
                value: "d5e25ca2-4715-473a-847a-58434ad24480");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 2,
                column: "StudyAreaGuid",
                value: "a623da88-161c-421c-abe7-6c8041eeddbe");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 3,
                column: "StudyAreaGuid",
                value: "a65499c3-5f17-41ca-9b01-035b6b4e153b");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 4,
                column: "StudyAreaGuid",
                value: "a5e8c34a-e4a8-4955-bc09-6481b8635af4");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 5,
                column: "StudyAreaGuid",
                value: "ee09a7a0-c4de-4dc2-9e0c-46e1c4a55a06");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 6,
                column: "StudyAreaGuid",
                value: "9ac65956-b321-4453-a592-462c77a6cf71");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 7,
                column: "StudyAreaGuid",
                value: "13e24ed7-3104-4aaa-be1f-56b0f9ba2a97");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 8,
                column: "StudyAreaGuid",
                value: "ac9d2c34-970a-4d55-9d45-6a3a6dbc19a5");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 9,
                column: "StudyAreaGuid",
                value: "24592c13-ad3b-4e14-847d-d89602f01ab1");

            migrationBuilder.UpdateData(
                table: "StudyArea",
                keyColumn: "StudyAreaId",
                keyValue: 10,
                column: "StudyAreaGuid",
                value: "c8b0b0a0-58e5-4228-862f-5338a990ecce");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 1,
                column: "StudyTypeGuid",
                value: "f7e90f3e-3451-4f2c-855b-330394b63fc8");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 2,
                column: "StudyTypeGuid",
                value: "18698f64-7d5d-4a23-8c8d-059c88d8e9b3");

            migrationBuilder.UpdateData(
                table: "StudyTypeId",
                keyColumn: "StudyTypeId",
                keyValue: 3,
                column: "StudyTypeGuid",
                value: "ae89c8d0-585d-4d97-bfb1-0b1992efb60a");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 1,
                column: "TimeAvailabilityGuid",
                value: "08d2dc05-657f-428e-8c3c-b715f5b66a88");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 2,
                column: "TimeAvailabilityGuid",
                value: "7a8db924-c6ca-441e-a12e-7f8a390fe7d1");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 3,
                column: "TimeAvailabilityGuid",
                value: "68b9364c-df6e-41f4-a292-d9512dd22d20");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 4,
                column: "TimeAvailabilityGuid",
                value: "c5415103-8f26-4ca7-af37-94158508326b");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 5,
                column: "TimeAvailabilityGuid",
                value: "be534321-46cb-4d8a-8183-04313a80fdfa");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 6,
                column: "TimeAvailabilityGuid",
                value: "d2eff5e1-1d0e-452c-be14-3ddea49eb1e6");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 7,
                column: "TimeAvailabilityGuid",
                value: "a62a5aa9-507e-4ec0-8707-d73edc30b96c");

            migrationBuilder.UpdateData(
                table: "TimeAvailability",
                keyColumn: "TimeAvailabilityId",
                keyValue: 8,
                column: "TimeAvailabilityGuid",
                value: "25d810ac-ff98-4dbf-8337-24e583849b4a");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 1,
                column: "TitleGuid",
                value: "804d8b75-08a0-4ec3-ae60-ae9b2fcb7988");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 2,
                column: "TitleGuid",
                value: "c59be096-2b83-4094-b3bb-cefa8acde3d1");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 3,
                column: "TitleGuid",
                value: "a8e34c16-3dee-466c-a6a8-9f2a1c1e4110");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 4,
                column: "TitleGuid",
                value: "3ab3514c-1357-47a6-b29b-41888bb8ddc2");

            migrationBuilder.UpdateData(
                table: "Title",
                keyColumn: "TitleId",
                keyValue: 5,
                column: "TitleGuid",
                value: "c9b130eb-94b3-4934-bf42-7af985929b6d");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 1,
                column: "WellnessGuid",
                value: "a2d71957-d04e-40c5-b18a-82a2901c2070");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 2,
                column: "WellnessGuid",
                value: "aa2bd7b7-c0bb-4dc6-8611-27167926bfb1");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 3,
                column: "WellnessGuid",
                value: "ca58ce52-93ae-411d-80d8-7eb2e0c4fc84");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 4,
                column: "WellnessGuid",
                value: "18f52a44-e0e5-42df-887e-c8f7f51e0b3f");

            migrationBuilder.UpdateData(
                table: "Wellness",
                keyColumn: "WellnessId",
                keyValue: 5,
                column: "WellnessGuid",
                value: "21fd358b-dcb7-4b4e-9c70-6a48b7186441");
        }
    }
}
