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
    am: {
      institutionName: string;
      summary: string;
      address: Address;
      institutionName_fuzzy: string[];
    };
  }
  
  interface Coordinates {
    type: string;
    coordinates: number[];
  }
  
  interface InstitutionID {
    _id: string;
    address: Address;
    availability: Availability;
    institutionType: string;
    establishedOn: string;
    institutionName: string;
    location: Coordinates;
    lang: Language;
  }
  
  interface Speciality {
    _id: string;
    isSubspeciality: boolean;
    name_fuzzy: string[];
    name: string;
    created_at: string;
    updated_at: string;
    __v: number;
    lang: {
      am: {
        name: string;
        description: string;
      };
    };
  }
  
  export interface Doctor {
    _id: string;
    emails: string[];
    photo: string;
    summary: string;
    speciality: Speciality[];
    experience_years: number;
    institutionID_list: InstitutionID[];
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
  export interface DoctorList {
    data:Doctor[],
    message:string,
    success:boolean,
    totalCount:number
  }
  