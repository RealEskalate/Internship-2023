interface Doctor {
    success: boolean;
    message: string;
    totalCount: number;
    data: DoctorData[];
  }
  
  export interface DoctorData {
    _id: string;
    phoneNumbers: string[];
    emails: string[];
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
  }
  
  export interface Speciality {
    _id: string;
    isSubspeciality: boolean;
    name: string;
    lang: {
      am: {
        name: string;
        description: string;
      };
    };
  }
  
  interface Institution {
    _id: string;
    institutionName: string;
    lang: {
      am: {
        institutionName: string;
        summary: string;
        address: {
          region: string;
          summary: string;
          woreda: string;
          zone: string;
        };
        institutionName_fuzzy: string[];
      };
    };
  }
  
  interface MainInstitution {
    _id: string;
    availability: {
      twentyFourHours: boolean;
      startDay: string;
      endDay: string;
      opening: string;
      closing: string;
    };
    services: Service[];
  }
  
  interface Service {
    _id: string;
    title: string;
    description: string;
    lang: {
      am: {
        title: string;
        description: string;
      };
    };
  }
  