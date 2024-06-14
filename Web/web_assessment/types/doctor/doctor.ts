interface DoctorsData {
  success: boolean;
  message: string;
  totalCount: Number;
  data: Doctor[];
}

export interface Doctor {
  _id: string;
  phoneNumbers: string[];
  // emails: string[];
  photo: string;
  summary: string;
  speciality: Speciality[];
  experience_years: Number;
  institutionID_list: institutionIDList[];
  gender: string;
  // languages: string[];
  // birthday: string;
  otherDocuments: string[];
  // experience: string[];
  fullName: string;
  // mainInstitution: MainInstitution;
  // education: string[];
  // availablity: string[];
  // __v: Number;
  fullName_fuzzy: string[];
  // source: string;
  // score: Number;
}

interface Speciality {
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

interface institutionIDList {
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

interface Services {
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

interface MainInstitution {
  _id: string;
  availability: {
    twentyFourHours: boolean;
    startDay: string;
    endDay: string;
    opening: string;
    closing: string;
  };
  services: Services[];
  institutionName: string;
  summary: string;
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
