export interface Welcome {
    success:    boolean;
    message:    string;
    totalCount: number;
    data:       Datum[];
}6

export interface Datum {
    _id:                   string;
    address:               Address;
    availability:          Availability;
    rating:                { [key: string]: number };
    phoneNumbers:          string[];
    emails:                any[];
    coverPhoto:            string;
    photo:                 string;
    speciality?:           any[];
    doctors:               Doctor[];
    pictures:              string[];
    status:                Status;
    services:              Service[];
    institutionType:       string;
    establishedOn:         Date;
    institutionName:       string;
    summary:               string;
    location:              Location;
    website:               string;
    __v:                   number;
    lang:                  DatumLang;
    institutionName_fuzzy: string[];
    source:                Source;
    score:                 number;
}

export interface Address {
    region:  Region;
    woreda:  string;
    zone:    string;
    summary: string;
}

export enum Region {
    AddisAbaba = "ADDIS ABABA",
    አዲስአበባ = "አዲስ አበባ",
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
    The0800 = "08:00",
    The0900 = "09:00",
}

export enum StartDay {
    The0Monday = "0Monday",
}

export interface Doctor {
    _id:                string;
    photo:              string;
    summary:            string;
    speciality:         string[];
    experience_years:   number;
    institutionID_list: MainInstitution[];
    gender:             Gender;
    languages:          Language[];
    birthday:           Date;
    otherDocuments:     any[];
    experience:         any[];
    fullName:           string;
    mainInstitution:    MainInstitution;
    education:          any[];
    availablity:        any[];
    __v:                number;
    fullName_fuzzy:     string[];
}

export enum Gender {
    Female = "Female",
    Male = "Male",
}

export enum MainInstitution {
    The629F12798373Fd1Bef2Db476 = "629f12798373fd1bef2db476",
    The629F12838373Fd1Bef2Db490 = "629f12838373fd1bef2db490",
    The629F12968373Fd1Bef2Db4DB = "629f12968373fd1bef2db4db",
    The629F129C8373Fd1Bef2Db501 = "629f129c8373fd1bef2db501",
    The62B5A97Ddd58Ed2C34D361E0 = "62b5a97ddd58ed2c34d361e0",
}

export enum Language {
    Amharic = "Amharic",
    English = "English",
}

export interface DatumLang {
    am: PurpleAm;
}

export interface PurpleAm {
    institutionName:       string;
    summary:               string;
    address:               Address;
    institutionName_fuzzy: string[];
}

export interface Location {
    type:        Type;
    coordinates: number[];
}

export enum Type {
    Point = "Point",
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
    Institutions = "institutions",
}

export enum Status {
    Open = "Open",
}