// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;

namespace ParusRx.Astral.Domain.Poa;

public record PoaCreateUnifiedRequest
{
    [XmlElement("ДатаНачалаДействия")]
    [JsonPropertyName("ДатаНачалаДействия")]
    public required string EffectiveDate { get; init; }

    [XmlElement("ДатаОкончанияДействия")]
    [JsonPropertyName("ДатаОкончанияДействия")]
    public required string ExpirationDate { get; init; }

    [XmlElement("ВозможностьПередоверия")]
    [JsonPropertyName("ВозможностьПередоверия")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<DelegationPossibility>))]
    public required DelegationPossibility DelegationPossibility { get; init; }

    [XmlElement("КодНОРегистрацииМЧД")]
    [JsonPropertyName("КодНОРегистрацииМЧД")]
    public string? TaxAuthorityCode { get; init; }

    [XmlArray("КодыНОДействияМЧД")]
    [XmlArrayItem("КодНОДействияМЧД")]
    [JsonPropertyName("КодыНОДействияМЧД")]
    public string[]? TaxAuthorityCodes { get; init; }

    [XmlElement("ИдПользователяЕСИА")]
    [JsonPropertyName("ИдПользователяЕСИА")]
    public string? EsiaUserId { get; init; }

    [XmlElement("ВнутреннийНомерМЧД")]
    [JsonPropertyName("ВнутреннийНомерМЧД")]
    public required string InternalNumber { get; init; }

    [XmlElement("ДатаВнутреннейРегистрации")]
    [JsonPropertyName("ДатаВнутреннейРегистрации")]
    public string? InternalRegistrationDate { get; init; }

    [XmlArray("СведенияОДоверителях")]
    [XmlArrayItem("СведенияОДоверителе")]
    [JsonPropertyName("СведенияОДоверителях")]
    public Principal[]? Principals { get; init; }

    [XmlArray("СведенияОПредставителях")]
    [XmlArrayItem("СведенияОПредставителе")]
    [JsonPropertyName("СведенияОПредставителях")]
    public AuthorizedRepresentative[]? AuthorizedRepresentatives { get; init; }

    [XmlElement("Полномочия")]
    [JsonPropertyName("Полномочия")]
    public required Authority Authority { get; init; }
}

public enum DelegationPossibility
{
    [XmlEnum("БезПередоверия")]
    [EnumMember(Value = "БезПередоверия")]
    WithoutDelegation,

    [XmlEnum("Однократная")]
    [EnumMember(Value = "Однократная")]
    OneTime,

    [XmlEnum("Многократная")]
    [EnumMember(Value = "Многократная")]
    Multiple
}

public record Principal 
{
    [XmlElement("Тип")]
    [JsonPropertyName("Тип")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<PrincipalType>))]
    public required PrincipalType Type { get; init; }

    [XmlElement("Наименование")]
    [JsonPropertyName("Наименование")]
    public required string Name { get; init; }

    [XmlElement("ИНН")]
    [JsonPropertyName("ИНН")]
    public string? Inn { get; init; }

    [XmlElement("ОГРН")]
    [JsonPropertyName("ОГРН")]
    public string? Ogrn { get; init; }

    [XmlElement("КПП")]
    [JsonPropertyName("КПП")]
    public string? Kpp { get; init; }

    [XmlElement("КодСтраныРегистрации")]
    [JsonPropertyName("КодСтраныРегистрации")]
    public string? RegistrationCountryCode { get; init; }

    [XmlElement("РегистрационныйНомер")]
    [JsonPropertyName("РегистрационныйНомер")]
    public string? RegistrationNumber { get; init; }

    [XmlElement("НомерЗаписиОбАккредитации")]
    [JsonPropertyName("НомерЗаписиОбАккредитации")]
    public string? AccreditationRecordNumber { get; init; }

    [XmlElement("АдресЮридический")]
    [JsonPropertyName("АдресЮридический")]
    public Address? LegalAddress { get; init; }

    [XmlArray("СведенияОЛицахДействующихОтИмениЮЛ")]
    [XmlArrayItem("СведенияОЛицеДействующемОтИмениЮЛ")]
    [JsonPropertyName("СведенияОЛицахДействующихОтИмениЮЛ")]
    public LegalEntityRepresentative[]? LegalEntityRepresentatives { get; init; }
}

public enum PrincipalType
{
    [XmlEnum("ЮЛ")]
    [EnumMember(Value = "ЮЛ")]
    LegalEntity,

    [XmlEnum("ИО")]
    [EnumMember(Value = "ИО")]
    ForeignOrganization,

    [XmlEnum("ИП")]
    [EnumMember(Value = "ИП")]
    IndividualEntrepreneur,

    [XmlEnum("ФЛ")]
    [EnumMember(Value = "ФЛ")]
    Individual

}

public record Address
{
    [XmlElement("КодРегиона")]
    [JsonPropertyName("КодРегиона")]
    public string? RegionCode { get; init; }

    [XmlElement("КодАдресаПоФИАС")]
    [JsonPropertyName("КодАдресаПоФИАС")]
    public string? FiasAddressCode { get; init; }

    [XmlElement("Индекс")]
    [JsonPropertyName("Индекс")]
    public string? ZipCode { get; init; }

    [XmlElement("Район")]
    [JsonPropertyName("Район")]
    public string? District { get; init; }

    [XmlElement("Город")]
    [JsonPropertyName("Город")]
    public string? City { get; init; }

    [XmlElement("НасПункт")]
    [JsonPropertyName("НасПункт")]
    public string? Settlement { get; init; }

    [XmlElement("Улица")]
    [JsonPropertyName("Улица")]
    public string? Street { get; init; }

    [XmlElement("Дом")]
    [JsonPropertyName("Дом")]
    public string? House { get; init; }

    [XmlElement("Корпус")]
    [JsonPropertyName("Корпус")]
    public string? Building { get; init; }

    [XmlElement("Квартира")]
    [JsonPropertyName("Квартира")]
    public string? Apartment { get; init; }
}

public record LegalEntityRepresentative
{
    [XmlElement("Тип")]
    [JsonPropertyName("Тип")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<LegalEntityRepresentativeType>))]
    public required LegalEntityRepresentativeType Type { get; init; }

    [XmlElement("Наименование")]
    [JsonPropertyName("Наименование")]
    public string? Name { get; init; }

    [XmlElement("ИНН")]
    [JsonPropertyName("ИНН")]
    public string? Inn { get; init; }

    [XmlElement("ОГРН")]
    [JsonPropertyName("ОГРН")]
    public string? Ogrn { get; init; }

    [XmlElement("КПП")]
    [JsonPropertyName("КПП")]
    public string? Kpp { get; init; }

    [XmlElement("АдресЮридический")]
    [JsonPropertyName("АдресЮридический")]
    public Address? LegalAddress { get; init; }

    [XmlArray("ПерсональныеДанныеФЛ")]
    [XmlArrayItem("ПерсональныеДанныеФЛ")]
    [JsonPropertyName("ПерсональныеДанныеФЛ")]
    public PersonalData[]? PersonalData { get; init; }
}

public enum LegalEntityRepresentativeType
{
    [XmlEnum("УО")]
    [EnumMember(Value = "УО")]
    GoverningBody,

    [XmlEnum("ИП")]
    [EnumMember(Value = "ИП")]
    IndividualEntrepreneur,

    [XmlEnum("ФЛ")]
    [EnumMember(Value = "ФЛ")]
    Individual
}

public record PersonalData
{
    [XmlElement("ФИО")]
    [JsonPropertyName("ФИО")]
    public required FullName FullName { get; init; }

    [XmlElement("Пол")]
    [JsonPropertyName("Пол")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<Gender>))]
    public Gender? Gender { get; init; }

    [XmlElement("ИННФЛ")]
    [JsonPropertyName("ИННФЛ")]
    public required string Inn { get; init; }

    [XmlElement("СНИЛС")]
    [JsonPropertyName("СНИЛС")]
    public required string Snils { get; init; }

    [XmlElement("ДатаРождения")]
    [JsonPropertyName("ДатаРождения")]
    public string? BirthDate { get; init; }

    [XmlElement("МестоРождения")]
    [JsonPropertyName("МестоРождения")]
    public string? BirthPlace { get; init; }

    [XmlElement("Гражданство")]
    [JsonPropertyName("Гражданство")]
    public string? Citizenship { get; init; }

    [XmlElement("КодСтраныГражданства")]
    [JsonPropertyName("КодСтраныГражданства")]
    public required string CitizenshipCode { get; init; }

    [XmlElement("ДокументУдостоверяющийЛичность")]
    [JsonPropertyName("ДокументУдостоверяющийЛичность")]
    public IdentityDocument? IdentityDocument { get; init; }

    [XmlElement("Адрес")]
    [JsonPropertyName("Адрес")]
    public Address? Address { get; init; }

    [XmlElement("Должность")]
    [JsonPropertyName("Должность")]
    public string? Position { get; init; }
}

public record FullName
{
    [XmlElement("Фамилия")]
    [JsonPropertyName("Фамилия")]
    public required string LastName { get; init; }

    [XmlElement("Имя")]
    [JsonPropertyName("Имя")]
    public required string FirstName { get; init; }

    [XmlElement("Отчество")]
    [JsonPropertyName("Отчество")]
    public string? MiddleName { get; init; }
}

public enum Gender
{
    [XmlEnum("М")]
    [EnumMember(Value = "М")]
    Male,

    [XmlEnum("Ж")]
    [EnumMember(Value = "Ж")]
    Female
}

public record IdentityDocument
{

    [XmlElement("Тип")]
    [JsonPropertyName("Тип")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<IdentityDocumentType>))]
    public required IdentityDocumentType Type { get; init; }

    [XmlElement("СерияНомер")]
    [JsonPropertyName("СерияНомер")]
    public required string SerialNumber { get; init; }

    [XmlElement("ДатаВыдачи")]
    [JsonPropertyName("ДатаВыдачи")]
    public required string IssueDate { get; init; }

    [XmlElement("ДатаОкончанияДействия")]
    [JsonPropertyName("ДатаОкончанияДействия")]
    public string? ExpirationDate { get; init; }

    [XmlElement("КемВыдан")]
    [JsonPropertyName("КемВыдан")]
    public required string IssuedBy { get; init; }

    [XmlElement("КодПодразделения")]
    [JsonPropertyName("КодПодразделения")]
    public required string DivisionCode { get; init; }
}

public enum IdentityDocumentType
{
    [XmlEnum("ПаспортРФ")]
    [EnumMember(Value = "ПаспортРФ")]
    RussianPassport,

    [XmlEnum("ПаспортИностранногоГражданина")]
    [EnumMember(Value = "ПаспортИностранногоГражданина")]
    ForeignPassport,

    [XmlEnum("СвидетельствоОРассмотренииХодатайстваОБеженстве")]
    [EnumMember(Value = "СвидетельствоОРассмотренииХодатайстваОБеженстве")]
    RefugeeStatusCertificate,

    [XmlEnum("ВидНаЖительствоРФ")]
    [EnumMember(Value = "ВидНаЖительствоРФ")]
    RussianResidencePermit,

    [XmlEnum("УдостстоверениеБеженца")]
    [EnumMember(Value = "УдостстоверениеБеженца")]
    RefugeeIdentityDocument,

    [XmlEnum("РазрешениеНаВременноеПроживаниеВРФ")]
    [EnumMember(Value = "РазрешениеНаВременноеПроживаниеВРФ")]
    TemporaryResidencePermit,

    [XmlEnum("СвидетельствоОПредоставленииВременногоУбежищаВРФ")]
    [EnumMember(Value = "СвидетельствоОПредоставленииВременногоУбежищаВРФ")]
    TemporaryAsylumCertificate,

    [XmlEnum("УдостоверениеЛичностиВоеннослужащегоРФ")]
    [EnumMember(Value = "УдостоверениеЛичностиВоеннослужащегоРФ")]
    RussianMilitaryIdentityCard,

    [XmlEnum("ВоенныйБилет")]
    [EnumMember(Value = "ВоенныйБилет")]
    MilitaryID,
}

public record AuthorizedRepresentative
{
    [XmlElement("Тип")]
    [JsonPropertyName("Тип")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter<AuthorizedRepresentativeType>))]
    public required AuthorizedRepresentativeType Type { get; init; }

    [XmlElement("Наименование")]
    [JsonPropertyName("Наименование")]
    public string? Name { get; init; }

    [XmlElement("ИНН")]
    [JsonPropertyName("ИНН")]
    public string? Inn { get; init; }

    [XmlElement("ОГРН")]
    [JsonPropertyName("ОГРН")]
    public string? Ogrn { get; init; }

    [XmlElement("КПП")]
    [JsonPropertyName("КПП")]
    public string? Kpp { get; init; }

    [XmlElement("КодСтраныРегистрации")]
    [JsonPropertyName("КодСтраныРегистрации")]
    public string? RegistrationCountryCode { get; init; }

    [XmlElement("РегистрационныйНомер")]
    [JsonPropertyName("РегистрационныйНомер")]
    public string? RegistrationNumber { get; init; }

    [XmlElement("НомерЗаписиОбАккредитации")]
    [JsonPropertyName("НомерЗаписиОбАккредитации")]
    public string? AccreditationRecordNumber { get; init; }

    [XmlElement("АдресЮридический")]
    [JsonPropertyName("АдресЮридический")]
    public Address? LegalAddress { get; init; }

    [XmlElement("ПерсональныеДанныеПредставителя")]
    [JsonPropertyName("ПерсональныеДанныеПредставителя")]
    public PersonalData? PersonalData { get; init; }
}

public enum AuthorizedRepresentativeType
{
    [XmlEnum("ЮЛ")]
    [EnumMember(Value = "ЮЛ")]
    LegalEntity,

    [XmlEnum("ИП")]
    [EnumMember(Value = "ИП")]
    IndividualEntrepreneur,

    [XmlEnum("ФЛ")]
    [EnumMember(Value = "ФЛ")]
    Individual,

    [XmlEnum("ФилиалЮЛ")]
    [EnumMember(Value = "ФилиалЮЛ")]
    LegalEntityBranch,

    [XmlEnum("ФилиалИО")]
    [EnumMember(Value = "ФилиалИО")]
    ForeignOrganizationBranch
}

public record Authority
{
    [XmlElement("СохранитьПриПередоверии")]
    [JsonPropertyName("СохранитьПриПередоверии")]
    public bool SaveOnDelegation { get; init; }

    [XmlElement("ЯвляютсяСовместными")]
    [JsonPropertyName("ЯвляютсяСовместными")]
    public bool AreJoint { get; init; }

    [XmlElement("ТекстовоеОписаниеПолномочий")]
    [JsonPropertyName("ТекстовоеОписаниеПолномочий")]
    public string? Description { get; init; }

    [XmlArray("СписокПолномочий")]
    [XmlArrayItem("Полномочие")]
    [JsonPropertyName("СписокПолномочий")]
    public AuthorityItem[]? Authorities { get; init; }
}

public record AuthorityItem
{
    [XmlElement("МнемоникаПолномочия")]
    [JsonPropertyName("МнемоникаПолномочия")]
    public required string Mnemonic { get; init; }

    [XmlElement("КодПолномочия")]
    [JsonPropertyName("КодПолномочия")]
    public required string Code { get; init; }

    [XmlElement("Наименование")]
    [JsonPropertyName("Наименование")]
    public required string Name { get; init; }

    [XmlArray("Ограничения")]
    [XmlArrayItem("Ограничение")]
    [JsonPropertyName("ограничения")]
    public Restriction[]? Restrictions { get; init; }
}

public record Restriction
{
    [XmlElement("КодОграничения")]
    [JsonPropertyName("КодОграничения")]
    public required string Code { get; init; }

    [XmlElement("НаименованиеОграничения")]
    [JsonPropertyName("НаименованиеОграничения")]
    public required string Name { get; init; }

    [XmlElement("НаименованиеЗначенияОграничения")]
    [JsonPropertyName("НаименованиеЗначенияОграничения")]
    public required string ValueName { get; init; }

    [XmlElement("ТекстовоеОписаниеОграничения")]
    [JsonPropertyName("ТекстовоеОписаниеОграничения")]
    public string? Description { get; init; }
}