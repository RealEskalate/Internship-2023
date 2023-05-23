export interface DoctorResponse {
  success: boolean;
  message: string;
  totalCount: number;
  data: Doctor[];
}

export interface Doctor {
  _id: string;
  fullName: string;
  photo: string;
  speciality: Speciality[];
  institutionID_list: Institution[];
  summary: string;
}

interface Speciality {
  name: string;
}

interface Institution {
  _id: string;
  institutionName: string;
}