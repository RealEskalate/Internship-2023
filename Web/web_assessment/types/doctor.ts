interface LanguageData {
    name: string;
    description: string;
  }
  
  interface LanguageTranslations {
    am: LanguageData;
  }
  
  interface Speciality {
    _id: string;
    isSubspeciality: boolean;
    name: string;
    lang: LanguageTranslations;
  }
  
  interface Address {
    region: string;
    summary: string;
    woreda: string;
    zone: string;
  }
  
  interface Institution {
    _id: string;
    institutionName: string;
    lang: LanguageTranslations;
  }
  
  interface Availability {
    twentyFourHours: boolean;
    startDay: string;
    endDay: string;
    opening: string;
    closing: string;
  }
  
  interface Service {
    _id: string;
    title: string;
    description: string;
    lang: LanguageTranslations;
  }
  
  interface MainInstitution {
    _id: string;
    availability: Availability;
    services: Service[];
    institutionName: string;
    lang: LanguageTranslations;
  }
  
  interface DoctorData {
    _id: string;
    phoneNumbers: any[];
    emails: any[];
    photo: string;
    summary: string;
    speciality: Speciality[];
    experience_years: number;
    institutionID_list: Institution[];
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
  
  interface UserData {
    success: boolean;
    message: string;
    totalCount: number;
    data: DoctorData[];
  }
  
  // Update mutation response type

  