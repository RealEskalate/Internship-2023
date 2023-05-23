export interface Doctor {
  fullName: string;
}

export interface DoctorResponse {
  success: boolean;
  message: string;
  totalCount: number;
  data: Doctor[];
}