type Coordinate = [number, number];

interface Address {
  region: string;
  summary: string;
  woreda: string;
  zone: string;
}

interface Availability {
  twentyFourHours: boolean;
  startDay: string;
  endDay: string;
  opening: string;
  closing: string;
}

interface Language {
  am: string;
}

interface Institution {
  _id: string;
  address: Address;
  availability: Availability;
  institutionType: string;
  establishedOn: string;
  institutionName: string;
  location: {
    type: string;
    coordinates: Coordinate;
  };
  lang: Language;
}

interface Specialty {
  _id: string;
  isSubspeciality: boolean;
  name_fuzzy: string[];
  name: string;
  created_at: string;
  updated_at: string;
  __v: number;
  lang: Language;
}

interface Doctor {
  _id: string;
  emails: string[];
  photo: string;
  summary: string;
  speciality: Specialty[];
  experience_years: number;
  institutionID_list: Institution[];
  gender: string;
  languages: string[];
  birthday: string;
  otherDocuments: any[]; // Adjust the type accordingly
  experience: any[]; // Adjust the type accordingly
  fullName: string;
  mainInstitution: string;
  education: any[]; // Adjust the type accordingly
  availablity: any[]; // Adjust the type accordingly
  __v: number;
  fullName_fuzzy: string[];
}
