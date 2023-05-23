export interface DoctorProfileResponse {
  _id: string;
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
  mainInstitution: string;
  education: any[];
  availablity: any[];
  __v: number;
  fullName_fuzzy: string[];
}

export interface Speciality {
  _id: string;
  isSubspeciality: boolean;
  name_fuzzy: string[];
  name: string;
  created_at: string;
  updated_at: string;
  __v: number;
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
  address: Address;
  availability: Availability;
  institutionType: string;
  establishedOn: string;
  institutionName: string;
  location: Location;
  lang: Lang2;
}

export interface Address {
  region: string;
  woreda: string;
  zone: string;
  summary: string;
}

export interface Availability {
  twentyFourHours: boolean;
  startDay: string;
  endDay: string;
  opening: string;
  closing: string;
}

export interface Location {
  type: string;
  coordinates: number[];
}

export interface Lang2 {
  am: Am2;
}

export interface Am2 {
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
