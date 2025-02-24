export interface Welcome {
    success:    boolean;
    message:    string;
    totalCount: number;
    data:       Data[];
}

export interface Data {
    _id:string;
    phoneNumbers:any[];
    emails:any[];
    photo:string;
    summary:string;
    speciality:Speciality[];
    experience_years:number;
    institutionID_list: InstitutionIDList[];
    gender:Gender;
    languages: Language[];
    birthday: Date;
    otherDocuments:     any[];
    experience:         any[];
    fullName:           string;
    mainInstitution:    MainInstitution;
    education:          any[];
    availablity:        any[];
    __v:                number;
    fullName_fuzzy:     string[];
    source:             Source;
    score:              number;
}

export enum Gender {
    Male = "Male",
}

export interface InstitutionIDList {
    _id:             ID;
    institutionName: InstitutionIDListInstitutionName;
    lang:            InstitutionIDListLang;
}

export enum ID {
    The629F129C8373Fd1Bef2Db501 = "629f129c8373fd1bef2db501",
    The62B5A97Ddd58Ed2C34D361E0 = "62b5a97ddd58ed2c34d361e0",
}

export enum InstitutionIDListInstitutionName {
    AddisCardiacHospital = "Addis Cardiac Hospital",
    BethzathaGeneralHospital = "Bethzatha General Hospital",
}

export interface InstitutionIDListLang {
    am: PurpleAm;
}

export interface PurpleAm {
    institutionName:       AmInstitutionName;
    summary:               string;
    address:               Address;
    institutionName_fuzzy: string[];
}

export interface Address {
    region:  Region;
    summary: Summary;
    woreda:  string;
    zone:    string;
}

export enum Region {
    አዲስአበባ = "አዲስ አበባ",
}

export enum Summary {
    ልደታክከተማመስቀልአደባባይአጠገብ = "ልደታ ክ/ከተማ መስቀል አደባባይ አጠገብ",
    ቦሌክከተማአዲስአበባኤርፖርትጭነትፊትለፊት = "ቦሌ ክ/ከተማ አዲስ አበባ ኤርፖርት ጭነት ፊት ለፊት",
}

export enum AmInstitutionName {
    ቤተዛታአጠቃላይሆስፒታል = "ቤተዛታ አጠቃላይ ሆስፒታል",
    አዲስየልብህክምናሆስፒታል = "አዲስ የልብ ህክምና ሆስፒታል",
}

export enum Language {
    Amharic = "Amharic",
    English = "English",
}

export interface MainInstitution {
    _id:             ID;
    availability:    Availability;
    services:        Service[];
    institutionName: InstitutionIDListInstitutionName;
    summary:         string;
    lang:            InstitutionIDListLang;
}

export interface Availability {
    twentyFourHours: boolean;
    startDay:        StartDay;
    endDay:          EndDay;
    opening:         Opening;
    closing:         Closing;
}

export enum Closing {
    The2359 = "23:59",
}

export enum EndDay {
    The6Sunday = "6Sunday",
}

export enum Opening {
    The0000 = "00:00",
}

export enum StartDay {
    The0Monday = "0Monday",
}

export interface Service {
    _id:         string;
    title:       string;
    description: string;
    lang:        ServiceLang;
}

export interface ServiceLang {
    am: FluffyAm;
}

export interface FluffyAm {
    title:        string;
    description?: string;
}

export enum Source {
    Doctors = "doctors",
}

export interface Speciality {
    _id:             string;
    isSubspeciality: boolean;
    name:            string;
    lang:            SpecialityLang;
}

export interface SpecialityLang {
    am: TentacledAm;
}

export interface TentacledAm {
    name:        string;
    description: string;
}
