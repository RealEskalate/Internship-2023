export interface HospitalResponse{
  success: boolean;
  message: string;
  totalCount: number;
  data: Hospital[];
}


export interface Hospital{
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
  rating: {
    "1": number;
    "2": number;
    "3": number;
    "4": number;
    "5": number;
  };
  phoneNumbers: string[];
  emails: string[];
  coverPhoto: string;
  photo: string;
  speciality: string[];
  pictures: string[];
  status: string;
  institutionType: string;
  establishedOn: string;
  institutionName: string;
  summary: string;
  location: {
    type: string;
    coordinates: number[];
  };
  website: string;
  __v: number;
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
  institutionName_fuzzy: string[];
  source: string;
  score: number;
}
