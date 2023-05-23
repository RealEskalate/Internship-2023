export interface Doctor {
    
      _id: string;
      phoneNumbers: string[];
      emails: string[];
      photo: string;
      summary: string;
      speciality: {
        _id: string;
        isSubspeciality: boolean;
        name: string;
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
      }[];
      gender: string;
      languages: string[];
      birthday: string;
      otherDocuments: any[];      experience: any[]; 
      fullName: string;
      mainInstitution: {
        _id: string;
        availability: {
          twentyFourHours: boolean;
          startDay: string;
          endDay: string;
          opening: string;
          closing: string;
        };
        services: {
          _id: string;
          title: string;
          description: string;
          lang: {
            am: {
              title: string;
              description: string;
            };
          };
        }[];
    }[];
  }
  