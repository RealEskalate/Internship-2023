export interface ResponseWrapper {
  data: any;
}

export interface DoctorsResponse {
  success: boolean;
  message: string;
  totalCount: number;
  data: Doctor[];
}

export interface Doctor {
  _id: string;
  phoneNumbers: string[];
  emails: string[];
  photo: string;
  summary: string;
  speciality: Speciality[];
  experience_years: number;
  institutionID_list: InstitutionIDList[];
  gender: string;
  languages: string[];
  birthday: Date;
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

export interface InstitutionIDList {
  _id: string;
  institutionName: string;
  lang: InstitutionIDListLang;
}

export interface InstitutionIDListLang {
  am: PurpleAm;
}

export interface PurpleAm {
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
  lang: InstitutionIDListLang;
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
  lang: ServiceLang;
}

export interface ServiceLang {
  am: FluffyAm;
}

export interface FluffyAm {
  title: string;
  description?: string;
}

export interface Speciality {
  _id: string;
  isSubspeciality: boolean;
  name: string;
  lang: SpecialityLang;
}

export interface SpecialityLang {
  am: TentacledAm;
}

export interface TentacledAm {
  name: string;
  description: string;
}
