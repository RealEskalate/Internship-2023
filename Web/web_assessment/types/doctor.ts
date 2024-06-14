export type Doctor = {
    _id: string;
    emails: string[];
    photo: string;
    summary: string;
    speciality: {
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
    }[];
    experience_years: number;
    institutionID_list: {
      _id: string;
      address: {
        region: string;
        woreda: string;
        zone: string;
        summary: string;
      };
      availability: {
        twentyFourHours: boolean;
        startDay: string;
        endDay: string;
        opening: string;
        closing: string;
      };
      institutionType: string;
      establishedOn: string;
      institutionName: string;
      location: {
        type: string;
        coordinates: [number, number];
      };
      lang: {
        am: {
          institutionName: string;
          summary: string;
        };
      };
    }[];
    gender: string;
    languages: string[];
    birthday: string;
    otherDocuments: any[]; // You can specify a more specific type if needed
    experience: any[]; // You can specify a more specific type if needed
    fullName: string;
    mainInstitution: string;
    education: any[]; // You can specify a more specific type if needed
    availablity: any[]; // You can specify a more specific type if needed
    __v: number;
    fullName_fuzzy: string[];
  }
  