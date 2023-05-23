export interface DoctorResponse {
  success: boolean;
  message: string;
  totalCount: number;
  data: Doctor[];
}

export interface Doctor {
  fullName: string;
  photo: string;
  speciality: Speciality[];
  institutionID_list: Institution[];
}

interface Speciality {
  name: string;
}

interface Institution {
  _id: string;
  institutionName: string;
}