export interface SearchResponse {
  success: boolean;
  message: string;
  totalCount: number;
  data: Doctor[];
}

export interface Doctor {
  _id: string;
  phoneNumbers: any[];
  emails: any[];
  photo: string;
  summary: string;
  speciality: Speciality[];
  experience_years: number;
  institutionID_list: InstitutionIdList[];
  gender: string;
  languages: string[];
  birthday: string;
  otherDocuments: any[];
  experience: any[];
  fullName: string;
  mainInstitution: MainInstitution;
  education: any[];
  availablity: any[];
  __v: number;
  fullName_fuzzy: string[];
  source: string;
  score: number;
}

export interface Speciality {
  _id: string;
  isSubspeciality: boolean;
  name: string;
  lang: Lang;
}

export interface Lang {
  am: Am;
}

export interface Am {
  name: string;
  description: string;
}

export interface InstitutionIdList {
  _id: string;
  institutionName: string;
  lang: Lang2;
}

export interface Lang2 {
  am: Am2;
}

export interface Am2 {
  institutionName: string;
  summary: string;
  address: Address;
  institutionName_fuzzy: string[];
}

export interface Address {
  region: string;
  summary: string;
  woreda: string;
  zone: string;
}

export interface MainInstitution {
  _id: string;
  availability: Availability;
  services: Service[];
  institutionName: string;
  summary: string;
  lang: Lang4;
}

export interface Availability {
  twentyFourHours: boolean;
  startDay: string;
  endDay: string;
  opening: string;
  closing: string;
}

export interface Service {
  _id: string;
  title: string;
  description: string;
  lang: Lang3;
}

export interface Lang3 {
  am: Am3;
}

export interface Am3 {
  title: string;
  description?: string;
}

export interface Lang4 {
  am: Am4;
}

export interface Am4 {
  institutionName: string;
  summary: string;
  address: Address2;
  institutionName_fuzzy: string[];
}

export interface Address2 {
  region: string;
  summary: string;
  woreda: string;
  zone: string;
}
